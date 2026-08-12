using ShipRateCalculator.Business.Models;
using ShipRateCalculator.Domain;

namespace ShipRateCalculator.Business.Interfaces;

public interface IShippingService
{
    Task<ShippingCalculationResult> CalculateAsync(decimal weight, string countryCode);

    Task<IEnumerable<CountryRate>> GetAvailableCountriesAsync();
}
