using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingApp {
    class Program {
        static void Main(string[] args) {
            int choice = 0;
            string fileName = "Tickets.csv";
            while (choice != 3) {
                Console.WriteLine("1) Read Data from file");
                Console.WriteLine("2) Create file from data");
                Console.WriteLine("3) Exit");

                string input = Console.ReadLine();

                choice = int.Parse(input);

                switch (choice) {
                    case 1:
                        if (File.Exists(fileName)) {
                            StreamReader sr = new StreamReader(fileName);
                            // Read the first line and set it as the header for the data points
                            string[] headers = sr.ReadLine().Split(','); 
                            while(!sr.EndOfStream) {
                                string line = sr.ReadLine(); 

                                string[] data = line.Split(',');


                                int i = 0;
                                foreach(var header in headers) {
                                    Console.WriteLine($"{header}: {data[i]}");
                                    i++; 
                                } 
                            }
                            sr.Close();
                        }
                        else {
                            Console.WriteLine("File does not exist");
                            Console.WriteLine(Directory.GetCurrentDirectory());
                        }
                        break;
                    case 2:
                        StreamWriter sw = new StreamWriter(fileName, true); 

                        Console.WriteLine("Enter TicketID:");
 
                        string ticketID = Console.ReadLine();

                        Console.WriteLine("Write summary for ticket:");

                        string summary = Console.ReadLine();

                        Console.WriteLine("Enter status of ticket:");

                        string status = Console.ReadLine();

                        Console.WriteLine("Enter proirity of status:");

                        string priority = Console.ReadLine();

                        Console.WriteLine("Who is summiting this ticket:");

                        string submitter = Console.ReadLine();

                        Console.WriteLine("Who is assigned for this ticket:");

                        string assigned = Console.ReadLine();

                        Console.WriteLine("Who is watching this ticket:");
                        string watchers = Console.ReadLine();

                        sw.WriteLine($"\n{ticketID},{summary}, {status}, {priority}, {submitter}, {assigned}, {watchers}"); 
                        sw.Close();
                        break; 
                    case 3:
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
