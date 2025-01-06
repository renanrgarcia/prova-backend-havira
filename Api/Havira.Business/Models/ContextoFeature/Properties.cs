using Havira.Business.Models.ContextoFeature.Enums;

namespace Havira.Business.Models.ContextoFeature
{
    public class Properties : Entity
    {
        public string Nome { get; set; }
        public Categoria Categoria { get; set; }

        public Properties(string nome, Categoria categoria)
        {
            Nome = nome;
            Categoria = categoria;
        }

        public Properties() { }

        public void Editar(string nome, Categoria categoria)
        {
            Nome = nome;
            Categoria = categoria;

            Atualizacao();
        }
    }
}