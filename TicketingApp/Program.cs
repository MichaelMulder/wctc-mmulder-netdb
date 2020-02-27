using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingApp.States;
using TicketingApp.TicketTypes;
using TicketingApp.FileManager;
using TicketingApp.Strategies;

namespace TicketingApp {
    class Program {
        static void Main(string[] args) {
            string bugTicketsFile = AppDomain.CurrentDomain.BaseDirectory + "Tickets.csv";
            string enhancmentTicketsFile = AppDomain.CurrentDomain.BaseDirectory + "Enhancements.csv";
            string TaskTicketsFile = AppDomain.CurrentDomain.BaseDirectory + "Task.csv";

            ConsoleProgram App = new ConsoleProgram(bugTicketsFile, enhancmentTicketsFile, TaskTicketsFile);

            App.Run(); 
        }
        
    }
}
