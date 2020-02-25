namespace TicketingApp.TicketTypes {
    enum TicketStatus {
        Open,
        Closed,
        Pending,
        Resolved,
        Error // Only for notifying something went wrong with parsing
    }
}
