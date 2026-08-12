using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShipRateCalculator.Business.Interfaces;
using ShipRateCalculator.Domain;
using ShipRateCalculator.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipRateCalculator.Web.Controllers;

public class ShippingController : Controller
{
    private readonly IShippingService _shippingService;
    private readonly ILogger<ShippingController> _logger;

    public ShippingController(IShippingService shippingService, ILogger<ShippingController> logger)
    {
        _shippingService = shippingService;
        _logger = logger;
    }

    // GET /Shipping
    public async Task<IActionResult> Index()
    {
        try
        {
            var availableCountries = await _shippingService.GetAvailableCountriesAsync();
            var model = new ShippingRequestViewModel
            {
                Countries = availableCountries,
                HasResult = false
            };
            return View(model);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al cargar la vista principal de la calculadora.");
            ViewBag.ErrorMessage = "Ocurrió un error al cargar los países. Por favor, intente más tarde.";
            return View(new ShippingRequestViewModel { Countries = new List<CountryRate>() });
        }
    }

    // POST /Shipping/Calculate
    [HttpPost]
    public async Task<IActionResult> Calculate(ShippingRequestViewModel request)
    {
        try
        {
            
            request.Countries = await _shippingService.GetAvailableCountriesAsync();
            request.HasResult = true;

            if (!ModelState.IsValid)
            {
                return View("Index", request);
            }

            
            var calculationResult = await _shippingService.CalculateAsync(request.Weight, request.CountryCode);

            
            request.Success = calculationResult.Success;
            request.Cost = calculationResult.Cost;
            request.RatePerKg = calculationResult.RatePerKg;
            request.ErrorMessage = calculationResult.ErrorMessage;

            if (calculationResult.Success)
            {
                request.CountryName = request.Countries.FirstOrDefault(c => c.CountryCode == request.CountryCode)?.Name;
            }

            return View("Index", request);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error crítico calculando la tarifa.");
            request.Countries = await _shippingService.GetAvailableCountriesAsync();
            request.HasResult = true;
            request.Success = false;
            request.ErrorMessage = "Ocurrió un error inesperado al procesar su solicitud.";

            return View("Index", request);
        }
    }
}