using Cinema.Models;

namespace Cinema.IRepository
{
    public interface IUnitOfWork
    {
        IGenericRepository<Actor> Actors { get; }
        IGenericRepository<Category> Categories { get; }
        IGenericRepository<CinemaSection> Cinemas { get; }
        IGenericRepository<Movie> Movies { get; }
        IGenericRepository<Producer> Producers { get; }

        Task SaveChangesAsync();
    }
}