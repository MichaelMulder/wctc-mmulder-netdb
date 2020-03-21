using Microsoft.EntityFrameworkCore;
using ConsoleBlogCore.Model;
using ConsoleBlogCore.Context;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using ConsoleBlogCore.Menus;

namespace ConsoleBlogCore.Bakers {
    class Blogger : IMakeBread {
        private Menu Menu;

        public Blogger(Menu menu) { 
            this.Menu = menu; 
        }

        public void Add() { 
            var newBlog = Menu.CreateBlog();
            using (var db = new BloggingContext()) { 
                db.Blogs.Add(newBlog);
                db.SaveChanges(); 
                Menu.displayMessage($"Added {newBlog.Name} to database"); 
            } 
        }

        public void Browse() { 
            SearchTypes searchType = Menu.getSearchType();
            Menu.displayBlogs(Search(searchType));
        }

        public void Delete() {
            SearchTypes searchType = Menu.getSearchType();
            var blogToDelete = Find(searchType);
            Menu.displayMessage($"Are you sure you want to delete {blogToDelete.Name}?");
            Menu.displayMessage("1) YES \n" +
                                "2) NO");
            var choice = Menu.getIntInput();
            
            switch(choice) {
                case 1:
                    Menu.displayMessage("Deleting...");
                    using(var db = new BloggingContext()) {
                        db.Blogs.Remove(blogToDelete); 
                        db.SaveChanges();
                    }
                break;
                case 2:
                    Menu.displayMessage("Exiting...");
                break;
            }
        }

        public void Edit() {
            SearchTypes searchType = Menu.getSearchType();
            var blogToEdit = Find(searchType); 
            using(var db = new BloggingContext()) {
                Menu.displayMessage(Menu.displayBlogEditMenu()); 
                var newName = Menu.getStringInput(); 
                var editBlog = db.Update(blogToEdit).Entity;
                Menu.displayMessage($"Changing {editBlog.Name} to {newName}");
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
                    Menu.displayMessage("Enter a Blog Name"); 
                    var blogName = Menu.getStringInput(); 
                    
                    var SearchByBlogName = blogQuery
                        .Where(b => b.Name.Contains(blogName)) 
                        .FirstOrDefault(); 
                    if(SearchByBlogName is Blog) { 
                        return SearchByBlogName;
                    } else {
                        Menu.displayMessage("Could not find blog");
                        return blogQuery.Single();
                    }

                case SearchTypes.SearchByBlogId:
                    Menu.displayMessage("Enter a Blog Id");
                    var blogId = Menu.getIntInput();

                    var SearchByBlogId = blogQuery
                        .Where(b => b.BlogId.Equals(blogId))
                        .FirstOrDefault();
                    if(SearchByBlogId is Blog) { 
                        return SearchByBlogId;
                    } else {
                        Menu.displayMessage("Could not find blog");
                        return blogQuery.Single();
                    }


                case SearchTypes.SearchByPostId:
                    Menu.displayMessage("Enter a Post Id");
                    var postId = Menu.getIntInput();
                    var SearchByPostId = blogQuery
                        .Where(b => b.Posts.Exists(p => p.PostID.Equals(postId)))
                        .FirstOrDefault();
                    if(SearchByPostId is Blog) { 
                        return SearchByPostId;
                    } else {
                        Menu.displayMessage("Could not find blog");
                        return blogQuery.Single();
                    } 
                case SearchTypes.SearchByPostTitle: 
                    Menu.displayMessage("Enter a Post Title");
                    var postTitle = Menu.getStringInput();
                    var SearchByPostTitle = blogQuery
                        .Where(b => b.Posts.Exists(p => p.Title.Contains(postTitle))) 
                        .FirstOrDefault();
                    if(SearchByPostTitle is Blog) { 
                        return SearchByPostTitle;
                    } else {
                        Menu.displayMessage("Could not find blog");
                        return blogQuery.Single();
                    } 
                case SearchTypes.SearchByPostContent:
                    Menu.displayMessage("Enter a Post Title");
                    var postContent = Menu.getStringInput();
                    var SearchByPostContent = blogQuery
                        .Where(b => b.Posts.Exists(p => p.Content.Contains(postContent))) 
                        .FirstOrDefault();
                    if(SearchByPostContent is Blog) { 
                        return SearchByPostContent;
                    } else {
                        Menu.displayMessage("Could not find blog");
                        return blogQuery.Single();
                    }
                case SearchTypes.SearchError:
                    Menu.displayMessage("Could not Determine Search Type");
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
                    Menu.displayMessage("Enter a Blog Name"); 
                    var blogName = Menu.getStringInput(); 
                    
                    var SearchByBlogName = blogQuery
                        .Where(b => b.Name.Contains(blogName));
                    if(SearchByBlogName is IEnumerable<Blog>) { 
                        return SearchByBlogName;
                    } else {
                        Menu.displayMessage("Could not find blog");
                        return blogQuery;
                    }

                case SearchTypes.SearchByBlogId:
                    Menu.displayMessage("Enter a Blog Id");
                    var blogId = Menu.getIntInput();

                    var SearchByBlogId = blogQuery
                        .Where(b => b.BlogId.Equals(blogId));
                    if(SearchByBlogId is IEnumerable<Blog>) { 
                        return SearchByBlogId;
                    } else {
                        Menu.displayMessage("Could not find blog");
                        return blogQuery;
                    }


                case SearchTypes.SearchByPostId:
                    Menu.displayMessage("Enter a Post Id");
                    var postId = Menu.getIntInput();
                    var SearchByPostId = blogQuery
                        .Where(b => b.Posts.Exists(p => p.PostID.Equals(postId)));
                    if(SearchByPostId is IEnumerable<Blog>) { 
                        return SearchByPostId;
                    } else {
                        Menu.displayMessage("Could not find blog");
                        return blogQuery;
                    } 
                case SearchTypes.SearchByPostTitle: 
                    Menu.displayMessage("Enter a Post Title");
                    var postTitle = Menu.getStringInput();
                    var SearchByPostTitle = blogQuery
                        .Where(b => b.Posts.Exists(p => p.Title.Contains(postTitle)));
                    if(SearchByPostTitle is IEnumerable<Blog>) { 
                        return SearchByPostTitle;
                    } else {
                        Menu.displayMessage("Could not find blog");
                        return blogQuery;
                    } 
                case SearchTypes.SearchByPostContent:
                    Menu.displayMessage("Enter a Post Title");
                    var postContent = Menu.getStringInput();
                    var SearchByPostContent = blogQuery
                        .Where(b => b.Posts.Exists(p => p.Content.Contains(postContent)));
                    if(SearchByPostContent is IEnumerable<Blog>) { 
                        return SearchByPostContent;
                    } else {
                        Menu.displayMessage("Could not find blog");
                        return blogQuery;
                    }
                case SearchTypes.SearchError:
                    Menu.displayMessage("Could not Determine Search Type");
                    return blogQuery;
                default:
                    return blogQuery;
            }
        }
    }
}
  