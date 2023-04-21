using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _560FinalProject
{
    public class Director
    {
        public int DirectorID;
        public string FirstName;
        public string LastName;

        public Director(int directorid, string firstName, string lastName)
        {
            DirectorID = directorid;
            FirstName = firstName;
            LastName = lastName;
        }

        /// <summary>
        /// This is a placeholder for director.
        /// </summary>
        public Director()
        {
            DirectorID = 696969;
            FirstName = "YO'";
            LastName = "MAMA";
        }
    }
}
