using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingApp.TicketTypes;

namespace TicketingApp.Strategies {
    class SummaryStrategy : ISearchStrategy {
        public IEnumerable<Ticket> Search(string searchTerm, List<Ticket> ticketList) { 
            return ticketList.Where(t => t.Summary.StartsWith(searchTerm.ToLower()));
        }
    }
    class SubmitterStrategy : ISearchStrategy {
        public IEnumerable<Ticket> Search(string searchTerm, List<Ticket> ticketList) { 
            return ticketList.Where(t => t.Submitter.StartsWith(searchTerm.ToLower()));
        }
    }
    class WatcherStrategy : ISearchStrategy {
        public IEnumerable<Ticket> Search(string searchTerm, List<Ticket> ticketList) { 
            return ticketList.Where(t => t.Watching.Contains(searchTerm.ToLower()));
        }
    }
    class AssginedStrategy : ISearchStrategy {
        public IEnumerable<Ticket> Search(string searchTerm, List<Ticket> ticketList) {
            return ticketList.Where(t => t.Assgined.StartsWith(searchTerm.ToLower()));
        }
    }
    class PriorityStrategy : ISearchStrategy {
        public IEnumerable<Ticket> Search(string searchTerm, List<Ticket> ticketList) {
            Priority priority = Enum.TryParse(searchTerm, out priority) ? priority : Priority.Error;
            return ticketList.Where(t => t.Priority.Equals(priority)); 
        }
    }
    class StatusStrategy : ISearchStrategy {
        public IEnumerable<Ticket> Search(string searchTerm, List<Ticket> ticketList) {
            TicketStatus status = Enum.TryParse(searchTerm, out status) ? status : TicketStatus.Error;
            return ticketList.Where(t => t.TicketStatus.Equals(status));
        } 
        // TODO Implment search for each ticket type 
        // May have to need a ticket search unqine for each kind of ticket 
    }

    class SeverityStrategy : ISearchStrategy {
        public IEnumerable<Ticket> Search(string searchTerm, List<Ticket> ticketList) {
            Severity severity = Enum.TryParse(searchTerm, out severity) ? severity : Severity.Error;
            var bugTicketList = ticketList.Cast<BugTicket>();
            return bugTicketList.Where(t => t.Severity.Equals(severity));
        }
    }
    class SoftwareStrategy : ISearchStrategy {
        public IEnumerable<Ticket> Search(string searchTerm, List<Ticket> ticketList) {
            var enhacmentList = ticketList.Cast<EnhancementTicket>();
            return enhacmentList.Where(t => t.Software.Contains(searchTerm));
        }
    }

    class CostStrategy : ISearchStrategy {
        public IEnumerable<Ticket> Search(string searchTerm, List<Ticket> ticketList) { 
            var enhacmentList = ticketList.Cast<EnhancementTicket>();

            decimal costSearch = decimal.TryParse(searchTerm, out costSearch) ? costSearch : 0;

            return enhacmentList.Where(t => t.Cost.Equals(costSearch)); 
        }
    } 
    class ReasonStrategy : ISearchStrategy {
        public IEnumerable<Ticket> Search(string searchTerm, List<Ticket> ticketList) { 
            var enhacmentList = ticketList.Cast<EnhancementTicket>();
            return enhacmentList.Where(t => t.Reason.Contains(searchTerm));
        }
    } 
    class EstimateStrategy : ISearchStrategy {
        public IEnumerable<Ticket> Search(string searchTerm, List<Ticket> ticketList) { 
            var enhacmentList = ticketList.Cast<EnhancementTicket>();
            return enhacmentList.Where(t => t.Estimate.Contains(searchTerm));
        }
    }

    class TaskNameStrategy : ISearchStrategy {
        public IEnumerable<Ticket> Search(string searchTerm, List<Ticket> ticketList) {
            var taskList = ticketList.Cast<TaskTicket>();
            return taskList.Where(t => t.TaskName.Contains(searchTerm));
        }
    }

    class DueDateStrategy : ISearchStrategy {
        public IEnumerable<Ticket> Search(string searchTerm, List<Ticket> ticketList) {
            var taskList = ticketList.Cast<TaskTicket>();
            return taskList.Where(t => t.DueDate.Contains(searchTerm));
        }
    }

}
