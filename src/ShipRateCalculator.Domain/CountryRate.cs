namespace ShipRateCalculator.Domain;

public class CountryRate
{
    public int Id { get; set; }
    public string CountryCode { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal RatePerKg { get; set; }
}
