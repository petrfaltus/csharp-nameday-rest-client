@echo off

set DOTNET_HOME=C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319

set PROJECT=namedayrestclient
set ICON=ico\%PROJECT%.ico
set EXECUTABLE=bin\%PROJECT%.exe

set SOURCE=NameDayRestClient
set FORM=Form%SOURCE%

call _clean.bat

"%DOTNET_HOME%\csc.exe" /win32icon:%ICON% /out:%EXECUTABLE% /target:winexe AssemblyInfo.cs Program.cs %FORM%.cs %FORM%.Designer.cs
