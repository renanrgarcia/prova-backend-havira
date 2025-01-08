using Microsoft.EntityFrameworkCore;
using Havira.Business.Models.ContextFeature;

namespace Havira.Data.Context
{
    public class MyDbContext : DbContext
    {
        public DbSet<Feature> Features { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
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
