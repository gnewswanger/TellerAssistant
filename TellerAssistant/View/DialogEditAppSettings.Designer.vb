<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogEditAppSettings
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
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip
        Me.toolBtnClose = New System.Windows.Forms.ToolStripButton
        Me.tpAppSettings = New System.Windows.Forms.TabPage
        Me.PropertyGrid1 = New System.Windows.Forms.PropertyGrid
        Me.tpScannerSettings = New System.Windows.Forms.TabPage
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.txtrchScannerSettings = New System.Windows.Forms.RichTextBox
        Me.tvScannerSettings = New System.Windows.Forms.TreeView
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.tpAppSettings.SuspendLayout()
        Me.tpScannerSettings.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.TabControl1)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(609, 327)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(634, 376)
        Me.ToolStripContainer1.TabIndex = 3
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.MenuStrip1)
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStrip2)
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(634, 24)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolBtnClose})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 24)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(68, 25)
        Me.ToolStrip2.TabIndex = 1
        '
        'toolBtnClose
        '
        Me.toolBtnClose.Image = Global.TellerAssistant2012.My.Resources.Resources.Cancel_Red_24
        Me.toolBtnClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolBtnClose.Name = "toolBtnClose"
        Me.toolBtnClose.Size = New System.Drawing.Size(56, 22)
        Me.toolBtnClose.Text = "Close"
        '
        'tpAppSettings
        '
        Me.tpAppSettings.Controls.Add(Me.PropertyGrid1)
        Me.tpAppSettings.Location = New System.Drawing.Point(4, 22)
        Me.tpAppSettings.Name = "tpAppSettings"
        Me.tpAppSettings.Padding = New System.Windows.Forms.Padding(3)
        Me.tpAppSettings.Size = New System.Drawing.Size(601, 301)
        Me.tpAppSettings.TabIndex = 2
        Me.tpAppSettings.Text = "Application Settings"
        Me.tpAppSettings.UseVisualStyleBackColor = True
        '
        'PropertyGrid1
        '
        Me.PropertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PropertyGrid1.Location = New System.Drawing.Point(3, 3)
        Me.PropertyGrid1.Name = "PropertyGrid1"
        Me.PropertyGrid1.Size = New System.Drawing.Size(595, 295)
        Me.PropertyGrid1.TabIndex = 0
        '
        'tpScannerSettings
        '
        Me.tpScannerSettings.Controls.Add(Me.SplitContainer1)
        Me.tpScannerSettings.Location = New System.Drawing.Point(4, 22)
        Me.tpScannerSettings.Name = "tpScannerSettings"
        Me.tpScannerSettings.Padding = New System.Windows.Forms.Padding(3)
        Me.tpScannerSettings.Size = New System.Drawing.Size(601, 301)
        Me.tpScannerSettings.TabIndex = 0
        Me.tpScannerSettings.Text = "Scanner Settings"
        Me.tpScannerSettings.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.tvScannerSettings)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtrchScannerSettings)
        Me.SplitContainer1.Size = New System.Drawing.Size(595, 295)
        Me.SplitContainer1.SplitterDistance = 282
        Me.SplitContainer1.TabIndex = 0
        '
        'txtrchScannerSettings
        '
        Me.txtrchScannerSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtrchScannerSettings.Location = New System.Drawing.Point(0, 0)
        Me.txtrchScannerSettings.Name = "txtrchScannerSettings"
        Me.txtrchScannerSettings.Size = New System.Drawing.Size(309, 295)
        Me.txtrchScannerSettings.TabIndex = 0
        Me.txtrchScannerSettings.Text = ""
        '
        'tvScannerSettings
        '
        Me.tvScannerSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvScannerSettings.Location = New System.Drawing.Point(0, 0)
        Me.tvScannerSettings.Name = "tvScannerSettings"
        Me.tvScannerSettings.Size = New System.Drawing.Size(282, 295)
        Me.tvScannerSettings.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tpScannerSettings)
        Me.TabControl1.Controls.Add(Me.tpAppSettings)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(609, 327)
        Me.TabControl1.TabIndex = 1
        '
        'dlgEditAppSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 376)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "dlgEditAppSettings"
        Me.Text = "Application Settings"
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.tpAppSettings.ResumeLayout(False)
        Me.tpScannerSettings.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents toolBtnClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpScannerSettings As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents tvScannerSettings As System.Windows.Forms.TreeView
    Friend WithEvents txtrchScannerSettings As System.Windows.Forms.RichTextBox
    Friend WithEvents tpAppSettings As System.Windows.Forms.TabPage
    Friend WithEvents PropertyGrid1 As System.Windows.Forms.PropertyGrid
End Class
