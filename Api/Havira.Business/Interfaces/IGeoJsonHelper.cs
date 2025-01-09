using NetTopologySuite.Geometries;

namespace Havira.Business.Interfaces
{
    public interface IGeoJsonHelper
    {
        Geometry DeserializeGeoJson(string geoJson);
        string SerializeGeoJson(Geometry geometry);
    }
}