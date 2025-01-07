using System.ComponentModel.DataAnnotations.Schema;
using Havira.Business.Helpers;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;

namespace Havira.Business.Models.ContextoFeature
{
    [Table(name: "feature", Schema = "dbo")]
    public class Feature : Entity
    {
        public string Type { get; set; } = "Feature";
        public Geometry Geometry { get; set; }
        public Properties Properties { get; set; }
        public bool Status { get; set; }

        public Feature(string type, Geometry geometry)
        {
            Type = type;
            Geometry = geometry;
            Status = true;
        }

        public Feature() { }

        public void Editar(string type, Geometry geometry, Properties properties)
        {
            Type = type;
            Geometry = new GeometryFactory().CreateGeometry(Point.Empty);
            Properties = properties;

            Atualizacao();
        }

        public void Desativar()
        {
            Status = false;
            Atualizacao();
        }

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
}