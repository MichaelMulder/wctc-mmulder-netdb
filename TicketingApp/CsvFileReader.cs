using System;
using System.Collections.Generic; 
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace TicketingApp {
    class CSVFileReader : IfileReader { 
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private bool headersAvaliable;
        private string[] headers;
        private List<string[]> data;

        public CSVFileReader(bool headersAvaiable) {
            this.headersAvaliable = headersAvaiable; 
        }

        public string[] Headers { get => headers; } 
        public List<string[]> Data { get => data; }

        public void readFromFile(string fileName) {
            try {
                if (File.Exists(fileName)) {
                    StreamReader sr = new StreamReader(fileName);
                    // Read the first line and set it as the header for the data points
                    if(this.headersAvaliable) { 
                        this.headers = sr.ReadLine().Split(',');
                    }

                    List<string[]> data = new List<string[]>();
                    while (!sr.EndOfStream) {
                        string line = sr.ReadLine();

                        Regex regx = new Regex(',' + "(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");

                        string[] dataLine = regx.Split(line);


                        data.Add(dataLine);


                        this.data = data;
                    }
                    sr.Close();
                }
            } catch(Exception e) {

                logger.Error(e.Message); 
            }
        }


    }
}
