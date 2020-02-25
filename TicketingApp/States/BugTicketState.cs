using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingApp.FileManager;

namespace TicketingApp {
    class BugTicketState : TicketState {

        public BugTicketState() {
            IParseStrategy strategy = new BugTicketParser();
            this.ParseContext = new ParseContext {
                Strategy = strategy
            };
        }

        public override void ReadTickets(string fileName) {
            CSVFileReader fr = new CSVFileReader(true);
            fr.readFromFile(fileName);

            var data = fr.Data;

            this.TicketList = ParseContext.DoParseForTickets(data); 
        }

        public override List<Ticket> SearchTickets(int searchChoice) {
            this.SearchContext = new SearchContext();
            var ticketList = TicketList;

            switch(searchChoice) { 
                case 1: 
                    Console.WriteLine("Enter a Summary:");
                    SearchContext.Strategy = new SummaryStrategy();
                    var searchSummary = Console.ReadLine();
                    return SearchContext.DoSearch(searchSummary, ticketList);
                case 2: 
                    Console.WriteLine("Enter a Satus(Open, Closed, Pending, Resolved):");
                    SearchContext.Strategy = new StatusStrategy();
                    var searchStatus = Console.ReadLine(); 
                    return SearchContext.DoSearch(searchStatus, ticketList);
                case 3: 
                    Console.WriteLine("Enter a Priority(High, Medium, Low):"); 
                    SearchContext.Strategy = new PriorityStrategy();
                    var searchPriority = Console.ReadLine();
                    return SearchContext.DoSearch(searchPriority, ticketList);
                case 4: 
                    Console.WriteLine("Enter a Summiter:");
                    SearchContext.Strategy = new SubmitterStrategy();
                    var searchSubmitter = Console.ReadLine(); 
                    return SearchContext.DoSearch(searchSubmitter, ticketList);
                case 5: 
                    Console.WriteLine("Enter an Assigned:"); 
                    SearchContext.Strategy = new AssginedStrategy();
                    var searchAssigned = Console.ReadLine();
                    return SearchContext.DoSearch(searchAssigned, ticketList);
                case 6: 
                    Console.WriteLine("Enter a Watcher:"); 
                    SearchContext.Strategy = new WatcherStrategy();
                    var searchWatcher = Console.ReadLine();
                    return SearchContext.DoSearch(searchWatcher, ticketList);
                default: 
                    Console.WriteLine("Please enter a number 1-7");
                    return ticketList;
            }

        }

        public override void WriteTicket(Ticket ticket, string fileName) {
            CSVFileWriter fw = new CSVFileWriter(); 

            var dataline = ParseContext.DoParseForData(ticket);

            fw.writeToFile(dataline, fileName);
        }

    }
}
