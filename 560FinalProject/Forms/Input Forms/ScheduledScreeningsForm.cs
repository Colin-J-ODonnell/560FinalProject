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

        Operations O { get; set; }

        /// <summary>
        /// Value assigned when user pics the search to complete 
        /// 1 = MovieSearch
        /// 2 = Actor Seach
        /// 3 = TRD Search
        /// 4 = Genre Search
        /// 0 = RESET
        /// </summary>
        public int SEARCHVALUE = 0;

        public ScheduledScreeningsForm(OpeningForm of, Operations o)
        {
            InitializeComponent();
            OF = of;
            O = o;
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            List<string> output = new List<string>();

            if (SEARCHVALUE == 1)
            {
                List<string> input = new List<string>();
                input.Add(movieTitle_textbox.Text);
                input.Add(movieReleaseDate_textbox.Text);
                input.Add(movieDuration_textbox.Text);
                input.Add(movieRevenue_textbox.Text);
                input.Add(movieRating_textbox.Text);
                output = O.MovieSearch(SEARCHVALUE, input);
            }

            output_listbox.DataSource = output;
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            this.Close();
            OF.Show();
        }
    }
}
