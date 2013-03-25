Imports System.Drawing
Imports System.Drawing.Printing

<Assembly: CLSCompliant(True)> 
Public MustInherit Class PrintClassBase
    Inherits mvcLibrary.mvcAbstractModel

#Region "Protected Members"
    Protected WithEvents prtDoc As PrintDocument
    Protected printObject As Object
    Protected rptTitle As GRNPrinting.TextBlockRecord
    Protected rptHeader As GRNPrinting.TextBlockRecord
    Protected rptFooter As GRNPrinting.TextBlockRecord
    Protected rptBody As GRNPrinting.TextBlockRecord
    Protected pageNo As PageNumberRecord
    Protected stamp As DateStampRecord
    Private repMode As ReportMode
    Protected firstPass As Boolean
    Protected columns As New GRNPrinting.ListOfColumnClass

#End Region

#Region "Class Properties"

    Public Property Landscape() As Boolean
        Get
            Return prtDoc.DefaultPageSettings.Landscape
        End Get
        Set(ByVal value As Boolean)
            prtDoc.DefaultPageSettings.Landscape = value
            Dim e As New PrintTextEventArgs(PrintEventName.peLandscapeChanged)
            e.Value = prtDoc.DefaultPageSettings
            Me.NotifyObservers(Me, e)
        End Set
    End Property

#End Region

#Region "Constructor and Initialization"

    Public Sub New()
        MyBase.New()
        InitializeDefaults(False)
    End Sub

    Public Sub InitializeDefaults(ByVal landscape As Boolean)

        Me.prtDoc = New PrintDocument
        Me.prtDoc.DefaultPageSettings.Margins.Left = 80
        Me.prtDoc.DefaultPageSettings.Margins.Right = 80
        Me.prtDoc.DefaultPageSettings.Margins.Top = 60
        Me.prtDoc.DefaultPageSettings.Margins.Bottom = 90
        Me.Landscape = landscape

        Me.repMode = ReportMode.rmNone

        CreateColumn(0, prtDoc.DefaultPageSettings.Margins.Left, GetPageTextWidth)
        Dim rect As New Rectangle(columns.GetItemByID(CStr(0)).ColumnLeft, prtDoc.DefaultPageSettings.Margins.Top, columns.GetItemByID(CStr(0)).ColumnWidth, 0)
        Me.rptHeader = New TextBlockRecord(BlockTypes.btHeader, rect, True, True)
        Me.rptHeader.DefaultPen = New Pen(Color.DodgerBlue)
        Me.AttachObserver(Me.rptHeader)

        Me.rptTitle = New TextBlockRecord(BlockTypes.btTitle, rect, True, True)
        Me.rptTitle.DefaultPen = New Pen(Color.DodgerBlue)
        Me.AttachObserver(Me.rptTitle)

        Me.rptBody = New TextBlockRecord(BlockTypes.btBody, rect, False, True)
        Me.rptBody.DefaultPen = New Pen(Color.DodgerBlue)
        Me.AttachObserver(Me.rptBody)

        rect = New Rectangle(rect.X, prtDoc.DefaultPageSettings.Bounds.Bottom - prtDoc.DefaultPageSettings.Margins.Bottom, rect.Width, 0)
        Me.rptFooter = New TextBlockRecord(BlockTypes.btFooter, rect, True, True)
        Me.rptFooter.DefaultPen = New Pen(Color.DodgerBlue)
        Me.AttachObserver(Me.rptFooter)

        Me.pageNo = New PageNumberRecord()
        Me.pageNo.TextFont = New Font("Times New Roman", 8, FontStyle.Regular)
        Me.stamp = New DateStampRecord
        Me.stamp.ColumnNo = 0
        Me.stamp.LineAlignment = StringAlignment.Near
        Me.stamp.TextFont = New Font("Times New Roman", 6, FontStyle.Regular)
        Me.stamp.Text = "Printed: " + Now.ToShortDateString
    End Sub

#End Region

#Region "Reset Methods:"

    Protected Sub ResetTitle()
        rptTitle.ClearLines()
        rptTitle.RectHeight = 0
        rptTitle.Rect = New Rectangle(rptTitle.Rect.Left, rptTitle.Rect.Top, rptTitle.Rect.Width, rptTitle.RectHeight)
    End Sub

    Protected Sub ResetHeader()
        rptHeader.ClearLines()
        rptHeader.RectHeight = 0
        rptHeader.Rect = New Rectangle(rptHeader.Rect.Left, rptHeader.Rect.Top, rptHeader.Rect.Width, rptHeader.RectHeight)
    End Sub

    Protected Sub ResetBody()
        rptBody.ClearLines()
        rptBody.RectHeight = 0
        rptBody.Rect = New Rectangle(rptBody.Rect.Left, rptBody.Rect.Top, rptBody.Rect.Width, rptBody.RectHeight)
    End Sub

    Protected Sub ResetFooter()
        rptFooter.ClearLines()
        rptFooter.RectHeight = 0
        rptFooter.Rect = New Rectangle(rptFooter.Rect.Left, rptFooter.Rect.Top, rptFooter.Rect.Width, rptFooter.RectHeight)
    End Sub

