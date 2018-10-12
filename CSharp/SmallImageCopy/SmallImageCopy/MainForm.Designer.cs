namespace SmallImageCopy {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnStart = new System.Windows.Forms.Button();
            this.FolderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.ChkOverwrite = new System.Windows.Forms.CheckBox();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.LabelCopiedFiles = new System.Windows.Forms.Label();
            this.ListBoxManual = new System.Windows.Forms.ListBox();
            this.TxtDestPath = new System.Windows.Forms.TextBox();
            this.TxtSourcePath = new System.Windows.Forms.TextBox();
            this.BtnSelectDest = new System.Windows.Forms.Button();
            this.BtnSelectSource = new System.Windows.Forms.Button();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.Label1 = new System.Windows.Forms.Label();
            this.ListBoxAuto = new System.Windows.Forms.ListBox();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.MenuStrip1.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.TabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.AboutToolStripMenuItem1});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "menuStrip1";
            this.MenuStrip1.Size = new System.Drawing.Size(618, 24);
            this.MenuStrip1.TabIndex = 0;
            this.MenuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileToolStripMenuItem.Text = "File";
            // 
            // aboutToolStripMenuItem1
            // 
            this.AboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.AboutToolStripMenuItem1.Size = new System.Drawing.Size(52, 20);
            this.AboutToolStripMenuItem1.Text = "About";
            // 
            // btnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(534, 393);
            this.BtnStart.Name = "btnStart";
            this.BtnStart.Size = new System.Drawing.Size(75, 23);
            this.BtnStart.TabIndex = 2;
            this.BtnStart.Text = "Start";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // chkOverwrite
            // 
            this.ChkOverwrite.AutoSize = true;
            this.ChkOverwrite.Location = new System.Drawing.Point(12, 397);
            this.ChkOverwrite.Name = "chkOverwrite";
            this.ChkOverwrite.Size = new System.Drawing.Size(134, 17);
            this.ChkOverwrite.TabIndex = 5;
            this.ChkOverwrite.Text = "Overwrite Existing Files";
            this.ChkOverwrite.UseMnemonic = false;
            this.ChkOverwrite.UseVisualStyleBackColor = false;
            this.ChkOverwrite.CheckedChanged += new System.EventHandler(this.chkOverwrite_CheckedChanged);
            // 
            // tabPage2
            // 
            this.TabPage2.Controls.Add(this.LabelCopiedFiles);
            this.TabPage2.Controls.Add(this.ListBoxManual);
            this.TabPage2.Controls.Add(this.TxtDestPath);
            this.TabPage2.Controls.Add(this.TxtSourcePath);
            this.TabPage2.Controls.Add(this.BtnSelectDest);
            this.TabPage2.Controls.Add(this.BtnSelectSource);
            this.TabPage2.Location = new System.Drawing.Point(4, 22);
            this.TabPage2.Name = "tabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(610, 334);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Manual Mode";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // labelCopiedFiles
            // 
            this.LabelCopiedFiles.AutoSize = true;
            this.LabelCopiedFiles.Location = new System.Drawing.Point(3, 74);
            this.LabelCopiedFiles.Name = "labelCopiedFiles";
            this.LabelCopiedFiles.Size = new System.Drawing.Size(67, 13);
            this.LabelCopiedFiles.TabIndex = 6;
            this.LabelCopiedFiles.Text = "Files Copied:";
            // 
            // listBoxManual
            // 
            this.ListBoxManual.FormattingEnabled = true;
            this.ListBoxManual.HorizontalScrollbar = true;
            this.ListBoxManual.Location = new System.Drawing.Point(6, 90);
            this.ListBoxManual.Name = "listBoxManual";
            this.ListBoxManual.Size = new System.Drawing.Size(599, 238);
            this.ListBoxManual.TabIndex = 5;
            // 
            // txtDestPath
            // 
            this.TxtDestPath.Location = new System.Drawing.Point(117, 37);
            this.TxtDestPath.Name = "txtDestPath";
            this.TxtDestPath.Size = new System.Drawing.Size(488, 20);
            this.TxtDestPath.TabIndex = 4;
            // 
            // txtSourcePath
            // 
            this.TxtSourcePath.Location = new System.Drawing.Point(117, 8);
            this.TxtSourcePath.Name = "txtSourcePath";
            this.TxtSourcePath.Size = new System.Drawing.Size(488, 20);
            this.TxtSourcePath.TabIndex = 2;
            // 
            // btnSelectDest
            // 
            this.BtnSelectDest.Location = new System.Drawing.Point(6, 35);
            this.BtnSelectDest.Name = "btnSelectDest";
            this.BtnSelectDest.Size = new System.Drawing.Size(103, 23);
            this.BtnSelectDest.TabIndex = 3;
            this.BtnSelectDest.Text = "Select Destination";
            this.BtnSelectDest.UseVisualStyleBackColor = true;
            this.BtnSelectDest.Click += new System.EventHandler(this.btnSelectDest_Click);
            // 
            // btnSelectSource
            // 
            this.BtnSelectSource.Location = new System.Drawing.Point(6, 6);
            this.BtnSelectSource.Name = "btnSelectSource";
            this.BtnSelectSource.Size = new System.Drawing.Size(103, 23);
            this.BtnSelectSource.TabIndex = 0;
            this.BtnSelectSource.Text = "Select Source";
            this.BtnSelectSource.UseVisualStyleBackColor = true;
            this.BtnSelectSource.Click += new System.EventHandler(this.BtnSelectSource_Click);
            // 
            // tabPage1
            // 
            this.TabPage1.Controls.Add(this.Label1);
            this.TabPage1.Controls.Add(this.ListBoxAuto);
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Name = "tabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(610, 334);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Auto Mode";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(3, 9);
            this.Label1.Name = "label1";
            this.Label1.Size = new System.Drawing.Size(67, 13);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Files Copied:";
            // 
            // listBoxAuto
            // 
            this.ListBoxAuto.FormattingEnabled = true;
            this.ListBoxAuto.Location = new System.Drawing.Point(6, 25);
            this.ListBoxAuto.Name = "listBoxAuto";
            this.ListBoxAuto.Size = new System.Drawing.Size(599, 303);
            this.ListBoxAuto.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Controls.Add(this.TabPage2);
            this.TabControl1.Location = new System.Drawing.Point(0, 27);
            this.TabControl1.Name = "tabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(618, 360);
            this.TabControl1.TabIndex = 1;
            this.TabControl1.SelectedIndexChanged += new System.EventHandler(this.resetDirPathsOnTabChange);
            // 
            // btnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(453, 393);
            this.BtnCancel.Name = "btnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 3;
            this.BtnCancel.Text = "Close";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 424);
            this.Controls.Add(this.ChkOverwrite);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.TabControl1);
            this.Controls.Add(this.MenuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.MenuStrip1;
            this.Name = "MainForm";
            this.Text = "Small Image Copy";
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.TabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem1;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog1;
        private System.Windows.Forms.CheckBox ChkOverwrite;
        private System.Windows.Forms.TabPage TabPage2;
        private System.Windows.Forms.ListBox ListBoxManual;
        private System.Windows.Forms.TextBox TxtDestPath;
        private System.Windows.Forms.TextBox TxtSourcePath;
        private System.Windows.Forms.Button BtnSelectDest;
        private System.Windows.Forms.Button BtnSelectSource;
        private System.Windows.Forms.TabPage TabPage1;
        private System.Windows.Forms.ListBox ListBoxAuto;
        private System.Windows.Forms.TabControl TabControl1;
        private System.Windows.Forms.Label LabelCopiedFiles;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Button BtnCancel;
    }
}

