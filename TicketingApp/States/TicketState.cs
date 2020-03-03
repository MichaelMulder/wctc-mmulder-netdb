using System.Collections.Generic;
using TicketingApp.TicketTypes;
using TicketingApp.Strategies;

namespace TicketingApp.States {
    abstract class TicketState {
        protected TicketContext context;
        public List<Ticket> TicketList {get; set;}

        public SearchContext SearchContext {get; set;}

        public ParseContext ParseContext {get; set;}

        public void SetContext(TicketContext context) {
            this.context = context;
        }

        public abstract void ReadTickets(string fileName);

        public abstract IEnumerable<Ticket> SearchTickets(int searchChoice);

        public abstract void WriteTicket(Ticket ticket, string fileName);
    }
}