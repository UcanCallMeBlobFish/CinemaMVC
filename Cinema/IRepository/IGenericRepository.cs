using Cinema.Data;
using System.Linq.Expressions;

namespace Cinema.IRepository
{
    public interface IGenericRepository<T> where T : class
    {

        Task CreateAsync(T obj);
        Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetByIdAsync(Expression<Func<T, bool>> id, params Expression<Func<T, object>>[] includeProperties);
        void Update(T obj);
        void Delete(T obj);


    }
}