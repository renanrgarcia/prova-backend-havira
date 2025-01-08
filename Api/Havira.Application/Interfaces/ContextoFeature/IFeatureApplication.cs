using Havira.Business.Models.ContextFeature.Enums;
using Havira.Application.ViewModel.ContextFeature;

namespace Havira.Application.Interfaces.ContextFeature
{
    public interface IFeatureApplication : IBaseApplication<FeatureViewModel>
    {
        Task<FeatureViewModel> AdicionarFeature(FeatureViewModel featureViewModel);
        Task<FeatureViewModel> ObterFeaturePorNome(string nome);
    }
}