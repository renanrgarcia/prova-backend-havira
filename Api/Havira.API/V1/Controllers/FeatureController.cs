using Havira.Api.Controllers;
using Havira.Application.Interfaces.ContextoFeature;
using Havira.Application.ViewModel.ContextoFeature;
using Havira.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Havira.API.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class FeatureController : MainController
    {
        private readonly IFeatureApplication _featureApplication;
        private readonly IGeoJsonHelper _geoJsonHelper;

        public FeatureController(
            INotificador notificador,
            IGeoJsonHelper geoJsonHelper,
            IFeatureApplication featureApplication) : base(notificador)
        {
            _featureApplication = featureApplication;
            _geoJsonHelper = geoJsonHelper;
        }

        [HttpGet("obterTodos")]
        public async Task<ActionResult<IEnumerable<FeatureViewModel>>> ObterTodos()
        {
            var localizacoes = await _featureApplication.ObterTodos();

            if (!localizacoes.Any()) return CustomResponse();

            foreach (var localizacao in localizacoes)
            {
                localizacao.Geometry = _geoJsonHelper.DeserializeGeoJson(localizacao.Geometry.ToString());
            }

            return CustomResponse(localizacoes);
        }

        [HttpGet("obter/{id:guid}")]
        public async Task<ActionResult<string>> ObterPorId(Guid id)
        {

            var feature = await _featureApplication.ObterPorId(id);

            if (feature == null) return CustomResponse();

            var geoJson = _geoJsonHelper.SerializeGeoJson(feature.Geometry);

            return geoJson;
        }

        [HttpPost("adicionar")]
        public async Task<IActionResult> AdicionarFeature([FromBody] FeatureViewModel featureViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var resultado = await _featureApplication.AdicionarFeature(featureViewModel);

            return CustomResponse(resultado);
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