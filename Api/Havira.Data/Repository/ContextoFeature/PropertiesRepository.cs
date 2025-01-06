using Havira.Business.Interfaces.ContextoProperties;
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