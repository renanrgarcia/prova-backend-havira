using Havira.Business.Models.ContextoFeature;
using Havira.Business.Models.ContextoFeature.Enums;

namespace Havira.Business.Interfaces.ContextoFeature
{
    public interface IPropertiesRepository : IRepository<Properties>
    {
        Task<Properties> ObterPropertiesPorNome(string nome);
        Task<List<Categoria>> ObterCategorias();
    }
}