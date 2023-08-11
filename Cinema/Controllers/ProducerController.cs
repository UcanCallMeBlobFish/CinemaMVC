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
        private readonly IProducerRepository _producerRepository;
        public ProducerController(IProducerRepository producerRepository)
        {
            _producerRepository = producerRepository;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var actors = _producerRepository.GetAllProducers();
            return View(actors);
        }
        [AllowAnonymous]

        public IActionResult Details(int id)
        {
            var actor = _producerRepository.GetProducerDetails(id);

            return View(actor);
        }
        [HttpGet]
        public IActionResult EditDetails(int id)
        {
            var actor = _producerRepository.GetProducerDetails(id);
            return View(actor);
        }


        [HttpPost]
        public IActionResult EditDetails(Producer updatedActor)
        {
            _producerRepository.UpdateProducer(updatedActor);
            return RedirectToRoute(new { controller = "Producer", action = "details", id = updatedActor.ProducerId });
        }

        [HttpGet]
        [Route("/producer/Delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            _producerRepository.RemoveProducer(id);

            return Content("Item is removed ");
        }

    }
}
