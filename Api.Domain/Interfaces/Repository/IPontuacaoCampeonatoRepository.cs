using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Repository.Base;

namespace Microsoft.EntityFrameworkCore.Design
{
    public interface IPontuacaoCampeonatoRepository: IRepository<PontuacaoCampeonatoEntity>
    {
       Task<IList<PontuacaoCampeonatoEntity>> SelectAsync(string codigoCampeonato);

    }
}