using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DomainModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SqlSugar;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Text = "我是漯河猪🐖🐽🐷";
            ViewBag.Number = 4;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
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
                                                                                                           //多表查询用法 http://www.codeisbug.com/Doc/8/1124

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
