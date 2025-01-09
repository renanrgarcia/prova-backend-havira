
using NetTopologySuite.Geometries;
using Newtonsoft.Json;

namespace Havira.Application.ViewModel.ContextFeature;

public class FeatureViewModel
{
    public Guid Id { get; set; }
    public string Type { get; set; } = "Feature";
    public Geometry Geometry { get; set; }

    public string ToGeoJson()
    {
        var feature = new
        {
            id = Id,
            type = Type,
            geometry = new
            {
                type = Geometry.GeometryType,
                coordinates = Geometry.Coordinates
            },
            properties = new
            {
                nome = Properties.Nome,
                categoria = Properties.Categoria
            }
        };
        return JsonConvert.SerializeObject(feature);
    }
}
