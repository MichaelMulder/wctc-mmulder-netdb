using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibaryApp {
    class CSVFileWriter : IfileWriter {
        public void writeToFile(string text, string fileName) {
            try {
                StreamWriter sw  = new StreamWriter(fileName, true);
                sw.WriteLine("\n" + text);
            } catch (Exception e) {
                Console.WriteLine(e);
            }
        }
    }

}
