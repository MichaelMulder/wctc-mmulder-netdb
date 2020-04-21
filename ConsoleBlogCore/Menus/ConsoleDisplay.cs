using System;
using ConsoleBlogCore.Bakers;

namespace ConsoleBlogCore.Menus {
    class ConsoleDisplay {
        public void Run() {
            int choice = 0; 

            while (choice < 4) { 
                IMenu mainMenu = new MainMenu(); 
                mainMenu.displayMenu();
                choice = MenuHelpers.getIntInput(); 
                BlogMenu blogMenu = new BlogMenu();
                PostMenu postMenu = new PostMenu();
                IMakeBread blogger = new Blogger(blogMenu); 
                IMakeBread poster = new Poster(postMenu); 
                switch (choice) { 
                    case 1: 
                        blogMenu.displayMenu();
                        IBakerMenu.bakerMenu(blogger);
                    break;  
                    case 2: 
                        postMenu.displayMenu();
                        IBakerMenu.bakerMenu(poster);
                    break; 
                    case 3:
                        Environment.Exit(0);
                    break; 
                }
            }
        }
    }
}