using System.Collections.Generic;
using TicketingApp.TicketTypes;

namespace TicketingApp.Strategies {
    interface IParseStrategy {
        List<Ticket> ParseDataForTickets(List<string[]> data);

        string[] ParseTicketForData(Ticket ticket);
    }
}