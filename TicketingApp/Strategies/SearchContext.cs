﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingApp.TicketTypes;

namespace TicketingApp.Strategies {
    class SearchContext {
        public ISearchStrategy Strategy { get; set; }

        public SearchContext() {

        }

        public SearchContext(ISearchStrategy strategy) {
            this.Strategy = strategy;
        }

        public IEnumerable<Ticket> DoSearch(string searchTerm, List<Ticket> ticketList) {
            return this.Strategy.Search(searchTerm, ticketList);
        }
    }
}
