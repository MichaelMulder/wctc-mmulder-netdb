﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingApp.Strategies;
using TicketingApp.FileManager;
using TicketingApp.TicketTypes;

namespace TicketingApp.States {
    class TaskTicketState : TicketState{
        public TaskTicketState() {
            IParseStrategy strategy = new TaskTicketParser();
            this.ParseContext = new ParseContext {
                Strategy = strategy
            };
        }
        public override void ReadTickets(string fileName) {
            CSVFileReader fr = new CSVFileReader(true); 
            fr.readFromFile(fileName);

            var data = fr.Data;

            this.TicketList = ParseContext.DoParseForTickets(data);
        }

        public override IEnumerable<Ticket> SearchTickets(int searchChoice) {
            var ticketList = TicketList;

            this.SearchContext = new SearchContext();

            switch (searchChoice) {
                case 1:
                    Menu.displayMessage("Enter a Summary:");
                    SearchContext.Strategy = new SummaryStrategy();
                    var searchSummary = Menu.getStringInput();
                    return SearchContext.DoSearch(searchSummary, ticketList);
                case 2:
                    Menu.displayMessage("Enter a Satus(Open, Closed, Pending, Resolved):");
                    SearchContext.Strategy = new StatusStrategy();
                    var searchStatus = Menu.getStringInput();
                    return SearchContext.DoSearch(searchStatus, ticketList);
                case 3:
                    Menu.displayMessage("Enter a Priority(High, Medium, Low):");
                    SearchContext.Strategy = new PriorityStrategy();
                    var searchPriority = Menu.getStringInput();
                    return SearchContext.DoSearch(searchPriority, ticketList);
                case 4:
                    Menu.displayMessage("Enter a Summiter:");
                    SearchContext.Strategy = new SubmitterStrategy();
                    var searchSubmitter = Menu.getStringInput();
                    return SearchContext.DoSearch(searchSubmitter, ticketList);
                case 5:
                    Menu.displayMessage("Enter an Assigned:");
                    SearchContext.Strategy = new AssginedStrategy();
                    var searchAssigned = Menu.getStringInput();
                    return SearchContext.DoSearch(searchAssigned, ticketList);
                case 6:
                    Menu.displayMessage("Enter a Watcher:");
                    SearchContext.Strategy = new WatcherStrategy();
                    var searchWatcher = Menu.getStringInput();
                    return SearchContext.DoSearch(searchWatcher, ticketList);
                case 7:
                    Menu.displayMessage("Enter a Task Name:");
                    SearchContext.Strategy = new TaskNameStrategy(); 
                    var searchTask = Menu.getStringInput();
                    return SearchContext.DoSearch(searchTask, ticketList);
                case 8:
                    Menu.displayMessage("Enter the due date");
                    SearchContext.Strategy = new DueDateStrategy();
                    var searchDue = Menu.getStringInput();
                    return SearchContext.DoSearch(searchDue, ticketList);
                default:
                    Menu.displayMessage("Please enter a number 1-8");
                    return ticketList;
            }
        }

        public override void WriteTicket(Ticket ticket, string fileName) {
            CSVFileWriter fw = new CSVFileWriter(); 

            var dataline = ParseContext.DoParseForData(ticket);


            TicketList.Add(ticket);

            fw.writeToFile(dataline, fileName); 
        }

        public void newThing() {
            Console.WriteLine("I do someing differnt");
        }

    }
}
