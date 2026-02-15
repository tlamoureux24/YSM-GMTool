# YSM GM Tool (WinForms, .NET 10)

Desktop GM tool for game DB browsing and Lua command generation.

## Stack
- .NET 10 (`net10.0-windows`)
- WinForms with native dark mode (`Application.SetColorMode(SystemColorMode.Dark)`)
- Dapper
- Microsoft.Data.SqlClient
- MySqlConnector
- Serilog
- FontAwesome.Sharp

## Project structure
- `src/App.Core` - domain models, query/lua stores, search normalization, settings, command history
- `src/App.Data` - database connectors and Dapper repository
- `src/App.WinForms` - UI, presenters, settings form, action controls

## Dark mode API note (A/B)
- Variant A (current .NET 10 SDK/docs): `Application.SetColorMode(SystemColorMode.Dark)`
- Variant B (older previews): no stable `SetColorMode` API; keep fallback/no-op

Current implementation uses Variant A.

## Run
1. `dotnet restore YSM-GMTool.slnx`
2. `dotnet run --project src/App.WinForms/App.WinForms.csproj`

## Environment variables (`.env`)
- Local `.env` is loaded automatically at startup (searching up from current and app base directory).
- Supported keys:
  - `YSM_DB_PROVIDER` (e.g. `MSSQL` or `MySQL`)
  - `YSM_DB_CONNECTION_STRING`
- `.env` is excluded from git in `.gitignore`.
- For local SQL Server with self-signed cert, add `TrustServerCertificate=True` to connection string.
- During `Release` auto-publish, local repo `.env` is copied to publish folder (if exists).

## Configuration files
- SQL queries: `src/App.WinForms/Config/queries.json`
- Lua command templates: `src/App.WinForms/Config/lua_commands.json`

Both files are copied to output under `bin/.../Config/`.

## App settings storage
User settings are persisted in:
`%LocalAppData%\YSM-GMTool\settings.json`

Contains database provider, connection string, sidebar player list, and append mode.

## Logs
Serilog writes logs to:
`%LocalAppData%\YSM-GMTool\logs\gmtool-YYYYMMDD.log`

## Auto publish on Release build
- `src/App.WinForms/App.WinForms.csproj` has an auto-publish target.
- Every `Release` build triggers `Publish` to:
  - `%USERPROFILE%\Desktop\GM Tool\`
- If files are locked (app running from publish folder), close the app before running `Release` build.
- Publish is configured as framework-dependent (runtime from system), to keep size low.
