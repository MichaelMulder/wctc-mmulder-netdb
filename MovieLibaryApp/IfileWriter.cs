using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibaryApp {
    interface IfileWriter {

        void writeToFile(string text, string fileName);
    }
}
