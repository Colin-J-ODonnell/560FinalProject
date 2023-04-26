namespace _560FinalProject.Forms.Other_Forms.Add_Forms
{
    partial class AddRoomForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.roomNumber_textbox = new System.Windows.Forms.TextBox();
            this.roomCapacity_textbox = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.back_button = new System.Windows.Forms.Button();
            this.add_button = new System.Windows.Forms.Button();
            this.roomTheaterID_texbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // roomNumber_textbox
            // 
            this.roomNumber_textbox.Location = new System.Drawing.Point(254, 82);
            this.roomNumber_textbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.roomNumber_textbox.Name = "roomNumber_textbox";
            this.roomNumber_textbox.Size = new System.Drawing.Size(340, 38);
            this.roomNumber_textbox.TabIndex = 42;
            // 
            // roomCapacity_textbox
            // 
            this.roomCapacity_textbox.Location = new System.Drawing.Point(185, 147);
            this.roomCapacity_textbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.roomCapacity_textbox.Name = "roomCapacity_textbox";
            this.roomCapacity_textbox.Size = new System.Drawing.Size(409, 38);
            this.roomCapacity_textbox.TabIndex = 41;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(46, 149);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(133, 32);
            this.label19.TabIndex = 40;
            this.label19.Text = "Capacity:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(43, 85);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(204, 32);
            this.label20.TabIndex = 39;
            this.label20.Text = "Room Number:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI Symbol", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(22, 18);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(229, 46);
            this.label21.TabIndex = 38;
            this.label21.Text = "Room Search";
            // 
            // back_button
            // 
            this.back_button.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold);
            this.back_button.Location = new System.Drawing.Point(346, 274);
            this.back_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.back_button.Name = "back_button";
            this.back_button.Size = new System.Drawing.Size(245, 67);
            this.back_button.TabIndex = 118;
            this.back_button.Text = "BACK";
            this.back_button.UseVisualStyleBackColor = true;
            this.back_button.Click += new System.EventHandler(this.back_button_Click);
            // 
            // add_button
            // 
            this.add_button.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold);
            this.add_button.Location = new System.Drawing.Point(46, 274);
            this.add_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.add_button.Name = "add_button";
            this.add_button.Size = new System.Drawing.Size(245, 67);
            this.add_button.TabIndex = 117;
            this.add_button.Text = "ADD";
            this.add_button.UseVisualStyleBackColor = true;
            this.add_button.Click += new System.EventHandler(this.add_button_Click);
            // 
            // roomTheaterID_texbox
            // 
            this.roomTheaterID_texbox.Location = new System.Drawing.Point(196, 211);
            this.roomTheaterID_texbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.roomTheaterID_texbox.Name = "roomTheaterID_texbox";
            this.roomTheaterID_texbox.Size = new System.Drawing.Size(395, 38);
            this.roomTheaterID_texbox.TabIndex = 122;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 32);
            this.label2.TabIndex = 121;
            this.label2.Text = "TheaterID:";
            // 
            // AddRoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 370);
            this.Controls.Add(this.roomTheaterID_texbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.back_button);
            this.Controls.Add(this.add_button);
            this.Controls.Add(this.roomNumber_textbox);
            this.Controls.Add(this.roomCapacity_textbox);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Name = "AddRoomForm";
            this.Text = "AddRoomForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox roomNumber_textbox;
        private System.Windows.Forms.TextBox roomCapacity_textbox;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button back_button;
        private System.Windows.Forms.Button add_button;
        private System.Windows.Forms.TextBox roomTheaterID_texbox;
        private System.Windows.Forms.Label label2;
    }
}