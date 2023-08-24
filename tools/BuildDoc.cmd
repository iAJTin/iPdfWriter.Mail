@ECHO OFF
CLS

rmdir ..\documentation /s /q

xmldocmd ..\src\lib\bin\Debug\netstandard2.0\iPdfWriter.Mail.dll ..\documentation

PAUSE
