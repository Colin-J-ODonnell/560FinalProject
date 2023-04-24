using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;
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
            // MAKE SURE THIS STRING IS SET TO YOUR LOCAL DATABASE!
            string connectionString = @"Server=(localdb)\MSSQLLocalDb;Database=rosen;Integrated Security=SSPI;";

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // GenerateOrDropTables.TableQuery(connectionString);
            // GenerateMovies.GenerateTables(connectionString);


            Operations OP = new Operations(connectionString);
            OP.CreateActor("Billy3", "Boi");
            //OP.RemoveActor(1002);
            Application.Run(new OpeningForm(OP));
        }
    }
}
