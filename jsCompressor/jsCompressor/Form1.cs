using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jsCompressor
{
    public partial class Form1 : Form
    {
        private string SelectedFolderPath { get; set; }

        public string PublicFolderPath { get; set; }

        private string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\";

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void OpenFolderBtn_Click(object sender, EventArgs e)
        {
            // popup select folder dialog and remove create new folder btn.
            var folderDialog = new FolderBrowserDialog();
            folderDialog.ShowNewFolderButton = false;

            var result = folderDialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                SelectedFolderPath = folderDialog.SelectedPath;
                FolderPathLab.Text = SelectedFolderPath;
            }

            folderDialog.Dispose();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            if (SelectedFolderPath.IsNullOrWhiteSpace())
            {
                PrintLine("请选择文件夹");
                return;
            }

            OutputBox.Items.Clear();

            DisableBtn();

            var thread = new Thread(Compressor);
            thread.Start();
        }

        private void Compressor()
        {
            SetProgress(0);

            PublicFolderPath = CreatePublicCopy();

            SetProgress(17);

            ClearMinJsAndMinCss(PublicFolderPath);

            SetProgress(35);

            CompressJsFiles(PublicFolderPath);

            SetProgress(55);

            CompressCssFiles(PublicFolderPath);

            SetProgress(70);

            ClearUncompressedJsFiles(PublicFolderPath);

            SetProgress(85);

            ClearUncompressedCssFiles(PublicFolderPath);

            EnableBtn();

            PrintLine("Done!");
        }

        private string CreatePublicCopy()
        {
            PrintLine("创建发布文件夹...");

            var folderName = "public_" + DateTime.Now.ToString("yyyy-MM-dd_HHmmss");

            while (Directory.Exists(DesktopPath + folderName))
            {
                folderName += "-" + (new Random()).Next(1, 99);
            }

            Directory.CreateDirectory(DesktopPath + folderName);

            PrintLine(string.Format("已在桌面创建发布文件夹（{0}）", folderName));

            PrintLine("文件拷贝...");

            CopyFolder(SelectedFolderPath, DesktopPath + folderName);

            PrintLine("文件拷贝完成");

            return DesktopPath + folderName;
        }

        private void ClearMinJsAndMinCss(string folderPath)
        {
            PrintLine("扫描文件夹...");

            var minJsArr = Directory.GetFileSystemEntries(folderPath, "*.min.js", SearchOption.AllDirectories);
            var minJsMapArr = Directory.GetFileSystemEntries(folderPath, "*.min.js.map", SearchOption.AllDirectories);
            var minCssArr = Directory.GetFileSystemEntries(folderPath, "*.min.css", SearchOption.AllDirectories);

            if (minJsArr.Length > 0)
            {
                PrintLine("发现*.min.js文件 " + minJsArr.Length + " 个");
                PrintLine("开始删除*.min.js文件");

                foreach (var filePath in minJsArr)
                {
                    DeleteFile(filePath);
                }

                PrintLine("*.min.js 文件删除完成");
            }

            if (minJsMapArr.Length > 0)
            {
                PrintLine("发现*.min.js.map文件 " + minJsMapArr.Length + " 个");
                PrintLine("开始删除*.min.js.map文件");

                foreach (var filePath in minJsMapArr)
                {
                    DeleteFile(filePath);
                }
                PrintLine("*.min.js.map 文件删除完成");
            }

            if (minCssArr.Length > 0)
            {
                PrintLine("发现*.min.css文件 " + minCssArr.Length + " 个");
                PrintLine("开始删除*.min.css文件");

                foreach (var filePath in minCssArr)
                {
                    DeleteFile(filePath);
                }

                PrintLine("*.min.css 文件删除完成");
            }
        }

        private void ClearUncompressedJsFiles(string folderPath)
        {
            PrintLine("开始删除未压缩js文件...");

            var jsArr = Directory.GetFileSystemEntries(folderPath, "*.js", SearchOption.AllDirectories);
            var minJsArr = Directory.GetFileSystemEntries(folderPath, "*.min.js", SearchOption.AllDirectories);

            var uncompressedJsArr = jsArr.Except(minJsArr);

            foreach (var filePath in uncompressedJsArr)
            {
                DeleteFile(filePath);
            }

            PrintLine("删除未压缩js文件完成");
        }

        private void ClearUncompressedCssFiles(string folderPath)
        {
            PrintLine("开始删除未压缩css文件...");

            var cssArr = Directory.GetFileSystemEntries(folderPath, "*.css", SearchOption.AllDirectories);
            var minCssArr = Directory.GetFileSystemEntries(folderPath, "*.min.css", SearchOption.AllDirectories);

            var uncompressedCssArr = cssArr.Except(minCssArr);

            foreach (var filePath in uncompressedCssArr)
            {
                DeleteFile(filePath);
            }

            PrintLine("删除未压缩css文件完成");
        }

        private void CompressJsFiles(string folderPath)
        {
            PrintLine("开始压缩js...");

            var jsArr = Directory.GetFileSystemEntries(folderPath, "*.js", SearchOption.AllDirectories);

            var minifier = new Minifier();
            foreach (var filePath in jsArr)
            {
                var newFilePath = Path.GetDirectoryName(filePath) + "\\" + Path.GetFileNameWithoutExtension(filePath) + ".min.js";

                // read file to string
                var contents = File.ReadAllText(filePath);
                var miniContents = minifier.MinifyJavaScript(contents);

                CreateNewFile(newFilePath, miniContents);
            }

            PrintLine("js压缩完成");
        }

        private void CompressCssFiles(string folderPath)
        {
            PrintLine("开始压缩css...");

            var cssArr = Directory.GetFileSystemEntries(folderPath, "*.css", SearchOption.AllDirectories);

            var minifier = new Minifier();
            foreach (var filePath in cssArr)
            {
                var newFilePath = Path.GetDirectoryName(filePath) + "\\" + Path.GetFileNameWithoutExtension(filePath) + ".min.css";

                // read file to string
                var contents = File.ReadAllText(filePath);
                var miniContents = minifier.MinifyStyleSheet(contents);

                CreateNewFile(newFilePath, miniContents);
            }

            PrintLine("css压缩完成");
        }

        private void CreateNewFile(string filePath, string content)
        {
            // Create the file. 
            using (FileStream fs = File.Create(filePath))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes(content);
                // Add some information to the file.
                fs.Write(info, 0, info.Length);
            }
        }

        private void DeleteFile(string filePath)
        {
            // delete file
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        private void DisableBtn()
        {
            OpenFolderBtn.Enabled = false;
            StartBtn.Enabled = false;
        }

        private void EnableBtn()
        {
            OpenFolderBtn.Enabled = true;
            StartBtn.Enabled = true;
            StartBtn.Text = "开始压缩";
        }

        private void SetProgress(int value)
        {
            StartBtn.Text = value + "%";
        }

        private void PrintLine(string content)
        {
            OutputBox.Items.Add("> " + content);
        }

        private void PrintLine(string content, string symbol)
        {
            OutputBox.Items.Add(symbol + " " + content);
        }

        public void CopyFolder(string sourceFolder, string destFolder)
        {
            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);
            string[] files = Directory.GetFiles(sourceFolder);
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(destFolder, name);
                File.Copy(file, dest);
            }
            string[] folders = Directory.GetDirectories(sourceFolder);
            foreach (string folder in folders)
            {
                // 忽略git的文件夹
                if (Path.GetFileName(folder).ToLower() == ".git")
                {
                    continue;
                }

                string name = Path.GetFileName(folder);
                string dest = Path.Combine(destFolder, name);
                CopyFolder(folder, dest);
            }
        }
    }
}
