#!/usr/bin/python
# -*- coding: gbk -*-
import os
import glob
import string

def IsNum(s):
    """
           字符串S中的字符是否都是数字字符    
    """
    for c in s:
        if c not in string.digits:
            return False
    return True

def DumpDir(dir, func):
    index = 1
    files = glob.glob(dir)    
    for file in files:         
        print " File \"%s\", line 1, [%d/%d] " % (os.path.abspath(file), index, len(files))
        func(file)
        index += 1

def DumpDirExt(file_ext, input_path, target_path, func):
    filelist = []
    if os.path.isfile(input_path):
        filelist.append(input_path)
    elif os.path.isdir(input_path):
        filelist = glob.glob(input_path+"//*" + file_ext)
    assert len(filelist) > 0
    
    target_dir = target_path
    if not os.path.isdir(target_dir):
        os.mkdir(target_dir)    
       
    for filename in filelist:            
        func(filename, target_dir)

def RunProfile(main):
    import hotshot, hotshot.stats, test.pystone
    prof = hotshot.Profile("stones.prof")
    prof.runcall(main)
    prof.close()
    stats = hotshot.stats.load("stones.prof")
    stats.strip_dirs()
    stats.sort_stats('time', 'calls')
    stats.print_stats(20)
