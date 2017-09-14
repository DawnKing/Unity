set SRC_DIR=%cd%\include
set DST_DIR=%cd%\..\Common\Common\Proto

del /s %DST_DIR%\*.cs

for /R %SRC_DIR% %%i in (*.proto) do ( 
    .\protoc -I=%SRC_DIR% --csharp_out=%DST_DIR% %%i
) 

pause