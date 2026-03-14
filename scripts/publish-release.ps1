param(
    [string]$PublishDir = "$env:USERPROFILE\Documents\YSMReleasedTools\GM-Tool\"
)

$ErrorActionPreference = "Stop"
$RepoRoot = Split-Path -Parent $PSScriptRoot
$ProjectPath = Join-Path $RepoRoot "src\App.WinForms\App.WinForms.csproj"
$PublishedExePath = Join-Path $PublishDir "GM Tool.exe"

Get-Process |
    Where-Object {
        try {
            $_.Path -eq $PublishedExePath
        }
        catch {
            $false
        }
    } |
    Stop-Process -Force -ErrorAction SilentlyContinue

if (Test-Path $PublishDir) {
    Remove-Item -Path $PublishDir -Recurse -Force
}

New-Item -ItemType Directory -Path $PublishDir -Force | Out-Null

dotnet build $ProjectPath `
    -c Release `
    -p:RuntimeIdentifier=win-x64 `
    -p:AutoPublishDir="$PublishDir" `
    -p:AutoPublishOnRelease=true
