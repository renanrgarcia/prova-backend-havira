using Havira.Api.Controllers;
using Havira.Application.Interfaces.ContextoLocalizacao;
using Havira.Application.ViewModel.ContextoLocalizacao;
using Havira.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Havira.API.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class LocalizacaoController : MainController
    {
        private readonly ILocalizacaoApplication _localizacaoApplication;

        public LocalizacaoController(
            INotificador notificador,
            ILocalizacaoApplication localizacaoApplication) : base(notificador)
        {
            _localizacaoApplication = localizacaoApplication;
        }

        [HttpGet("obterTodos")]
        public async Task<ActionResult<IEnumerable<LocalizacaoViewModel>>> ObterTodos()
        {
            var localizacoes = await _localizacaoApplication.ObterTodos();

            if (!localizacoes.Any()) return CustomResponse();

            return CustomResponse(localizacoes);
        }

        [HttpGet("obter/{id:guid}")]
        public async Task<ActionResult<LocalizacaoViewModel>> ObterPorId(Guid id)
        {
            var localizacao = await _localizacaoApplication.ObterPorId(id);

            if (localizacao == null) return CustomResponse();

            return localizacao;
        }

        [HttpPost("adicionar")]
        public async Task<IActionResult> AdicionarLocalizacao(LocalizacaoViewModel localizacaoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var resultado = await _localizacaoApplication.AdicionarLocalizacao(localizacaoViewModel);

            return CustomResponse(resultado);
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> AtualizarLocalizacao(LocalizacaoViewModel localizacaoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var resultado = await _localizacaoApplication.Atualizar(localizacaoViewModel);

            if (!resultado) return CustomResponse();

            return CustomResponse("Localização atualizada!");
        }

        [HttpDelete("remover/{id:guid}")]
        public async Task<ActionResult> RemoverLocalizacao(Guid id)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var resultado = await _localizacaoApplication.Remover(id);

            if (!resultado) return CustomResponse();

            return CustomResponse("Localização removida!");
        }

        [HttpGet("obterCategorias")]
        public async Task<ActionResult<IEnumerable<string>>> ObterCategorias()
        {
            var categorias = await _localizacaoApplication.ObterCategorias();

            if (categorias == null) return CustomResponse();

            return CustomResponse(categorias);
        }
    }
}