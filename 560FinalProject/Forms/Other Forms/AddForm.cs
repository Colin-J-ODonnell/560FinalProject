using _560FinalProject.Forms.Other_Forms.Add_Forms;
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
    public partial class AddForm : Form
    {
        MovieDatabaseForm MDF;

        Operations O;

        public AddForm(MovieDatabaseForm mdf, Operations o)
        {
            InitializeComponent();
            MDF = mdf;
            O = o;
        }

        private void movie_button_Click(object sender, EventArgs e)
        {
            AddMovieForm amf = new AddMovieForm(this, O);
            this.Hide();
            amf.Show();
        }

        private void theater_button_Click(object sender, EventArgs e)
        {
            AddTheaterForm atf = new AddTheaterForm(this, O);
            this.Hide();
            atf.Show();
        }

        private void actor_button_Click(object sender, EventArgs e)
        {
            AddActorForm aaf = new AddActorForm(this, O);
            this.Hide();
            aaf.Show();
        }

        private void room_button_Click(object sender, EventArgs e)
        {
            AddRoomForm arf = new AddRoomForm(this, O);
            this.Hide();
            arf.Show();
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            this.Close();
            MDF.Show();
        }
    }
}
