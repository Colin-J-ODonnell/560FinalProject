﻿using System;
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
using System.Threading;
using _560FinalProject.Models;

namespace _560FinalProject
{
    public class Operations
    {
        /// <summary>
        /// This is the connection string to the local database (may be different per user).
        /// </summary>
        private readonly string cs;

        public Operations(string connectionString) { cs = connectionString; }

        public List<string> MovieSearch(int ind, List<string> userInput, int NumUpDown, SortByEnum sort)
        {
            string SQLCommand = "";
            if (ind == 1) SQLCommand = UserMovieSearch(userInput, NumUpDown, sort); 
            if (ind == 2) SQLCommand = UserActorSearch(userInput, NumUpDown, sort);
            if (ind == 3) SQLCommand = UserTDRSearch(userInput, NumUpDown, sort);
            if (ind == 4) SQLCommand = UserGenreSearch(userInput, NumUpDown, sort);

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

        private string UserMovieSearch(List<string> userInput, int NumUpDown, SortByEnum sort)
        {
            string startCommand = $"SELECT TOP {NumUpDown} M.MovieID, M.Title, M.ReleaseYear, M.Duration, M.Gross, M.Rating FROM MovieOperations.Movie M WHERE ";
            int catcher = 0;
            int count = 0;
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
                else
                {
                    count++;
                }
            }
            if (count == 5) startCommand = startCommand.Substring(0, startCommand.Length - 6);
            switch (sort)
            {
                case SortByEnum.ID_ASC:
                    startCommand += " GROUP BY  M.MovieID, M.Title, M.ReleaseYear, M.Duration, M.Gross, M.Rating ORDER BY M.MovieID ASC";
                    break;
                case SortByEnum.ID_DESC:
                    startCommand += " GROUP BY  M.MovieID, M.Title, M.ReleaseYear, M.Duration, M.Gross, M.Rating ORDER BY M.MovieID DESC";
                    break;
                case SortByEnum.RATING_ASC:
                    startCommand += " GROUP BY  M.MovieID, M.Title, M.ReleaseYear, M.Duration, M.Gross, M.Rating ORDER BY M.Rating ASC";
                    break;
                case SortByEnum.RATING_DESC:
                    startCommand += " GROUP BY  M.MovieID, M.Title, M.ReleaseYear, M.Duration, M.Gross, M.Rating ORDER BY M.Rating DESC";
                    break;
                case SortByEnum.YEAR_ASC:
                    startCommand += " GROUP BY  M.MovieID, M.Title, M.ReleaseYear, M.Duration, M.Gross, M.Rating ORDER BY M.ReleaseYear ASC";
                    break;
                case SortByEnum.YEAR_DESC:
                    startCommand += " GROUP BY  M.MovieID, M.Title, M.ReleaseYear, M.Duration, M.Gross, M.Rating ORDER BY M.ReleaseYear DESC";
                    break;
            }
            return startCommand;
        }

