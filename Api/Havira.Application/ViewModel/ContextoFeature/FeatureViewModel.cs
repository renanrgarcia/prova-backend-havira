using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using Newtonsoft.Json;

namespace Havira.Application.ViewModel.ContextoFeature;

public class FeatureViewModel
{
    public Guid Id { get; set; }
    [JsonProperty("type")]
    public string Type { get; set; }
    public Geometry Geometry { get; set; }
    public PropertiesViewModel Properties { get; set; }


    public static Geometry DeserializeGeometry(string geoJson)
    {
        var serializer = GeoJsonSerializer.Create();

        using var stringReader = new StringReader(geoJson);
        using var jsonReader = new JsonTextReader(stringReader);

        return serializer.Deserialize<Geometry>(jsonReader);
    }

    public static string SerializeGeometry(Geometry geometry)
    {
        var serializer = GeoJsonSerializer.Create();

        using var stringWriter = new StringWriter();
        using var jsonWriter = new JsonTextWriter(stringWriter);
        serializer.Serialize(jsonWriter, geometry);

        return stringWriter.ToString();
    }
}
