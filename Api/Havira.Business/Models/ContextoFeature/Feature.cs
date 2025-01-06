using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Havira.Business.Models.ContextoFeature
{
    [Table(name: "feature", Schema = "dbo")]
    public class Feature : Entity
    {
        public string Type { get; set; } = "Feature";
        public Geometry Geometry { get; set; }
        public Properties Properties { get; set; }
        public bool Status { get; set; }

        public Feature(string type, Geometry geometry, Properties properties, bool status)
        {
            Type = type;
            Geometry = geometry;
            Properties = properties;
            Status = status;
        }

        public Feature() { }

        public void Editar(string type, Geometry geometry, Properties properties)
        {
            Type = type;
            Geometry = geometry;
            Properties = properties;

            Atualizacao();
        }

        public void Desativar()
        {
            Status = false;
            Atualizacao();
        }
    }
}