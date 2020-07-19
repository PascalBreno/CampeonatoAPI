using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class PartidaMap : IEntityTypeConfiguration<PartidaEntity>
    {
        public void Configure(EntityTypeBuilder<PartidaEntity> builder)
        {
            builder.ToTable("Partida");
            builder.HasKey(x => x.Id);
            builder.HasOne<TimeEntity>(x => x.timeA);
            builder.HasOne<TimeEntity>(x => x.timeB);
            builder.Property(x => x.golsA).IsRequired();
            builder.Property(x => x.golsB).IsRequired();
            builder.Property(x => x.data).IsRequired();
            builder.Property(x => x.codigoCampeonato);
        }
    }
}