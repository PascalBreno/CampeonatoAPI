using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.AppService.Base;

namespace Domain.Interfaces.AppService
{
    public interface ITimeAppService: IBaseAppService<TimeEntity>
    {
        public Task<TimeEntity> SelectCodigoAsync(string sigla);
    }
}