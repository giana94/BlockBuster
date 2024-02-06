using BlockBuster.Models;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBusterConsole
{
    internal class OutputHelper
    {
        public void Output(List<Movie> movies, string outputType)
        {
            if (outputType.Equals("CSV", StringComparison.OrdinalIgnoreCase))
            {
                WriteToCSV(movies);
            }
            else if (outputType.Equals("Console", StringComparison.OrdinalIgnoreCase))
            {
                WriteToConsole(movies);
            }
            else
            {
                Console.WriteLine("Invalid output type. Please specify 'CSV' or 'Console'.");
            }
        }

        public void WriteToConsole(List<Movie> movies)
        {
            Console.WriteLine("List of Movies:");
            foreach (var movie in movies)
            {
                Console.WriteLine($"MovieID: {movie.MovieId}    Title: {movie.Title}     Release Year: {movie.ReleaseYear}");
            }

        }

        public void WriteToCSV(List<Movie> movies)
        {
            using (var writer = new StreamWriter(@"..\file.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(movies);
            }

        }


    }
}
