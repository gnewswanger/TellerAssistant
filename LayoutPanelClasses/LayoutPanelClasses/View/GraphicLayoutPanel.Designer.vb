<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GraphicLayoutPanel
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.Canvas = New System.Windows.Forms.Panel
        Me.SuspendLayout()
        '
        'Canvas
        '
        Me.Canvas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Canvas.Location = New System.Drawing.Point(0, 0)
        Me.Canvas.Name = "Canvas"
        Me.Canvas.Size = New System.Drawing.Size(379, 433)
        Me.Canvas.TabIndex = 0
        '
        'GraphicLayoutPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Canvas)
        Me.Name = "GraphicLayoutPanel"
        Me.Size = New System.Drawing.Size(379, 433)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Canvas As System.Windows.Forms.Panel

End Class
