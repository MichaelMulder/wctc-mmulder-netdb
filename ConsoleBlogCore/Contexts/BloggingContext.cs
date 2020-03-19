using System; 
using System.Configuration; 
using ConsoleBlogCore.Model;
using Microsoft.EntityFrameworkCore; 

namespace ConsoleBlogCore.Context {
  public class BloggingContext : DbContext {

    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; } 

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["BloggingDatabase"].ConnectionString);
    }

  }

}
