using Cinema.IRepository;
using Cinema.Models;
using Cinema.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProducerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProducerController(IProducerRepository producerRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var producers = await _unitOfWork.Producers.GetAllAsync();
            return View(producers);
        }
        [AllowAnonymous]

        public async Task<IActionResult> Details(int id)
        {
            var producer = await _unitOfWork.Producers.GetByIdAsync(a => a.ProducerId == id);

            return View(producer);
        }

        [HttpGet]
        public async Task<IActionResult> EditDetails(int id)
        {
            var prod = await _unitOfWork.Producers.GetByIdAsync(a => a.ProducerId == id);
            return View(prod);
        }


        [HttpPost]
        public async Task<ActionResult> EditDetails(Producer updatedActor)
        {
            _unitOfWork.Producers.Update(updatedActor);
            await _unitOfWork.SaveChangesAsync();
            return RedirectToRoute(new { controller = "Producer", action = "details", id = updatedActor.ProducerId });
        }

        [HttpGet]
        [Route("/producer/Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var prod = await _unitOfWork.Producers.GetByIdAsync(a=> a.ProducerId == id);
            _unitOfWork.Producers.Delete(prod);
             await _unitOfWork.SaveChangesAsync();

            return Content("Item is removed ");
        }

    }
}
