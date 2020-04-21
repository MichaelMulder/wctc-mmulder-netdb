using System;
using ConsoleBlogCore.Bakers;

namespace ConsoleBlogCore.Menus {
    class MenuHelpers {
        public static string getStringInput() { 
            return Console.ReadLine();
        } 
        public static int getIntInput() { 
            var input = Console.ReadLine(); 
            int parsedInput; 
            parsedInput = int.TryParse(input, out parsedInput) ? parsedInput : 0; 
            if (parsedInput == 0) 
                Console.WriteLine("Please enter valid input (a number)"); 

            return parsedInput;
        }

        public static SearchTypes getSearchType() {
            Console.WriteLine("\n 1) Search By Blog Name" +
                "\n 2) Search By Blog Id" +
                "\n 3) Search By Post Title" +
                "\n 4) Search By Post Content"+
                "\n 5) Search By Post Id");
            int choice = MenuHelpers.getIntInput();
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

    }

}