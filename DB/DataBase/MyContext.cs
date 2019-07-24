using Core;
using Microsoft.EntityFrameworkCore;
using System;

namespace DB
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<Post> Posts { get; set; }
    }
}
