namespace ShipRateCalculator.Business.Models;


public class ShippingCalculationResult
{
    public bool Success { get; set; }
    public decimal? Cost { get; set; }
    public decimal? RatePerKg { get; set; }
    public string? ErrorMessage { get; set; }
}
