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
                                        displayResults(ticketM.searchBySummary(searchSummary));
                                        break;
                                    case 2:
                                        Console.WriteLine("Enter a Satus(Open, Closed, Pending, Resolved):");
                                        var searchSatus = Console.ReadLine();
                                        displayResults(ticketM.searchByStatus(searchSatus));

                                        break;
                                    case 3: 
                                        Console.WriteLine("Enter a Priority(High, Medium, Low):");
                                        var searchPriority = Console.ReadLine();
                                        displayResults(ticketM.searchByProirity(searchPriority));
                                        break;
                                    case 4:
                                        Console.WriteLine("Enter a Summiter:");
                                        var searchSubmitter = Console.ReadLine();
                                        displayResults(ticketM.searchBySubmitter(searchSubmitter));
                                        break;
                                    case 5:
                                        Console.WriteLine("Enter an Assigned:");
                                        var searchAssigned = Console.ReadLine();
                                        displayResults(ticketM.searchByAssigned(searchAssigned));
                                        break;
                                    case 6:
                                        Console.WriteLine("Enter a Watcher:");
                                        var searchWatcher = Console.ReadLine();
                                        displayResults(ticketM.searchByWatcher(searchWatcher));
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

                            newTicket.TicketStatus = TicketManager.parseStringToTicketStatus(status);

                            Console.WriteLine("Enter priority of status(High, Medium, Low):");

                            string priority = Console.ReadLine();

                            newTicket.Priority = TicketManager.parseStringToPriorityStatus(priority);

                            Console.WriteLine("Who is summiting this ticket:");

                            newTicket.Submitter = Console.ReadLine();

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
        static void displayResults(List<Ticket> ticketList) {
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
                        Console.WriteLine($" TicketID: {ticket.TicketID}");
                        Console.WriteLine($" Summary: {ticket.Summary}");
                        Console.WriteLine($" Status: {ticket.TicketStatus}");
                        Console.WriteLine($" Priority: {ticket.Priority}");
                        Console.WriteLine($" Submitter: {ticket.Submitter}");
                        Console.WriteLine($" Assgined: {ticket.Assgined}");
                        Console.WriteLine($" Watchers: {watchers}");
                        Console.WriteLine("\n");
                    }
                    else if (ticket is TaskTicket taskTicket) {
                        Console.WriteLine($" TicketID: {ticket.TicketID}");
                        Console.WriteLine($" Summary: {ticket.Summary}");
                        Console.WriteLine($" Status: {ticket.TicketStatus}");
                        Console.WriteLine($" Priority: {ticket.Priority}");
                        Console.WriteLine($" Submitter: {ticket.Submitter}");
                        Console.WriteLine($" Assgined: {ticket.Assgined}");
                        Console.WriteLine($" Watchers: {watchers}");
                        Console.WriteLine("\n");
                    } 

                }
                Console.WriteLine("Press space to conintue... Press q to quit...");
                var input = Console.ReadKey(true).Key;
                if (input == ConsoleKey.Spacebar) {
                    pageCounter++;
                    ticketPage = ticketList.Skip(pageSize * pageCounter).Take(pageSize).ToList();
                } else if (input == ConsoleKey.Q) {
                    break;
                }
            }

        }

    }
}
