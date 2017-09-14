@echo off
set tools=.\scripts\
set target=..\..\Assets\Scripts\Templates

@echo "Generate csharp template files begin"
@echo ""

del /s %target%\*.cs
python %tools%\template_to_csharp.py -i input -o %target%\

@echo ""
@echo "Generate csharp template files end."

pause
