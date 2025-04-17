namespace tokenizationifier
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.resetButton = new System.Windows.Forms.Button();
            this.addFilesButton = new System.Windows.Forms.Button();
            this.minifyButton = new System.Windows.Forms.Button();
            this.openOutputButton = new System.Windows.Forms.Button();
            this.changeDirButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 40);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(460, 250);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(460, 20);
            this.label1.Text = "Add files, minify, open output, or change output directory.";
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(12, 300);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(80, 23);
            this.resetButton.Text = "Reset";
            this.resetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // addFilesButton
            // 
            this.addFilesButton.Location = new System.Drawing.Point(98, 300);
            this.addFilesButton.Name = "addFilesButton";
            this.addFilesButton.Size = new System.Drawing.Size(80, 23);
            this.addFilesButton.Text = "Add Files";
            this.addFilesButton.Click += new System.EventHandler(this.AddFilesButton_Click);
            // 
            // minifyButton
            // 
            this.minifyButton.Location = new System.Drawing.Point(184, 300);
            this.minifyButton.Name = "minifyButton";
            this.minifyButton.Size = new System.Drawing.Size(80, 23);
            this.minifyButton.Text = "Minify";
            this.minifyButton.Click += new System.EventHandler(this.MinifyButton_Click);
            // 
            // openOutputButton
            // 
            this.openOutputButton.Location = new System.Drawing.Point(270, 300);
            this.openOutputButton.Name = "openOutputButton";
            this.openOutputButton.Size = new System.Drawing.Size(80, 23);
            this.openOutputButton.Text = "Open Output";
            this.openOutputButton.Click += new System.EventHandler(this.OpenOutputButton_Click);
            // 
            // changeDirButton
            // 
            this.changeDirButton.Location = new System.Drawing.Point(356, 300);
            this.changeDirButton.Name = "changeDirButton";
            this.changeDirButton.Size = new System.Drawing.Size(80, 23);
            this.changeDirButton.Text = "Change Dir";
            this.changeDirButton.Click += new System.EventHandler(this.ChangeDirButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.changeDirButton);
            this.Controls.Add(this.openOutputButton);
            this.Controls.Add(this.minifyButton);
            this.Controls.Add(this.addFilesButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Tokenizationifier";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button addFilesButton;
        private System.Windows.Forms.Button minifyButton;
        private System.Windows.Forms.Button openOutputButton;
        private System.Windows.Forms.Button changeDirButton;
    }
}