using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Infrastructure.Data.Entities;

namespace Infrastructure.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal WebDictionaryContext context;
        internal DbSet<TEntity> dbSet;
        public GenericRepository(WebDictionaryContext context)
            => (this.context, dbSet) = (context, context.Set<TEntity>());

        public virtual void Create(TEntity entity)
        {
            dbSet.Add(entity);
            //DbSet<AppUser>.Dictionaries.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity? entityToDelete = dbSet.Find(id);
            if (entityToDelete != null)
            {
                dbSet.Remove(entityToDelete);
            }
            context.SaveChanges();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public virtual TEntity? GetById(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
