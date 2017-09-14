#!/usr/bin/python
# -*- coding: gbk -*-

from proto_parser import ProtoParser

proto_type_map = {}

class ProtoHandler:
    def __init__(self):
        self.package_set = set()
        self.enum_set = set()
        self.class_set = set()
    def OnAddNode(self, node):
        if node.token == "package":
            self.package_set.add(node)
        elif node.token == "enum_stmt":
            self.enum_set.add(node)
        elif node.token == "message_stmt":
            self.class_set.add(node)

def FindCachedProtoTypes(proto_file):
    """
    return enum_list and class_list in a proto file
    """
    if proto_type_map.has_key(proto_file):
        return proto_type_map[proto_file]
    else:
        generator = ProtoHandler()
        parser = ProtoParser()
        parser.RegisterGenerator(generator)
        parser.ParseFile(proto_file)
        proto_type_map[proto_file] = [generator.enum_set, generator.class_set]
        return proto_type_map[proto_file]
