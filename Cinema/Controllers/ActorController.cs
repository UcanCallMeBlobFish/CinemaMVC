using Cinema.IRepository;
using Cinema.Models;
using Cinema.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ActorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ActorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var actors = await _unitOfWork.Actors.GetAllAsync();
            return View(actors);
        }



        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var actor = await _unitOfWork.Actors.GetByIdAsync(a => a.ActorId == id);

            return View(actor);
        }

        [HttpGet]
        public async  Task<IActionResult> EditDetails(int id) 
        {
            var actor = await _unitOfWork.Actors.GetByIdAsync(a => a.ActorId == id);
            await  _unitOfWork.SaveChangesAsync();

            return View(actor);
        }


        [HttpPost]
        public async Task<IActionResult> EditDetails(Actor updatedActor)
        {
            _unitOfWork.Actors.Update(updatedActor);
            await _unitOfWork.SaveChangesAsync();
            return RedirectToRoute( new { controller = "actor", action = "details", id = updatedActor.ActorId });
        }

        [HttpGet]
        [Route("/actor/Delete/{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var obj = await _unitOfWork.Actors.GetByIdAsync(a => a.ActorId == id);
            _unitOfWork.Actors.Delete(obj);
            await _unitOfWork.SaveChangesAsync();
            return Content("Item is removed ");
        }

    }
}
