namespace _560FinalProject.Forms.Other_Forms.Add_Forms
{
    partial class AddActorForm
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
            this.actorFirstName_textbox = new System.Windows.Forms.TextBox();
            this.actorLastName_textbox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.back_button = new System.Windows.Forms.Button();
            this.add_button = new System.Windows.Forms.Button();
            this.actorMovieList_textbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // actorFirstName_textbox
            // 
            this.actorFirstName_textbox.Location = new System.Drawing.Point(213, 79);
            this.actorFirstName_textbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.actorFirstName_textbox.Name = "actorFirstName_textbox";
            this.actorFirstName_textbox.Size = new System.Drawing.Size(385, 38);
            this.actorFirstName_textbox.TabIndex = 27;
            // 
            // actorLastName_textbox
            // 
            this.actorLastName_textbox.Location = new System.Drawing.Point(210, 139);
            this.actorLastName_textbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.actorLastName_textbox.Name = "actorLastName_textbox";
            this.actorLastName_textbox.Size = new System.Drawing.Size(388, 38);
            this.actorLastName_textbox.TabIndex = 26;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(47, 141);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(158, 32);
            this.label12.TabIndex = 25;
            this.label12.Text = "Last Name:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(47, 82);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(159, 32);
            this.label13.TabIndex = 24;
            this.label13.Text = "First Name:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Symbol", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(26, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(223, 46);
            this.label11.TabIndex = 23;
            this.label11.Text = "Actor Search";
            // 
            // back_button
            // 
            this.back_button.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold);
            this.back_button.Location = new System.Drawing.Point(354, 277);
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
            this.add_button.Location = new System.Drawing.Point(54, 277);
            this.add_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.add_button.Name = "add_button";
            this.add_button.Size = new System.Drawing.Size(245, 67);
            this.add_button.TabIndex = 117;
            this.add_button.Text = "ADD";
            this.add_button.UseVisualStyleBackColor = true;
            this.add_button.Click += new System.EventHandler(this.add_button_Click);
            // 
            // actorMovieList_textbox
            // 
            this.actorMovieList_textbox.Location = new System.Drawing.Point(231, 203);
            this.actorMovieList_textbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.actorMovieList_textbox.Name = "actorMovieList_textbox";
            this.actorMovieList_textbox.Size = new System.Drawing.Size(368, 38);
            this.actorMovieList_textbox.TabIndex = 122;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 32);
            this.label2.TabIndex = 121;
            this.label2.Text = "MovieID List:";
            // 
            // AddActorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 380);
            this.Controls.Add(this.actorMovieList_textbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.back_button);
            this.Controls.Add(this.add_button);
            this.Controls.Add(this.actorFirstName_textbox);
            this.Controls.Add(this.actorLastName_textbox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Name = "AddActorForm";
            this.Text = "AddActor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox actorFirstName_textbox;
        private System.Windows.Forms.TextBox actorLastName_textbox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button back_button;
        private System.Windows.Forms.Button add_button;
        private System.Windows.Forms.TextBox actorMovieList_textbox;
        private System.Windows.Forms.Label label2;
    }
}