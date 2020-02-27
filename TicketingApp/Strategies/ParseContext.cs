using System.Collections.Generic;
using TicketingApp.TicketTypes;

namespace TicketingApp.Strategies {
    class ParseContext {
        public IParseStrategy Strategy { get; set; }

        public ParseContext() {

        }

        public ParseContext(IParseStrategy strategy) {
            this.Strategy = strategy;
        }

        public List<Ticket> DoParseForTickets(List<string[]> data) {
            return this.Strategy.ParseDataForTickets(data);
        }

        public string[] DoParseForData(Ticket ticket) {
            return this.Strategy.ParseTicketForData(ticket);
        }

    }
}