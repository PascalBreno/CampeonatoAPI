using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Data.Context;
using Data.Repository.Base;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Repository
{
    public class CampeonatoRepository : BaseRepository<CampeonatoEntity>, ICampeonatoRepository
    {
        public CampeonatoRepository(MyContext context) : base(context)
        {
        }
        public new async Task<CampeonatoEntity> InsertAsync(CampeonatoEntity campeonato)
        {
            do
            {
                campeonato.codigoCampeonato = geraCodigo();
            }while(await ExistAsync(campeonato.codigoCampeonato));
            return await base.InsertAsync(campeonato);
        }

        private static string geraCodigo()
        {
            var rand = new Random();
            var result = "";
            const string random = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
            for (var i = 0; i < 5; i++)
            {
                result += random[rand.Next(0, random.Length)];
            }
            return result;
        }
        
        public async Task<CampeonatoEntity> SelectCodigoAsync(string codigoCampeonato)
        {
            try
            {
                return await _context.Campeonato.Include(x => x.campeao).Include(x => x.vici).Include(x => x.terceiro)
                    .Include(x => x.partidas).ThenInclude(partida=>partida.timeA)
                    .Include(x => x.partidas).ThenInclude(partida=>partida.timeB)
                    .FirstOrDefaultAsync(x=>x.codigoCampeonato==codigoCampeonato && !x.isDeleted);
            }
            catch (Exception)
            {
                await _context.DisposeAsync();
                throw;
            }
        }

        public async Task<bool> ExistAsync(string codigoCampeonato)
        {
            return await _context.Campeonato.AnyAsync(x => x.codigoCampeonato==codigoCampeonato && !x.isDeleted);
        }
    }
    
}