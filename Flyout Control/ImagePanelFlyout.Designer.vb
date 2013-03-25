<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImagePanelFlyout
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
        Me.components = New System.ComponentModel.Container
        Me.pnlImageFlyout1 = New System.Windows.Forms.Panel
        Me.pnlPictureContainer = New System.Windows.Forms.Panel
        Me.btnTextFlyoutClose = New System.Windows.Forms.Button
        Me.ImageViewerPanel1 = New ImageViewerPanel.ImageViewerPanel
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AutoFlyoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.pnlImageFlyout1.SuspendLayout()
        Me.pnlPictureContainer.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlImageFlyout1
        '
        Me.pnlImageFlyout1.BackColor = System.Drawing.SystemColors.Control
        Me.pnlImageFlyout1.Controls.Add(Me.pnlPictureContainer)
        Me.pnlImageFlyout1.Location = New System.Drawing.Point(3, 3)
        Me.pnlImageFlyout1.Name = "pnlImageFlyout1"
        Me.pnlImageFlyout1.Size = New System.Drawing.Size(12, 100)
        Me.pnlImageFlyout1.TabIndex = 0
        '
        'pnlPictureContainer
        '
        Me.pnlPictureContainer.Controls.Add(Me.btnTextFlyoutClose)
        Me.pnlPictureContainer.Controls.Add(Me.ImageViewerPanel1)
        Me.pnlPictureContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPictureContainer.Location = New System.Drawing.Point(0, 0)
        Me.pnlPictureContainer.Name = "pnlPictureContainer"
        Me.pnlPictureContainer.Size = New System.Drawing.Size(12, 100)
        Me.pnlPictureContainer.TabIndex = 0
        Me.pnlPictureContainer.Visible = False
        '
        'btnTextFlyoutClose
        '
        Me.btnTextFlyoutClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTextFlyoutClose.AutoSize = True
        Me.btnTextFlyoutClose.BackColor = System.Drawing.Color.Firebrick
        Me.btnTextFlyoutClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnTextFlyoutClose.FlatAppearance.BorderSize = 0
        Me.btnTextFlyoutClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTextFlyoutClose.ForeColor = System.Drawing.Color.White
        Me.btnTextFlyoutClose.Location = New System.Drawing.Point(-13, 0)
        Me.btnTextFlyoutClose.Margin = New System.Windows.Forms.Padding(0)
        Me.btnTextFlyoutClose.Name = "btnTextFlyoutClose"
        Me.btnTextFlyoutClose.Size = New System.Drawing.Size(25, 23)
        Me.btnTextFlyoutClose.TabIndex = 24
        Me.btnTextFlyoutClose.Text = "X"
        Me.btnTextFlyoutClose.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnTextFlyoutClose.UseVisualStyleBackColor = False
        '
        'ImageViewerPanel1
        '
        Me.ImageViewerPanel1.BackColor = System.Drawing.SystemColors.Control
        Me.ImageViewerPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImageViewerPanel1.Image = Nothing
        Me.ImageViewerPanel1.Location = New System.Drawing.Point(0, 0)
        Me.ImageViewerPanel1.Name = "ImageViewerPanel1"
        Me.ImageViewerPanel1.Size = New System.Drawing.Size(12, 100)
        Me.ImageViewerPanel1.TabIndex = 25
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AutoFlyoutToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(153, 48)
        '
        'AutoFlyoutToolStripMenuItem
        '
        Me.AutoFlyoutToolStripMenuItem.Checked = True
        Me.AutoFlyoutToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AutoFlyoutToolStripMenuItem.Name = "AutoFlyoutToolStripMenuItem"
        Me.AutoFlyoutToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AutoFlyoutToolStripMenuItem.Text = "Auto FlyOut"
        '
        'Timer1
        '
        Me.Timer1.Interval = 3000
        '
        'ImagePanelFlyout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.Controls.Add(Me.pnlImageFlyout1)
        Me.Name = "ImagePanelFlyout"
        Me.Size = New System.Drawing.Size(18, 106)
        Me.pnlImageFlyout1.ResumeLayout(False)
        Me.pnlPictureContainer.ResumeLayout(False)
        Me.pnlPictureContainer.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlImageFlyout1 As System.Windows.Forms.Panel
    Friend WithEvents pnlPictureContainer As System.Windows.Forms.Panel
    Friend WithEvents btnTextFlyoutClose As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AutoFlyoutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ImageViewerPanel1 As ImageViewerPanel.ImageViewerPanel

End Class
