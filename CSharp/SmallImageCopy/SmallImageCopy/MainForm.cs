using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.AccessControl;

namespace SmallImageCopy {
    public partial class MainForm : Form {
        private String sourceDir;
        private String destDir;
        private FileHandler fileHandler;

        public MainForm() {
            InitializeComponent();
            fileHandler = new FileHandler(this);
        }

        private void BtnSelectSource_Click(object sender, EventArgs e) {
            if (FolderBrowserDialog1.ShowDialog() == DialogResult.OK) {
                TxtSourcePath.Text = FolderBrowserDialog1.SelectedPath;
                sourceDir = FolderBrowserDialog1.SelectedPath;
            }
        }

        private void btnSelectDest_Click(object sender, EventArgs e) {
            if (FolderBrowserDialog1.ShowDialog() == DialogResult.OK) {
                TxtDestPath.Text = FolderBrowserDialog1.SelectedPath;
                destDir = FolderBrowserDialog1.SelectedPath;
            }
        }

        private void btnStart_Click(object sender, EventArgs e) {
            if (TabControl1.SelectedTab == TabControl1.TabPages[0]) {
                sourceDir = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\PictureBackup");
                destDir = Environment.CurrentDirectory + "\\PictureBackup";
                fileHandler.SetDirs(sourceDir, destDir);
                fileHandler.CopyFiles(fileHandler.FilesToList(), "auto");
            }
            if (TabControl1.SelectedTab == TabControl1.TabPages[1]) {
                fileHandler.SetDirs(sourceDir, destDir);
                fileHandler.CopyFiles(fileHandler.FilesToList(), "manual");
            }

        }

        private void btnCancel_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void chkOverwrite_CheckedChanged(object sender, EventArgs e) {
            if(!fileHandler.GetOverwriteState()) {
                fileHandler.SetOvervwriteState(true);
            } else {
                fileHandler.SetOvervwriteState(false);
            }
        }

        public void setListBoxAutoItem(String item) {
            ListBoxAuto.Items.Add(item);
            ListBoxAuto.EndUpdate();
        }

        public void setListBoxManualItem(String item) {
            Console.WriteLine(item);
            ListBoxManual.Items.Add(item);
            ListBoxManual.EndUpdate();
        }

        private void resetDirPathsOnTabChange(object sender, EventArgs e) {
            TxtSourcePath.Text = "";
            TxtDestPath.Text = "";
            sourceDir = "";
            destDir = "";
            ListBoxAuto.Items.Clear();
            ListBoxManual.Items.Clear();
        }

    }
}