        private string UserActorSearch(List<string> userInput, int NumUpDown, SortByEnum sort)
        {
            string startCommand = $"SELECT TOP ({NumUpDown}) A.ActorID, A.FirstName, A.LastName, COUNT(MC.ActorID) FROM MovieOperations.Actor A INNER JOIN " +
                $"MovieOperations.MovieCast MC ON MC.ActorID = A.ActorID INNER JOIN MovieOperations.Movie M ON M.MovieID = MC.MovieID INNER JOIN " +
                $"MovieOperations.MovieGenres MG ON MG.MovieID = M.MovieID INNER JOIN MovieOperations.Genre G ON G.GenreID = MG.GenreID WHERE ";
            int catcher = 0;
            int count = 0;
            if (string.IsNullOrEmpty(userInput[2]))
            {
                startCommand = $"SELECT TOP ({NumUpDown}) A.ActorID, A.FirstName, A.LastName, COUNT(MC.ActorID) FROM MovieOperations.Actor A INNER JOIN " +
                $"MovieOperations.MovieCast MC ON MC.ActorID = A.ActorID WHERE ";
            }
            for (int i = 0; i < userInput.Count; i++)
            {
                if (!string.IsNullOrEmpty(userInput[i]))
                {
                    if (i == userInput.Count) catcher = 0;
                    if (catcher == 1) startCommand += " AND ";
                    if (i == 0) startCommand += $"A.FirstName LIKE N'%{userInput[i]}%' "; catcher = 1;
                    if (i == 1) startCommand += $"A.LastName LIKE N'%{userInput[i]}%' "; catcher = 1;
                    if (i == 2) startCommand += $"G.GenreType LIKE N'%{userInput[i]}%' "; catcher = 1;
                }
                else
                {
                    count++;
                }
            }
            if (count == 3)
            {
                startCommand = startCommand.Substring(0, startCommand.Length - 6);
            }
            switch (sort)
            {
                case SortByEnum.ID_ASC:
                    startCommand += "GROUP BY A.ActorID, A.FirstName, A.LastName ORDER BY A.ActorID ASC";
                    break;
                case SortByEnum.ID_DESC:
                    startCommand += "GROUP BY A.ActorID, A.FirstName, A.LastName ORDER BY A.ActorID DESC";
                    break;
                case SortByEnum.NUM_MOVIES_ASC:
                    startCommand += "GROUP BY A.ActorID, A.FirstName, A.LastName ORDER BY COUNT(MC.ActorID) ASC";
                    break;
                case SortByEnum.NUM_MOVIES_DESC:
                    startCommand += "GROUP BY A.ActorID, A.FirstName, A.LastName ORDER BY COUNT(MC.ActorID) DESC";
                    break;
            }
            return startCommand;
        }

        private string UserTDRSearch(List<string> userInput, int NumUpDown, SortByEnum sort)
        {
            string startCommand = $"SELECT TOP {NumUpDown} T.TheaterID, T.TheaterName, T.TheaterAddress, R.RoomID, R.RoomNumber, R.Capacity, M.MovieID, M.Title, M.Rating, ST.ShowtimeID, ST.Showtime FROM MovieOperations.Theater T INNER JOIN MovieOperations.Room R ON R.TheaterID = T.TheaterID " +
                "INNER JOIN MovieOperations.MovieShowtime ST ON ST.RoomID = R.RoomID INNER JOIN MovieOperations.Movie M ON M.MovieID = ST.MovieID WHERE ";
            int catcher = 0;
            int count = 0;
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
                            startCommand += $"T.TheaterAddress LIKE N'%{userInput[i]}%'";
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
                else count++;
            }
            if (count == userInput.Count)
            {
                startCommand = startCommand.Substring(0, startCommand.Length - 6);
            }
            switch (sort)
            {
                case SortByEnum.ID_ASC:
                    startCommand += " GROUP BY T.TheaterID, T.TheaterName, T.TheaterAddress, R.RoomID, R.RoomNumber, R.Capacity, M.MovieID, M.Title, M.Rating, ST.ShowtimeID, ST.Showtime ORDER BY T.TheaterID ASC";
                    break;
                case SortByEnum.ID_DESC:
                    startCommand += " GROUP BY T.TheaterID, T.TheaterName, T.TheaterAddress, R.RoomID, R.RoomNumber, R.Capacity, M.MovieID, M.Title, M.Rating, ST.ShowtimeID, ST.Showtime ORDER BY T.TheaterID DESC";
                    break;
                case SortByEnum.DATE_ASC:
                    startCommand += " GROUP BY T.TheaterID, T.TheaterName, T.TheaterAddress, R.RoomID, R.RoomNumber, R.Capacity, M.MovieID, M.Title, M.Rating, ST.ShowtimeID, ST.Showtime ORDER BY ST.Showtime ASC";
                    break;
                case SortByEnum.DATE_DESC:
                    startCommand += " GROUP BY T.TheaterID, T.TheaterName, T.TheaterAddress, R.RoomID, R.RoomNumber, R.Capacity, M.MovieID, M.Title, M.Rating, ST.ShowtimeID, ST.Showtime ORDER BY ST.Showtime DESC";
                    break;
                case SortByEnum.RATING_ASC:
                    startCommand += " GROUP BY T.TheaterID, T.TheaterName, T.TheaterAddress, R.RoomID, R.RoomNumber, R.Capacity, M.MovieID, M.Title, M.Rating, ST.ShowtimeID, ST.Showtime ORDER BY M.Rating ASC";
                    break;
                case SortByEnum.RATING_DESC:
                    startCommand += " GROUP BY T.TheaterID, T.TheaterName, T.TheaterAddress, R.RoomID, R.RoomNumber, R.Capacity, M.MovieID, M.Title, M.Rating, ST.ShowtimeID, ST.Showtime ORDER BY M.Rating DESC";
                    break;
            }
            return startCommand;
        }

