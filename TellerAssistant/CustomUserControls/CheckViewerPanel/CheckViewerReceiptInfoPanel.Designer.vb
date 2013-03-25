<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CheckViewerReceiptInfoPanel
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
    Private Shadows components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDonorAddr = New System.Windows.Forms.TextBox()
        Me.txtDonorCity = New System.Windows.Forms.TextBox()
        Me.txtDonorState = New System.Windows.Forms.TextBox()
        Me.txtDonorZip = New System.Windows.Forms.TextBox()
        Me.labelReceiptComplete = New System.Windows.Forms.Label()
        Me.txtDonorName = New System.Windows.Forms.TextBox()
        Me.txtDonorEnvelope = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCheckReset
        '
        Me.btnCheckReset.Enabled = True
        Me.btnCheckReset.Text = "&Cancel"
        '
        'btnCheckApply
        '
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Panel1MinSize = 250
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtDonorEnvelope)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtDonorCity)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtDonorAddr)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtDonorZip)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtDonorState)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel2.Controls.Add(Me.labelReceiptComplete)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtDonorName)
        Me.SplitContainer1.Panel2MinSize = 250
        Me.SplitContainer1.SplitterDistance = 500
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Donor:"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(52, 109)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 48
        Me.Label2.Text = "Address:"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(73, 130)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 13)
        Me.Label3.TabIndex = 49
        Me.Label3.Text = "City:"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(65, 151)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 50
        Me.Label4.Text = "State:"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(158, 151)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(25, 13)
        Me.Label5.TabIndex = 51
        Me.Label5.Text = "Zip:"
        '
        'txtDonorAddr
        '
        Me.txtDonorAddr.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.txtDonorAddr.Location = New System.Drawing.Point(106, 106)
        Me.txtDonorAddr.Name = "txtDonorAddr"
        Me.txtDonorAddr.Size = New System.Drawing.Size(171, 20)
        Me.txtDonorAddr.TabIndex = 1
        '
        'txtDonorCity
        '
        Me.txtDonorCity.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.txtDonorCity.Location = New System.Drawing.Point(106, 127)
        Me.txtDonorCity.Name = "txtDonorCity"
        Me.txtDonorCity.Size = New System.Drawing.Size(171, 20)
        Me.txtDonorCity.TabIndex = 2
        '
        'txtDonorState
        '
        Me.txtDonorState.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.txtDonorState.Location = New System.Drawing.Point(106, 148)
        Me.txtDonorState.Name = "txtDonorState"
        Me.txtDonorState.Size = New System.Drawing.Size(46, 20)
        Me.txtDonorState.TabIndex = 3
        '
        'txtDonorZip
        '
        Me.txtDonorZip.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.txtDonorZip.Location = New System.Drawing.Point(183, 148)
        Me.txtDonorZip.Name = "txtDonorZip"
        Me.txtDonorZip.Size = New System.Drawing.Size(94, 20)
        Me.txtDonorZip.TabIndex = 4
        '
        'labelReceiptComplete
        '
        Me.labelReceiptComplete.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.labelReceiptComplete.AutoSize = True
        Me.labelReceiptComplete.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelReceiptComplete.ForeColor = System.Drawing.Color.SpringGreen
        Me.labelReceiptComplete.Location = New System.Drawing.Point(73, 198)
        Me.labelReceiptComplete.Name = "labelReceiptComplete"
        Me.labelReceiptComplete.Size = New System.Drawing.Size(156, 18)
        Me.labelReceiptComplete.TabIndex = 62
        Me.labelReceiptComplete.Text = "Receipt Completed."
        Me.labelReceiptComplete.Visible = False
        '
        'txtDonorName
        '
        Me.txtDonorName.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.txtDonorName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDonorName.Location = New System.Drawing.Point(54, 79)
        Me.txtDonorName.Name = "txtDonorName"
        Me.txtDonorName.ReadOnly = True
        Me.txtDonorName.Size = New System.Drawing.Size(221, 20)
        Me.txtDonorName.TabIndex = 63
        '
        'txtDonorEnvelope
        '
        Me.txtDonorEnvelope.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.txtDonorEnvelope.Location = New System.Drawing.Point(136, 175)
        Me.txtDonorEnvelope.Name = "txtDonorEnvelope"
        Me.txtDonorEnvelope.Size = New System.Drawing.Size(141, 20)
        Me.txtDonorEnvelope.TabIndex = 64
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(65, 178)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 13)
        Me.Label6.TabIndex = 65
        Me.Label6.Text = "Envelope No:"
        '
        'CheckViewerReceiptInfoPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Name = "CheckViewerReceiptInfoPanel"
        Me.SpliterDistance = 500
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Protected Friend WithEvents txtDonorState As System.Windows.Forms.TextBox
    Protected Friend WithEvents txtDonorCity As System.Windows.Forms.TextBox
    Protected Friend WithEvents txtDonorAddr As System.Windows.Forms.TextBox
    Protected Friend WithEvents Label5 As System.Windows.Forms.Label
    Protected Friend WithEvents txtDonorZip As System.Windows.Forms.TextBox
    Protected Friend WithEvents labelReceiptComplete As System.Windows.Forms.Label
    Friend WithEvents txtDonorName As System.Windows.Forms.TextBox
    Protected Friend WithEvents txtDonorEnvelope As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label

End Class
