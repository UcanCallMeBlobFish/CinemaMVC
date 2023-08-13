using Cinema.Data;
using Cinema.IRepository;
using Cinema.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Repository
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        private readonly AppDbContext _context;
        public MovieRepository(AppDbContext context):base(context)
        {
            _context = context;
        }

        public List<Movie> GetAllMovies()
        {
            var movies = _context.Movies
                .Include(a => a.Actors)
                .Include(b => b.Category)
                .Include(a => a.Cinema)
                .Include(b => b.CinemaMovies)
                .ThenInclude(ab => ab.CinemaSection)
                .Include(b => b.ActorsMovies)
                .ThenInclude(b => b.Actor)
                .OrderBy(a => a.MovieId)
                .ToList();
            return movies;
        }

        public Movie GetMovieById(int id)
        {
            var movie = _context.Movies
                .Include(m => m.Actors)
                .Include(m => m.Category)
                .Include(m => m.CinemaMovies)
                .ThenInclude(m => m.CinemaSection)
                .Include(m => m.Producer)
                .Include(m => m.ActorsMovies)
                .ThenInclude(am => am.Actor)
                .FirstOrDefault(m => m.MovieId == id);
            return movie;
        }

        public Movie AddMovie(Movie movie)  //admin function
        {
            _context.Add(movie);
            _context.SaveChanges();
            return movie;
        }

        public Movie EditMovieDetails(Movie newone)
        {
            var existingMovie = _context.Movies.Where(a => a.MovieId == newone.MovieId).FirstOrDefault();


            existingMovie.Title = newone.Title;
            existingMovie.Description = newone.Description;
            existingMovie.StartDate = newone.StartDate;
            existingMovie.EndDate = newone.EndDate;
            existingMovie.Status = newone.Status;
            existingMovie.CategoryId = newone.CategoryId;
            existingMovie.ProducerId = newone.ProducerId;

            _context.SaveChanges();
            return existingMovie;


        }





    }
}
