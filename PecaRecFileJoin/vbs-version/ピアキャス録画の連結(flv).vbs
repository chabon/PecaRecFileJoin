'// -------------------------------------------------------------------------- //
'//! @file   �s�A�L���X�^��̘A��(flv).vbs 
'//! @brief	 �h���b�O�A���h�h���b�v��flv�̘^��t�@�C����A�����A�폜�ƃ��l�[�����s���X�N���v�g
'//! @author ----
'//! @since  2015/01/25(��)
'//!  
'//! FLVMerge�𗘗p�B �Q�l�F http://looooooooop.blog35.fc2.com/blog-entry-638.html
'//! FLVMerge�̓J�����g�f�B���N�g���ɂ����o�͏o���Ȃ��d�l�Ȃ̂ŁA
'//! �J�����g�f�B���N�g�����������铮��̂���f�B���N�g���ɂ���
'//!  
'//! COPYRIGHT (C) 2015 ____ ALL RIGHT RESERVED
'// -------------------------------------------------------------------------- //


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


'���͂��ꂽ�t�@�C���̕\��
Wscript.Echo " "
Wscript.Echo "�����͂��ꂽ�t�@�C��"
Dim args, arg

Set args = WScript.Arguments
For Each arg In args
	WScript.Echo objFileSys.GetFileName(arg)
Next



'�J�����g�f�B���N�g������������FLV������t�H���_��
objWshShell.CurrentDirectory = objFileSys.GetParentFolderName(args(0))
Wscript.Echo " "
WScript.echo "�����݂̍�ƃf�B���N�g��= " & objWshShell.CurrentDirectory

'���̃X�N���v�g�̃f�B���N�g�����擾
Dim scriptDirPath
scriptDirPath = objFileSys.GetParentFolderName(WScript.ScriptFullName)
Wscript.Echo " "
WScript.echo "���X�N���v�g�̃f�B���N�g��= " & scriptDirPath


'FLVMerge �̈����̐錾
Dim flvMergeArgs


'�h���b�v�����t�@�C���������ɒǉ����Ă���
For Each arg In args
	flvMergeArgs = flvMergeArgs & """" & arg & """" & " "
Next


'�o�̓t�@�C�����̃p�X
Dim joinedFilePath
joinedFilePath = objFileSys.GetParentFolderName(args(0)) & "\merge.flv"


'�����\��
Wscript.Echo " "
Wscript.Echo "��FLVMerge ����"
Wscript.echo flvMergeArgs


'FLVMerge ���s
Wscript.Echo " "
Wscript.Echo "��FLVMerge ���s"
objWshShell.Run scriptDirPath & "\FLVMerge.exe " & flvMergeArgs, 1, true
Wscript.Echo "��FLVMerge �ɂ��t�@�C���̌������I�����܂��� "


'�t�@�C���̍폜(trash.exe�𗘗p�B��������)
Wscript.Echo " "
Wscript.Echo "�������O�̃t�@�C���̍폜"
for Each arg In args
	objWshShell.Run scriptDirPath & "\trash.exe " & """" & arg & """", 0, true
Next


'���l�[��
Wscript.Echo " "
Wscript.Echo "��������t�@�C���̃��l�[��"
Dim objFile
Set objFile = objFileSys.GetFile(joinedFilePath)
objFile.Name = objFileSys.GetFileName(args(0))
Set objFile = Nothing


'�I��
Wscript.Echo " "
Wscript.Echo "���I�����܂���"


