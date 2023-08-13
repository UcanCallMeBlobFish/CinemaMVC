using Cinema.Data;
using Cinema.IRepository;
using Cinema.Models;

namespace Cinema.Repository
{
    public class ActorRepository :GenericRepository<Actor>, IActorRepository
    {
        private readonly AppDbContext _context;
        public ActorRepository(AppDbContext context):base(context) 
        {
            _context = context;

        }

       
    }
}
