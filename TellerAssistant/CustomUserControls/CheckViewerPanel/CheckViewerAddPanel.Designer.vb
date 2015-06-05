<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CheckViewerAddPanel
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
    Friend Shadows components As System.ComponentModel.IContainer

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
        'txtCheckNo
        '
        Me.txtCheckNo.Margin = New System.Windows.Forms.Padding(3, 3, 3, 3)
        '
        'txtCheckAcct
        '
        Me.txtCheckAcct.Margin = New System.Windows.Forms.Padding(3, 3, 3, 3)
        '
        'txtCheckBank
        '
        Me.txtCheckBank.Margin = New System.Windows.Forms.Padding(3, 3, 3, 3)
        '
        'txtCheckAmt
        '
        Me.txtCheckAmt.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        '
        'btnCheckReset
        '
        Me.btnCheckReset.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        '
        'btnCheckApply
        '
        Me.btnCheckApply.Margin = New System.Windows.Forms.Padding(3, 3, 3, 3)
        '
        'SplitContainer1
        '
        Me.SplitContainer1.SplitterDistance = 524
        '
        'CheckViewerAddPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Name = "CheckViewerAddPanel"
        Me.SpliterDistance = 524
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

End Class
