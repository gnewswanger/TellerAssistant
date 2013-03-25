<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDonorInformation
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer
        Me.CheckViewerReceiptInfoPanel1 = New TellerAssistant2012.CheckViewerReceiptInfoPanel
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.CheckViewerReceiptInfoPanel1)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(813, 268)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(813, 293)
        Me.ToolStripContainer1.TabIndex = 0
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'CheckViewerReceiptInfoPanel1
        '
        Me.CheckViewerReceiptInfoPanel1.ApplyonEntryKey = False
        Me.CheckViewerReceiptInfoPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckViewerReceiptInfoPanel1.Location = New System.Drawing.Point(0, 0)
        Me.CheckViewerReceiptInfoPanel1.Name = "CheckViewerReceiptInfoPanel1"
        Me.CheckViewerReceiptInfoPanel1.NavButtonsVisible = False
        Me.CheckViewerReceiptInfoPanel1.OkButtonLabel = "&Apply"
        Me.CheckViewerReceiptInfoPanel1.Size = New System.Drawing.Size(813, 268)
        Me.CheckViewerReceiptInfoPanel1.SpliterDistance = 508
        Me.CheckViewerReceiptInfoPanel1.TabIndex = 0
        '
        'FormDonorInformation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(813, 293)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "FormDonorInformation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Donor Information"
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents CheckViewerReceiptInfoPanel1 As TellerAssistant2012.CheckViewerReceiptInfoPanel
End Class
