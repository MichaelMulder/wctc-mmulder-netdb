using System;

namespace ConsoleBlog {
    class BloggingContext : DbContext {

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

    }
}
