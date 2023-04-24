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

        public Database_OutputForm(MovieDatabaseForm mdf, Operations o, List<int> MovieIDs, List<string> Titles, List<int> Release, List<int> Duration, List<string> Revenue, List<float> Ratings)
        {
            InitializeComponent();
            MDF = mdf;
            O = o;
            PopulateListBox(MovieIDs, Titles, Release, Duration, Revenue, Ratings);
        }

        private void PopulateListBox(List<int> MovieIDs, List<string> Titles, List<int> Release, List<int> Duration, List<string> Revenue, List<float> Ratings)
        {
            List<string> table = new List<string>();
            for(int i = 0; i < MovieIDs.Count; i++)
            {
                table.Add($"{MovieIDs[i]}, {Titles[i]}, {Release[i]}, {Duration[i]}, {Revenue[i]}, {Ratings[i]}");
            }
            listBox1.DataSource = table;
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            this.Close();
            MDF.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
