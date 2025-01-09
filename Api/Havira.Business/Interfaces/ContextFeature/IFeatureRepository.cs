using Havira.Business.Models.ContextFeature;
using Havira.Business.Models.ContextFeature.Enums;

namespace Havira.Business.Interfaces.ContextFeature
{
    public interface IFeatureRepository : IRepository<Feature>
    {
        Task<Feature> GetFeatureByName(string name);
        Task<List<Feature>> GetFeaturesByCategory(Category category);
        Task<List<Category>> GetCategories();
    }
}