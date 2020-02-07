using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibaryApp {
    class Program {
        static void Main(string[] args) {
            int choice = 0;
            string fileName = "Movies";
            while (choice != 3) {
                Console.WriteLine("1) Search for a movie");
                Console.WriteLine("2) Create a Movie for the database");
                Console.WriteLine("3) Exit");

                string input = Console.ReadLine();
                CSVFileReader fr = new CSVFileReader(true);

                choice = int.Parse(input);

                List<Movie> movieList;

                switch (choice) {
                    case 1:
                        fr.readFromFile(fileName);
                        string[] headers = fr.Headers;
                        string[] data = fr.Data;
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
        Movie dataLineToMovie(string dataLine) {
            return null;
        }

        List<Movie> dataToMovieList(string[] data) {
            return null;
        } 
        
        string movieToDataLine(Movie movie) { 
            return null;
        } 

        List<Movie> searchByName(string searchTerm) {
            // TODO
            return null;
        }

        List<Movie> searchByYear(string year) {
            // TODO
            return null;
        }

        List<Movie> searchByGenre(params MovieGenres[] genres) {
            // TODO
            return null;
        }
    }
}

