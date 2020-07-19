﻿// <auto-generated />
using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20200715234015_unique")]
    partial class unique
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Entities.CampeonatoEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("campeaoId")
                        .HasColumnType("char(36)");

                    b.Property<string>("codigoCampeonato")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<DateTime?>("dataFinal")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("dataInicio")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("nome")
                        .HasColumnType("varchar(1000) CHARACTER SET utf8mb4")
                        .HasMaxLength(1000);

                    b.Property<Guid?>("quartoId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("terceiroId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("viciId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("campeaoId");

                    b.HasIndex("codigoCampeonato")
                        .IsUnique();

                    b.HasIndex("quartoId");

                    b.HasIndex("terceiroId");

                    b.HasIndex("viciId");

                    b.ToTable("Campeonato");
                });

            modelBuilder.Entity("Domain.Entities.PartidaEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("data")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("golsA")
                        .HasColumnType("int");

                    b.Property<int>("golsB")
                        .HasColumnType("int");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid?>("timeAId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("timeBId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("timeAId");

                    b.HasIndex("timeBId");

                    b.ToTable("Partida");
                });

            modelBuilder.Entity("Domain.Entities.TimeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<string>("sigla")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("sigla")
                        .IsUnique();

                    b.ToTable("Time");
                });

            modelBuilder.Entity("Domain.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<bool>("isDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("varchar(60) CHARACTER SET utf8mb4")
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.HasIndex("email")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("Domain.Entities.CampeonatoEntity", b =>
                {
                    b.HasOne("Domain.Entities.TimeEntity", "campeao")
                        .WithMany()
                        .HasForeignKey("campeaoId");

                    b.HasOne("Domain.Entities.TimeEntity", "quarto")
                        .WithMany()
                        .HasForeignKey("quartoId");

                    b.HasOne("Domain.Entities.TimeEntity", "terceiro")
                        .WithMany()
                        .HasForeignKey("terceiroId");

                    b.HasOne("Domain.Entities.TimeEntity", "vici")
                        .WithMany()
                        .HasForeignKey("viciId");
                });

            modelBuilder.Entity("Domain.Entities.PartidaEntity", b =>
                {
                    b.HasOne("Domain.Entities.TimeEntity", "timeA")
                        .WithMany()
                        .HasForeignKey("timeAId");

                    b.HasOne("Domain.Entities.TimeEntity", "timeB")
                        .WithMany()
                        .HasForeignKey("timeBId");
                });
#pragma warning restore 612, 618
        }
    }
}