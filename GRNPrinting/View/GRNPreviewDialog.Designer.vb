<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GRNPreviewDialog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GRNPreviewDialog))
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.PrintPreviewControl1 = New System.Windows.Forms.PrintPreviewControl()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnToolPrint = New System.Windows.Forms.ToolStripButton()
        Me.btnToolPrintSetup = New System.Windows.Forms.ToolStripButton()
        Me.btnToolZoom = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnToolPrintCancel = New System.Windows.Forms.ToolStripButton()
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.BestFitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.PrintPreviewControl1)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(779, 639)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(779, 664)
        Me.ToolStripContainer1.TabIndex = 0
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStrip1)
        '
        'PrintPreviewControl1
        '
        Me.PrintPreviewControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PrintPreviewControl1.Location = New System.Drawing.Point(0, 0)
        Me.PrintPreviewControl1.Name = "PrintPreviewControl1"
        Me.PrintPreviewControl1.Size = New System.Drawing.Size(779, 639)
        Me.PrintPreviewControl1.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnToolPrint, Me.btnToolPrintSetup, Me.btnToolZoom, Me.btnToolPrintCancel})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(252, 25)
        Me.ToolStrip1.TabIndex = 0
        '
        'btnToolPrint
        '
        Me.btnToolPrint.Image = CType(resources.GetObject("btnToolPrint.Image"), System.Drawing.Image)
        Me.btnToolPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnToolPrint.Name = "btnToolPrint"
        Me.btnToolPrint.Size = New System.Drawing.Size(52, 22)
        Me.btnToolPrint.Text = "Print"
        '
        'btnToolPrintSetup
        '
        Me.btnToolPrintSetup.Image = CType(resources.GetObject("btnToolPrintSetup.Image"), System.Drawing.Image)
        Me.btnToolPrintSetup.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnToolPrintSetup.Name = "btnToolPrintSetup"
        Me.btnToolPrintSetup.Size = New System.Drawing.Size(57, 22)
        Me.btnToolPrintSetup.Text = "Setup"
        '
        'btnToolZoom
        '
        Me.btnToolZoom.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BestFitToolStripMenuItem, Me.ToolStripMenuItem3, Me.ToolStripMenuItem2, Me.ToolStripMenuItem4})
        Me.btnToolZoom.Image = CType(resources.GetObject("btnToolZoom.Image"), System.Drawing.Image)
        Me.btnToolZoom.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnToolZoom.Name = "btnToolZoom"
        Me.btnToolZoom.Size = New System.Drawing.Size(68, 22)
        Me.btnToolZoom.Text = "Zoom"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(152, 22)
        Me.ToolStripMenuItem2.Text = "100%"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(152, 22)
        Me.ToolStripMenuItem3.Text = "150%"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(152, 22)
        Me.ToolStripMenuItem4.Text = "50%"
        '
        'btnToolPrintCancel
        '
        Me.btnToolPrintCancel.Image = CType(resources.GetObject("btnToolPrintCancel.Image"), System.Drawing.Image)
        Me.btnToolPrintCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnToolPrintCancel.Name = "btnToolPrintCancel"
        Me.btnToolPrintCancel.Size = New System.Drawing.Size(63, 22)
        Me.btnToolPrintCancel.Text = "Cancel"
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'BestFitToolStripMenuItem
        '
        Me.BestFitToolStripMenuItem.Name = "BestFitToolStripMenuItem"
        Me.BestFitToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.BestFitToolStripMenuItem.Text = "Best Fit"
        '
        'GRNPreviewDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(779, 664)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "GRNPreviewDialog"
        Me.Text = "Print Preview"
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents PrintPreviewControl1 As System.Windows.Forms.PrintPreviewControl
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnToolPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnToolPrintSetup As System.Windows.Forms.ToolStripButton
    Friend WithEvents PageSetupDialog1 As System.Windows.Forms.PageSetupDialog
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents btnToolZoom As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnToolPrintCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents BestFitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
