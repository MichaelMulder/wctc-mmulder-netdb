using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBlogCore.Model {
    public class Blog {

        public int BlogId { get; set; }

        public string Name { get; set; } 

        public List<Post> Posts { get; set; }
    }

}
