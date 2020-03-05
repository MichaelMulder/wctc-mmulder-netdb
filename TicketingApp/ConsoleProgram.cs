using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingApp.Strategies;
using TicketingApp.FileManager;
using TicketingApp.TicketTypes;
using TicketingApp.States;

namespace TicketingApp {
    class ConsoleProgram {
        public string bugTicketsFile { get; set; }
        public string enhancmentTicketsFile { get; set; }
        public string TaskTicketsFile { get; set; }
        public ConsoleProgram(string bugFile, string enhacmentFile, string taskFile) {
            this.bugTicketsFile = bugFile;
            this.enhancmentTicketsFile = enhacmentFile;
            this.TaskTicketsFile = taskFile;
        }
        public void Run() {
            int choice = 0;
            while (choice < 4) {
                Menu.displayMessage(Menu.displayTicketSelectionMenu());
                choice = Menu.getInput();
                TicketContext context = new TicketContext();
                TicketState state;
                switch(choice) {
                    case 1:
                        state = new BugTicketState();
                        Menu.TicketSwitcher(context, state, bugTicketsFile);
                        Menu.displayMessage(Menu.displayTicketMenu());
                        Menu.TicketContextMenu(context, state, bugTicketsFile);
                        break;
                    case 2: 
                        state = new EnhacementTicketState(); 
                        Menu.TicketSwitcher(context, state, enhancmentTicketsFile);
                        Menu.displayMessage(Menu.displayTicketMenu());
                        Menu.TicketContextMenu(context, state, enhancmentTicketsFile);
                        break;
                    case 3: 
                        state = new TaskTicketState(); 
                        Menu.TicketSwitcher(context, state, TaskTicketsFile);
                        Menu.displayMessage(Menu.displayTicketMenu()); 
                        Menu.TicketContextMenu(context, state, TaskTicketsFile);
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                }

            }

        }
    }
}
