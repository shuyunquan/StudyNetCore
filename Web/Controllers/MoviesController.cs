using System.Linq;
using AutoMapper;
using DB;
using DomainModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

namespace Web.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        private readonly MyContext _context;
        private readonly IMapper _mapper;


        public MoviesController(
            MyContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Movies
        public ActionResult Index()
        {
            var models = _context.Movie.ToList();
            return View(models);
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = _context.Movie.FirstOrDefault(m => m.ID == id);
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
            _context.Movie.Add(movie);
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var movie = _context.Movie.Find(id);
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
                _context.Movie.Update(movie);
                _context.SaveChanges();

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
            Movie movie = _context.Movie.Find(id);
            if (movie != null)
            {
                _context.Movie.Remove(movie);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        public IActionResult Test()
        {
            var movies = _context.Movie.ToList();
            if (movies?.Count() > 0)
            {
                foreach (var movie in movies)
                {
                    MovieViewModel movievm = _mapper.Map<MovieViewModel>(movie);
                    System.Console.WriteLine("不错哦");
                }
            }

            return View();
        }


    }
}