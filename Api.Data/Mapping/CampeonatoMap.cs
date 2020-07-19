using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class CampeonatoMap :IEntityTypeConfiguration<CampeonatoEntity>
    {
        public void Configure(EntityTypeBuilder<CampeonatoEntity> builder)
        {
            builder.ToTable("Campeonato");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.nome).HasMaxLength(1000);
            builder.Property(x => x.dataInicio).IsRequired();
            builder.Property(x => x.dataFinal);
            builder.HasIndex(x => x.codigoCampeonato).IsUnique();
            builder.HasOne(x => x.campeao);
            builder.HasOne(x => x.vici);
            builder.HasOne(x => x.terceiro);
            builder.HasMany(x => x.partidas);
            
        }
    }
}