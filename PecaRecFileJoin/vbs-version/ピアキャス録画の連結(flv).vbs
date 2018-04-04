'// -------------------------------------------------------------------------- //
'//! @file   ピアキャス録画の連結(flv).vbs 
'//! @brief	 ドラッグアンドドロップでflvの録画ファイルを連結し、削除とリネームを行うスクリプト
'//! @author ----
'//! @since  2015/01/25(月)
'//!  
'//! FLVMergeを利用。 参考： http://looooooooop.blog35.fc2.com/blog-entry-638.html
'//! FLVMergeはカレントディレクトリにしか出力出来ない仕様なので、
'//! カレントディレクトリを結合する動画のあるディレクトリにする
'//!  
'//! COPYRIGHT (C) 2015 ____ ALL RIGHT RESERVED
'// -------------------------------------------------------------------------- //


Option Explicit
'CScript.exe(コンソール画面)強制実行
'@ref http://scripting.cocolog-nifty.com/blog/2007/05/cscriptexe_8312.html

Sub RerunCScript 'ここから
Dim Args
Dim Arg
If LCase(Right(WScript.FullName,11))="wscript.exe" Then
  Args=Array("cmd.exe /k CScript.exe",""""&WScript.ScriptFullName&"""")
  For Each Arg In WScript.Arguments
    ReDim Preserve Args(UBound(Args)+1)
    Args(UBound(Args))=""""&Arg&""""
  Next
  WScript.Quit CreateObject("WScript.Shell").Run(Join(Args),1,True)
End If
End Sub
RerunCScript 'ここまで





'/* ==================================================================== */
'/		メイン
'/* ==================================================================== */

'ファイルシステムオブジェクト作成
Dim objFileSys
Set objFileSys = CreateObject("Scripting.FileSystemObject")


'シェルオブジェクト作成
Dim objWshShell
Set objWshShell = WScript.CreateObject("WScript.Shell")


'入力されたファイルの表示
Wscript.Echo " "
Wscript.Echo "■入力されたファイル"
Dim args, arg

Set args = WScript.Arguments
For Each arg In args
	WScript.Echo objFileSys.GetFileName(arg)
Next



'カレントディレクトリを結合するFLVがあるフォルダに
objWshShell.CurrentDirectory = objFileSys.GetParentFolderName(args(0))
Wscript.Echo " "
WScript.echo "■現在の作業ディレクトリ= " & objWshShell.CurrentDirectory

'このスクリプトのディレクトリを取得
Dim scriptDirPath
scriptDirPath = objFileSys.GetParentFolderName(WScript.ScriptFullName)
Wscript.Echo " "
WScript.echo "■スクリプトのディレクトリ= " & scriptDirPath


'FLVMerge の引数の宣言
Dim flvMergeArgs


'ドロップしたファイルを引数に追加していく
For Each arg In args
	flvMergeArgs = flvMergeArgs & """" & arg & """" & " "
Next


'出力ファイル名のパス
Dim joinedFilePath
joinedFilePath = objFileSys.GetParentFolderName(args(0)) & "\merge.flv"


'引数表示
Wscript.Echo " "
Wscript.Echo "■FLVMerge 引数"
Wscript.echo flvMergeArgs


'FLVMerge 実行
Wscript.Echo " "
Wscript.Echo "■FLVMerge 実行"
objWshShell.Run scriptDirPath & "\FLVMerge.exe " & flvMergeArgs, 1, true
Wscript.Echo "■FLVMerge によるファイルの結合が終了しました "


'ファイルの削除(trash.exeを利用。同期処理)
Wscript.Echo " "
Wscript.Echo "■結合前のファイルの削除"
for Each arg In args
	objWshShell.Run scriptDirPath & "\trash.exe " & """" & arg & """", 0, true
Next


'リネーム
Wscript.Echo " "
Wscript.Echo "■結合後ファイルのリネーム"
Dim objFile
Set objFile = objFileSys.GetFile(joinedFilePath)
objFile.Name = objFileSys.GetFileName(args(0))
Set objFile = Nothing


'終了
Wscript.Echo " "
Wscript.Echo "■終了しました"


