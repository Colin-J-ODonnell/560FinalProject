using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _560FinalProject
{
    public class Genre
    {
        public int GenreID { get; set; }
        public string Type { get; set; }

        public Genre(int genreID, string type)
        {
            GenreID = genreID;
            Type = type;
        }

        /// <summary>
        /// This is a placeholder for genre.
        /// </summary>
        public Genre()
        {
            GenreID = 69;
            Type = "Funky Stuff";
        }
    }
}
