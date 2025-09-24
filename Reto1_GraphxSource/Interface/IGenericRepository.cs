using System.Linq.Expressions;

namespace Reto1.API.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> DbSet();
        Task<T> GetByIdAsync(int id);
        Task<T> FindByIdExtendedAsync(int id, params Expression<Func<T, object>>[] includes);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        Task Insert(T entity);
        void Update(T entity);
        void DeleteById(T entity);
        Task Save();

    }
}
