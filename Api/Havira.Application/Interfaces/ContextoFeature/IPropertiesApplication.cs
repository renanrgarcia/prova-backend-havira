using Havira.Business.Models.ContextoFeature.Enums;
using Havira.Application.ViewModel.ContextoFeature;

namespace Havira.Application.Interfaces.ContextoFeature
{
    public interface IPropertiesApplication : IBaseApplication<PropertiesViewModel>
    {
        Task<List<Categoria>> ObterCategorias();
    }
}