using System;

namespace ConsoleBlogCore.Menus {
  class MainMenu : IMenu {
    public void displayMenu() {
        var menu = "\n 1) Manage Blogs" +
                "\n 2) Manage Posts" +
                "\n 3) Exit";

        Console.WriteLine(menu);
    }
  }
}