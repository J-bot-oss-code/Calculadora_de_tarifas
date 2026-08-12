using ShipRateCalculator.Domain;

namespace ShipRateCalculator.Data.Repositories;

public class CountryRateRepository : ICountryRateRepository
{
    public Task<CountryRate?> GetByCodeAsync(string code)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CountryRate>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}
