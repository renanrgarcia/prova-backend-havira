using Havira.Business.Models.ContextoFeature;
using Havira.Business.Models.ContextoFeature.Enums;

namespace Havira.Business.Interfaces.ContextoFeature
{
    public interface IFeatureRepository : IRepository<Feature>
    {
        Task<Feature> ObterFeaturePorNome(string name);
        Task<List<Feature>> ObterFeaturePorCategoria(Category category);
    }
}