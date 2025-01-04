using System.ComponentModel.DataAnnotations.Schema;
using Havira.Business.Models.ContextoLocalizacao.Enums;
using Havira.Business.Models.ContextoTrabalho;

namespace Havira.Business.Models.ContextoLocalizacao
{
    [Table(name: TableConsts.Localizacao, Schema = SchemaConsts.LOCALIZACAO)]
    public class Localizacao : Entity
    {
        public string Nome { get; set; }
        public Categoria Categoria { get; set; }
        public Point Localizacao { get; set; }
        public bool Status { get; set; }

        public Localizacao(string nome, Categoria categoria, Point localizacao)
        {
            Nome = nome;
            Categoria = categoria;
            Localizacao = localizacao;
            Status = true;
        }

        public Localizacao() { }

        public void Editar(string nome, Categoria categoria, Point localizacao, bool status)
        {
            Nome = nome.Trim();
            Categoria = categoria;
            Localizacao = localizacao;
            Status = status;

            Atualizacao();
        }
    }
}