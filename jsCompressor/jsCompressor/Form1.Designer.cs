namespace jsCompressor
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.OpenFolderBtn = new System.Windows.Forms.Button();
            this.OutputBox = new System.Windows.Forms.ListBox();
            this.StartBtn = new System.Windows.Forms.Button();
            this.FolderPathLab = new System.Windows.Forms.TextBox();
            this.BiaozhunRio = new System.Windows.Forms.RadioButton();
            this.MinRio = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OpenFolderBtn
            // 
            this.OpenFolderBtn.Location = new System.Drawing.Point(12, 22);
            this.OpenFolderBtn.Name = "OpenFolderBtn";
            this.OpenFolderBtn.Size = new System.Drawing.Size(75, 21);
            this.OpenFolderBtn.TabIndex = 0;
            this.OpenFolderBtn.Text = "选择文件夹";
            this.OpenFolderBtn.UseVisualStyleBackColor = true;
            this.OpenFolderBtn.Click += new System.EventHandler(this.OpenFolderBtn_Click);
            // 
            // OutputBox
            // 
            this.OutputBox.FormattingEnabled = true;
            this.OutputBox.ItemHeight = 12;
            this.OutputBox.Location = new System.Drawing.Point(12, 62);
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.Size = new System.Drawing.Size(504, 244);
            this.OutputBox.TabIndex = 2;
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(441, 322);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(75, 54);
            this.StartBtn.TabIndex = 3;
            this.StartBtn.Text = "开始压缩";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // FolderPathLab
            // 
            this.FolderPathLab.Location = new System.Drawing.Point(93, 22);
            this.FolderPathLab.Name = "FolderPathLab";
            this.FolderPathLab.ReadOnly = true;
            this.FolderPathLab.Size = new System.Drawing.Size(423, 21);
            this.FolderPathLab.TabIndex = 4;
            // 
            // BiaozhunRio
            // 
            this.BiaozhunRio.AutoSize = true;
            this.BiaozhunRio.Location = new System.Drawing.Point(360, 331);
            this.BiaozhunRio.Name = "BiaozhunRio";
            this.BiaozhunRio.Size = new System.Drawing.Size(47, 16);
            this.BiaozhunRio.TabIndex = 5;
            this.BiaozhunRio.Text = "标准";
            this.BiaozhunRio.UseVisualStyleBackColor = true;
            // 
            // MinRio
            // 
            this.MinRio.AutoSize = true;
            this.MinRio.Checked = true;
            this.MinRio.Location = new System.Drawing.Point(360, 353);
            this.MinRio.Name = "MinRio";
            this.MinRio.Size = new System.Drawing.Size(65, 16);
            this.MinRio.TabIndex = 6;
            this.MinRio.TabStop = true;
            this.MinRio.Text = "min文件";
            this.MinRio.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 322);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(335, 48);
            this.label1.TabIndex = 7;
            this.label1.Text = "标准模式：直接在原文件上压缩，不会生成min文件。\r\nmin模式：生成min文件，并删除源文件。\r\n\r\n*如果源目录中包含.git文件夹，在生成时不会包含该文件夹" +
    "。\r\n";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 389);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MinRio);
            this.Controls.Add(this.BiaozhunRio);
            this.Controls.Add(this.FolderPathLab);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.OutputBox);
            this.Controls.Add(this.OpenFolderBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "李迅的 Js/Css 压缩工具 v1.2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OpenFolderBtn;
        private System.Windows.Forms.ListBox OutputBox;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.TextBox FolderPathLab;
        private System.Windows.Forms.RadioButton BiaozhunRio;
        private System.Windows.Forms.RadioButton MinRio;
        private System.Windows.Forms.Label label1;
    }
}

