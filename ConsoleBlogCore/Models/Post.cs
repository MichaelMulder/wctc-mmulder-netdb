using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBlogCore.Model {
    public class Post { 

        public int PostID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int BlogId { get; set; } 

        public Blog Blog { get; set; }
    }
}
