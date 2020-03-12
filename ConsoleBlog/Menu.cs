using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBlog {
    class Menu {
        public static void displayMessage(string message) {
            Console.WriteLine(message);
        }
        public static string getStringInput() {
            return Console.ReadLine();
        }
        public static string displayBlogggingSelectionMenu() {
            var menu = "\n 1) Add Blog" +
                "\n 2) Add Post" +
                "\n 3) View Blogs" +
                "\n 4) View Posts" + 
                "\n 5) Exit";
            return menu;
        }
        public static int getIntInput() {
            var input = Console.ReadLine();
            int parsedInput;
            parsedInput = int.TryParse(input, out parsedInput) ? parsedInput : 0;
            if (parsedInput == 0) {
                Console.WriteLine("Please enter vaild input (a number)");
            }
            return parsedInput;
        }

    }
}
