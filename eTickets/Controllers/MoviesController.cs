using eTickets.Data;
using eTickets.Data.Services.MoviesService;
using eTickets.Data.Services.ProducerService;
using eTickets.Models;
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

        public async Task<IActionResult> Filter(string searchString)
        {
            var movies = await _service.GetAllAsync(n => n.Cinema, n => n.Category);

            if(!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = movies.Where(n => n.Name.Contains(searchString) || n.Description.Contains(searchString)).ToList();
                return View("Index", filteredResult);
            }

            return View("Index", movies);
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


        [HttpPost]
        public async Task<IActionResult> Create(MovieViewModel movie)
        {
            if(!ModelState.IsValid)
            {
                var movieDropdownData = await _service.GetMovieDropDownValues();

                ViewBag.Cinemas = new SelectList(movieDropdownData.Cinemas, "Id", "Name");
                ViewBag.Categories = new SelectList(movieDropdownData.Categories, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownData.Actors, "Id", "FullName");

                return View(movie);
            }

            await _service.AddNewMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }


        //Get: Movies/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var details = await _service.GetMovieByIdAsync(id);

            if (details == null) return View("NotFound");


            return View(details);
        }


        //Get: Producers/Create
        public async Task<IActionResult> Edit(int id)
        {
            var details = await _service.GetMovieByIdAsync(id);

            if (details == null) return View("NotFound");

            var response = new MovieViewModel()
            {
                Id = details.Id,
                Name = details.Name,
                Description = details.Description,
                Price = details.Price,
                StartDate = details.StartDate,
                EndDate = details.EndDate,
                ImageURL = details.ImageURL,
                CategoryId = details.CategoryId,
                CinemaId = details.CinemaId,
                ProducerId = details.ProducerId,
                ActorIds = details.Actor_Movies.Select(n => n.ActorId).ToList(),

            };

            var movieDropdownData = await _service.GetMovieDropDownValues();

            ViewBag.Cinemas = new SelectList(movieDropdownData.Cinemas, "Id", "Name");
            ViewBag.Categories = new SelectList(movieDropdownData.Categories, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownData.Actors, "Id", "FullName");

            return View(response);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, MovieViewModel movie)
        {

            if (id != movie.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var movieDropdownData = await _service.GetMovieDropDownValues();

                ViewBag.Cinemas = new SelectList(movieDropdownData.Cinemas, "Id", "Name");
                ViewBag.Categories = new SelectList(movieDropdownData.Categories, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownData.Actors, "Id", "FullName");

                return View(movie);
            }

            await _service.UpdateMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }
    }
}
