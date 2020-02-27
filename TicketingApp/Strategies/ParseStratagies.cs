using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingApp.TicketTypes;

namespace TicketingApp.Strategies {
    class BugTicketParser : IParseStrategy {
        public List<Ticket> ParseDataForTickets(List<string[]> data) {
            var ticketList = new List<Ticket>();
            data.ForEach(dataLine => {
                TicketStatus ticketStatus;
                Priority priority;
                Severity severity;
                Ticket bugTicket = new BugTicket {
                    TicketID = int.Parse(dataLine[0]),
                    Summary = dataLine[1].ToLower(),
                    TicketStatus = Enum.TryParse(dataLine[2], out ticketStatus) ? ticketStatus : TicketStatus.Error, // ticketStatus parser
                    Priority = Enum.TryParse(dataLine[3], out priority) ? priority : Priority.Error, // ticketPriority parser
                    Submitter = dataLine[4].ToLower(),
                    Assgined = dataLine[5].ToLower(),
                    Watching = dataLine[6].ToLower().Split('|').ToList(),
                    Severity = Enum.TryParse(dataLine[7], out severity) ? severity : Severity.Error
                };
                ticketList.Add(bugTicket);
            });
            return ticketList;
        }

        public string[] ParseTicketForData(Ticket ticket) {
            var watchers = string.Join("|", ticket.Watching.ToArray());
            var bugTicket = (BugTicket)ticket;
            string[] newDataLine = {
                bugTicket.TicketID.ToString(),
                bugTicket.Summary,
                bugTicket.TicketStatus.ToString(),
                bugTicket.Priority.ToString(),
                bugTicket.Submitter,
                bugTicket.Assgined,
                watchers,
                bugTicket.Severity.ToString()
            };
            return newDataLine;
        }
    }

    class EnhacementTicketParser : IParseStrategy {
        public List<Ticket> ParseDataForTickets(List<string[]> data) {
            var ticketList = new List<Ticket>();
            data.ForEach(dataLine => {
                TicketStatus ticketStatus;
                Priority priority;
                decimal cost;
                Ticket eTicket = new EnhancementTicket {
                    TicketID = int.Parse(dataLine[0]),
                    Summary = dataLine[1].ToLower(),
                    TicketStatus = Enum.TryParse(dataLine[2], out ticketStatus) ? ticketStatus : TicketStatus.Error, // ticketStatus parser
                    Priority = Enum.TryParse(dataLine[3], out priority) ? priority : Priority.Error, // ticketPriority parser
                    Submitter = dataLine[4].ToLower(),
                    Assgined = dataLine[5].ToLower(),
                    Watching = dataLine[6].ToLower().Split('|').ToList(),
                    Software = dataLine[7].ToLower(),
                    Cost = decimal.TryParse(dataLine[8], out cost) ? cost : 0,
                    Reason = dataLine[8].ToLower(),
                    Estimate = dataLine[9].ToLower()
                };
                ticketList.Add(eTicket);
            });
            return ticketList; 
        }

        public string[] ParseTicketForData(Ticket ticket) {
            var watchers = string.Join("|", ticket.Watching.ToArray());
            var eTicket = (EnhancementTicket)ticket;
            string[] newDataLine = {
                eTicket.TicketID.ToString(),
                eTicket.Summary,
                eTicket.TicketStatus.ToString(),
                eTicket.Priority.ToString(),
                eTicket.Submitter,
                eTicket.Assgined,
                watchers,
                eTicket.Software,
                eTicket.Cost.ToString(),
                eTicket.Reason,
                eTicket.Estimate
            };
            return newDataLine; 
        }
    }

    class TaskTicketParser : IParseStrategy {
        public List<Ticket> ParseDataForTickets(List<string[]> data) {
            var ticketList = new List<Ticket>();
            data.ForEach(dataLine => {
                TicketStatus ticketStatus;
                Priority priority;
                Ticket taskTicket = new TaskTicket {
                    TicketID = int.Parse(dataLine[0]),
                    Summary = dataLine[1].ToLower(),
                    TicketStatus = Enum.TryParse(dataLine[2], out ticketStatus) ? ticketStatus : TicketStatus.Error, // ticketStatus parser
                    Priority = Enum.TryParse(dataLine[3], out priority) ? priority : Priority.Error, // ticketPriority parser
                    Submitter = dataLine[4].ToLower(),
                    Assgined = dataLine[5].ToLower(),
                    Watching = dataLine[6].ToLower().Split('|').ToList(),
                    TaskName = dataLine[7].ToLower(),
                    DueDate = dataLine[8].ToLower()
                };
                ticketList.Add(taskTicket);
            });
            return ticketList; 
        }

        public string[] ParseTicketForData(Ticket ticket) {
            var watchers = string.Join("|", ticket.Watching.ToArray());
            var taskTicket = (TaskTicket)ticket;
            string[] newDataLine = {
                taskTicket.TicketID.ToString(),
                taskTicket.Summary,
                taskTicket.TicketStatus.ToString(),
                taskTicket.Priority.ToString(),
                taskTicket.Submitter,
                taskTicket.Assgined,
                watchers,
                taskTicket.TaskName,
                taskTicket.DueDate
            };
            return newDataLine;
        }
    }
}
