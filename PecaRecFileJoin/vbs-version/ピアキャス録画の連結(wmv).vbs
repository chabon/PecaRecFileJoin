Option Explicit



'CScript.exe(�R���\�[�����)�������s
'@ref http://scripting.cocolog-nifty.com/blog/2007/05/cscriptexe_8312.html

Sub RerunCScript '��������
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
RerunCScript '�����܂�




'/* ==================================================================== */
'/		���C��
'/* ==================================================================== */

'�t�@�C���V�X�e���I�u�W�F�N�g�쐬
Dim objFileSys
Set objFileSys = CreateObject("Scripting.FileSystemObject")


'�V�F���I�u�W�F�N�g�쐬
Dim objWshShell
Set objWshShell = WScript.CreateObject("WScript.Shell")


'�J�����g�f�B���N�g��������VBS�̂���f�B���N�g����
objWshShell.CurrentDirectory = objFileSys.GetParentFolderName(WScript.ScriptFullName)
WScript.echo "�����݂̍�ƃf�B���N�g��= " & objWshShell.CurrentDirectory


'���͂��ꂽ�t�@�C���̕\��
Wscript.Echo " "
Wscript.Echo "�����͂��ꂽ�t�@�C��"
Dim args, arg

Set args = WScript.Arguments
For Each arg In args
	WScript.Echo objFileSys.GetFileName(arg)
Next


'asfbin�̈����̐錾
Dim asfbinArgs


'�h���b�v�����t�@�C���������ɒǉ����Ă���
For Each arg In args
	asfbinArgs = asfbinArgs & "-i " & """" & arg & """" & " "
Next


'�o�̓t�@�C�����I�v�V�����ǉ�(�t�@�C�����͈ꎞ�I�Ȃ���)
Dim joinedFilePath
joinedFilePath = objFileSys.GetParentFolderName(args(0)) & "\asfbinJoined.wmv"
asfbinArgs = asfbinArgs & "-o " & joinedFilePath & " "


'�I�v�V�����ǉ�
asfbinArgs = asfbinArgs & "-cvb -rkf -ba -bv -ebkf -dmo -forceindex"


'�����\��
Wscript.Echo " "
Wscript.Echo "��asfbin ����"
Wscript.echo asfbinargs


'asfbin ���s
Wscript.Echo " "
Wscript.Echo "��asfbin ���s"
objWshShell.Run objWshShell.CurrentDirectory & "\asfbin.exe " & asfbinArgs, 1, true
Wscript.Echo "��asfbin �ɂ��t�@�C���̌������I�����܂��� "


'�t�@�C���̍폜(trash.exe�𗘗p�B��������)
Wscript.Echo " "
Wscript.Echo "�������ς݃t�@�C���̍폜"
for Each arg In args
	objWshShell.Run objWshShell.CurrentDirectory & "\trash.exe " &  """" & arg & """" , 0, true
Next


'���l�[��
Dim objFile
Set objFile = objFileSys.GetFile(joinedFilePath)
objFile.Name = objFileSys.GetFileName(args(0))
Set objFile = Nothing


'�I��
Wscript.Echo " "
Wscript.Echo "���I�����܂���"


