using eTickets.Data;
using eTickets.Data.Services.ActorService;
using eTickets.Data.Services.ProducerService;
using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ProducersController : Controller
    {
        private readonly IProducersService _service;


        public ProducersController(IProducersService service)
        {
            _service = service;
        }


        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var producers = await _service.GetAllAsync();
            return View(producers);
        }


        //Get: Producers/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName, ProfilePictureUrl, Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
                //return BadRequest(ModelState);
            }


            await _service.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }


        [AllowAnonymous]
        //Get: Producers/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var details = await _service.GetByIdAsync(id);

            if (details == null)
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
        public async Task<IActionResult> Edit(int id, [Bind("Id, FullName, ProfilePictureUrl, Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
                //return BadRequest(ModelState);
            }

            await _service.UpdateAsync(id, producer);
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
