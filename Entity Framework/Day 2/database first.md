Good news: EF Core Power Tools is basically just a GUI wrapper around a CLI command that ships with EF Core itself — `dotnet ef dbcontext scaffold`. You don't need Visual Studio or the extension at all; the CLI does the exact same "database → code" reverse engineering.

Here's the full workflow in VS Code on Fedora:

**1. Install the EF CLI tool (once per machine)**
```bash
dotnet tool install --global dotnet-ef
```
Check it worked:
```bash
dotnet ef --version
```
If `dotnet ef` isn't found after this, add `~/.dotnet/tools` to your PATH:
```bash
export PATH="$PATH:$HOME/.dotnet/tools"
```

**2. Add the required NuGet packages to your project**
From your project folder:
```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools
```
`Design` is the one that actually powers scaffolding — don't skip it.

**3. Run the scaffold command**
```bash
dotnet ef dbcontext scaffold "Server=localhost,1433;Database=YourDbName;User Id=sa;Password=YourPassword;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer --output-dir Models --context-dir Data --context YourDbNameContext
```

Since you're running SQL Server in Docker, use the connection string that points at your container (localhost + whatever port you mapped, e.g. `1433`).

**Useful flags:**
- `--output-dir Models` → where entity classes go
- `--context-dir Data` → where the DbContext class goes
- `--context YourDbNameContext` → name the DbContext explicitly
- `--data-annotations` → use `[Key]`, `[Required]` etc. instead of Fluent API (optional, matter of taste)
- `--force` → overwrite existing generated files if you re-run it
- `--table TableName` → scaffold only specific tables (repeatable) instead of the whole DB
- `--no-onconfiguring` → skip generating the `OnConfiguring` method with the hardcoded connection string (good practice, since you'll usually inject the connection string via config instead)

**4. Result**
You'll get a `Models/` folder full of entity classes (one per table) and a `Data/YourDbNameContext.cs` with `DbSet<T>` properties and the Fluent API mappings — exactly what Power Tools would generate, just without the Visual Studio dialog.

One tip for your Fedora/Docker setup: if you get an SSL/certificate handshake error connecting to the container, that's what `TrustServerCertificate=True` in the connection string fixes — very common with local dev SQL Server in Docker.

If you want a nicer way to browse the DB itself while working, the **SQL Server (mssql)** extension in VS Code is worth having too, though it's optional for this task.