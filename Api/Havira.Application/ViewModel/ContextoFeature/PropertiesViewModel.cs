using Havira.Business.Models.ContextoFeature.Enums;
using Newtonsoft.Json;

namespace Havira.Application.ViewModel.ContextoFeature;

public class PropertiesViewModel
{
    [JsonProperty("nome")]
    public string Nome { get; set; }
    [JsonProperty("categoria")]
    public Categoria Categoria { get; set; }
}