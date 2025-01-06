using Havira.Business.Models.ContextoFeature.Enums;
using Havira.Application.ViewModel.ContextoFeature;

namespace Havira.Application.Interfaces.ContextoFeature
{
    public interface IPropertiesApplication : IBaseApplication<PropertiesViewModel>
    {
        Task<PropertiesViewModel> AdicionarProperties(PropertiesViewModel propertiesViewModel);
        Task<List<Categoria>> ObterCategorias();
    }
}