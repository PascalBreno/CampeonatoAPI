using Data.Mapping;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class MyContext : DbContext
    {


        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TimeEntity>(new TimeMap().Configure);
            modelBuilder.Entity<PartidaEntity>(new PartidaMap().Configure);
            modelBuilder.Entity<CampeonatoEntity>(new CampeonatoMap().Configure);
            modelBuilder.Entity<PontuacaoCampeonatoEntity>(new PontuacaoCampeonatoMap().Configure);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<CampeonatoEntity> Campeonato { get; set; }
        public DbSet<PontuacaoCampeonatoEntity> PontuacaoCampeonatoEntities { get; set; }
        public DbSet<TimeEntity> TimeEntities { get; set; }
    }
}