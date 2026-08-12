namespace ShipRateCalculator.Business.Models;

/// <summary>
/// Resultado del cálculo de una tarifa de envío.
/// </summary>
public class ShippingCalculationResult
{
    public bool Success { get; set; }
    public decimal? Cost { get; set; }
    public decimal? RatePerKg { get; set; }
    public string? ErrorMessage { get; set; }
}
