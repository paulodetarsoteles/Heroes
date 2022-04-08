using Heroes.Models;
using Microsoft.EntityFrameworkCore;

namespace Heroes.Data
{
    public class HeroiContext : DbContext
    {
        DbSet<Heroi> Herois { get; set; }
        DbSet<Arma> Armas { get; set; }
        DbSet<IdentidadeSecreta> IdentidadesSecretas { get; set; }
        DbSet<Batalha> Batalhas { get; set; }
        DbSet<HeroiBatalha> HeroisBatalhas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                ("Password=12345678;Persist Security Info=False;User ID=sa;Initial Catalog=HeroApp;Data Source=DESKTOP-JVF2A0R\\SQLEXPRESS");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeroiBatalha>(x =>
            {
                x.HasKey(y => new
                {
                    y.BatalhaId,
                    y.HeroiId
                });
            });
        }
    }
}