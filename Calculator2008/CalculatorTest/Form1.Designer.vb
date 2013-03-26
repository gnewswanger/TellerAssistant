<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.CalculatorTextbox1 = New CalculatorClasses.CalculatorTextbox
        Me.CalculatorTextbox2 = New CalculatorClasses.CalculatorTextbox
        Me.SuspendLayout()
        '
        'CalculatorTextbox1
        '
        Me.CalculatorTextbox1.Location = New System.Drawing.Point(175, 95)
        Me.CalculatorTextbox1.Name = "CalculatorTextbox1"
        Me.CalculatorTextbox1.Size = New System.Drawing.Size(100, 20)
        Me.CalculatorTextbox1.TabIndex = 0
        '
        'CalculatorTextbox2
        '
        Me.CalculatorTextbox2.Location = New System.Drawing.Point(175, 151)
        Me.CalculatorTextbox2.Name = "CalculatorTextbox2"
        Me.CalculatorTextbox2.Size = New System.Drawing.Size(100, 20)
        Me.CalculatorTextbox2.TabIndex = 1
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(358, 298)
        Me.Controls.Add(Me.CalculatorTextbox2)
        Me.Controls.Add(Me.CalculatorTextbox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CalculatorTextbox1 As CalculatorClasses.CalculatorTextbox
    Friend WithEvents CalculatorTextbox2 As CalculatorClasses.CalculatorTextbox

End Class
