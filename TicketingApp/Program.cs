using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;
            string fileName = "Tickets.csv";
            while (choice != 3)
            {
                Console.WriteLine("1) Read Data from file");
                Console.WriteLine("2) Create file from data");
                Console.WriteLine("3) Exit");

                string input = Console.ReadLine();

                choice = int.Parse(input);


                switch (choice)
                {
                    case 1:
                        if (File.Exists(fileName))
                        {
                            StreamReader sr = new StreamReader(fileName); 
                            while(!sr.EndOfStream)
                            {
                                string line = sr.ReadLine();

                                string[] arr = line.Split(',');

                                Console.WriteLine($"TicketID: {arr[0]}");

                            }
                        }
                        else
                        {
                            Console.WriteLine("File does not exist");
                        }
                        break;
                    case 2:
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
