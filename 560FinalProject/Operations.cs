using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Transactions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _560FinalProject.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace _560FinalProject
{
    public class Operations
    {
        /// <summary>
        /// This is the connection string to the local database (may be different per user).
        /// </summary>
        private readonly string cs;

        public Operations(string connectionString) { cs = connectionString; }

        // CREATE ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Creates an Actor with the given parameters.
        /// </summary>
        public Actor CreateActor(string firstName, string lastName)
        {
            // Verify parameters.
            if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentException("The parameter cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(lastName)) throw new ArgumentException("The parameter cannot be null or empty.");

            // Save to database.
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(cs))
                {
                    using (var command = new SqlCommand("MovieOperations.CreateActor", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("FirstName", firstName);
                        command.Parameters.AddWithValue("LastName", lastName);

                        var p = command.Parameters.Add("ActorID", SqlDbType.Int);
                        p.Direction = ParameterDirection.Output;

                        connection.Open();

                        command.ExecuteNonQuery();

                        transaction.Complete();

                        var actorid = (int)command.Parameters["ActorID"].Value;

                        return new Actor(actorid, firstName, lastName);
                    }
                }
            }
        }

        /// <summary>
        /// Creates an MovieShowtime with the given parameters.
        /// </summary>
        public MovieShowtime CreateMovieShowtime(DateTime movieTime)
        {
            // Verify parameters.
            // None Needed Here.

            // Save to database.
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(cs))
                {
                    using (var command = new SqlCommand("MovieOperations.CreateMovieShowtime", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("MovieTime", movieTime);

                        var a = command.Parameters.Add("ShowtimeID", SqlDbType.Int);
                        a.Direction = ParameterDirection.Output;
                        var b = command.Parameters.Add("MovieID", SqlDbType.Int);
                        b.Direction = ParameterDirection.Output;
                        var c = command.Parameters.Add("RoomID", SqlDbType.Int);
                        c.Direction = ParameterDirection.Output;

                        connection.Open();

                        command.ExecuteNonQuery();

                        transaction.Complete();

                        var showtimeid = (int)command.Parameters["ShowtimeID"].Value;
                        var movieid = (int)command.Parameters["MovieID"].Value;
                        var roomid = (int)command.Parameters["RoomID"].Value;

                        return new MovieShowtime(showtimeid, movieid, roomid, movieTime);
                    }
                }
            }
        }

        /// <summary>
        /// Creates an Room with the given parameters.
        /// </summary>
        public Room CreateRoom(int roomnumber, int capacity)
        {
            // Verify parameters.
            // None Needed Here.

            // Save to database.
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(cs))
                {
                    using (var command = new SqlCommand("MovieOperations.CreateRoom", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("RoomNumber", roomnumber);
                        command.Parameters.AddWithValue("Capacity", capacity);

                        var a = command.Parameters.Add("RoomID", SqlDbType.Int);
                        a.Direction = ParameterDirection.Output;
                        var b = command.Parameters.Add("TheaterID", SqlDbType.Int);
                        b.Direction = ParameterDirection.Output;

                        connection.Open();

                        command.ExecuteNonQuery();

                        transaction.Complete();

                        var roomid = (int)command.Parameters["RoomID"].Value;
                        var theaterid = (int)command.Parameters["TheaterID"].Value;

                        return new Room(roomid, theaterid, roomnumber, capacity);
                    }
                }
            }
        }

        /// <summary>
        /// Creates an Theater with the given parameters.
        /// </summary>
        public Theater CreateTheater(string name, string address)
        {
            // Verify parameters.
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("The parameter cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(address)) throw new ArgumentException("The parameter cannot be null or empty.");

            // Save to database.
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(cs))
                {
                    using (var command = new SqlCommand("MovieOperations.CreateTheater", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("Name", name);
                        command.Parameters.AddWithValue("Address", address);

                        var p = command.Parameters.Add("TheaterID", SqlDbType.Int);
                        p.Direction = ParameterDirection.Output;

                        connection.Open();

                        command.ExecuteNonQuery();

                        transaction.Complete();

                        var theaterid = (int)command.Parameters["TheaterID"].Value;

                        return new Theater(theaterid, name, address);
                    }
                }
            }
        }

        // REMOVE ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Removes an Actor with the given parameters.
        /// </summary>
        public void RemoveActor(string firstName, string lastName)
        {
            // Verify parameters.
            if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentException("The parameter cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(lastName)) throw new ArgumentException("The parameter cannot be null or empty.");

            // Save to database.
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(cs))
                {
                    using (var command = new SqlCommand("MovieOperations.RemoveActor", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("FirstName", firstName);
                        command.Parameters.AddWithValue("LastName", lastName);

                        // Find a way to retrieve the correct actorID. Maybe through an sql program?

                        // var p = command.Parameters.Add("ActorID", SqlDbType.Int);
                        // p.Direction = ParameterDirection.Output;

                        connection.Open();

                        command.ExecuteNonQuery();

                        transaction.Complete();

                        // var actorid = (int)command.Parameters["ActorID"].Value;

                        // return new Actor(actorid, firstName, lastName);
                    }
                }
            }
        }

        /// <summary>
        /// Removes an MovieShowtime with the given parameters.
        /// </summary>
        public void RemoveMovieShowtime(DateTime movieTime)
        {
            // Verify parameters.
            // None Needed Here.

            // Save to database.
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(cs))
                {
                    using (var command = new SqlCommand("MovieOperations.RemoveMovieShowtime", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("MovieTime", movieTime);

                        // Find a way to retrieve the correct actorID. Maybe through an sql program?

                        // var a = command.Parameters.Add("ShowtimeID", SqlDbType.Int);
                        // a.Direction = ParameterDirection.Output;
                        // var b = command.Parameters.Add("MovieID", SqlDbType.Int);
                        // b.Direction = ParameterDirection.Output;
                        // var c = command.Parameters.Add("RoomID", SqlDbType.Int);
                        // c.Direction = ParameterDirection.Output;

                        connection.Open();

                        command.ExecuteNonQuery();

                        transaction.Complete();

                        // var showtimeid = (int)command.Parameters["ShowtimeID"].Value;
                        // var movieid = (int)command.Parameters["MovieID"].Value;
                        // var roomid = (int)command.Parameters["RoomID"].Value;

                        // return new MovieShowtime(showtimeid, movieid, roomid, movieTime);
                    }
                }
            }
        }

        /// <summary>
        /// Removes an Room with the given parameters.
        /// </summary>
        public void RemoveRoom(int roomnumber, int capacity)
        {
            // Verify parameters.
            // None Needed Here.

            // Save to database.
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(cs))
                {
                    using (var command = new SqlCommand("MovieOperations.RemoveRoom", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("RoomNumber", roomnumber);
                        command.Parameters.AddWithValue("Capacity", capacity);

                        // Find a way to retrieve the correct actorID. Maybe through an sql program?

                        // var a = command.Parameters.Add("RoomID", SqlDbType.Int);
                        // a.Direction = ParameterDirection.Output;
                        // var b = command.Parameters.Add("TheaterID", SqlDbType.Int);
                        // b.Direction = ParameterDirection.Output;

                        connection.Open();

                        command.ExecuteNonQuery();

                        transaction.Complete();

                        // var roomid = (int)command.Parameters["RoomID"].Value;
                        // var theaterid = (int)command.Parameters["TheaterID"].Value;

                        // return new Room(roomid, theaterid, roomnumber, capacity);
                    }
                }
            }
        }

        /// <summary>
        /// Removes an Theater with the given parameters.
        /// </summary>
        public void RemoveTheater(string name, string address)
        {
            // Verify parameters.
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("The parameter cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(address)) throw new ArgumentException("The parameter cannot be null or empty.");

            // Save to database.
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(cs))
                {
                    using (var command = new SqlCommand("MovieOperations.RemoveTheater", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("Name", name);
                        command.Parameters.AddWithValue("Address", address);

                        // Find a way to retrieve the correct actorID. Maybe through an sql program?

                        // var p = command.Parameters.Add("TheaterID", SqlDbType.Int);
                        // p.Direction = ParameterDirection.Output;

                        connection.Open();

                        command.ExecuteNonQuery();

                        transaction.Complete();

                        // var theaterid = (int)command.Parameters["TheaterID"].Value;

                        // return new Theater(theaterid, name, address);
                    }
                }
            }
        }
    }
}
