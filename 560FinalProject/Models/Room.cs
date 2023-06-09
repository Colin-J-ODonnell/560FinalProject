﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _560FinalProject
{
    public class Room
    {
        public int RoomID { get; set; }
        public int TheaterID { get; set; }
        public int RoomNumber { get; set; }
        public int Capacity { get; set; }

        public Room(int roodid, int theaterid, int roomnumber, int capacity)
        {
            RoomID = roodid;   
            TheaterID = theaterid;
            RoomNumber = roomnumber;
            Capacity = capacity;
        }

        /// <summary>
        /// This is for a placeholder room.
        /// </summary>
        public Room()
        {
            RoomID = 6969;
            TheaterID = 696969;
            RoomNumber = 420;
            Capacity = 9000;
        }
    }
}
