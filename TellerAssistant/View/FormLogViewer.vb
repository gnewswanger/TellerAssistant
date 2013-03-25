Imports System.IO

Public Class FormLogViewer

    Private isDirty As Boolean

    Public Sub New(ByVal fullname As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        InitializeListview(fullname)

    End Sub

    Private Sub InitializeListview(ByVal fname As String)
        Try
            isDirty = False
            Dim sr As StreamReader
            Dim fs As FileStream
            lvExceptionList.Items.Clear()
            If File.Exists(fname) Then
                fs = New FileStream(fname, FileMode.OpenOrCreate)
                sr = New StreamReader(fs)
                If sr.Peek = -1 Then
                    lvExceptionList.Items.Add("No Exceptions Found")
                End If
                Dim strs(5) As String
                While sr.Peek <> -1
                    Dim charSeparators() As Char = {","c}
                    Dim str As String = sr.ReadLine
                    strs = str.Split(charSeparators, StringSplitOptions.None)
                    Dim itm As New ListViewItem
                    itm.Text = New String(CType(strs(1), Char()))
                    'itm.SubItems.Add(New String(strs(1)))
                    itm.SubItems.Add(New String(CType(strs(2), Char())))
                    itm.SubItems.Add(New String(CType(strs(3), Char())))
                    If strs(4) Is Nothing Then
                        strs(4) = String.Empty
                    End If
                    itm.SubItems.Add(New String(CType(strs(4), Char())))

                    Dim group As ListViewGroup = New ListViewGroup(New String(CType(strs(0), Char())), New String(CType(strs(0), Char())))
                    If lvExceptionList.Groups(group.Name) Is Nothing Then
                        lvExceptionList.Groups.Add(group)
                    End If
                    itm.Group = lvExceptionList.Groups(group.Name)
                    lvExceptionList.Items.Add(itm)
                    If lvExceptionList.Items.Count > 500 Then
                        lvExceptionList.Items.Item(0).Remove()
                        isDirty = True
                    End If
                End While
                sr.Close()
                fs.Close()
            Else
                lvExceptionList.Items.Add("No Exceptions Found")
            End If
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show("at InitializeListview: " & ex.Message, "Load Exception Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        CloseToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub ClearSelectedRecordsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearSelectedRecordsToolStripMenuItem.Click
        Dim lst As ListView.CheckedListViewItemCollection
        lst = lvExceptionList.CheckedItems
        For Each item As ListViewItem In lst
            lvExceptionList.Items.Remove(item)
            isDirty = True
        Next
        lvExceptionList.Refresh()
    End Sub

    Private Sub frmLogViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If isDirty Then
            If MessageBox.Show("Some records were removed from list and will be permanently deleted from file. " _
                               & "Do you want to continue?", "Saving list to file", MessageBoxButtons.YesNo, _
                               MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                Dim lst As New List(Of String)
                For Each item As ListViewItem In lvExceptionList.Items
                    's1.WriteLine(title & "," & msg & "," & excpt & "," & detail & "," & exceptDate)
                    lst.Add(item.Group.Name & "," & item.SubItems(0).Text & "," & item.SubItems(1).Text & "," & item.SubItems(2).Text & "," & item.SubItems(3).Text)
                Next
                RewriteErrorLog(lst)
            Else
                e.Cancel = True
                isDirty = False
            End If
        End If
    End Sub
End Class