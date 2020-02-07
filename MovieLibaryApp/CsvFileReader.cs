using System;
using System.Collections.Generic; 
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibaryApp {
    class CSVFileReader : IfileReader { 
        private bool headersAvaliable;
        private string[] headers;
        private string[] data;

        public CSVFileReader(bool headersAvaiable) {
            this.headersAvaliable = headersAvaiable; 
        }

        public string[] Headers { get => headers; } 
        public string[] Data { get => data; }

        public void readFromFile(string fileName) {
            try {
                if (File.Exists(fileName)) {
                    StreamReader sr = new StreamReader(fileName + ".csv");
                    // Read the first line and set it as the header for the data points
                    if(this.headersAvaliable) { 
                        this.headers = sr.ReadLine().Split(',');
                    }
                    while (!sr.EndOfStream) {
                        string line = sr.ReadLine();

                        this.data = line.Split(',');
                    }
                    sr.Close();
                }
            } catch(Exception e) {
                Console.WriteLine(e); 
            }
        }


    }
}
