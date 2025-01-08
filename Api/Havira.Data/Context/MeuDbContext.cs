using Microsoft.EntityFrameworkCore;
using Havira.Business.Models.ContextoFeature;

namespace Havira.Data.Context
{
    public class MeuDbContext : DbContext
    {
        public DbSet<Feature> Features { get; set; }
        public DbSet<Properties> Properties { get; set; }

        public MeuDbContext(DbContextOptions<MeuDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("postgis");
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
