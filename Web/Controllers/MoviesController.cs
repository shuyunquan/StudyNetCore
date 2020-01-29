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
using StackExchange.Redis;
using Microsoft.EntityFrameworkCore.Internal;

namespace Web.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly HtmlEncoder _htmlEncoder;
        private readonly IMemoryCache _memoryCache;
        private readonly IMovieService _movieService;
        private readonly IDatabase _db;

        public MoviesController(
            IMovieService movieService,
            IMapper mapper,
            HtmlEncoder htmlEncoder,
            IMemoryCache memoryCache,
            IConnectionMultiplexer redis)
        {
            _movieService = movieService;
            _mapper = mapper;
            _htmlEncoder = htmlEncoder;
            _memoryCache = memoryCache;
            _db = redis.GetDatabase();
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
            List<MovieViewModel> movieViewModels = _mapper.Map<List<MovieViewModel>>(cacheMovieList);
            //从Redis取出所有的浏览值
            RedisKey[] redisKeys = movieViewModels.Select(x => (RedisKey)$"movie:{x.ID}:views").ToArray();
            var viewCounts = await _db.StringGetAsync(redisKeys);
            //浏览器赋值给MovieViewModel
            foreach (var movieViewModel in movieViewModels)
            {
                var id = movieViewModel.ID;
                var key = (RedisKey)$"movie:{movieViewModel.ID}:views";
                var index = redisKeys.IndexOf(key);
                if (index > -1)
                {
                    movieViewModel.ViewCount = viewCounts[index];
                }
            }
            //上面我写的是,先取出所有的Redis里面的计数缓存值,然后再遍历赋值,为什么我不直接通过Redis的值每一个ViewModel都取一次呢?
            //可能一次获取Redis,多次计算,比每一个都获取Redis好一点吧
            return View(movieViewModels);
        }

        // GET: Movies/Details/5
        public ActionResult Details(int id)
        {
            var model = _movieService.QueryByID(id);
            if (model == null)
            {
                return NotFound();
            }
            //现在加入Redis计数器功能
            //首先,Redis缓存需要一个key,这里做法是当前的控制器Movies加上ID,加上Views,然后冒号分隔
            var key = $"movie:{id}:views";
            _db.StringIncrement(key);
            var viewCount = _db.StringGet(key);
            ViewBag.viewCount = viewCount;
            return View(model.Result);
        }

        [HttpPost]
        public ActionResult AddItem(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            //防止XSS攻击
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