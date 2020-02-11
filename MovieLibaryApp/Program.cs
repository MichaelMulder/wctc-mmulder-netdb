using System; 
using System.Collections.Generic;
using System.IO;
<<<<<<< HEAD
using System.Linq;
=======
>>>>>>> 48de221... Ported over weekend work from laptob with core, added search functions

namespace MovieLibaryApp
{
 class Program {
<<<<<<< HEAD

        static void Main(string[] args) {
            int choice = 0;
            string fileName = "movies.csv";


            CSVFileReader fr = new CSVFileReader(true);

            fr.readFromFile(fileName);

            string[] headers = fr.Headers; 
            var data = fr.Data; 

            var movieList = MovieManager.dataToMovieList(data);

            var movieM = new MovieManager(movieList);
            while (choice != 3) {

                Console.WriteLine("1) Search movies");
                Console.WriteLine("2) Add movie");
                Console.WriteLine("3) Exit"); 
 

                
                string input = Console.ReadLine(); 

                if (int.TryParse(input, out choice)) {
                    switch (choice) {
                        case 1:
                            Console.WriteLine("1) Search by title");
                            Console.WriteLine("2) Search by genre");
                            Console.WriteLine("3) Display All");

                            int searchChoice;
                            string searchInput = Console.ReadLine();
                            if (int.TryParse(searchInput, out searchChoice)) {
                                switch (searchChoice) {

                                    case 1:
                                        Console.WriteLine("Enter a Movie title");
                                        var searchTitle = Console.ReadLine();
                                        displayResults(movieM.searchByName(searchTitle));
                                        break;
                                    case 2:
                                        Console.WriteLine("Enter a movie genre");
                                        var searchGenre = Console.ReadLine();
                                        if (Enum.TryParse(searchGenre, out MovieGenres genre)) {
                                            displayResults(movieM.searchByGenre(genre));
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
                                        Console.WriteLine("Please input a 1, 2, or 3");
                                        break;

                                }
                            }

                            break;
                        case 2:
                            CSVFileWriter fw = new CSVFileWriter();
                            var newMovie = new Movie();
                            newMovie.ID = movieList[movieList.Count - 1].ID + 1;
                            Console.WriteLine("Enter the title of the Movie");
                            string movieTitle = Console.ReadLine();
                            if (movieM.TitleIsVaild(movieTitle)) {
                                newMovie.Title = movieTitle;
                            } else {
                                Console.WriteLine(movieTitle + "is already apart of the database enter a diffrent title");
                                movieTitle = Console.ReadLine();
                            }
                            Console.WriteLine("Enter the genres of the Movie seperated by |");
                            string movieGenres = Console.ReadLine();
                            newMovie.Genres = MovieManager.parseStringToMovieGenres(movieGenres);
                            movieList.Add(newMovie);
                            string[] newDataLine = MovieManager.movieToDataLine(newMovie);
                            fw.writeToFile(newDataLine, fileName);
                            break;
                        case 3:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Please input a 1, 2, or 3");
                            break;
                    }
                }
            } 
        }

       
        static void displayResults(List<Movie> movies) {
            int pageSize = 5, pageCounter = 0; 
            var moviePage = movies.Take(pageSize).ToList();
            while(moviePage.Count() > 0){
                foreach (var movie in moviePage) {
                    var movieGenres = String.Join(", ", movie.Genres.ToArray());
                    System.Console.WriteLine($"| {"ID",-6}| {"Title",-20} | {"Genres",3} ");
                    System.Console.WriteLine($"|-------|----------------------|-------");
                    System.Console.WriteLine($"|{movie.ID,7}|{movie.Title,-22}| {movieGenres}");
                    System.Console.WriteLine("\n");
                }
                Console.WriteLine("Press space to conintue... Press q to quit...");
                var input = Console.ReadKey(true).Key;
                if (input == ConsoleKey.Spacebar) { 
                    pageCounter++; 
                    moviePage = movies.Skip(pageSize * pageCounter).Take(pageSize).ToList();
                } else if (input == ConsoleKey.Q) {
                    break;
                } 
            }
=======
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

>>>>>>> 48de221... Ported over weekend work from laptob with core, added search functions
        }
    }

}
