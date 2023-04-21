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
        public int DirectorID;
        public string Title;
        public int Duration;
        public int ReleaseYear;
        public double Gross;
        public double Rating;

        public Movie(int movieID, int directorID, string title, int duration, int releaseYear, double gross, double rating)
        {
            MovieID = movieID;
            DirectorID = directorID;
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
            DirectorID = 6969;
            Title = "Placeholder Movie";
            Duration = 420;
            ReleaseYear = 3000;
            Gross = 1000000000;
            Rating = 10;
        }
    }
}
