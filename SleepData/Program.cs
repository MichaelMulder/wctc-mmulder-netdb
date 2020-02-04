using System;
using System.IO;
using System.Collections;

namespace SleepData
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // ask for input
            Console.WriteLine("Enter 1 to create data file.");
            Console.WriteLine("Enter 2 to parse data.");
            Console.WriteLine("Enter anything else to quit."); 
            // input response
            string resp = Console.ReadLine();

            // specify path for data file
            // string file = "~/Downloads/data.txt";
            string file = AppDomain.CurrentDomain.BaseDirectory + "data.txt";

            if (resp == "1")
            {
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
                while (dataDate < dataEndDate)
                {
                    // 7 days in a week
                    int[] hours = new int[7];
                    for (int i = 0; i < hours.Length; i++)
                    {
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
            else if (resp == "2")
            {
                // TODO: parse data file into hash table
                /*
                 * Table structure
                 * WeekKey              HoursSleptValue   
                 * -------              ----------
                 * DateTime             int[7]
                 * 1/1/2020             8|9|6|10|12|8|7
                 */

                Hashtable sleepData = new Hashtable();

                StreamReader sr = new StreamReader(file);

                while(!sr.EndOfStream)
                {
                    string[] fileData = sr.ReadLine().Split(',');

                   
                    string[] weeksData = fileData[0].Split('\n');

                    string[] weekhoursData = fileData[1].Split('\n');

                    ArrayList weekDates = convertWeeksToWeekDates(weeksData);
                    Console.WriteLine(weekDates[0]);
                    int i = 0;
                    foreach(var week in weekDates)
                    {
                        var dataHours = weekhoursData[i];
                        var hours = weekHoursDataToArray(dataHours);
                        sleepData.Add(week, hours);
                        i++;
                    }

                }
                               
            }

            /**
             * Convert a string array of weeks into an arraylist of DateTimes
             */
 
            ArrayList convertWeeksToWeekDates(string[] weeks) { 
                var weekDates = new ArrayList();
                foreach(var week in weeks) { 
                    weekDates.Add(DateTime.Parse(week));
                } 
                
                return weekDates; 
            }

            /**
             * Turns a string of numbers seperated like 6|8|9
             * into an arraylist of numbers 
             */

            ArrayList weekHoursDataToArray(string weekHours)
            {
                var hours = new ArrayList();
                string[] dataHours;
                dataHours = weekHours.Split('|');
                foreach(var hour in dataHours) {
                    hours.Add(int.Parse(hour));
                }
                return hours;
            }

        }
    }
}
