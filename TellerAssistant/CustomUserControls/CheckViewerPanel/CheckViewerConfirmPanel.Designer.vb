<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CheckViewerConfirmPanel
    Inherits TellerAssistant2012.CheckViewerPanelBaseClass

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
        Me.txtConfirmCheckAmt = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.picReceiptFlag = New System.Windows.Forms.PictureBox()
        Me.btnEditCheck = New System.Windows.Forms.Button()
        Me.btnSkipConfirm = New System.Windows.Forms.Button()
        Me.btnConfirmCheck = New System.Windows.Forms.Button()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.picReceiptFlag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.picReceiptFlag)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtConfirmCheckAmt)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnEditCheck)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnSkipConfirm)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnConfirmCheck)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label21)
        Me.SplitContainer1.SplitterDistance = 550
        '
        'txtConfirmCheckAmt
        '
        Me.txtConfirmCheckAmt.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.txtConfirmCheckAmt.BackColor = System.Drawing.SystemColors.Info
        Me.txtConfirmCheckAmt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtConfirmCheckAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConfirmCheckAmt.Location = New System.Drawing.Point(50, 45)
        Me.txtConfirmCheckAmt.Name = "txtConfirmCheckAmt"
        Me.txtConfirmCheckAmt.Size = New System.Drawing.Size(175, 33)
        Me.txtConfirmCheckAmt.TabIndex = 18
        Me.txtConfirmCheckAmt.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label21
        '
        Me.Label21.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(44, 32)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(80, 13)
        Me.Label21.TabIndex = 17
        Me.Label21.Text = "Check Amount:"
        '
        'picReceiptFlag
        '
        Me.picReceiptFlag.Image = Global.TellerAssistant2012.My.Resources.Resources._80_yellow_flag
        Me.picReceiptFlag.Location = New System.Drawing.Point(210, 21)
        Me.picReceiptFlag.Name = "picReceiptFlag"
        Me.picReceiptFlag.Size = New System.Drawing.Size(22, 21)
        Me.picReceiptFlag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picReceiptFlag.TabIndex = 19
        Me.picReceiptFlag.TabStop = False
        Me.picReceiptFlag.Visible = False
        '
        'btnEditCheck
        '
        Me.btnEditCheck.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditCheck.Image = Global.TellerAssistant2012.My.Resources.Resources.EditInformationHS
        Me.btnEditCheck.Location = New System.Drawing.Point(115, 201)
        Me.btnEditCheck.Name = "btnEditCheck"
        Me.btnEditCheck.Size = New System.Drawing.Size(75, 27)
        Me.btnEditCheck.TabIndex = 16
        Me.btnEditCheck.Text = "&Edit"
        Me.btnEditCheck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEditCheck.UseVisualStyleBackColor = True
        '
        'btnSkipConfirm
        '
        Me.btnSkipConfirm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSkipConfirm.Image = Global.TellerAssistant2012.My.Resources.Resources.GreenRightArrow
        Me.btnSkipConfirm.Location = New System.Drawing.Point(154, 144)
        Me.btnSkipConfirm.Name = "btnSkipConfirm"
        Me.btnSkipConfirm.Size = New System.Drawing.Size(66, 49)
        Me.btnSkipConfirm.TabIndex = 15
        Me.btnSkipConfirm.Text = "&Skip"
        Me.btnSkipConfirm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSkipConfirm.UseVisualStyleBackColor = True
        '
        'btnConfirmCheck
        '
        Me.btnConfirmCheck.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConfirmCheck.Image = Global.TellerAssistant2012.My.Resources.Resources.Check_OK
        Me.btnConfirmCheck.Location = New System.Drawing.Point(47, 144)
        Me.btnConfirmCheck.Name = "btnConfirmCheck"
        Me.btnConfirmCheck.Size = New System.Drawing.Size(99, 49)
        Me.btnConfirmCheck.TabIndex = 14
        Me.btnConfirmCheck.Text = "&Confirm"
        Me.btnConfirmCheck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnConfirmCheck.UseVisualStyleBackColor = True
        '
        'CheckViewerConfirmPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Name = "CheckViewerConfirmPanel"
        Me.SpliterDistance = 550
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.picReceiptFlag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtConfirmCheckAmt As System.Windows.Forms.Label
    Friend WithEvents btnEditCheck As System.Windows.Forms.Button
    Friend WithEvents btnSkipConfirm As System.Windows.Forms.Button
    Friend WithEvents btnConfirmCheck As System.Windows.Forms.Button
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents picReceiptFlag As System.Windows.Forms.PictureBox

End Class
