using Havira.Business.Models.ContextoLocalizacao;

namespace Havira.Business.Interfaces.ContextoLocalizacao
{
    public interface ILocalizacaoRepository : IRepository<Localizacao>
    {
        Task<Localizacao> ObterLocalizacaoPorTitulo(string titulo);
        Task<List<string>> ObterCategorias();
        Task<List<string>> ObterPorCategoria();
    }
}