
using System.Linq.Expressions;

namespace Infrastructure.Persistence.Repositories
{
    public interface IGenericRepository
    {
        Task<TEntity> GetById<TEntity>(int id) where TEntity : class;
        Task<TEntity> FirstOrDefault<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;

        Task Add<TEntity>(TEntity entity) where TEntity : class;
        Task Update<TEntity>(TEntity entity);
        Task Remove<TEntity>(TEntity entity);

        Task<IEnumerable<TEntity>> GetAll<TEntity>() where TEntity : class;
        Task<IEnumerable<TEntity>> GetWhere<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;

        Task<int> CountAll<TEntity>() where TEntity : class;
        Task<int> CountWhere<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
    }
}
