@ECHO OFF
CLS

rmdir ..\documentation /s /q

xmldocmd ..\src\lib\iPdfWriter\iPdfWriter.Mail\bin\Debug\netstandard2.0\iPdfWriter.Mail.dll ..\documentation

PAUSE
