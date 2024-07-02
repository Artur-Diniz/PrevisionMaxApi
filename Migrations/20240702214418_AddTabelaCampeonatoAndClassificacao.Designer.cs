﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PrevisionMax.Data;

#nullable disable

namespace PrevisionMaxApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240702214418_AddTabelaCampeonatoAndClassificacao")]
    partial class AddTabelaCampeonatoAndClassificacao
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PrevisionMax.Models.Classificacao", b =>
                {
                    b.Property<int>("idClassficacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idClassficacao"));

                    b.Property<int>("GolsFeitos")
                        .HasColumnType("int");

                    b.Property<int>("GolsSofridos")
                        .HasColumnType("int");

                    b.Property<string>("NomeTime")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varChar");

                    b.Property<int>("Pontos")
                        .HasColumnType("int");

                    b.Property<int>("PosicaoTime")
                        .HasColumnType("int");

                    b.Property<int>("numDerrotas")
                        .HasColumnType("int");

                    b.Property<int>("numEmpates")
                        .HasColumnType("int");

                    b.Property<int>("numJogos")
                        .HasColumnType("int");

                    b.Property<int>("numVitorias")
                        .HasColumnType("int");

                    b.Property<string>("ultiomojogos1")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varChar");

                    b.Property<string>("ultiomojogos2")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varChar");

                    b.Property<string>("ultiomojogos3")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varChar");

                    b.Property<string>("ultiomojogos4")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varChar");

                    b.Property<string>("ultiomojogos5")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varChar");

                    b.HasKey("idClassficacao");

                    b.ToTable("TB_Classificacao", (string)null);
                });

            modelBuilder.Entity("PrevisionMax.Models.EstatisticaTimesCasa", b =>
                {
                    b.Property<int>("IdEstatisticaCasa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEstatisticaCasa"));

                    b.Property<int>("AtaquesperigososCasa")
                        .HasColumnType("int");

                    b.Property<int>("CartoesAmareloCasa")
                        .HasColumnType("int");

                    b.Property<int>("CartoesVermelhosCasa")
                        .HasColumnType("int");

                    b.Property<int>("DefesaGoleiroCasa")
                        .HasColumnType("int");

                    b.Property<int>("FaltasCasas")
                        .HasColumnType("int");

                    b.Property<int>("GolsCasa")
                        .HasColumnType("int");

                    b.Property<int>("InpedimentosCasa")
                        .HasColumnType("int");

                    b.Property<string>("NomeTimeCasa")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varChar");

                    b.Property<int>("PassesCompletosCasa")
                        .HasColumnType("int");

                    b.Property<int>("PassesTotaisCasa")
                        .HasColumnType("int");

                    b.Property<int>("TentativasGolsCasa")
                        .HasColumnType("int");

                    b.Property<int>("chutesnoGolsCasa")
                        .HasColumnType("int");

                    b.Property<int>("chutespraforaCasa")
                        .HasColumnType("int");

                    b.Property<int>("escanteiosCasa")
                        .HasColumnType("int");

                    b.HasKey("IdEstatisticaCasa");

                    b.ToTable("Tb_EstatisticaCasa", (string)null);

                    b.HasData(
                        new
                        {
                            IdEstatisticaCasa = 1,
                            AtaquesperigososCasa = 0,
                            CartoesAmareloCasa = 0,
                            CartoesVermelhosCasa = 0,
                            DefesaGoleiroCasa = 0,
                            FaltasCasas = 0,
                            GolsCasa = 99,
                            InpedimentosCasa = 0,
                            NomeTimeCasa = "Palmeiras",
                            PassesCompletosCasa = 0,
                            PassesTotaisCasa = 0,
                            TentativasGolsCasa = 0,
                            chutesnoGolsCasa = 0,
                            chutespraforaCasa = 0,
                            escanteiosCasa = 0
                        },
                        new
                        {
                            IdEstatisticaCasa = 2,
                            AtaquesperigososCasa = 0,
                            CartoesAmareloCasa = 0,
                            CartoesVermelhosCasa = 0,
                            DefesaGoleiroCasa = 0,
                            FaltasCasas = 0,
                            GolsCasa = -31,
                            InpedimentosCasa = 0,
                            NomeTimeCasa = "Corinthians",
                            PassesCompletosCasa = 0,
                            PassesTotaisCasa = 0,
                            TentativasGolsCasa = 0,
                            chutesnoGolsCasa = 0,
                            chutespraforaCasa = 0,
                            escanteiosCasa = 0
                        },
                        new
                        {
                            IdEstatisticaCasa = 3,
                            AtaquesperigososCasa = 0,
                            CartoesAmareloCasa = 0,
                            CartoesVermelhosCasa = 0,
                            DefesaGoleiroCasa = 0,
                            FaltasCasas = 0,
                            GolsCasa = 2,
                            InpedimentosCasa = 0,
                            NomeTimeCasa = "Flamengo",
                            PassesCompletosCasa = 0,
                            PassesTotaisCasa = 0,
                            TentativasGolsCasa = 0,
                            chutesnoGolsCasa = 0,
                            chutespraforaCasa = 0,
                            escanteiosCasa = 0
                        });
                });

            modelBuilder.Entity("PrevisionMax.Models.EstatisticaTimesFora", b =>
                {
                    b.Property<int>("IdEstatisticaFora")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEstatisticaFora"));

                    b.Property<int>("AtaquesperigososFora")
                        .HasColumnType("int");

                    b.Property<int>("CartoesAmareloFora")
                        .HasColumnType("int");

                    b.Property<int>("CartoesVermelhosFora")
                        .HasColumnType("int");

                    b.Property<int>("DefesaGoleiroFora")
                        .HasColumnType("int");

                    b.Property<int>("FaltasForas")
                        .HasColumnType("int");

                    b.Property<int>("GolsFora")
                        .HasColumnType("int");

                    b.Property<int>("InpedimentosFora")
                        .HasColumnType("int");

                    b.Property<string>("NomeTimeFora")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varChar");

                    b.Property<int>("PassesCompletosFora")
                        .HasColumnType("int");

                    b.Property<int>("PassesTotaisFora")
                        .HasColumnType("int");

                    b.Property<int>("TentativasGolsFora")
                        .HasColumnType("int");

                    b.Property<int>("chutesnoGolsFora")
                        .HasColumnType("int");

                    b.Property<int>("chutespraforaFora")
                        .HasColumnType("int");

                    b.Property<int>("escanteiosFora")
                        .HasColumnType("int");

                    b.HasKey("IdEstatisticaFora");

                    b.ToTable("Tb_EstatisticaFora", (string)null);
                });

            modelBuilder.Entity("PrevisionMax.Models.Palpites", b =>
                {
                    b.Property<int>("idPalpites")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idPalpites"));

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varChar");

                    b.Property<int>("idPartida")
                        .HasColumnType("int");

                    b.Property<double?>("num")
                        .HasColumnType("float");

                    b.Property<int>("tipoAposta")
                        .HasColumnType("int");

                    b.HasKey("idPalpites");

                    b.HasIndex("idPartida");

                    b.ToTable("TB_Palpites", (string)null);
                });

            modelBuilder.Entity("PrevisionMax.Models.Partidas", b =>
                {
                    b.Property<int>("idPartida")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idPartida"));

                    b.Property<string>("Campeonato")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varChar");

                    b.Property<int>("IdEstatisticaCasa")
                        .HasColumnType("int");

                    b.Property<int>("IdEstatisticaFora")
                        .HasColumnType("int");

                    b.Property<string>("NomeTimeCasa")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varChar");

                    b.Property<string>("NomeTimeFora")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varChar");

                    b.Property<DateTime>("data")
                        .HasColumnType("datetime2");

                    b.HasKey("idPartida");

                    b.HasIndex("IdEstatisticaCasa");

                    b.HasIndex("IdEstatisticaFora");

                    b.ToTable("TB_Partidas", (string)null);
                });

            modelBuilder.Entity("PrevisionMax.Models.TabelaCampeonato", b =>
                {
                    b.Property<int>("idCampeonato")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idCampeonato"));

                    b.Property<string>("ClassificacaoIds")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeCampeonato")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varChar");

                    b.Property<DateTime>("data")
                        .HasColumnType("datetime2");

                    b.HasKey("idCampeonato");

                    b.ToTable("TB_TBCampeonato", (string)null);
                });

            modelBuilder.Entity("PrevisionMax.Models.Palpites", b =>
                {
                    b.HasOne("PrevisionMax.Models.Partidas", null)
                        .WithMany()
                        .HasForeignKey("idPartida")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PrevisionMax.Models.Partidas", b =>
                {
                    b.HasOne("PrevisionMax.Models.EstatisticaTimesCasa", null)
                        .WithMany()
                        .HasForeignKey("IdEstatisticaCasa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PrevisionMax.Models.EstatisticaTimesFora", null)
                        .WithMany()
                        .HasForeignKey("IdEstatisticaFora")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
