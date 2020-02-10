using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibaryApp {
    class Movie {
        private int id;
        private string title;
        private List<MovieGenres> genres;

        public int ID { get => id; set => id = value; } 

        public string Title { get => title; set => title = value; } 

        internal List<MovieGenres> Genres { get => genres; set => genres = value; }
    }
}
