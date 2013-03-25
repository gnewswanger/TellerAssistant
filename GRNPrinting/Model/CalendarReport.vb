Imports System.Drawing

Public Class CalendarReport
    Inherits GRNPrinting.PrintClassBase

#Region "Print Calendar Methods"

    Public Sub PrintCalendar(ByVal dt As DateTime)
        printObject = dt
        Dim previewDlg As New System.Windows.Forms.PrintPreviewDialog
        previewDlg.Document = prtDoc
        previewDlg.WindowState = System.Windows.Forms.FormWindowState.Maximized
        AddHandler prtDoc.PrintPage, AddressOf PrintPageCalendar
        firstPass = True
        prtDoc.DefaultPageSettings.Landscape = True
        previewDlg.ShowDialog()
        ResetAllRecords()
        RemoveHandler prtDoc.PrintPage, AddressOf PrintPageCalendar
    End Sub

    Private Sub PrintPageCalendar(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Dim c, r, rowCount, colCount, dow1, days As Integer
        Dim ypos, cellHeight, cellWidth As Integer
        Dim sDay As String

        days = DateTime.DaysInMonth(CType(printObject, DateTime).Year, CType(printObject, DateTime).Month)
        printObject = New DateTime(CType(printObject, DateTime).Year, CType(printObject, DateTime).Month, 1)
        dow1 = CType(printObject, DateTime).DayOfWeek
        colCount = 7
        rowCount = CInt((days + (dow1 + 1)) / colCount)
        If ((days + dow1 + 1) / colCount) > rowCount Then
            rowCount = rowCount + 1
        End If
        cellWidth = CInt((e.MarginBounds.Right - e.MarginBounds.Left) / colCount)

        columns.Clear()
        'CreateColumn(0, prtDoc.DefaultPageSettings.Margins.Left, GetPageTextWidth)
        CreateColumn(1, e.MarginBounds.Left, cellWidth)
        CreateColumn(2, e.MarginBounds.Left + cellWidth, cellWidth)
        CreateColumn(3, e.MarginBounds.Left + (cellWidth * 2), cellWidth)
        CreateColumn(4, e.MarginBounds.Left + (cellWidth * 3), cellWidth)
        CreateColumn(5, e.MarginBounds.Left + (cellWidth * 4), cellWidth)
        CreateColumn(6, e.MarginBounds.Left + (cellWidth * 5), cellWidth)
        CreateColumn(7, e.MarginBounds.Left + (cellWidth * 6), cellWidth)

        stamp.Rect = New Rectangle(e.MarginBounds.Left, e.PageBounds.Top, columns.GetItemByID(CStr(Me.stamp.ColumnNo)).ColumnWidth, CInt(Me.stamp.TextFont.GetHeight))
        DrawStampText(e)

        Dim params As New TextLineParams
        params.IsBoxed = False
        params.BoxPen = Pens.DodgerBlue
        params.TextFont = New Font("Times New Roman", 12, FontStyle.Bold)
        params.TextPen = Pens.Black
        params.Alignment = StringAlignment.Near
        params.LineAlignment = StringAlignment.Near

        ResetHeader()
        rptHeader.Rect = New Rectangle(e.MarginBounds.Left, stamp.Rect.Bottom, columns.GetItemByID(CStr(0)).ColumnWidth, CInt(params.TextFont.GetHeight))
        rptHeader.AddTextLine("Custom Calendars", , params, True)

        params.Alignment = StringAlignment.Center
        params.LineAlignment = StringAlignment.Center
        params.TextFont = New Font("Times New Roman", 28, FontStyle.Bold)

        Dim mon As Type = GetType(Months)
        rptHeader.AddTextLine([Enum].GetName(GetType(Months), CType(printObject, DateTime).Month - 1) & ", " & CType(printObject, DateTime).Year.ToString, , params, True)

        params.IsBoxed = False
        params.BoxPen = Pens.DodgerBlue
        params.TextFont = New Font("Times New Roman", 10, FontStyle.Bold)
        params.TextPen = Pens.Black

        rptHeader.AddTextLine("SUN", 1, params)
        rptHeader.AddTextLine("MON", 2, params)
        rptHeader.AddTextLine("TUE", 3, params)
        rptHeader.AddTextLine("WED", 4, params)
        rptHeader.AddTextLine("THU", 5, params)
        rptHeader.AddTextLine("FRI", 6, params)
        rptHeader.AddTextLine("SAT", 7, params, True)

        DrawTextBlockRecord(rptHeader, e)

        ypos = rptHeader.Rect.Top + rptHeader.RectHeight
        cellHeight = CInt((e.MarginBounds.Bottom - rptHeader.Rect.Height - rptFooter.Rect.Height + 30) / rowCount)

        For i As Integer = 0 To (rowCount * colCount) - 1
            c = (i Mod colCount) + 1
            r = CInt(Fix((i) / colCount))
            If i >= dow1 AndAlso i < days + dow1 Then
                sDay = (i - dow1 + 1).ToString
            Else
                sDay = " "
            End If
            Dim drawFormat As New StringFormat
            drawFormat.Alignment = StringAlignment.Near
            drawFormat.LineAlignment = StringAlignment.Near
            DrawColumn(c, ypos + (r * cellHeight), cellHeight, sDay, New Font("Times New Roman", 12, FontStyle.Bold), drawFormat, True, e)
        Next
    End Sub
#End Region

End Class
