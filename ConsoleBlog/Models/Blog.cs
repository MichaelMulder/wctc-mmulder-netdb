using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBlog {
    class Blog {

        public int BlogId { get; set; }

        public string Name { get; set; } 

        public List<Post> Posts { get; set; }
        
        
    }
}
