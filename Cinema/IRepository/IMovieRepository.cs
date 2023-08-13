using Cinema.Models;

namespace Cinema.IRepository
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
        Movie AddMovie(Movie movie);
        Movie EditMovieDetails(Movie newone);
        List<Movie> GetAllMovies();
        Movie GetMovieById(int id);
    }
}