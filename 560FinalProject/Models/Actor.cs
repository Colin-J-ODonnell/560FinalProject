using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _560FinalProject
{
    public class Actor
    {
        public int ActorID;
        public string FirstName;
        public string LastName;

        public Actor(int actorID, string firstName, string lastName)
        {
            ActorID = actorID;
            FirstName = firstName;
            LastName = lastName;
        }

        /// <summary>
        /// This is a placeholder for actor.
        /// </summary>
        public Actor()
        {
            ActorID = 696969;
            FirstName = "JO'";
            LastName = "MAMA";
        }
    }
}
