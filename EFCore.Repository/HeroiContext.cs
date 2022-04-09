using Microsoft.EntityFrameworkCore;
using EFCore.Domain;

namespace EFCore.Repository
{

    public class HeroiContext : DbContext
    {
        public HeroiContext(DbContextOptions<HeroiContext> options) : base(options) { }

        DbSet<Heroi> Herois { get; set; }
        DbSet<Arma> Armas { get; set; }
        DbSet<IdentidadeSecreta> IdentidadesSecretas { get; set; }
        DbSet<Batalha> Batalhas { get; set; }
        DbSet<HeroiBatalha> HeroisBatalhas { get; set; }

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
