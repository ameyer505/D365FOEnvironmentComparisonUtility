namespace D365FOEnvironmentComparisonUtility
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem1 = new ToolStripMenuItem();
            label4 = new Label();
            tb_srcFile = new TextBox();
            tb_destFile = new TextBox();
            tb_outputFolder = new TextBox();
            btn_srcBrowse = new Button();
            brn_destBrowse = new Button();
            btn_outputFolderBrowse = new Button();
            btn_generate = new Button();
            ofd_src = new OpenFileDialog();
            ofd_dest = new OpenFileDialog();
            fbd_output = new FolderBrowserDialog();
            tb_output = new TextBox();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(30, 35);
            label1.Name = "label1";
            label1.Size = new Size(78, 17);
            label1.TabIndex = 0;
            label1.Text = "Source File :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 83);
            label2.Name = "label2";
            label2.Size = new Size(103, 17);
            label2.TabIndex = 1;
            label2.Text = "Destination File :";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(658, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem, exitToolStripMenuItem1 });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(107, 22);
            exitToolStripMenuItem.Text = "About";
            // 
            // exitToolStripMenuItem1
            // 
            exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            exitToolStripMenuItem1.Size = new Size(107, 22);
            exitToolStripMenuItem1.Text = "Exit";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(12, 130);
            label4.Name = "label4";
            label4.Size = new Size(96, 17);
            label4.TabIndex = 4;
            label4.Text = "Output Folder :";
            // 
            // tb_srcFile
            // 
            tb_srcFile.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            tb_srcFile.Location = new Point(121, 32);
            tb_srcFile.Name = "tb_srcFile";
            tb_srcFile.Size = new Size(434, 25);
            tb_srcFile.TabIndex = 5;
            tb_srcFile.TextChanged += tbSrcFile_TextChanged;
            // 
            // tb_destFile
            // 
            tb_destFile.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            tb_destFile.Location = new Point(121, 83);
            tb_destFile.Name = "tb_destFile";
            tb_destFile.Size = new Size(434, 25);
            tb_destFile.TabIndex = 6;
            tb_destFile.TextChanged += tbDestFile_TextChanged;
            // 
            // tb_outputFolder
            // 
            tb_outputFolder.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            tb_outputFolder.Location = new Point(121, 130);
            tb_outputFolder.Name = "tb_outputFolder";
            tb_outputFolder.Size = new Size(434, 25);
            tb_outputFolder.TabIndex = 7;
            tb_outputFolder.TextChanged += tbOutputFile_TextChanged;
            // 
            // btn_srcBrowse
            // 
            btn_srcBrowse.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btn_srcBrowse.Location = new Point(561, 34);
            btn_srcBrowse.Name = "btn_srcBrowse";
            btn_srcBrowse.Size = new Size(75, 23);
            btn_srcBrowse.TabIndex = 8;
            btn_srcBrowse.Text = "Browse";
            btn_srcBrowse.UseVisualStyleBackColor = true;
            btn_srcBrowse.Click += btnSrcBrowse_Click;
            // 
            // brn_destBrowse
            // 
            brn_destBrowse.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            brn_destBrowse.Location = new Point(561, 85);
            brn_destBrowse.Name = "brn_destBrowse";
            brn_destBrowse.Size = new Size(75, 23);
            brn_destBrowse.TabIndex = 9;
            brn_destBrowse.Text = "Browse";
            brn_destBrowse.UseVisualStyleBackColor = true;
            brn_destBrowse.Click += btnDestBrowse_Click;
            // 
            // btn_outputFolderBrowse
            // 
            btn_outputFolderBrowse.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btn_outputFolderBrowse.Location = new Point(561, 130);
            btn_outputFolderBrowse.Name = "btn_outputFolderBrowse";
            btn_outputFolderBrowse.Size = new Size(75, 23);
            btn_outputFolderBrowse.TabIndex = 10;
            btn_outputFolderBrowse.Text = "Browse";
            btn_outputFolderBrowse.UseVisualStyleBackColor = true;
            btn_outputFolderBrowse.Click += btnOutputBrowse_Click;
            // 
            // btn_generate
            // 
            btn_generate.Enabled = false;
            btn_generate.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btn_generate.Location = new Point(470, 178);
            btn_generate.Name = "btn_generate";
            btn_generate.Size = new Size(166, 28);
            btn_generate.TabIndex = 11;
            btn_generate.Text = "Generate Comparison";
            btn_generate.UseVisualStyleBackColor = true;
            btn_generate.Click += btnGenerate_Click;
            // 
            // ofd_src
            // 
            ofd_src.FileName = "openFileDialog1";
            // 
            // ofd_dest
            // 
            ofd_dest.FileName = "openFileDialog1";
            // 
            // tb_output
            // 
            tb_output.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            tb_output.Location = new Point(12, 235);
            tb_output.Multiline = true;
            tb_output.Name = "tb_output";
            tb_output.ReadOnly = true;
            tb_output.Size = new Size(624, 235);
            tb_output.TabIndex = 12;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(658, 493);
            Controls.Add(tb_output);
            Controls.Add(btn_generate);
            Controls.Add(btn_outputFolderBrowse);
            Controls.Add(brn_destBrowse);
            Controls.Add(btn_srcBrowse);
            Controls.Add(tb_outputFolder);
            Controls.Add(tb_destFile);
            Controls.Add(tb_srcFile);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "D365FO Environment Comparison Utility v1.1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem1;
        private Label label4;
        private TextBox tb_srcFile;
        private TextBox tb_destFile;
        private TextBox tb_outputFolder;
        private Button btn_srcBrowse;
        private Button brn_destBrowse;
        private Button btn_outputFolderBrowse;
        private Button btn_generate;
        private OpenFileDialog ofd_src;
        private OpenFileDialog ofd_dest;
        private FolderBrowserDialog fbd_output;
        private TextBox tb_output;
    }
}