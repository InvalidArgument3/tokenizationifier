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
            mainTableLayoutPanel = new TableLayoutPanel();
            headerPanel = new Panel();
            label1 = new Label();
            GithubLabel = new LinkLabel();
            textBox1 = new TextBox();
            buttonTableLayoutPanel = new TableLayoutPanel();
            resetButton = new Button();
            addFilesButton = new Button();
            minifyButton = new Button();
            clipboardButton = new Button();
            modeComboBox = new ComboBox();
            changeDirButton = new Button();
            openOutputButton = new Button();
            tokenCountButton = new Button();
            mainTableLayoutPanel.SuspendLayout();
            headerPanel.SuspendLayout();
            buttonTableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainTableLayoutPanel
            // 
            mainTableLayoutPanel.ColumnCount = 1;
            mainTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainTableLayoutPanel.Controls.Add(headerPanel, 0, 0);
            mainTableLayoutPanel.Controls.Add(textBox1, 0, 1);
            mainTableLayoutPanel.Controls.Add(buttonTableLayoutPanel, 0, 2);
            mainTableLayoutPanel.Dock = DockStyle.Fill;
            mainTableLayoutPanel.Location = new Point(0, 0);
            mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            mainTableLayoutPanel.RowCount = 3;
            mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            mainTableLayoutPanel.Size = new Size(565, 417);
            mainTableLayoutPanel.TabIndex = 0;
            // 
            // headerPanel
            // 
            headerPanel.Controls.Add(label1);
            headerPanel.Controls.Add(GithubLabel);
            headerPanel.Dock = DockStyle.Fill;
            headerPanel.Location = new Point(3, 3);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(559, 24);
            headerPanel.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(500, 23);
            label1.TabIndex = 0;
            label1.Text = "Select mode, add files, minify, count tokens, or change output directory.";
            // 
            // GithubLabel
            // 
            GithubLabel.Anchor = AnchorStyles.Right;
            GithubLabel.AutoSize = true;
            GithubLabel.Location = new Point(500, 5);
            GithubLabel.Name = "GithubLabel";
            GithubLabel.Size = new Size(43, 15);
            GithubLabel.TabIndex = 1;
            GithubLabel.TabStop = true;
            GithubLabel.Text = "Github";
            GithubLabel.LinkClicked += GithubLabel_LinkClicked;
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(3, 33);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(559, 311);
            textBox1.TabIndex = 1;
            // 
            // buttonTableLayoutPanel
            // 
            buttonTableLayoutPanel.ColumnCount = 5;
            buttonTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            buttonTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            buttonTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            buttonTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            buttonTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            buttonTableLayoutPanel.Controls.Add(resetButton, 0, 0);
            buttonTableLayoutPanel.Controls.Add(addFilesButton, 1, 0);
            buttonTableLayoutPanel.Controls.Add(minifyButton, 2, 0);
            buttonTableLayoutPanel.Controls.Add(clipboardButton, 3, 0);
            buttonTableLayoutPanel.Controls.Add(modeComboBox, 4, 0);
            buttonTableLayoutPanel.Controls.Add(changeDirButton, 0, 1);
            buttonTableLayoutPanel.Controls.Add(openOutputButton, 3, 1);
            buttonTableLayoutPanel.Controls.Add(tokenCountButton, 4, 1);
            buttonTableLayoutPanel.Dock = DockStyle.Fill;
            buttonTableLayoutPanel.Location = new Point(3, 350);
            buttonTableLayoutPanel.Name = "buttonTableLayoutPanel";
            buttonTableLayoutPanel.RowCount = 2;
            buttonTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            buttonTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            buttonTableLayoutPanel.Size = new Size(559, 64);
            buttonTableLayoutPanel.TabIndex = 2;
            // 
            // resetButton
            // 
            resetButton.Dock = DockStyle.Fill;
            resetButton.Location = new Point(3, 3);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(105, 26);
            resetButton.TabIndex = 0;
            resetButton.Text = "Reset";
            resetButton.Click += ResetButton_Click;
            // 
            // addFilesButton
            // 
            addFilesButton.Dock = DockStyle.Fill;
            addFilesButton.Location = new Point(114, 3);
            addFilesButton.Name = "addFilesButton";
            addFilesButton.Size = new Size(105, 26);
            addFilesButton.TabIndex = 1;
            addFilesButton.Text = "Add Files";
            addFilesButton.Click += AddFilesButton_Click;
            // 
            // minifyButton
            // 
            minifyButton.Dock = DockStyle.Fill;
            minifyButton.Location = new Point(225, 3);
            minifyButton.Name = "minifyButton";
            minifyButton.Size = new Size(105, 26);
            minifyButton.TabIndex = 2;
            minifyButton.Text = "Minify";
            minifyButton.Click += MinifyButton_Click;
            // 
            // clipboardButton
            // 
            clipboardButton.Dock = DockStyle.Fill;
            clipboardButton.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            clipboardButton.Location = new Point(336, 3);
            clipboardButton.Name = "clipboardButton";
            clipboardButton.Size = new Size(105, 26);
            clipboardButton.TabIndex = 3;
            clipboardButton.Text = "Copy Output";
            clipboardButton.Click += clipboardButton_Click;
            // 
            // modeComboBox
            // 
            modeComboBox.Dock = DockStyle.Fill;
            modeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            modeComboBox.Location = new Point(447, 3);
            modeComboBox.Name = "modeComboBox";
            modeComboBox.Size = new Size(109, 23);
            modeComboBox.TabIndex = 4;
            // 
            // changeDirButton
            // 
            changeDirButton.Dock = DockStyle.Fill;
            changeDirButton.Location = new Point(3, 35);
            changeDirButton.Name = "changeDirButton";
            changeDirButton.Size = new Size(105, 26);
            changeDirButton.TabIndex = 5;
            changeDirButton.Text = "Change Dir";
            changeDirButton.Click += ChangeDirButton_Click;
            // 
            // openOutputButton
            // 
            openOutputButton.Dock = DockStyle.Fill;
            openOutputButton.Location = new Point(336, 35);
            openOutputButton.Name = "openOutputButton";
            openOutputButton.Size = new Size(105, 26);
            openOutputButton.TabIndex = 6;
            openOutputButton.Text = "Open Output";
            openOutputButton.Click += OpenOutputButton_Click;
            // 
            // tokenCountButton
            // 
            tokenCountButton.Dock = DockStyle.Fill;
            tokenCountButton.Location = new Point(447, 35);
            tokenCountButton.Name = "tokenCountButton";
            tokenCountButton.Size = new Size(109, 26);
            tokenCountButton.TabIndex = 7;
            tokenCountButton.Text = "Count Tokens";
            tokenCountButton.Click += tokenCountButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(565, 417);
            Controls.Add(mainTableLayoutPanel);
            Name = "Form1";
            Text = "Tokenizationifier";
            mainTableLayoutPanel.ResumeLayout(false);
            mainTableLayoutPanel.PerformLayout();
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            buttonTableLayoutPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        private TableLayoutPanel mainTableLayoutPanel;
        private Panel headerPanel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button addFilesButton;
        private System.Windows.Forms.Button minifyButton;
        private System.Windows.Forms.Button openOutputButton;
        private System.Windows.Forms.Button changeDirButton;
        private Button clipboardButton;
        private LinkLabel GithubLabel;
        private ComboBox modeComboBox;
        private Button tokenCountButton;
        private TableLayoutPanel buttonTableLayoutPanel;
    }
}