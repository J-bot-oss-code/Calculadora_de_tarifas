namespace ShipRateCalculator.Domain;

/// <summary>
/// Representa la tarifa de envío por kilogramo para un país.
/// Mapea a la tabla dbo.CountryRates.
/// </summary>
public class CountryRate
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public decimal RatePerKg { get; set; }
}
