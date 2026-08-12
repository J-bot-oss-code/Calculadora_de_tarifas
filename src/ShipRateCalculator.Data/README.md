# ShipRateCalculator.Data — Capa de datos

Class Library (.NET 8) con Entity Framework Core sobre SQL Server.

Responsabilidad: exponer el acceso a la tabla de países/tarifas mediante
un `DbContext` y un repositorio (`ICountryRateRepository`). Es la única
capa que conoce EF Core y la cadena de conexión.

Se crea desde Visual Studio como proyecto **Class Library**, apuntando a
**.NET 8**, con los paquetes NuGet:
- `Microsoft.EntityFrameworkCore.SqlServer`
- `Microsoft.EntityFrameworkCore.Tools`

Contiene:
- `AppDbContext.cs` — contexto de EF Core.
- `Migrations/` — migraciones generadas con `Add-Migration` / `dotnet ef migrations add`.
- `Repositories/CountryRateRepository.cs` — consultas contra la tabla `CountryRates`.
