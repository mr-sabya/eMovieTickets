using eTickets.Data;
using eTickets.Data.Services.ActorService;
using eTickets.Data.Services.CinemaService;
using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class CinemasController : Controller
    {
        private readonly ICinemasService _service;


        public CinemasController(ICinemasService service)
        {
            _service = service;
        }


        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var cinemas = await _service.GetAllAsync();
            return View(cinemas);
        }

        //Get: Cinemas/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name, Logo, Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
                //return BadRequest(ModelState);
            }


            await _service.AddAsync(cinema);
            return RedirectToAction(nameof(Index));
        }


        [AllowAnonymous]
        //Get: Cinemas/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var details = await _service.GetByIdAsync(id);

            if (details == null)
            {
                return View("NotFound");
            }
            return View(details);
        }


        //Get: Cinemas/Edit/id
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
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name, Logo, Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
                //return BadRequest(ModelState);
            }

            await _service.UpdateAsync(id, cinema);
            return RedirectToAction(nameof(Index));
        }


        //Get: Cinemas/Delete/id
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
