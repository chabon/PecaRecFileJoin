using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using System.Windows.Forms;


namespace PecaRecFileJoin
{
    public static class JoinUtil
    {
        public static void JoinWmvFiles(JoinProfile joinProfile)
        {
            string asfbinArgs = "";

            // 引数にファイルを追加
            foreach(string file in joinProfile.Files )
            {
                asfbinArgs = asfbinArgs + "-i " + "\"" + file + "\"" + " "; 
            }

            // 出力ファイル名オプション追加(ファイル名は一時的なもの)
            string outputFilePath;
            outputFilePath = joinProfile.OutputDir + @"\asfbinJoined.wmv";
            asfbinArgs = asfbinArgs + "-o " + outputFilePath + " ";

            // オプション追加
            asfbinArgs = asfbinArgs + "-cvb -rkf -ba -bv -ebkf -dmo -forceindex";

            //
            Console.WriteLine(asfbinArgs);

            // asfbin実行
            if( !System.IO.File.Exists(@"external-bin\asfbin.exe") )
                MessageBox.Show("external-bin\\asfbin.exe がありません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Process p = Process.Start(@"external-bin\asfbin.exe", asfbinArgs);
            p.WaitForExit();

            // ファイルの削除
            foreach( string file in joinProfile.Files )
            {
                if( !System.IO.File.Exists(@"external-bin\trash.exe") )
                    MessageBox.Show("external-bin\\trash.exe がありません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                p = Process.Start(@"external-bin\trash.exe", "\"" + file + "\"");
                p.WaitForExit();
            }

            // リネーム
            string renamedOutputFilePath = joinProfile.OutputDir + @"\" + joinProfile.OutputFileName;
            System.IO.File.Move(outputFilePath, renamedOutputFilePath);
        }





        /// <summary>
        /// ffmpegでflvを結合
        /// @ref https://webnetforce.net/ffmpegde-dong-huawo-jie-hesuru-zui-xin-banconcatno/
        /// </summary>
        /// <param name="joinProfile"></param>
        public static void JoinFlvFiles(JoinProfile joinProfile)
        {
            // input.txtを作成(ディレクトリ構造は、\でなく/で記述)
            // パスにスペースがあるとエラーになるので、'で囲む。'自体は囲めないので分離してエスケープ
            // https://superuser.com/questions/787064/filename-quoting-in-ffmpeg-concat
            string inputFiles = "";
            foreach(string file in joinProfile.Files )
            {
                string filePath_unix = file.Replace("\\", "/");
                filePath_unix = filePath_unix.Replace("'", "'\\''");
                inputFiles = inputFiles + "file '" + filePath_unix + "'\r\n"; 
            }
            System.IO.StreamWriter sw = new System.IO.StreamWriter(@"input.txt");
            sw.Write(inputFiles);
            sw.Close();

            // 出力パス
            string outputFilePath;
            outputFilePath = joinProfile.OutputDir + @"\ffmpegJoined.flv";

            // ffmpeg引数
            string ffmpegArgs;
            //ffmpegArgs = "-safe 0 -f concat -i input.txt -c:v copy -c:a copy -c:s copy -map 0:v -map 0:a -map 0:s? " + outputFilePath;
            ffmpegArgs = "-f concat -safe 0 -i input.txt -c copy " + "\"" + outputFilePath + "\"";

            // ffmpeg実行
            if( !System.IO.File.Exists(@"external-bin\ffmpeg.exe") )
                MessageBox.Show("external-bin\\ffmpeg.exe がありません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Process p = Process.Start(@"external-bin\ffmpeg.exe", ffmpegArgs);
            p.WaitForExit();

            // ファイルの削除
            foreach( string file in joinProfile.Files )
            {
                if( !System.IO.File.Exists(@"external-bin\trash.exe") )
                    MessageBox.Show("external-bin\\trash.exe がありません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                p = Process.Start(@"external-bin\trash.exe", "\"" + file + "\"");
                p.WaitForExit();
            }

            // リネーム
            string renamedOutputFilePath = joinProfile.OutputDir + @"\" + joinProfile.OutputFileName;
            System.IO.File.Move(outputFilePath, renamedOutputFilePath);

        }

    }
}
