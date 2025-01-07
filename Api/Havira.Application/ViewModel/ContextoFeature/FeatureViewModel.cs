using Havira.Business.Helpers;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;

namespace Havira.Application.ViewModel.ContextoFeature;

public class FeatureViewModel
{
    public Guid Id { get; set; }
    public string Type { get; set; } = "Feature";
    public Geometry Geometry { get; set; }
    public PropertiesViewModel Properties { get; set; }
}
