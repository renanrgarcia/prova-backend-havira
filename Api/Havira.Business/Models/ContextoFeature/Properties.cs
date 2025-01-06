using Havira.Business.Models.ContextoFeature.Enums;

namespace Havira.Business.Models.ContextoFeature
{
    public class Properties : Entity
    {
        public Guid FeatureId { get; set; }
        public string Nome { get; set; }
        public Categoria Categoria { get; set; }
        public Feature feature { get; set; }

        public Properties(Feature feature, string nome, Categoria categoria)
        {
            FeatureId = feature.Id;
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