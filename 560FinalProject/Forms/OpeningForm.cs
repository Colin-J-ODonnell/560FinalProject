﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _560FinalProject
{
    public partial class OpeningForm : Form
    {
        Operations O { get; set; }

        public OpeningForm(Operations o)
        {
            InitializeComponent();
            O = o;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void database_button_Click(object sender, EventArgs e)
        {
            MovieDatabaseForm mdf = new MovieDatabaseForm(this, O);
            this.Hide();
            mdf.Show();
        }

        private void schedule_button_Click(object sender, EventArgs e)
        {
            ScheduledScreeningsForm ssf = new ScheduledScreeningsForm(this, O);
            this.Hide();
            ssf.Show();
        }
    }
}
