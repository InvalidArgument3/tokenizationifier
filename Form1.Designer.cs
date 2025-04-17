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
            textBox1 = new TextBox();
            label1 = new Label();
            resetButton = new Button();
            addFilesButton = new Button();
            minifyButton = new Button();
            openOutputButton = new Button();
            changeDirButton = new Button();
            clipboardButton = new Button();
            GithubLabel = new LinkLabel();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(14, 46);
            textBox1.Margin = new Padding(4, 3, 4, 3);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(536, 288);
            textBox1.TabIndex = 5;
            // 
            // label1
            // 
            label1.Location = new Point(14, 12);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(537, 23);
            label1.TabIndex = 6;
            label1.Text = "Add files, minify, open output, or change output directory.";
            // 
            // resetButton
            // 
            resetButton.Location = new Point(14, 346);
            resetButton.Margin = new Padding(4, 3, 4, 3);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(93, 27);
            resetButton.TabIndex = 4;
            resetButton.Text = "Reset";
            resetButton.Click += ResetButton_Click;
            // 
            // addFilesButton
            // 
            addFilesButton.Location = new Point(114, 346);
            addFilesButton.Margin = new Padding(4, 3, 4, 3);
            addFilesButton.Name = "addFilesButton";
            addFilesButton.Size = new Size(93, 27);
            addFilesButton.TabIndex = 3;
            addFilesButton.Text = "Add Files";
            addFilesButton.Click += AddFilesButton_Click;
            // 
            // minifyButton
            // 
            minifyButton.Location = new Point(215, 346);
            minifyButton.Margin = new Padding(4, 3, 4, 3);
            minifyButton.Name = "minifyButton";
            minifyButton.Size = new Size(93, 27);
            minifyButton.TabIndex = 2;
            minifyButton.Text = "Minify";
            minifyButton.Click += MinifyButton_Click;
            // 
            // openOutputButton
            // 
            openOutputButton.Location = new Point(316, 379);
            openOutputButton.Margin = new Padding(4, 3, 4, 3);
            openOutputButton.Name = "openOutputButton";
            openOutputButton.Size = new Size(93, 27);
            openOutputButton.TabIndex = 1;
            openOutputButton.Text = "Open Output";
            openOutputButton.Click += OpenOutputButton_Click;
            // 
            // changeDirButton
            // 
            changeDirButton.Location = new Point(14, 379);
            changeDirButton.Margin = new Padding(4, 3, 4, 3);
            changeDirButton.Name = "changeDirButton";
            changeDirButton.Size = new Size(93, 27);
            changeDirButton.TabIndex = 0;
            changeDirButton.Text = "Change Dir";
            changeDirButton.Click += ChangeDirButton_Click;
            // 
            // clipboardButton
            // 
            clipboardButton.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            clipboardButton.Location = new Point(316, 346);
            clipboardButton.Margin = new Padding(4, 3, 4, 3);
            clipboardButton.Name = "clipboardButton";
            clipboardButton.Size = new Size(93, 27);
            clipboardButton.TabIndex = 7;
            clipboardButton.Text = "Copy Output";
            clipboardButton.Click += clipboardButton_Click;
            // 
            // GithubLabel
            // 
            GithubLabel.AutoSize = true;
            GithubLabel.Location = new Point(507, 12);
            GithubLabel.Name = "GithubLabel";
            GithubLabel.Size = new Size(43, 15);
            GithubLabel.TabIndex = 8;
            GithubLabel.TabStop = true;
            GithubLabel.Text = "Github";
            GithubLabel.LinkClicked += GithubLabel_LinkClicked;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(565, 417);
            Controls.Add(GithubLabel);
            Controls.Add(clipboardButton);
            Controls.Add(changeDirButton);
            Controls.Add(openOutputButton);
            Controls.Add(minifyButton);
            Controls.Add(addFilesButton);
            Controls.Add(resetButton);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Tokenizationifier";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button addFilesButton;
        private System.Windows.Forms.Button minifyButton;
        private System.Windows.Forms.Button openOutputButton;
        private System.Windows.Forms.Button changeDirButton;
        private Button clipboardButton;
        private LinkLabel GithubLabel;
    }
}