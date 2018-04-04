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


'カレントディレクトリをこのVBSのあるディレクトリに
objWshShell.CurrentDirectory = objFileSys.GetParentFolderName(WScript.ScriptFullName)
WScript.echo "■現在の作業ディレクトリ= " & objWshShell.CurrentDirectory


'入力されたファイルの表示
Wscript.Echo " "
Wscript.Echo "■入力されたファイル"
Dim args, arg

Set args = WScript.Arguments
For Each arg In args
	WScript.Echo objFileSys.GetFileName(arg)
Next


'asfbinの引数の宣言
Dim asfbinArgs


'ドロップしたファイルを引数に追加していく
For Each arg In args
	asfbinArgs = asfbinArgs & "-i " & """" & arg & """" & " "
Next


'出力ファイル名オプション追加(ファイル名は一時的なもの)
Dim joinedFilePath
joinedFilePath = objFileSys.GetParentFolderName(args(0)) & "\asfbinJoined.wmv"
asfbinArgs = asfbinArgs & "-o " & joinedFilePath & " "


'オプション追加
asfbinArgs = asfbinArgs & "-cvb -rkf -ba -bv -ebkf -dmo -forceindex"


'引数表示
Wscript.Echo " "
Wscript.Echo "■asfbin 引数"
Wscript.echo asfbinargs


'asfbin 実行
Wscript.Echo " "
Wscript.Echo "■asfbin 実行"
objWshShell.Run objWshShell.CurrentDirectory & "\asfbin.exe " & asfbinArgs, 1, true
Wscript.Echo "■asfbin によるファイルの結合が終了しました "


'ファイルの削除(trash.exeを利用。同期処理)
Wscript.Echo " "
Wscript.Echo "■結合済みファイルの削除"
for Each arg In args
	objWshShell.Run objWshShell.CurrentDirectory & "\trash.exe " &  """" & arg & """" , 0, true
Next


'リネーム
Dim objFile
Set objFile = objFileSys.GetFile(joinedFilePath)
objFile.Name = objFileSys.GetFileName(args(0))
Set objFile = Nothing


'終了
Wscript.Echo " "
Wscript.Echo "■終了しました"


