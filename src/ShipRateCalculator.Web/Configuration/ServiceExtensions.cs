using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShipRateCalculator.Business; // Para ver AddBusinessServices
using ShipRateCalculator.Data;     // Para ver AddDataServices

namespace ShipRateCalculator.Web.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        
        services.AddDataServices(configuration);

        
        services.AddBusinessServices();

       
        services.AddControllersWithViews();

        return services;
    }
}