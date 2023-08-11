using Cinema.Data;
using Cinema.IRepository;
using Cinema.Models;

namespace Cinema.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Category> GetAllCategory()
        {
            return _context.Categories.OrderBy(a => a.CategoryId).ToList();
        }
    }
}
