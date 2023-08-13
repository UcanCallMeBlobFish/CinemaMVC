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
        private readonly IUnitOfWork _unitOfWork;




        public HomeController(IUnitOfWork unitOfWork,IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
           
            _unitOfWork = unitOfWork;

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
        public async Task<IActionResult> Create()
        {
            ViewBag.CinemaSections = await _unitOfWork.Cinemas.GetAllAsync();
            ViewBag.Categories = await  _unitOfWork.Categories.GetAllAsync();
            ViewBag.Producers = await _unitOfWork.Producers.GetAllAsync();

            return View();
        }

        [HttpPost]
        public async Task< IActionResult> Create(Movie newMovie)
        {
         
            await _unitOfWork.Movies.CreateAsync(newMovie);
            await _unitOfWork.SaveChangesAsync();

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