using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using Newtonsoft.Json;

namespace Havira.Business.Helpers;
public class GeoJsonHelper
{
    public static Geometry DeserializeGeoJson(string geoJson)
    {
        var serializer = GeoJsonSerializer.Create();
        using (var stringReader = new StringReader(geoJson))
        using (var jsonReader = new JsonTextReader(stringReader))
        {
            return serializer.Deserialize<Geometry>(jsonReader);
        }
    }

    public static string SerializeGeoJson(Geometry geometry)
    {
        var serializer = GeoJsonSerializer.Create();
        string geoJson;
        using (var stringWriter = new StringWriter())
        using (var jsonWriter = new JsonTextWriter(stringWriter))
        {
            serializer.Serialize(jsonWriter, geometry);
            geoJson = stringWriter.ToString();
        }
        return geoJson;
    }
}