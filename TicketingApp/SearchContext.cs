using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingApp {
    class SearchContex {
        public ISearchStrategy Strategy { get; set; }

        public SearchContex() {

        }

        public SearchContex(ISearchStrategy strategy) {
            this.Strategy = strategy;
        }

        public List<Ticket> DoSearch(string searchTerm, List<Ticket> ticketList) {
            return this.Strategy.Search(searchTerm, ticketList);
        }
    }
}
