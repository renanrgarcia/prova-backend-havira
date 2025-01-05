using System.Linq.Expressions;
using Havira.Business.Interfaces;
using Havira.Business.Models;
using Havira.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Havira.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly MeuDbContext Db;

        protected readonly DbSet<TEntity> DbSet;

        protected Repository(MeuDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<TEntity> Obter(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.FirstOrDefaultAsync(predicate);
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<bool> Existe(Guid id)
        {
            return await DbSet.AnyAsync(x => x.Id.Equals(id));
        }

        public virtual async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task AdicionarVarios(IEnumerable<TEntity> entity)
        {
            DbSet.AddRange(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
            entity.Atualizacao();
            await SaveChanges();
        }

        public virtual async Task AtualizarVarios(IEnumerable<TEntity> entity)
        {
            DbSet.UpdateRange(entity);
            await SaveChanges();
        }

        public virtual async Task Remover(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}