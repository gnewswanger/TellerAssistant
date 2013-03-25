Imports System.Drawing

Public Class DepositReport
    Inherits GRNPrinting.PrintClassBase

    Private WithEvents previewDlg As PrintPreviewDialog
    Private colGutter As Single = 30
    Private currDetail As DepositDetailClass
    Private chkListIndex As Integer
    Private yDetailStart As Single

    Public Sub New(ByVal detail As DepositDetailClass)
        MyBase.New()
        currDetail = detail
        rptBody.DefaultFont = New Font("Courier New", 9)
    End Sub

    Public Sub NewPrintDepositTicket()
        Dim printDlg As New PrintDialog()

    End Sub

    Public Sub PrintDepositTicket()
        'Dim previewDlg As New System.Windows.Forms.PrintPreviewDialog
        Dim previewDlg As New GRNPrinting.GRNPreviewDialog
        Me.prtDoc.DefaultPageSettings.PrinterSettings.Copies = 3
        previewDlg.Document = prtDoc
        'previewDlg.WindowState = System.Windows.Forms.FormWindowState.Maximized
        AddHandler prtDoc.PrintPage, AddressOf Prtr_PrintDepositSlip
        firstPass = True
        If previewDlg.ShowDialog = DialogResult.OK Then
            previewDlg.Document.Print()
        End If
        ResetAllRecords()
        RemoveHandler prtDoc.PrintPage, AddressOf Prtr_PrintDepositSlip
    End Sub

    Private Sub Prtr_PrintDepositSlip(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Dim xPos As Single = e.MarginBounds.Left
        Dim yPos As Single = e.MarginBounds.Top - (rptBody.DefaultFont.GetHeight(e.Graphics) / 2)
        Dim lineHeight As Single = rptBody.DefaultFont.GetHeight(e.Graphics)
        Dim colWidth As Single = (e.MarginBounds.Right - e.MarginBounds.Left - colGutter) / 2
        Dim boxHght As Single = 3 * lineHeight
        Dim str As String = String.Empty
        If firstPass Then
            Dim rect As New RectangleF(xPos, yPos, e.MarginBounds.Right - xPos, boxHght)

            yPos = CSng(e.MarginBounds.Top + lineHeight * 7.5)
            e.Graphics.DrawString(currDetail.DepositSummary.DepositDate.ToShortDateString, rptHeader.DefaultFont, Brushes.Black, xPos + 35, yPos)

            str = [String].Format("{0,14:C}", currDetail.GetTotalCoins + currDetail.GetTotalCurrency)
            rect.Location = New PointF(xPos + colWidth + colGutter + 60, e.MarginBounds.Top)
            rect.Size = New SizeF(colWidth, lineHeight * 2)
            DrawTextbox(e, str, rptBody.DefaultFont, Brushes.Black, rect, False)

            str = [String].Format("{0,14:C}", currDetail.GetTotalChecks)
            rect.Location = New PointF(xPos + colWidth + colGutter + 60, e.MarginBounds.Top + lineHeight * 2)
            DrawTextbox(e, str, rptBody.DefaultFont, Brushes.Black, rect, False)

            str = [String].Format("{0,6}", currDetail.GetCheckCount)
            rect.Location = New PointF(xPos + colWidth + colGutter + 60, e.MarginBounds.Top + lineHeight * 6)
            DrawTextbox(e, str, rptBody.DefaultFont, Brushes.Black, rect, False)

            str = [String].Format("{0,14:C}", currDetail.GetTotalDeposit)
            rect.Location = New PointF(xPos + colWidth + colGutter + 60, e.MarginBounds.Top + lineHeight * 8)
            DrawTextbox(e, str, rptBody.DefaultFont, Brushes.Black, rect, False)

            yPos += lineHeight * 12

            e.Graphics.DrawString(currDetail.DepositSummary.DepositNumber + " - " + currDetail.DepositSummary.Description, rptHeader.DefaultFont, Brushes.Black, xPos, yPos)
            yPos += CSng(lineHeight * 1.5)
            e.Graphics.DrawString("Check List", rptHeader.DefaultFont, Brushes.Black, xPos, yPos)
            yPos += lineHeight
            yDetailStart = yPos
        End If

        e.HasMorePages = False

        If (currDetail.CheckClassList.Count + 12) * lineHeight >= (e.MarginBounds.Bottom - yPos) * 2 Then
            xPos = CSng(e.MarginBounds.Left / 2)
            colWidth = (e.MarginBounds.Right - xPos) / 3
        End If

        For i As Integer = chkListIndex To currDetail.CheckClassList.Count - 1
            e.Graphics.DrawString(String.Format("{0,4}", (i + 1)) + currDetail.CheckClassList(i).Text, rptBody.DefaultFont, Brushes.Black, xPos, yPos)
            yPos += lineHeight
            If yPos + lineHeight >= e.MarginBounds.Bottom Then
                If xPos + colWidth + colGutter >= e.MarginBounds.Right Then
                    e.HasMorePages = True
                    firstPass = False
                    chkListIndex = i
                    yDetailStart = e.MarginBounds.Top
                    Exit For
                Else
                    yPos = yDetailStart
                    xPos += colWidth
                End If
            End If
        Next

        If e.HasMorePages = False Then
            If yPos + (lineHeight * 12) >= e.MarginBounds.Bottom Then
                If xPos + colWidth > e.MarginBounds.Right Then
                    firstPass = False
                    e.HasMorePages = True
                Else
                    yPos = yDetailStart
                    xPos += colWidth
                End If
            End If
            yPos += lineHeight
            e.Graphics.DrawString("Currency", rptHeader.DefaultFont, Brushes.Black, xPos, yPos)
            yPos += lineHeight
            Dim dnm As CashType
            For Each dnm In [Enum].GetValues(GetType(CashType))
                If DrawDenomination(e, dnm, xPos, yPos) Then
                    yPos += lineHeight
                    If yPos >= e.MarginBounds.Bottom Then
                        If xPos + colWidth + colGutter > e.MarginBounds.Right Then
                            firstPass = False
                            e.HasMorePages = True
                        Else
                            yPos = yDetailStart
                            xPos += colWidth + colGutter
                        End If
                    End If
                End If
            Next
        End If


    End Sub

    Private Function DrawDenomination(ByRef e As System.Drawing.Printing.PrintPageEventArgs, ByVal denom As CashType, ByVal x As Single, ByVal y As Single) As Boolean
        Dim ct As Integer = currDetail.GetCashDenomCount(denom)
        Dim amt As Single = currDetail.GetCashDenomTotal(denom)
        If ct > 0 Then
            e.Graphics.DrawString(String.Format("{0,3}", ct) + " x " + String.Format("{0,-11}", [Enum].GetName(GetType(CashType), denom)) + "=" + String.Format("{0,10:C}", amt), rptBody.DefaultFont, Brushes.Black, x, y)
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub DrawSignatureBox(ByRef e As System.Drawing.Printing.PrintPageEventArgs, ByVal rect As RectangleF, ByVal colwidth As Single, ByVal lineHeight As Single)
        rect.Size = New SizeF(colwidth, lineHeight * 7)
        Dim Str As String = "Head Teller:" & vbCrLf & vbTab + "_____________________________" & vbCrLf _
            & "Teller:" & vbCrLf & vbTab & "_____________________________" & vbCrLf _
            & "Teller:" & vbCrLf & vbTab & "_____________________________"
        DrawTextbox(e, Str, rptHeader.DefaultFont, Brushes.Black, rect, True)
    End Sub

    Public Overrides Sub UpdateData(ByVal NewEvent As mvcLibrary.mvcEventArgsBase)

    End Sub

End Class
