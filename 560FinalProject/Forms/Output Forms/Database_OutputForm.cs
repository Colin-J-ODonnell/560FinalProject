using System;
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
    public partial class Database_OutputForm : Form
    {
        MovieDatabaseForm MDF { get; set; }

        Operations O { get; set; }

        public Database_OutputForm(MovieDatabaseForm mdf, Operations o)
        {
            InitializeComponent();
            MDF = mdf;
            O = o;
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            this.Close();
            MDF.Show();
        }
    }
}
