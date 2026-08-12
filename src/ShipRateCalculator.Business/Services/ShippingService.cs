using Microsoft.Extensions.Logging;
using ShipRateCalculator.Business.Interfaces;
using ShipRateCalculator.Business.Models;
using ShipRateCalculator.Data.Repositories;
using ShipRateCalculator.Domain;

namespace ShipRateCalculator.Business.Services;

public class ShippingService : IShippingService
{
    private readonly ICountryRateRepository _repository;
    private readonly ILogger<ShippingService> _logger;

    
    public ShippingService(ICountryRateRepository repository, ILogger<ShippingService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<ShippingCalculationResult> CalculateAsync(decimal weight, string countryCode)
    {
        try
        {
            
            if (weight <= 0)
            {
                return new ShippingCalculationResult
                {
                    Success = false,
                    ErrorMessage = "El peso del paquete debe ser mayor a cero."
                };
            }

            
            if (string.IsNullOrWhiteSpace(countryCode))
            {
                return new ShippingCalculationResult
                {
                    Success = false,
                    ErrorMessage = "Debe seleccionar o especificar un país de destino."
                };
            }

            
            var countryRate = await _repository.GetByCodeAsync(countryCode);

            if (countryRate == null)
            {
                return new ShippingCalculationResult
                {
                    Success = false,
                    ErrorMessage = $"No se encontró una tarifa configurada para el país con código: {countryCode}"
                };
            }

            
            decimal calculatedCost = weight * countryRate.RatePerKg;

           
            return new ShippingCalculationResult
            {
                Success = true,
                Cost = calculatedCost,
                RatePerKg = countryRate.RatePerKg
            };
        }
        catch (Exception ex)
        {
           
            _logger.LogError(ex, "Error crítico al calcular la tarifa de envío para el país: {CountryCode} con peso: {Weight}", countryCode, weight);

            
            return new ShippingCalculationResult
            {
                Success = false,
                ErrorMessage = "Ocurrió un error inesperado al procesar el cálculo de la tarifa. Intente más tarde."
            };
        }
    }

    public async Task<IEnumerable<CountryRate>> GetAvailableCountriesAsync()
    {
        try
        {
            return await _repository.GetAllAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error crítico al obtener la lista de países disponibles.");
            throw; 
        }
    }
}