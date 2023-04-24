namespace _560FinalProject
{
    partial class Database_OutputForm
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
            this.back_button = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // back_button
            // 
            this.back_button.Font = new System.Drawing.Font("Segoe UI Symbol", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back_button.Location = new System.Drawing.Point(159, 511);
            this.back_button.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.back_button.Name = "back_button";
            this.back_button.Size = new System.Drawing.Size(212, 52);
            this.back_button.TabIndex = 18;
            this.back_button.Text = "GO BACK";
            this.back_button.UseVisualStyleBackColor = true;
            this.back_button.Click += new System.EventHandler(this.back_button_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(244, 569);
            this.label26.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(31, 13);
            this.label26.TabIndex = 46;
            this.label26.Text = "        ";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(13, 13);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(510, 498);
            this.listBox1.TabIndex = 47;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // Database_OutputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(535, 601);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.back_button);
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Name = "Database_OutputForm";
            this.Text = "OutputForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button back_button;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ListBox listBox1;
    }
}