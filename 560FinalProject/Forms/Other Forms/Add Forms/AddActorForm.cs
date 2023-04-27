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
    public partial class AddActorForm : Form
    {
        AddForm AF;

        Operations O;

        public AddActorForm(AddForm af, Operations o)
        {
            InitializeComponent();
            AF = af;
            O = o;
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(actorFirstName_textbox.Text) && !string.IsNullOrEmpty(actorLastName_textbox.Text) && !string.IsNullOrEmpty(actorMovieList_textbox.Text))
            {
                O.CreateActor(actorFirstName_textbox.Text, actorLastName_textbox.Text, actorMovieList_textbox.Text);
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
