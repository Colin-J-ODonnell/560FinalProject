using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _560FinalProject
{
    public class MovieShowtime
    {
        public int ShowtimeID { get; set; }
        public int MovieID { get; set; }
        public int RoomID { get; set; }
        public DateTime MovieTime { get; set; }

        public MovieShowtime(int showtimeID, int movieID, int roomID, DateTime movieTime)
        {
            ShowtimeID = showtimeID;
            MovieID = movieID;
            RoomID = roomID;
            MovieTime = movieTime;
        }

        /// <summary>
        /// This is a placeholder for MovieShowtime.
        /// </summary>
        public MovieShowtime()
        {
            ShowtimeID = 6969;
            MovieID = 6969;
            RoomID = 420;
            MovieTime = DateTime.Now;
        }
    }
}
