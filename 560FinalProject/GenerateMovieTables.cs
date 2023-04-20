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
    public static class GenerateMovieTables
    {
        public static void GenerateTables(string connectionString)
        {
            /// need to add movie sql command calling
            /// need to add movie sql command calling

            string theaterName = "AMC Empire";
            string address = "420 Block";
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("MovieOperations.CreateTheater", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("Name", theaterName);
                        command.Parameters.AddWithValue("Address", address);

                        var p = command.Parameters.Add("TheaterID", SqlDbType.Int);
                        p.Direction = ParameterDirection.Output;

                        connection.Open();

                        command.ExecuteNonQuery();
                        transaction.Complete();
                    }
                }
            }
        }
    }
}
