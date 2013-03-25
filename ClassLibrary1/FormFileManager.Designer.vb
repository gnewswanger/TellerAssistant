<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFileManager
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.splitCntFrom = New System.Windows.Forms.SplitContainer
        Me.tvFromFolders = New System.Windows.Forms.TreeView
        Me.lvFromFiles = New System.Windows.Forms.ListView
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.splitCntTo = New System.Windows.Forms.SplitContainer
        Me.tvToFolders = New System.Windows.Forms.TreeView
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnMoveFiles = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.splitCntFrom.Panel1.SuspendLayout()
        Me.splitCntFrom.Panel2.SuspendLayout()
        Me.splitCntFrom.SuspendLayout()
        Me.splitCntTo.Panel1.SuspendLayout()
        Me.splitCntTo.Panel2.SuspendLayout()
        Me.splitCntTo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.SplitContainer1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.014028!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.98597!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(706, 499)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 38)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.splitCntFrom)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.splitCntTo)
        Me.SplitContainer1.Size = New System.Drawing.Size(700, 458)
        Me.SplitContainer1.SplitterDistance = 354
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 1
        '
        'splitCntFrom
        '
        Me.splitCntFrom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitCntFrom.Location = New System.Drawing.Point(0, 0)
        Me.splitCntFrom.Name = "splitCntFrom"
        Me.splitCntFrom.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitCntFrom.Panel1
        '
        Me.splitCntFrom.Panel1.Controls.Add(Me.tvFromFolders)
        '
        'splitCntFrom.Panel2
        '
        Me.splitCntFrom.Panel2.Controls.Add(Me.lvFromFiles)
        Me.splitCntFrom.Size = New System.Drawing.Size(354, 458)
        Me.splitCntFrom.SplitterDistance = 232
        Me.splitCntFrom.TabIndex = 0
        '
        'tvFromFolders
        '
        Me.tvFromFolders.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvFromFolders.HideSelection = False
        Me.tvFromFolders.Location = New System.Drawing.Point(0, 0)
        Me.tvFromFolders.Name = "tvFromFolders"
        Me.tvFromFolders.Size = New System.Drawing.Size(354, 232)
        Me.tvFromFolders.TabIndex = 1
        '
        'lvFromFiles
        '
        Me.lvFromFiles.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lvFromFiles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvFromFiles.Location = New System.Drawing.Point(0, 0)
        Me.lvFromFiles.Name = "lvFromFiles"
        Me.lvFromFiles.Size = New System.Drawing.Size(354, 222)
        Me.lvFromFiles.TabIndex = 1
        Me.lvFromFiles.UseCompatibleStateImageBehavior = False
        Me.lvFromFiles.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Name"
        Me.ColumnHeader3.Width = 200
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Date Modified"
        Me.ColumnHeader4.Width = 150
        '
        'splitCntTo
        '
        Me.splitCntTo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitCntTo.Location = New System.Drawing.Point(0, 0)
        Me.splitCntTo.Name = "splitCntTo"
        Me.splitCntTo.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitCntTo.Panel1
        '
        Me.splitCntTo.Panel1.Controls.Add(Me.tvToFolders)
        '
        'splitCntTo.Panel2
        '
        Me.splitCntTo.Panel2.Controls.Add(Me.Label1)
        Me.splitCntTo.Size = New System.Drawing.Size(341, 458)
        Me.splitCntTo.SplitterDistance = 365
        Me.splitCntTo.TabIndex = 0
        '
        'tvToFolders
        '
        Me.tvToFolders.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvToFolders.HideSelection = False
        Me.tvToFolders.Location = New System.Drawing.Point(0, 0)
        Me.tvToFolders.Name = "tvToFolders"
        Me.tvToFolders.Size = New System.Drawing.Size(341, 365)
        Me.tvToFolders.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(65, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Label1"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.btnMoveFiles)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(700, 29)
        Me.Panel1.TabIndex = 2
        '
        'btnMoveFiles
        '
        Me.btnMoveFiles.Location = New System.Drawing.Point(240, 3)
        Me.btnMoveFiles.Name = "btnMoveFiles"
        Me.btnMoveFiles.Size = New System.Drawing.Size(114, 23)
        Me.btnMoveFiles.TabIndex = 0
        Me.btnMoveFiles.Text = "Execute MOVE"
        Me.btnMoveFiles.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(372, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(272, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Destination: Choose Parent Directory to receive transfer."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(172, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Source: Choose Directory to move."
        '
        'FormFileManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(706, 499)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FormFileManager"
        Me.Text = "File Manager"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.splitCntFrom.Panel1.ResumeLayout(False)
        Me.splitCntFrom.Panel2.ResumeLayout(False)
        Me.splitCntFrom.ResumeLayout(False)
        Me.splitCntTo.Panel1.ResumeLayout(False)
        Me.splitCntTo.Panel2.ResumeLayout(False)
        Me.splitCntTo.Panel2.PerformLayout()
        Me.splitCntTo.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents splitCntFrom As System.Windows.Forms.SplitContainer
    Friend WithEvents tvFromFolders As System.Windows.Forms.TreeView
    Friend WithEvents lvFromFiles As System.Windows.Forms.ListView
    Friend WithEvents splitCntTo As System.Windows.Forms.SplitContainer
    Friend WithEvents tvToFolders As System.Windows.Forms.TreeView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnMoveFiles As System.Windows.Forms.Button
End Class
