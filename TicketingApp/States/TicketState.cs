using System.Collections.Generic;

namespace TicketingApp {
    abstract class TicketState {
        protected TicketContext context;
        public List<Ticket> TicketList {get; set;}

        public SearchContext SearchContext {get; set;}

        public ParseContext ParseContext {get; set;}

        public void SetContext(TicketContext context) {
            this.context = context;
        }

        public abstract void ReadTickets(string fileName);

        public abstract List<Ticket> SearchTickets(int searchChoice);

        public abstract void WriteTicket(Ticket ticket, string fileName);
    }
}