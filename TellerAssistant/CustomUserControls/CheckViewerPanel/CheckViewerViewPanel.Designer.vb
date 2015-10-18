<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CheckViewerViewPanel
    Inherits TellerAssistant2012.CheckViewerNavViewPanel

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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtCheckNo = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.txtCheckAcct = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.txtCheckBank = New System.Windows.Forms.TextBox()
        Me.chkbxSendReceipt = New System.Windows.Forms.CheckBox()
        Me.comboDonor = New System.Windows.Forms.ComboBox()
        Me.btnEditDonor = New System.Windows.Forms.Button()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtpCheckDate
        '
        Me.dtpCheckDate.TabIndex = 14
        '
        'btnCheckReset
        '
        Me.btnCheckReset.TabIndex = 13
        '
        'btnCheckApply
        '
        Me.btnCheckApply.TabIndex = 8
        '
        'SplitContainer1
        '
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnEditDonor)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtCheckNo)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label33)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label36)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtCheckAcct)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label37)
        Me.SplitContainer1.Panel2.Controls.Add(Me.comboDonor)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtCheckBank)
        Me.SplitContainer1.Panel2.Controls.Add(Me.chkbxSendReceipt)
        Me.SplitContainer1.SplitterDistance = 500
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(78, 137)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "Donnor:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label33
        '
        Me.Label33.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(65, 116)
        Me.Label33.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(58, 13)
        Me.Label33.TabIndex = 49
        Me.Label33.Text = "Check No:"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtCheckNo
        '
        Me.txtCheckNo.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.txtCheckNo.Location = New System.Drawing.Point(122, 113)
        Me.txtCheckNo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCheckNo.Name = "txtCheckNo"
        Me.txtCheckNo.Size = New System.Drawing.Size(137, 20)
        Me.txtCheckNo.TabIndex = 4
        '
        'Label36
        '
        Me.Label36.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(73, 96)
        Me.Label36.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(50, 13)
        Me.Label36.TabIndex = 48
        Me.Label36.Text = "Account:"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtCheckAcct
        '
        Me.txtCheckAcct.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.txtCheckAcct.Location = New System.Drawing.Point(122, 93)
        Me.txtCheckAcct.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCheckAcct.Name = "txtCheckAcct"
        Me.txtCheckAcct.Size = New System.Drawing.Size(137, 20)
        Me.txtCheckAcct.TabIndex = 3
        '
        'Label37
        '
        Me.Label37.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(88, 76)
        Me.Label37.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(35, 13)
        Me.Label37.TabIndex = 47
        Me.Label37.Text = "Bank:"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtCheckBank
        '
        Me.txtCheckBank.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.txtCheckBank.Location = New System.Drawing.Point(122, 73)
        Me.txtCheckBank.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCheckBank.Name = "txtCheckBank"
        Me.txtCheckBank.Size = New System.Drawing.Size(137, 20)
        Me.txtCheckBank.TabIndex = 2
        '
        'chkbxSendReceipt
        '
        Me.chkbxSendReceipt.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.chkbxSendReceipt.AutoSize = True
        Me.chkbxSendReceipt.Location = New System.Drawing.Point(136, 185)
        Me.chkbxSendReceipt.Name = "chkbxSendReceipt"
        Me.chkbxSendReceipt.Size = New System.Drawing.Size(112, 17)
        Me.chkbxSendReceipt.TabIndex = 7
        Me.chkbxSendReceipt.Text = "Send Tax Receipt"
        Me.chkbxSendReceipt.UseVisualStyleBackColor = True
        '
        'comboDonor
        '
        Me.comboDonor.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.comboDonor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.comboDonor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.comboDonor.FormattingEnabled = True
        Me.comboDonor.Location = New System.Drawing.Point(122, 133)
        Me.comboDonor.Name = "comboDonor"
        Me.comboDonor.Size = New System.Drawing.Size(137, 21)
        Me.comboDonor.TabIndex = 5
        '
        'btnEditDonor
        '
        Me.btnEditDonor.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnEditDonor.Location = New System.Drawing.Point(122, 154)
        Me.btnEditDonor.Margin = New System.Windows.Forms.Padding(2)
        Me.btnEditDonor.Name = "btnEditDonor"
        Me.btnEditDonor.Size = New System.Drawing.Size(137, 23)
        Me.btnEditDonor.TabIndex = 6
        Me.btnEditDonor.Text = "Edit Donor Info"
        Me.btnEditDonor.UseVisualStyleBackColor = True
        '
        'CheckViewerViewPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Name = "CheckViewerViewPanel"
        Me.SpliterDistance = 500
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Protected Friend WithEvents btnEditDonor As System.Windows.Forms.Button
    Protected Friend WithEvents Label1 As System.Windows.Forms.Label
    Protected Friend WithEvents Label33 As System.Windows.Forms.Label
    Protected Friend WithEvents txtCheckNo As System.Windows.Forms.TextBox
    Protected Friend WithEvents Label36 As System.Windows.Forms.Label
    Protected Friend WithEvents txtCheckAcct As System.Windows.Forms.TextBox
    Protected Friend WithEvents Label37 As System.Windows.Forms.Label
    Protected Friend WithEvents txtCheckBank As System.Windows.Forms.TextBox
    Protected Friend WithEvents chkbxSendReceipt As System.Windows.Forms.CheckBox
    Protected Friend WithEvents comboDonor As System.Windows.Forms.ComboBox

End Class
