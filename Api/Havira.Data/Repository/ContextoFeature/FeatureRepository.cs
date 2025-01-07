using Havira.Business.Interfaces.ContextoFeature;
using Havira.Business.Models.ContextoFeature;
using Havira.Business.Models.ContextoFeature.Enums;
using Havira.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Havira.Data.Repository.ContextoFeature
{
    public class FeatureRepository : Repository<Feature>, IFeatureRepository
    {
        public FeatureRepository(MeuDbContext db) : base(db)
        {
        }

        public async Task<Feature> ObterFeaturePorNome(string nome)
        {
            var feature = await DbSet
                            .Include(x => x.Properties)
                            .AsNoTracking()
                            .FirstOrDefaultAsync(x => x.Properties.Nome.ToLower().Trim().Equals(nome.ToLower().Trim()));

            return feature;
        }

        public Task<List<Feature>> ObterFeaturePorCategoria(Categoria categoria)
        {
            var features = DbSet
                            .AsNoTracking()
                            .Include(x => x.Properties)
                            .Where(x => x.Properties.Categoria == categoria)
                            .ToListAsync();

            return features;
        }
    }
}