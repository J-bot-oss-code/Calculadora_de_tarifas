using Microsoft.Extensions.DependencyInjection;
using ShipRateCalculator.Business.Interfaces;
using ShipRateCalculator.Business.Services;

namespace ShipRateCalculator.Business
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
           
            services.AddScoped<IShippingService, ShippingService>();

            return services;
        }
    }
}