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
            string connectionString = @"Server=(localdb)\MSSQLLocalDb;Database=DatabaseProject;Integrated Security=SSPI;";

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Operations OP = new Operations(connectionString);
            Application.Run(new OpeningForm(OP));
        }
    }
}
