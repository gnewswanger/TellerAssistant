<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CheckViewerPanelBaseClass
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
    Friend components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.ImageViewerPanel1 = New ImageViewerPanel.ImageViewerPanel
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ImageViewerPanel1)
        Me.SplitContainer1.Panel1MinSize = 300
        Me.SplitContainer1.Panel2MinSize = 100
        Me.SplitContainer1.Size = New System.Drawing.Size(800, 255)
        Me.SplitContainer1.SplitterDistance = 525
        Me.SplitContainer1.TabIndex = 19
        '
        'ImageViewerPanel1
        '
        Me.ImageViewerPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImageViewerPanel1.Image = Nothing
        Me.ImageViewerPanel1.Location = New System.Drawing.Point(0, 0)
        Me.ImageViewerPanel1.Name = "ImageViewerPanel1"
        Me.ImageViewerPanel1.Size = New System.Drawing.Size(525, 255)
        Me.ImageViewerPanel1.TabIndex = 19
        '
        'CheckViewerPanelBaseClass
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "CheckViewerPanelBaseClass"
        Me.Size = New System.Drawing.Size(800, 255)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImageViewerPanel1 As ImageViewerPanel.ImageViewerPanel
    Protected Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer

End Class
