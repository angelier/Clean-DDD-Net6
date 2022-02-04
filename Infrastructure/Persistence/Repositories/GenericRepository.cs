using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence.Contexts;
using System.Linq.Expressions;

namespace Infrastructure.Persistence.Repositories
{
    public class GenericRepository : IGenericRepository
    {
        protected readonly Context _context;

        public GenericRepository(Context context)
        {
            _context = context;
        }

        public async Task<TEntity> GetById<TEntity>(int id) where TEntity : class => await _context.Set<TEntity>().FindAsync(id) ?? throw new KeyNotFoundException("Entity not found");

        public async Task<TEntity> FirstOrDefault<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class => await _context.Set<TEntity>().FirstOrDefaultAsync(predicate) ?? throw new KeyNotFoundException("Entity not found");

        public async Task Add<TEntity>(TEntity entity) where TEntity : class
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public Task Update<TEntity>(TEntity entity)
        {
            if (entity != null)
                _context.Entry(entity).State = EntityState.Modified;

            return _context.SaveChangesAsync();
        }

        public Task Remove<TEntity>(TEntity entity)
        {
            if (entity != null)
                _context.Remove(entity);
            return _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll<TEntity>() where TEntity : class
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetWhere<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return await _context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public Task<int> CountAll<TEntity>() where TEntity : class => _context.Set<TEntity>().CountAsync();

        public Task<int> CountWhere<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return _context.Set<TEntity>().CountAsync();
        }
    }
}
