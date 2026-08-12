using Microsoft.AspNetCore.Mvc;
using ShipRateCalculator.Business.Interfaces;

namespace ShipRateCalculator.Web.Controllers;

public class ShippingController : Controller
{
    private readonly IShippingService _shippingService;

    public ShippingController(IShippingService shippingService)
    {
        _shippingService = shippingService;
    }

    // GET /Shipping
    public IActionResult Index()
    {
        throw new NotImplementedException();
    }

    // POST /Shipping/Calculate
    [HttpPost]
    public IActionResult Calculate(decimal weight, string countryCode)
    {
        throw new NotImplementedException();
    }
}
