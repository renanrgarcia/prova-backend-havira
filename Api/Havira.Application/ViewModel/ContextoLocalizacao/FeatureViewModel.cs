using System.Text.Json.Serialization;
using Havira.Business.Models.ContextoFeature.Enums;
using NetTopologySuite.Geometries;
using static Havira.Business.Models.ContextoFeature.Feature;

namespace Havira.Application.ViewModel.ContextoFeature;

public class FeatureViewModel
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public Geometry Geometry { get; set; }
    public PropertiesViewModel PropertiesViewModel { get; set; }
}
