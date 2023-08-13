using Cinema.Data;
using Cinema.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Cinema.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(T obj)
        {
            await _context.Set<T>().AddAsync(obj);
        }
        public async Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> list = _context.Set<T>();
           
            foreach (var property in includeProperties)
            {
                list = list.Include(property);
            }

            return await list.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> id, params Expression<Func<T, object>>[] includeProperties)
        {

            IQueryable<T> list = _context.Set<T>();

            foreach (var property in includeProperties)
            {
                list = list.Include(property);
            }

            return await list.AsNoTracking().FirstOrDefaultAsync(id);
        }

        public void Update(T obj)
        {
            _context.Update(obj);
        }
        public void Delete(T obj)
        {
            _context.Remove(obj);
        }
    }

  
}
