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
        Me.txtCheckNo.Location = New System.Drawing.Point(174, 171)
        Me.txtCheckNo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        '
        'Label36
        '
        Me.Label36.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        '
        'txtCheckAcct
        '
        Me.txtCheckAcct.Location = New System.Drawing.Point(174, 139)
        Me.txtCheckAcct.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        '
        'txtCheckBank
        '
        Me.txtCheckBank.Location = New System.Drawing.Point(174, 107)
        Me.txtCheckBank.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
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
        Me.txtCheckAmt.Location = New System.Drawing.Point(230, 64)
        Me.txtCheckAmt.Margin = New System.Windows.Forms.Padding(9, 12, 9, 12)
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(106, 31)
        Me.Label18.Margin = New System.Windows.Forms.Padding(9, 0, 9, 0)
        '
        'dtpCheckDate
        '
        Me.dtpCheckDate.Location = New System.Drawing.Point(230, 31)
        Me.dtpCheckDate.Margin = New System.Windows.Forms.Padding(9, 12, 9, 12)
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(106, 67)
        Me.Label19.Margin = New System.Windows.Forms.Padding(9, 0, 9, 0)
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
        '
        'CheckViewerEditPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Name = "CheckViewerEditPanel"
        Me.NavButtonsVisible = True
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

End Class
