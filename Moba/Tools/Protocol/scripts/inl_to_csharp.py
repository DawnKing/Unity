#!/usr/bin/python

import sys
import re
from printer import Printer

def GetComment(line):
    what = re.compile(".*//(.*)").match(line)
    if what != None and len(what.groups()) > 0:
        return what.groups()[0]
    else:
        return ""
        

def Transform(filename, out):
    lines = open(filename).readlines()
    
    printer = Printer(out)
    printer.AppendLine("// Generated by inltoas.py. DO NOT EDIT!")
    printer.AppendLine("namespace GameProtocol")
    printer.AppendLine("{")
    printer.IncIndent()
    printer.AppendLine("public sealed class MessageType")
    printer.AppendLine("{")
    printer.IncIndent()

    re_assign = re.compile("MSGTYPE_DECLARE_ASSIGN\((\S+),\s*(\d+)\)")
    re_declare = re.compile("MSGTYPE_DECLARE\(\s*(\S+)\s*\)")
    
    index = 0
    for line in lines:
        if "MSGTYPE_BEGIN_BLOCK" in line:
            pass            
            
        
        # prase assign state
        what = re_assign.match(line)        
        if what != None:
            msgName = what.groups()[0]
            assIndex = what.groups()[1]

            comment = GetComment(line)   
                
            printer.AppendLine("public const short %s = %s; // %s"
                      % (msgName, assIndex, comment.decode("gbk").encode("utf8")))
            index = int(assIndex)
            continue

        # parse declcare statements
        what = re_declare.match(line)
        if what != None:
            msgName=what.groups()[0]
            comment = GetComment(line)
            assIndex = index + 1
            printer.AppendLine("public const short %s = %s; // %s"
                      % (msgName, assIndex, comment.decode("gbk").encode("utf8")))
            index = assIndex
            continue
        
        line = line.strip()
        if line.startswith("//") or len(line) == 0:
            printer.AppendLine("%s" % line.decode("gbk").encode("utf8"))
        else:
            printer.AppendLine("// %s" % line.decode("gbk").encode("utf8"))

    printer.DecIndent()
    printer.AppendLine("}")
    printer.DecIndent()
    printer.AppendLine("}")    
    printer.Flush()


if __name__ == "__main__":
    """
    usage: inttoas.py INL_FILE OUT_FILE
    """
    input_path = sys.argv[1]
    output_path = None
    if len(sys.argv) > 2:
        output_path = sys.argv[2]
    Transform(input_path, output_path)