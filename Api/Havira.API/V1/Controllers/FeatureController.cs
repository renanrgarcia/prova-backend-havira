using Havira.Api.Controllers;
using Havira.Application.Interfaces.ContextFeature;
using Havira.Application.ViewModel.ContextFeature;
using Havira.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Havira.API.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class FeatureController : MainController
    {
        private readonly IFeatureApplication _featureApplication;

        public FeatureController(
            INotificador notificador,
            IFeatureApplication featureApplication) : base(notificador)
        {
            _featureApplication = featureApplication;
        }

        [HttpGet("obterTodos")]
        public async Task<ActionResult<IEnumerable<string>>> ObterTodos()
        {
            var localizacoes = await _featureApplication.ObterTodos();

            if (!localizacoes.Any()) return CustomResponse();

            Console.WriteLine("Localizações: " + localizacoes.ToArray());

            // foreach (var localizacao in localizacoes)
            // {
            //     localizacao.ToGeoJson();
            // }

            // Console.WriteLine("Localizações2: " + localizacoes);

            return CustomResponse(localizacoes);
        }

        [HttpGet("obter/{id:guid}")]
        public async Task<ActionResult<string>> ObterPorId(Guid id)
        {

            var feature = await _featureApplication.ObterPorId(id);

            if (feature == null) return CustomResponse();

            return feature.ToGeoJson();
        }

        [HttpPost("adicionar")]
        public async Task<IActionResult> AdicionarFeature([FromBody] FeatureViewModel featureViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var resultado = await _featureApplication.AdicionarFeature(featureViewModel);

            return CustomResponse(resultado.ToGeoJson());
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> AtualizarFeature([FromBody] FeatureViewModel featureViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var resultado = await _featureApplication.Atualizar(featureViewModel);

            if (!resultado) return CustomResponse();

            return CustomResponse("Localização atualizada!");
        }

        [HttpDelete("remover/{id:guid}")]
        public async Task<ActionResult> RemoverFeature(Guid id)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var resultado = await _featureApplication.Remover(id);

            if (!resultado) return CustomResponse();

            return CustomResponse("Localização removida!");
        }
    }
}