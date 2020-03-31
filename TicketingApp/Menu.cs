using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingApp.TicketTypes;
using TicketingApp.States;

namespace TicketingApp {
    class Menu {
        public static void displayMessage(string message) {
            Console.WriteLine(message);
        }
        public static string getStringInput() {
            return Console.ReadLine();
        }
        public static string displayTicketSelectionMenu() {
            var menu = "\n 1) Bug Tickets" +
                "\n 2) Enhacment Tickets" +
                "\n 3) Task Tickets" +
                "\n 4) Exit";
            return menu;
        }
        public static string displayTicketMenu() {
            var menu = "\n 1) Search Tickets" + 
                "\n 2) Add a Ticket" + 
                "\n 3) Select a diffrent ticket type";
            return menu;
        }
        public static string displayBugSearchMenu() {
            var menu = "\n 1) Search by Summary" +
            "\n 2) Search by Status" +
            "\n 3) Search by Priority" +
            "\n 4) Search by Submitter" +
            "\n 5) Search by Assigned" +
             "\n 6) Search by Watcher" +
            "\n 7) Search by Severity" +
            "\n 8) Display all Tickets";
            return menu;
        }
        public static string displayESearchMenu() {
            var menu = "\n 1) Search by Summary" +
            "\n 2) Search by Status" +
            "\n 3) Search by Priority" +
            "\n 4) Search by Submitter" +
            "\n 5) Search by Assigned" +
             "\n 6) Search by Watcher" +
            "\n 7) Search by Software" +
            "\n 8) Search by Cost" + 
            "\n 9) Search by Reason" + 
            "\n 10) Search by Estimate" +
            "\n 11) Display all Tickets";
            return menu;
        }


        public static string displayTaskSearchMenu() {
            var menu = "\n 1) Search by Summary" +
            "\n 2) Search by Status" +
            "\n 3) Search by Priority" +
            "\n 4) Search by Submitter" +
            "\n 5) Search by Assigned" +
             "\n 6) Search by Watcher" +
            "\n 7) Search by Severity" +
            "\n 8) Search by Task Name" +
            "\n 9) Display all Tickets";
            return menu;
        }



        public static int getInput() {
            var input = Console.ReadLine();
            int parsedInput;
            parsedInput = int.TryParse(input, out parsedInput) ? parsedInput : 0;
            if(parsedInput == 0) {
                Console.WriteLine("Please enter vaild input (a number)");
            }
            return parsedInput;
        }

        public static BugTicket GetBugTicket(TicketState state) {

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

            var newTicket = new BugTicket {
                TicketID = state.TicketList[listLength - 1].TicketID + 1,
                Summary = summary.ToLower(),
                TicketStatus = Enum.TryParse(status, out TicketStatus ticketStatus) ? ticketStatus : TicketStatus.Error, // ticketStatus parser
                Priority = Enum.TryParse(sPriority, out Priority priority) ? priority : Priority.Error, // ticketPriority parser
                Submitter = submitter.ToLower(),
                Assgined = assgined.ToLower(),
                Watching = watchers.ToLower().Split('|').ToList(),
                Severity = Enum.TryParse(sSeverity, out Severity severity) ? severity : Severity.Error
            };
            return newTicket;
        } 

