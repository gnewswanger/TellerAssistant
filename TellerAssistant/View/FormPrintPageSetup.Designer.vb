<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPrintPageSetup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPrintPageSetup))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.lblCanvasX = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblCanvasY = New System.Windows.Forms.ToolStripStatusLabel
        Me.GraphicLayoutPanel1 = New LayoutPanelClasses.GraphicLayoutPanel
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblCanvasX, Me.lblCanvasY})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 657)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(658, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblCanvasX
        '
        Me.lblCanvasX.Name = "lblCanvasX"
        Me.lblCanvasX.Size = New System.Drawing.Size(36, 17)
        Me.lblCanvasX.Text = "X Pos"
        '
        'lblCanvasY
        '
        Me.lblCanvasY.Name = "lblCanvasY"
        Me.lblCanvasY.Size = New System.Drawing.Size(36, 17)
        Me.lblCanvasY.Text = "Y Pos"
        '
        'GraphicLayoutPanel1
        '
        Me.GraphicLayoutPanel1.BackgroundBitmap = CType(resources.GetObject("GraphicLayoutPanel1.BackgroundBitmap"), System.Drawing.Bitmap)
        Me.GraphicLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GraphicLayoutPanel1.dx = 0
        Me.GraphicLayoutPanel1.dy = 0
        Me.GraphicLayoutPanel1.gridSize = 0
        Me.GraphicLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GraphicLayoutPanel1.Name = "GraphicLayoutPanel1"
        Me.GraphicLayoutPanel1.Size = New System.Drawing.Size(658, 657)
        Me.GraphicLayoutPanel1.TabIndex = 2
        Me.GraphicLayoutPanel1.Zoom = 1.0!
        '
        'FormPrintPageSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(658, 679)
        Me.Controls.Add(Me.GraphicLayoutPanel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "FormPrintPageSetup"
        Me.Text = "frmPrintPageSetup"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblCanvasX As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblCanvasY As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GraphicLayoutPanel1 As LayoutPanelClasses.GraphicLayoutPanel
End Class
