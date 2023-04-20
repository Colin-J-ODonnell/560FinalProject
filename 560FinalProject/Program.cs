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
            string connectionString = @"Server=(localdb)\MSSQLLocalDb;Database=rosen;Integrated Security=SSPI;";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GenerateOrDropTables.TableQuery(connectionString);
            GenerateMovieTables.GenerateTables(connectionString);
            Application.Run(new OpeningForm());
        }
    }
}
