using ShipRateCalculator.Domain;
using System.Collections.Generic;

namespace ShipRateCalculator.Web.Models;

public class ShippingRequestViewModel
{
    
    public decimal Weight { get; set; }
    public string CountryCode { get; set; } = string.Empty;
    public IEnumerable<CountryRate> Countries { get; set; } = new List<CountryRate>();

   
    public bool HasResult { get; set; }
    public bool Success { get; set; }
    public decimal? Cost { get; set; }
    public decimal? RatePerKg { get; set; }
    public string? CountryName { get; set; }
    public string? ErrorMessage { get; set; }
}