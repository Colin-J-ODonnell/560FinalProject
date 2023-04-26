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

        public EditForm(MovieDatabaseForm mdf, Operations o)
        {
            InitializeComponent();
            MDF = mdf;
            O = o;
        }

        private void edit_button_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(movieTitle_textbox.Text) && !string.IsNullOrEmpty(movieDuration_textbox.Text) && !string.IsNullOrEmpty(movieReleaseDate_textbox.Text) &&
                    !string.IsNullOrEmpty(movieTitle_textbox.Text) && !string.IsNullOrEmpty(movieRating_textbox.Text))
            {
                // Edit code from Operations here.
            }
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            this.Close();
            MDF.Show();
        }
    }
}
