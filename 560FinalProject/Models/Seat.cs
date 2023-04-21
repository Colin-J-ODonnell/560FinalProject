using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _560FinalProject
{
    public class Seat
    {
        public int SeatID;
        public int RoomID;
        public int SeatNumber;

        public Seat(int seatID, int roomID, int seatNumber)
        {
            SeatID = seatID;
            RoomID = roomID;
            SeatNumber = seatNumber;
        }

        /// <summary>
        /// This is a placeholder for seat.
        /// </summary>
        public Seat()
        {
            SeatID = 420;
            RoomID = 6969;
            SeatNumber = 420;
        }
    }
}
