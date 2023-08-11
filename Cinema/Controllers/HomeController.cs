using Cinema.IRepository;
using Cinema.Models;
using Cinema.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace Cinema.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IActorRepository _actorRepository;
        private readonly ICinemaRepository _cinemaRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProducerRepository _producerRepository;




        public HomeController(ICategoryRepository categoryRepository,IMovieRepository movieRepository, IActorRepository actorRepository, ICinemaRepository cinemaRepository, IProducerRepository producerRepository)
        {
            _movieRepository = movieRepository;
            _actorRepository = actorRepository;
            _cinemaRepository = cinemaRepository;
            _producerRepository = producerRepository;
            _categoryRepository = categoryRepository;

        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var movieList = _movieRepository.GetAllMovies();
            return View(movieList);
        }

        [AllowAnonymous]

        public IActionResult Details(int id)
        {
            var movieDetails = _movieRepository.GetMovieById(id);
            return View(movieDetails);
        }

        
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.CinemaSections = _cinemaRepository.GetAllCinemas();

            ViewBag.Categories = _categoryRepository.GetAllCategory();
            ViewBag.Producers = _producerRepository.GetAllProducers();

            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateVM newMovie)
        {
         
            

            _movieRepository.AddMovie(newMovie);

            return View("index");

        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var movie = _movieRepository.GetMovieById(Id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {

            _movieRepository.EditMovieDetails(movie);
            return RedirectToRoute("default", new { controller = "home", action = "details", id = movie.MovieId });
        }

        [AllowAnonymous]

        [HttpGet]
        public IActionResult Filter(string movie)
        {
            if (!string.IsNullOrEmpty(movie))
            {
                var temp = _movieRepository.GetAllMovies();
                var filtered = temp.Where(a => a.Title == movie).ToList();
                if(filtered.Count ==0 ) filtered=temp.Where(a => a.Description == movie).ToList();
                if (filtered is not null) return View("index", filtered);
               
            }
            return View("index");
        }



        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}