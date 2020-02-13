using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingApp {
    class Ticket {
        public int TicketID { get; set; }
        public string Summary { get; set; } 
        public TicketStatus TicketStatus { get; set; }
        public Priority Priority { get; set; }
        public string Submitter { get; set; }
        public string Assgined { get; set; }
        public List<string> Watching { get; set; }

    }
}
