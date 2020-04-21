using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleBlogCore.Model;
using ConsoleBlogCore.Bakers;

namespace ConsoleBlogCore.Menus {
    class Menu {
        public displayTypes displayType {get; set;}
        public Menu(displayTypes display) {
           this.displayType = display;
        }
        public void displayMessage(string message) {
            switch(displayType) {
                case displayTypes.Console:
                    Console.WriteLine(message);
                    break;
                case displayTypes.Web:
                    // do web stuff
                    break;
                default:
                    // Error
                    break;
            }
        }
        public string getStringInput() {
            switch(displayType) {
                case displayTypes.Console:
                    return Console.ReadLine();
                case displayTypes.Web:
                    // do web stuff
                    return "";
                default:
                    // Error
                    return "";
            }
        }
        public static string displayBloggerMenu() {
            var menu = "\n 1) Browse Blogs" +
                "\n 2) Add a Blog" +
                "\n 3) Edit a Blog" +
                "\n 4) Delete a Blog" +
                "\n 5) Exit";
            return menu;
        }
        public static string displayManagingSelectionMenu() {
            var menu = "\n 1) Manage Blogs" +
                "\n 2) Manage Posts" +
                "\n 3) Exit";
            return menu;
        }
        public static string displayPosterMenu() {
            var menu = "\n 1) Browse Posts" +
                "\n 2) Add a Post" +
                "\n 3) Edit a Post" +
                "\n 4) Delete a Post"+
                "\n 5) Exit";
            return menu;
        }

        public static string displayPostEditMenu() {
            var menu = "\n 1) Edit post title" +
                "\n 2) Edit post content"+
                "\n 3) Exit";
            return menu;
        }

        public static string displayBlogEditMenu() {
            var menu = "What would you like the new blog name to be?";
            return menu;
        }

        public static string displaySearchMenu() {
            var menu = "\n 1) Search By Blog Name" +
                "\n 2) Search By Blog Id" +
                "\n 3) Search By Post Title" +
                "\n 4) Search By Post Content"+
                "\n 5) Search By Post Id";
            return menu;
        }

        public void displayPosts(IEnumerable<Post> posts) {
            int pageSize = 3, pageCount = 0;
            var postPage = posts.Take(pageSize);
            while(postPage.Count() > 0) {
                foreach(var post in postPage) { 
                    this.displayMessage($"\n" + 
                    $" Post Id: {post.PostID} \n" + 
                    $" Post Title: {post.Title} \n" + 
                    $" Post Content: {post.Content} \n" + 
                    $" Blog Id: {post.BlogId} \n" + 
                    $" Blog Name: {post.Blog.Name} \n"); 
                }     
                displayMessage("Press space to continue... Press q to quit...");
                var input = Console.ReadKey(true).Key; 
                if (input == ConsoleKey.Spacebar) {
                    pageCount++;
                    postPage = posts.Skip(pageSize * pageCount).Take(pageSize);
                } else if (input == ConsoleKey.Q) {
                    break;
                }
            } 
        }
        public void displayBlogs(IEnumerable<Blog> blogs) {
            int pageSize = 3, pageCount = 0;
            var blogPage = blogs.Take(pageSize).ToList();
            while(blogPage.Count() > 0) {
                System.Console.WriteLine(blogPage.Count());
                foreach (var blog in blogPage) { 
                    displayMessage($"BlogId: {blog.BlogId}"); 
                    displayMessage($"Blog: {blog.Name}"); 
                    if(blog.Posts.Count > 0) { 
                        displayMessage($" Posts: {blog.Posts.Count}"); 
                        foreach(var post in blog.Posts) { 
                            displayMessage($"\n" + 
                            $" Post Id: {post.PostID} \n" + 
                            $" Post Title: {post.Title} \n" + 
                            $" Post Content: {post.Content} \n" ); 
                        } 
                        displayMessage("------------------ \n"); 
                    } else { 
                        displayMessage(" No posts yet..."); 

                        displayMessage("------------------\n"); 
                    }
                }
                displayMessage("Press space to continue... Press q to quit...");
                var input = Console.ReadKey(true).Key;
                if (input.Equals(ConsoleKey.Spacebar)) {
                    pageCount++; 
                    blogPage = blogs.Skip(pageSize * pageCount).Take(pageSize).ToList();
                } else if (input == ConsoleKey.Q) {
                    break;
                }
            } 
        }

        public SearchTypes getSearchType() {
            this.displayMessage(displaySearchMenu());
            int choice = getIntInput();
            switch(choice) {
                case 1:
                    return SearchTypes.SearchByBlogName;
                case 2:
                    return SearchTypes.SearchByBlogId;
                case 3:
                    return SearchTypes.SearchByPostTitle;
                case 4:
                    return SearchTypes.SearchByPostContent;
                case 5:
                    return SearchTypes.SearchByPostId;
                default:
                    return SearchTypes.SearchError;
                     
            }
        }


        public void bakerMenu(IMakeBread baker) {
            this.displayMessage(Menu.displayBloggerMenu());
            int bakerChoice = 0;
            bakerChoice = this.getIntInput();
            switch(bakerChoice) {
                case 1:
                    baker.Browse();
                break;
                case 2:
                    baker.Add();
                break;
                case 3:
                    baker.Edit();
                break;
                case 4:
                    baker.Delete();
                break;
                case 5:
                break;
            }
        }


        public Blog CreateBlog() {
            this.displayMessage("Enter a name"); 
            var newBlogName = this.getStringInput(); 
            var newBlog = new Blog() { 
                Name = newBlogName, 
            }; 
            return newBlog;
        }

        public Post CreatePost(Blog blog) {
            this.displayMessage("Enter the post title:"); 
            var postTitle = this.getStringInput(); 
            this.displayMessage("Enter post content"); 
            var postContent = this.getStringInput(); 
            var newPost = new Post { 
                Title = postTitle, 
                Content = postContent, 
                Blog = blog, 
                BlogId = blog.BlogId 
            }; 
            return newPost;
        }
        public int getIntInput() {
            switch(displayType) {
                case displayTypes.Console:
                    var input = Console.ReadLine();
                    int parsedInput;
                    parsedInput = int.TryParse(input, out parsedInput) ? parsedInput : 0;
                    if (parsedInput == 0)
                        Console.WriteLine("Please enter valid input (a number)");

                    return parsedInput;
                case displayTypes.Web:
                    // do Web stuff
                    return 0;
                default:
                    // Error
                    return 0;
            }
        }

    }
}
