using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _560FinalProject
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string connectionString = @"Server=(localdb)\MSSQLLocalDb;Database=DatabaseProject;Integrated Security=SSPI;";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // GenerateOrDropTables.TableQuery(connectionString);
            // GenerateMovies.GenerateTables(connectionString);

            Operations OP = new Operations(connectionString);
            OP.CreateMovie("Billy Boi", 180, 1492, "$1,000", 0.5);

            Application.Run(new OpeningForm());
        }
    }
}
