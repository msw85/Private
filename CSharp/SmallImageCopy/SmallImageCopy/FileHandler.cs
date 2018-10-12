using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SmallImageCopy {
    class FileHandler {
        private String sourceDir;
        private String destDir;
        private Boolean overwriteState;
        MainForm mainForm;

        public FileHandler(MainForm mainForm) {
            this.mainForm = mainForm;
        }

        public List<String> FilesToList() {
            String[] filetypes = { "*.jpeg", "*.jpg", "*.png", "*.bmp", "*.gif", "*.tiff" };
            List<String> filesList = new List<String>();
            foreach (String filetype in filetypes) {
                filesList.AddRange(Directory.GetFiles(sourceDir, filetype, SearchOption.AllDirectories));
            }
         return filesList;
        }

        public void CopyFiles(List<String> files, String mode) {
            //Have destDir support subdirectories to get the right treestructure in backup (Maybe Substring?)
            foreach (String file in files) {
                String fileName = Path.GetFileName(file);
                File.Copy(file, destDir + "\\" + fileName, overwriteState);
                //File.SetAttributes(destDir + "\\" + fileName, FileAttributes.Normal);
                if (mode == "auto") {
                    mainForm.setListBoxAutoItem(file + " --> " + destDir + "\\" + fileName);
                }
                if (mode == "manual") {
                    mainForm.setListBoxManualItem(file + "\\" + fileName + " --> " + destDir + "\\" + fileName);
                }
            }
        }

        public void SetDirs(String sourceDir, String destDir) {
            this.sourceDir = sourceDir;
            this.destDir = destDir;
        }

        public void SetOvervwriteState(Boolean state) {
            overwriteState = state;
        }

        public Boolean GetOverwriteState() {
            return overwriteState;
        }
    }
}
