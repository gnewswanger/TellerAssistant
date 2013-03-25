Public Class CheckSearchReport
    Inherits GRNPrinting.PrintClassBase

    Private WithEvents previewDlg As PrintPreviewDialog
    Private chkList As ListView.ListViewItemCollection
    Private listIndex As Integer
    Private colGutter As Single = 10

    Public Sub New()
        MyBase.New()
        Me.InitializeComponents()
    End Sub

    Private Sub InitializeComponents()
        Me.rptBody.DefaultFont = New Font("Courier New", 9)

    End Sub

    Public Sub PrintCheckList(ByVal list As ListView.ListViewItemCollection, Optional ByVal title As String = Nothing, Optional ByVal subTitle As String = Nothing)
        Me.chkList = list
        Dim params As New GRNPrinting.TextLineParams
        params.IsBoxed = False
        params.BoxPen = Pens.DodgerBlue
        params.TextFont = New Font("Times New Roman", 12, FontStyle.Bold)
        params.TextPen = Pens.Black
        params.Alignment = StringAlignment.Center
        params.LineAlignment = StringAlignment.Center
        If title <> Nothing Then
            Me.AddTitleTextLine(title, 0, params, True)
        End If
        If subTitle <> Nothing Then
            params.TextFont = New Font("Times New Roman", 10, FontStyle.Bold)
            Me.AddTitleTextLine(subTitle, 0, params, True)
        End If
        listIndex = 0
        Dim previewDlg As New System.Windows.Forms.PrintDialog
        previewDlg.UseEXDialog = True
        previewDlg.Document = prtDoc
        'previewDlg.WindowState = System.Windows.Forms.FormWindowState.Maximized
        AddHandler prtDoc.PrintPage, AddressOf Prtr_PrintSearchReport
        firstPass = True
        If previewDlg.ShowDialog() = DialogResult.OK Then
            previewDlg.Document.Print()
        End If
        ResetAllRecords()
        RemoveHandler prtDoc.PrintPage, AddressOf Prtr_PrintSearchReport
    End Sub

    Private Sub Prtr_PrintSearchReport(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        e.PageSettings.Margins.Left = 50
        e.PageSettings.Margins.Right = 50
        Dim xPos As Single = e.PageSettings.Margins.Left
        Dim yPos As Single = e.MarginBounds.Top - (rptBody.DefaultFont.GetHeight(e.Graphics) / 2)
        Dim lineHeight As Single = rptBody.DefaultFont.GetHeight(e.Graphics)
        Dim minColWidth As Single = 350
        Dim colCount As Integer = CInt((e.PageSettings.Bounds.Width - e.PageSettings.Margins.Right - e.PageSettings.Margins.Left) / minColWidth)
        Dim colWidth As Single = CSng(((e.PageSettings.Bounds.Width - e.PageSettings.Margins.Right - e.PageSettings.Margins.Left) / colCount) - colGutter)
        columns.Clear()
        For i As Integer = 0 To colCount - 1
            CreateColumn(i + 1, CInt(e.PageSettings.Margins.Left + ((colWidth + colGutter) * i)), CInt(colWidth))
        Next
        Dim boxHght As Single = 3 * lineHeight
        Dim rect As New RectangleF(xPos, yPos, e.PageSettings.Margins.Right - xPos, boxHght)
        DrawTextBlockRecord(Me.rptTitle, e)
        yPos = Me.rptTitle.Rect.Bottom + Me.rptTitle.DefaultFont.GetHeight(e.Graphics)
        Dim prtRect As New Rectangle(CInt(xPos), CInt(yPos), CInt(colWidth), CInt(colWidth / 2))
        'Dim lstItem As ListViewItem
        Dim colIndex As Integer = 1
        For i As Integer = listIndex To chkList.Count - 1
            'For Each lstItem In chkList
            Dim chk As ChecksClass = CType(chkList(i).Tag, ChecksClass)
            Dim prtText As String = chk.ImageFullPath.Substring(chk.ImageFullPath.LastIndexOf("\") - 6, 6) + "  " + chk.Text
            Dim chkPrtImage As New GRNPrinting.Image2PrintClass(New CheckImageClass(chk.ImageFullPath + chk.ImageFile).CheckImage, _
                                                                prtRect, prtText, rptBody.DefaultFont)
            e.Graphics.DrawImage(chkPrtImage.PrintImage, New Point(CInt(xPos), CInt(yPos)))
            colIndex += 1
            If colIndex > colCount Then
                colIndex = 1
                yPos += prtRect.Height + colGutter
                If yPos > e.MarginBounds.Bottom Then
                    If chkList.Count - 1 > i Then
                        listIndex = i + 1
                        firstPass = False
                        e.HasMorePages = True
                        Exit Sub
                    Else
                        e.HasMorePages = False
                    End If
                End If
            End If
            xPos = columns.GetItemByID(CStr(colIndex)).ColumnLeft
        Next

    End Sub

End Class
