using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO; // Ensure this is used for WKTReader
using System.Text.Json;
using Havira.Business.Models.ContextoLocalizacao;
using System.ComponentModel.DataAnnotations.Schema;

namespace Havira.Data.Context
{
    public class MeuDbContext : DbContext
    {
        public DbSet<Localizacao> Localizacoes { get; set; }

        public MeuDbContext(DbContextOptions<MeuDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("postgis");

            var coordenadasConverter = new ValueConverter<Point, string>(
                v => v == null ? null : v.ToString(),
                v => v == null ? null : (Point)new WKTReader().Read(v)
            );

            modelBuilder.Entity<Localizacao>(b =>
            {
                b.Property(p => p.Coordenadas)
                    .HasColumnType("geography(Point,4326)")
                    .HasConversion(coordenadasConverter);
            });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
