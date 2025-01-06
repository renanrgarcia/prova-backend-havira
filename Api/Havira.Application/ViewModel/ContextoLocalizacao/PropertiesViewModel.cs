using System.Text.Json.Serialization;
using Havira.Business.Models.ContextoFeature.Enums;
using NetTopologySuite.Geometries;
using static Havira.Business.Models.ContextoFeature.Properties;

namespace Havira.Application.ViewModel.ContextoFeature;

public class PropertiesViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public Categoria Categoria { get; set; }
    public Guid FeatureId { get; set; }
}