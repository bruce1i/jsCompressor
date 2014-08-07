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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 389);
            this.Controls.Add(this.FolderPathLab);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.OutputBox);
            this.Controls.Add(this.OpenFolderBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "李迅的 Js/Css 压缩工具 v1.1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OpenFolderBtn;
        private System.Windows.Forms.ListBox OutputBox;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.TextBox FolderPathLab;
    }
}

