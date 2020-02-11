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
                sw.WriteLine("\n" + newLine);
            } catch (Exception e) {
                logger.Error(e.Message);
            }
        }
    }

}
