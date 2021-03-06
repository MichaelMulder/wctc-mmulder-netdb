using System;
using ConsoleBlogCore.Bakers;

namespace ConsoleBlogCore.Menus {
    class ConsoleMenu {
        public void Run() {
            int choice = 0; 
            while (choice < 4) { 
                Menu menu = new Menu(displayTypes.Console); 
                menu.displayMessage(Menu.displayManagingSelectionMenu()); 
                choice = menu.getIntInput(); 
                Blogger blogger = new Blogger(menu); 
                Poster poster = new Poster(menu); 
                switch (choice) { 
                    case 1: 
                        menu.bloggerMenu(blogger); 
                    break;  
                    case 2: 
                        menu.posterMenu(poster); 
                    break; 
                    case 3:
                        Environment.Exit(0);
                    break; 
                }
            }
        }
    }
}