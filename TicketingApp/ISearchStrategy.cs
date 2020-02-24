using System.Collections.Generic;

namespace TicketingApp {
    interface ISearchStrategy {
        List<Ticket> Search(string searchTerm, List<Ticket> ticketList);
    }
}