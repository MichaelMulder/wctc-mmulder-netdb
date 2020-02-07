using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibaryApp {
    class Movie {
        private int id;
        private string title;
        private int year;
        private List<MovieGenres> genres;

        public int Year { get => year; set => year = value; }

        public string Title { get => title; set => title = value; } 

        internal List<MovieGenres> Genres { get => genres; set => genres = value; }
    }
}