        private string UserGenreSearch(List<string> userInput, int NumUpDown, SortByEnum sort)
        {
            string startCommand = $"SELECT TOP {NumUpDown} G.GenreType, MG.MovieGenreID, M.Title, M.Rating, M.ReleaseYear FROM MovieOperations.MovieGenres MG INNER JOIN MovieOperations.Movie M ON M.MovieID = MG.MovieID INNER JOIN MovieOperations.Genre G ON G.GenreID = MG.GenreID WHERE ";
            int catcher = 0;
            int count = 0;
            for (int i = 0; i < userInput.Count; i++)
            {
                if (!string.IsNullOrEmpty(userInput[i]))
                {
                    if (i == userInput.Count) catcher = 0;
                    if (catcher == 1) startCommand += " AND ";
                    if (i == 0) startCommand += $"M.ReleaseYear = {userInput[i]}"; catcher = 1;
                    if (i == 1) startCommand += $"M.Rating = {userInput[i]}"; catcher = 1;
                    if (i == 2) startCommand += $"G.GenreType LIKE N'%{userInput[i]}%'"; catcher = 1;
                }
                else
                {
                    count++;
                }
            }
            if(count == userInput.Count) startCommand = startCommand.Substring(0, startCommand.Length - 6);

            switch (sort)
            {
                case SortByEnum.ID_ASC:
                    startCommand += " GROUP BY G.GenreID, G.GenreType, MG.MovieGenreID, M.Title, M.Rating, M.ReleaseYear ORDER BY G.GenreID ASC";
                    break;
                case SortByEnum.ID_DESC:
                    startCommand += " GROUP BY G.GenreID, G.GenreType, MG.MovieGenreID, M.Title, M.Rating, M.ReleaseYear ORDER BY G.GenreID DESC";
                    break;
                case SortByEnum.RATING_ASC:
                    startCommand += " GROUP BY G.GenreID, G.GenreType, MG.MovieGenreID, M.Title, M.Rating, M.ReleaseYear ORDER BY M.Rating ASC";
                    break;
                case SortByEnum.RATING_DESC:
                    startCommand += " GROUP BY G.GenreID, G.GenreType, MG.MovieGenreID, M.Title, M.Rating, M.ReleaseYear ORDER BY M.Rating DESC";
                    break;
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
            if (string.IsNullOrWhiteSpace(movielist)) throw new ArgumentException("The parameter cannot be null or empty.");

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

                        foreach (string movieID in list) CreateMovieCast(Convert.ToInt32(movieID), actorid);

                        return new Actor(actorid, firstName, lastName, list);
                    }
                }
            }
        }

        /// <summary>
        /// Creates an MovieCast with the given parameters.
        /// </summary>
        public MovieCast CreateMovieCast(int movieID, int actorID)
        {
            if (string.IsNullOrWhiteSpace(Convert.ToString(movieID))) throw new ArgumentException("The parameter cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(Convert.ToString(actorID))) throw new ArgumentException("The parameter cannot be null or empty.");

            // Save to database.
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(cs))
                {
                    using (var command = new SqlCommand("MovieOperations.CreateMovieCast", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("MovieID", movieID);
                        command.Parameters.AddWithValue("ActorID", actorID);

                        var p = command.Parameters.Add("CastID", SqlDbType.Int);
                        p.Direction = ParameterDirection.Output;

                        connection.Open();

                        command.ExecuteNonQuery();

                        transaction.Complete();

                        var castID = (int)command.Parameters["CastID"].Value;

                        return new MovieCast(castID, movieID, actorID);
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
            if (string.IsNullOrWhiteSpace(Convert.ToString(duration))) throw new ArgumentException("The parameter cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(Convert.ToString(releaseYear))) throw new ArgumentException("The parameter cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(gross)) throw new ArgumentException("The parameter cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(Convert.ToString(rating))) throw new ArgumentException("The parameter cannot be null or empty.");

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
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("TheaterName", name);
                        command.Parameters.AddWithValue("TheaterAddress", address);
                        command.Parameters.AddWithValue("RoomCount", 10);
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
            if (string.IsNullOrWhiteSpace(Convert.ToString(roomnumber))) throw new ArgumentException("The parameter cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(Convert.ToString(capacity))) throw new ArgumentException("The parameter cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(Convert.ToString(theaterid))) throw new ArgumentException("The parameter cannot be null or empty.");

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
            if (string.IsNullOrWhiteSpace(Convert.ToString(duration))) throw new ArgumentException("The parameter cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(Convert.ToString(releaseYear))) throw new ArgumentException("The parameter cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(gross)) throw new ArgumentException("The parameter cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(Convert.ToString(rating))) throw new ArgumentException("The parameter cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(Convert.ToString(id))) throw new ArgumentException("The parameter cannot be null or empty.");

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

        /// <summary>
        /// Update a Showtime with the given parameters.
        /// </summary>
        public void UpdateShowtime(int showtimeID, int roomID, int movieID, DateTime dt)
        {
            if (string.IsNullOrWhiteSpace(Convert.ToString(showtimeID))) throw new ArgumentException("The parameter cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(Convert.ToString(roomID))) throw new ArgumentException("The parameter cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(Convert.ToString(movieID))) throw new ArgumentException("The parameter cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(Convert.ToString(dt))) throw new ArgumentException("The parameter cannot be null or empty.");

            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(cs))
                {
                    using (var command = new SqlCommand("MovieOperations.UpdateShowtime", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("ShowtimeID", showtimeID);
                        command.Parameters.AddWithValue("RoomID", roomID);
                        command.Parameters.AddWithValue("MovieID", movieID);
                        command.Parameters.AddWithValue("StartDateTime", dt);
                        connection.Open();

                        command.ExecuteNonQuery();

                        transaction.Complete();


                    }
                }
            }
        }

        /// <summary>
        /// Update an Theater with the given parameters.
        /// </summary>
        public Theater UpdateTheater(string name, string address, int theaterID)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("The parameter cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(address)) throw new ArgumentException("The parameter cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(Convert.ToString(theaterID))) throw new ArgumentException("The parameter cannot be null or empty.");

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
        public void UpdateRoom(int roomNum, int capacity, int roomID)
        {
            if (string.IsNullOrWhiteSpace(Convert.ToString(roomNum))) throw new ArgumentException("The parameter cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(Convert.ToString(capacity))) throw new ArgumentException("The parameter cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(Convert.ToString(roomID))) throw new ArgumentException("The parameter cannot be null or empty.");

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
        /// Removes an Actor with the given ID.
        /// </summary>
        public void RemoveActor(int id)
        {
            // Verify parameters.
            if (string.IsNullOrWhiteSpace(Convert.ToString(id))) throw new ArgumentException("The parameter cannot be null or empty.");

            RemoveFromMovieCast(id);

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
        /// Removes an MovieCast with the given ID.
        /// </summary>
        public void RemoveFromMovieCast(int id)
        {
            if (string.IsNullOrWhiteSpace(Convert.ToString(id))) throw new ArgumentException("The parameter cannot be null or empty.");

            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(cs))
                {
                    using (var command = new SqlCommand("MovieOperations.RemoveFromMovieCast", connection))
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
            if (string.IsNullOrWhiteSpace(Convert.ToString(id))) throw new ArgumentException("The parameter cannot be null or empty.");

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
            if (string.IsNullOrWhiteSpace(Convert.ToString(id))) throw new ArgumentException("The parameter cannot be null or empty.");

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
            if (string.IsNullOrWhiteSpace(Convert.ToString(id))) throw new ArgumentException("The parameter cannot be null or empty.");

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
