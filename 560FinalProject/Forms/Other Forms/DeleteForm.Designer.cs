namespace _560FinalProject.Forms.Other_Forms
{
    partial class DeleteForm
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
            this.delete_button = new System.Windows.Forms.Button();
            this.back_button = new System.Windows.Forms.Button();
            this.movie_checkbox = new System.Windows.Forms.CheckBox();
            this.room_checkbox = new System.Windows.Forms.CheckBox();
            this.actor_checkbox = new System.Windows.Forms.CheckBox();
            this.theater_checkbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // delete_button
            // 
            this.delete_button.Font = new System.Drawing.Font("Segoe UI Symbol", 14.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete_button.Location = new System.Drawing.Point(57, 213);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(323, 96);
            this.delete_button.TabIndex = 0;
            this.delete_button.Text = "DELETE";
            this.delete_button.UseVisualStyleBackColor = true;
            this.delete_button.Click += new System.EventHandler(this.delete_button_Click);
            // 
            // back_button
            // 
            this.back_button.Font = new System.Drawing.Font("Segoe UI Symbol", 14.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back_button.Location = new System.Drawing.Point(487, 213);
            this.back_button.Name = "back_button";
            this.back_button.Size = new System.Drawing.Size(325, 96);
            this.back_button.TabIndex = 1;
            this.back_button.Text = "BACK";
            this.back_button.UseVisualStyleBackColor = true;
            this.back_button.Click += new System.EventHandler(this.back_button_Click);
            // 
            // movie_checkbox
            // 
            this.movie_checkbox.AutoSize = true;
            this.movie_checkbox.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.movie_checkbox.Location = new System.Drawing.Point(57, 31);
            this.movie_checkbox.Name = "movie_checkbox";
            this.movie_checkbox.Size = new System.Drawing.Size(335, 58);
            this.movie_checkbox.TabIndex = 2;
            this.movie_checkbox.Text = "Remove Movie";
            this.movie_checkbox.UseVisualStyleBackColor = true;
            this.movie_checkbox.CheckedChanged += new System.EventHandler(this.movie_checkbox_CheckedChanged);
            // 
            // room_checkbox
            // 
            this.room_checkbox.AutoSize = true;
            this.room_checkbox.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.room_checkbox.Location = new System.Drawing.Point(473, 118);
            this.room_checkbox.Name = "room_checkbox";
            this.room_checkbox.Size = new System.Drawing.Size(329, 58);
            this.room_checkbox.TabIndex = 3;
            this.room_checkbox.Text = "Remove Room";
            this.room_checkbox.UseVisualStyleBackColor = true;
            this.room_checkbox.CheckedChanged += new System.EventHandler(this.room_checkbox_CheckedChanged);
            // 
            // actor_checkbox
            // 
            this.actor_checkbox.AutoSize = true;
            this.actor_checkbox.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actor_checkbox.Location = new System.Drawing.Point(57, 118);
            this.actor_checkbox.Name = "actor_checkbox";
            this.actor_checkbox.Size = new System.Drawing.Size(321, 58);
            this.actor_checkbox.TabIndex = 4;
            this.actor_checkbox.Text = "Remove Actor";
            this.actor_checkbox.UseVisualStyleBackColor = true;
            this.actor_checkbox.CheckedChanged += new System.EventHandler(this.actor_checkbox_CheckedChanged);
            // 
            // theater_checkbox
            // 
            this.theater_checkbox.AutoSize = true;
            this.theater_checkbox.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.theater_checkbox.Location = new System.Drawing.Point(473, 31);
            this.theater_checkbox.Name = "theater_checkbox";
            this.theater_checkbox.Size = new System.Drawing.Size(362, 58);
            this.theater_checkbox.TabIndex = 5;
            this.theater_checkbox.Text = "Remove Theater";
            this.theater_checkbox.UseVisualStyleBackColor = true;
            this.theater_checkbox.CheckedChanged += new System.EventHandler(this.theater_checkbox_CheckedChanged);
            // 
            // DeleteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 340);
            this.Controls.Add(this.theater_checkbox);
            this.Controls.Add(this.actor_checkbox);
            this.Controls.Add(this.room_checkbox);
            this.Controls.Add(this.movie_checkbox);
            this.Controls.Add(this.back_button);
            this.Controls.Add(this.delete_button);
            this.Name = "DeleteForm";
            this.Text = "DeleteForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button delete_button;
        private System.Windows.Forms.Button back_button;
        private System.Windows.Forms.CheckBox movie_checkbox;
        private System.Windows.Forms.CheckBox room_checkbox;
        private System.Windows.Forms.CheckBox actor_checkbox;
        private System.Windows.Forms.CheckBox theater_checkbox;
    }
}