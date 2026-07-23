## Issue: EF Core + SQL Server on Linux (Docker) — Connection Fails Silently

### Problem 1: Using Windows Authentication on Linux

If your `OnConfiguring` method uses `Trusted_Connection=true`, it will fail on Linux/Docker setups:

```csharp
optionsBuilder.UseSqlServer("Server=localhost; Database=Assignment; Trusted_Connection=true; Encrypt=false;");
```

`Trusted_Connection=true` means "use Windows Integrated Authentication." This only works on a Windows domain/account — a Linux Docker container has no concept of Windows auth, so the connection fails.

**Fix:** Use SQL Login (username/password) instead, matching whatever `SA` credentials you set when you spun up the SQL Server Docker container:

```csharp
optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Assignment;User Id=sa;Password=YOUR_SA_PASSWORD;TrustServerCertificate=true;");
```

`TrustServerCertificate=true` is also needed because Docker SQL Server images typically ship a self-signed cert that .NET will otherwise reject.

---

### Problem 2: Table Created, but No Data Inserted (Silent Failure)

If you assign foreign keys manually using raw int IDs instead of navigation properties:

```csharp
Doctor D1 = new Doctor { FirstName = "shehap", LastName = "sherif", HospitalId = 1 };
```

EF Core has no object-level relationship to work with here — it's just guessing that `HospitalId = 1` will exist by the time this row is inserted. If EF inserts Doctors before Hospitals, SQL Server rejects it (FK constraint violation), `SaveChanges()` throws, and the whole transaction rolls back. Since console apps close instantly on unhandled exceptions, you never see the error — you just see an empty table.

**Fix:** Use navigation properties instead of raw FK ints, so EF Core builds the dependency graph itself and inserts everything in the correct order:

```csharp
Doctor D1 = new Doctor { FirstName = "shehap", LastName = "sherif", Hospital = H1 };
```

**Bonus fix — always wrap `SaveChanges()` so failures aren't silent:**

```csharp
try
{
    Db.SaveChanges();
    Console.WriteLine("Saved successfully!");
}
catch (Exception ex)
{
    Console.WriteLine("ERROR: " + ex.Message);
    if (ex.InnerException != null)
        Console.WriteLine("INNER: " + ex.InnerException.Message);
}
Console.ReadLine();
```