Imports System.IO
Imports System.Xml

Public Class DialogEditAppSettings

    Private isDirty As Boolean = False
    Private isMySettingsChanged As Boolean = False
    Private currSearchStr As String = String.Empty
    Private xd As XmlDocument = New XmlDocument

    Private Sub dlgEditAppSettings_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If isMySettingsChanged Then
            If MsgBox("Application settings have been changed. Do you want to save them?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                My.Settings.Save()
            Else
                My.Settings.Reset()
            End If
        End If
    End Sub

    Private Sub dlgEditAppSettings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        isDirty = False
        Try
            Dim path As String = Application.LocalUserAppDataPath & "\" & My.Settings.MySettingsFilename
            If File.Exists(path) Then
                xd.Load(path)
                GetScannerSettings()
                PropertyGrid1.SelectedObject = My.Settings
            Else

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub toolBtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolBtnClose.Click
        Close()
    End Sub

    Private Sub GetScannerSettings()
        Try
            tvScannerSettings.Nodes.Clear()
            tvScannerSettings.Nodes.Add(New TreeNode(xd.DocumentElement.Name))
            Dim tNode As TreeNode = New TreeNode()
            tNode = tvScannerSettings.Nodes(0)
            AddNode(xd.DocumentElement, tNode)
            tvScannerSettings.ExpandAll()
        Catch xmlex As XmlException
            MessageBox.Show(xmlex.Message)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub AddNode(ByVal inXmlNode As XmlNode, ByVal inTreeNode As TreeNode)
        Dim xNode As XmlNode
        Dim tNode As TreeNode
        Dim nodeList As XmlNodeList
        If (inXmlNode.HasChildNodes) AndAlso (inXmlNode.FirstChild.NodeType <> XmlNodeType.Text) Then
            nodeList = inXmlNode.ChildNodes
            For i As Integer = 0 To nodeList.Count - 1
                xNode = inXmlNode.ChildNodes(i)
                If xNode.NodeType <> XmlNodeType.Comment Then
                    inTreeNode.Nodes.Add(New TreeNode(xNode.Name))
                    If (xNode.Attributes IsNot Nothing AndAlso xNode.Attributes.GetNamedItem("name") IsNot Nothing) _
                    AndAlso xNode.NodeType <> XmlNodeType.Text Then
                        inTreeNode.LastNode.Nodes.Add(New TreeNode("[@name='" & xNode.Attributes("name").Value))
                    End If
                    tNode = inTreeNode.LastNode
                    AddNode(xNode, tNode)
                End If
            Next
            '    'inTreeNode.Text = (inXmlNode.OuterXml).Trim
        End If
    End Sub

    Private Function ReadSettingFromXml(ByVal xmlPath As String) As String
        Return xd.SelectSingleNode(xmlPath).InnerText
    End Function

    Private Sub WriteSettingToXml(ByVal xmlPath As String, ByVal value As String)
        xd.SelectSingleNode(xmlPath).InnerText = value
        xd.Save(Application.LocalUserAppDataPath & "\" & My.Settings.MySettingsFilename)
    End Sub

    Private Sub tvScannerSettings_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvScannerSettings.AfterSelect
        SetSettingScannerEditPanel()
    End Sub

    Private Sub SetSettingScannerEditPanel()
        If tvScannerSettings.SelectedNode.Nodes.Count = 0 Then
            Dim lvl As Integer = tvScannerSettings.SelectedNode.Level
            Dim srchStr As String = String.Empty
            Dim tnode As TreeNode
            tnode = tvScannerSettings.SelectedNode
            srchStr = tnode.FullPath.Trim
            srchStr = srchStr.Replace("\", "/")
            If srchStr.LastIndexOf("[") > 0 Then
                srchStr = srchStr.Replace("/[", "[")
                srchStr = srchStr & "']"
            End If
            currSearchStr = srchStr
            txtrchScannerSettings.Text = ReadSettingFromXml(currSearchStr)
            If txtrchScannerSettings.Text = "" Then
                txtrchScannerSettings.Text = "(No value assigned.)"
            End If
        Else
            txtrchScannerSettings.Text = ""
        End If
    End Sub

    Private Sub txtrchScannerSettings_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtrchScannerSettings.KeyPress
        isDirty = True
    End Sub

    Private Sub tvScannerSettings_BeforeSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles tvScannerSettings.BeforeSelect
        If isDirty Then
            If MessageBox.Show("The current value was changed. Do you wish to save the new value?", "Save Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                WriteSettingToXml(currSearchStr, txtrchScannerSettings.Text.Trim)
                isDirty = False
            End If
        End If
    End Sub

    Private Sub PropertyGrid1_PropertyValueChanged(ByVal s As Object, ByVal e As System.Windows.Forms.PropertyValueChangedEventArgs) Handles PropertyGrid1.PropertyValueChanged
        isMySettingsChanged = True
    End Sub
End Class