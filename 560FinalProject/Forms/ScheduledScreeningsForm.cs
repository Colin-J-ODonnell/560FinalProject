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
    public partial class ScheduledScreeningsForm : Form
    {
        OpeningForm OF { get; set; }

        public ScheduledScreeningsForm(OpeningForm of)
        {
            InitializeComponent();
            OF = of;
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            Screenings_OutputForm sof = new Screenings_OutputForm(this);
            this.Hide();
            sof.Show();
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            this.Close();
            OF.Show();
        }
    }
}
