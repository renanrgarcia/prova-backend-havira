using Havira.Business.Models.ContextFeature.Enums;
using Newtonsoft.Json;

namespace Havira.Application.ViewModel.ContextFeature;

public class PropertiesViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public Categoria Categoria { get; set; }
}