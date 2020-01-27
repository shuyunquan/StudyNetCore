using AutoMapper;
using DomainModels;
using IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using ViewModels;
using System.Text.Encodings.Web;
using Microsoft.Extensions.Caching.Memory;
using Web.Data;
using System.Collections.Generic;
using System;

namespace Web.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly HtmlEncoder _htmlEncoder;
        private readonly IMemoryCache _memoryCache;
        private readonly IMovieService _movieService;

        public MoviesController(
            IMovieService movieService,
            IMapper mapper,
            HtmlEncoder htmlEncoder,
            IMemoryCache memoryCache)
        {
            _movieService = movieService;
            _mapper = mapper;
            _htmlEncoder = htmlEncoder;
            _memoryCache = memoryCache;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            if (!_memoryCache.TryGetValue(CacheEntryConstants.MovieList,out List<Movie> cacheMovieList))
            {
                cacheMovieList = await _movieService.Query();
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                   //.SetAbsoluteExpiration(TimeSpan.FromSeconds(600))强制600s之后缓存失效
                   .SetSlidingExpiration(TimeSpan.FromSeconds(30));//动态设定缓存,访问就+30s,没人访问就30s之后缓存失效
                //新设置缓存,key,值,参数
                _memoryCache.Set(CacheEntryConstants.MovieList, cacheMovieList, cacheEntryOptions);
            }
            return View(cacheMovieList);
        }

        // GET: Movies/Details/5
        public ActionResult Details(int id)
        {
            var model = _movieService.QueryByID(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model.Result);
        }

        [HttpPost]
        public ActionResult AddItem(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            movie.Title = _htmlEncoder.Encode(movie.Title);
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
            return View(movie.Result);
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
                _movieService.DeleteById(movie.Result.ID);
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