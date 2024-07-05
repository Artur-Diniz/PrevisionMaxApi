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
    [Migration("20240704181835_AddPEstatisticaTimes")]
    partial class AddPEstatisticaTimes
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
                        .HasMaxLength(200)
                        .HasColumnType("varChar");

                    b.Property<string>("ultiomojogos2")
                        .HasMaxLength(200)
                        .HasColumnType("varChar");

                    b.Property<string>("ultiomojogos3")
                        .HasMaxLength(200)
                        .HasColumnType("varChar");

                    b.Property<string>("ultiomojogos4")
                        .HasMaxLength(200)
                        .HasColumnType("varChar");

                    b.Property<string>("ultiomojogos5")
                        .HasMaxLength(200)
                        .HasColumnType("varChar");

                    b.HasKey("idClassficacao");

                    b.ToTable("TB_Classificacao", (string)null);
                });

            modelBuilder.Entity("PrevisionMax.Models.EstatisticaTimes", b =>
                {
                    b.Property<int>("IdTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTime"));

                    b.Property<int>("AtaquesperigososMedia")
                        .HasColumnType("int");

                    b.Property<int>("AtaquesperigososMediaCF")
                        .HasColumnType("int");

                    b.Property<int>("CartoesAmareloMaior")
                        .HasColumnType("int");

                    b.Property<int>("CartoesAmareloMedia")
                        .HasColumnType("int");

                    b.Property<int>("CartoesAmareloMediaCF")
                        .HasColumnType("int");

                    b.Property<int>("CartoesAmareloMenor")
                        .HasColumnType("int");

                    b.Property<int>("CartoesVermelhosMedia")
                        .HasColumnType("int");

                    b.Property<int>("DefesaGoleiroMaior")
                        .HasColumnType("int");

                    b.Property<int>("DefesaGoleiroMedia")
                        .HasColumnType("int");

                    b.Property<int>("DefesaGoleiroMediaCF")
                        .HasColumnType("int");

                    b.Property<int>("DefesaGoleiroMenor")
                        .HasColumnType("int");

                    b.Property<int>("FaltasMaior")
                        .HasColumnType("int");

                    b.Property<int>("FaltasMedia")
                        .HasColumnType("int");

                    b.Property<int>("FaltasMediaCF")
                        .HasColumnType("int");

                    b.Property<int>("FaltasMenor")
                        .HasColumnType("int");

                    b.Property<int>("GolMaior")
                        .HasColumnType("int");

                    b.Property<int>("GolMedias")
                        .HasColumnType("int");

                    b.Property<int>("GolMediasCF")
                        .HasColumnType("int");

                    b.Property<int>("GolMenor")
                        .HasColumnType("int");

                    b.Property<int>("InpedimentosMaior")
                        .HasColumnType("int");

                    b.Property<int>("InpedimentosMedia")
                        .HasColumnType("int");

                    b.Property<int>("InpedimentosMediaCF")
                        .HasColumnType("int");

                    b.Property<int>("InpedimentosMenor")
                        .HasColumnType("int");

                    b.Property<string>("NomeTime")
                        .HasMaxLength(200)
                        .HasColumnType("varChar");

                    b.Property<int>("PassesCompletosMaior")
                        .HasColumnType("int");

                    b.Property<int>("PassesCompletosMedia")
                        .HasColumnType("int");

                    b.Property<int>("PassesCompletosMediaCF")
                        .HasColumnType("int");

                    b.Property<int>("PassesCompletosMenor")
                        .HasColumnType("int");

                    b.Property<int>("PassesTotaisMaior")
                        .HasColumnType("int");

                    b.Property<int>("PassesTotaisMedia")
                        .HasColumnType("int");

                    b.Property<int>("PassesTotaisMediaCF")
                        .HasColumnType("int");

                    b.Property<int>("PassesTotaisMenor")
                        .HasColumnType("int");

                    b.Property<int>("TentativasGolsMaior")
                        .HasColumnType("int");

                    b.Property<int>("TentativasGolsMedias")
                        .HasColumnType("int");

                    b.Property<int>("TentativasGolsMediasCF")
                        .HasColumnType("int");

                    b.Property<int>("TentativasGolsMenor")
                        .HasColumnType("int");

                    b.Property<int>("chutesnoGolsMaior")
                        .HasColumnType("int");

                    b.Property<int>("chutesnoGolsMedia")
                        .HasColumnType("int");

                    b.Property<int>("chutesnoGolsMediaCF")
                        .HasColumnType("int");

                    b.Property<int>("chutesnoGolsMenor")
                        .HasColumnType("int");

                    b.Property<int>("chutespraforaMaior")
                        .HasColumnType("int");

                    b.Property<int>("chutespraforaMedia")
                        .HasColumnType("int");

                    b.Property<int>("chutespraforaMediaCF")
                        .HasColumnType("int");

                    b.Property<int>("chutespraforaMenor")
                        .HasColumnType("int");

                    b.Property<int>("escanteiosMaior")
                        .HasColumnType("int");

                    b.Property<int>("escanteiosMedia")
                        .HasColumnType("int");

                    b.Property<int>("escanteiosMediaCF")
                        .HasColumnType("int");

                    b.Property<int>("escanteiosMenor")
                        .HasColumnType("int");

                    b.HasKey("IdTime");

                    b.ToTable("Tb_EstatisticaTimes");
                });

            modelBuilder.Entity("PrevisionMax.Models.EstatisticaTimesCasa", b =>
                {
                    b.Property<int>("IdEstatisticaCasa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEstatisticaCasa"));

                    b.Property<string>("AdversarioFora")
                        .HasMaxLength(200)
                        .HasColumnType("varChar");

                    b.Property<int>("AtaquesperigososCasa")
                        .HasColumnType("int");

                    b.Property<int?>("CartoesAmareloCasa")
                        .HasColumnType("int");

                    b.Property<int?>("CartoesVermelhosCasa")
                        .HasColumnType("int");

                    b.Property<int?>("DefesaGoleiroCasa")
                        .HasColumnType("int");

                    b.Property<int>("FaltasCasas")
                        .HasColumnType("int");

                    b.Property<int>("GolsCasa")
                        .HasColumnType("int");

                    b.Property<int>("GolsSofridosCasa")
                        .HasColumnType("int");

                    b.Property<int?>("InpedimentosCasa")
                        .HasColumnType("int");

                    b.Property<string>("NomeTimeCasa")
                        .HasMaxLength(200)
                        .HasColumnType("varChar");

                    b.Property<int>("PassesCompletosCasa")
                        .HasColumnType("int");

                    b.Property<int>("PassesTotaisCasa")
                        .HasColumnType("int");

                    b.Property<int>("TentativasGolsCasa")
                        .HasColumnType("int");

                    b.Property<int?>("chutesnoGolsCasa")
                        .HasColumnType("int");

                    b.Property<int>("chutespraforaCasa")
                        .HasColumnType("int");

                    b.Property<int?>("escanteiosCasa")
                        .HasColumnType("int");

                    b.HasKey("IdEstatisticaCasa");

                    b.ToTable("Tb_EstatisticaCasa", (string)null);
                });

            modelBuilder.Entity("PrevisionMax.Models.EstatisticaTimesFora", b =>
                {
                    b.Property<int>("IdEstatisticaFora")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEstatisticaFora"));

                    b.Property<string>("AdversarioCasa")
                        .HasMaxLength(200)
                        .HasColumnType("varChar");

                    b.Property<int>("AtaquesperigososFora")
                        .HasColumnType("int");

                    b.Property<int?>("CartoesAmareloFora")
                        .HasColumnType("int");

                    b.Property<int?>("CartoesVermelhosFora")
                        .HasColumnType("int");

                    b.Property<int?>("DefesaGoleiroFora")
                        .HasColumnType("int");

                    b.Property<int>("FaltasForas")
                        .HasColumnType("int");

                    b.Property<int>("GolsFora")
                        .HasColumnType("int");

                    b.Property<int>("GolsSofridosFora")
                        .HasColumnType("int");

                    b.Property<int?>("InpedimentosFora")
                        .HasColumnType("int");

                    b.Property<string>("NomeTimeFora")
                        .HasMaxLength(200)
                        .HasColumnType("varChar");

                    b.Property<int>("PassesCompletosFora")
                        .HasColumnType("int");

                    b.Property<int>("PassesTotaisFora")
                        .HasColumnType("int");

                    b.Property<int>("TentativasGolsFora")
                        .HasColumnType("int");

                    b.Property<int?>("chutesnoGolsFora")
                        .HasColumnType("int");

                    b.Property<int>("chutespraforaFora")
                        .HasColumnType("int");

                    b.Property<int?>("escanteiosFora")
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
                        .HasMaxLength(200)
                        .HasColumnType("varChar");

                    b.Property<int?>("IdEstatisticaCasa")
                        .HasColumnType("int");

                    b.Property<int?>("IdEstatisticaFora")
                        .HasColumnType("int");

                    b.Property<string>("NomeTimeCasa")
                        .HasMaxLength(200)
                        .HasColumnType("varChar");

                    b.Property<string>("NomeTimeFora")
                        .HasMaxLength(200)
                        .HasColumnType("varChar");

                    b.Property<bool>("PartidaAnalise")
                        .HasColumnType("bit");

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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeCampeonato")
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
                        .HasForeignKey("IdEstatisticaCasa");

                    b.HasOne("PrevisionMax.Models.EstatisticaTimesFora", null)
                        .WithMany()
                        .HasForeignKey("IdEstatisticaFora");
                });
#pragma warning restore 612, 618
        }
    }
}
