using Havira.Business.Models.ContextoLocalizacao;
using Havira.Business.Models.ContextoLocalizacao.Enums;

namespace Havira.Business.Interfaces.ContextoLocalizacao
{
    public interface ILocalizacaoRepository : IRepository<Localizacao>
    {
        Task<Localizacao> ObterLocalizacaoPorNome(string nome);
        Task<List<Categoria>> ObterCategorias();
        Task<List<Localizacao>> ObterPorCategoria(Categoria categoria);
    }
}