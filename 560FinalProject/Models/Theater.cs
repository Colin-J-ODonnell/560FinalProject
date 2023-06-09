﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _560FinalProject
{
    public class Theater
    {
        public int TheaterID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public Theater(int theaterID, string name, string address)
        {
            TheaterID = theaterID;
            Name = name;
            Address = address;
        }

        /// <summary>
        /// This is for a placeholder theater.
        /// </summary>
        public Theater()
        {
            TheaterID = 696969;
            Name = "Placeholder";
            Address = "Fake Address";
        }
    }
}
