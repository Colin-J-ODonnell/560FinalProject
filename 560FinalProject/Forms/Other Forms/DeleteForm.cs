using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _560FinalProject.Forms.Other_Forms
{
    public partial class DeleteForm : Form
    {
        MovieDatabaseForm MDF { get; set; }

        Operations O { get; set; }

        /// <summary>
        /// Value assigned when user pics the search to complete 
        /// 1 = Remove Movie 
        /// 2 = Remove Actor
        /// 3 = Remove Theater
        /// 4 = Remove Room
        /// 0 = NONE
        /// </summary>
        public int REMOVEVALUE = 0;

        public string DeleteInput;

        public DeleteForm(MovieDatabaseForm mdf, Operations o, string input)
        {
            InitializeComponent();
            MDF = mdf;
            O = o;
            DeleteInput = input;
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            if(REMOVEVALUE != 0)
            {
                string input = DeleteInput;
                string[] strs = input.Split(',');
                int id = 0;

                switch (REMOVEVALUE)
                {
                    case 1:
                        id = Convert.ToInt32(strs[0]);
                        O.RemoveMovie(id);
                        break;
                    case 2:
                        id = Convert.ToInt32(strs[0]);
                        O.RemoveActor(id);
                        break;
                    case 3:
                        id = Convert.ToInt32(strs[0]);
                        O.RemoveTheater(id);
                        break;
                    case 4:
                        id = Convert.ToInt32(strs[0]);
                        O.RemoveRoom(Convert.ToInt32(strs[3]));
                        break;
                    default:
                        MessageBox.Show("Not an item you can remove!");
                        break;
                }

                this.Close();
            }
            else MessageBox.Show("No item selected!!");
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            this.Close();
            MDF.Show();
        }

        private void movie_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (movie_checkbox.Checked)
            {
                REMOVEVALUE = 1;
                theater_checkbox.Enabled = false;
                actor_checkbox.Enabled = false;
                room_checkbox.Enabled = false;
            }
            else
            {
                REMOVEVALUE = 0;
                theater_checkbox.Enabled = true;
                actor_checkbox.Enabled = true;
                room_checkbox.Enabled = true;
            }
        }

        private void theater_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (theater_checkbox.Checked)
            {
                REMOVEVALUE = 3;
                movie_checkbox.Enabled = false;
                actor_checkbox.Enabled = false;
                room_checkbox.Enabled = false;
            }
            else
            {
                REMOVEVALUE = 0;
                movie_checkbox.Enabled = true;
                actor_checkbox.Enabled = true;
                room_checkbox.Enabled = true;
            }
        }

        private void actor_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (actor_checkbox.Checked)
            {
                REMOVEVALUE = 2;
                theater_checkbox.Enabled = false;
                movie_checkbox.Enabled = false;
                room_checkbox.Enabled = false;
            }
            else
            {
                REMOVEVALUE = 0;
                theater_checkbox.Enabled = true;
                movie_checkbox.Enabled = true;
                room_checkbox.Enabled = true;
            }
        }

        private void room_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (room_checkbox.Checked)
            {
                REMOVEVALUE = 4;
                theater_checkbox.Enabled = false;
                actor_checkbox.Enabled = false;
                movie_checkbox.Enabled = false;
            }
            else
            {
                REMOVEVALUE = 0;
                theater_checkbox.Enabled = true;
                actor_checkbox.Enabled = true;
                movie_checkbox.Enabled = true;
            }
        }
    }
}
