using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                                var listLength = state.TicketList.Count; 

                                Console.WriteLine("Write summary for ticket:");

                                string summary = Console.ReadLine();

                                Console.WriteLine("Enter status of ticket(Open, Closed, Pending, Resovled):");

                                string status = Console.ReadLine();


                                Console.WriteLine("Enter priority of status(High, Medium, Low):");

                                string sPriority = Console.ReadLine(); 

                                Console.WriteLine("Who is summiting this ticket:");

                                string submitter = Console.ReadLine();

                                Console.WriteLine("Who is assigned for this ticket:");

                                string assgined = Console.ReadLine();

                                Console.WriteLine("Who is watching this ticket(seperated by |):");
                                string watchers = Console.ReadLine();

                                Console.WriteLine("What is the severity of the bug(Minor, Major, Critical):");
                                string sSeverity = Console.ReadLine();

                                var newTicket = new BugTicket{ 
                                    TicketID = state.TicketList[listLength - 1].TicketID + 1,
                                    Summary = summary.ToLower(),
                                    TicketStatus = Enum.TryParse(status, out TicketStatus ticketStatus) ? ticketStatus : TicketStatus.Error, // ticketStatus parser
                                    Priority = Enum.TryParse(sPriority, out Priority priority) ? priority : Priority.Error, // ticketPriority parser
                                    Submitter = submitter.ToLower(),
                                    Assgined = assgined.ToLower(),
                                    Watching = watchers.ToLower().Split('|').ToList(),
                                    Severity = Enum.TryParse(sSeverity, out Severity severity) ? severity : Severity.Error 
                                };

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
                                var listLength = state.TicketList.Count; 

                                Console.WriteLine("Write summary for ticket:");

                                string summary = Console.ReadLine();

                                Console.WriteLine("Enter status of ticket(Open, Closed, Pending, Resovled):");

                                string status = Console.ReadLine();


                                Console.WriteLine("Enter priority of status(High, Medium, Low):");

                                string sPriority = Console.ReadLine(); 

                                Console.WriteLine("Who is summiting this ticket:");

                                string submitter = Console.ReadLine();

                                Console.WriteLine("Who is assigned for this ticket:");

                                string assgined = Console.ReadLine();

                                Console.WriteLine("Who is watching this ticket(seperated by |):");
                                string watchers = Console.ReadLine();

                                Console.WriteLine("What is the software:");
                                string software = Console.ReadLine();

                                Console.WriteLine("What is the cost (ex. 1.00)");
                                string sCost = Console.ReadLine();

                                Console.WriteLine("What is the reason");
                                string reason = Console.ReadLine(); 

                                Console.WriteLine("What is the estimate");
                                string estimate = Console.ReadLine(); 

                                var newETicket = new EnhancementTicket {
                                    TicketID = state.TicketList[listLength - 1].TicketID + 1,
                                    Summary = summary.ToLower(),
                                    TicketStatus = Enum.TryParse(status, out TicketStatus ticketStatus) ? ticketStatus : TicketStatus.Error, // ticketStatus parser
                                    Priority = Enum.TryParse(sPriority, out Priority priority) ? priority : Priority.Error, // ticketPriority parser
                                    Submitter = submitter.ToLower(),
                                    Assgined = assgined.ToLower(),
                                    Watching = watchers.ToLower().Split('|').ToList(),
                                    Software = software.ToLower(),
                                    Cost = decimal.TryParse(sCost, out decimal cost) ? cost : 0,
                                    Reason = reason.ToLower(),
                                    Estimate = estimate.ToLower()
                                };

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
                                var listLength = state.TicketList.Count; 

                                Console.WriteLine("Write summary for ticket:");

                                string summary = Console.ReadLine();

                                Console.WriteLine("Enter status of ticket(Open, Closed, Pending, Resovled):");

                                string status = Console.ReadLine();


                                Console.WriteLine("Enter priority of status(High, Medium, Low):");

                                string sPriority = Console.ReadLine(); 

                                Console.WriteLine("Who is summiting this ticket:");

                                string submitter = Console.ReadLine();

                                Console.WriteLine("Who is assigned for this ticket:");

                                string assgined = Console.ReadLine();

                                Console.WriteLine("Who is watching this ticket(seperated by |):");
                                string watchers = Console.ReadLine();

                                Console.WriteLine("What is the Task Name:");
                                string taskName = Console.ReadLine();

                                Console.WriteLine("What is the Due Date:");
                                string dueDate = Console.ReadLine();




                                var newTaskTicket = new TaskTicket {
                                    TicketID = state.TicketList[listLength - 1].TicketID + 1,
                                    Summary = summary.ToLower(),
                                    TicketStatus = Enum.TryParse(status, out TicketStatus ticketStatus) ? ticketStatus : TicketStatus.Error, // ticketStatus parser
                                    Priority = Enum.TryParse(sPriority, out Priority priority) ? priority : Priority.Error, // ticketPriority parser
                                    Submitter = submitter.ToLower(),
                                    Assgined = assgined.ToLower(),
                                    Watching = watchers.ToLower().Split('|').ToList(),
                                    TaskName = taskName.ToLower(),
                                    DueDate = dueDate.ToLower()
                                };

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
