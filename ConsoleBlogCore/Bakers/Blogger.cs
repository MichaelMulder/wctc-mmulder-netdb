using Microsoft.EntityFrameworkCore;
using ConsoleBlogCore.Model;
using ConsoleBlogCore.Context;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using ConsoleBlogCore.Menus;
using System;

namespace ConsoleBlogCore.Bakers {
    class Blogger : IMakeBread {
        private BlogMenu Menu;

        public Blogger(BlogMenu menu) { 
            this.Menu = menu; 
        }

        public void Add() { 
            var newBlog = Menu.CreateBlog();
            using (var db = new BloggingContext()) { 
                db.Blogs.Add(newBlog);
                db.SaveChanges(); 
                Console.WriteLine($"Added {newBlog.Name} to database"); 
            } 
        }

        public void Browse() { 
            SearchTypes searchType = MenuHelpers.getSearchType();
            Menu.displayBlogs(Search(searchType));
        }

        public void Delete() {
            SearchTypes searchType = MenuHelpers.getSearchType();
            var blogToDelete = Find(searchType);
            Console.WriteLine($"Are you sure you want to delete {blogToDelete.Name}?");
            Console.WriteLine("1) YES \n" +
                                "2) NO");
            var choice = MenuHelpers.getIntInput();
            
            switch(choice) {
                case 1:
                    Console.WriteLine("Deleting...");
                    using(var db = new BloggingContext()) {
                        db.Blogs.Remove(blogToDelete); 
                        db.SaveChanges();
                    }
                break;
                case 2:
                    Console.WriteLine("Exiting...");
                break;
            }
        }

        public void Edit() {
            SearchTypes searchType = MenuHelpers.getSearchType();
            var blogToEdit = Find(searchType); 
            using(var db = new BloggingContext()) {
                Menu.editMenu();
                var newName = MenuHelpers.getStringInput(); 
                var editBlog = db.Update(blogToEdit).Entity;
                Console.WriteLine($"Changing {editBlog.Name} to {newName}");
                editBlog.Name = newName;
                db.SaveChanges();
            }
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

        public Blog Find(SearchTypes search) {
            var data = Read();
            var blogQuery = data.OfType<Blog>();
            switch(search) {
                case SearchTypes.SearchByBlogName:
                    Console.WriteLine("Enter a Blog Name"); 
                    var blogName = MenuHelpers.getStringInput(); 
                    
                    var SearchByBlogName = blogQuery
                        .Where(b => b.Name.Contains(blogName)) 
                        .FirstOrDefault(); 
                    if(SearchByBlogName is Blog) { 
                        return SearchByBlogName;
                    } else {
                        Console.WriteLine("Could not find blog");
                        return blogQuery.Single();
                    }

                case SearchTypes.SearchByBlogId:
                    Console.WriteLine("Enter a Blog Id");
                    var blogId = MenuHelpers.getIntInput();

                    var SearchByBlogId = blogQuery
                        .Where(b => b.BlogId.Equals(blogId))
                        .FirstOrDefault();
                    if(SearchByBlogId is Blog) { 
                        return SearchByBlogId;
                    } else {
                        Console.WriteLine("Could not find blog");
                        return blogQuery.Single();
                    }


                case SearchTypes.SearchByPostId:
                    Console.WriteLine("Enter a Post Id");
                    var postId = MenuHelpers.getIntInput();
                    var SearchByPostId = blogQuery
                        .Where(b => b.Posts.Exists(p => p.PostID.Equals(postId)))
                        .FirstOrDefault();
                    if(SearchByPostId is Blog) { 
                        return SearchByPostId;
                    } else {
                        Console.WriteLine("Could not find blog");
                        return blogQuery.Single();
                    } 
                case SearchTypes.SearchByPostTitle: 
                    Console.WriteLine("Enter a Post Title");
                    var postTitle = MenuHelpers.getStringInput();
                    var SearchByPostTitle = blogQuery
                        .Where(b => b.Posts.Exists(p => p.Title.Contains(postTitle))) 
                        .FirstOrDefault();
                    if(SearchByPostTitle is Blog) { 
                        return SearchByPostTitle;
                    } else {
                        Console.WriteLine("Could not find blog");
                        return blogQuery.Single();
                    } 
                case SearchTypes.SearchByPostContent:
                    Console.WriteLine("Enter a Post Title");
                    var postContent = MenuHelpers.getStringInput();
                    var SearchByPostContent = blogQuery
                        .Where(b => b.Posts.Exists(p => p.Content.Contains(postContent))) 
                        .FirstOrDefault();
                    if(SearchByPostContent is Blog) { 
                        return SearchByPostContent;
                    } else {
                        Console.WriteLine("Could not find blog");
                        return blogQuery.Single();
                    }
                case SearchTypes.SearchError:
                    Console.WriteLine("Could not Determine Search Type");
                    return blogQuery.Single();
                default:
                    return blogQuery.Single();
            }
        }

        public IEnumerable<Blog> Search(SearchTypes search) {
            var data = Read();
            var blogQuery = data.OfType<Blog>();
            switch(search) {
                case SearchTypes.SearchByBlogName:
                    Console.WriteLine("Enter a Blog Name"); 
                    var blogName = MenuHelpers.getStringInput(); 
                    
                    var SearchByBlogName = blogQuery
                        .Where(b => b.Name.Contains(blogName));
                    if(SearchByBlogName is IEnumerable<Blog>) { 
                        return SearchByBlogName;
                    } else {
                        Console.WriteLine("Could not find blog");
                        return blogQuery;
                    }

                case SearchTypes.SearchByBlogId:
                    Console.WriteLine("Enter a Blog Id");
                    var blogId = MenuHelpers.getIntInput();

                    var SearchByBlogId = blogQuery
                        .Where(b => b.BlogId.Equals(blogId));
                    if(SearchByBlogId is IEnumerable<Blog>) { 
                        return SearchByBlogId;
                    } else {
                        Console.WriteLine("Could not find blog");
                        return blogQuery;
                    }


                case SearchTypes.SearchByPostId:
                    Console.WriteLine("Enter a Post Id");
                    var postId = MenuHelpers.getIntInput();
                    var SearchByPostId = blogQuery
                        .Where(b => b.Posts.Exists(p => p.PostID.Equals(postId)));
                    if(SearchByPostId is IEnumerable<Blog>) { 
                        return SearchByPostId;
                    } else {
                        Console.WriteLine("Could not find blog");
                        return blogQuery;
                    } 
                case SearchTypes.SearchByPostTitle: 
                    Console.WriteLine("Enter a Post Title");
                    var postTitle = MenuHelpers.getStringInput();
                    var SearchByPostTitle = blogQuery
                        .Where(b => b.Posts.Exists(p => p.Title.Contains(postTitle)));
                    if(SearchByPostTitle is IEnumerable<Blog>) { 
                        return SearchByPostTitle;
                    } else {
                        Console.WriteLine("Could not find blog");
                        return blogQuery;
                    } 
                case SearchTypes.SearchByPostContent:
                    Console.WriteLine("Enter a Post Title");
                    var postContent = MenuHelpers.getStringInput();
                    var SearchByPostContent = blogQuery
                        .Where(b => b.Posts.Exists(p => p.Content.Contains(postContent)));
                    if(SearchByPostContent is IEnumerable<Blog>) { 
                        return SearchByPostContent;
                    } else {
                        Console.WriteLine("Could not find blog");
                        return blogQuery;
                    }
                case SearchTypes.SearchError:
                    Console.WriteLine("Could not Determine Search Type");
                    return blogQuery;
                default:
                    return blogQuery;
            }
        }
    }
}
  