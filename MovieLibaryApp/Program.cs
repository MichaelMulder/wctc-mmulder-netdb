using System; 
using System.Collections.Generic;
using System.IO;

namespace MovieLibaryApp
{
 class Program {
        static void Main(string[] args) {
            int choice = 0;
            string fileName = "movies.csv";
            while (choice != 3) {

                Console.WriteLine("1) Search movies");
                Console.WriteLine("2) Add movie");
                Console.WriteLine("3) Exit"); 
 

                
                string input = Console.ReadLine();
                CSVFileReader fr = new CSVFileReader(true);

                choice = int.Parse(input);

                fr.readFromFile(fileName);
                string[] headers = fr.Headers; 
                var data = fr.Data; 


                var movieList = dataToMovieList(data);
                switch (choice) {
                    case 1:
                        Console.WriteLine("1) Search by title");
                        Console.WriteLine("2) Search by genre");
                        Console.WriteLine("3) Display All"); 
 
                        int searchChoice;
                        string searchInput = Console.ReadLine();
                        searchChoice = int.Parse(searchInput);
                        switch (searchChoice) {
                            
                            case 1:
                                Console.WriteLine("Enter a Movie title");
                                var searchTitle = Console.ReadLine();
                                displayResults(searchByName(searchTitle, movieList));
                                break; 
                            case 2:
                                Console.WriteLine("Enter a movie genre");
                                var searchGenre = Console.ReadLine(); 
                                if (Enum.TryParse(searchGenre, out MovieGenres genre)) { 
                                    displayResults(searchByGenre(genre, movieList));
                                } else {
                                    Console.WriteLine("Please enter one of the following genres");
                                    Console.WriteLine(" Action, " + "Adventure, " + "Animation, " +
                                        "Children, " +
                                        "Comedy, " +
                                        "Crime, " +
                                        "Documentary, " +
                                        "Drama, " +
                                        "Fantasy, " +
                                        "FilmNoir, " +
                                        "Horror, " +
                                        "Musical, " +
                                        "Mystery, " +
                                        "Romance, " +
                                        "SciFi, " +
                                        "Thriller, " +
                                        "War, " +
                                        "Western, NoGenre"); 
                                } 
                                break;
                            
                            case 3: 
                                displayResults(movieList);
                                break;

                            default:
                                break;

                        } 

                        break;
                    case 2: 
                        var newMovie = new Movie();
                        newMovie.ID = movieList.Count + 1;
                        Console.WriteLine("Enter the title of the Movie");
                        string movieTitle = Console.ReadLine();
                        newMovie.Title = movieTitle; 
                        Console.WriteLine("Enter the genres of the Movie seperated by |");
                        string movieGenres = Console.ReadLine();
                        newMovie.Genres = parseStringToMovieGenres(movieGenres); 
                        movieList.Add(newMovie);
                        
                        break;
                    case 3:
                        Environment.Exit(0);
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
            var genres = String.Join("|", movie.Genres.ToArray());
            string[] newDataLine = { movie.ID.ToString(), movie.Title, genres }; 
            return newDataLine;
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
