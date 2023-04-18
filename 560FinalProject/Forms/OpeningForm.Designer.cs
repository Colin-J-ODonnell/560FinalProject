namespace _560FinalProject
{
    partial class OpeningForm
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
            this.database_button = new System.Windows.Forms.Button();
            this.schedule_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.edit_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // database_button
            // 
            this.database_button.Font = new System.Drawing.Font("Segoe UI Symbol", 14.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.database_button.Location = new System.Drawing.Point(111, 231);
            this.database_button.Name = "database_button";
            this.database_button.Size = new System.Drawing.Size(371, 181);
            this.database_button.TabIndex = 0;
            this.database_button.Text = "Movie Database";
            this.database_button.UseVisualStyleBackColor = true;
            this.database_button.Click += new System.EventHandler(this.database_button_Click);
            // 
            // schedule_button
            // 
            this.schedule_button.Font = new System.Drawing.Font("Segoe UI Symbol", 14.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.schedule_button.Location = new System.Drawing.Point(553, 231);
            this.schedule_button.Name = "schedule_button";
            this.schedule_button.Size = new System.Drawing.Size(371, 181);
            this.schedule_button.TabIndex = 1;
            this.schedule_button.Text = "Scheduled Screenings";
            this.schedule_button.UseVisualStyleBackColor = true;
            this.schedule_button.Click += new System.EventHandler(this.schedule_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Symbol", 14.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(308, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(422, 62);
            this.label1.TabIndex = 2;
            this.label1.Text = "Movie Application";
            // 
            // edit_button
            // 
            this.edit_button.Font = new System.Drawing.Font("Segoe UI Symbol", 14.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edit_button.Location = new System.Drawing.Point(330, 427);
            this.edit_button.Name = "edit_button";
            this.edit_button.Size = new System.Drawing.Size(371, 181);
            this.edit_button.TabIndex = 3;
            this.edit_button.Text = "Edit Database";
            this.edit_button.UseVisualStyleBackColor = true;
            this.edit_button.Click += new System.EventHandler(this.edit_button_Click);
            // 
            // OpeningForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 653);
            this.Controls.Add(this.edit_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.schedule_button);
            this.Controls.Add(this.database_button);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "OpeningForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button database_button;
        private System.Windows.Forms.Button schedule_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button edit_button;
    }
}

