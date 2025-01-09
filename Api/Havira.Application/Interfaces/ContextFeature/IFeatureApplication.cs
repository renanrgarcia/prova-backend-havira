using Havira.Application.ViewModel.ContextFeature;

namespace Havira.Application.Interfaces.ContextFeature
{
    public interface IFeatureApplication : IDisposable
    {
        Task<IEnumerable<GetFeatureViewModel>> GetAll();
        Task<GetFeatureViewModel> GetById(Guid Id);
        Task Create(CreateOrUpdateFeatureViewModel viewModel);
        Task<bool> Update(CreateOrUpdateFeatureViewModel viewModel);
        Task<bool> Remove(Guid id);
        Task<CreateOrUpdateFeatureViewModel> CreateFeature(CreateOrUpdateFeatureViewModel viewModel);
        Task<GetFeatureViewModel> GetFeatureByName(string name);
    }
}