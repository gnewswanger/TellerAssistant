﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(4)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.picReceiptFlag)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtConfirmCheckAmt)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnEditCheck)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnSkipConfirm)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnConfirmCheck)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label21)
        Me.SplitContainer1.SplitterDistance = 850
        '
        'txtConfirmCheckAmt
        '
        Me.txtConfirmCheckAmt.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtConfirmCheckAmt.BackColor = System.Drawing.SystemColors.Info
        Me.txtConfirmCheckAmt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtConfirmCheckAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConfirmCheckAmt.Location = New System.Drawing.Point(18, 92)
        Me.txtConfirmCheckAmt.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.txtConfirmCheckAmt.Name = "txtConfirmCheckAmt"
        Me.txtConfirmCheckAmt.Size = New System.Drawing.Size(285, 64)
        Me.txtConfirmCheckAmt.TabIndex = 18
        Me.txtConfirmCheckAmt.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label21
        '
        Me.Label21.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(14, 59)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(118, 20)
        Me.Label21.TabIndex = 17
        Me.Label21.Text = "Check Amount:"
        '
        'picReceiptFlag
        '
        Me.picReceiptFlag.Image = Global.TellerAssistant2012.My.Resources.Resources._80_yellow_flag
        Me.picReceiptFlag.Location = New System.Drawing.Point(521, 124)
        Me.picReceiptFlag.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.picReceiptFlag.Name = "picReceiptFlag"
        Me.picReceiptFlag.Size = New System.Drawing.Size(33, 32)
        Me.picReceiptFlag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picReceiptFlag.TabIndex = 19
        Me.picReceiptFlag.TabStop = False
        Me.picReceiptFlag.Visible = False
        '
        'btnEditCheck
        '
        Me.btnEditCheck.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnEditCheck.Image = Global.TellerAssistant2012.My.Resources.Resources.EditInformationHS
        Me.btnEditCheck.Location = New System.Drawing.Point(127, 305)
        Me.btnEditCheck.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnEditCheck.Name = "btnEditCheck"
        Me.btnEditCheck.Size = New System.Drawing.Size(112, 42)
        Me.btnEditCheck.TabIndex = 16
        Me.btnEditCheck.Text = "&Edit"
        Me.btnEditCheck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEditCheck.UseVisualStyleBackColor = True
        '
        'btnSkipConfirm
        '
        Me.btnSkipConfirm.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnSkipConfirm.Image = Global.TellerAssistant2012.My.Resources.Resources.GreenRightArrow
        Me.btnSkipConfirm.Location = New System.Drawing.Point(186, 188)
        Me.btnSkipConfirm.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSkipConfirm.Name = "btnSkipConfirm"
        Me.btnSkipConfirm.Size = New System.Drawing.Size(99, 75)
        Me.btnSkipConfirm.TabIndex = 15
        Me.btnSkipConfirm.Text = "&Skip"
        Me.btnSkipConfirm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSkipConfirm.UseVisualStyleBackColor = True
        '
        'btnConfirmCheck
        '
        Me.btnConfirmCheck.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnConfirmCheck.Image = Global.TellerAssistant2012.My.Resources.Resources.Check_OK
        Me.btnConfirmCheck.Location = New System.Drawing.Point(30, 188)
        Me.btnConfirmCheck.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnConfirmCheck.Name = "btnConfirmCheck"
        Me.btnConfirmCheck.Size = New System.Drawing.Size(148, 75)
        Me.btnConfirmCheck.TabIndex = 14
        Me.btnConfirmCheck.Text = "&Confirm"
        Me.btnConfirmCheck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnConfirmCheck.UseVisualStyleBackColor = True
        '
        'CheckViewerConfirmPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.Name = "CheckViewerConfirmPanel"
        Me.SpliterDistance = 850
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
