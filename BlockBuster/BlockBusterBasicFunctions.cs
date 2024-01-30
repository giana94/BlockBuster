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
                return db.Movies.ToList();
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

        public static Movie GetMovieByTitle(string title)
        {
            using (var db = new SE407_BlockBusterContext())
            {
                return db.Movies.FirstOrDefault(m => m.Title == title);
            }
        }


    }
}