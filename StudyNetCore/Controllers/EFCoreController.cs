using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB;
using DomainModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace StudyNetCore.Controllers
{
    public class EFCoreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public void Add()
        {
            using (var context = new MyContext())
            {
                var blog = new Blog {
                    Url = "http://sample.com",
                    Rating=98
                };
                context.Blogs.Add(blog);
                context.SaveChanges();
            }
        }
        public void Remove()
        {
            using (var context = new MyContext())
            {
                var blog = context.Blogs.Single(b => b.BlogId == 2);
                context.Blogs.Remove(blog);
                context.SaveChanges();
            }
        }
        public void Update()
        {
            using (var context = new MyContext())
            {
                var blog = context.Blogs.Single(b => b.BlogId == 1);
                blog.Url = "http://www.vae.com";
                context.SaveChanges();
            }
        }
        public void Select()
        {
            using (var context = new MyContext())
            {
                var blogs = context.Blogs.ToList();
                Console.WriteLine(blogs);
            }
        }
    }
}