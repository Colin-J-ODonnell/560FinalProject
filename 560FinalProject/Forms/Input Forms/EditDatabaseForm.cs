using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _560FinalProject.Forms
{
    public partial class EditDatabaseForm : Form
    {
        OpeningForm OF { get; set; }

        Operations O { get; set; }

        public EditDatabaseForm(OpeningForm of, Operations o)
        {
            InitializeComponent();
            OF = of;
            O = o;
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            this.Close();
            OF.Show();
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            
        }

        private void truncate_button_Click(object sender, EventArgs e)
        {

        }
    }
}
