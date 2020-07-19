using Application.AppServices;
using Domain.Interfaces.AppService;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyInjectionStartup
{
    public static class ConfigureAppService
    {
        public static void ConfigureDependencieAppService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICampeonatoAppServices, CampeonatoAppService>();
            serviceCollection.AddScoped<ITimeAppService, TimeAppService>();
        }
    }
}