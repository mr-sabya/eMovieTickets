using eTickets.Data;
using eTickets.Data.Services.MoviesService;
using eTickets.Data.Services.ProducerService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;


        public MoviesController(IMoviesService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var movies = await _service.GetAllAsync(n => n.Cinema, n => n.Category);
            return View(movies);
        }


        //Get: Producers/Create
        public async Task<IActionResult> Create()
        {
            var movieDropdownData = await _service.GetMovieDropDownValues();

            ViewBag.Cinemas = new SelectList(movieDropdownData.Cinemas, "Id", "Name");
            ViewBag.Categories = new SelectList(movieDropdownData.Categories, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownData.Actors, "Id", "FullName");

            return View();
        }


        //Get: Movies/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var details = await _service.GetMovieByIdAsync(id);
            return View(details);
        }
    }
}
