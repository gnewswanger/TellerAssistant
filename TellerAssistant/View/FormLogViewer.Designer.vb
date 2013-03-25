<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLogViewer
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
        Me.btnClose = New System.Windows.Forms.Button
        Me.lvExceptionList = New System.Windows.Forms.ListView
        Me.colMessage = New System.Windows.Forms.ColumnHeader
        Me.colException = New System.Windows.Forms.ColumnHeader
        Me.colDetail = New System.Windows.Forms.ColumnHeader
        Me.colDateTime = New System.Windows.Forms.ColumnHeader
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearSelectedRecordsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(741, 493)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lvExceptionList
        '
        Me.lvExceptionList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvExceptionList.CheckBoxes = True
        Me.lvExceptionList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colMessage, Me.colException, Me.colDetail, Me.colDateTime})
        Me.lvExceptionList.FullRowSelect = True
        Me.lvExceptionList.GridLines = True
        Me.lvExceptionList.HideSelection = False
        Me.lvExceptionList.Location = New System.Drawing.Point(12, 27)
        Me.lvExceptionList.Name = "lvExceptionList"
        Me.lvExceptionList.Size = New System.Drawing.Size(801, 460)
        Me.lvExceptionList.TabIndex = 3
        Me.lvExceptionList.UseCompatibleStateImageBehavior = False
        Me.lvExceptionList.View = System.Windows.Forms.View.Details
        '
        'colMessage
        '
        Me.colMessage.Text = "Message:"
        Me.colMessage.Width = 190
        '
        'colException
        '
        Me.colException.Text = "Exception:"
        Me.colException.Width = 180
        '
        'colDetail
        '
        Me.colDetail.Text = "Detail"
        Me.colDetail.Width = 273
        '
        'colDateTime
        '
        Me.colDateTime.Text = "Date / Time:"
        Me.colDateTime.Width = 150
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(825, 24)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MenuToolStripMenuItem
        '
        Me.MenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearSelectedRecordsToolStripMenuItem, Me.CloseToolStripMenuItem})
        Me.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        Me.MenuToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.MenuToolStripMenuItem.Text = "Menu"
        '
        'ClearSelectedRecordsToolStripMenuItem
        '
        Me.ClearSelectedRecordsToolStripMenuItem.Name = "ClearSelectedRecordsToolStripMenuItem"
        Me.ClearSelectedRecordsToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.ClearSelectedRecordsToolStripMenuItem.Text = "Clear selected records"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.CloseToolStripMenuItem.Text = "&Close"
        '
        'FormLogViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(825, 528)
        Me.Controls.Add(Me.lvExceptionList)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormLogViewer"
        Me.Text = "Log Viewer"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lvExceptionList As System.Windows.Forms.ListView
    Friend WithEvents colMessage As System.Windows.Forms.ColumnHeader
    Friend WithEvents colException As System.Windows.Forms.ColumnHeader
    Friend WithEvents colDateTime As System.Windows.Forms.ColumnHeader
    Friend WithEvents colDetail As System.Windows.Forms.ColumnHeader
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearSelectedRecordsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
