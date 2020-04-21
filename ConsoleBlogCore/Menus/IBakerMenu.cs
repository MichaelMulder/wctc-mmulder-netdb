using System.Collections.Generic;
using ConsoleBlogCore.Bakers;

namespace ConsoleBlogCore.Menus {
    interface IBakerMenu : IMenu {
        void editMenu();
        static void bakerMenu(IMakeBread baker) {
            int bakerChoice = 0;
            bakerChoice = MenuHelpers.getIntInput();
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


    }
}