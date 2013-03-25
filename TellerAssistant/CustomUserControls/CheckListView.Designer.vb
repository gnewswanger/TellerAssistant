<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CheckListView
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
        Me.lvCheckSearchQueue = New System.Windows.Forms.ListView
        Me.SuspendLayout()
        '
        'lvCheckSearchQueue
        '
        Me.lvCheckSearchQueue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvCheckSearchQueue.HideSelection = False
        Me.lvCheckSearchQueue.Location = New System.Drawing.Point(0, 0)
        Me.lvCheckSearchQueue.MultiSelect = False
        Me.lvCheckSearchQueue.Name = "lvCheckSearchQueue"
        Me.lvCheckSearchQueue.ShowGroups = False
        Me.lvCheckSearchQueue.ShowItemToolTips = True
        Me.lvCheckSearchQueue.Size = New System.Drawing.Size(400, 150)
        Me.lvCheckSearchQueue.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvCheckSearchQueue.TabIndex = 0
        Me.lvCheckSearchQueue.TileSize = New System.Drawing.Size(90, 50)
        Me.lvCheckSearchQueue.UseCompatibleStateImageBehavior = False
        '
        'CheckListView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.Controls.Add(Me.lvCheckSearchQueue)
        Me.Name = "CheckListView"
        Me.Size = New System.Drawing.Size(400, 150)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lvCheckSearchQueue As System.Windows.Forms.ListView

End Class
