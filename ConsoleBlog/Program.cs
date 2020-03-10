using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using System.Data.Entity;

namespace ConsoleBlog {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Enter a blog name: ");
            var name = Console.ReadLine();

            var blog = new Blog() { Name = name };

            // persist the blog

            using (var db = new BloggingContext()) {
                db.Blogs.Add(blog);
                db.SaveChanges();
            } 

            using(var db = new BloggingContext()) {
                var query = db.Blogs; 

                var blogList = query.ToList();
                foreach(var item in blogList) {
                    Console.WriteLine($"Blog: {item.Name}");
                }
            }
        } 
    }

    class BloggingContext : DbContext {

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

    }
}
