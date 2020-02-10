using System; 
using System.Collections.Generic;
using System.IO;

namespace MovieLibaryApp
{
 class Program {
        static void Main(string[] args) {
            int choice = 0;
            string fileName = "Movies.csv";
            while (choice != 3) {
                Console.WriteLine("1) Search for a movie");
                Console.WriteLine("2) Create a Movie for the database");
                Console.WriteLine("3) Exit");

                string input = Console.ReadLine();
                CSVFileReader fr = new CSVFileReader(true);

                choice = int.Parse(input);


                switch (choice) {
                    case 1:
                        fr.readFromFile(fileName);
                        string[] headers = fr.Headers; 
                        var data = fr.Data;

                        var myMoives = dataToMovieList(data);

                        displayResults(myMoives);

                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    default:
                        break;
                }
            } 
        }

        static Movie dataLineToMovie(string[] dataLine) { 
            var movie = new Movie();
            for(int i = 0; i < dataLine.Length; i++) { 
                movie.ID = int.Parse(dataLine[0]);
                movie.Title = dataLine[1];
                movie.Genres = parseStringToMovieGenres(dataLine[2]);
            }
            return movie;
        }

        static List<Movie> dataToMovieList(List<string[]> data) {
            var movieList = new List<Movie>();
            foreach (var dataLine in data) {
                movieList.Add(dataLineToMovie(dataLine));
            }

            return movieList;
        } 

        static List<MovieGenres> parseStringToMovieGenres(string dataGenres) {
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
        
        static string[] movieToDataLine(Movie movie) {
            string[] newDataLine = { movie.ID, movie.Title, };
            
            return null;
        } 

        static List<Movie> searchByName(string searchTerm, List<Movie> movieList) {
            var results = movieList.FindAll(m => m.Title.StartsWith(searchTerm));
            return results;
        } 

        static List<Movie> searchByGenre(MovieGenres genre, List<Movie> movieList) {
            var results = movieList.FindAll(m => m.Genres.Contains(genre));
            return results;
        }

        static void displayResults(List<Movie> movies) { 
            foreach(var movie in movies) {
                var movieGenres = String.Join(", ", movie.Genres.ToArray());
                System.Console.WriteLine($"| {"ID", -6}| {"Title", -20} | {"Genres", 3} "); 
                System.Console.WriteLine($"|-------|----------------------|-------");
                System.Console.WriteLine($"|{movie.ID, 7}|{movie.Title, -22}| {movieGenres}");
                System.Console.WriteLine("\n");
            }

        }
    }

}
