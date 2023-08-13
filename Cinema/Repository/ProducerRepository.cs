using Cinema.Data;
using Cinema.IRepository;
using Cinema.Models;

namespace Cinema.Repository
{
    public class ProducerRepository : GenericRepository<Producer> , IProducerRepository
    {
        private readonly AppDbContext _context;

        public ProducerRepository(AppDbContext context):base(context) 
        {
            _context = context;
        }

       
       
    }
}
