using _560FinalProject.Forms.Other_Forms;
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
        /// 1 = Movie Search
        /// 2 = Actor Search
        /// 3 = TRD Search
        /// 4 = Genre Search
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
            List<string> output = new List<string>();
            int numUpDwn = Convert.ToInt32(numericUpDown1.Value);
            if (SEARCHVALUE == 1)
            {
                List<string> input = new List<string>();
                input.Add(movieTitle_textbox.Text);
                input.Add(movieReleaseDate_textbox.Text);
                input.Add(movieDuration_textbox.Text);
                input.Add(movieRevenue_textbox.Text);
                input.Add(movieRating_textbox.Text);
                output = O.MovieSearch(SEARCHVALUE, input, numUpDwn);
            }
            if (SEARCHVALUE == 2)
            {
                List<string> input = new List<string>();
                input.Add(actorFirstName_textbox.Text);
                input.Add(actorLastName_textbox.Text);
                output = O.MovieSearch(SEARCHVALUE, input, numUpDwn);
            }
            if (SEARCHVALUE == 3)
            {
                List<string> input = new List<string>();
                input.Add(theaterName_textbox.Text);
                input.Add(theaterAddress_textbox.Text);
                input.Add(roomNumber_textbox.Text);
                input.Add(roomCapacity_textbox.Text);
                input.Add(dateStart_textbox.Text);
                input.Add(dateEnd_textbox.Text);
                output = O.MovieSearch(SEARCHVALUE, input, numUpDwn);
            }
            if (SEARCHVALUE == 4)
            {
                List<string> input = new List<string>();
                input.Add(movieReleaseDate_textbox.Text);
                input.Add(movieRating_textbox.Text);
                input.Add(movieGenre_textbox.Text);
                output = O.MovieSearch(SEARCHVALUE, input, numUpDwn);
            }

            output_listbox.DataSource = output;
        }

        private void reset_button_Click(object sender, EventArgs e)
        {
            ResetSearch();
            ResetSearch();
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            AddForm af = new AddForm(this, O);
            af.Show();
        }

        private void update_button_Click(object sender, EventArgs e)
        {
            if (output_listbox.SelectedItem != null)
            {
                EditForm ef = new EditForm(this, O, SEARCHVALUE, output_listbox.SelectedItem.ToString());
                ef.Show();
            }
            else MessageBox.Show("No selected item!");
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            if (output_listbox.SelectedItem != null)
            {
                DeleteForm df = new DeleteForm(this, O, output_listbox.SelectedItem.ToString());
                df.Show();
            }
            else MessageBox.Show("No selected item!");
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            this.Close();
            OF.Show();
        }

        private void MovieSearchDiabled()
        {
            SEARCHVALUE = 1;
            actorFirstName_textbox.Enabled = false;
            actorLastName_textbox.Enabled = false;

            theaterName_textbox.Enabled = false;
            theaterAddress_textbox.Enabled = false;

            roomNumber_textbox.Enabled = false;
            roomCapacity_textbox.Enabled = false;

            dateStart_textbox.Enabled = false;
            dateEnd_textbox.Enabled = false;

            movieGenre_textbox.Enabled = false;
        }

        private void ActorSearchDisabled()
        {
            SEARCHVALUE = 2;
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

        private void TRDSearch()
        {
            SEARCHVALUE = 3;
            movieTitle_textbox.Enabled = false;
            movieReleaseDate_textbox.Enabled = false;
            movieDuration_textbox.Enabled = false;
            movieRevenue_textbox.Enabled = false;
            movieRating_textbox.Enabled = false;
            actorFirstName_textbox.Enabled = false;
            actorLastName_textbox.Enabled = false;
            movieGenre_textbox.Enabled = false;
        }

        private void GenreSearchDisabled()
        {
            movieTitle_textbox.Enabled = false;
            movieDuration_textbox.Enabled = false;
            movieRevenue_textbox.Enabled = false;
            theaterName_textbox.Enabled = false;
            theaterAddress_textbox.Enabled = false;
            roomNumber_textbox.Enabled = false;
            roomCapacity_textbox.Enabled = false;
            dateStart_textbox.Enabled = false;
            dateEnd_textbox.Enabled = false;
            actorFirstName_textbox.Enabled = false;
            actorLastName_textbox.Enabled = false;
            SEARCHVALUE = 4;
        }

        private void ResetSearch()
        {
            SEARCHVALUE = 0;

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

        private void movieTitle_textbox_TextChanged(object sender, EventArgs e)
        {
            MovieSearchDiabled();
        }

        private void movieReleaseDate_textbox_TextChanged(object sender, EventArgs e)
        {
            if (SEARCHVALUE != 4)
            {
                MovieSearchDiabled();
            }
            else GenreSearchDisabled();
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
            GenreSearchDisabled();
        }

        private void movieRating_textbox_TextChanged(object sender, EventArgs e)
        {
            if (SEARCHVALUE != 4)
            {
                MovieSearchDiabled();
            }
            else GenreSearchDisabled();
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
            TRDSearch();
        }

        private void theaterAddress_textbox_TextChanged(object sender, EventArgs e)
        {
            TRDSearch();
        }

        private void roomNumber_textbox_TextChanged(object sender, EventArgs e)
        {
            TRDSearch();
        }

        private void roomCapacity_textbox_TextChanged(object sender, EventArgs e)
        {
            TRDSearch();
        }

        private void dateStart_textbox_TextChanged(object sender, EventArgs e)
        {
            TRDSearch();
        }

        private void dateEnd_textbox_TextChanged(object sender, EventArgs e)
        {
            TRDSearch();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
