using Havira.Application.ViewModel.ContextFeature;

namespace Havira.Application.Interfaces.ContextFeature
{
    public interface IFeatureApplication : IDisposable
    {
        Task<IEnumerable<GetFeatureViewModel>> GetAll();
        Task<GetFeatureViewModel> GetById(Guid Id);
        Task Create(CreateFeatureViewModel viewModel);
        Task<bool> Update(CreateFeatureViewModel viewModel);
        Task<bool> Remove(Guid id);
        Task<CreateFeatureViewModel> CreateFeature(CreateFeatureViewModel viewModel);
        Task<GetFeatureViewModel> GetFeatureByName(string name);
    }
}