#End Region

#Region "Public Methods"

    Public Sub CreateColumn(ByVal colId As Integer, ByVal xPos As Integer, ByVal width As Integer)
        Dim col As New GRNPrinting.ColumnClass(colId, xPos, width)
        columns.Add(col)
        Me.AttachObserver(col)
        columns.Sort()
    End Sub

    Public Sub ResetAllRecords()
        ResetTitle()
        ResetHeader()
        ResetBody()
        ResetFooter()
    End Sub

    Public Sub AddTitleTextLine(ByVal line As String, Optional ByVal col As Integer = 0, Optional ByVal parms As TextLineParams = Nothing, Optional ByVal newline As Boolean = False)
        rptTitle.AddTextLine(line, col, parms, newline)
    End Sub

    Public Sub AddHeaderTextLine(ByVal line As String, Optional ByVal col As Integer = 0, Optional ByVal parms As TextLineParams = Nothing, Optional ByVal newline As Boolean = False)
        rptHeader.AddTextLine(line, col, parms, newline)
    End Sub

    Public Sub AddBodyTextLine(ByVal line As String, Optional ByVal col As Integer = 0, Optional ByVal parms As TextLineParams = Nothing, Optional ByVal newline As Boolean = False)
        rptBody.AddTextLine(line, col, parms, newline)
    End Sub

    Public Sub AddFooterTextLine(ByVal line As String, Optional ByVal col As Integer = 0, Optional ByVal parms As TextLineParams = Nothing, Optional ByVal newline As Boolean = False)
        rptFooter.AddTextLine(line, col, parms, newline)
    End Sub

    Public Function GetPageTextWidth() As Integer
        Return prtDoc.DefaultPageSettings.Bounds.Width - prtDoc.DefaultPageSettings.Margins.Left - prtDoc.DefaultPageSettings.Margins.Right
    End Function

    Public Overrides Sub UpdateData(ByVal NewEvent As mvcLibrary.mvcEventArgsBase)

    End Sub
#End Region

#Region "Print Report"

    Public Sub PrintGenericReport()
        Dim previewDlg As New System.Windows.Forms.PrintPreviewDialog
        previewDlg.Document = prtDoc
        previewDlg.WindowState = System.Windows.Forms.FormWindowState.Maximized
        AddHandler prtDoc.PrintPage, AddressOf prtDoc_PrintPage
        firstPass = True
        previewDlg.ShowDialog()
        ResetAllRecords()
        RemoveHandler prtDoc.PrintPage, AddressOf prtDoc_PrintPage
    End Sub

    Protected Sub prtDoc_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Dim yPos As Single = e.MarginBounds.Top

        If rptTitle.LineCount > 0 Then
            DrawTextBlockRecord(rptTitle, e)
            yPos += rptTitle.RectHeight
        End If
        If rptHeader.LineCount > 0 Then
            DrawTextBlockRecord(rptHeader, e)
            yPos += rptHeader.RectHeight
        End If
        If rptBody.LineCount > 0 Then
            yPos += rptBody.GetTextLine(0).TextFont.GetHeight
            rptBody.Rect = New Rectangle(rptBody.Rect.X, CInt(yPos), rptBody.Rect.Width, rptBody.Rect.Height)
            DrawTextBlockRecord(rptBody, e)
            yPos += rptBody.Rect.Height
        End If
        If rptFooter.LineCount > 0 Then
            DrawTextBlockRecord(rptFooter, e)
        End If
    End Sub

#End Region

