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
MD Brevitee.Data\lib\%LIB%
copy /Y .\BuildOutput\Release\%VER%\Brevitee.Data.dll Brevitee.Data\lib\%LIB%\Brevitee.Data.dll
copy /Y .\BuildOutput\Release\%VER%\Brevitee.Data.xml Brevitee.Data\lib\%LIB%\Brevitee.Data.xml
copy /Y .\BuildOutput\Release\%VER%\Brevitee.Data.Model.dll Brevitee.Data\lib\%LIB%\Brevitee.Data.Model.dll
copy /Y .\BuildOutput\Release\%VER%\Brevitee.Data.Model.xml Brevitee.Data\lib\%LIB%\Brevitee.Data.Model.xml
copy /Y .\BuildOutput\Release\%VER%\Brevitee.Data.MsSql.dll Brevitee.Data\lib\%LIB%\Brevitee.Data.MsSql.dll
copy /Y .\BuildOutput\Release\%VER%\Brevitee.Data.MsSql.xml Brevitee.Data\lib\%LIB%\Brevitee.Data.MsSql.xml
copy /Y .\BuildOutput\Release\%VER%\Brevitee.Data.Repositories.dll Brevitee.Data\lib\%LIB%\Brevitee.Data.Repositories.dll
copy /Y .\BuildOutput\Release\%VER%\Brevitee.Data.Repositories.xml Brevitee.Data\lib\%LIB%\Brevitee.Data.Repositories.xml
copy /Y .\BuildOutput\Release\%VER%\Brevitee.Data.Schema.dll Brevitee.Data\lib\%LIB%\Brevitee.Data.Schema.dll
copy /Y .\BuildOutput\Release\%VER%\Brevitee.Data.Schema.xml Brevitee.Data\lib\%LIB%\Brevitee.Data.Schema.xml
copy /Y .\BuildOutput\Release\%VER%\Brevitee.Data.SQLite.dll Brevitee.Data\lib\%LIB%\Brevitee.Data.SQLite.dll
copy /Y .\BuildOutput\Release\%VER%\System.Data.SQLite.dll Brevitee.Data\lib\%LIB%\System.Data.SQLite.dll
GOTO %NEXT%

:END


