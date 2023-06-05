using eTickets.Data;
using eTickets.Data.Services.ActorService;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;


        public ActorsController(IActorsService service) 
        {
            _service = service;
        }


        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get: Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName, ProfilePictureUrl, Bio")] Actor actor)
        {
            if(!ModelState.IsValid)
            {
                return View(actor);
                //return BadRequest(ModelState);
            }


            await _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }


        //Get: Actors/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var details = await _service.GetByIdAsync(id);

            if(details == null)
            {
                return View("NotFound");
            }
            return View(details);
        }


        //Get: Actors/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var details = await _service.GetByIdAsync(id);

            if (details == null)
            {
                return View("NotFound");
            }
            return View(details);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, FullName, ProfilePictureUrl, Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
                //return BadRequest(ModelState);
            }

            await _service.UpdateAsync(id, actor);
            return RedirectToAction(nameof(Index));
        }


        //Get: Actors/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var details = await _service.GetByIdAsync(id);

            if (details == null)
            {
                return View("NotFound");
            }
            return View(details);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var details = await _service.GetByIdAsync(id);

            if (details == null)
            {
                return View("NotFound");
            }

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
