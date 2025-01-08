using Havira.Business.Interfaces.ContextFeature;
using Havira.Business.Models.ContextFeature;
using Havira.Business.Models.ContextFeature.Enums;
using Havira.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Havira.Data.Repository.ContextFeature
{
    public class FeatureRepository : Repository<Feature>, IFeatureRepository
    {
        public FeatureRepository(MyDbContext db) : base(db)
        {
        }

        public async Task<Feature> GetFeatureByName(string name)
        {
            var feature = await DbSet
                            .AsNoTracking()
                            .FirstOrDefaultAsync(x => x.Name.ToLower().Trim().Equals(name.ToLower().Trim()));

            return feature;
        }

        public Task<List<Feature>> GetFeaturesByCategory(Category category)
        {
            var features = DbSet
                            .AsNoTracking()
                            .Where(x => x.Category == category)
                            .ToListAsync();

            return features;
        }

        public async Task<List<Category>> GetCategories()
        {
            var categories = await DbSet
                                .AsNoTracking()
                                .Select(x => x.Category)
                                .Distinct()
                                .ToListAsync();

            return categories;
        }
    }
}