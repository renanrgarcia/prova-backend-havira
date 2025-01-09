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
        public Point Point { get; set; }

        public Feature(string name, Category category, Point point)
        {
            Name = name;
            Category = category;
            Point = point;
        }

        public Feature() { }

        public void Editar(string name, Category category, Point point)
        {
            Name = name;
            Category = category;
            Point = point;

            Atualizacao();
        }

        public class GeoJsonPoint
        {
            public string Type { get; set; }
            public double[] Coordinates { get; set; }
        }
    }
}