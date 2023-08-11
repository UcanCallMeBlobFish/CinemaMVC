using Cinema.IRepository;
using Cinema.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ActorController : Controller
    {
        private readonly IActorRepository _actorRepository;
        public ActorController(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository; 
            
        }
        [AllowAnonymous]

        public IActionResult Index()
        {
            var actors = _actorRepository.GetActors();
            return View(actors);
        }
        [AllowAnonymous]

        public IActionResult Details(int id)
        {
            var actor = _actorRepository.GetActorDetails(id);

            return View(actor);
        }
        [HttpGet]
        public IActionResult EditDetails(int id) 
        {
            var actor = _actorRepository.GetActorDetails(id);
            return View(actor);
        }


        [HttpPost]
        public IActionResult EditDetails(Actor updatedActor)
        {
            _actorRepository.UpdateActor(updatedActor);
            return RedirectToRoute( new { controller = "actor", action = "details", id = updatedActor.ActorId });
        }

        [HttpGet]
        [Route("/actor/Delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            _actorRepository.RemoveActor(id);

            return Content("Item is removed ");
        }

    }
}
