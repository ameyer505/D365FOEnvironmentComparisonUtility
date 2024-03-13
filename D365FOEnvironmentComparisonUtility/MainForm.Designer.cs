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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_srcFile = new System.Windows.Forms.TextBox();
            this.tb_destFile = new System.Windows.Forms.TextBox();
            this.tb_outputFolder = new System.Windows.Forms.TextBox();
            this.btn_srcBrowse = new System.Windows.Forms.Button();
            this.brn_destBrowse = new System.Windows.Forms.Button();
            this.btn_outputFolderBrowse = new System.Windows.Forms.Button();
            this.btn_generate = new System.Windows.Forms.Button();
            this.ofd_src = new System.Windows.Forms.OpenFileDialog();
            this.ofd_dest = new System.Windows.Forms.OpenFileDialog();
            this.fbd_output = new System.Windows.Forms.FolderBrowserDialog();
            this.tb_output = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(30, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source File :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Destination File :";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(658, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.exitToolStripMenuItem.Text = "About";
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(12, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Output Folder :";
            // 
            // tb_srcFile
            // 
            this.tb_srcFile.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tb_srcFile.Location = new System.Drawing.Point(121, 32);
            this.tb_srcFile.Name = "tb_srcFile";
            this.tb_srcFile.Size = new System.Drawing.Size(434, 25);
            this.tb_srcFile.TabIndex = 5;
            this.tb_srcFile.TextChanged += new System.EventHandler(this.tbSrcFile_TextChanged);
            // 
            // tb_destFile
            // 
            this.tb_destFile.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tb_destFile.Location = new System.Drawing.Point(121, 83);
            this.tb_destFile.Name = "tb_destFile";
            this.tb_destFile.Size = new System.Drawing.Size(434, 25);
            this.tb_destFile.TabIndex = 6;
            this.tb_destFile.TextChanged += new System.EventHandler(this.tbDestFile_TextChanged);
            // 
            // tb_outputFolder
            // 
            this.tb_outputFolder.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tb_outputFolder.Location = new System.Drawing.Point(121, 130);
            this.tb_outputFolder.Name = "tb_outputFolder";
            this.tb_outputFolder.Size = new System.Drawing.Size(434, 25);
            this.tb_outputFolder.TabIndex = 7;
            this.tb_outputFolder.TextChanged += new System.EventHandler(this.tbOutputFile_TextChanged);
            // 
            // btn_srcBrowse
            // 
            this.btn_srcBrowse.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_srcBrowse.Location = new System.Drawing.Point(561, 34);
            this.btn_srcBrowse.Name = "btn_srcBrowse";
            this.btn_srcBrowse.Size = new System.Drawing.Size(75, 23);
            this.btn_srcBrowse.TabIndex = 8;
            this.btn_srcBrowse.Text = "Browse";
            this.btn_srcBrowse.UseVisualStyleBackColor = true;
            this.btn_srcBrowse.Click += new System.EventHandler(this.btnSrcBrowse_Click);
            // 
            // brn_destBrowse
            // 
            this.brn_destBrowse.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.brn_destBrowse.Location = new System.Drawing.Point(561, 85);
            this.brn_destBrowse.Name = "brn_destBrowse";
            this.brn_destBrowse.Size = new System.Drawing.Size(75, 23);
            this.brn_destBrowse.TabIndex = 9;
            this.brn_destBrowse.Text = "Browse";
            this.brn_destBrowse.UseVisualStyleBackColor = true;
            this.brn_destBrowse.Click += new System.EventHandler(this.btnDestBrowse_Click);
            // 
            // btn_outputFolderBrowse
            // 
            this.btn_outputFolderBrowse.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_outputFolderBrowse.Location = new System.Drawing.Point(561, 130);
            this.btn_outputFolderBrowse.Name = "btn_outputFolderBrowse";
            this.btn_outputFolderBrowse.Size = new System.Drawing.Size(75, 23);
            this.btn_outputFolderBrowse.TabIndex = 10;
            this.btn_outputFolderBrowse.Text = "Browse";
            this.btn_outputFolderBrowse.UseVisualStyleBackColor = true;
            this.btn_outputFolderBrowse.Click += new System.EventHandler(this.btnOutputBrowse_Click);
            // 
            // btn_generate
            // 
            this.btn_generate.Enabled = false;
            this.btn_generate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_generate.Location = new System.Drawing.Point(470, 178);
            this.btn_generate.Name = "btn_generate";
            this.btn_generate.Size = new System.Drawing.Size(166, 28);
            this.btn_generate.TabIndex = 11;
            this.btn_generate.Text = "Generate Comparison";
            this.btn_generate.UseVisualStyleBackColor = true;
            this.btn_generate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // ofd_src
            // 
            this.ofd_src.FileName = "openFileDialog1";
            // 
            // ofd_dest
            // 
            this.ofd_dest.FileName = "openFileDialog1";
            // 
            // tb_output
            // 
            this.tb_output.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tb_output.Location = new System.Drawing.Point(12, 235);
            this.tb_output.Multiline = true;
            this.tb_output.Name = "tb_output";
            this.tb_output.ReadOnly = true;
            this.tb_output.Size = new System.Drawing.Size(624, 235);
            this.tb_output.TabIndex = 12;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 493);
            this.Controls.Add(this.tb_output);
            this.Controls.Add(this.btn_generate);
            this.Controls.Add(this.btn_outputFolderBrowse);
            this.Controls.Add(this.brn_destBrowse);
            this.Controls.Add(this.btn_srcBrowse);
            this.Controls.Add(this.tb_outputFolder);
            this.Controls.Add(this.tb_destFile);
            this.Controls.Add(this.tb_srcFile);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "D365FO Environment Comparison Utility v1.0";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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