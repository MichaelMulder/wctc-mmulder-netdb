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
            while (choice != 3) {
                Menu.displayMessage(Menu.displayTicketSelectionMenu());
                choice = Menu.getInput();
                TicketContext context = new TicketContext();
                TicketState state;
                switch(choice) {
                    case 1:
                        state = new BugTicketState(); 
                        context.ChangeState(state); 
                        context.Read(bugTicketsFile);
                        Menu.displayMessage(Menu.displayTicketMenu());
                        int bugTicketChoice = Menu.getInput();
                        switch(bugTicketChoice) {
                            case 1:
                                Menu.displayMessage(Menu.displaySearchMenu());
                                int searchChoice = Menu.getInput();
                                Menu.displayResults(context.Search(searchChoice));
                                break;
                            case 2:
                                var newTicket = Menu.GetBugTicket(state);
                                state.TicketList.Add(newTicket);

                                context.Write(newTicket, bugTicketsFile);

                                break;
                            case 3:
                                break;
                        }
                        break;
                    case 2: 
                        state = new EnhacementTicketState(); 
                        context.ChangeState(state);
                        context.Read(enhancmentTicketsFile);
                        Menu.displayMessage(Menu.displayTicketMenu());
                        int eTicketChoice = Menu.getInput();
                        switch(eTicketChoice) {
                            case 1:
                                Menu.displayMessage(Menu.displaySearchMenu());
                                int searchChoice = Menu.getInput();
                                Menu.displayResults(context.Search(searchChoice));
                                break;
                            case 2:
                                var newETicket = Menu.GetEnhancementTicket(state);
                                state.TicketList.Add(newETicket);

                                context.Write(newETicket, enhancmentTicketsFile); 

                                break;
                            case 3:
                                break;
                        }
                        break;
                    case 3: 
                        state = new TaskTicketState(); 
                        context.ChangeState(state);
                        context.Read(TaskTicketsFile);
                        Menu.displayMessage(Menu.displayTicketMenu());
                        int taskTicketChoice = Menu.getInput();
                        switch(taskTicketChoice) {
                            case 1:
                                Menu.displayMessage(Menu.displaySearchMenu());
                                int searchChoice = Menu.getInput();
                                Menu.displayResults(context.Search(searchChoice));
                                break;
                            case 2:
                                var newTaskTicket = Menu.GetTaskTicket(state);
                                state.TicketList.Add(newTaskTicket);
                                context.Write(newTaskTicket, TaskTicketsFile); 

                                break;
                            case 3:
                                break;
                        }
                        break;
                    case 4:
                        Environment.Exit(-1);
                        break;
                }

            }

        }
    }
}
