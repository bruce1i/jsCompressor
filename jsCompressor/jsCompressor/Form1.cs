using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jsCompressor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void OpenFolderBtn_Click(object sender, EventArgs e)
        {
            // popup select folder dialog and remove create new folder btn.
            var folderDialog = new FolderBrowserDialog();
            folderDialog.ShowNewFolderButton = false;

            var result = folderDialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                var folderPath = folderDialog.SelectedPath;
                FolderPathLab.Text = folderPath;


                // files in directory
                int x = 10;
                var files = Directory.EnumerateFiles(folderPath)
                                 .OrderByDescending(filename => filename).ToList();

                var i = 0;

                var test = Directory.GetFileSystemEntries(folderPath, "*.png", SearchOption.AllDirectories);

                var j = 0;

                //string destination_dir = System.IO.Directory.GetCurrentDirectory() + @"./4x6";

                //string[] extensions = { ".jpg", ".gif", ".png", ".tiff" };

                //string[] dizin = Directory.GetFiles(fbd.SelectedPath, "*.*")
                //    .Where(f => extensions.Contains(new FileInfo(f).Extension.ToLower())).ToArray();

                //t4x6Folder.Text = dizin.Count().ToString();

                //foreach (string file_name in dizin)
                //{
                //    File.Copy(file_name, destination_dir + file_name.Substring(fbd.SelectedPath.Length), true);
                //}

                //int fileCount = Directory.GetFiles(destination_dir, "*.*", SearchOption.TopDirectoryOnly).Length;

                //t4x6Folder.Text = filepreCount.ToString();// fileCount.ToString();

            }

            folderDialog.Dispose();
        }
    }
}
