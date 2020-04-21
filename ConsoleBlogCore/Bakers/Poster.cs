using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ConsoleBlogCore.Context;
using ConsoleBlogCore.Menus;
using ConsoleBlogCore.Model;

namespace ConsoleBlogCore.Bakers {
    class Poster : IMakeBread { 
        private PostMenu Menu; 
        public Poster(PostMenu menu) { 
            this.Menu = menu; 
        } 
        public void Add() { 
            BlogMenu Menu = new BlogMenu();
            Blogger blogger = new Blogger(Menu);
            var search = MenuHelpers.getSearchType();
            var blogFound = blogger.Find(search);
            Console.WriteLine($"Found {blogFound.Name}");
            using (var db = new BloggingContext()) { 
                var newPost = this.Menu.CreatePost(blogFound);
                var blog = db.Update(blogFound).Entity;
                Console.WriteLine($"Added {newPost.Title} to {blog.Name}");
                blog.Posts.Add(newPost); 
                db.SaveChanges(); 
            }
        } 
        public void Browse() { 
            SearchTypes searchType = MenuHelpers.getSearchType();
            Menu.displayPosts(Search(searchType));
        }

        public void Delete() {
            SearchTypes searchType = MenuHelpers.getSearchType();
            var postToDelete = Find(searchType);
            Console.WriteLine($"Are you sure you want to delete {postToDelete.Title}?");
            Console.WriteLine("1) YES \n" +
                                "2) NO");

            var choice = MenuHelpers.getIntInput();
            switch(choice) {
                case 1:
                    Console.WriteLine("Deleting...");
                    using(var db = new BloggingContext()) {
                        db.Posts.Remove(postToDelete);
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
            var postToEdit = Find(searchType); 
            Console.WriteLine($"Found {postToEdit.Title}");
            using(var db = new BloggingContext()) {
                int choice; 
                this.Menu.editMenu();
                choice = MenuHelpers.getIntInput();
                var editPost = db.Update(postToEdit).Entity;
                switch(choice) {
                    case 1:
                        Console.WriteLine($"Enter a new title for {editPost.Title}");
                        var newTitle = MenuHelpers.getStringInput(); 
                        Console.WriteLine($"Changing {editPost.Title} to {newTitle}");
                        editPost.Title = newTitle;
                        db.SaveChanges();
                    break;
                    case 2:
                        Console.WriteLine($"Enter a new Content for {editPost.Title}");
                        var newContent = MenuHelpers.getStringInput(); 
                        Console.WriteLine($"Changing {editPost.Content} to {newContent}");
                        editPost.Content = newContent;
                        db.SaveChanges();
                    break;
                    default:
                    break;
                }
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
                return postQuery;
            } 
        } 

        public Post Find(SearchTypes search) {
            var data = Read();
            var postQuery = data.OfType<Post>();
            switch(search) {
                case SearchTypes.SearchByBlogName:
                    Console.WriteLine("Enter a Blog Name"); 
                    var blogName = MenuHelpers.getStringInput(); 
                    
                    var SearchByBlogName = postQuery
                        .Where(p => p.Blog.Name.Contains(blogName)) 
                        .FirstOrDefault(); 
                    if(SearchByBlogName is Post) { 
                        return SearchByBlogName;
                    } else {
                        Console.WriteLine("Could not find blog");
                        return postQuery.Single();
                    }

                case SearchTypes.SearchByBlogId:
                    Console.WriteLine("Enter a Blog Id");
                    var blogId = MenuHelpers.getIntInput();

                    var SearchByBlogId = postQuery
                        .Where(p => p.BlogId.Equals(blogId))
                        .FirstOrDefault();
                    if(SearchByBlogId is Post) { 
                        return SearchByBlogId;
                    } else {
                        Console.WriteLine("Could not find blog");
                        return postQuery.Single();
                    }


                case SearchTypes.SearchByPostId:
                    Console.WriteLine("Enter a Post Id");
                    var postId = MenuHelpers.getIntInput();
                    var SearchByPostId = postQuery
                        .Where(p => p.PostID.Equals(postId))
                        .FirstOrDefault();
                    if(SearchByPostId is Post) { 
                        return SearchByPostId;
                    } else {
                        Console.WriteLine("Could not find blog");
                        return postQuery.Single();
                    } 
                case SearchTypes.SearchByPostTitle: 
                    Console.WriteLine("Enter a Post Title");
                    var postTitle = MenuHelpers.getStringInput();
                    var SearchByPostTitle = postQuery
                        .Where(p => p.Title.Contains(postTitle)) 
                        .FirstOrDefault();
                    if(SearchByPostTitle is Post) { 
                        return SearchByPostTitle;
                    } else {
                        Console.WriteLine("Could not find blog");
                        return postQuery.Single();
                    } 
                case SearchTypes.SearchByPostContent:
                    Console.WriteLine("Enter a Post Title");
                    var postContent = MenuHelpers.getStringInput();
                    var SearchByPostContent = postQuery
                        .Where(p => p.Content.Contains(postContent)) 
                        .FirstOrDefault();
                    if(SearchByPostContent is Post) { 
                        return SearchByPostContent;
                    } else {
                        Console.WriteLine("Could not find blog");
                        return postQuery.Single();
                    }
                case SearchTypes.SearchError:
                    Console.WriteLine("Could not Determine Search Type");
                    return postQuery.Single();
                default:
                    return postQuery.Single();
            }
        }
        public IEnumerable<Post> Search(SearchTypes search) {
            var data = Read();
            var blogQuery = data.OfType<Post>();
            switch(search) {
                case SearchTypes.SearchByBlogName:
                    Console.WriteLine("Enter a Blog Name"); 
                    var blogName = MenuHelpers.getStringInput(); 
                    
                    var SearchByBlogName = blogQuery
                        .Where(p => p.Blog.Name.Contains(blogName));
                    if(SearchByBlogName is IEnumerable<Post>) { 
                        return SearchByBlogName;
                    } else {
                        Console.WriteLine("Could not find blog");
                        return blogQuery;
                    }

                case SearchTypes.SearchByBlogId:
                    Console.WriteLine("Enter a Blog Id");
                    var blogId = MenuHelpers.getIntInput();

                    var SearchByBlogId = blogQuery
                        .Where(p => p.BlogId.Equals(blogId));
                    if(SearchByBlogId is IEnumerable<Post>) { 
                        return SearchByBlogId;
                    } else {
                        Console.WriteLine("Could not find blog");
                        return blogQuery;
                    }


                case SearchTypes.SearchByPostId:
                    Console.WriteLine("Enter a Post Id");
                    var postId = MenuHelpers.getIntInput();
                    var SearchByPostId = blogQuery
                        .Where(p => p.PostID.Equals(postId));
                    if(SearchByPostId is IEnumerable<Post>) { 
                        return SearchByPostId;
                    } else {
                        Console.WriteLine("Could not find blog");
                        return blogQuery;
                    } 
                case SearchTypes.SearchByPostTitle: 
                    Console.WriteLine("Enter a Post Title");
                    var postTitle = MenuHelpers.getStringInput();
                    var SearchByPostTitle = blogQuery
                        .Where(p => p.Title.Contains(postTitle));
                    if(SearchByPostTitle is IEnumerable<Post>) { 
                        return SearchByPostTitle;
                    } else {
                        Console.WriteLine("Could not find blog");
                        return blogQuery;
                    } 
                case SearchTypes.SearchByPostContent:
                    Console.WriteLine("Enter a Post Title");
                    var postContent = MenuHelpers.getStringInput();
                    var SearchByPostContent = blogQuery
                        .Where(p => p.Content.Contains(postContent));
                    if(SearchByPostContent is IEnumerable<Post>) { 
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