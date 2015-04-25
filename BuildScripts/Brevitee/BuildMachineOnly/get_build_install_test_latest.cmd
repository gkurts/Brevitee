SET EnableNuGetPackageRestore=true

D:
cd \BuildScripts
call clone.cmd

D:
cd \BuildScripts
call nugetrestore.cmd

cd C:\src\Brevitee\Brevitee\BuildScripts\Brevitee
call build_and_install_toolkit.cmd

C:
cd C:\src\Brevitee\Brevitee\BuildScripts\Brevitee
call build_and_run_tests_w_coverage.cmd

cd C:\src\Brevitee\Brevitee\BuildScripts\Brevitee
call generate_coverage_report.cmd