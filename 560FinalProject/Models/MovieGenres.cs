using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _560FinalProject.Models
{
    public class MovieGenres
    {
        public int MovieGenreID { get; set; }
        public int MovieID { get; set; }
        public int GenreID { get; set; }

        public MovieGenres(int movieGenreID, int movieID, int genreID)
        {
            MovieGenreID = movieGenreID;
            MovieID = movieID;
            GenreID = genreID;
        }

        /// <summary>
        /// This is a placeholder for MovieGenres.
        /// </summary>
        public MovieGenres()
        {
            MovieGenreID = 69;
            MovieID = 6969;
            GenreID = 69;
        }
    }
}
