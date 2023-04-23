using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _560FinalProject.Models
{
    public class MovieCast
    {
        public int CastID { get; set; }
        public int MovieID { get; set; }
        public int ActorID { get; set; }

        public MovieCast(int castID, int movieID, int actorID)
        {
            CastID = castID;
            MovieID = movieID;
            ActorID = actorID;
        }

        /// <summary>
        /// This is a placeholder for MovieCast.
        /// </summary>
        public MovieCast()
        {
            CastID = 69420;
            MovieID = 6969;
            ActorID = 696969;
        }
    }
}
