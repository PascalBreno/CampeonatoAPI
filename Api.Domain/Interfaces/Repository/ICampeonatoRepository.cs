using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Repository.Base;

namespace Domain.Interfaces.Repository
{
    public interface ICampeonatoRepository : IRepository<CampeonatoEntity>
    {
        Task<CampeonatoEntity> SelectCodigoAsync(string codigoCampeonato);
        public Task<bool> ExistAsync(string codigoCampeonato);
    }
}