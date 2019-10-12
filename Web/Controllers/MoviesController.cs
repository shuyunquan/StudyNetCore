using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB;
using DomainModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MyContext _context;
        public MoviesController(MyContext context)
        {
            _context = context;
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

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult AddItem(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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
            return View();
        }

        // POST: Movies/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Test()
        {
            return View(_context.Movie.ToList());
        }


    }
}