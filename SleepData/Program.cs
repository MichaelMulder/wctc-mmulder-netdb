using System;
using System.IO;
using System.Collections.Generic;

namespace SleepData {
    class MainClass {
        public static void Main(string[] args) {
            // ask for input
            Console.WriteLine("Enter 1 to create data file.");
            Console.WriteLine("Enter 2 to parse data.");
            Console.WriteLine("Enter anything else to quit."); 
            // input response
            string resp = Console.ReadLine();

            // specify path for data file
            // string file = "~/Downloads/data.txt";
            string file = AppDomain.CurrentDomain.BaseDirectory + "data.txt";

            if (resp == "1") {
                // create data file
                
                // ask a question
                Console.WriteLine("How many weeks of data is needed?");
                // input the response (convert to int)
                int weeks = int.Parse(Console.ReadLine());

                // determine start and end date
                DateTime today = DateTime.Now;
                // we want full weeks sunday - saturday
                DateTime dataEndDate = today.AddDays(-(int)today.DayOfWeek);
                // subtract # of weeks from endDate to get startDate
                DateTime dataDate = dataEndDate.AddDays(-(weeks * 7));

                // random number generator
                Random rnd = new Random();

                // create file
                StreamWriter sw = new StreamWriter(file);
                // loop for the desired # of weeks
                while (dataDate < dataEndDate) {
                    // 7 days in a week
                    int[] hours = new int[7];
                    for (int i = 0; i < hours.Length; i++) {
                        // generate random number of hours slept between 4-12 (inclusive)
                        hours[i] = rnd.Next(4, 13);
                    }
                    // M/d/yyyy,#|#|#|#|#|#|#
                    //Console.WriteLine($"{dataDate:M/d/yy},{string.Join("|", hours)}");
                    sw.WriteLine($"{dataDate:M/d/yyyy},{string.Join("|", hours)}");
                    // add 1 week to date
                    dataDate = dataDate.AddDays(7);
                }
                sw.Close();
            }
            else if (resp == "2") {
                /*
                 * Table structure
                 * WeekKey              HoursSleptValue   
                 * -------              ----------
                 * DateTime             List<int>
                 * 1/1/2020             8|9|6|10|12|8|7
                 */

                Dictionary<DateTime, List<int>> sleepData = new Dictionary<DateTime, List<int>>();

                StreamReader sr = new StreamReader(file);

                while(!sr.EndOfStream) {
                    string[] fileData = sr.ReadLine().Split(','); 
                   
                    string[] weeksData = fileData[0].Split('\n');

                    string[] weekhoursData = fileData[1].Split('\n');

                    List<DateTime> weekDates = convertWeeksToWeekDates(weeksData);
                    int i = 0;
                    foreach(var week in weekDates) {
                        var dataHours = weekhoursData[i];
                        var hours = weekHoursDataToArray(dataHours);
                        sleepData.Add(week, hours);
                        i++;
                    }

                }

                displayResults(sleepData);                
                               
                sr.Close();
            }

            /**
             * Convert a string array of weeks into an list of DateTimes
             */
 
            List<DateTime> convertWeeksToWeekDates(string[] weeks) { 
                var weekDates = new List<DateTime>();
                foreach(var week in weeks) { 
                    weekDates.Add(DateTime.Parse(week));
                } 
                
                return weekDates; 
            }

            /**
             * Turns a string of numbers seperated like 6|8|9
             * into an list of numbers 
             */

            List<int> weekHoursDataToArray(string weekHours) {
                var hours = new List<int>();
                string[] dataHours;
                dataHours = weekHours.Split('|');
                foreach(var hour in dataHours) {
                    hours.Add(int.Parse(hour));
                }
                return hours;
            }

            /*
             * display results to user
             */
            void displayResults(Dictionary<DateTime, List<int>> sleepData) {

                
                foreach (KeyValuePair<DateTime, List<int>> kvp in sleepData) {
                    var total = 0;
                    var avg = 0;
                    var date = kvp.Key;
                    var hours = kvp.Value;
                    for(var i = 0; i < hours.Count; i++) { 
                        total += hours[i];
                    }
                    avg += total / hours.Count;
                    Console.WriteLine($"  Week of {date:MMM}, {date:dd}, {date:yyyy}");
                    Console.WriteLine($"{"Su",3} {"Mo",3} {"Tu",3} {"We", 3} {"Th", 3} {"Fr", 3} {"Sa", 3} {"Total", 3} {"Avg", 3}");
                    Console.WriteLine($"---------------------------"); 
                    Console.WriteLine($"{hours[0],3} {hours[1],3} {hours[2],3} {hours[3], 3} {hours[4], 3} {hours[5], 3} {hours[6], 3} {total, 3} {avg, 3}");
                }


            }

        }
    }
}
