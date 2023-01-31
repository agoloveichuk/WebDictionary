namespace Infrastructure.Data.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Delete(object id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        TEntity? GetById(object id);
        void Update(TEntity entityToUpdate);
    }
}