using ShipRateCalculator.Business.Interfaces;
using ShipRateCalculator.Business.Models;
using ShipRateCalculator.Data.Repositories;
using ShipRateCalculator.Domain;

namespace ShipRateCalculator.Business.Services;

public class ShippingService : IShippingService
{
    private readonly ICountryRateRepository _repository;

    public ShippingService(ICountryRateRepository repository)
    {
        _repository = repository;
    }

    public Task<ShippingCalculationResult> CalculateAsync(decimal weight, string countryCode)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CountryRate>> GetAvailableCountriesAsync()
    {
        throw new NotImplementedException();
    }
}
