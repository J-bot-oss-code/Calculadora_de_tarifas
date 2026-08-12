namespace ShipRateCalculator.Web.Models;

/// <summary>
/// Resultado a mostrar en la vista: costo calculado o mensaje de error.
/// </summary>
public class ShippingResultViewModel
{
    public bool Success { get; set; }
    public decimal? Cost { get; set; }
    public decimal? RatePerKg { get; set; }
    public string? CountryName { get; set; }
    public string? ErrorMessage { get; set; }
}
