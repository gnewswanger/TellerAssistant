<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TextPanelFlyout
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
        Me.txtTextFlyout = New System.Windows.Forms.RichTextBox
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AutoFlyoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.btnTextFlyoutClose = New System.Windows.Forms.Button
        Me.pnlTextFlyout1 = New System.Windows.Forms.Panel
        Me.pnlTextFlyout2 = New System.Windows.Forms.Panel
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.ContextMenuStrip1.SuspendLayout()
        Me.pnlTextFlyout1.SuspendLayout()
        Me.pnlTextFlyout2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtTextFlyout
        '
        Me.txtTextFlyout.BackColor = System.Drawing.SystemColors.Control
        Me.txtTextFlyout.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTextFlyout.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtTextFlyout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTextFlyout.Location = New System.Drawing.Point(0, 0)
        Me.txtTextFlyout.Name = "txtTextFlyout"
        Me.txtTextFlyout.ReadOnly = True
        Me.txtTextFlyout.Size = New System.Drawing.Size(6, 200)
        Me.txtTextFlyout.TabIndex = 0
        Me.txtTextFlyout.Text = ""
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AutoFlyoutToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(139, 26)
        '
        'AutoFlyoutToolStripMenuItem
        '
        Me.AutoFlyoutToolStripMenuItem.Checked = True
        Me.AutoFlyoutToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AutoFlyoutToolStripMenuItem.Name = "AutoFlyoutToolStripMenuItem"
        Me.AutoFlyoutToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.AutoFlyoutToolStripMenuItem.Text = "Auto FlyOut"
        '
        'btnTextFlyoutClose
        '
        Me.btnTextFlyoutClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTextFlyoutClose.BackColor = System.Drawing.Color.Firebrick
        Me.btnTextFlyoutClose.FlatAppearance.BorderSize = 0
        Me.btnTextFlyoutClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTextFlyoutClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTextFlyoutClose.ForeColor = System.Drawing.Color.White
        Me.btnTextFlyoutClose.Location = New System.Drawing.Point(-9, 0)
        Me.btnTextFlyoutClose.Margin = New System.Windows.Forms.Padding(0)
        Me.btnTextFlyoutClose.Name = "btnTextFlyoutClose"
        Me.btnTextFlyoutClose.Size = New System.Drawing.Size(15, 15)
        Me.btnTextFlyoutClose.TabIndex = 23
        Me.btnTextFlyoutClose.Text = "X"
        Me.btnTextFlyoutClose.UseVisualStyleBackColor = False
        '
        'pnlTextFlyout1
        '
        Me.pnlTextFlyout1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.pnlTextFlyout1.Controls.Add(Me.pnlTextFlyout2)
        Me.pnlTextFlyout1.Location = New System.Drawing.Point(3, 3)
        Me.pnlTextFlyout1.Name = "pnlTextFlyout1"
        Me.pnlTextFlyout1.Size = New System.Drawing.Size(6, 200)
        Me.pnlTextFlyout1.TabIndex = 24
        '
        'pnlTextFlyout2
        '
        Me.pnlTextFlyout2.Controls.Add(Me.btnTextFlyoutClose)
        Me.pnlTextFlyout2.Controls.Add(Me.txtTextFlyout)
        Me.pnlTextFlyout2.Controls.Add(Me.ShapeContainer1)
        Me.pnlTextFlyout2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTextFlyout2.Location = New System.Drawing.Point(0, 0)
        Me.pnlTextFlyout2.Name = "pnlTextFlyout2"
        Me.pnlTextFlyout2.Size = New System.Drawing.Size(6, 200)
        Me.pnlTextFlyout2.TabIndex = 0
        Me.pnlTextFlyout2.TabStop = True
        Me.pnlTextFlyout2.Visible = False
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(6, 200)
        Me.ShapeContainer1.TabIndex = 24
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 3
        Me.LineShape1.X2 = 3
        Me.LineShape1.Y1 = 143
        Me.LineShape1.Y2 = 15
        '
        'TextPanelFlyout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Controls.Add(Me.pnlTextFlyout1)
        Me.Name = "TextPanelFlyout"
        Me.Size = New System.Drawing.Size(12, 206)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.pnlTextFlyout1.ResumeLayout(False)
        Me.pnlTextFlyout2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtTextFlyout As System.Windows.Forms.RichTextBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AutoFlyoutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnTextFlyoutClose As System.Windows.Forms.Button
    Friend WithEvents pnlTextFlyout1 As System.Windows.Forms.Panel
    Friend WithEvents pnlTextFlyout2 As System.Windows.Forms.Panel
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape

End Class
