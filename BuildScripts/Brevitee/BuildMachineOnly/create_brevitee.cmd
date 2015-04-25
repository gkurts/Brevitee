call clone.cmd
C:
CD \

RMDIR /S /Q C:\src\Brevitee

CD C:\src\Brevitee\Brevitee\sync
call sync-BA-Brevitee.cmd

CD C:\src\Brevitee\Brevitee\BuildScripts\Brevitee

call clean.cmd

call build_solution.cmd Release v4.5
call build_toolkit.cmd
call copy_all.cmd