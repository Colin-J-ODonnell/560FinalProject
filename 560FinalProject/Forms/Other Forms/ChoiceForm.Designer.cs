namespace _560FinalProject.Forms.Other_Forms
{
    partial class ChoiceForm
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
            this.editRoom_button = new System.Windows.Forms.Button();
            this.editShowtime_button = new System.Windows.Forms.Button();
            this.editTheater_button = new System.Windows.Forms.Button();
            this.edit_label = new System.Windows.Forms.Label();
            this.editMovie_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // editRoom_button
            // 
            this.editRoom_button.Font = new System.Drawing.Font("Segoe UI Symbol", 14.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editRoom_button.Location = new System.Drawing.Point(649, 88);
            this.editRoom_button.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.editRoom_button.Name = "editRoom_button";
            this.editRoom_button.Size = new System.Drawing.Size(300, 105);
            this.editRoom_button.TabIndex = 0;
            this.editRoom_button.Text = "Room";
            this.editRoom_button.UseVisualStyleBackColor = true;
            this.editRoom_button.Click += new System.EventHandler(this.editRoom_button_Click);
            // 
            // editShowtime_button
            // 
            this.editShowtime_button.Font = new System.Drawing.Font("Segoe UI Symbol", 14.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editShowtime_button.Location = new System.Drawing.Point(333, 88);
            this.editShowtime_button.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.editShowtime_button.Name = "editShowtime_button";
            this.editShowtime_button.Size = new System.Drawing.Size(300, 105);
            this.editShowtime_button.TabIndex = 1;
            this.editShowtime_button.Text = "Showtime";
            this.editShowtime_button.UseVisualStyleBackColor = true;
            this.editShowtime_button.Click += new System.EventHandler(this.editShowtime_button_Click);
            // 
            // editTheater_button
            // 
            this.editTheater_button.Font = new System.Drawing.Font("Segoe UI Symbol", 14.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editTheater_button.Location = new System.Drawing.Point(17, 88);
            this.editTheater_button.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.editTheater_button.Name = "editTheater_button";
            this.editTheater_button.Size = new System.Drawing.Size(300, 105);
            this.editTheater_button.TabIndex = 2;
            this.editTheater_button.Text = "Theater";
            this.editTheater_button.UseVisualStyleBackColor = true;
            this.editTheater_button.Click += new System.EventHandler(this.editTheater_button_Click);
            // 
            // edit_label
            // 
            this.edit_label.AutoSize = true;
            this.edit_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edit_label.Location = new System.Drawing.Point(281, 20);
            this.edit_label.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.edit_label.Name = "edit_label";
            this.edit_label.Size = new System.Drawing.Size(696, 61);
            this.edit_label.TabIndex = 3;
            this.edit_label.Text = "What would you like to Edit:";
            // 
            // editMovie_button
            // 
            this.editMovie_button.Font = new System.Drawing.Font("Segoe UI Symbol", 14.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editMovie_button.Location = new System.Drawing.Point(965, 88);
            this.editMovie_button.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.editMovie_button.Name = "editMovie_button";
            this.editMovie_button.Size = new System.Drawing.Size(300, 105);
            this.editMovie_button.TabIndex = 4;
            this.editMovie_button.Text = "Movie";
            this.editMovie_button.UseVisualStyleBackColor = true;
            this.editMovie_button.Click += new System.EventHandler(this.editMovie_button_Click);
            // 
            // ChoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 207);
            this.Controls.Add(this.editMovie_button);
            this.Controls.Add(this.edit_label);
            this.Controls.Add(this.editTheater_button);
            this.Controls.Add(this.editShowtime_button);
            this.Controls.Add(this.editRoom_button);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "ChoiceForm";
            this.Text = "ChoiceForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button editRoom_button;
        private System.Windows.Forms.Button editShowtime_button;
        private System.Windows.Forms.Button editTheater_button;
        private System.Windows.Forms.Label edit_label;
        private System.Windows.Forms.Button editMovie_button;
    }
}