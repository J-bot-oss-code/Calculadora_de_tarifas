using ShipRateCalculator.Domain;
using Microsoft.EntityFrameworkCore;
using ShipRateCalculator.Business.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShipRateCalculator.Data.Repositories
{

    public class CountryRateRepository : ICountryRateRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<CountryRateRepository> _logger;
        public CountryRateRepository(AppDbContext context, ILogger<CountryRateRepository> logger)
        {
            _context = context;
            _logger = logger;
        }


        public async Task<CountryRate?> GetByCodeAsync(string code)
        {
            try { 
            
                return await _context.CountryRates.FirstOrDefaultAsync(c => c.CountryCode == code);

            } catch(Exception ex) {

                _logger.LogError(ex, $"Error al intentar buscar la tarifa para el código de país '{code}'.");
                throw;
            }
        }

        public async Task<IEnumerable<CountryRate>> GetAllAsync()
        {
            try { 
            
                return await _context.CountryRates.ToListAsync();

            } catch (Exception ex){

                _logger.LogError(ex, "Error al intentar obtener la lista completa de tarifas de envío.");
                throw;
            }
        }

    }
}

