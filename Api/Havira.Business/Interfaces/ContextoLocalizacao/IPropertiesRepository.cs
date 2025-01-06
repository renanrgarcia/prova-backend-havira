using Havira.Business.Models.ContextoFeature;
using Havira.Business.Models.ContextoFeature.Enums;

namespace Havira.Business.Interfaces.ContextoProperties
{
    public interface IPropertiesRepository : IRepository<Properties>
    {
        Task<List<Categoria>> ObterCategorias();
    }
}