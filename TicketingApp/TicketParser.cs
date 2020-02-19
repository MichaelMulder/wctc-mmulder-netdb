using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingApp {
    class TicketParser {
        public static Ticket dataLineToTicket(string[] dataLine, TicketType ticketType) {
            switch(ticketType) {

                case TicketType.BugTicket:
                    Ticket bugTicket = new BugTicket {
                        TicketID = int.Parse(dataLine[0]),
                        Summary = dataLine[1].ToLower(),
                        TicketStatus = parseStringToTicketStatus(dataLine[2]), // ticketStatus parser
                        Priority = parseStringToPriorityStatus(dataLine[3]), // ticketPriority parser
                        Submitter = dataLine[4].ToLower(),
                        Assgined = dataLine[5].ToLower(),
                        Watching = dataLine[6].ToLower().Split('|').ToList()
                    };
                    return bugTicket;
                case TicketType.EnhancmentTicket:
                    Ticket EnhancementTicket = new EnhancementTicket {
                        TicketID = int.Parse(dataLine[0]),
                        Summary = dataLine[1].ToLower(),
                        TicketStatus = parseStringToTicketStatus(dataLine[2]), // ticketStatus parser
                        Priority = parseStringToPriorityStatus(dataLine[3]), // ticketPriority parser
                        Submitter = dataLine[4].ToLower(),
                        Assgined = dataLine[5].ToLower(),
                        Watching = dataLine[6].ToLower().Split('|').ToList() 
                    };
                    return EnhancementTicket;
                case TicketType.TaskTicket:
                    Ticket taskTicket = new TaskTicket {
                        TicketID = int.Parse(dataLine[0]),
                        Summary = dataLine[1].ToLower(),
                        TicketStatus = parseStringToTicketStatus(dataLine[2]), // ticketStatus parser
                        Priority = parseStringToPriorityStatus(dataLine[3]), // ticketPriority parser
                        Submitter = dataLine[4].ToLower(),
                        Assgined = dataLine[5].ToLower(),
                        Watching = dataLine[6].ToLower().Split('|').ToList()

                    };
                    return taskTicket;
                default:
                    return _ = new BugTicket();
            }
        }

        public static List<Ticket> dataToTicketList(List<string[]> data, TicketType ticketType) {
            var ticketList = new List<Ticket>();
            foreach(var dataLine in data) {
                ticketList.Add(dataLineToTicket(dataLine, ticketType));
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
            switch(ticket) {

                case BugTicket bugTicket:
                    string[] newBugDataLine = { 
                        ticket.TicketID.ToString(), 
                        ticket.Summary, 
                        ticket.TicketStatus.ToString(), 
                        ticket.Priority.ToString(), 
                        ticket.Submitter, 
                        ticket.Assgined, 
                        watchers
                    };
                return newBugDataLine;

                case EnhancementTicket enhancementTicket:
                    string[] newEDataLine = { 
                        ticket.TicketID.ToString(), 
                        ticket.Summary, 
                        ticket.TicketStatus.ToString(), 
                        ticket.Priority.ToString(), 
                        ticket.Submitter, 
                        ticket.Assgined, 
                        watchers
                    };
                return newEDataLine;

                case TaskTicket taskTicket:
                    string[] newTaskDataLine = { 
                        ticket.TicketID.ToString(), 
                        ticket.Summary, 
                        ticket.TicketStatus.ToString(), 
                        ticket.Priority.ToString(), 
                        ticket.Submitter, 
                        ticket.Assgined, 
                        watchers
                    };
                return newTaskDataLine;

                default:
                    string[] newDataLine = { 
                        ticket.TicketID.ToString(), 
                        ticket.Summary, 
                        ticket.TicketStatus.ToString(), 
                        ticket.Priority.ToString(), 
                        ticket.Submitter, 
                        ticket.Assgined, 
                        watchers
                    };
                    return newDataLine;
            }
        }

    }
}
