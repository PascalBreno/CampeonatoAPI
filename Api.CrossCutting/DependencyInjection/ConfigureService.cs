﻿using Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using Service.Services;

namespace CrossCutting.DependencyInjection
{
    public static class ConfigureService
    {
        public static void ConfigureDependencieService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ITimeService, TimeService>();
            serviceCollection.AddScoped<IPartidaService, PartidaService>();
            serviceCollection.AddScoped<ICampeonatoService, CampeonatoService>();
        }
    }
}