@echo off

SET LIB=net40
SET VER=v4.0
SET NEXT=NEXT
GOTO COPY

:NEXT
SET LIB=net45
SET VER=v4.5
SET NEXT=END
GOTO COPY

:COPY
MD Brevitee.Data.Repositories\lib\%LIB%
copy /Y .\BuildOutput\Release\%VER%\Brevitee.Data.Repositories.dll Brevitee.Data.Repositories\lib\%LIB%\Brevitee.Data.Repositories.dll
copy /Y .\BuildOutput\Release\%VER%\Brevitee.Data.Repositories.xml Brevitee.Data.Repositories\lib\%LIB%\Brevitee.Data.Repositories.xml
GOTO %NEXT%

:END


