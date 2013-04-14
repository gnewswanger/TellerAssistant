<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCheckSearch
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
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtChecksCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lvSearchResults = New TellerAssistant2012.CheckListView()
        Me.CheckSearchPanel1 = New TellerAssistant2012.CheckSearchPanel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.toolBtnPrint = New System.Windows.Forms.ToolStripButton()
        Me.toolBtnExit = New System.Windows.Forms.ToolStripButton()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListStyleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExtraLargeIconToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewLargeIcon = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewList = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.labelCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolTip1
        '
        Me.ToolTip1.ShowAlways = True
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.BottomToolStripPanel
        '
        Me.ToolStripContainer1.BottomToolStripPanel.Controls.Add(Me.StatusStrip1)
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.lvSearchResults)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.CheckSearchPanel1)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.ToolStrip1)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.MenuStrip1)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(802, 585)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(802, 632)
        Me.ToolStripContainer1.TabIndex = 0
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.txtChecksCount, Me.labelCount})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 0)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(802, 22)
        Me.StatusStrip1.TabIndex = 0
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(44, 17)
        Me.ToolStripStatusLabel1.Text = "Found:"
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtChecksCount
        '
        Me.txtChecksCount.Name = "txtChecksCount"
        Me.txtChecksCount.Size = New System.Drawing.Size(0, 17)
        '
        'lvSearchResults
        '
        Me.lvSearchResults.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.lvSearchResults.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvSearchResults.Location = New System.Drawing.Point(0, 249)
        Me.lvSearchResults.Name = "lvSearchResults"
        Me.lvSearchResults.QueueIndex = -1
        Me.lvSearchResults.Size = New System.Drawing.Size(802, 336)
        Me.lvSearchResults.TabIndex = 13
        '
        'CheckSearchPanel1
        '
        Me.CheckSearchPanel1.BackColor = System.Drawing.Color.Transparent
        Me.CheckSearchPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.CheckSearchPanel1.Location = New System.Drawing.Point(0, 24)
        Me.CheckSearchPanel1.Name = "CheckSearchPanel1"
        Me.CheckSearchPanel1.Size = New System.Drawing.Size(802, 225)
        Me.CheckSearchPanel1.StartDate = New Date(2013, 1, 1, 0, 0, 0, 0)
        Me.CheckSearchPanel1.TabIndex = 14
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolBtnPrint, Me.toolBtnExit})
        Me.ToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.ToolStrip1.Location = New System.Drawing.Point(691, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(111, 25)
        Me.ToolStrip1.TabIndex = 10
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'toolBtnPrint
        '
        Me.toolBtnPrint.Image = Global.TellerAssistant2012.My.Resources.Resources.PrintHS
        Me.toolBtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolBtnPrint.Name = "toolBtnPrint"
        Me.toolBtnPrint.Size = New System.Drawing.Size(52, 22)
        Me.toolBtnPrint.Text = "Print"
        '
        'toolBtnExit
        '
        Me.toolBtnExit.Image = Global.TellerAssistant2012.My.Resources.Resources.Cancel_Red_24
        Me.toolBtnExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolBtnExit.Name = "toolBtnExit"
        Me.toolBtnExit.Size = New System.Drawing.Size(56, 22)
        Me.toolBtnExit.Text = "Close"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem, Me.ViewToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(802, 24)
        Me.MenuStrip1.TabIndex = 7
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPrint, Me.mnuExit})
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.ExitToolStripMenuItem.Text = "&File"
        '
        'mnuPrint
        '
        Me.mnuPrint.Image = Global.TellerAssistant2012.My.Resources.Resources.PrintHS
        Me.mnuPrint.Name = "mnuPrint"
        Me.mnuPrint.Size = New System.Drawing.Size(103, 22)
        Me.mnuPrint.Text = "&Print"
        '
        'mnuExit
        '
        Me.mnuExit.Image = Global.TellerAssistant2012.My.Resources.Resources.Cancel_Red_24
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.Size = New System.Drawing.Size(103, 22)
        Me.mnuExit.Text = "&Close"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ListStyleToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ViewToolStripMenuItem.Text = "&View"
        '
        'ListStyleToolStripMenuItem
        '
        Me.ListStyleToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExtraLargeIconToolStripMenuItem, Me.mnuViewLargeIcon, Me.mnuViewList})
        Me.ListStyleToolStripMenuItem.Name = "ListStyleToolStripMenuItem"
        Me.ListStyleToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.ListStyleToolStripMenuItem.Text = "List Style"
        '
        'ExtraLargeIconToolStripMenuItem
        '
        Me.ExtraLargeIconToolStripMenuItem.Name = "ExtraLargeIconToolStripMenuItem"
        Me.ExtraLargeIconToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.ExtraLargeIconToolStripMenuItem.Text = "Extra Large Icon"
        '
        'mnuViewLargeIcon
        '
        Me.mnuViewLargeIcon.Name = "mnuViewLargeIcon"
        Me.mnuViewLargeIcon.Size = New System.Drawing.Size(157, 22)
        Me.mnuViewLargeIcon.Tag = "Windows.Forms.View.LargeIcon"
        Me.mnuViewLargeIcon.Text = "Large Icon"
        '
        'mnuViewList
        '
        Me.mnuViewList.Name = "mnuViewList"
        Me.mnuViewList.Size = New System.Drawing.Size(157, 22)
        Me.mnuViewList.Text = "List"
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'labelCount
        '
        Me.labelCount.Name = "labelCount"
        Me.labelCount.Size = New System.Drawing.Size(121, 17)
        Me.labelCount.Text = "ToolStripStatusLabel2"
        '
        'FormCheckSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(802, 632)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "FormCheckSearch"
        Me.Text = "Check Search"
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.ContentPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)

End Sub
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents toolBtnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents lvSearchResults As TellerAssistant2012.CheckListView
    Friend WithEvents toolBtnPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListStyleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewLargeIcon As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewList As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExtraLargeIconToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtChecksCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents CheckSearchPanel1 As TellerAssistant2012.CheckSearchPanel
    Friend WithEvents labelCount As System.Windows.Forms.ToolStripStatusLabel
End Class
