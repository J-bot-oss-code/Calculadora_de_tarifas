# ShipRateCalculator.Data — Capa de datos

Class Library (.NET 8) con Entity Framework Core sobre SQL Server.

Responsabilidad: exponer el acceso a la tabla de países/tarifas mediante
un `DbContext` y un repositorio (`ICountryRateRepository`). Es la única
capa que conoce EF Core y la cadena de conexión.

## Enfoque: Database First, sin migraciones

Por decisión del equipo, **no se usan EF Core Migrations**. A medida que la
aplicación crece, el historial de migraciones se vuelve pesado y difícil de
mantener (archivos que se acumulan indefinidamente, conflictos de merge en
la carpeta `Migrations/`, etc.).

En su lugar, el esquema de la base de datos se administra directamente con
**scripts SQL versionados** en `Scripts/`, y EF Core solo se usa para mapear
y consultar esa base ya existente (enfoque *Database First*).

### Flujo de trabajo

1. El esquema y los datos iniciales viven en `Scripts/001_create_database.sql`.
   Cualquier cambio de estructura se agrega como un script nuevo numerado
   (`002_...sql`, `003_...sql`), nunca editando uno ya ejecutado en otros
   ambientes.
2. Se ejecuta ese script manualmente contra SQL Server (SSMS, Azure Data
   Studio o `sqlcmd`) para crear/actualizar la base.
3. Las clases de EF Core (`AppDbContext` y las entidades) se generan o
   actualizan a partir de la base ya creada con:
   ```bash
   dotnet ef dbcontext scaffold "Server=.;Database=ShipRateCalculatorDb;Trusted_Connection=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -o Models --context AppDbContext --no-onconfiguring
   ```
   (o el mismo comando desde la Consola del Administrador de Paquetes en
   Visual Studio: `Scaffold-DbContext ...`)

Con esto, EF Core nunca intenta crear ni modificar el esquema por sí solo:
solo lee la estructura que ya existe en la base de datos.

Paquetes NuGet necesarios:
- `Microsoft.EntityFrameworkCore.SqlServer`
- `Microsoft.EntityFrameworkCore.Design` (solo para el scaffolding, no
  queda como dependencia en producción si así se prefiere)

## Estructura

```
ShipRateCalculator.Data/
├── Scripts/
│   └── 001_create_database.sql   # esquema + datos iniciales
├── AppDbContext.cs                # contexto de EF Core (generado/ajustado)
├── Models/
│   └── CountryRate.cs             # entidad mapeada a dbo.CountryRates
└── Repositories/
    ├── ICountryRateRepository.cs
    └── CountryRateRepository.cs   # consultas contra la tabla CountryRates
```
