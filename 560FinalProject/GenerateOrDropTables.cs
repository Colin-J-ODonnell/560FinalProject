using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace _560FinalProject
{
    public static class GenerateOrDropTables
    {
        public static void TableQuery(string connectionString)
        {
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("MovieOperations.Tables", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        command.ExecuteNonQuery();
                        transaction.Complete();
                    }
                }
            }
        }
    }
}
