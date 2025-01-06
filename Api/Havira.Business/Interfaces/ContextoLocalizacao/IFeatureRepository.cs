using Havira.Business.Models.ContextoFeature;
using Havira.Business.Models.ContextoFeature.Enums;

namespace Havira.Business.Interfaces.ContextoFeature
{
    public interface IFeatureRepository : IRepository<Feature>
    {
        Task<Feature> ObterFeaturePorNome(string nome);
        Task<List<Feature>> ObterFeaturePorCategoria(Categoria categoria);
    }
}