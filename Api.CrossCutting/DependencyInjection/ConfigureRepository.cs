using Data.Context;
using Data.Repository;
using Data.Repository.Base;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Repository.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependencyInjection
{
    public static class ConfigureRepository
    {
         public static void ConfigureDependencieRepository(IServiceCollection serviceCollection)
         {
             serviceCollection.AddDbContext<MyContext>(
                 options=>options.UseMySql("Server=localhost;Port=3306;Database=dbAPI;Uid=root;Pwd=1KGCVA62LXq")
             );
             
             serviceCollection.AddScoped(typeof(IRepository<>),typeof(BaseRepository<>));
             serviceCollection.AddScoped(typeof(ITimeRepository), typeof(TimeRepository));
             serviceCollection.AddScoped(typeof(IPartidaRepository), typeof(PartidaRepository));
             serviceCollection.AddScoped(typeof(ICampeonatoRepository), typeof(CampeonatoRepository));
             serviceCollection.AddScoped(typeof(IPontuacaoCampeonatoRepository), typeof(PontuacaoCampeonatoRepository));

         }
    }
}