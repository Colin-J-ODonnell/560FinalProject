using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _560FinalProject.Forms.Other_Forms.Add_Forms
{
    public partial class AddMovieForm : Form
    {
        AddForm AF;

        Operations O;

        public AddMovieForm(AddForm af, Operations o)
        {
            InitializeComponent();
            AF = af;
            O = o;
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(movieTitle_textbox.Text) && !string.IsNullOrEmpty(movieDuration_textbox.Text) && !string.IsNullOrEmpty(movieReleaseDate_textbox.Text) &&
                    !string.IsNullOrEmpty(movieTitle_textbox.Text) && !string.IsNullOrEmpty(movieRating_textbox.Text))
            {
                O.CreateMovie(movieTitle_textbox.Text, Convert.ToInt32(movieDuration_textbox.Text), Convert.ToInt32(movieReleaseDate_textbox.Text),
                    movieRevenue_textbox.Text, Convert.ToDouble(movieRating_textbox.Text));
                AF.MDF.Search(AF.MDF.SORT);
                this.Close();
            }
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            this.Close();
            AF.Show();
        }
    }
}
