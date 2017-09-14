#!/usr/bin/python
# -*- coding: gbk -*-

from proto_scanner import *

class ParseNode:
    """
          语法树节点 语法树token来表示节点类型，value是节点值
          另外还需要知道父节点，和所有子节点
    """
    def __init__(self, parent, token, value=None):
        """节点初始化
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
                     输出节点信息
        """
        text = self.Desc(offset)
        for node in self.childs:
            text += node.Dump(offset + 4)
        return text
    
    def Apply(self, visitor):
        """
        Apply接口用来遍历整个语法树， 参考Visitor模式
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
            语法解析器基类，操作词法分析器的简单接口
    """
    def __init__(self, lex_type):
        """
                     语法分析器构造，需要指定语言类型，现在可选proto和cpp
        """        
        self.lex = BuildScanner(lex_type)
        self.tree = ParseNode(None, 'root', None)
        self.current = self.tree
        self.generators = []
        self.filename = ''

    def RegisterGenerator(self, gen):
        """
                     注册生成工具
        """
        self.generators.append(gen)
        
    def DumpTree(self):
        """
                    输出当前语法树信息
        """
        text = self.tree.Dump(0)
        print text
    
    def ParseFile(self, filename):
        self.tree.filename = filename
        self.filename = filename
        self.ParseString(file(filename).read())
    
    def ParseString(self, text):
        """
                     解析文本
        """        
        self.lex.NewText(text)
        self.ParseProgram()

    def Eof(self):
        """
                    当前是否读取到文件结束符
        """        
        return self.lex.token == '\0'
        
    def ParseProgram(self):
        """
                     解析程序
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
                    消耗一个token，如果没有此token，抛出异常
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
                     期待一个token，不符合抛出异常，否则返回此token值
        """
        self.lex.Scan()
        if self.lex.token != token:
            print "Expect [%s], but [%s]" % (token, self.lex.token)
            raise SyntaxError
        return self.lex.value

    def Expect(self, tokens):
        """
                     期待tokens中的一个token，不符合抛出异常，否则返回此token值
        """
        self.lex.Scan()
        if self.lex.token not in tokens:
            print "Expect %s, but is [%s]" % (tokens, self.lex.token)
            raise SyntaxError
        return self.lex.value

    def AddChildNode(self, node):
        """
                     在语法树上增加一个节点
        """
        node.parent = self.current
        self.current.childs.append(node)
        for generator in self.generators:
            generator.OnAddNode(node)
