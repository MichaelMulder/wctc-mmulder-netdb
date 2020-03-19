using System.Collections;
using Microsoft.EntityFrameworkCore;

namespace ConsoleBlogCore {
  interface IMakeBread {
    void Browse();
    IEnumerable Read();
    void Edit();
    void Add();
    void Delete();
  }
}