@ECHO OFF
CLS

rmdir ..\documentation /s /q

xmldocmd ..\src\lib\iPdfWriter\iPdfWriter.Net.Mail\bin\Debug\net461\iPdfWriter.Net.Mail.dll ..\documentation

PAUSE
