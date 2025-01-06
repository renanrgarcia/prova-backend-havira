using Havira.Business.Models.ContextoFeature.Enums;
using Havira.Application.ViewModel.ContextoFeature;

namespace Havira.Application.Interfaces.ContextoFeature
{
    public interface IFeatureApplication : IBaseApplication<FeatureViewModel>
    {
        Task<FeatureViewModel> AdicionarFeature(FeatureViewModel featureViewModel);
        Task<FeatureViewModel> ObterFeaturePorNome(string nome);
        Task<List<FeatureViewModel>> ObterPorCategoria(Categoria categoria);
    }
}