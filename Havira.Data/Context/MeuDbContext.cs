using Havira.Business.Models.ContextoLocalizacao;
using Microsoft.EntityFrameworkCore;

namespace Havira.Data.Context
{
    public class MeuDbContext : DbContext
    {
        public DbSet<Localizacao> Localizacoes { get; set; }
        public MeuDbContext()
        {
        }
        public MeuDbContext(DbContextOptions<MeuDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Localizacao>(b =>
            {
                b.Property(p => p.Coordenadas).HasColumnType("geometry(Point, 4326)");
                b.HasIndex(p => p.Coordenadas).HasMethod("GIST");
            });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}