using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class PontuacaoCampeonatoMap: IEntityTypeConfiguration<PontuacaoCampeonatoEntity>
    {
        public void Configure(EntityTypeBuilder<PontuacaoCampeonatoEntity> builder)
        {
            builder.ToTable("PontuacaoCampeonato");
            builder.HasOne(x => x.time);
            builder.Property(x => x.codigoCampeonato);
            builder.Property(x => x.pontuacaoTime);
        }
    }
}