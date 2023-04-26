namespace _560FinalProject.Forms.Other_Forms.Add_Forms
{
    partial class AddTheaterForm
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
            this.theaterName_textbox = new System.Windows.Forms.TextBox();
            this.theaterAddress_textbox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.back_button = new System.Windows.Forms.Button();
            this.add_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // theaterName_textbox
            // 
            this.theaterName_textbox.Location = new System.Drawing.Point(151, 84);
            this.theaterName_textbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.theaterName_textbox.Name = "theaterName_textbox";
            this.theaterName_textbox.Size = new System.Drawing.Size(447, 38);
            this.theaterName_textbox.TabIndex = 21;
            // 
            // theaterAddress_textbox
            // 
            this.theaterAddress_textbox.Location = new System.Drawing.Point(183, 148);
            this.theaterAddress_textbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.theaterAddress_textbox.Name = "theaterAddress_textbox";
            this.theaterAddress_textbox.Size = new System.Drawing.Size(415, 38);
            this.theaterAddress_textbox.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(50, 151);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(126, 32);
            this.label10.TabIndex = 19;
            this.label10.Text = "Address:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(47, 89);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 32);
            this.label9.TabIndex = 18;
            this.label9.Text = "Name:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Symbol", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(26, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(257, 46);
            this.label8.TabIndex = 17;
            this.label8.Text = "Theater Search";
            // 
            // back_button
            // 
            this.back_button.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold);
            this.back_button.Location = new System.Drawing.Point(356, 224);
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
            this.add_button.Location = new System.Drawing.Point(56, 224);
            this.add_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.add_button.Name = "add_button";
            this.add_button.Size = new System.Drawing.Size(245, 67);
            this.add_button.TabIndex = 117;
            this.add_button.Text = "ADD";
            this.add_button.UseVisualStyleBackColor = true;
            this.add_button.Click += new System.EventHandler(this.add_button_Click);
            // 
            // AddTheaterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 333);
            this.Controls.Add(this.back_button);
            this.Controls.Add(this.add_button);
            this.Controls.Add(this.theaterName_textbox);
            this.Controls.Add(this.theaterAddress_textbox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Name = "AddTheaterForm";
            this.Text = "AddTheaterForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox theaterName_textbox;
        private System.Windows.Forms.TextBox theaterAddress_textbox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button back_button;
        private System.Windows.Forms.Button add_button;
    }
}