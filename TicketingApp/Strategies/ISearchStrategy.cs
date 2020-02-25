using System.Collections.Generic;
using TicketingApp.TicketTypes;

namespace TicketingApp {
    interface ISearchStrategy {
        List<Ticket> Search(string searchTerm, List<Ticket> ticketList);
    }
}