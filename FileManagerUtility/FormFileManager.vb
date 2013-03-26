Imports System.Windows.Forms
Imports System.IO
Imports System.Net.Mail

Public Class FormFileManager

    Private Sub FormFileManager_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        AddDrivesToTreeView(tvFromFolders.Nodes)
        AddDrivesToTreeView(tvToFolders.Nodes)

    End Sub

    Private Sub AddDrivesToTreeView(ByRef tv As TreeNodeCollection)
        'add drives to the treeview
        Dim sDrives() As String = Directory.GetLogicalDrives
        Dim sDrive As String
        Dim tNode As TreeNode

        For Each sDrive In sDrives
            Dim drvInf As DriveInfo = New DriveInfo(sDrive)
            If drvInf.IsReady Then
                tNode = tv.Add(sDrive)
                'add a dummy node
                tNode.Nodes.Add("dummy")
            End If
        Next

    End Sub

    Private Sub tvFromFolders_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvFromFolders.AfterSelect, tvToFolders.AfterSelect
        Dim drivInf As DriveInfo = New DriveInfo(CType(sender, TreeView).SelectedNode.FullPath)
        If drivInf.IsReady Then
            Dim sFiles() As String = Directory.GetFiles(CType(sender, TreeView).SelectedNode.FullPath)
            Select Case CType(sender, TreeView).Name
                Case "tvFromFolders"
                    GetFiles(lvFromFiles, sFiles)
                Case "tvToFolders"

            End Select
        End If
    End Sub

    Private Sub GetFiles(ByRef lv As ListView, ByVal sFiles() As String)
        Dim lvItem As ListViewItem
        lv.Items.Clear()
        Dim sFile As String
        For Each sFile In sFiles
            lvItem = lv.Items.Add(StripPath(sFile))
            If lv.Items.Count > 0 Then
                lvItem.SubItems.Add(File.GetLastWriteTime(sFile).ToString)
            End If
        Next
    End Sub

    Private Sub tvFromFolders_BeforeExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles tvFromFolders.BeforeExpand, tvToFolders.BeforeExpand
        Dim oNode As TreeNode = CType(e.Node, TreeNode)
        If oNode.Nodes(0).Text = "dummy" Then
            'remove the dummy
            oNode.Nodes(0).Remove()
            'add the real children
            'GetChildren(oNode)
        End If
        GetChildren(oNode)
    End Sub

    Private Sub GetChildren(ByVal node As TreeNode)
        Dim sDirs() As String = Directory.GetDirectories(node.FullPath)
        Dim sDir As String
        Dim tNode As TreeNode

        For Each sDir In sDirs
            tNode = node.Nodes.Add(StripPath(sDir))
            'add a dummy node as a child
            tNode.Nodes.Add("dummy")
        Next
    End Sub

    Private Function StripPath(ByVal path As String) As String
        Dim pos As Integer
        pos = path.LastIndexOf("\")
        Return path.Substring(pos + 1)
    End Function

    Private Sub FormFileManager_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnMoveFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveFiles.Click
        Dim srcDir As String
        Dim destDir As String
        If tvFromFolders.SelectedNode IsNot Nothing AndAlso tvToFolders.SelectedNode IsNot Nothing Then
            srcDir = tvFromFolders.SelectedNode.FullPath
            srcDir = srcDir.Replace("\\", "\")
            destDir = tvToFolders.SelectedNode.FullPath & "\\" & tvFromFolders.SelectedNode.Text
            destDir = destDir.Replace("\\", "\")
            If MessageBox.Show("You are about to move the directory at " & srcDir _
                               & " to the directory named " & destDir & vbCrLf & ". Do you wish to continue?", "Move Directory Files", _
                               MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

                If CopyDirectory(srcDir, destDir) Then
                    Try
                        System.IO.Directory.Delete(srcDir, True)
                        tvFromFolders.SelectedNode.Remove()
                    Catch ex As Exception
                        MsgBox("Failed in deleting the directory " & srcDir & ". " & ex.Message)
                    End Try
                End If
            End If
        Else
            MsgBox("You must select both a source directory and a destination parent directory.")
        End If
    End Sub

    Private Function CopyDirectory(ByVal SourcePath As String, ByVal DestPath As String, Optional ByVal Overwrite As Boolean = False) As Boolean
        Dim retVal As Boolean = False
        Dim sourceDir As DirectoryInfo = New DirectoryInfo(SourcePath)
        Dim destDir As DirectoryInfo = New DirectoryInfo(DestPath)

        If sourceDir.Exists Then
            ' if destination SubDir's parent SubDir does not exist throw an exception
            If Not destDir.Parent.Exists Then
                Throw New DirectoryNotFoundException _
                    ("Destination directory does not exist: " + destDir.Parent.FullName)
            End If

            If Not destDir.Exists Then
                destDir.Create()
            End If

            ' copy all the files of the current directory
            Dim ChildFile As FileInfo
            For Each ChildFile In sourceDir.GetFiles()
                If Overwrite Then
                    ChildFile.CopyTo(Path.Combine(destDir.FullName, ChildFile.Name), True)
                Else
                    ' if Overwrite = false, copy the file only if it does not exist
                    ' this is done to avoid an IOException if a file already exists
                    ' this way the other files can be copied anyway...
                    If Not File.Exists(Path.Combine(destDir.FullName, ChildFile.Name)) Then
                        ChildFile.CopyTo(Path.Combine(destDir.FullName, ChildFile.Name), False)
                    End If
                End If
            Next

            ' copy all the sub-directories by recursively calling this same routine
            Dim SubDir As DirectoryInfo
            For Each SubDir In sourceDir.GetDirectories()
                CopyDirectory(SubDir.FullName, Path.Combine(destDir.FullName, _
                    SubDir.Name), Overwrite)
            Next
            retVal = True
        Else
            Throw New DirectoryNotFoundException("Source directory does not exist: " + sourceDir.FullName)
        End If
        Return retVal
    End Function

End Class