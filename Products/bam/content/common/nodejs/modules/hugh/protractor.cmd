@IF EXIST "%~dp0\node.exe" (
  "%~dp0\node.exe"  "%~dp0\node_modules\protractor\bin\protractor" %*
) ELSE (
  node  "%~dp0\node_modules\protractor\bin\protractor" %*
)