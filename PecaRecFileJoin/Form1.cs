using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PecaRecFileJoin
{
    public partial class Form1 : Form
    {
        public List<JoinProfile> JoinProfileList = new List<JoinProfile>();

        public Form1()
        {
            InitializeComponent();
            InitiarizeJoinProfileListView();

            // ini読み込み
            IniFile ini = new IniFile("./setting.ini");
            string val = ini["main", "specify-outputdir"];
            if( val == "True" ) CheckBox_SpecifyOutputDir.Checked = true;
            val = ini["main", "outputdir"];
            if( val != "" ) Label_OutputDir.Text = val;
        }

        public void InitiarizeJoinProfileListView()
        {
            // ListViewコントロールのプロパティを設定
            JoinProfileListView.FullRowSelect = true;
            JoinProfileListView.GridLines = true;
            JoinProfileListView.Sorting = SortOrder.None;
            JoinProfileListView.View = View.Details;
            JoinProfileListView.ShowItemToolTips = true;
            JoinProfileListView.MultiSelect = false;

            // 列（コラム）ヘッダの作成
            ColumnHeader columnName, columnFileCnt, columnExt, columnState, columnDirPath;
            columnName = new ColumnHeader();
            columnExt = new ColumnHeader();
            columnState = new ColumnHeader();
            columnFileCnt = new ColumnHeader();
            columnDirPath = new ColumnHeader();

            columnName.Text = "出力ファイル名";
            columnName.Width = 450;
            columnExt.Text = "拡張子";
            columnExt.Width = 50;
            columnFileCnt.Text = "Cnt";
            columnFileCnt.Width = 50;
            columnState.Text = "状態";
            columnState.Width = 50;
            columnDirPath.Text = "結合元ファイルディレクトリ";
            columnDirPath.Width = 300;

            ColumnHeader[] colHeaderRegValue = 
                { columnName, columnExt, columnFileCnt, columnState , columnDirPath };
            JoinProfileListView.Columns.AddRange(colHeaderRegValue);

        }

        public void UpdateJoinProfileListView()
        {
            JoinProfileListView.Items.Clear();

            foreach(JoinProfile jp in JoinProfileList )
            {
                string[] items = {
                    jp.OutputFileName,
                    jp.Extension,
                    jp.Files.Count().ToString(),
                    jp.State,
                    System.IO.Path.GetDirectoryName( jp.Files[0] )
                };
                ListViewItem lvi = new ListViewItem(items);
                JoinProfileListView.Items.Add(lvi);
            }
        }

        public void UpdateJoinFilesTextBox()
        {
            TextBox_JoinFiles.Text = "";
            if( JoinProfileListView.SelectedItems.Count < 1 ) return;

            int idx = JoinProfileListView.SelectedIndices[0];
            if(idx < JoinProfileList.Count )
            {
                string txt = "";
                foreach(string file in JoinProfileList[idx].Files )
                {
                    txt += file + "\r\n";
                }
                TextBox_JoinFiles.Text = txt;
            }
        }

        /* ---------------------------------------------------- */
        //     Event
        /* ---------------------------------------------------- */
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            //コントロール内にドラッグされたとき実行される
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                //ドラッグされたデータ形式を調べ、ファイルのときはコピーとする
                e.Effect = DragDropEffects.Copy;
            else
                //ファイル以外は受け付けない
                e.Effect = DragDropEffects.None;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[]) e.Data.GetData(DataFormats.FileDrop, false);
            if( files.Length < 2 ) return;

            // 拡張子が全てのファイルで一致しているかチェック
            string ext = System.IO.Path.GetExtension(files[0]).ToLower();
            for(int i=1; i< files.Length; i++ )
            {
                if( ext != System.IO.Path.GetExtension(files[i]).ToLower() )
                {
                    MessageBox.Show("拡張子が一致していません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // ディレクトリまでのパスに'が含まれている(ffmpegのinput.txt作成で都合が悪い)
            //foreach(string file in files )
            //{
            //    if( System.IO.Path.GetDirectoryName(file).Contains('\'') )
            //    {
            //        MessageBox.Show("ディレクトリパスに'が含まれています", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //}

            // 完了済みアイテムを削除
            JoinProfileList.RemoveAll(j => j.State != "待機");


            // 昇順ソート
            Array.Sort(files);

            // プロファイル作成
            JoinProfile jp = new JoinProfile();
            jp.OutputFileName = System.IO.Path.GetFileName( files[0] );
            jp.Extension = System.IO.Path.GetExtension( files[0] ).ToLower();
            jp.Files = files;
            this.JoinProfileList.Add(jp);

            // ListView更新
            UpdateJoinProfileListView();
        }

        private void JoinProfileListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateJoinFilesTextBox();
        }

        private void JoinStartButton_Click(object sender, EventArgs e)
        {
            if( JoinProfileList.Count < 1 ) return;

            foreach(JoinProfile jp in JoinProfileList )
            {
                // 出力ディレクトリを指定
                if(CheckBox_SpecifyOutputDir.Checked
                    && System.IO.Directory.Exists(Label_OutputDir.Text) )
                {
                    jp.OutputDir = Label_OutputDir.Text;
                }
                else
                {
                    jp.OutputDir = System.IO.Path.GetDirectoryName(jp.Files[0]);
                }

                // 結合処理開始
                jp.State = "処理中";
                if(jp.Extension == ".wmv" )
                {
                    JoinUtil.JoinWmvFiles(jp);
                }
                else if(jp.Extension == ".flv" )
                {
                    JoinUtil.JoinFlvFiles(jp);
                }
                jp.State = "完了";
                UpdateJoinProfileListView();
            }
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "フォルダを指定してください。";
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            //fbd.SelectedPath = @"C:\Windows";
            fbd.ShowNewFolderButton = true;

            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                this.Label_OutputDir.Text = fbd.SelectedPath;
            }
        }

        private void ItemDeleteButton_Click(object sender, EventArgs e)
        {

            if( JoinProfileListView.SelectedItems.Count < 1 ) return;

            int idx = JoinProfileListView.SelectedIndices[0];
            if(idx < JoinProfileList.Count )
            {
                JoinProfileList.RemoveAt(idx);
                UpdateJoinProfileListView();
                UpdateJoinFilesTextBox();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            IniFile ini = new IniFile("./setting.ini");
            ini["main", "specify-outputdir"] = CheckBox_SpecifyOutputDir.Checked.ToString();
            ini["main", "outputdir"] = Label_OutputDir.Text;
        }
    }
}
