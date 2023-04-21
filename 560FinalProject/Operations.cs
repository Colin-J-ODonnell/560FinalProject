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
        private readonly string cs;

        public Operations(string connectionString)
        {
            cs = connectionString;
        }

        public Movie CreateMovie(string title, int duration, int releaseYear, double gross, double rating)
        {
            // Verify parameters.
            if (title == " ")
                throw new ArgumentException("The parameter cannot be null or empty.");

            // Save to database.
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(cs))
                {
                    using (var command = new SqlCommand("Movie.CreateMovie", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        if (title != " ") command.Parameters.AddWithValue("Title", title);
                        else title = null;
                        if (duration != 0) command.Parameters.AddWithValue("Duration", duration);
                        else duration = 0;
                        if (releaseYear != 0) command.Parameters.AddWithValue("ReleaseYear", releaseYear);
                        else releaseYear = 0;
                        if (gross != 0) command.Parameters.AddWithValue("Gross", gross);
                        else gross = 0;
                        if (rating != 0) command.Parameters.AddWithValue("Rating", rating);
                        else rating = 0;

                        var p = command.Parameters.Add("MovieID", SqlDbType.Int);
                        p.Direction = ParameterDirection.Output;

                        var pp = command.Parameters.Add("DirectorID", SqlDbType.Int);
                        pp.Direction = ParameterDirection.Output;

                        connection.Open();

                        command.ExecuteNonQuery();

                        transaction.Complete();

                        var movieid = (int)command.Parameters["MovieID"].Value;
                        var directorid = (int)command.Parameters["DirectorID"].Value;

                        return new Movie(movieid, directorid, title, duration, releaseYear, gross, rating);
                    }
                }
            }
        }
    }
}
