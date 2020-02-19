using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingApp {
    class TicketManager {
        public List<Ticket> TicketList { get; set; }

        public TicketManager(List<Ticket> ticketList) {
            this.TicketList = ticketList;
        }

        public void readTicketList(int readChoice) {
            CSVFileReader frB = new CSVFileReader(true); 
            CSVFileReader frE = new CSVFileReader(true); 
            CSVFileReader frT = new CSVFileReader(true);

            frB.readFromFile("Tickets.csv");
            frE.readFromFile("Enhancements.csv");
            frT.readFromFile("Task.csv");

            var bugTicketsData = frB.Data;
            var enhancementTicketsData = frE.Data;
            var taskTicketsData = frT.Data;

           

            switch(readChoice) {
                case 1: 
                    TicketList = TicketParser.dataToTicketList(bugTicketsData, TicketType.BugTicket);
                    break;
                case 2:
                    TicketList = TicketParser.dataToTicketList(enhancementTicketsData, TicketType.EnhancmentTicket);
                    break;
                case 3:
                    TicketList = TicketParser.dataToTicketList(taskTicketsData, TicketType.TaskTicket);
                    break;
            }



        }
 
         

        public static void addToTicketList(Ticket ticket) { 

            CSVFileWriter fwB = new CSVFileWriter();
            CSVFileWriter fwE = new CSVFileWriter();
            CSVFileWriter fwT = new CSVFileWriter();

            switch(ticket) {
                case BugTicket bugTicket: 
                    break;
                case EnhancementTicket enhancementTicket:
                    break;
                case TaskTicket taskTicket:
                    break;
            }

        }

        public List<Ticket> searchTicketList(int searchChoice) {

            SearchContex contex = new SearchContex();
            var ticketList = TicketList;

            switch(searchChoice) { 
                case 1: 
                    Console.WriteLine("Enter a Summary:");
                    contex.Strategy = new SummaryStrategy();
                    var searchSummary = Console.ReadLine();
                    return contex.DoSearch(searchSummary, ticketList);
                case 2: 
                    Console.WriteLine("Enter a Satus(Open, Closed, Pending, Resolved):");
                    contex.Strategy = new StatusStrategy();
                    var searchStatus = Console.ReadLine(); 
                    return contex.DoSearch(searchStatus, ticketList);
                case 3: 
                    Console.WriteLine("Enter a Priority(High, Medium, Low):"); 
                    contex.Strategy = new PriorityStrategy();
                    var searchPriority = Console.ReadLine();
                    return contex.DoSearch(searchPriority, ticketList);
                case 4: 
                    Console.WriteLine("Enter a Summiter:");
                    contex.Strategy = new SubmitterStrategy();
                    var searchSubmitter = Console.ReadLine(); 
                    return contex.DoSearch(searchSubmitter, ticketList);
                case 5: 
                    Console.WriteLine("Enter an Assigned:"); 
                    contex.Strategy = new AssginedStrategy();
                    var searchAssigned = Console.ReadLine();
                    return contex.DoSearch(searchAssigned, ticketList);
                case 6: 
                    Console.WriteLine("Enter a Watcher:"); 
                    contex.Strategy = new WatcherStrategy();
                    var searchWatcher = Console.ReadLine();
                    return contex.DoSearch(searchWatcher, ticketList);
                default: 
                    Console.WriteLine("Please enter a number 1-7");
                    return ticketList;
            }

        }

    }
}
