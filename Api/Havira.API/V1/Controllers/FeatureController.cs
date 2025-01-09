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
        public async Task<ActionResult<IEnumerable<GetFeatureViewModel>>> GetAll()
        {
            var features = await _featureApplication.GetAll();

            if (!features.Any()) return CustomResponse();

            return CustomResponse(features);
        }

        [HttpGet("get/{id:guid}")]
        public async Task<ActionResult<GetFeatureViewModel>> GetById(Guid id)
        {

            var feature = await _featureApplication.GetById(id);

            if (feature == null) return CustomResponse();

            return feature;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateFeature([FromBody] CreateFeatureViewModel featureViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _featureApplication.CreateFeature(featureViewModel);

            return CustomResponse(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateFeature([FromBody] CreateFeatureViewModel featureViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _featureApplication.Update(featureViewModel);

            if (!result) return CustomResponse();

            return CustomResponse("Location updated!");
        }

        [HttpDelete("remove/{id:guid}")]
        public async Task<ActionResult> RemoveFeature(Guid id)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _featureApplication.Remove(id);

            if (!result) return CustomResponse();

            return CustomResponse("Location removed!");
        }
    }
}