# GM Tool

Windows desktop GM utility for browsing game data and generating Lua commands from UI actions.

Built with WinForms on .NET 10, with native dark mode and async database access (MSSQL + MySQL).

## Key Features
- Multi-tab workflow: `Playerchecker`, `Monster`, `Items`, `Skills`, `Buffs`, `NPCs`, `Summons`
- Fast in-memory filtering after `Load All`
- Async DB operations with cancellation support
- Provider-aware SQL query store (`queries.json`)
- Lua command template store (`lua_commands.json`)
- Command generation directly to clipboard
- Optional `/run ` prefix mode:
  - If `Append /run to commands` is checked, generated commands get `/run ` prefix
  - Commands starting with `//` are not prefixed
- Native dark mode via .NET 10 WinForms API

## Tech Stack
- .NET 10 (`net10.0-windows`, `LangVersion=latest`)
- WinForms
- Dapper
- `Microsoft.Data.SqlClient`
- `MySqlConnector`
- Serilog (`Serilog.Sinks.File`)
- FontAwesome.Sharp

## Requirements
- Windows 10/11 (x64)
- .NET 10 Desktop Runtime installed
- Access to one of:
  - Microsoft SQL Server
  - MySQL/MariaDB (compatible with MySqlConnector)
- Valid SQL queries for your schema in `queries.json`

## Quick Start
1. Restore:
   - `dotnet restore YSM-GMTool.slnx`
2. Run:
   - `dotnet run --project src/App.WinForms/App.WinForms.csproj`
3. Open `Settings` (top-right icon), configure DB connection, test, save.
4. In any tab, click `Load All`, search/select data, generate command.

## Configuration

### 1) SQL Queries
File: `src/App.WinForms/Config/queries.json`

Structure:
- root by provider: `MSSQL`, `MySQL`
- per entity: `Playerchecker`, `Monsters`, `Items`, `Skills`, `States`, `NPC`, `Summons`

Queries support tokens replaced from Settings -> Table Names, e.g.:
- `{{CharacterResource}}`
- `{{MonsterResource}}`
- `{{StringResource}}`
- `{{StringResourceFull}}`
- `{{ItemResource}}`
- `{{SkillResource}}`
- `{{StateResource}}`
- `{{NpcResource}}`
- `{{SummonResource}}`

### 2) Lua Templates
File: `src/App.WinForms/Config/lua_commands.json`

Each action uses a template key and placeholder replacement.  
You can change command syntax without recompiling.

### 3) Environment Variables (`.env`)
Supported keys:
- `YSM_DB_PROVIDER` (`MSSQL` or `MySQL`)
- `YSM_DB_CONNECTION_STRING`

`.env` is loaded automatically at startup (current dir, app dir, LocalAppData dir, and parent search).

Notes:
- `.env` is gitignored.
- On `Release` auto-publish, root `.env` is copied to the publish folder (if present).

## Settings Window
The Settings dialog includes:
- Connection tab:
  - provider, server, port, database, user, password
  - integrated security / encryption options
  - connection preview
  - connection test button
- Table Names tab:
  - DB-name placeholders for future multi-db usage:
    - `Arcadia Name`
    - `Telecaster Name`
    - `Auth Name`
  - resource table names used by current queries

Current runtime data loading is focused on Arcadia/resource queries; the additional DB name fields are already persisted for future expansion.

## Search Behavior
- Debounced search input (`~120ms`)
- Filtering runs on indexed in-memory data after `Load All`
- Modes:
  - `Search by ID`
  - `Search by Name`
  - NPC tab also has separate `Search by Contact script`
- Summons name search checks both:
  - `Summon Name`
  - `Card Name`

## Command Generation Behavior
- Every action builds a command from template + selected values
- Output is copied to clipboard immediately
- `/run` mode:
  - checked: prefix `/run ` to non-comment commands
  - unchecked: keep raw command
  - commands starting with `//` remain unchanged

## Application Data
- User settings:
  - `%LocalAppData%\YSM-GMTool\settings.json`
- Logs:
  - `%LocalAppData%\YSM-GMTool\logs\gmtool-YYYYMMDD.log`

## Build and Publish

### Debug build
- `dotnet build src/App.WinForms/App.WinForms.csproj`

### Release build (auto publish enabled)
- `dotnet build src/App.WinForms/App.WinForms.csproj -c Release`

Release build automatically publishes to:
- `%USERPROFILE%\Desktop\GM Tool\`

Publish profile is framework-dependent (runtime from system) and single-file oriented to keep output compact.

If publish fails with file lock errors:
- close `GM Tool.exe` running from publish directory
- run Release build again

## Project Structure
- `src/App.Core`
  - models, interfaces, settings, query/lua stores, normalization
- `src/App.Data`
  - DB connection factory + Dapper repository
- `src/App.WinForms`
  - forms, controls, presenters, app bootstrap, config files

## Dark Mode Note (A/B)
- Variant A (current .NET 10): `Application.SetColorMode(SystemColorMode.Dark)`
- Variant B (older previews): no stable public API

Current implementation uses Variant A.

## Troubleshooting
- SQL Server certificate error during connect/test:
  - add `TrustServerCertificate=True` for self-signed/local instances
- Empty grids after `Load All`:
  - verify provider + connection
  - verify `queries.json` for your schema/table names
  - verify tokens in Settings -> Table Names
