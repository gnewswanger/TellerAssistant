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
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        '
        'Label33
        '
        Me.Label33.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        '
        'txtCheckNo
        '
        Me.txtCheckNo.Margin = New System.Windows.Forms.Padding(3, 3, 3, 3)
        '
        'Label36
        '
        Me.Label36.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        '
        'txtCheckAcct
        '
        Me.txtCheckAcct.Margin = New System.Windows.Forms.Padding(3, 3, 3, 3)
        '
        'txtCheckBank
        '
        Me.txtCheckBank.Margin = New System.Windows.Forms.Padding(3, 3, 3, 3)
        '
        'chkbxSendReceipt
        '
        Me.chkbxSendReceipt.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        '
        'Label37
        '
        Me.Label37.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        '
        'txtCheckAmt
        '
        Me.txtCheckAmt.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        '
        'Label18
        '
        Me.Label18.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        '
        'dtpCheckDate
        '
        Me.dtpCheckDate.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        '
        'Label19
        '
        Me.Label19.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        '
        'btnCheckReset
        '
        Me.btnCheckReset.Margin = New System.Windows.Forms.Padding(9, 12, 9, 12)
        '
        'btnCheckApply
        '
        Me.btnCheckApply.Margin = New System.Windows.Forms.Padding(9, 12, 9, 12)
        '
        'SplitContainer1
        '
        Me.SplitContainer1.SplitterDistance = 524
        '
        'CheckViewerEditPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "CheckViewerEditPanel"
        Me.NavButtonsVisible = True
        Me.SpliterDistance = 524
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

End Class
