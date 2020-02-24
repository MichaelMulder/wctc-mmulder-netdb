using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingApp {
    class EnhancementTicket : Ticket {
        public string Software { get; set; }
        public decimal Cost { get; set; }
        public string Reason { get; set; }
        public string Estimate { get; set; }
    }
}
