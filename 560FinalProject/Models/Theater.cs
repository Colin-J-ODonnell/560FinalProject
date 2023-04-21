using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _560FinalProject
{
    public class Theater
    {
        public int TheaterID;
        public string Name;
        public string Address;

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
