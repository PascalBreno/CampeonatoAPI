using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Data.Repository.Base;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Parameters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Repository
{
    public class TimeRepository : BaseRepository<TimeEntity> , ITimeRepository
    {
        public TimeRepository(MyContext context) : base(context)
        {

      
        }
        public new async Task<IEnumerable<TimeEntity>> SelectAsync(ParametersPage parametersPage)
        {
            var result =  await base.SelectAsync(parametersPage);

            return result.OrderBy(x => x.nome);

        } 
        public async Task<TimeEntity> SelectCodigoAsync(string sigla)
        {
            return  await _context.TimeEntities.Where(x => !x.isDeleted && x.sigla == sigla).FirstOrDefaultAsync();

        }
    }
}