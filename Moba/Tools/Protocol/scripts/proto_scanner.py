#!/usr/bin/python
# -*- coding: gbk -*-

"""
# proto 格式的语法
# 关键字: message package option required optinal enum repeated default
# 操作符: { } = ; [ ]
# 序号
# 字符串
# 数字
# Identifier
# comment //
"""

import string
from util import IsNum

class SyntaxError:
    """
           语法错误异常
    """
    def __init__(self):
        mstr = 'Syntax Error'
        
class LexicalError:
    """
          词法错误异常    
    """
    def __init__(self):
        m_str = 'Lexical Error'

"""
protocol 协议定义语言的词法定义
"""
proto_lexical_data = {
    'keywords':  set(['message', 'package', 'option', 'optional', 'repeated', 'required', 'enum', 'default', 'struct', 'import']),
    'operators': set(['{', '}', '[', ']', ';', '=', '\0']),
    'types':     ['int32', 'string'],
    'comments':  [['/*', '*/', 'comment'], ['//', '\n', 'comment']]
    }

"""
c++ 协议定义语言的词法定义
"""
cpp_lexical_data = {
    'keywords':  ['class', '#define', '#endif', '#ifndef', 'public', 'private', 'enum', '#include', 'struct', 'typedef'],
    'operators': ['{', '}', '[', ']', ';', '=', '(', ')', ',', '::', ':', '<<', '<', '>', '\0'],
    'types':     ['int32', 'std::string', 'int', 'long', 'short'],
    'comments':  [['/*', '*/', 'comment'], ['//', '\n', 'comment'], ['#', '\n', 'preprocesor']]
    }

class Token:
    def __init__(self, token_type, value, line_no):
        self.token = token_type
        self.value = value
        self.line_no = line_no
    def ToList(self):
        return [self.token, self.value]
    
    def ToTriList(self):
        return [self.token, self.value, self.line_no]

class Scanner:
    """
    Source code scanner.    
    """
    def __init__(self, lex_data, text):
        """
                     初始化语法解析器  lex_data语言语法数据 text是需要解析的文本                                     
        """
        self.keyword_list = lex_data['keywords']
        self.operator_list = lex_data['operators']
        self.type_list = lex_data['types']
        self.region_mark_list = lex_data['comments']
        self.NewText(text)

    def NewText(self, text):
        """
                     重新传入要解析的文本，并重置解析器
        """
        self.next = 0
        self.text = text + '\0'
        self.last = []
        self.cur_line_no = 0
        
    def GetLineNo(self):
        return self.cur_line_no

    def ShowError(self, filename=''):
        """
                    打印错误位置
        """
        
        begin = self.text.rfind('\n', 0, self.start) + 1
        end = self.text.find('\n', self.start)
        line_no = self.text[:self.start].count('\n')
        tab_count = self.text[begin:self.start].count('\t')
        
        if filename != "" or filename != None:            
            print '\n  File "%s", line %d, in Parsing' % (filename, line_no)
        print '=>', self.text[begin:end]
        print '=>', ' ' * ((self.start - begin) + 1 + tab_count*3) + '^'

    def Match(self):
        if self.token != token:
            raise SyntaxError, [token]
        else:
            value = self.value
            if self.token != '\0':
                self.Scan()  # next token/value
            return value     # return prior value
        
    def Undo(self, step = 1):
        """
                     撤消scan，setp表示撤消几个token        
        """
        self.value = ''
        while step > 0:            
            self.next, self.cur_lin_no = self.last.pop()
            step -= 1

    def Scan(self):
        """
                     从文本中提取一个token
        """
        self.value = ''
        self.last.append([self.next, self.cur_line_no])
        ix = self.next

        # Skip whitespace.
        while self.text[ix] in string.whitespace:
            if self.text[ix] == "\n":
                self.cur_line_no += 1
            ix = ix + 1
        self.start = ix
        
        # read comment or preprocessor directives
        for region_mark in self.region_mark_list:
            begin_mark = region_mark[0]
            end_mark = region_mark[1]
            token = region_mark[2]
            
            if self.text[ix:(ix+len(begin_mark))] == begin_mark:
                self.next = self.text.find(end_mark, self.start)
                ix = self.next + len(end_mark)
                self.value = self.text[self.start:ix]
                lines = self.value.count("\n")
                self.value = self.value.strip()
                self.token = token
                self.next = ix
                token = Token(self.token, self.value, self.GetLineNo())
                self.cur_line_no += lines
                return token
        
        # parse C-style string
        if self.text[ix] == '"' or self.text[ix] == "'":
            ending = self.text[ix]
            ix += 1
            while self.text[ix] != ending:
                if self.text[ix] == '\\':
                    ix += 2
                else:
                    ix += 1
            ix += 1
            self.token = "const_string"
            self.value = self.text[self.start:ix]
            self.next = ix
            token = Token(self.token, self.value, self.GetLineNo())
            self.cur_line_no += self.value.count("\n")
            return token

        # parse operator
        for operator in self.operator_list:
            if self.text[self.start:self.start+len(operator)] == operator:
                self.token = operator
                self.next = self.start + len(operator)
                return Token(self.token, self.value, self.GetLineNo())
        # parse word
        while self.text[ix] not in string.whitespace and self.text[ix] not in self.operator_list:
            ix += 1
        totext = self.text[self.start:ix]
        # keywords
        if totext in self.keyword_list:
            self.token = totext
        # type
        elif totext in self.type_list:
            self.token = 'type'            
        # number        
        elif IsNum(totext):
            self.token = 'number'        
        # identifier
        elif True:
            self.token = "identifier"
        self.value = totext
        self.next = ix
        return Token(self.token, self.value, self.GetLineNo())
        
        
def BuildScanner(lex_type):
    """
    Create a scanner according by lex_type, now support cpp and proto.
    """
    if lex_type=="cpp":
        assert True
        return Scanner(cpp_lexical_data, '')
    else:
        return Scanner(proto_lexical_data, '')   

def TestProto(filename):
    lex_data = proto_lexical_data
    if filename.endswith(".h"):
        lex_data = cpp_lexical_data
    
    lex = Scanner(lex_data, file(filename).read())
    try:
        index = 0
        while True:
            token = lex.Scan()
            if token.token == '\0':
                break            
            print "%4d %5d %20s %s" % (index, token.line_no, token.token, token.value)
            index += 1        
    except LexicalError:
        lex.ShowError()

if __name__=="__main__":   
    TestProto("..\\test\\cpp\\Test.h")
    
            
            
        
