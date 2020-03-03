using System.Collections.Generic;
using TicketingApp.TicketTypes;

namespace TicketingApp.Strategies {
    interface ISearchStrategy {
        IEnumerable<Ticket> Search(string searchTerm, List<Ticket> ticketList);
    }
}