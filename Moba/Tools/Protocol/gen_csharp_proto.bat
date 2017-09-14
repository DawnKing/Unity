@echo off
set tools=.\scripts
set target=..\..\Assets\Scripts\Protocol

@echo "Generate csharp proto files begin"

del /s %target%\*.cs
python %tools%\inl_to_csharp.py .\input\message.inl %target%\MessageType.cs
python %tools%\proto_to_csharp.py .\input %target%

@echo "Generate csharp proto files end."

pause