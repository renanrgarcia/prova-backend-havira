using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Havira.Business.Models.ContextoLocalizacao.Enums;
using NetTopologySuite.Geometries;

namespace Havira.Business.Models.ContextoLocalizacao
{
    [Table(name: "localizacao", Schema = "dbo")]
    public class Localizacao : Entity
    {
        public string Nome { get; set; }
        public Categoria Categoria { get; set; }
        [Column(TypeName = "geography(Point,4326)")]
        public Point Coordenadas { get; set; } = new Point(0.0, 0.0) { SRID = 4326 };
        public bool Status { get; set; }

        public Localizacao(string nome, Categoria categoria, Point coordenadas)
        {
            Nome = nome;
            Categoria = categoria;
            Coordenadas = coordenadas;
            Status = true;
        }

        public Localizacao() { }

        public void Editar(string nome, Categoria categoria, Point coordenadas)
        {
            Nome = nome.Trim();
            Categoria = categoria;
            Coordenadas = coordenadas;

            Atualizacao();
        }

        public void Desativar()
        {
            Status = false;
            Atualizacao();
        }
    }
}