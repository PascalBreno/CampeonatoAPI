using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class TimeMap : IEntityTypeConfiguration<TimeEntity>
    {
        public void Configure(EntityTypeBuilder<TimeEntity> builder)
        {
            builder.ToTable("Time");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.nome).HasMaxLength(100).IsRequired();
            builder.HasIndex(x => x.sigla).IsUnique();
            builder.HasData(new TimeEntity
            {
                nome = "Palmeiras",
                sigla = "PLM",
                Id = Guid.NewGuid(),
                CreateAt = DateTime.Now
            });
            builder.HasData(new TimeEntity
            {
                nome = "São Paulo",
                sigla = "SP",
                Id = Guid.NewGuid(),
                CreateAt = DateTime.Now
            });
            builder.HasData(new TimeEntity
            {
                nome = "Flamento",
                sigla = "FLM",
                Id = Guid.NewGuid(),
                CreateAt = DateTime.Now
            }); 
            builder.HasData(new TimeEntity
            {
                nome = "Bota Fogo",
                sigla = "BTF",
                Id = Guid.NewGuid(),
                CreateAt = DateTime.Now
            });
            builder.HasData(new TimeEntity
            {
                nome = "Grêmio",
                sigla = "GRM",
                Id = Guid.NewGuid(),
                CreateAt = DateTime.Now
            });
        }
    }
}