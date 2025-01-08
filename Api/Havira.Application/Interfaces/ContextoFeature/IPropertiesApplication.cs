using Havira.Business.Models.ContextFeature.Enums;
using Havira.Application.ViewModel.ContextFeature;

namespace Havira.Application.Interfaces.ContextFeature
{
    public interface IPropertiesApplication : IBaseApplication<PropertiesViewModel>
    {
        Task<List<Categoria>> ObterCategorias();
    }
}