using ShipRateCalculator.Domain;

namespace ShipRateCalculator.Web.Models;

/// <summary>
/// Datos capturados en el formulario: peso y país de destino,
/// más la lista de países para poblar el <select>.
/// </summary>
public class ShippingRequestViewModel
{
    public decimal Weight { get; set; }
    public string CountryCode { get; set; }
    public IEnumerable<CountryRate> Countries { get; set; }
}
