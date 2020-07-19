using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Data.Repository.Base;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Repository
{
           
        public class PontuacaoCampeonatoRepository : BaseRepository<PontuacaoCampeonatoEntity> , IPontuacaoCampeonatoRepository
        {
            private readonly DbSet<PontuacaoCampeonatoEntity> _datasetOverride;
            public PontuacaoCampeonatoRepository(MyContext context) : base(context)
            {
                _datasetOverride = context.Set<PontuacaoCampeonatoEntity>();
            }

            public async Task<IList<PontuacaoCampeonatoEntity>> SelectAsync(string codigoCampeonato)
            {
                try
                {
                    return await _datasetOverride.Where(x => x.codigoCampeonato == codigoCampeonato && !x.isDeleted).ToListAsync();

                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
}