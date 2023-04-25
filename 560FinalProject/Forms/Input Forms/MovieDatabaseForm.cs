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

        /// <summary>
        /// Value assigned when user pics the search to complete 
        /// 1 = MovieSearch
        /// 2 = Actor Seach
        /// 3 = Theater Search
        /// 4 = Room Search
        /// 5 = Date Search
        /// 0 = RESET
        /// </summary>
        public int SEARCHVALUE = 0;

        public MovieDatabaseForm(OpeningForm of, Operations o)
        {
            InitializeComponent();
            OF = of;
            O = o;
        }

        private void search_button_Click(object sender, EventArgs e)
        {

            MovieSearch();

            
        }

        private void MovieSearch()
        {
            List<int> MovieIDs = new List<int>();
            List<string> Titles = new List<string>();
            List<int> Release = new List<int>();
            List<int> Duration = new List<int>();
            List<string> Revenue = new List<string>();
            List<float> Ratings = new List<float>();
            List<string> inputData = new List<string>();
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(@"Server=(localdb)\MSSQLLocalDb;Database=rosen;Integrated Security=SSPI;"))
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
                                    if (i == reader.FieldCount - 1)
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

            foreach (string s in inputData)
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

        private void MovieSearchDiabled()
        {
            actorFirstName_textbox.Enabled = false;
            actorLastName_textbox.Enabled = false;

            theaterName_textbox.Enabled = false;
            theaterAddress_textbox.Enabled = false;

            roomNumber_textbox.Enabled = false;
            roomCapacity_textbox.Enabled = false;

            dateStart_textbox.Enabled = false;
            dateEnd_textbox.Enabled = false;
        }

        private void ActorSearchDisabled()
        {
            theaterName_textbox.Enabled = false;
            theaterAddress_textbox.Enabled = false;
            roomNumber_textbox.Enabled = false;
            roomCapacity_textbox.Enabled = false;
            dateStart_textbox.Enabled = false;
            dateEnd_textbox.Enabled = false;
            
            movieTitle_textbox.Enabled = false;
            movieReleaseDate_textbox.Enabled = false;
            movieDuration_textbox.Enabled = false;
            movieRevenue_textbox.Enabled = false;
            movieRating_textbox.Enabled = false;
            movieGenre_textbox.Enabled = false;
        }

        private void TheaterSearchDisabled()
        {
            movieTitle_textbox.Enabled = false;
            movieReleaseDate_textbox.Enabled = false;
            movieDuration_textbox.Enabled = false;
            movieRevenue_textbox.Enabled = false;
            movieRating_textbox.Enabled = false;
            movieGenre_textbox.Enabled = false;
            roomNumber_textbox.Enabled = false;
            roomCapacity_textbox.Enabled = false;
            dateStart_textbox.Enabled = false;
            dateEnd_textbox.Enabled = false;
        }

        private void RoomSearchDisabled()
        {
            movieTitle_textbox.Enabled = false;
            movieReleaseDate_textbox.Enabled = false;
            movieDuration_textbox.Enabled = false;
            movieRevenue_textbox.Enabled = false;
            movieRating_textbox.Enabled = false;
            movieGenre_textbox.Enabled = false;
            dateStart_textbox.Enabled = false;
            dateEnd_textbox.Enabled = false;
            theaterName_textbox.Enabled = false;
            theaterAddress_textbox.Enabled = false;
        }

        private void DateSearchDisabled()
        {
            movieTitle_textbox.Enabled = false;
            movieReleaseDate_textbox.Enabled = false;
            movieDuration_textbox.Enabled = false;
            movieRevenue_textbox.Enabled = false;
            movieRating_textbox.Enabled = false;
            movieGenre_textbox.Enabled = false;

            actorFirstName_textbox.Enabled = false;
            actorLastName_textbox.Enabled = false;

            theaterName_textbox.Enabled = false;
            theaterAddress_textbox.Enabled = false;

            roomNumber_textbox.Enabled = false;
            roomCapacity_textbox.Enabled = false;

        }

        private void movieTitle_textbox_TextChanged(object sender, EventArgs e)
        {
            MovieSearchDiabled();
        }

        private void movieReleaseDate_textbox_TextChanged(object sender, EventArgs e)
        {
            MovieSearchDiabled();
        }

        private void movieDuration_textbox_TextChanged(object sender, EventArgs e)
        {
            MovieSearchDiabled();
        }

        private void movieBudget_textbox_TextChanged(object sender, EventArgs e)
        {
            MovieSearchDiabled();
        }

        private void movieRevenue_textbox_TextChanged(object sender, EventArgs e)
        {
            MovieSearchDiabled();
        }

        private void movieGenre_textbox_TextChanged(object sender, EventArgs e)
        {
            MovieSearchDiabled();
        }

        private void movieRating_textbox_TextChanged(object sender, EventArgs e)
        {
            MovieSearchDiabled();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            MovieSearchDiabled();
        }

        private void actorFirstName_textbox_TextChanged(object sender, EventArgs e)
        {
            ActorSearchDisabled();        
        }

        private void actorLastName_textbox_TextChanged(object sender, EventArgs e)
        {
            ActorSearchDisabled();
        }

        private void theaterName_textbox_TextChanged(object sender, EventArgs e)
        {
            TheaterSearchDisabled();
        }

        private void theaterAddress_textbox_TextChanged(object sender, EventArgs e)
        {
            TheaterSearchDisabled();
        }

        private void roomNumber_textbox_TextChanged(object sender, EventArgs e)
        {
            RoomSearchDisabled();
        }

        private void roomCapacity_textbox_TextChanged(object sender, EventArgs e)
        {
            RoomSearchDisabled();
        }

        private void dateStart_textbox_TextChanged(object sender, EventArgs e)
        {
            DateSearchDisabled();
        }

        private void dateEnd_textbox_TextChanged(object sender, EventArgs e)
        {
            DateSearchDisabled();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void reset_button_Click(object sender, EventArgs e)
        {
            ResetSearch();
            ResetSearch();
        }

        private void ResetSearch()
        {
            movieTitle_textbox.Enabled = true;
            movieReleaseDate_textbox.Enabled = true;
            movieDuration_textbox.Enabled = true;
            movieRevenue_textbox.Enabled = true;
            movieRating_textbox.Enabled = true;
            movieGenre_textbox.Enabled = true;

            actorFirstName_textbox.Enabled = true;
            actorLastName_textbox.Enabled = true;

            theaterName_textbox.Enabled = true;
            theaterAddress_textbox.Enabled = true;

            roomNumber_textbox.Enabled = true;
            roomCapacity_textbox.Enabled = true;

            dateStart_textbox.Enabled = true;
            dateEnd_textbox.Enabled = true;

            movieTitle_textbox.Text = null;
            movieReleaseDate_textbox.Text = null;
            movieDuration_textbox.Text = null;
            movieRevenue_textbox.Text = null;
            movieRating_textbox.Text = null;
            movieGenre_textbox.Text = null;

            actorFirstName_textbox.Text = null;
            actorLastName_textbox.Text = null;

            theaterName_textbox.Text = null;
            theaterAddress_textbox.Text = null;

            roomNumber_textbox.Text = null;
            roomCapacity_textbox.Text = null;

            dateStart_textbox.Text = null;
            dateEnd_textbox.Text = null;
        }
    }
}
