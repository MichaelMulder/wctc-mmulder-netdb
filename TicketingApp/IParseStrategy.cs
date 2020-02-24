using System.Collections.Generic;

namespace TicketingApp {
    interface IParseStrategy {
        List<Ticket> ParseDataForTickets(List<string[]> data);

        string[] ParseTicketForData(Ticket ticket);
    }
}