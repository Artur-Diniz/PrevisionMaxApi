using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrevisionMax.Models;

namespace PrevisionMax.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }


        public DbSet<EstatisticaTimes> Tb_EstatisticaTimes { get; set; }
        public DbSet<EstatisticaTimesCasa> Tb_EstatisticaCasa { get; set; }
        public DbSet<EstatisticaTimesFora> Tb_EstatisticaFora { get; set; }
        public DbSet<Classificacao> TB_Classificacao { get; set; }
        public DbSet<Partidas> TB_Partidas { get; set; }
        public DbSet<TabelaCampeonato> TB_TBCampeonato { get; set; }
        public DbSet<Palpites> TB_Palpites { get; set; }
        public DbSet<EstatisticaTabela> TB_EstatisticaTabela { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EstatisticaTimesCasa>().ToTable("Tb_EstatisticaCasa");
            modelBuilder.Entity<EstatisticaTimesFora>().ToTable("Tb_EstatisticaFora");
            modelBuilder.Entity<Classificacao>().ToTable("TB_Classificacao");
            modelBuilder.Entity<Partidas>().ToTable("TB_Partidas");
            modelBuilder.Entity<TabelaCampeonato>().ToTable("TB_TBCampeonato");
            modelBuilder.Entity<Palpites>().ToTable("TB_Palpites");

        
            // Configuração das chaves estrangeiras
            modelBuilder.Entity<Palpites>()
                .HasOne<Partidas>()
                .WithMany()
                .HasForeignKey(p => p.idPartida);

            modelBuilder.Entity<Partidas>()
                .HasOne<EstatisticaTimesCasa>()
                .WithMany()
                .HasForeignKey(p => p.IdEstatisticaCasa);

            modelBuilder.Entity<Partidas>()
                .HasOne<EstatisticaTimesFora>()
                .WithMany()
                .HasForeignKey(p => p.IdEstatisticaFora);

        
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveColumnType("varChar").HaveMaxLength(200);
        }
    }
}
