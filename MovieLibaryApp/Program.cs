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
            string fileName = "Movies.csv";
            while (choice != 3) {
                Console.WriteLine("1) Search for a movie");
                Console.WriteLine("2) Create a Movie for the database");
                Console.WriteLine("3) Exit");

                string input = Console.ReadLine();

                choice = int.Parse(input);

                switch (choice) {
                    case 1:
                        if (File.Exists(fileName)) {
                            StreamReader sr = new StreamReader(fileName);
                            // Read the first line and set it as the header for the data points
                            string[] headers = sr.ReadLine().Split(',');
                            while (!sr.EndOfStream) {
                                string line = sr.ReadLine();

                                string[] data = line.Split(',');



                            }
                            sr.Close();
                        } else {
                            Console.WriteLine("File does not exist");
                            Console.WriteLine(Directory.GetCurrentDirectory());
                        }
                        break;
                    case 2:
                        StreamWriter sw = new StreamWriter(fileName, true);

                        sw.Close();
                        break;
                    case 3:
                        break;
                    default:
                        break;
                }
            }
        }
    }
    class Movie {
        private int id;
        private string title;
        private int year;
        private List<movieGenres> genres;


        public int Id {
            get { return this.id; }
            set { this.id = value; }
        }
        public string Title {
            get { return this.title; }
            set { this.title = value; }
        }

        public int Year {
            get { return this.year; }
            set { this.year = value; }
        }

        public List<movieGenres> Genres {
            get { return this.genres; }
            set { this.genres = value; }
        } 
    }
    
    enum movieGenres {
        Action,
        Adventure,
        Animation,
        Children,
        Comedy,
        Crime,
        Documentary,
        Drama,
        Fantasy,
        FilmNoir,
        Horror,
        Musical,
        Mystery,
        Romance,
        SciFi,
        Thriller,
        War,
        Western,
        NoGenre
    }
}
