using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ConsoleBlogCore.Context;
using ConsoleBlogCore.Menus;
using ConsoleBlogCore.Model;

namespace ConsoleBlogCore.Bakers {
    class Poster : IMakeBread { 
        private Menu Menu; 
        public Poster(Menu menu) { 
            this.Menu = menu; 
        } 
        public void Add() { 
            Blogger blogger = new Blogger(Menu);
            var search = Menu.getSearchType();
            var blogFound = blogger.Find(search);
            Menu.displayMessage($"Found {blogFound.Name}");
            using (var db = new BloggingContext()) { 
                var newPost = Menu.CreatePost(blogFound);
                var blog = db.Update(blogFound).Entity;
                Menu.displayMessage($"Added {newPost.Title} to {blog.Name}");
                blog.Posts.Add(newPost); 
                db.SaveChanges(); 
            }
        } 
        public void Browse() { 
            SearchTypes searchType = Menu.getSearchType();
            Menu.displayPosts(Search(searchType));
        }

        public void Delete() {
            SearchTypes searchType = Menu.getSearchType();
            var postToDelete = Find(searchType);
            Menu.displayMessage($"Are you sure you want to delete {postToDelete.Title}?");
            Menu.displayMessage("1) YES \n" +
                                "2) NO");

            var choice = Menu.getIntInput();
            switch(choice) {
                case 1:
                    Menu.displayMessage("Deleting...");
                    using(var db = new BloggingContext()) {
                        db.Posts.Remove(postToDelete);
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
            var postToEdit = Find(searchType); 
            Menu.displayMessage($"Found {postToEdit.Title}");
            using(var db = new BloggingContext()) {
                int choice; 
                Menu.displayMessage(Menu.displayPostEditMenu());
                choice = Menu.getIntInput();
                var editPost = db.Update(postToEdit).Entity;
                switch(choice) {
                    case 1:
                        Menu.displayMessage($"Enter a new title for {editPost.Title}");
                        var newTitle = Menu.getStringInput(); 
                        Menu.displayMessage($"Changing {editPost.Title} to {newTitle}");
                        editPost.Title = newTitle;
                        db.SaveChanges();
                    break;
                    case 2:
                        Menu.displayMessage($"Enter a new Content for {editPost.Title}");
                        var newContent = Menu.getStringInput(); 
                        Menu.displayMessage($"Changing {editPost.Content} to {newContent}");
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
                    Menu.displayMessage("Enter a Blog Name"); 
                    var blogName = Menu.getStringInput(); 
                    
                    var SearchByBlogName = postQuery
                        .Where(p => p.Blog.Name.Contains(blogName)) 
                        .FirstOrDefault(); 
                    if(SearchByBlogName is Post) { 
                        return SearchByBlogName;
                    } else {
                        Menu.displayMessage("Could not find blog");
                        return postQuery.Single();
                    }

                case SearchTypes.SearchByBlogId:
                    Menu.displayMessage("Enter a Blog Id");
                    var blogId = Menu.getIntInput();

                    var SearchByBlogId = postQuery
                        .Where(p => p.BlogId.Equals(blogId))
                        .FirstOrDefault();
                    if(SearchByBlogId is Post) { 
                        return SearchByBlogId;
                    } else {
                        Menu.displayMessage("Could not find blog");
                        return postQuery.Single();
                    }


                case SearchTypes.SearchByPostId:
                    Menu.displayMessage("Enter a Post Id");
                    var postId = Menu.getIntInput();
                    var SearchByPostId = postQuery
                        .Where(p => p.PostID.Equals(postId))
                        .FirstOrDefault();
                    if(SearchByPostId is Post) { 
                        return SearchByPostId;
                    } else {
                        Menu.displayMessage("Could not find blog");
                        return postQuery.Single();
                    } 
                case SearchTypes.SearchByPostTitle: 
                    Menu.displayMessage("Enter a Post Title");
                    var postTitle = Menu.getStringInput();
                    var SearchByPostTitle = postQuery
                        .Where(p => p.Title.Contains(postTitle)) 
                        .FirstOrDefault();
                    if(SearchByPostTitle is Post) { 
                        return SearchByPostTitle;
                    } else {
                        Menu.displayMessage("Could not find blog");
                        return postQuery.Single();
                    } 
                case SearchTypes.SearchByPostContent:
                    Menu.displayMessage("Enter a Post Title");
                    var postContent = Menu.getStringInput();
                    var SearchByPostContent = postQuery
                        .Where(p => p.Content.Contains(postContent)) 
                        .FirstOrDefault();
                    if(SearchByPostContent is Post) { 
                        return SearchByPostContent;
                    } else {
                        Menu.displayMessage("Could not find blog");
                        return postQuery.Single();
                    }
                case SearchTypes.SearchError:
                    Menu.displayMessage("Could not Determine Search Type");
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
                    Menu.displayMessage("Enter a Blog Name"); 
                    var blogName = Menu.getStringInput(); 
                    
                    var SearchByBlogName = blogQuery
                        .Where(p => p.Blog.Name.Contains(blogName));
                    if(SearchByBlogName is IEnumerable<Post>) { 
                        return SearchByBlogName;
                    } else {
                        Menu.displayMessage("Could not find blog");
                        return blogQuery;
                    }

                case SearchTypes.SearchByBlogId:
                    Menu.displayMessage("Enter a Blog Id");
                    var blogId = Menu.getIntInput();

                    var SearchByBlogId = blogQuery
                        .Where(p => p.BlogId.Equals(blogId));
                    if(SearchByBlogId is IEnumerable<Post>) { 
                        return SearchByBlogId;
                    } else {
                        Menu.displayMessage("Could not find blog");
                        return blogQuery;
                    }


                case SearchTypes.SearchByPostId:
                    Menu.displayMessage("Enter a Post Id");
                    var postId = Menu.getIntInput();
                    var SearchByPostId = blogQuery
                        .Where(p => p.PostID.Equals(postId));
                    if(SearchByPostId is IEnumerable<Post>) { 
                        return SearchByPostId;
                    } else {
                        Menu.displayMessage("Could not find blog");
                        return blogQuery;
                    } 
                case SearchTypes.SearchByPostTitle: 
                    Menu.displayMessage("Enter a Post Title");
                    var postTitle = Menu.getStringInput();
                    var SearchByPostTitle = blogQuery
                        .Where(p => p.Title.Contains(postTitle));
                    if(SearchByPostTitle is IEnumerable<Post>) { 
                        return SearchByPostTitle;
                    } else {
                        Menu.displayMessage("Could not find blog");
                        return blogQuery;
                    } 
                case SearchTypes.SearchByPostContent:
                    Menu.displayMessage("Enter a Post Title");
                    var postContent = Menu.getStringInput();
                    var SearchByPostContent = blogQuery
                        .Where(p => p.Content.Contains(postContent));
                    if(SearchByPostContent is IEnumerable<Post>) { 
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