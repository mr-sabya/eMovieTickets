using eTickets.Data.Services.CategoryService;
using eTickets.Data.Services.CinemaService;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService _service;


        public CategoriesController(ICategoriesService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _service.GetAllAsync();
            return View(categories);
        }

        //Get: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name")] Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
                //return BadRequest(ModelState);
            }


            await _service.AddAsync(category);
            return RedirectToAction(nameof(Index));
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
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name")] Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
                //return BadRequest(ModelState);
            }

            await _service.UpdateAsync(id, category);
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
