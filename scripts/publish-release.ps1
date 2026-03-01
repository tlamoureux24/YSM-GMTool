param(
    [string]$PublishDir = "$env:USERPROFILE\Documents\YSMReleasedTools\GM-Tool\"
)

$ErrorActionPreference = "Stop"

if (Test-Path $PublishDir) {
    Remove-Item -Path $PublishDir -Recurse -Force
}

New-Item -ItemType Directory -Path $PublishDir -Force | Out-Null

dotnet build ".\src\App.WinForms\App.WinForms.csproj" `
    -c Release `
    -p:RuntimeIdentifier=win-x64 `
    -p:AutoPublishDir="$PublishDir" `
    -p:AutoPublishOnRelease=true
