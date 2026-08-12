using ShipRateCalculator.Domain;

namespace ShipRateCalculator.Data.Repositories;

public interface ICountryRateRepository
{
    Task<CountryRate?> GetByCodeAsync(string code);

    Task<IEnumerable<CountryRate>> GetAllAsync();
}
