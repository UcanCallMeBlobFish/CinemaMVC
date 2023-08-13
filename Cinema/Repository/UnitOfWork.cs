using Cinema.Data;
using Cinema.IRepository;
using Cinema.Models;

namespace Cinema.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        private IGenericRepository<Actor> _actors;
        private IGenericRepository<Category> _categories;
        private IGenericRepository<CinemaSection> _cinemas;
        private IGenericRepository<Movie> _Movies;
        private IGenericRepository<Producer> _producer;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }


        public IGenericRepository<Actor> Actors => _actors ??= new GenericRepository<Actor>(_context);
        public IGenericRepository<Category> Categories => _categories ??= new GenericRepository<Category>(_context);
        public IGenericRepository<CinemaSection> Cinemas => _cinemas ??= new GenericRepository<CinemaSection>(_context);
        public IGenericRepository<Movie> Movies => _Movies ??= new GenericRepository<Movie>(_context);
        public IGenericRepository<Producer> Producers => _producer ??= new GenericRepository<Producer>(_context);

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }



    }
}
