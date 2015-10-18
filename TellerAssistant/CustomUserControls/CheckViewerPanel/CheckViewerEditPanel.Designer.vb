<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CheckViewerEditPanel
    Inherits TellerAssistant2012.CheckViewerViewPanel

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
    Private Shadows components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(77, 138)
        '
        'Label33
        '
        Me.Label33.Location = New System.Drawing.Point(64, 117)
        '
        'Label36
        '
        Me.Label36.Location = New System.Drawing.Point(72, 97)
        '
        'Label37
        '
        Me.Label37.Location = New System.Drawing.Point(87, 77)
        '
        'chkbxSendReceipt
        '
        Me.chkbxSendReceipt.Location = New System.Drawing.Point(126, 182)
        '
        'SplitContainer1
        '
        Me.SplitContainer1.SplitterDistance = 513
        '
        'CheckViewerEditPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Name = "CheckViewerEditPanel"
        Me.NavButtonsVisible = True
        Me.SpliterDistance = 513
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

End Class
