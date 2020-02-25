using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<< HEAD:TicketingApp/Ticket.cs
namespace TicketingApp {
    class Ticket {
=======
namespace TicketingApp.TicketTypes {
    abstract class Ticket {
>>>>>>> cc8ed5b... Reoragnized and Refactoring:TicketingApp/TicketTypes/Ticket.cs
        public int TicketID { get; set; }
        public string Summary { get; set; } 
        public TicketStatus TicketStatus { get; set; }
        public Priority Priority { get; set; }
        public string Submitter { get; set; }
        public string Assgined { get; set; }
        public List<string> Watching { get; set; }

    }
}
