# GM Tool

A Windows desktop GM utility for Rappelz private servers — browse game data, inspect player inventories/warehouses, and generate Lua commands directly to clipboard.

Built with WinForms on .NET 10, with a native dark theme and fully async database access (MSSQL + MySQL).

---

## Features

### Tabs
| Tab | Description |
|-----|-------------|
| **Playerchecker** | Search characters by account name or character name. View ONLINE/OFFLINE status, load inventory, load warehouse, or open quick info. |
| **Monster** | Browse all monsters by name, ID, or location. Generate spawn commands. |
| **Items** | Browse all items. Give to yourself or other players, edit level/enhance/appearance/itemcode. |
| **Skills** | Browse skills. Learn, set level, remove — for yourself or another player. |
| **Buffs** | Browse all buff/state records. Apply/remove buffs, world states, and event states. |
| **NPCs** | Browse NPCs with contact script search. Generate add/show/warp commands. |
| **Summons** | Browse summons and their card items. Insert or stage summons. |

### Playerchecker details
- **SQL-level search** (no Load All needed) — queries run directly against the DB as you type.
- **Two search modes**: `by Account` (searches `account` column) or `by Char Name` (searches `name` column with `LIKE`).
- **ONLINE / OFFLINE** status column derived from login/logout timestamps.
- **Load Inventory** — shows the selected character's inventory in the lower panel.
- **Load Warehouse** — shows all warehouse items for the character's account.
- **Open Infos** — quick summary popup (name, account, level, job, status).
- 350 ms debounce on search input for responsive SQL queries without flooding the DB.

### Other tabs
- Fast in-memory filtering after `Load All`.
- Debounced search input (~120 ms).
- Search modes: by ID, by Name, and (NPCs) by Contact Script.

### Command generation
- Every action builds a Lua command from a configurable template and copies it to clipboard.
- Optional `/run` prefix: when **Append /run to commands** is checked, the `/run ` prefix is added to all non-comment commands.
- Commands starting with `//` are never prefixed.

### Sidebar
- Manage a list of target players (add/remove from the right sidebar).
- Selected player is used as a target for multi-player commands.
- Settings persist between sessions.

---

## Requirements

- **Windows 10 / 11** (x64)
- **.NET 10 Desktop Runtime** ([download](https://dotnet.microsoft.com/en-us/download/dotnet/10.0))
- Access to one of:
  - Microsoft SQL Server / Azure SQL
  - MySQL or MariaDB (compatible with MySqlConnector)
- Read access to the game database (Arcadia resources + Telecaster character/item data + Auth accounts)

---

## Installation

### Option A — Run from source

```bash
git clone https://github.com/your-org/YSM-GMTool.git
cd YSM-GMTool
dotnet restore YSM-GMTool.slnx
dotnet run --project src/App.WinForms/App.WinForms.csproj
```

### Option B — Release build (auto-publish to Desktop)

```bash
dotnet build src/App.WinForms/App.WinForms.csproj -c Release
```

The Release build automatically publishes a self-contained executable to:
```
%USERPROFILE%\Desktop\GM Tool\
```

> If the build fails with a file-lock error, close **GM Tool.exe** from that folder and retry.

---

## First-time Setup

1. Launch the application.
2. Click the **Settings** icon (top-right of the sidebar).
3. In the **Connection** tab:
   - Select provider: `MSSQL` or `MySQL`
   - Enter server, port, database, username, password
   - Click **Test Connection** to verify
   - Click **OK** to save
4. In the **Table Names** tab, fill in the token values that match your server's schema:
   - `Arcadia Name` — resource DB name (e.g. `ArcadiaDB`)
   - `Telecaster Name` — character/item DB name (e.g. `TelecasterDB`)
   - `Auth Name` — account DB name (e.g. `AuthDB`)
   - `StringResource` — string table name (e.g. `StringResource`)
   - `ItemResource`, `SkillResource`, `StateResource`, `NpcResource`, `SummonResource`, `MonsterResource`
5. Go to any tab and start using the tool.

---

## Configuration

### SQL Queries — `src/App.WinForms/Config/queries.json`

Queries are grouped by provider (`MSSQL`, `MySQL`) and entity key. Tokens in `{{DougleBraces}}` are replaced at runtime from Settings → Table Names.

| Token | Maps to |
|-------|---------|
| `{{ArcadiaName}}` | Resource database name |
| `{{TelecasterName}}` | Character/item database name |
| `{{AuthName}}` | Account database name |
| `{{StringResource}}` | String lookup table |
| `{{ItemResource}}` | Item resource table |
| `{{SkillResource}}` | Skill resource table |
| `{{StateResource}}` | State/buff resource table |
| `{{NpcResource}}` | NPC resource table |
| `{{SummonResource}}` | Summon resource table |
| `{{MonsterResource}}` | Monster resource table |

Parameterized queries use Dapper named parameters (`@SearchTerm`, `@OwnerId`, `@AccountName`).

### Lua Templates — `src/App.WinForms/Config/lua_commands.json`

Command templates use `{{placeholder}}` substitution. Edit freely to match your server's Lua API without recompiling.

### Environment Variables (`.env`)

Place a `.env` file in the project root, app folder, or `%LocalAppData%\YSM-GMTool\`:

```env
YSM_DB_PROVIDER=MSSQL
YSM_DB_CONNECTION_STRING=Server=localhost;Database=ArcadiaDB;User Id=sa;Password=...;TrustServerCertificate=True
```

`.env` is gitignored. On Release auto-publish, the root `.env` (if present) is copied to the publish folder.

---

## Application Data

| Data | Path |
|------|------|
| User settings | `%LocalAppData%\YSM-GMTool\settings.json` |
| Log files | `%LocalAppData%\YSM-GMTool\logs\gmtool-YYYYMMDD.log` |

---

## Project Structure

```
src/
  App.Core/         # Models, interfaces, enums, query/lua stores, normalizer
  App.Data/         # Dapper repository, DB connection factory
  App.WinForms/     # WinForms UI: forms, controls, presenters, config
    Config/
      queries.json        # SQL queries per provider and entity
      lua_commands.json   # Lua command templates
```

---

## Tech Stack

| Component | Library |
|-----------|---------|
| UI framework | WinForms (.NET 10) |
| ORM | Dapper |
| SQL Server | Microsoft.Data.SqlClient |
| MySQL | MySqlConnector |
| Logging | Serilog (file sink) |
| Icons | FontAwesome.Sharp |

---

## Troubleshooting

| Problem | Solution |
|---------|----------|
| SQL Server certificate error | Add `TrustServerCertificate=True` to the connection string or use the Settings checkbox |
| Empty grid after searching | Verify provider, connection string, and token values in Settings → Table Names |
| PlayerChecker shows no results | Make sure `Telecaster Name` and `Arcadia Name` are set correctly; the queries are cross-database |
| Warehouse items not loading | Verify `Auth Name` token is set and the account table is accessible |
| Release publish fails (file lock) | Close `GM Tool.exe` from `%USERPROFILE%\Desktop\GM Tool\` and rebuild |
