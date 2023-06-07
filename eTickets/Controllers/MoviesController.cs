using eTickets.Data;
using eTickets.Data.Services.MoviesService;
using eTickets.Data.Services.ProducerService;
using Microsoft.AspNetCore.Mvc;
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


        //Get: Movies/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var details = await _service.GetMovieByIdAsync(id);
            return View(details);
        }
    }
}