#Region "Draw Methods"

    Protected Sub DrawTextBlockRecord(ByVal record As TextBlockRecord, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Dim currentY As Integer
        currentY = record.Rect.Top
        For i As Integer = 0 To record.LineCount - 1
            If record.GetTextLine(i).Text = "[Separator]" Then
                DrawLine(record.LineColumn(i), currentY, CInt(record.GetTextLine(i).TextFont.GetHeight * 2), e)
                currentY = CInt(currentY + record.GetTextLine(i).TextFont.GetHeight * 2)
            Else
                Dim rect As New Rectangle(columns.GetItemByID(CStr(record.LineColumn(i))).ColumnLeft, currentY, _
                columns.GetItemByID(CStr(record.LineColumn(i))).ColumnWidth, CInt(record.GetTextLine(i).TextFont.GetHeight))
                e.Graphics.DrawString(record.GetTextLine(i).Text, record.GetTextLine(i).TextFont, record.GetTextLine(i).TextPen.Brush, CType(rect, RectangleF), record.GetTextLine(i).TextFormat)
                If record.GetTextLine(i).NewLine Then
                    currentY = CInt(currentY + record.GetTextLine(i).TextFont.GetHeight)
                End If
                If record.GetTextLine(i).IsBoxed Then
                    e.Graphics.DrawRectangle(record.GetTextLine(i).BoxPen, rect)
                End If
            End If
        Next
        If record.IsBoxed Then
            e.Graphics.DrawRectangle(record.DefaultPen, record.Rect)
        End If
    End Sub

    Protected Sub DrawColumn(ByVal colId As Integer, ByVal ypos As Integer, ByVal yHeight As Integer, ByVal line As String, ByVal TextFont As Font, ByVal drawFormat As System.Drawing.StringFormat, ByVal boxed As Boolean, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Dim rect As New Rectangle(columns.GetItemByID(CStr(colId)).ColumnLeft, ypos, columns.GetItemByID(CStr(colId)).ColumnWidth, yHeight)
        e.Graphics.DrawString(line, TextFont, Brushes.Black, rect, New StringFormat(drawFormat))
        If boxed Then
            e.Graphics.DrawRectangle(Pens.DodgerBlue, rect)
        End If
    End Sub

    Protected Function DrawLine(ByVal colId As Integer, ByVal ypos As Integer, ByVal yHeight As Integer, ByVal e As System.Drawing.Printing.PrintPageEventArgs) As Integer
        Dim point1 As New Point(columns.GetItemByID(CStr(colId)).ColumnLeft, CInt(ypos + (yHeight / 2)))
        Dim point2 As New Point(columns.GetItemByID(CStr(colId)).ColumnLeft + columns.GetItemByID(CStr(colId)).ColumnWidth, point1.Y)
        e.Graphics.DrawLine(Pens.DodgerBlue, point1, point2)
        Return ypos + yHeight
    End Function

    Protected Sub DrawTextbox(ByRef e As System.Drawing.Printing.PrintPageEventArgs, ByVal text As String, ByVal fnt As Font, ByVal brsh As Brush, ByVal rect As RectangleF, ByVal Bordered As Boolean)
        If Bordered Then
            e.Graphics.DrawRectangle(New Pen(brsh), rect.Left, rect.Top, rect.Width, rect.Height)
        End If
        e.Graphics.DrawString(text, fnt, brsh, rect)
    End Sub

    Protected Sub DrawImageBox(ByRef e As System.Drawing.Printing.PrintPageEventArgs, ByVal img As Image, ByVal text As String, ByVal fnt As Font, ByVal brsh As Brush, ByVal rect As RectangleF, ByVal Bordered As Boolean)
        If Bordered Then
            e.Graphics.DrawRectangle(New Pen(brsh), rect.Left, rect.Top, rect.Width, rect.Height)
        End If
        Dim txtRect As RectangleF
        If text IsNot Nothing OrElse text <> "" Then
            Dim strSize As New SizeF
            strSize = e.Graphics.MeasureString(text, fnt)
            txtRect = New RectangleF(rect.X, rect.Y - strSize.Height, strSize.Width, strSize.Height)
            e.Graphics.DrawString(text, fnt, brsh, txtRect)
        End If
        Dim imgRect As New RectangleF(rect.X, rect.Y, rect.Width, rect.Height - txtRect.Height)
        e.Graphics.DrawImage(img, imgRect, img.GetBounds(GraphicsUnit.Inch), GraphicsUnit.Inch)
    End Sub



#End Region

#Region "Print Datestamp"

    Public Sub SetDateStampTextLine(ByVal col As Integer, ByVal align As System.Drawing.StringAlignment, ByVal fnt As Font)
        Me.stamp.ColumnNo = col
        Me.stamp.LineAlignment = align
        Me.stamp.TextFont = fnt
        Me.stamp.Text = "Printed: " & Now.ToShortDateString
        Me.stamp.Rect = New Rectangle(Me.stamp.Rect.X, Me.stamp.Rect.Y, columns.GetItemByID(CStr(Me.stamp.ColumnNo)).ColumnWidth, CInt(Me.stamp.TextFont.GetHeight))
    End Sub

    Protected Sub DrawStampText(ByRef e As System.Drawing.Printing.PrintPageEventArgs)
        Dim drawFormat As New StringFormat
        drawFormat.Alignment = stamp.LineAlignment
        e.Graphics.DrawString(stamp.Text, stamp.TextFont, Brushes.Black, stamp.Rect, drawFormat)
    End Sub

#End Region

End Class
