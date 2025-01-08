using Havira.Api.Controllers;
using Havira.Application.Interfaces.ContextFeature;
using Havira.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Havira.API.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PropertiesController : MainController
    {
        private readonly IPropertiesApplication _propertiesApplication;

        public PropertiesController(
            INotificador notificador,
            IPropertiesApplication propertiesApplication) : base(notificador)
        {
            _propertiesApplication = propertiesApplication;
        }

        [HttpGet("obterCategorias")]
        public async Task<ActionResult<IEnumerable<string>>> ObterCategorias()
        {
            var categorias = await _propertiesApplication.ObterCategorias();

            if (categorias == null) return CustomResponse();

            return CustomResponse(categorias);
        }
    }
}