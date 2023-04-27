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
            this.SuspendLayout();
            // 
            // editRoom_button
            // 
            this.editRoom_button.Location = new System.Drawing.Point(224, 37);
            this.editRoom_button.Name = "editRoom_button";
            this.editRoom_button.Size = new System.Drawing.Size(101, 44);
            this.editRoom_button.TabIndex = 0;
            this.editRoom_button.Text = "Room";
            this.editRoom_button.UseVisualStyleBackColor = true;
            this.editRoom_button.Click += new System.EventHandler(this.editRoom_button_Click);
            // 
            // editShowtime_button
            // 
            this.editShowtime_button.Location = new System.Drawing.Point(117, 37);
            this.editShowtime_button.Name = "editShowtime_button";
            this.editShowtime_button.Size = new System.Drawing.Size(101, 44);
            this.editShowtime_button.TabIndex = 1;
            this.editShowtime_button.Text = "Showtime";
            this.editShowtime_button.UseVisualStyleBackColor = true;
            this.editShowtime_button.Click += new System.EventHandler(this.editShowtime_button_Click);
            // 
            // editTheater_button
            // 
            this.editTheater_button.Location = new System.Drawing.Point(10, 37);
            this.editTheater_button.Name = "editTheater_button";
            this.editTheater_button.Size = new System.Drawing.Size(101, 44);
            this.editTheater_button.TabIndex = 2;
            this.editTheater_button.Text = "Theater";
            this.editTheater_button.UseVisualStyleBackColor = true;
            this.editTheater_button.Click += new System.EventHandler(this.editTheater_button_Click);
            // 
            // edit_label
            // 
            this.edit_label.AutoSize = true;
            this.edit_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edit_label.Location = new System.Drawing.Point(20, 9);
            this.edit_label.Name = "edit_label";
            this.edit_label.Size = new System.Drawing.Size(305, 25);
            this.edit_label.TabIndex = 3;
            this.edit_label.Text = "What would you like to Edit:";
            // 
            // ChoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 87);
            this.Controls.Add(this.edit_label);
            this.Controls.Add(this.editTheater_button);
            this.Controls.Add(this.editShowtime_button);
            this.Controls.Add(this.editRoom_button);
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
    }
}