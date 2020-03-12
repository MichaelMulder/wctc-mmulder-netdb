using System;
using System.Data.Entity;
using ConsoleBlog.Model;

namespace ConsoleBlog.Context {
    public class BloggingContext : DbContext {

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; } 

    }
}
