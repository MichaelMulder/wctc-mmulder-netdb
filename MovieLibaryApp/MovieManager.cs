using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibaryApp {
    class MovieManager {

        private List<Movie> movieList;

        public MovieManager(List<Movie> movieList) {
            this.movieList = movieList; 
        }
        public static Movie dataLineToMovie(string[] dataLine) { 
            var movie = new Movie();
            for(int i = 0; i < dataLine.Length; i++) { 
                movie.ID = int.Parse(dataLine[0]);
                movie.Title = dataLine[1].ToLower();
                movie.Genres = parseStringToMovieGenres(dataLine[2]);
            }
            return movie;
        }

        public static List<Movie> dataToMovieList(List<string[]> data) {
            var movieList = new List<Movie>();
            foreach (var dataLine in data) {
                movieList.Add(dataLineToMovie(dataLine));
            }

            return movieList;
        } 

        public static List<MovieGenres> parseStringToMovieGenres(string dataGenres) {
            var genres = new List<MovieGenres>();
            string[] stringGenres = dataGenres.Split('|');
            foreach(var stringGenre in stringGenres) { 
                if(stringGenre == "Film-Noir") {
                    genres.Add(MovieGenres.FilmNoir);
                }

                if (stringGenre == "(no genres listed)") {
                    genres.Add(MovieGenres.NoGenre);
                }

                if(stringGenre == "Sci-Fi") {
                    genres.Add(MovieGenres.SciFi);
                }
                    
                if(Enum.TryParse(stringGenre, out MovieGenres genre)) { 
                    genres.Add(genre); 
                }
            }
            return genres;
        }
        
        public static string[] movieToDataLine(Movie movie) {
            var genres = string.Join("|", movie.Genres.ToArray());
            string[] newDataLine = { movie.ID.ToString(), movie.Title, genres }; 
            return newDataLine;
        } 

        public List<Movie> searchByName(string searchTerm) {
            return this.movieList.FindAll(m => m.Title.StartsWith(searchTerm.ToLower()));
        } 

        public  List<Movie> searchByGenre(MovieGenres genre) {
            return  this.movieList.FindAll(m => m.Genres.Contains(genre)); 
        }

        public bool TitleIsVaild(string title) { 
            return this.movieList.Exists(m => m.Title.Contains(title.ToLower())); 
        }
    }
}
