using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _560FinalProject.Forms.Other_Forms
{
    public partial class EditForm : Form
    {
        MovieDatabaseForm MDF;

        Operations O;

        public string Data;

        /// <summary>
        /// Value assigned when user pics the edit to complete 
        /// 1 = Movie Edit
        /// 2 = Actor Edit
        /// 3 = Theater
        /// 4 = Showtime
        /// 5 = Room
        /// </summary>
        public int EDITVALUE;


        public EditForm(MovieDatabaseForm mdf, Operations o, int value, string input)
        {
            InitializeComponent();
            MDF = mdf;
            O = o;
            EDITVALUE = value;
            Data = input;

            SetTextboxOnStart();
            SetTextboxValuesOnStart();
        }

        private void edit_button_Click(object sender, EventArgs e)
        {
            switch (EDITVALUE)
            {
                case 1:
                    // M.MovieID, M.Title, M.ReleaseYear, M.Duration, M.Gross, M.Rating
                    if (!string.IsNullOrEmpty(movieTitle_textbox.Text) && !string.IsNullOrEmpty(movieDuration_textbox.Text) && !string.IsNullOrEmpty(movieReleaseDate_textbox.Text) &&
                    !string.IsNullOrEmpty(movieRevenue_textbox.Text) && !string.IsNullOrEmpty(movieRating_textbox.Text))
                    {
                        string[] split = Data.Split(',');
                        O.UpdateMovie(movieTitle_textbox.Text, Convert.ToInt32(movieDuration_textbox.Text), Convert.ToInt32(movieReleaseDate_textbox.Text), movieRevenue_textbox.Text, Convert.ToDouble(movieRating_textbox.Text),Convert.ToInt32(split[0]));
                        this.Close();
                    }
                    else MessageBox.Show("Please input all required Data.");
                    break;
                case 2:
                    // A.ActorID A.FirstName, A.LastName, M.Title
                    if (!string.IsNullOrEmpty(actorFirstName_textbox.Text) && !string.IsNullOrEmpty(actorLastName_textbox.Text) && !string.IsNullOrEmpty(movieTitle_textbox.Text))
                    {
                        // Edit code from Operations here.
                    }
                    else MessageBox.Show("Please input all required Data.");
                    break;
                case 3:
                    // T.TheaterID, R.RoomID, T.[Name], M.Title, ST.Showtime
                    if (!string.IsNullOrEmpty(theaterName_textbox.Text) && !string.IsNullOrEmpty(theaterAddress_textbox.Text))
                    {
                        string[] split = Data.Split(',');
                        O.UpdateTheater(theaterName_textbox.Text, theaterAddress_textbox.Text);
                    }
                    else MessageBox.Show("Please input all required Data.");
                    break;
                default:
                    MessageBox.Show("Edit value not accepted!");
                    break;
            }
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            this.Close();
            MDF.Show();
        }

        private void SetTextboxOnStart()
        {
            switch (EDITVALUE)
            {
                case 1:
                    GenreOptionsOFF();
                    ActorOptionsOFF();
                    TDROptionsOFF();
                    break;
                case 2:
                    MovieOptionsOFF();
                    GenreOptionsOFF();
                    TDROptionsOFF();
                    break;
                case 3:
                    MovieOptionsOFF();
                    ActorOptionsOFF();
                    GenreOptionsOFF();
                    break;
                default:
                    break;
            }
        }

        private void SetTextboxValuesOnStart()
        {
            string[] input = Data.Split(',');

            switch (EDITVALUE)
            {
                case 1:
                    // M.MovieID, M.Title, M.ReleaseYear, M.Duration, M.Gross, M.Rating
                    movieTitle_textbox.Text = input[1];
                    movieReleaseDate_textbox.Text = input[2];
                    movieDuration_textbox.Text = input[3];
                    movieRevenue_textbox.Text = input[4];
                    movieRating_textbox.Text = input[5];
                    break;
                case 2:
                    // A.ActorID A.FirstName, A.LastName, M.Title
                    actorFirstName_textbox.Text = input[1];
                    actorLastName_textbox.Text = input[2];
                    movieTitle_textbox.Text = input[3];
                    break;
                case 3:
                    // T.TheaterID, R.RoomID, T.[Name], M.Title, ST.Showtime
                    theaterName_textbox.Text = input[1];
                    theaterAddress_textbox.Text = input[2];
                    movieTitle_textbox.Text = input[6];
                    break;
                case 4:
                    dateStart_textbox.Text = input[7];
                    break;
                case 5:
                    roomNumber_textbox.Text = input[4];
                    roomCapacity_textbox.Text = input[5];
                    break;
                default:
                    break;
            }
        }

        private void MovieOptionsOFF()
        {
            movieTitle_textbox.Enabled = false;
            movieDuration_textbox.Enabled = false;
            movieReleaseDate_textbox.Enabled = false;   
            movieRevenue_textbox.Enabled = false;
            movieRating_textbox.Enabled = false;
        }

        private void GenreOptionsOFF()
        {
            movieGenre_textbox.Enabled = false;
        }

        private void ActorOptionsOFF()
        {
            actorFirstName_textbox.Enabled = false;
            actorLastName_textbox.Enabled = false;
        }

        private void TDROptionsOFF()
        {
            theaterAddress_textbox.Enabled = false;
            theaterName_textbox.Enabled = false;

            roomCapacity_textbox.Enabled = false;
            roomNumber_textbox.Enabled = false;

            dateEnd_textbox.Enabled = false;
            dateStart_textbox.Enabled = false; 
        }

        private void EditForm_Load(object sender, EventArgs e)
        {

        }
    }
}
