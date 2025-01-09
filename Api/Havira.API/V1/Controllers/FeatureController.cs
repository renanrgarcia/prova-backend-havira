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
            INotificator notificator,
            IFeatureApplication featureApplication) : base(notificator)
        {
            _featureApplication = featureApplication;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<IEnumerable<string>>> getAll()
        {
            var localizacoes = await _featureApplication.GetAll();

            if (!localizacoes.Any()) return CustomResponse();

            Console.WriteLine("Localizações: " + localizacoes.ToArray());

            return CustomResponse(localizacoes);
        }

        [HttpGet("get/{id:guid}")]
        public async Task<ActionResult<string>> GetById(Guid id)
        {

            var feature = await _featureApplication.GetById(id);

            if (feature == null) return CustomResponse();

            return feature.ToGeoJson();
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateFeature([FromBody] FeatureViewModel featureViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var resultado = await _featureApplication.CreateFeature(featureViewModel);

            return CustomResponse(resultado.ToGeoJson());
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateFeature([FromBody] FeatureViewModel featureViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var resultado = await _featureApplication.Update(featureViewModel);

            if (!resultado) return CustomResponse();

            return CustomResponse("Localização atualizada!");
        }

        [HttpDelete("remove/{id:guid}")]
        public async Task<ActionResult> RemoveFeature(Guid id)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var resultado = await _featureApplication.Remove(id);

            if (!resultado) return CustomResponse();

            return CustomResponse("Localização removida!");
        }
    }
}