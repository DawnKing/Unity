#!/usr/bin/python
# -*- coding: gbk -*-

from proto_scanner import *

class ParseNode:
    """
          �﷨���ڵ� �﷨��token����ʾ�ڵ����ͣ�value�ǽڵ�ֵ
          ���⻹��Ҫ֪�����ڵ㣬�������ӽڵ�
    """
    def __init__(self, parent, token, value=None):
        """�ڵ��ʼ��
        """
        self.parent = parent
        self.token = token
        self.value = value
        self.childs = []
        self.prev_sibling = None
        self.next_sibling = None
        self.comment = ''        
        
    def Desc(self, offset):
        return "%s%s: %s\n" % (' ' * offset, self.token, self.value)
    
    def Dump(self, offset):
        """
                     ����ڵ���Ϣ
        """
        text = self.Desc(offset)
        for node in self.childs:
            text += node.Dump(offset + 4)
        return text
    
    def Apply(self, visitor):
        """
        Apply�ӿ��������������﷨���� �ο�Visitorģʽ
        """        
        s = visitor.BeginNode(self)
        for node in self.childs:
            s += node.Apply(visitor)
        s += visitor.EndNode(self)
        return s
    
    def __getitem__(self, index):
        return self.childs[index]

class Parser:
    """
            �﷨���������࣬�����ʷ��������ļ򵥽ӿ�
    """
    def __init__(self, lex_type):
        """
                     �﷨���������죬��Ҫָ���������ͣ����ڿ�ѡproto��cpp
        """        
        self.lex = BuildScanner(lex_type)
        self.tree = ParseNode(None, 'root', None)
        self.current = self.tree
        self.generators = []
        self.filename = ''

    def RegisterGenerator(self, gen):
        """
                     ע�����ɹ���
        """
        self.generators.append(gen)
        
    def DumpTree(self):
        """
                    �����ǰ�﷨����Ϣ
        """
        text = self.tree.Dump(0)
        print text
    
    def ParseFile(self, filename):
        self.tree.filename = filename
        self.filename = filename
        self.ParseString(file(filename).read())
    
    def ParseString(self, text):
        """
                     �����ı�
        """        
        self.lex.NewText(text)
        self.ParseProgram()

    def Eof(self):
        """
                    ��ǰ�Ƿ��ȡ���ļ�������
        """        
        return self.lex.token == '\0'
        
    def ParseProgram(self):
        """
                     ��������
        """
        try:
            while True:
                self.ParseStmt()
                if self.Eof():
                    break
        except LexicalError:
            self.lex.ShowError(self.filename)
            raise
        except SyntaxError:
            self.lex.ShowError(self.filename)
            raise
        
    def Consume(self, token):
        """
                    ����һ��token�����û�д�token���׳��쳣
        """        
        self.Expect(token)
        
    def TryConsume(self, token):
        self.lex.Scan()
        if self.lex.token == token:
            return True
        else:
            self.lex.Undo(1)
            return False

    def Expect(self, token):
        """
                     �ڴ�һ��token���������׳��쳣�����򷵻ش�tokenֵ
        """
        self.lex.Scan()
        if self.lex.token != token:
            print "Expect [%s], but [%s]" % (token, self.lex.token)
            raise SyntaxError
        return self.lex.value

    def Expect(self, tokens):
        """
                     �ڴ�tokens�е�һ��token���������׳��쳣�����򷵻ش�tokenֵ
        """
        self.lex.Scan()
        if self.lex.token not in tokens:
            print "Expect %s, but is [%s]" % (tokens, self.lex.token)
            raise SyntaxError
        return self.lex.value

    def AddChildNode(self, node):
        """
                     ���﷨��������һ���ڵ�
        """
        node.parent = self.current
        self.current.childs.append(node)
        for generator in self.generators:
            generator.OnAddNode(node)
