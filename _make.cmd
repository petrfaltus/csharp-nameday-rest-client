@echo off

set DOTNET_HOME=C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319

set PROJECT=namedayrestclient
set ICON=ico\%PROJECT%.ico
set EXECUTABLE=bin\%PROJECT%.exe

set SOURCE=NameDayRestClient
set FORM=Form%SOURCE%

set JSON_DLL=bin\Newtonsoft.Json.dll

call _clean.bat

"%DOTNET_HOME%\csc.exe" /win32icon:%ICON% /reference:%JSON_DLL% /out:%EXECUTABLE% /target:winexe AssemblyInfo.cs Program.cs %FORM%.cs %FORM%.Designer.cs Search.cs Web.cs RestRequest1.cs RestReply1.cs RestRequest2.cs RestReply2.cs
