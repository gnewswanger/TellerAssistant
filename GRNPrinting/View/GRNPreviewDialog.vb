Imports System.Drawing.Printing

''' <summary>
''' 
''' </summary>
''' <remarks></remarks>
Public Class GRNPreviewDialog

#Region "Public Class Properties"
    Public Property Document As PrintDocument
        Get
            Return Me.PrintPreviewControl1.Document
        End Get
        Set(value As PrintDocument)
            Me.PrintPreviewControl1.Document = value
        End Set
    End Property

    Public Property PageSetupVisible As Boolean

#End Region
    Private Sub btnToolPrint_Click(sender As Object, e As EventArgs) Handles btnToolPrint.Click
        Me.PrintDialog1.Document = Me.Document
        If Me.PrintDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.PrintDialog1.Document.Print()
        End If
        Me.Close()
    End Sub

    Private Sub btnToolPrintCancel_Click(sender As Object, e As EventArgs) Handles btnToolPrintCancel.Click
        Me.Close()
    End Sub

    Private Sub btnToolPrintSetup_Click(sender As Object, e As EventArgs) Handles btnToolPrintSetup.Click
        Me.PageSetupDialog1.Document = Me.Document
        Me.PageSetupDialog1.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        Me.PrintPreviewControl1.Zoom = 0.5
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        Me.PrintPreviewControl1.Zoom = 1.5
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Me.PrintPreviewControl1.Zoom = 1.0
    End Sub

    Private Sub BestFitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BestFitToolStripMenuItem.Click
        Me.PrintPreviewControl1.AutoZoom = True
    End Sub
End Class