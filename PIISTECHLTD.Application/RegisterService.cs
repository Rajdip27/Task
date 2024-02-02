using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PIISTECHLTD.Application.Repository.Base;

namespace PIISTECHLTD.Application;

public static class RegisterService
{
    public static IServiceCollection ApplicationConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(x => {
            x.AddMaps(typeof(IApplication).Assembly);

        });
       // services.AddValidatorsFromAssembly(typeof(IApplication).Assembly);
        services.AddScoped(typeof(IBaseRepository<,,>), typeof(BaseRepository<,,>));
        //services.AddTransient<ICityRepository, CityRepository>();
        //services.AddTransient<IEmployeeRepository, EmployeeRepository>();


        services.Scan(scan => scan.FromAssemblyOf<IApplication>()
            .AddClasses(classes => classes.AssignableTo<IApplication>())
            .AddClasses(x => x.AssignableTo(typeof(IBaseRepository<,,>)))
            .AsSelfWithInterfaces()
            .WithScopedLifetime());

        return services;
    }
}
