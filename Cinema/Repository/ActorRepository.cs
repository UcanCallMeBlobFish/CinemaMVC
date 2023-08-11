using Cinema.Data;
using Cinema.IRepository;
using Cinema.Models;

namespace Cinema.Repository
{
    public class ActorRepository : IActorRepository
    {
        private readonly AppDbContext _context;
        public ActorRepository(AppDbContext context)
        {
            _context = context;

        }

        public List<Actor> GetActors()
        {
            var actors = _context.Actors.OrderBy(a => a.ActorId).ToList();
            return actors;
        }
        public Actor GetActorDetails(int id)
        {
            var actor = _context.Actors.Where(actor => actor.ActorId == id).FirstOrDefault();
            return actor;
        }

        public Actor EditActorInformation(Actor actor)
        {
            var dbactor = _context.Actors.Where(a => a.ActorId == actor.ActorId).FirstOrDefault();

            dbactor.Name = actor.Name;
            dbactor.Description = actor.Description;
            dbactor.LastName = actor.LastName;
            dbactor.Imgurl = actor.Imgurl;

            return dbactor;
        }

        public void AddActor(Actor actor)
        {
            _context.Actors.Add(actor);
            _context.SaveChanges();
        }

        public void RemoveActor(int id)
        {
            var remove = _context.Actors.Where(a => a.ActorId == id).FirstOrDefault();
            _context.Remove(remove);
            _context.SaveChanges();
        }



        public void UpdateActor(Actor updatedActor)
        {
            var existingActor = _context.Actors.Where(a => a.ActorId == updatedActor.ActorId).FirstOrDefault();
           
                existingActor.Name = updatedActor.Name;
                existingActor.Description = updatedActor.Description;
                existingActor.LastName = updatedActor.LastName;
                existingActor.Imgurl = updatedActor.Imgurl;

                _context.SaveChanges();
           
            
        }
    }
}
