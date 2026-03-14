@echo off
setlocal

set "REPO_DIR=%USERPROFILE%\Documents\Repos\YSM-GMTool"
set "PUBLISH_DIR=%USERPROFILE%\Desktop\GM Tool\"
set "PUBLISH_SCRIPT=%REPO_DIR%\scripts\publish-release.ps1"

if not exist "%PUBLISH_SCRIPT%" (
    echo Missing publish script: "%PUBLISH_SCRIPT%"
    exit /b 1
)

powershell -NoProfile -ExecutionPolicy Bypass -File "%PUBLISH_SCRIPT%" -PublishDir "%PUBLISH_DIR%"
exit /b %ERRORLEVEL%
