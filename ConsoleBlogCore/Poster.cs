using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ConsoleBlogCore.Context;
using ConsoleBlogCore.Menus;
using ConsoleBlogCore.Model;

namespace ConsoleBlogCore {
  class Poster : IMakeBread {
    private Menu Menu;

    public Poster(Menu menu)
    {
      this.Menu = menu;
    }

    public void Add() { 
      Menu.displayMessage("Enter a Blog Name"); 
      var blogName = Menu.getStringInput(); 
      using (var db = new BloggingContext()) { 
        var blogFound = db.Blogs 
          .Where(b => b.Name == blogName) 
          .FirstOrDefault(); 

        blogFound.Posts = new List<Post>(); 
        Menu.displayMessage("Enter the post title:"); 
        var postTitle = Menu.getStringInput(); 
        Menu.displayMessage("Enter post content"); 
        var postContent = Menu.getStringInput(); 
        var newPost = new Post { 
          Title = postTitle, 
          Content = postContent, 
          Blog = blogFound, 
          BlogId = blogFound.BlogId 
        }; 
        blogFound.Posts.Add(newPost); 
        db.SaveChanges();
      }

    }

    public void Browse() {
      var data = this.Read(); 
      var posts = data.OfType<Post>();
      foreach(var post in posts) {
        Menu.displayMessage($"\n" + 
          $" Post Id: {post.PostID} \n" + 
          $" Post Title: {post.Title} \n" +
          $" Post Content: {post.Content} \n" +
          $" Blog Id: {post.BlogId} \n" +
          $" Blog Name: {post.Blog.Name} \n"); 
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
        return postQuery;
      }
    }
  }
}