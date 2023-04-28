using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Transactions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace _560FinalProject
{
    public class Operations
    {
        /// <summary>
        /// This is the connection string to the local database (may be different per user).
        /// </summary>
        private readonly string cs;

        public Operations(string connectionString) { cs = connectionString; }

        public List<string> MovieSearch(int ind, List<string> userInput, int NumUpDown)
        {
            string SQLCommand = "";
            if (ind == 1) SQLCommand = UserMovieSearch(userInput, NumUpDown); 
            if (ind == 2) SQLCommand = UserActorSearch(userInput, NumUpDown);
            if (ind == 3) SQLCommand = UserTDRSearch(userInput, NumUpDown);
            if (ind == 4) SQLCommand = UserGenreSearch(userInput, NumUpDown);

            List<string> outputData = new List<string>();
            
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(cs))
                {
                    using (var command = new SqlCommand(SQLCommand, connection))
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string line = "";
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    if (i == reader.FieldCount - 1) line += $"{reader.GetValue(i)}";
                                    else line += $"{reader.GetValue(i)},";
                                }
                                outputData.Add(line);
                            }
                        }
                        transaction.Complete();
                    }
                }
            }
            return outputData;
        }

        private string UserMovieSearch(List<string> userInput, int NumUpDown)
        {
            string startCommand = $"SELECT TOP {NumUpDown} M.MovieID, M.Title, M.ReleaseYear, M.Duration, M.Gross, M.Rating FROM MovieOperations.Movie M WHERE ";
            int catcher = 0;
            for(int i = 0; i < userInput.Count;i++)
            {
                if (!string.IsNullOrEmpty(userInput[i]))
                {
                    if (i == userInput.Count) catcher = 0;
                    if (catcher == 1) startCommand += " AND ";
                    if (i == 0) startCommand += $"M.Title LIKE N'%{userInput[i]}%'"; catcher = 1;
                    if (i == 1) startCommand += $"M.ReleaseYear = {userInput[i]}"; catcher = 1;
                    if (i == 2) startCommand += $"M.Duration = {userInput[i]}"; catcher = 1;
                    if (i == 3) startCommand += $"M.Gross = N'{userInput[i]}'"; catcher = 1;
                    if (i == 4) startCommand += $"M.Rating = {userInput[i]}"; catcher = 1;
                }
            }
            return startCommand;
        }

        private string UserActorSearch(List<string> userInput, int NumUpDown)
        {
            string startCommand = $"SELECT TOP ({NumUpDown}) A.ActorID, A.FirstName, A.LastName, COUNT(MC.ActorID) FROM MovieOperations.Actor A INNER JOIN " +
                $"MovieOperations.MovieCast MC ON MC.ActorID = A.ActorID WHERE ";
            int catcher = 0;
            for (int i = 0; i < userInput.Count; i++)
            {
                if (!string.IsNullOrEmpty(userInput[i]))
                {
                    if (i == userInput.Count) catcher = 0;
                    if (catcher == 1) startCommand += " AND ";
                    if (i == 0) startCommand += $"A.FirstName = N'{userInput[i]}'"; catcher = 1;
                    if (i == 1) startCommand += $"A.LastName = N'{userInput[i]}'"; catcher = 1;
                }
            }
            startCommand += $" GROUP BY A.ActorID, A.FirstName, A.LastName";
            startCommand += $" ORDER BY COUNT(MC.ActorID) DESC";
            return startCommand;
        }

        private string UserTDRSearch(List<string> userInput, int NumUpDown)
        {
            string startCommand = $"SELECT TOP {NumUpDown} T.TheaterID, T.TheaterName, T.TheaterAddress, R.RoomID, R.RoomNumber, R.Capacity, M.Title, ST.Showtime FROM MovieOperations.Theater T INNER JOIN MovieOperations.Room R ON R.TheaterID = T.TheaterID " +
                "INNER JOIN MovieOperations.MovieShowtime ST ON ST.RoomID = R.RoomID INNER JOIN MovieOperations.Movie M ON M.MovieID = ST.MovieID WHERE ";
            int catcher = 0;
            for (int i = 0; i < userInput.Count; i++)
            {
                if (!string.IsNullOrEmpty(userInput[i]))
                {
                    if (i == userInput.Count) catcher = 0;
                    if (catcher == 1) startCommand += " AND ";
                    switch (i)
                    {
                        case 0:
                            startCommand += $"T.TheaterName LIKE N'%{userInput[i]}%'"; 
                            catcher = 1;
                            break;
                        case 1:
                            startCommand += $"T.TheaterAddress = N'{userInput[i]}'"; 
                            catcher = 1;
                            break;
                        case 2:
                            startCommand += $"R.RoomNumber = {userInput[i]}";
                            catcher = 1;
                            break;
                        case 3:
                            startCommand += $"R.Capacity = {userInput[i]}";
                            catcher = 1;
                            break;
                        case 4:
                            startCommand += $"ST.Showtime > '{userInput[i]}'";
                            catcher = 1;
                            break;
                        case 5:
                            startCommand += $"ST.Showtime < '{userInput[i]}'";
                            break;
                    }
                }
            }
            startCommand += " ORDER BY ST.Showtime ASC ";
            return startCommand;
        }

        private string UserGenreSearch(List<string> userInput, int NumUpDown)
        {
            string startCommand = $"SELECT TOP {NumUpDown} G.GenreType, MG.MovieGenreID, M.Title, M.Rating, M.ReleaseYear FROM MovieOperations.MovieGenres MG INNER JOIN MovieOperations.Movie M ON M.MovieID = MG.MovieID INNER JOIN MovieOperations.Genre G ON G.GenreID = MG.GenreID WHERE ";
            int catcher = 0;
            for (int i = 0; i < userInput.Count; i++)
            {
                if (!string.IsNullOrEmpty(userInput[i]))
                {
                    if (i == userInput.Count) catcher = 0;
                    if (catcher == 1) startCommand += " AND ";
                    if (i == 0) startCommand += $"M.ReleaseYear = {userInput[i]}"; catcher = 1;
                    if (i == 1) startCommand += $"M.Rating = {userInput[i]}"; catcher = 1;
                    if (i == 2) startCommand += $"G.GenreType = N'{userInput[i]}'"; catcher = 1;
                }
            }
            return startCommand;
        }

        // CREATE //

        /// <summary>
        /// Creates an Actor with the given parameters.
        /// </summary>
        public Actor CreateActor(string firstName, string lastName, string movielist)
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

                        List<string> list = new List<string>();
                        string[] strs = movielist.Split(' ');
                        foreach (string str in strs) list.Add(str);

                        command.Parameters.AddWithValue("MovieList", movielist);

                        var p = command.Parameters.Add("ActorID", SqlDbType.Int);
                        p.Direction = ParameterDirection.Output;

                        connection.Open();

                        command.ExecuteNonQuery();

                        transaction.Complete();

                        var actorid = (int)command.Parameters["ActorID"].Value;

                        return new Actor(actorid, firstName, lastName, list);
                    }
                }
            }
        }

        /// <summary>
        /// Creates an MovieShowtime with the given parameters.
        /// </summary>
        public Movie CreateMovie(string title, int duration, int releaseYear, string gross, double rating)
        {
            // Verify parameters.
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("The parameter cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(gross)) throw new ArgumentException("The parameter cannot be null or empty.");

            // Save to database.
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(cs))
                {
                    using (var command = new SqlCommand("MovieOperations.CreateMovie", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("Title", title);
                        command.Parameters.AddWithValue("Duration", duration);
                        command.Parameters.AddWithValue("ReleaseYear", releaseYear);
                        command.Parameters.AddWithValue("Gross", gross);
                        command.Parameters.AddWithValue("Rating", rating);

                        var b = command.Parameters.Add("MovieID", SqlDbType.Int);
                        b.Direction = ParameterDirection.Output;

                        connection.Open();

                        command.ExecuteNonQuery();

                        transaction.Complete();

                        var movieid = (int)command.Parameters["MovieID"].Value;

                        return new Movie(movieid, title, duration, releaseYear, gross, rating);
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
                        //command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("TheaterName", name);
                        command.Parameters.AddWithValue("TheaterAddress", address);

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

        /// <summary>
        /// Creates an Room with the given parameters.
        /// </summary>
        public Room CreateRoom(int roomnumber, int capacity, int theaterid)
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
                        command.Parameters.AddWithValue("TheaterID", theaterid);

                        var a = command.Parameters.Add("RoomID", SqlDbType.Int);
                        a.Direction = ParameterDirection.Output;

                        connection.Open();

                        command.ExecuteNonQuery();

                        transaction.Complete();

                        var roomid = (int)command.Parameters["RoomID"].Value;

                        return new Room(roomid, theaterid, roomnumber, capacity);
                    }
                }
            }
        }

        // UPDATE //

        /// <summary>
        /// Update an Actor with the given parameters.
        /// </summary>
        public Movie UpdateMovie(string title, int duration, int releaseYear, string gross, double rating, int id)
        {
            // Verify parameters.
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("The parameter cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(gross)) throw new ArgumentException("The parameter cannot be null or empty.");

            // Save to database.
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(cs))
                {
                    using (var command = new SqlCommand("MovieOperations.UpdateMovie", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("Title", title);
                        command.Parameters.AddWithValue("Duration", duration);
                        command.Parameters.AddWithValue("ReleaseYear", releaseYear);
                        command.Parameters.AddWithValue("Gross", gross);
                        command.Parameters.AddWithValue("Rating", rating);
                        command.Parameters.AddWithValue("MovieID", id);

                        connection.Open();

                        command.ExecuteNonQuery();

                        transaction.Complete();

                        var movieid = (int)command.Parameters["MovieID"].Value;

                        return new Movie(movieid, title, duration, releaseYear, gross, rating);
                    }
                }
            }
        }

        public void UpdateActor()
        /// <summary>
        /// Update an Theater with the given parameters.
        /// </summary>
        public Theater UpdateTheater(string name, string address, int theaterID)
        {
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(cs))
                {
                    using (var command = new SqlCommand("MovieOperations.UpdateTheater", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("TheaterName", name);
                        command.Parameters.AddWithValue("TheaterAddress", address);
                        command.Parameters.AddWithValue("TheaterID", theaterID);

                        connection.Open();

                        command.ExecuteNonQuery();

                        transaction.Complete();

                        return new Theater(theaterID, name, address);
                    }
                }
            }
        }

        /// <summary>
        /// Update an Room with the given parameters.
        /// </summary>
        public void UpdateRoom(string roomNum, string capacity, int roomID)
        {
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(cs))
                {
                    using (var command = new SqlCommand("MovieOperations.UpdateRoom", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("RoomNumber", roomNum);
                        command.Parameters.AddWithValue("Capacity", capacity);
                        command.Parameters.AddWithValue("RoomID", roomID);

                        connection.Open();

                        command.ExecuteNonQuery();

                        transaction.Complete();
                    }
                }
            }
        }

        // REMOVE //

        /// <summary>
        /// Removes an Actor with the given parameters.
        /// </summary>
        public void RemoveActor(int id)
        {
            // Verify parameters.
            if (string.IsNullOrWhiteSpace(Convert.ToString(id))) throw new ArgumentException("The parameter cannot be null or empty.");

            // Save to database.
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(cs))
                {
                    using (var command = new SqlCommand("MovieOperations.RemoveActor", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ActorID", id);

                        connection.Open();

                        command.ExecuteNonQuery();

                        transaction.Complete();
                    }
                }
            }
        }

        /// <summary>
        /// Removes an MovieShowtime with the given parameters.
        /// </summary>
        public void RemoveMovie(int id)
        {
            // Save to database.
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(cs))
                {
                    using (var command = new SqlCommand("MovieOperations.RemoveMovie", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@MovieID", id);

                        connection.Open();

                        command.ExecuteNonQuery();

                        transaction.Complete();
                    }
                }
            }
        }

        /// <summary>
        /// Removes an Room with the given parameters.
        /// </summary>
        public void RemoveRoom(int id)
        {
            // Save to database.
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(cs))
                {
                    using (var command = new SqlCommand("MovieOperations.RemoveRoom", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@RoomID", id);

                        connection.Open();

                        command.ExecuteNonQuery();

                        transaction.Complete();
                    }
                }
            }
        }

        /// <summary>
        /// Removes an Theater with the given parameters.
        /// </summary>
        public void RemoveTheater(int id)
        {
            // Save to database.
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(cs))
                {
                    using (var command = new SqlCommand("MovieOperations.RemoveTheater", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@TheaterID", id);

                        connection.Open();

                        command.ExecuteNonQuery();

                        transaction.Complete();
                    }
                }
            }
        }
    }
}
