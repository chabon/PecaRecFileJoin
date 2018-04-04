namespace PecaRecFileJoin
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.JoinProfileListView = new System.Windows.Forms.ListView();
            this.JoinStartButton = new System.Windows.Forms.Button();
            this.CheckBox_SpecifyOutputDir = new System.Windows.Forms.CheckBox();
            this.Label_OutputDir = new System.Windows.Forms.Label();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.ItemDeleteButton = new System.Windows.Forms.Button();
            this.TextBox_JoinFiles = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // JoinProfileListView
            // 
            this.JoinProfileListView.Dock = System.Windows.Forms.DockStyle.Top;
            this.JoinProfileListView.Location = new System.Drawing.Point(0, 0);
            this.JoinProfileListView.Margin = new System.Windows.Forms.Padding(3, 3, 3, 100);
            this.JoinProfileListView.Name = "JoinProfileListView";
            this.JoinProfileListView.Size = new System.Drawing.Size(919, 209);
            this.JoinProfileListView.TabIndex = 0;
            this.JoinProfileListView.UseCompatibleStateImageBehavior = false;
            this.JoinProfileListView.SelectedIndexChanged += new System.EventHandler(this.JoinProfileListView_SelectedIndexChanged);
            // 
            // JoinStartButton
            // 
            this.JoinStartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.JoinStartButton.Location = new System.Drawing.Point(838, 387);
            this.JoinStartButton.Name = "JoinStartButton";
            this.JoinStartButton.Size = new System.Drawing.Size(69, 22);
            this.JoinStartButton.TabIndex = 1;
            this.JoinStartButton.Text = "結合開始";
            this.JoinStartButton.UseVisualStyleBackColor = true;
            this.JoinStartButton.Click += new System.EventHandler(this.JoinStartButton_Click);
            // 
            // CheckBox_SpecifyOutputDir
            // 
            this.CheckBox_SpecifyOutputDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CheckBox_SpecifyOutputDir.AutoSize = true;
            this.CheckBox_SpecifyOutputDir.Location = new System.Drawing.Point(12, 390);
            this.CheckBox_SpecifyOutputDir.Name = "CheckBox_SpecifyOutputDir";
            this.CheckBox_SpecifyOutputDir.Size = new System.Drawing.Size(149, 16);
            this.CheckBox_SpecifyOutputDir.TabIndex = 2;
            this.CheckBox_SpecifyOutputDir.Text = "出力ディレクトリを指定する";
            this.CheckBox_SpecifyOutputDir.UseVisualStyleBackColor = true;
            // 
            // Label_OutputDir
            // 
            this.Label_OutputDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label_OutputDir.AutoSize = true;
            this.Label_OutputDir.Location = new System.Drawing.Point(206, 390);
            this.Label_OutputDir.Name = "Label_OutputDir";
            this.Label_OutputDir.Size = new System.Drawing.Size(0, 12);
            this.Label_OutputDir.TabIndex = 3;
            // 
            // BrowseButton
            // 
            this.BrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BrowseButton.Location = new System.Drawing.Point(158, 385);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(42, 22);
            this.BrowseButton.TabIndex = 4;
            this.BrowseButton.Text = "参照";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // ItemDeleteButton
            // 
            this.ItemDeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemDeleteButton.Location = new System.Drawing.Point(793, 387);
            this.ItemDeleteButton.Name = "ItemDeleteButton";
            this.ItemDeleteButton.Size = new System.Drawing.Size(39, 22);
            this.ItemDeleteButton.TabIndex = 5;
            this.ItemDeleteButton.Text = "削除";
            this.ItemDeleteButton.UseVisualStyleBackColor = true;
            this.ItemDeleteButton.Click += new System.EventHandler(this.ItemDeleteButton_Click);
            // 
            // TextBox_JoinFiles
            // 
            this.TextBox_JoinFiles.Dock = System.Windows.Forms.DockStyle.Top;
            this.TextBox_JoinFiles.Location = new System.Drawing.Point(0, 209);
            this.TextBox_JoinFiles.Multiline = true;
            this.TextBox_JoinFiles.Name = "TextBox_JoinFiles";
            this.TextBox_JoinFiles.ReadOnly = true;
            this.TextBox_JoinFiles.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextBox_JoinFiles.Size = new System.Drawing.Size(919, 164);
            this.TextBox_JoinFiles.TabIndex = 6;
            this.TextBox_JoinFiles.WordWrap = false;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 417);
            this.Controls.Add(this.TextBox_JoinFiles);
            this.Controls.Add(this.ItemDeleteButton);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.Label_OutputDir);
            this.Controls.Add(this.CheckBox_SpecifyOutputDir);
            this.Controls.Add(this.JoinStartButton);
            this.Controls.Add(this.JoinProfileListView);
            this.Name = "Form1";
            this.Text = "Peca録画連結ツール";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView JoinProfileListView;
        private System.Windows.Forms.Button JoinStartButton;
        private System.Windows.Forms.CheckBox CheckBox_SpecifyOutputDir;
        private System.Windows.Forms.Label Label_OutputDir;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.Button ItemDeleteButton;
        private System.Windows.Forms.TextBox TextBox_JoinFiles;
    }
}

