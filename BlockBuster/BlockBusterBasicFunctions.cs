using BlockBuster.Models;
using Microsoft.EntityFrameworkCore;

namespace BlockBuster
{
    public class BlockBusterBasicFunctions
    {
        public static Movie GetMovieById(int id)
        {
            using (var db = new SE407_BlockBusterContext())
            {
                return db.Movies.Find(id);
            }
        }

        public static List<Movie> GetAllMovies()
        {
            using (var db = new SE407_BlockBusterContext())
            {
                return db.Movies.Include(m => m.Director).Include(m => m.Genre).ToList();
            }
        }

        public static List<Transaction> GetAllCheckedoutMovies()
        {
            using (var db = new SE407_BlockBusterContext())
            {
                return db.Transactions
                    .Include(t => t.Movie)
                    .Where(t => t.CheckedIn == "N")
                    .ToList();
            }
        }

        public static List<Movie> GetAllMoviesByGenre(string genre)
        {
            using (var db = new SE407_BlockBusterContext())
            {
                return db.Movies
                    .Include(m => m.Genre)
                    .Where(m => m.Genre.GenreDescr == genre)
                    .ToList();
            }
        }

        public static List<Movie> GetAllMoviesByDirectorLastName(string lastName)
        {
            using (var db = new SE407_BlockBusterContext())
            {
                return db.Movies
                    .Include(m => m.Director)
                    .Where(m => m.Director.LastName == lastName)
                    .ToList();
            }
        }

        public static List<Movie> GetAllMoviesFull()
        {
            using (var db = new SE407_BlockBusterContext())
            {
                var movies = db.Movies
                    .Include(movies => movies.Director)
                    .Include(movies => movies.Genre)
                    .ToList();
                return movies;
            }
        }

        public static Movie GetMovieByTitle(string title)
        {
            using (var db = new SE407_BlockBusterContext())
            {
                return db.Movies.FirstOrDefault(m => m.Title == title);
            }
        }


        public static List<Movie> ExecuteQuery(string outputType, params string[] userOption)
        {
            switch (outputType)
            {
                case "GetMovieById":
                    if (userOption.Length == 1 && int.TryParse(userOption[0], out int id))
                    {
                        return new List<Movie> { GetMovieById(id) };
                    }
                    else
                    {
                        Console.WriteLine("Invalid Option for GetMovieById.");
                        return new List<Movie>();
                    }
                case "GetAllMovies":
                    return GetAllMovies();

                case "GetAllMoviesByGenre":
                    if (userOption.Length == 1)
                    {
                        return GetAllMoviesByGenre(userOption[0]);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Option for GetAllMoviesByGenre.");
                        return new List<Movie>();
                    }

                case "GetAllMoviesByDirectorLastName":
                    if (userOption.Length == 1)
                    {
                        return GetAllMoviesByDirectorLastName(userOption[0]);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Option for GetAllMoviesByDirectorLastName.");
                        return new List<Movie>();
                    }

                case "GetMovieByTitle":
                    if (userOption.Length == 1)
                    {
                        return new List<Movie> { GetMovieByTitle(userOption[0]) };
                    }
                    else
                    {
                        Console.WriteLine("Invalid Option for GetMovieByTitle.");
                        return new List<Movie>();
                    }

                default:
                    Console.WriteLine("Invalid method.");
                    return new List<Movie>();
            }
        }

        public static Movie GetFullMovieById(int id)
        {
            using (var db = new SE407_BlockBusterContext())
            {
                var movie = db.Movies
                    .Include(m => m.Director)
                    .Include(m => m.Genre)
                    .Where(m => m.MovieId == id)
                    .FirstOrDefault();
                return movie;
            }
        }

        public static List<Genre> GetAllGenres()
        {
            using (var db = new SE407_BlockBusterContext())
            {
                return db.Genres.ToList();
            }
        }

        public static List<Director> GetAllDirectors()
        {
            using (var db = new SE407_BlockBusterContext())
            {
                return db.Directors.ToList();
            }
        }

    }
}