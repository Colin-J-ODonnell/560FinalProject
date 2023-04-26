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
    public partial class AddTheaterForm : Form
    {
        AddForm AF;

        Operations O;

        public AddTheaterForm(AddForm af, Operations o)
        {
            InitializeComponent();
            AF = af;
            O = o;
        }   

        private void add_button_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(theaterName_textbox.Text) && !string.IsNullOrEmpty(theaterAddress_textbox.Text))
            {
                O.CreateTheater(theaterName_textbox.Text, theaterAddress_textbox.Text);
            }
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            this.Close();
            AF.Show();
        }
    }
}
