using NetTopologySuite.Geometries;

namespace Havira.Application.ViewModel.ContextoFeature;

public class FeatureViewModel
{
    public string Type { get; set; } = "Feature";
    public Geometry Geometry { get; set; }
    public PropertiesViewModel Properties { get; set; }
}
