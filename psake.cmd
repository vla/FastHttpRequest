@echo off
setlocal
title Fast Http Request Build
echo.
echo "++++++++++++++++++++++++++++++++++++++++++++++++++++"
echo "+       Fast Http Request Build       
echo "+                                   
echo "+           v.la@Live.cn                           
echo "+                                   
echo "++++++++++++++++++++++++++++++++++++++++++++++++++++"
:menu
echo.
echo [1]   Build Lib
echo [2]   Build Nuget
echo [h]   psake help
echo [0]   Exit
echo.
@echo Please select?
@echo Enter the above option to enter
@echo off

set /p menu=

if %menu% == 0 goto exit
if %menu% == 1 goto 1
if %menu% == 2 goto 2
if %menu% == h goto help
goto :eof

:1
powershell -NoProfile -ExecutionPolicy Bypass -Command "& '%~dp0tools\psake\psake.ps1' build.ps1 %*; if ($psake.build_success -eq $false) { exit 1 } else { exit 0 }"
echo.
echo Build ok!
echo.
set menu=
goto menu

:2
powershell -NoProfile -ExecutionPolicy Bypass -Command "& '%~dp0tools\psake\psake.ps1' build-nuget.ps1 %*; if ($psake.build_success -eq $false) { exit 1 } else { exit 0 }"
echo.
echo Build ok!
echo.
set menu=
goto menu

:help
powershell -NoProfile -ExecutionPolicy Bypass -Command "& '%~dp0tools\psake\psake.ps1' -help"
goto menu

:exit
goto :eof

