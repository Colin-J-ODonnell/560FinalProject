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
        public MovieDatabaseForm MDF;
        public Operations O;
        string input;

        public ChoiceForm(MovieDatabaseForm mdf, Operations O, string item)
        {
            InitializeComponent();
            this.MDF = mdf;
            this.O = O;
            input = item;
        }

        private void editTheater_button_Click(object sender, EventArgs e)
        {
            choice = 3;
            EditForm ef = new EditForm(MDF, O, choice, input);
            ef.Show();
            this.Close();
        }

        private void editShowtime_button_Click(object sender, EventArgs e)
        {
            choice = 4;
            EditForm ef = new EditForm(MDF, O, choice, input);
            ef.Show();
            this.Close();
        }

        private void editRoom_button_Click(object sender, EventArgs e)
        {
            choice = 5;
            EditForm ef = new EditForm(MDF, O, choice, input);
            ef.Show();
            this.Close();
        }

        private void editMovie_button_Click(object sender, EventArgs e)
        {
            choice = 1;
            EditForm ef = new EditForm(MDF, O, choice, input);
            ef.Show();
            this.Close();
        }
    }
}
