Imports LayoutPanelClasses

Public Class FormPrintPageSetup

    Private Sub GraphicLayoutPanel1_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) 'Handles GraphicLayoutPanel1.MouseWheel
        If e.Delta > 0 Then
            GraphicLayoutPanel1.zoomIn(1)
        Else
            GraphicLayoutPanel1.zoomOut(1)
        End If

    End Sub

    Private Sub InitializeCanvas()
        GraphicLayoutPanel1.AddRect("Currency", New Rectangle(0, 0, 250, 32))
        GraphicLayoutPanel1.AddRect("Coins", New Rectangle(25, 75, 250, 32))
        GraphicLayoutPanel1.AddRect("Checks", New Rectangle(25, 125, 250, 32))
        GraphicLayoutPanel1.AddRect("Total", New Rectangle(25, 175, 250, 32))
        GraphicLayoutPanel1.redraw(True)
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        GraphicLayoutPanel1.BackgroundBitmap = [Image].FromHbitmap(My.Resources.Deposit_Slip.GetHbitmap)
        ' Add any initialization after the InitializeComponent() call.
        InitializeCanvas()
    End Sub

    Private Sub FormPrintPageSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class