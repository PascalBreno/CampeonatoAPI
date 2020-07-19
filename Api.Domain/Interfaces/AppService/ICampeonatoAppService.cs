using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.AppService.Base;
using Domain.Interfaces.Services.Base;

namespace Domain.Interfaces.AppService
{
        public interface ICampeonatoAppServices : IBaseAppService<CampeonatoEntity>
        {
            Task<CampeonatoEntity> GetByCod(string codigoCampeonato);
        }
}