namespace _560FinalProject.Forms.Other_Forms
{
    partial class AddForm
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
            this.room_button = new System.Windows.Forms.Button();
            this.movie_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.actor_button = new System.Windows.Forms.Button();
            this.theater_button = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.back_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // room_button
            // 
            this.room_button.Font = new System.Drawing.Font("Segoe UI Symbol", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.room_button.Location = new System.Drawing.Point(677, 184);
            this.room_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.room_button.Name = "room_button";
            this.room_button.Size = new System.Drawing.Size(565, 124);
            this.room_button.TabIndex = 138;
            this.room_button.Text = "ROOM";
            this.room_button.UseVisualStyleBackColor = true;
            this.room_button.Click += new System.EventHandler(this.room_button_Click);
            // 
            // movie_button
            // 
            this.movie_button.Font = new System.Drawing.Font("Segoe UI Symbol", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.movie_button.Location = new System.Drawing.Point(35, 34);
            this.movie_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.movie_button.Name = "movie_button";
            this.movie_button.Size = new System.Drawing.Size(565, 124);
            this.movie_button.TabIndex = 137;
            this.movie_button.Text = "MOVIE";
            this.movie_button.UseVisualStyleBackColor = true;
            this.movie_button.Click += new System.EventHandler(this.movie_button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(949, 421);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 32);
            this.label2.TabIndex = 136;
            this.label2.Text = "        ";
            // 
            // actor_button
            // 
            this.actor_button.Font = new System.Drawing.Font("Segoe UI Symbol", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actor_button.Location = new System.Drawing.Point(35, 184);
            this.actor_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.actor_button.Name = "actor_button";
            this.actor_button.Size = new System.Drawing.Size(565, 124);
            this.actor_button.TabIndex = 135;
            this.actor_button.Text = "ACTOR";
            this.actor_button.UseVisualStyleBackColor = true;
            this.actor_button.Click += new System.EventHandler(this.actor_button_Click);
            // 
            // theater_button
            // 
            this.theater_button.Font = new System.Drawing.Font("Segoe UI Symbol", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.theater_button.Location = new System.Drawing.Point(677, 34);
            this.theater_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.theater_button.Name = "theater_button";
            this.theater_button.Size = new System.Drawing.Size(565, 124);
            this.theater_button.TabIndex = 134;
            this.theater_button.Text = "THEATER";
            this.theater_button.UseVisualStyleBackColor = true;
            this.theater_button.Click += new System.EventHandler(this.theater_button_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(632, 179);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(0, 32);
            this.label25.TabIndex = 133;
            // 
            // back_button
            // 
            this.back_button.Font = new System.Drawing.Font("Segoe UI Symbol", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back_button.Location = new System.Drawing.Point(360, 329);
            this.back_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.back_button.Name = "back_button";
            this.back_button.Size = new System.Drawing.Size(565, 124);
            this.back_button.TabIndex = 132;
            this.back_button.Text = "GO BACK";
            this.back_button.UseVisualStyleBackColor = true;
            this.back_button.Click += new System.EventHandler(this.back_button_Click);
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 489);
            this.Controls.Add(this.room_button);
            this.Controls.Add(this.movie_button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.actor_button);
            this.Controls.Add(this.theater_button);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.back_button);
            this.Name = "AddForm";
            this.Text = "AddForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button room_button;
        private System.Windows.Forms.Button movie_button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button actor_button;
        private System.Windows.Forms.Button theater_button;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button back_button;
    }
}