using Microsoft.EntityFrameworkCore;
using Reto1.API.Entities;
using Reto1.API.Interface;
using System.Linq.Expressions;

namespace Reto1.API.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _context;
        public GenericRepository(StoreContext context)
        {
            _context = context;
        }

        public IQueryable<T> DbSet()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            var result = _context.Set<T>().AsQueryable();

            foreach (var include in includes)
            {
                result = result.Include(include);
            }

            return await result
              .AsNoTracking()
              .ToListAsync();
        }

        public async Task<T> FindByIdExtendedAsync(int id, params Expression<Func<T, object>>[] includes)
        {
            var result = _context.Set<T>().AsQueryable();

            if (includes != null)
            {
                result = includes.Aggregate(result,
                    (current, include) => current.Include(include));
            }

            return await result.SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(item => item.Id == id);
        }

        public async Task Insert(T entity)
        {
            await _context.Set<T>().AddAsync(entity);

        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void DeleteById(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}
