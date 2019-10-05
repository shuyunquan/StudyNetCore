using DomainModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace DB
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
          : base(options)
        {
        }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<TodoItem> TodoItem { get; set; }
    }
}
