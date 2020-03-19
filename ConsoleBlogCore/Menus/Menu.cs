using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static string displayBlogggingSelectionMenu() {
            var menu = "\n 1) Add Blog" +
                "\n 2) Add Post" +
                "\n 3) View Blogs" +
                "\n 4) View Posts" + 
                "\n 5) Exit";
            return menu;
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