        public static EnhancementTicket GetEnhancementTicket(TicketState state) {

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
            return newETicket;
        }
        public static TaskTicket GetTaskTicket(TicketState state) {
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
            return newTaskTicket;
        }
        public static void displayResults(IEnumerable<Ticket> ticketList) {
            int pageSize = 3, pageCounter = 0; 
            var ticketPage = ticketList.Take(pageSize).ToList();
            while (ticketPage.Count() > 0) {
                foreach (var ticket in ticketPage) {
                    var watchers = string.Join(", ", ticket.Watching.ToArray());
                    if (ticket is BugTicket bugTicket) {
                        Console.WriteLine($" TicketID: {bugTicket.TicketID}");
                        Console.WriteLine($" Summary: {bugTicket.Summary}");
                        Console.WriteLine($" Status: {bugTicket.TicketStatus}");
                        Console.WriteLine($" Priority: {bugTicket.Priority}");
                        Console.WriteLine($" Submitter: {bugTicket.Submitter}");
                        Console.WriteLine($" Assgined: {bugTicket.Assgined}");
                        Console.WriteLine($" Watchers: {watchers}");
                        Console.WriteLine($" Severity: {bugTicket.Severity} ");
                        Console.WriteLine("\n");
                    }
                    else if (ticket is EnhancementTicket enhancementTicket) {
                        Console.WriteLine($" TicketID: {enhancementTicket.TicketID}");
                        Console.WriteLine($" Summary: {enhancementTicket.Summary}");
                        Console.WriteLine($" Status: {enhancementTicket.TicketStatus}");
                        Console.WriteLine($" Priority: {enhancementTicket.Priority}");
                        Console.WriteLine($" Submitter: {enhancementTicket.Submitter}");
                        Console.WriteLine($" Assgined: {enhancementTicket.Assgined}");
                        Console.WriteLine($" Watchers: {watchers}"); 
                        Console.WriteLine($" Software: {enhancementTicket.Software}"); 
                        Console.WriteLine($" Cost: {enhancementTicket.Cost}"); 
                        Console.WriteLine($" Reason: {enhancementTicket.Reason}"); 
                        Console.WriteLine($" Estimate: {enhancementTicket.Estimate}");
                        Console.WriteLine("\n");
                    }
                    else if (ticket is TaskTicket taskTicket) {
                        Console.WriteLine($" TicketID: {taskTicket.TicketID}");
                        Console.WriteLine($" Summary: {taskTicket.Summary}");
                        Console.WriteLine($" Status: {taskTicket.TicketStatus}");
                        Console.WriteLine($" Priority: {taskTicket.Priority}");
                        Console.WriteLine($" Submitter: {taskTicket.Submitter}");
                        Console.WriteLine($" Assgined: {taskTicket.Assgined}");
                        Console.WriteLine($" Watchers: {watchers}"); 
                        Console.WriteLine($" Task Name: {taskTicket.TaskName}"); 
                        Console.WriteLine($" Due Date: {taskTicket.DueDate}");
                        Console.WriteLine("\n");
                    } 

                }
                Console.WriteLine("Press space to continue... Press q to quit...");
                var input = Console.ReadKey(true).Key;
                if (input == ConsoleKey.Spacebar) {
                    pageCounter++;
                    ticketPage = ticketList.Skip(pageSize * pageCounter).Take(pageSize).ToList();
                } else if (input == ConsoleKey.Q) {
                    break;
                }
            }

        } 

        public static void TicketContextMenu(TicketContext context, TicketState state, string fileName) { 
            int choice = Menu.getInput();
            switch(choice) {
                case 1:
                    Menu.displayMessage(Menu.displaySearchMenu(state)); 
                    int searchChoice = Menu.getInput(); 
                    Menu.displayResults(context.Search(searchChoice)); 
                    break; 
                case 2:
                    if (state is BugTicketState) {
                        var newTicket = Menu.GetBugTicket(state);
                        context.Write(newTicket, fileName);
                    } else if (state is EnhacementTicketState) {
                        var newTicket = GetEnhancementTicket(state);
                        context.Write(newTicket, fileName);
                    } else if (state is TaskTicketState) {
                        var newTicket = GetTaskTicket(state);
                        context.Write(newTicket, fileName);
                    }
                    
                    break; 
                case 3: 
                    break; 
            } 
        }

        private static string displaySearchMenu(TicketState state) {
            if(state is BugTicketState) {
                return Menu.displayBugSearchMenu();
            }
            else if(state is EnhacementTicketState) {
                return Menu.displayESearchMenu();
            }
            else if(state is TaskTicketState) {
                return Menu.displayTaskSearchMenu();
            }
            else {
                return "Error unknown ticket state passed";
            }
        }

        public static void TicketSwitcher(TicketContext context, TicketState state, string fileName) {
            context.ChangeState(state); 
            context.Read(fileName); 
        }

    }
}
