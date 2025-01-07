using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetTopologySuite.Geometries;

namespace Havira.Business.Interfaces
{
    public interface IGeoJsonHelper
    {
        Geometry DeserializeGeoJson(string geoJson);
        string SerializeGeoJson(Geometry geometry);
    }
}