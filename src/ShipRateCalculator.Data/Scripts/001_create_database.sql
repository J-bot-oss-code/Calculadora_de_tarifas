/*
  ShipRateCalculator — script de creación de base de datos
  ---------------------------------------------------------
  Ejecutar manualmente en SQL Server Management Studio (o sqlcmd)
  antes de correr la aplicación. El esquema se administra aquí,
  no mediante EF Core Migrations.
  ---------------------------------------------------------
*/

IF DB_ID('ShipRateCalculatorDb') IS NULL
BEGIN
    CREATE DATABASE ShipRateCalculatorDb;
END
GO

USE ShipRateCalculatorDb;
GO

IF OBJECT_ID('dbo.CountryRates', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.CountryRates (
        Id           INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        Code         NVARCHAR(5)       NOT NULL,
        Name         NVARCHAR(100)     NOT NULL,
        RatePerKg    DECIMAL(10,2)     NOT NULL,
        CONSTRAINT UQ_CountryRates_Code UNIQUE (Code)
    );
END
GO

-- Datos iniciales (reglas de negocio vigentes)
IF NOT EXISTS (SELECT 1 FROM dbo.CountryRates)
BEGIN
    INSERT INTO dbo.CountryRates (Code, Name, RatePerKg) VALUES
        ('IN', N'India', 5.00),
        ('US', N'Estados Unidos', 8.00),
        ('UK', N'Reino Unido', 10.00);
END
GO
