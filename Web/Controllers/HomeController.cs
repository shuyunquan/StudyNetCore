﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DomainModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using SqlSugar;
using StackExchange.Redis;
using Web.Data;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMemoryCache _cache;
        private readonly IDatabase _db;

        public HomeController(ILogger<HomeController> logger, IMemoryCache cache,
            IConnectionMultiplexer redis)
        {
            _logger = logger;
            _cache = cache;
            _db = redis.GetDatabase();
        }

        public IActionResult Index()
        {
            _logger.LogInformation("正在访问首页 {0},{1}",1,2);
            ViewBag.Text = "我是漯河猪🐖🐽🐷";
            ViewBag.Number = 4;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("about-us")]
        [Authorize]
        public IActionResult AboutUs()
        {
            return View();
        }

        [Route("about-vae")]
        public IActionResult AboutVae()
        {
            _logger.LogWarning("这是一个严重的警告日志,错误变量{0},{1}",555,666);
            return View();
        }

        public string TestMemoryCache()
        {
            //首先判断缓存中是否有数据了
            if (!_cache.TryGetValue(CacheEntryConstants.TestMemoryCache,out string cacheTestMemoryCache))
            {
                //如果缓存中没有,则赋值,且加入缓存
                cacheTestMemoryCache = "测试缓存";
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    //.SetAbsoluteExpiration(TimeSpan.FromSeconds(600))强制600s之后缓存失效
                    .SetSlidingExpiration(TimeSpan.FromSeconds(30));//动态设定缓存,访问就+30s,没人访问就30s之后缓存失效
                //新设置缓存,key,值,参数
                _cache.Set(CacheEntryConstants.TestMemoryCache, cacheTestMemoryCache, cacheEntryOptions);
            }
            return cacheTestMemoryCache;
        }

        public string TestRedis()
        {
            _db.StringSet("name", "Vae");
            var name = _db.StringGet("name");
            return name;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public void SqlSugarTest()
        {
            SqlSugarClient db = new SqlSugarClient(
            new ConnectionConfig()
            {
                ConnectionString = "server=.;uid=sa;pwd=test123;database=VaeDB",
                DbType = DbType.SqlServer,//设置数据库类型
                IsAutoCloseConnection = true,//自动释放数据务，如果存在事务，在事务结束后释放
                //InitKeyType = InitKeyType.Attribute //从实体特性中读取主键自增列信息
            });

            //用来打印Sql方便你调式    
            db.Aop.OnLogExecuting = (sql, pars) =>
            {
                Console.WriteLine(sql + "\r\n" +
                db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                Console.WriteLine();
            };

            /*查询*/
            var list = db.Queryable<Movie>().ToList();//查询所有
            var getByWhere = db.Queryable<Movie>().Where(it => it.ID == 1).ToList();//根据条件查询
            var total = 0;
            var getPage = db.Queryable<Movie>().Where(it => it.ID == 1).ToPageList(1, 2, ref total);//根据分页查询

            /*插入*/
            var data = new Movie() { Title = "诸葛亮",ReleaseDate= DateTime.Parse("2019-09-09"),Genre="丞相" };
            db.Insertable(data).ExecuteReturnIdentity();
            //更多插入用法 http://www.codeisbug.com/Doc/8/1130

            /*更新*/
            var data2 = new Movie() { ID = 1, Genre = "音乐家" };
            db.Updateable(data2).ExecuteCommand();
            //更多更新用法 http://www.codeisbug.com/Doc/8/1129

            /*删除*/
            db.Deleteable<Movie>(3).ExecuteCommand();
            //更多删除用法 http://www.codeisbug.com/Doc/8/1128
        }

    }
}
