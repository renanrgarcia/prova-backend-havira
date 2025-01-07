using Havira.Business.Interfaces.ContextoFeature;
using Havira.Business.Models.ContextoFeature;
using Havira.Business.Models.ContextoFeature.Enums;
using Havira.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Havira.Data.Repository.ContextoFeature
{
    public class PropertiesRepository : Repository<Properties>, IPropertiesRepository
    {
        public PropertiesRepository(MeuDbContext db) : base(db)
        {
        }

        public async Task<Properties> ObterPropertiesPorNome(string nome)
        {
            var properties = await DbSet
                            .AsNoTracking()
                            .FirstOrDefaultAsync(x => x.Nome.ToLower().Trim().Equals(nome.ToLower().Trim()));

            return properties;
        }

        public async Task<List<Categoria>> ObterCategorias()
        {
            var categorias = await DbSet
                            .Select(x => x.Categoria)
                            .Distinct()
                            .ToListAsync();

            return categorias;
        }
    }
}