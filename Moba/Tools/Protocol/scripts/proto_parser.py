#!/usr/bin/python
# -*- coding: gbk -*-

import os

from base_parser import *
from util import DumpDir
       
class ProtoParser(Parser):
    """
    message 语言定义的语法:
       prog             := stmts
       stmts            := stmt  stmts
       stmt             := package_stmt; |
                           option_stmt;  |
                           message_stmt  |
                           enum_stmts    |
                           comment_stmts
                           
       message_stmts    := message_stmt | message_stmts
       message_stmt     := message ID { message_stmts field_stmts enum_stmts }
       enum_stmts       := enum_stmt | enum_stmts
       enum_stmt        := enum ID { enum_field_stmts }            
       enum_field_stmts := enum_field_stmt | enum_field_stmts;
       enum_field_stmt  := ID = NUMBER;
       field_stmts      := field_stmt | field_stmt ; field_stmts;
       field_stmt       :=
       package_stmt     := package ID;
    """
    def __init__(self):
        Parser.__init__(self, 'proto')
    
    def ParseStmt(self):
        self.lex.Scan()
        if self.lex.token == "comment":
            self.AddChildNode(ParseNode(self.current, "comment", self.lex.value))
        elif self.lex.token == "package":
            self.ParsePackage()
        elif self.lex.token == "option":
            self.ParseOption()
        elif self.lex.token == "message":
            self.ParseMessage()
        elif self.lex.token == "struct":
            self.ParseStruct()
        elif self.lex.token == "enum":
            self.ParseEnum()
        elif self.lex.token == "import":
            self.ParseImport()
        elif self.lex.token == "\0":
            #print "Parse END."
            pass
        else:
            print "TODO UNKNOWN TOKEN: %s\%s" % (self.lex.token, self.lex.ShowError())
    
    def ParseImport(self):
        token, value, line_no = self.lex.Scan().ToTriList()
        if token != "identifier":
            raise SyntaxError
        self.AddChildNode(ParseNode(self.current, 'import_stmt', value))
        self.Consume(";")
    
    def ParsePackage(self):
        self.lex.Scan()
        if self.lex.token != 'identifier':            
            raise SyntaxError
        package_name = self.lex.value        
        self.Consume(';')
        self.AddChildNode(ParseNode(self.current, 'package_stmt', package_name))

    def ParseOption(self):
        option_name = self.Expect('identifier')
        self.Consume("=")
        option_value = self.Expect(['const_string', 'number', 'identifier'])
        self.Consume(";")
        self.AddChildNode(ParseNode(self.current, 'option_stmt', [option_name, option_value]))

    def ParseMessage(self):
        message_name = self.Expect('identifier')
        message_node = ParseNode(self.current, 'message_stmt', message_name)
        self.AddChildNode(message_node)
        self.Consume("{")
        self.lex.Scan()
        while self.lex.token != '}':
            self.current = message_node
            if self.lex.token == "message":
                self.ParseMessage()
            elif self.lex.token in ['required', 'optional', 'repeated']:
                self.ParseMessageField(self.lex.token)
            elif self.lex.token == 'comment':
                self.AddChildNode(ParseNode(self.current, "comment", self.lex.value))
            elif self.lex.token == 'enum':
                self.ParseEnum()
            elif self.lex.token == 'struct':
                self.ParseStruct()
            elif self.lex.token == 'option':
                self.ParseOption()
            elif self.lex.token == ";":
                self.lex.Scan()
                continue
            else:
                raise SyntaxError
            self.lex.Scan()

        self.current = self.current.parent
        assert self.current != None
        
    def ParseMessageField(self, field_lable):
        field_type = self.Expect(["type", "identifier"])
        field_name = self.Expect("identifier")
        self.Consume("=")
        field_num = self.Expect("number")
        self.lex.Scan()
        if self.lex.token == ";":
            self.AddChildNode(ParseNode(self.current, 'field_stmt', [field_lable, field_type, field_name, field_num]))
            return
        elif self.lex.token == '[':
            option_name = self.Expect("identifier")
            self.Consume("=")
            default_value = self.Expect(['number','identifier'])
            self.Consume("]")
            self.Consume(";")
            # option value for use in furture
            self.AddChildNode(ParseNode(self.current, 'field_stmt', [field_lable, field_type, field_name, field_num]))
 
    def ParseStruct(self):
        struct_name = self.Expect("identifier")
        struct_node = ParseNode(self.current, 'struct_stmt', struct_name)
        self.AddChildNode(struct_node)
        self.Consume("{")
        self.lex.Scan()
        while self.lex.token != '}':
            self.current = struct_node
            self.ParseStructField()
            self.lex.Scan()
        self.current = struct_node.parent

    def ParseStructField(self):
        if self.lex.token == 'comment':
            self.AddChildNode(ParseNode(self.current, "comment", self.lex.value))
            return
        if self.lex.token not in ["type", "identifier"]:
            raise SyntaxError
        struct_field_type = self.lex.value
        struct_field_name = self.Expect("identifier")
        self.lex.Scan()
        if self.lex.token == ";":
            self.AddChildNode(ParseNode(self.current, 'struct_field_stmt', [struct_field_type, struct_field_name]))
        elif self.lex.token == "[":
            struct_field_dims = self.Expect("number")
            self.Consume("]")
            self.Consume(";")
            self.AddChildNode(ParseNode(self.current, 'struct_field_stmt', [struct_field_type, struct_field_name, struct_field_dims]))

    def ParseEnum(self):
        token, value = self.lex.Scan().ToList()
        if token == "identifier":
            enum_name = value
        elif token == "{": # unnamed enum 
            enum_name = "unnamed"
            self.lex.Undo()
                                
        enum_node = ParseNode(self.current, 'enum_stmt', enum_name)
        self.AddChildNode(enum_node)
        self.Consume("{")        
        self.lex.Scan()
        while self.lex.token != '}':
            if self.lex.token == "comment":
                self.AddChildNode(ParseNode(enum_node, "comment", self.lex.value))
            else:
                self.current = enum_node
                self.ParseEnumField()
            self.lex.Scan()
        self.current = enum_node.parent

    def ParseExperssion(self):
        expr = '' 
        self.lex.Scan()
        while self.lex.token not in [';', '}', ']']:
            if self.lex.token in ["identifier", "number"]:
                expr += self.lex.value
            else:
                expr += self.lex.token
            self.lex.Scan()        
        self.lex.Undo(1)
        return expr
    
    def ParseEnumField(self):
        if self.lex.token != 'identifier':
            raise SyntaxError        
        enum_field_name = self.lex.value
        self.Consume('=')
        enum_field_value = self.ParseExperssion()
        self.Consume(";")
        self.AddChildNode(ParseNode(self.current, 'enum_field_stmt', [enum_field_name, enum_field_value]))


if __name__ == "__main__":
    def DumpFile(filename):
        parser = ProtoParser()
        parser.ParseFile(filename)
        parser.DumpTree()
    DumpDir("../proto_out/*.proto", DumpFile)

    
  
