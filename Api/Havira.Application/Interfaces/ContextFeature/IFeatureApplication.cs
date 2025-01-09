using Havira.Application.ViewModel.ContextFeature;

namespace Havira.Application.Interfaces.ContextFeature
{
    public interface IFeatureApplication : IBaseApplication<FeatureViewModel>
    {
        Task<FeatureViewModel> CreateFeature(FeatureViewModel featureViewModel);
        Task<FeatureViewModel> GetFeatureByName(string name);
    }
}