@echo off
call C:\src\Brevitee\Brevitee\Brevitee.Server\zip_base_app_and_content.cmd
call .\restore.cmd
SET OutputPath=C:\src\Brevitee\Brevitee\BuildScripts\Brevitee\BuildOutput\%1\

if "%2" == "v4.5" GOTO NEXT

SET VER=v4.0
SET NEXT=NEXT
GOTO BUILD

:NEXT
SET VER=v4.5
SET NEXT=END
GOTO BUILD

:BUILD

rmdir /Q /S %OutputPath%%VER%
mkdir %OutputPath%%VER%
.\MSBuild\MSBuild.exe /t:Build /m /filelogger /p:AutoGenerateBindingRedirects=true;GenerateDocumentation=true;OutputPath=%OutputPath%%VER%;Configuration=%1;Platform="Any CPU";CompilerVersion=%VER% c:\src\Brevitee\Brevitee\Brevitee.Nuget.sln

IF ERRORLEVEL 1 GOTO END

GOTO %NEXT%

:END
EXIT /b %ERRORLEVEL%