using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingApp.FileManager {
    interface IfileWriter { 
        void writeToFile(string[] dataLine, string fileName);
    }
}
