using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingApp {
    class TicketContext {
        private TicketState state = null;

        public TicketContext() {

        }
        public TicketContext(TicketState state) {
            this.ChangeState(state);
        }

        public void ChangeState(TicketState state) {
            this.state = state;
            this.state.SetContext(this);
        }

        public void Read(string fileName) {
            this.state.ReadTickets(fileName);
        }

        public List<Ticket> Search(int searchChoice) {
            return this.state.SearchTickets(searchChoice);
        }

        public void Write(Ticket ticket, string fileName) {
            this.state.WriteTicket(ticket, fileName);
        }
    }
}
