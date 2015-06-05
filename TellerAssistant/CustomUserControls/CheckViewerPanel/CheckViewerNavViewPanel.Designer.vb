<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CheckViewerNavViewPanel
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
        Me.txtCheckAmt = New CalculatorClasses.CalculatorTextbox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.dtpCheckDate = New System.Windows.Forms.DateTimePicker()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.btnNavLast = New System.Windows.Forms.Button()
        Me.btnNavFirst = New System.Windows.Forms.Button()
        Me.btnCheckNext = New System.Windows.Forms.Button()
        Me.btnCheckPrev = New System.Windows.Forms.Button()
        Me.btnCheckReset = New System.Windows.Forms.Button()
        Me.btnCheckApply = New System.Windows.Forms.Button()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.ForeColor = System.Drawing.SystemColors.ControlText
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnNavLast)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnNavFirst)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtCheckAmt)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnCheckNext)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnCheckPrev)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnCheckReset)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnCheckApply)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label18)
        Me.SplitContainer1.Panel2.Controls.Add(Me.dtpCheckDate)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label19)
        Me.SplitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SplitContainer1.Panel2MinSize = 220
        Me.SplitContainer1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SplitContainer1.SplitterDistance = 524
        '
        'txtCheckAmt
        '
        Me.txtCheckAmt.AdvanceOnEnterKey = False
        Me.txtCheckAmt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCheckAmt.DecimalPlaces = 0
        Me.txtCheckAmt.FormatString = "$#,###,##0.00;($#,###,##0.00)"
        Me.txtCheckAmt.Location = New System.Drawing.Point(156, 45)
        Me.txtCheckAmt.Name = "txtCheckAmt"
        Me.txtCheckAmt.Size = New System.Drawing.Size(100, 20)
        Me.txtCheckAmt.TabIndex = 1
        Me.txtCheckAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(72, 22)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(67, 13)
        Me.Label18.TabIndex = 41
        Me.Label18.Text = "Check Date:"
        '
        'dtpCheckDate
        '
        Me.dtpCheckDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpCheckDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCheckDate.Location = New System.Drawing.Point(156, 19)
        Me.dtpCheckDate.Name = "dtpCheckDate"
        Me.dtpCheckDate.Size = New System.Drawing.Size(100, 20)
        Me.dtpCheckDate.TabIndex = 8
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(72, 45)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(80, 13)
        Me.Label19.TabIndex = 38
        Me.Label19.Text = "Check Amount:"
        '
        'btnNavLast
        '
        Me.btnNavLast.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNavLast.AutoEllipsis = True
        Me.btnNavLast.DialogResult = System.Windows.Forms.DialogResult.Yes
        Me.btnNavLast.Enabled = False
        Me.btnNavLast.Image = Global.TellerAssistant2012.My.Resources.Resources.DataContainer_MoveLastHS
        Me.btnNavLast.Location = New System.Drawing.Point(30, 203)
        Me.btnNavLast.Name = "btnNavLast"
        Me.btnNavLast.Size = New System.Drawing.Size(22, 37)
        Me.btnNavLast.TabIndex = 12
        Me.btnNavLast.TabStop = False
        Me.btnNavLast.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNavLast.UseVisualStyleBackColor = True
        '
        'btnNavFirst
        '
        Me.btnNavFirst.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNavFirst.AutoEllipsis = True
        Me.btnNavFirst.Enabled = False
        Me.btnNavFirst.Image = Global.TellerAssistant2012.My.Resources.Resources.DataContainer_MoveFirstHS
        Me.btnNavFirst.Location = New System.Drawing.Point(8, 203)
        Me.btnNavFirst.Name = "btnNavFirst"
        Me.btnNavFirst.Size = New System.Drawing.Size(22, 37)
        Me.btnNavFirst.TabIndex = 11
        Me.btnNavFirst.TabStop = False
        Me.btnNavFirst.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnNavFirst.UseVisualStyleBackColor = True
        '
        'btnCheckNext
        '
        Me.btnCheckNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCheckNext.Enabled = False
        Me.btnCheckNext.Image = Global.TellerAssistant2012.My.Resources.Resources.DataContainer_MoveNextHS
        Me.btnCheckNext.Location = New System.Drawing.Point(8, 121)
        Me.btnCheckNext.Name = "btnCheckNext"
        Me.btnCheckNext.Size = New System.Drawing.Size(44, 37)
        Me.btnCheckNext.TabIndex = 9
        Me.btnCheckNext.TabStop = False
        Me.btnCheckNext.Text = "Next"
        Me.btnCheckNext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnCheckNext.UseVisualStyleBackColor = True
        '
        'btnCheckPrev
        '
        Me.btnCheckPrev.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCheckPrev.Enabled = False
        Me.btnCheckPrev.Image = Global.TellerAssistant2012.My.Resources.Resources.DataContainer_MovePreviousHS
        Me.btnCheckPrev.Location = New System.Drawing.Point(8, 161)
        Me.btnCheckPrev.Name = "btnCheckPrev"
        Me.btnCheckPrev.Size = New System.Drawing.Size(44, 37)
        Me.btnCheckPrev.TabIndex = 10
        Me.btnCheckPrev.TabStop = False
        Me.btnCheckPrev.Text = "Prev"
        Me.btnCheckPrev.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnCheckPrev.UseVisualStyleBackColor = True
        '
        'btnCheckReset
        '
        Me.btnCheckReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCheckReset.Enabled = False
        Me.btnCheckReset.Image = Global.TellerAssistant2012.My.Resources.Resources.RestartHS
        Me.btnCheckReset.Location = New System.Drawing.Point(270, 299)
        Me.btnCheckReset.Name = "btnCheckReset"
        Me.btnCheckReset.Size = New System.Drawing.Size(75, 23)
        Me.btnCheckReset.TabIndex = 7
        Me.btnCheckReset.Text = "&Reset"
        Me.btnCheckReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCheckReset.UseVisualStyleBackColor = True
        '
        'btnCheckApply
        '
        Me.btnCheckApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCheckApply.Enabled = False
        Me.btnCheckApply.Image = Global.TellerAssistant2012.My.Resources.Resources.Check_OK
        Me.btnCheckApply.Location = New System.Drawing.Point(184, 299)
        Me.btnCheckApply.Name = "btnCheckApply"
        Me.btnCheckApply.Size = New System.Drawing.Size(75, 23)
        Me.btnCheckApply.TabIndex = 6
        Me.btnCheckApply.Text = "&Apply"
        Me.btnCheckApply.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCheckApply.UseVisualStyleBackColor = True
        '
        'CheckViewerNavViewPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "CheckViewerNavViewPanel"
        Me.SpliterDistance = 524
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnNavLast As System.Windows.Forms.Button
    Friend WithEvents btnNavFirst As System.Windows.Forms.Button
    Friend WithEvents btnCheckNext As System.Windows.Forms.Button
    Friend WithEvents btnCheckPrev As System.Windows.Forms.Button
    Protected Friend WithEvents txtCheckAmt As CalculatorClasses.CalculatorTextbox
    Protected Friend WithEvents Label18 As System.Windows.Forms.Label
    Protected Friend WithEvents dtpCheckDate As System.Windows.Forms.DateTimePicker
    Protected Friend WithEvents Label19 As System.Windows.Forms.Label
    Protected Friend WithEvents btnCheckReset As System.Windows.Forms.Button
    Protected Friend WithEvents btnCheckApply As System.Windows.Forms.Button

End Class
