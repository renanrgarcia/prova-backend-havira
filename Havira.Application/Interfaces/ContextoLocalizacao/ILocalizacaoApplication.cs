using Havira.Business.Models.ContextoLocalizacao.Enums;
using Havira.Application.ViewModel.ContextoLocalizacao;

namespace Havira.Application.Interfaces.ContextoLocalizacao
{
    public interface ILocalizacaoApplication : IBaseApplication<LocalizacaoViewModel>
    {
        Task<LocalizacaoViewModel> AdicionarLocalizacao(LocalizacaoViewModel localizacaoViewModel);
        Task<LocalizacaoViewModel> ObterLocalizacaoPorNome(string nome);
        Task<List<Categoria>> ObterCategorias();
        Task<List<LocalizacaoViewModel>> ObterPorCategoria(Categoria categoria);
    }
}