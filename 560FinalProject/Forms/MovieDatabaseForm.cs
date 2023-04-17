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
    public partial class MovieDatabaseForm : Form
    {
        OpeningForm OF { get; set; }

        public MovieDatabaseForm(OpeningForm of)
        {
            InitializeComponent();
            OF = of;
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            Database_OutputForm of = new Database_OutputForm(this);
            this.Hide();
            of.Show();
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            this.Close();
            OF.Show();
        }

        private void MovieDatabaseForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
