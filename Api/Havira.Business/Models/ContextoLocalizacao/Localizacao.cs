using System.ComponentModel.DataAnnotations.Schema;
using Havira.Business.Models.ContextoLocalizacao.Enums;
using NetTopologySuite.Geometries;

namespace Havira.Business.Models.ContextoLocalizacao
{
    [Table(name: TableConsts.Localizacao, Schema = SchemaConsts.LOCALIZACAO)]
    public class Localizacao : Entity
    {
        public string Nome { get; set; }
        public Categoria Categoria { get; set; }
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