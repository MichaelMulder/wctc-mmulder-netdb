using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleBlogCore.Model;

namespace ConsoleBlogCore.Menus {
  class PostMenu : IBakerMenu {
    public void displayMenu() {
        var menu = "\n 1) Browse Posts" +
            "\n 2) Add a Post" +
            "\n 3) Edit a Post" +
            "\n 4) Delete a Post"+
            "\n 5) Exit";

        Console.WriteLine(menu);
    }

    public void editMenu() {
        var menu = "\n 1) Edit post title" +
            "\n 2) Edit post content"+
            "\n 3) Exit";
        Console.WriteLine(menu);
    }
    public void displayPosts(IEnumerable<Post> posts) { 
        int pageSize = 3, pageCount = 0; 
        var postPage = posts.Take(pageSize); 
        while(postPage.Count() > 0) { 
            foreach(var post in postPage) { 
                Console.WriteLine($"\n" + 
                $" Post Id: {post.PostID} \n" + 
                $" Post Title: {post.Title} \n" + 
                $" Post Content: {post.Content} \n" + 
                $" Blog Id: {post.BlogId} \n" + 
                $" Blog Name: {post.Blog.Name} \n"); 
            }     
            Console.WriteLine("Press space to continue... Press q to quit..."); 
            var input = Console.ReadKey(true).Key; 
            if (input == ConsoleKey.Spacebar) { 
                pageCount++; 
                postPage = posts.Skip(pageSize * pageCount).Take(pageSize);
            } else if (input == ConsoleKey.Q) {
                    break;
            }
        } 
    }
    public Post CreatePost(Blog blog) { 
        Console.WriteLine("Enter the post title:"); 
        var postTitle = MenuHelpers.getStringInput(); 
        Console.WriteLine("Enter post content"); 
        var postContent = MenuHelpers.getStringInput(); 
        var newPost = new Post { 
            Title = postTitle, 
            Content = postContent, 
            Blog = blog, 
            BlogId = blog.BlogId 
        }; 
            return newPost;
        }
  }
}