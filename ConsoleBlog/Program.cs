using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using System.Data.Entity;
using ConsoleBlog.Model;
using ConsoleBlog.Context;

namespace ConsoleBlog {
    class Program {
        static void Main(string[] args) {
            int choice = 0;
            while(choice < 6) {
                Menu.displayMessage(Menu.displayBlogggingSelectionMenu());
                choice = Menu.getIntInput();
                switch(choice) {
                    case 1:
                        Menu.displayMessage("Enter a name");
                        var newBlogName = Menu.getStringInput(); 
                        var newPostList = new List<Post>();
                        var newBlog = new Blog() { 
                            Name = newBlogName, 
                            Posts = newPostList
                        };
                        using (var db = new BloggingContext()) {
                            db.Blogs.Add(newBlog);
                            db.SaveChanges();
                            Menu.displayMessage($"Added {newBlog.Name} to database");
                        }
                        break; 
                    case 2:
                        // TODO Add post to blog
                        Menu.displayMessage("Enter a Blog Name");
                        var blogName = Menu.getStringInput();
                        using(var db = new BloggingContext()) {
                            var blogFound = db.Blogs
                                .Where(b => b.Name == blogName)
                                .FirstOrDefault();
                            Menu.displayMessage(blogFound.Name);
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
                            blogFound.ToString();
                            blogFound.Posts.Add(newPost);     
                        }
                        break; 
                    case 3: 
                        using (var db = new BloggingContext()) {
                            var query = db.Blogs; 
                            var blogList = query.ToList();
                            foreach (var blog in blogList) {
                                Menu.displayMessage($"Blog: {blog.Name}");
                            }
                        }
                        break; 
                    case 4:
                        using(var db = new BloggingContext()) {
                            var query = db.Posts;
                            var postList = query.ToList();
                            foreach(var post in postList) {
                                Menu.displayMessage($"" +
                                    $"Post Title: {post.Title}" +
                                    $"Post Content: {post.Content}" +
                                    $"Blog: {post.Blog.Name}");
                            }
                        }
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                }
            } 
        }
    }
}
