using BlockBuster.Models;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace BlockBusterTest
{
    public class BlockBusterBasicFunctionsTest
    {
        [Fact]
        public void GetMovieByIdTest()
        {
            var result = BlockBusterBasicFunctions.GetMovieById(11);
            Assert.NotNull(result);
            Assert.True(result.ReleaseYear == 1958);
            Assert.True(result.Title == "Vertigo");
        }

        [Fact]
        public void GetAllMoviesTest()
        {
            var result = BlockBusterBasicFunctions.GetAllMovies();
            Assert.NotNull(result);
            Assert.True(result.Count == 54);
        }

        [Fact]
        public void GetAllCheckedoutMoviesTest()
        {
            var result = BlockBusterBasicFunctions.GetAllCheckedoutMovies();
            Assert.NotNull(result);
            Assert.True(result.Count == 3);
        }

        [Fact]
        public void GetAllMoviesByGenreTest()
        {
            var result = BlockBusterBasicFunctions.GetAllMoviesByGenre("comedy");
            Assert.NotNull(result);
            Assert.True(result.Count > 0);
            Assert.True(result.All(m => m.Genre.GenreDescr == "Comedy"));
        }

        [Fact]
        public void GetAllMoviesByDirectorLastNameTest()
        {
            var result = BlockBusterBasicFunctions.GetAllMoviesByDirectorLastName("Wilder");

            Assert.NotNull(result);
            Assert.True(result.Count > 0);
            Assert.True(result.TrueForAll(m => m.Director.LastName == "Wilder"));
        }

        [Fact]
        public void GetMovieByTitleTest()
        {
            var result = BlockBusterBasicFunctions.GetMovieByTitle("Forrest Gump");
            Assert.NotNull(result);
            Assert.True(result.ReleaseYear == 1994);
            Assert.True(result.Title == "Forrest Gump");
        }


    }
}