using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleBlogCore.Context;
using ConsoleBlogCore.Model;
using Microsoft.EntityFrameworkCore;
using ConsoleBlogCore.Menus;

namespace ConsoleBlogCore {
  class Program {
    static void Main(string[] args) {
      int choice = 0;
      while (choice < 6) {
        Menu menu = new Menu(displayTypes.Console);
        menu.displayMessage(Menu.displayBlogggingSelectionMenu());
        choice = menu.getIntInput();
        Blogger blogger = new Blogger(menu);
        Poster poster = new Poster(menu);
        switch (choice) {
          case 1:
            blogger.Add();
            break;
          case 2:
            poster.Add();
            break;
          case 3:
            blogger.Browse();
            break;
          case 4:
            poster.Browse();
            break;
          case 5:
            Environment.Exit(0);
            break;
        }
      }
    }
  }
}
