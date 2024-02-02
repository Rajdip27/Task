using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PIISTECHLTD.Application;
using PIISTECHLTD.Data;

namespace PIISTECHLTD.IoC.Configuration;

public static class ServiceCollectionsExtension
{
    public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
    {
        services.ApplicationConfiguration(configuration);
        services.InfrastructureConfiguration(configuration);
        return services;
    }
}
