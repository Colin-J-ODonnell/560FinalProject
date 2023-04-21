using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _560FinalProject
{
    public class Movie
    {
        public int MovieID;
        public string Title;
        public int Duration;
        public int ReleaseYear;
        public string Gross;
        public double Rating;

        public Movie(int movieID, string title, int duration, int releaseYear, string gross, double rating)
        {
            MovieID = movieID;
            Title = title;
            Duration = duration;
            ReleaseYear = releaseYear;
            Gross = gross;
            Rating = rating;
        }

        /// <summary>
        /// This is a placeholder for movie.
        /// </summary>
        public Movie()
        {
            MovieID = 696969;
            Title = "Placeholder Movie";
            Duration = 420;
            ReleaseYear = 3000;
            Gross = "N/A";
            Rating = 10;
        }
    }
}
