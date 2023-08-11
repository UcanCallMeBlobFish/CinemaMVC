using Cinema.Models;

namespace Cinema.IRepository
{
    public interface IMovieRepository
    {
        Movie AddMovie(Movie movie);
        Movie EditMovieDetails(Movie newone);
        List<Movie> GetAllMovies();
        Movie GetMovieById(int id);
    }
}