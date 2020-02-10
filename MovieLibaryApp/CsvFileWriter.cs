using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibaryApp {
    class CSVFileWriter : IfileWriter { 
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public void writeToFile(string[] dataLine, string fileName) {
            try {
                StreamWriter sw  = new StreamWriter(fileName, true);
                string newLine = string.Join(",", dataLine);
<<<<<<< HEAD
<<<<<<< HEAD
                sw.WriteLine(newLine);
                sw.Close();
            } catch (Exception e) {
                logger.Error(e.Message);
                Console.WriteLine(e);
=======
                sw.WriteLine("\n" + newLine);
            } catch (Exception e) {
                logger.Error(e.Message);
>>>>>>> f2994f6... save to file
=======
                sw.WriteLine(newLine);
                sw.Close();
            } catch (Exception e) {
                logger.Error(e.Message);
                Console.WriteLine(e);
>>>>>>> 40a474f... Fixed file IO, refactored movieMethods to Movie Manager
            }
        }
    }

}
