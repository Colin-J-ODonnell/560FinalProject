using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _560FinalProject.Forms.Other_Forms
{
    public partial class ChoiceForm : Form
    {
        public int choice;

        public EditForm ef;
        public MovieDatabaseForm mdf;
        public Operations O;
        string input;
        public ChoiceForm(MovieDatabaseForm mdf, Operations O, string item)
        {
            InitializeComponent();
            this.mdf = mdf;
            this.O = O;
            input = item;
        }

        private void editTheater_button_Click(object sender, EventArgs e)
        {
            choice = 3;
            ef = new EditForm(mdf, O, choice, input);
            ef.Show();
            this.Close();
        }

        private void editShowtime_button_Click(object sender, EventArgs e)
        {
            choice = 4;
            ef = new EditForm(mdf, O, choice, input);
            ef.Show();
            this.Close();
        }

        private void editRoom_button_Click(object sender, EventArgs e)
        {
            choice = 5;
            ef = new EditForm(mdf, O, choice, input);
            ef.Show();
            this.Close();
        }
        
    }
}
