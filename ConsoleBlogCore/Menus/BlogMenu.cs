using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleBlogCore.Model;

namespace ConsoleBlogCore.Menus {
  class BlogMenu : IBakerMenu {
    public void displayMenu() {
        var menu = "\n 1) Browse Blogs" +
            "\n 2) Add a Blog" +
            "\n 3) Edit a Blog" +
            "\n 4) Delete a Blog" +
            "\n 5) Exit";
        Console.WriteLine(menu);
    }

    public void editMenu() {
        var menu = "What would you like the new blog name to be?";
        Console.WriteLine(menu);
    }

    public void displayBlogs(IEnumerable<Blog> blogs) {
        int pageSize = 3, pageCount = 0;
        var blogPage = blogs.Take(pageSize).ToList();
        while(blogPage.Count() > 0) {
            System.Console.WriteLine(blogPage.Count());
            foreach (var blog in blogPage) { 
                Console.WriteLine($"BlogId: {blog.BlogId}"); 
                Console.WriteLine($"Blog: {blog.Name}"); 
                if(blog.Posts.Count > 0) { 
                    Console.WriteLine($" Posts: {blog.Posts.Count}"); 
                    foreach(var post in blog.Posts) { 
                        Console.WriteLine($"\n" + 
                            $" Post Id: {post.PostID} \n" + 
                            $" Post Title: {post.Title} \n" + 
                            $" Post Content: {post.Content} \n" ); 
                        } 
                        Console.WriteLine("------------------ \n"); 
                } else { 
                    Console.WriteLine(" No posts yet..."); 

                    Console.WriteLine("------------------\n"); 
                }
            }
            Console.WriteLine("Press space to continue... Press q to quit...");
                var input = Console.ReadKey(true).Key;
                if (input.Equals(ConsoleKey.Spacebar)) {
                    pageCount++; 
                    blogPage = blogs.Skip(pageSize * pageCount).Take(pageSize).ToList();
                } else if (input == ConsoleKey.Q) {
                    break;
                }
        } 
    }
    public Blog CreateBlog() { 
        Console.WriteLine("Enter a name"); 
        var newBlogName = MenuHelpers.getStringInput(); 
        var newBlog = new Blog() { 
            Name = newBlogName, 
        }; 
            return newBlog;
        }
  }


}