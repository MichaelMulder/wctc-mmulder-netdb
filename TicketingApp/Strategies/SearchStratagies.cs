using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingApp.TicketTypes;
namespace TicketingApp.Strategies {
    class SummaryStrategy : ISearchStrategy {
        public List<Ticket> Search(string searchTerm, List<Ticket> ticketList) { 
            return ticketList.FindAll(t => t.Summary.StartsWith(searchTerm.ToLower()));
        }
    }
    class SubmitterStrategy : ISearchStrategy {
        public List<Ticket> Search(string searchTerm, List<Ticket> ticketList) { 
            return ticketList.FindAll(t => t.Submitter.StartsWith(searchTerm.ToLower()));
        }
    }
    class WatcherStrategy : ISearchStrategy {
        public List<Ticket> Search(string searchTerm, List<Ticket> ticketList) { 
            return ticketList.FindAll(t => t.Watching.Contains(searchTerm.ToLower()));
        }
    }
    class AssginedStrategy : ISearchStrategy {
        public List<Ticket> Search(string searchTerm, List<Ticket> ticketList) {
            return ticketList.FindAll(t => t.Assgined.StartsWith(searchTerm.ToLower()));
        }
    }
    class PriorityStrategy : ISearchStrategy {
        public List<Ticket> Search(string searchTerm, List<Ticket> ticketList) {
            Priority priority = Enum.TryParse(searchTerm, out priority) ? priority : Priority.Error;
            return ticketList.FindAll(t => t.Priority.Equals(priority)); 
        }
    }
    class StatusStrategy : ISearchStrategy {
        public List<Ticket> Search(string searchTerm, List<Ticket> ticketList) {
            TicketStatus status = Enum.TryParse(searchTerm, out status) ? status : TicketStatus.Error;
            return ticketList.FindAll(t => t.TicketStatus.Equals(status));
        } 
        // TODO Implment search for each ticket type 
        // May have to need a ticket search unqine for each kind of ticket 
    }

    //class SeverityStrategy : ISearchStrategy {
    //    public List<Ticket> Search(string searchTerm, List<Ticket> ticketList) {
            
    //        Severity severity = Enum.TryParse(searchTerm, out severity) ? severity : Severity.Error; 
    //        return ticketList.FindAll(t => t.Severity.Equals(severity));
    //    } 

    //} 
    //class SoftwareStrategy : ISearchStrategy {
    //    public List<Ticket> Search(string searchTerm, List<Ticket> ticketList) {
    //        Severity severity = Enum.TryParse(searchTerm, out severity) ? severity : Severity.Error; 
    //        return ticketList.FindAll(t => t.TicketStatus.Equals(severity));
    //    } 

    //}


}
