using Cinema.Data;
using Cinema.IRepository;
using Cinema.Models;

namespace Cinema.Repository
{
    public class CinemaRepository : ICinemaRepository
    {
        private readonly AppDbContext _context;
        public CinemaRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<CinemaSection> GetAllCinemas()
        {
            return _context.CinemaSections.OrderBy(a => a.CinemaSectionId).ToList();
        }

    }
}
