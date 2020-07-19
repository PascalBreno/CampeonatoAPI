
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Repository.Base;

namespace Domain.Interfaces.Repository
{
    public interface ITimeRepository : IRepository<TimeEntity>
    {
        Task<TimeEntity> SelectCodigoAsync(string codigoCampeonato);

    }
}