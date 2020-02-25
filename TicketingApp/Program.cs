using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingApp.States;
using TicketingApp.TicketTypes;
using TicketingApp.FileManager;
using TicketingApp.Strategies;

namespace TicketingApp {
    class Program {
        static void Main(string[] args) {
            int choice = 0;
            string bugTicketsFile = AppDomain.CurrentDomain.BaseDirectory + "Tickets.csv";
            string enhancmentTicketsFile = AppDomain.CurrentDomain.BaseDirectory + "Enhancements.csv";
            string TaskTicketsFile = AppDomain.CurrentDomain.BaseDirectory + "Task.csv";

            while (choice != 4) {
                Console.WriteLine(Menu.displayTicketSelectionMenu());
                choice = Menu.getInput();
                TicketContext context = new TicketContext();
                TicketState state;
                switch(choice) {
                    case 1:
                        state = new BugTicketState(); 
                        context.ChangeState(state); 
                        context.Read(bugTicketsFile);
                        Console.WriteLine(Menu.displayTicketMenu());
                        int bugTicketChoice = Menu.getInput();
                        switch(bugTicketChoice) {
                            case 1:
                                Console.WriteLine(Menu.displaySearchMenu());
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
                        Console.WriteLine(Menu.displayTicketMenu());
                        int eTicketChoice = Menu.getInput();
                        switch(eTicketChoice) {
                            case 1:
                                Console.WriteLine(Menu.displaySearchMenu());
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
                        Console.WriteLine(Menu.displayTicketMenu());
                        int taskTicketChoice = Menu.getInput();
                        switch(taskTicketChoice) {
                            case 1:
                                Console.WriteLine(Menu.displaySearchMenu());
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
                        Environment.Exit(0);
                        break;
                }

            }
        }
        
    }
}
