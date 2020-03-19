using Microsoft.EntityFrameworkCore;
using ConsoleBlogCore.Model;
using ConsoleBlogCore.Context;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using ConsoleBlogCore.Menus;

namespace ConsoleBlogCore {
  class Blogger : IMakeBread {
    private Menu Menu;

    public Blogger(Menu menu)
    {
      this.Menu = menu;
    }

    public void Add() { 
      Menu.displayMessage("Enter a name");
      var newBlogName = Menu.getStringInput();
      var newBlog = new Blog() { 
        Name = newBlogName,
      };
      using (var db = new BloggingContext()) {
        db.Blogs.Add(newBlog);
        db.SaveChanges(); 
        Menu.displayMessage($"Added {newBlog.Name} to database");
      } 
    }

    public void Browse() {
      var data = this.Read();
      var blogs = data.OfType<Blog>();
      foreach (var blog in blogs) { 
        Menu.displayMessage($"BlogId: {blog.BlogId}");
        Menu.displayMessage($"\nBlog: {blog.Name}"); 

        if(blog.Posts.Count > 0) {
          Menu.displayMessage($" Posts: {blog.Posts.Count}");
          foreach(var post in blog.Posts) { 
            Menu.displayMessage($"\n" + 
              $" Post Id: {post.PostID} \n" + 
              $" Post Title: {post.Title} \n" +
              $" Post Content: {post.Content} \n" );
          }
        } else {
          Menu.displayMessage(" No posts yet...");
        }
      }
    }

    public void Delete() {
     throw new System.NotImplementedException();
    }

    public void Edit() {
      throw new System.NotImplementedException();
    }

    public IEnumerable Read() { 
      using (var db = new BloggingContext()) {
        var postQuery = db.Posts.ToList(); 
        var blogQuery = db.Blogs.ToList(); 
        foreach(var blog in blogQuery) {
          blog.Posts = new List<Post>();
          foreach(var post in postQuery) {
            if(post.BlogId.Equals(blog.BlogId)) {
              blog.Posts.Add(post);
            }
          }
        }
        return blogQuery;
      }
    }
  }
}
  