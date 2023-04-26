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

namespace _560FinalProject
{
    public class Operations
    {
        /// <summary>
        /// This is the connection string to the local database (may be different per user).
        /// </summary>
        private readonly string cs;

        public Operations(string connectionString) 
        { 
            cs = connectionString;
        }

        public List<string> MovieSearch(int ind, List<string> userInput)
        {
            string SQLCommand = "";
            if (ind == 1) SQLCommand = UserMovieSearch(userInput); 
            if (ind == 2) SQLCommand = UserActorSearch(userInput);
            if (ind == 3) SQLCommand = UserTDRSearch(userInput);
            if (ind == 4) SQLCommand = UserGenreSearch(userInput);

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

        private string UserMovieSearch(List<string> userInput)
        {
            string startCommand = "SELECT M.MovieID, M.Title, M.ReleaseYear, M.Duration, M.Gross, M.Rating FROM MovieOperations.Movie M WHERE ";
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

        private string UserActorSearch(List<string> userInput)
        {
            string startCommand = "SELECT A.ActorID A.FirstName, A.LastName, M.Title FROM MovieOperations.Actor A INNER JOIN MovieOperations.MovieCast MC ON MC.ActorID = A.ActorID INNER JOIN MovieOperations.Movie M ON M.MovieID = MC.MovieID WHERE ";
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
            return startCommand;
        }

        
        private string UserTDRSearch(List<string> userInput)
        {
            string startCommand = "SELECT T.TheaterID, R.RoomID, T.[Name], M.Title, ST.Showtime FROM MovieOperations.Theater T INNER JOIN MovieOperations.Room R ON R.TheaterID = T.TheaterID " +
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
                            startCommand += $"T.[Name] LIKE N'%{userInput[i]}%'"; 
                            catcher = 1;
                            break;
                        case 1:
                            startCommand += $"T.[Address] = N'{userInput[i]}'"; 
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
            startCommand += " ORDER BY ST.Showtime ASC";
            return startCommand;
        }
        private string UserGenreSearch(List<string> userInput)
        {
            string startCommand = "SELECT G.GenreType, MG.MovieGenreID, M.Title, M.Rating, M.ReleaseYear FROM MovieOperations.MovieGenres MG INNER JOIN MovieOperations.Movie M ON M.MovieID = MG.MovieID INNER JOIN MovieOperations.Genre G ON G.GenreID = MG.GenreID WHERE ";
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
                        string[] strs = movielist.Split(',');
                        foreach (string str in strs) list.Add(str);

                        command.Parameters.AddWithValue("LastName", list);

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
        public void RemoveMovie(int id)
        {
            // Verify parameters.
            // None Needed Here.

            // Save to database.
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(cs))
                {
                    using (var command = new SqlCommand("MovieOperations.RemoveMovie", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@MovieID", id);

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
        public void RemoveRoom(int id)
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

                        command.Parameters.AddWithValue("@RoomID", id);

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
        public void RemoveTheater(int id)
        {
            // Verify parameters.

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

        public void GenerateRooms()
        {
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(cs))
                {
                    using (var command = new SqlCommand("SELECT * FROM MovieOperations.Theater", connection))
                    {
                        int[] roomNumbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 };
                        int[] holder = roomNumbers;
                        connection.Open();
                        List<Room> rooms = new List<Room>();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Random rand = new Random();
                                int totalCount = 1;
                                for (int i = 0; i < reader.FieldCount; i+=4)
                                {
                                    roomNumbers = roomNumbers.OrderBy(x => rand.Next()).ToArray();
                                    int count = (int)reader.GetValue(i+3);
                                    for(int j = 1; j <= count; j++)
                                    {
                                        rooms.Add(new Room(totalCount++, i + 1, roomNumbers[j], rand.Next(4, 15) * 5));
                                    }
                                    roomNumbers = holder;
                                }
                            }
                        }

                        transaction.Complete();

                        using (StreamWriter sw = new StreamWriter("ryoutput.txt"))
                        {
                            for (int i = 0; i < rooms.Count; i++)
                            {
                                string s = Convert.ToString(rooms[i].RoomID) + "," + Convert.ToString(rooms[i].TheaterID) + "," + Convert.ToString(rooms[i].RoomNumber) + "," + Convert.ToString(rooms[i].Capacity);
                                sw.WriteLine(s);
                            }
                        }
                    }
                }
            }
        }
    }
}
