﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PIISTECHLTD.Data.Persistence;

namespace PIISTECHLTD.Data;

public static class RegisterService
{
    public static IServiceCollection InfrastructureConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(x =>
            x.UseSqlServer(configuration.GetConnectionString("DbConn")));

        return services;
    }
}
