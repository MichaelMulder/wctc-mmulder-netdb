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
            string fileName = "Tickets.csv";

            CSVFileReader fr = new CSVFileReader(true);

            fr.readFromFile(fileName);

            string[] headers = fr.Headers;
            var data = fr.Data;

            var ticketList = TicketManager.dataToTicketList(data);

            var ticketM = new TicketManager(ticketList);

            fr.readFromFile(fileName);
            while (choice != 3) {
                Console.WriteLine("1) Search Tickets");
                Console.WriteLine("2) Add a Ticket");
                Console.WriteLine("3) Exit");

                string input = Console.ReadLine();

                if (int.TryParse(input, out choice)) {

                    switch (choice) {
                        case 1:
                            Console.WriteLine("1) Search by Summary");
                            Console.WriteLine("2) Search by Status");
                            Console.WriteLine("3) Search by Priority"); 
                            Console.WriteLine("4) Search by Submitter"); 
                            Console.WriteLine("5) Search by Assigned"); 
                            Console.WriteLine("6) Search by Watcher");
                            Console.WriteLine("7) Display all Tickets");

                            int searchChoice;
                            string searchInput = Console.ReadLine();
                            if(int.TryParse(searchInput, out searchChoice)) {
                                switch (searchChoice) { 
                                    case 1:
                                        Console.WriteLine("Enter a Summary:");
                                        var searchSummary = Console.ReadLine();
                                        displayResults(ticketM.searchBySummary(searchSummary), headers);
                                        break;
                                    case 2:
                                        Console.WriteLine("Enter a Satus(Open, Colsed, Pending, Resolved):");
                                        var searchSatus = Console.ReadLine();
                                        displayResults(ticketM.searchByStatus(searchSatus), headers);

                                        break;
                                    case 3: 
                                        Console.WriteLine("Enter a Priority(High, Medium, Low):");
                                        var searchPriority = Console.ReadLine();
                                        displayResults(ticketM.searchByProirity(searchPriority), headers);
                                        break;
                                    case 4:
                                        Console.WriteLine("Enter a Summiter:");
                                        var searchSubmitter = Console.ReadLine();
                                        displayResults(ticketM.searchBySubmitter(searchSubmitter), headers);
                                        break;
                                    case 5:
                                        Console.WriteLine("Enter an Assigned:");
                                        var searchAssigned = Console.ReadLine();
                                        displayResults(ticketM.searchByAssigned(searchAssigned), headers);
                                        break;
                                    case 6:
                                        Console.WriteLine("Enter a Watcher:");
                                        var searchWatcher = Console.ReadLine();
                                        displayResults(ticketM.searchByWatcher(searchWatcher), headers);
                                        break;
                                    default: 
                                        Console.WriteLine("Please enter a number 1-7");
                                        break;
                                }
                            }
                            break;
                        case 2:
                            CSVFileWriter fw = new CSVFileWriter();

                            var newTicket = new Ticket();

                            newTicket.TicketID = ticketList[ticketList.Count - 1].TicketID + 1;

                            Console.WriteLine("Write summary for ticket:");

                            newTicket.Summary = Console.ReadLine();

                            Console.WriteLine("Enter status of ticket(Open, Closed, Pending, Resovled):");

                            string status = Console.ReadLine();

<<<<<<< HEAD
                            newTicket.TicketStatus = TicketManager.parseStringToTicketStatus(status);
=======
                                state.TicketList.Add(newTicket);

                                context.Write(newTicket, bugTicketsFile);
>>>>>>> c7b62d6... now adds to ticket list after getting newTicket data from user

                            Console.WriteLine("Enter priority of status(High, Medium, Low):");

                            string priority = Console.ReadLine();

                            newTicket.Priority = TicketManager.parseStringToPriorityStatus(priority);

                            Console.WriteLine("Who is summiting this ticket:");

                            newTicket.Submitter = Console.ReadLine();

<<<<<<< HEAD
                            Console.WriteLine("Who is assigned for this ticket:");

                            newTicket.Assgined = Console.ReadLine();

                            Console.WriteLine("Who is watching this ticket(seperated by |):");
                            string watchers = Console.ReadLine();

                            newTicket.Watching = watchers.Split('|').ToList();

                            ticketList.Add(newTicket);

                            string[] newDataLine = TicketManager.ticketToDataLine(newTicket);
                            fw.writeToFile(newDataLine, fileName);

                            break;
                        case 3:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Please input a 1, 2, or 3");
                            break;
                    }
                }
            }
        }
        static void displayResults(List<Ticket> ticketList, string[] headers) {
            int pageSize = 3, pageCounter = 0; 
            var ticketPage = ticketList.Take(pageSize).ToList();
            while (ticketPage.Count() > 0) {
                foreach (var ticket in ticketPage) {
                    var watchers = string.Join(", ", ticket.Watching.ToArray());
                    Console.WriteLine($" {headers[0]}: {ticket.TicketID}");
                    Console.WriteLine($"{headers[1]}: {ticket.Summary}");
                    Console.WriteLine($"{headers[2]}: {ticket.TicketStatus}");
                    Console.WriteLine($"{headers[3]}: {ticket.Priority}");
                    Console.WriteLine($"{headers[4]}: {ticket.Submitter}");
                    Console.WriteLine($"{headers[5]}: {ticket.Assgined}");
                    Console.WriteLine($"{headers[6]}: {watchers}");
                    Console.WriteLine("\n");
                }
                Console.WriteLine("Press space to conintue... Press q to quit...");
                var input = Console.ReadKey(true).Key;
                if (input == ConsoleKey.Spacebar) {
                    pageCounter++;
                    ticketPage = ticketList.Skip(pageSize * pageCounter).Take(pageSize).ToList();
                } else if (input == ConsoleKey.Q) {
                    break;
=======

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
>>>>>>> c7b62d6... now adds to ticket list after getting newTicket data from user
                }
            }

        }

    }
}
