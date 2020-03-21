using System.Collections;
using Microsoft.EntityFrameworkCore;

namespace ConsoleBlogCore.Bakers {
    interface IMakeBread {
        void Browse();
        IEnumerable Read();
        void Edit();
        void Add();
        void Delete();
    }
}