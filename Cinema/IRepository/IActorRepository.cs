using Cinema.Models;

namespace Cinema.IRepository
{
    public interface IActorRepository
    {
        void AddActor(Actor actor);
        Actor EditActorInformation(Actor actor);
        Actor GetActorDetails(int id);
        List<Actor> GetActors();
        void RemoveActor(int id);
        void UpdateActor(Actor updatedActor);
    }
}