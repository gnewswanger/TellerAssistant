<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImageViewerPanel
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
        Me.pnlPicsBox = New System.Windows.Forms.Panel
        Me.picsBox = New System.Windows.Forms.PictureBox
        Me.pnlPicsBox.SuspendLayout()
        CType(Me.picsBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlPicsBox
        '
        Me.pnlPicsBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlPicsBox.BackColor = System.Drawing.Color.LightGray
        Me.pnlPicsBox.Controls.Add(Me.picsBox)
        Me.pnlPicsBox.Location = New System.Drawing.Point(0, 0)
        Me.pnlPicsBox.Name = "pnlPicsBox"
        Me.pnlPicsBox.Size = New System.Drawing.Size(457, 190)
        Me.pnlPicsBox.TabIndex = 9
        '
        'picsBox
        '
        Me.picsBox.Location = New System.Drawing.Point(3, 5)
        Me.picsBox.Name = "picsBox"
        Me.picsBox.Size = New System.Drawing.Size(450, 180)
        Me.picsBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picsBox.TabIndex = 0
        Me.picsBox.TabStop = False
        '
        'ImageViewerPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlPicsBox)
        Me.Name = "ImageViewerPanel"
        Me.Size = New System.Drawing.Size(460, 190)
        Me.pnlPicsBox.ResumeLayout(False)
        CType(Me.picsBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlPicsBox As System.Windows.Forms.Panel
    Friend WithEvents picsBox As System.Windows.Forms.PictureBox

End Class
