using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingApp {
    class Menu {
        public static string displayTicketMenu() {
            var menu = "\n 1) Search Tickets" + 
                "\n 2) Add a Ticket" + 
                "\n 3) Exit";
            return menu;
        }
    }
}
