using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace _560FinalProject
{
    public partial class MovieDatabaseForm : Form
    {
        OpeningForm OF { get; set; }

        Operations O { get; set; }

        public MovieDatabaseForm(OpeningForm of, Operations o)
        {
            InitializeComponent();
            OF = of;
            O = o;
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            List<int> MovieIDs = new List<int>();
            List<string> Titles = new List<string>();
            List<int> Release = new List<int>();
            List<int> Duration = new List<int>();
            List<string> Revenue = new List<string>();
            List< float > Ratings = new List<float>();
            List<string> inputData = new List<string>();
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(@"Server=(localdb)\MSSQLLocalDb;Database=local codonnell;Integrated Security=SSPI;"))
                {
                    using (var command = new SqlCommand("SELECT * FROM MovieOperations.Movie", connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string line = "";
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    if(i == reader.FieldCount - 1)
                                    {
                                        line += $"{reader.GetValue(i)}";
                                    }
                                    else
                                    {
                                        line += $"{reader.GetValue(i)},";
                                    }
                                    
                                }
                                inputData.Add(line);
                            }
                        }
                        transaction.Complete();
                    }
                }
            }

            foreach(string s in inputData)
            {
                string[] split = s.Split(',');
                MovieIDs.Add(Convert.ToInt32(split[0]));
                Titles.Add(split[1]);
                Release.Add(Convert.ToInt32(split[2]));
                Duration.Add(Convert.ToInt32(split[3]));
                Revenue.Add(split[4]);
                Ratings.Add((float)Convert.ToDouble(split[5]));
            }

            Database_OutputForm of = new Database_OutputForm(this, O, MovieIDs, Titles, Release, Duration, Revenue, Ratings);
            this.Hide();
            of.Show();


            
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            this.Close();
            OF.Show();
        }

        private void MovieDatabaseForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
