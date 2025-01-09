using System.ComponentModel.DataAnnotations.Schema;
using Havira.Business.Models.ContextFeature.Enums;
using NetTopologySuite.Geometries;

namespace Havira.Business.Models.ContextFeature
{
    [Table(name: "feature", Schema = "dbo")]
    public class Feature : Entity
    {
        public string Name { get; set; }
        public Category Category { get; set; }
        public Point Geometry { get; set; }

        public Feature(string name, Category category, Point geometry)
        {
            Name = name;
            Category = category;
            Geometry = geometry;
        }

        public Feature() { }

        public void Editar(string name, Category category, Point geometry)
        {
            Name = name;
            Category = category;
            Geometry = geometry;

            UpdateLog();
        }

        public class GeoJsonPoint
        {
            public string Type { get; set; } = "Point";
            public double[] Coordinates { get; set; }
        }
    }
}