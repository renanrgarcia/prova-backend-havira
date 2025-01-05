using Havira.Business.Interfaces.ContextoLocalizacao;
using Havira.Business.Models.ContextoLocalizacao;
using Havira.Business.Models.ContextoLocalizacao.Enums;
using Havira.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Havira.Data.Repository.ContextoLocalizacao
{
    public class LocalizacaoRepository : Repository<Localizacao>, ILocalizacaoRepository
    {
        public LocalizacaoRepository(MeuDbContext db) : base(db)
        {
        }

        public async Task<Localizacao> ObterLocalizacaoPorNome(string nome)
        {
            var localizacao = await DbSet
                            .AsNoTracking()
                            .FirstOrDefaultAsync(x => x.Nome.ToLower().Trim().Equals(nome.ToLower().Trim()));

            return localizacao;
        }

        public async Task<List<Categoria>> ObterCategorias()
        {
            var categorias = await DbSet
                            .Select(x => x.Categoria)
                            .Distinct()
                            .ToListAsync();

            return categorias;
        }

        public Task<List<Localizacao>> ObterPorCategoria(Categoria categoria)
        {
            var localizacoes = DbSet
                            .AsNoTracking()
                            .Where(x => x.Categoria == categoria)
                            .ToListAsync();

            return localizacoes;
        }
    }
}