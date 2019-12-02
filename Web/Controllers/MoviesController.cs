using AutoMapper;
using DomainModels;
using IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using ViewModels;

namespace Web.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMovieService _movieService;

        public MoviesController(
            IMovieService movieService,
            IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        // GET: Movies
        public ActionResult Index()
        {
            var models = _movieService.Query();
            return View(models);
        }

        // GET: Movies/Details/5
        public ActionResult Details(int id)
        {
            var model = _movieService.QueryByID(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        public ActionResult AddItem(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            Task<int> result = _movieService.Add(movie);
            return RedirectToAction("Index", "Movies");
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int id)
        {
            var movie = _movieService.QueryByID(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, IFormCollection collection)
        {
            try
            {
                Movie movie = new Movie();
                TryUpdateModelAsync(movie);
                if (id != movie.ID)
                {
                    return NotFound();
                }
                _movieService.Update(movie);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int id)
        {
            var movie = _movieService.QueryByID(id);
            if (movie != null)
            {
                _movieService.DeleteById(movie.Id);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Test()
        {
            var movies = await _movieService.Query();
            if (movies?.Count() > 0)
            {
                foreach (var movie in movies)
                {
                    var movievm = _mapper.Map<MovieViewModel>(movie);
                    System.Console.WriteLine("不错哦");
                }
            }
            return View();
        }
    }
}