using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _560FinalProject.Forms.Other_Forms.Add_Forms
{
    public partial class AddRoomForm : Form
    {
        AddForm AF;

        Operations O;

        public AddRoomForm(AddForm af, Operations o)
        {
            InitializeComponent();
            AF = af;
            O = o;
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(roomNumber_textbox.Text) && !string.IsNullOrEmpty(roomCapacity_textbox.Text) && !string.IsNullOrEmpty(roomTheaterID_texbox.Text))
            {
                O.CreateRoom(Convert.ToInt32(roomNumber_textbox.Text), Convert.ToInt32(roomCapacity_textbox.Text), Convert.ToInt32(roomTheaterID_texbox.Text));
                this.Close();
            }
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            this.Close();
            AF.Show();
        }
    }
}
