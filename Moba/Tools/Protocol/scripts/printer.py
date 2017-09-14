# -*- coding: gbk -*-

import os.path
import sys

class Printer:
    def __init__(self, filename = None):        
        self.offset = 0
        self.lines = []
        self.filename = filename
        self.sameLine = False
    def GetIndent(self):
        return self.offset * ' '
    def IncIndent(self):
        self.offset += 4
    def DecIndent(self):
        self.offset -= 4
    def AppendLine(self, text):
        self.sameLine = False
        for l in text.split('\n'):
            self.lines.append(self.GetIndent() + l)    
    def AppendSameLine(self, text):
        self.sameLine = False
        self.lines[-1] += text
    def AppendComment(self, text):
        if self.sameLine and text[:2] == "//":
            addSpace = 32 - len(self.lines[-1])
            if addSpace < 0:
                addSpace = 0
            self.lines[-1] += addSpace * ' ' + text
        else:
            self.AppendLine(text)
        self.sameLine = False
    def Flush(self):   
        if self.filename == None:
            self.fp = sys.stdout
        else:
            dir = os.path.dirname(self.filename)
            if not os.path.isdir(dir):
                os.makedirs(dir)

            self.fp = file(self.filename, "w+")
            
        for l in self.lines:
            self.fp.write(l + "\n")
