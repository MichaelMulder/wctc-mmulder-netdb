using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingApp {
    class TaskTicket : Ticket {
        public string TaskName { get; set; }
        public string DueDate { get; set; }
    }
}
