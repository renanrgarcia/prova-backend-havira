using Havira.Business.Models.ContextoFeature.Enums;
using Newtonsoft.Json;

namespace Havira.Application.ViewModel.ContextoFeature;

public class PropertiesViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public Categoria Categoria { get; set; }
}