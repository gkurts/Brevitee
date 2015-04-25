cd .\BuildOutput\Debug\v4.5
"..\..\..\OpenCover\OpenCover.Console.exe" -target:".\bamtestrunner.exe" -targetargs:"/dir:. /search:*.tests.exe" -register:user -filter:"+[Brevitee*]*" -output:.\CodeCoverage.xml
