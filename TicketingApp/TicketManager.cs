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

        public static Ticket dataLineToTicket(string[] dataLine) {
            var ticket = new Ticket();
            ticket.TicketID = int.Parse(dataLine[0]);
            ticket.Summary = dataLine[1].ToLower();
            ticket.TicketStatus = parseStringToTicketStatus(dataLine[2]); // ticketStatus parser
            ticket.Priority = parseStringToPriorityStatus(dataLine[3]); // ticketPriority parser
            ticket.Submitter = dataLine[4].ToLower();
            ticket.Assgined = dataLine[5].ToLower();
            ticket.Watching = dataLine[6].ToLower().Split('|').ToList(); 
            return ticket;
        }

        public static List<Ticket> dataToTicketList(List<string[]> data) {
            var ticketList = new List<Ticket>();
            foreach(var dataLine in data) {
                ticketList.Add(dataLineToTicket(dataLine));
            }
            return ticketList;
        }

        public static TicketStatus parseStringToTicketStatus(string stringToParse) {
            TicketStatus ticketStatus; 
            return Enum.TryParse(stringToParse, out ticketStatus) ? ticketStatus : TicketStatus.Error;
        }

        public static Priority parseStringToPriorityStatus(string stringToParse) {
            Priority priority;
            return Enum.TryParse(stringToParse, out priority) ? priority : Priority.Error;
        }
        
        public static string[] ticketToDataLine(Ticket ticket) {
            var watchers = string.Join("|", ticket.Watching.ToArray());
            string[] newDataLine = { ticket.TicketID.ToString(), ticket.Summary, 
                ticket.TicketStatus.ToString(), ticket.Priority.ToString(), ticket.Submitter, 
                ticket.Assgined, watchers};
            return newDataLine; 
        }

        public List<Ticket> searchBySummary(string searchTerm) { 
            return this.TicketList.FindAll(t => t.Summary.StartsWith(searchTerm.ToLower()));
        }

        public List<Ticket> searchBySubmitter(string searchTerm) { 
            return this.TicketList.FindAll(t => t.Submitter.StartsWith(searchTerm.ToLower()));
        }
        
        public List<Ticket> searchByWatcher(string searchTerm) {
            return this.TicketList.FindAll(t => t.Watching.Contains(searchTerm.ToLower()));
        }
        

        public List<Ticket> searchByAssigned(string searchTerm) { 
            return this.TicketList.FindAll(t => t.Assgined.StartsWith(searchTerm.ToLower()));
        }

        public List<Ticket> searchByStatus(string searchTerm) {
            TicketStatus status = Enum.TryParse(searchTerm, out status) ? status : TicketStatus.Error;
            return this.TicketList.FindAll(t => t.TicketStatus.Equals(status));
        }

        public List<Ticket> searchByProirity(string searchTerm) {
            Priority priority = Enum.TryParse(searchTerm, out priority) ? priority : Priority.Error;
            return this.TicketList.FindAll(t => t.Priority.Equals(priority));
        }

    }
}
