using DomainModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace DB
{
    public class MyContext:DbContext
    {
        //public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=EFCore;Trusted_Connection=True;");
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

    }
}
