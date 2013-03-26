<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KeypadClass
    Inherits System.Windows.Forms.UserControl

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
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnC = New System.Windows.Forms.Button
        Me.txtNumber = New System.Windows.Forms.TextBox
        Me.btnCE = New System.Windows.Forms.Button
        Me.btnShiftLeft = New System.Windows.Forms.Button
        Me.btnPercent = New System.Windows.Forms.Button
        Me.btn7 = New System.Windows.Forms.Button
        Me.btn8 = New System.Windows.Forms.Button
        Me.btn9 = New System.Windows.Forms.Button
        Me.btnDivide = New System.Windows.Forms.Button
        Me.btn4 = New System.Windows.Forms.Button
        Me.btn5 = New System.Windows.Forms.Button
        Me.btn6 = New System.Windows.Forms.Button
        Me.btnTimes = New System.Windows.Forms.Button
        Me.btn1 = New System.Windows.Forms.Button
        Me.btn2 = New System.Windows.Forms.Button
        Me.btn3 = New System.Windows.Forms.Button
        Me.btnMinus = New System.Windows.Forms.Button
        Me.btn0 = New System.Windows.Forms.Button
        Me.btnDot = New System.Windows.Forms.Button
        Me.btnPlus = New System.Windows.Forms.Button
        Me.btnEquals = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnC
        '
        Me.btnC.Location = New System.Drawing.Point(0, 20)
        Me.btnC.Name = "btnC"
        Me.btnC.Size = New System.Drawing.Size(24, 24)
        Me.btnC.TabIndex = 0
        Me.btnC.TabStop = False
        Me.btnC.Text = "C"
        Me.btnC.UseVisualStyleBackColor = True
        '
        'txtNumber
        '
        Me.txtNumber.BackColor = System.Drawing.Color.Black
        Me.txtNumber.CausesValidation = False
        Me.txtNumber.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.txtNumber.Location = New System.Drawing.Point(0, 0)
        Me.txtNumber.MaxLength = 15
        Me.txtNumber.Name = "txtNumber"
        Me.txtNumber.ReadOnly = True
        Me.txtNumber.Size = New System.Drawing.Size(96, 20)
        Me.txtNumber.TabIndex = 1
        Me.txtNumber.TabStop = False
        Me.txtNumber.Text = "000.00"
        Me.txtNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnCE
        '
        Me.btnCE.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnCE.Location = New System.Drawing.Point(24, 20)
        Me.btnCE.Name = "btnCE"
        Me.btnCE.Size = New System.Drawing.Size(24, 24)
        Me.btnCE.TabIndex = 2
        Me.btnCE.TabStop = False
        Me.btnCE.Text = "CE"
        Me.btnCE.UseVisualStyleBackColor = True
        '
        'btnShiftLeft
        '
        Me.btnShiftLeft.Location = New System.Drawing.Point(48, 20)
        Me.btnShiftLeft.Name = "btnShiftLeft"
        Me.btnShiftLeft.Size = New System.Drawing.Size(24, 24)
        Me.btnShiftLeft.TabIndex = 3
        Me.btnShiftLeft.TabStop = False
        Me.btnShiftLeft.Text = "<"
        Me.btnShiftLeft.UseVisualStyleBackColor = True
        '
        'btnPercent
        '
        Me.btnPercent.Location = New System.Drawing.Point(72, 20)
        Me.btnPercent.Name = "btnPercent"
        Me.btnPercent.Size = New System.Drawing.Size(24, 24)
        Me.btnPercent.TabIndex = 4
        Me.btnPercent.TabStop = False
        Me.btnPercent.Text = "%"
        Me.btnPercent.UseVisualStyleBackColor = True
        '
        'btn7
        '
        Me.btn7.Location = New System.Drawing.Point(0, 44)
        Me.btn7.Name = "btn7"
        Me.btn7.Size = New System.Drawing.Size(24, 24)
        Me.btn7.TabIndex = 5
        Me.btn7.TabStop = False
        Me.btn7.Text = "7"
        Me.btn7.UseVisualStyleBackColor = True
        '
        'btn8
        '
        Me.btn8.Location = New System.Drawing.Point(24, 44)
        Me.btn8.Name = "btn8"
        Me.btn8.Size = New System.Drawing.Size(24, 24)
        Me.btn8.TabIndex = 6
        Me.btn8.TabStop = False
        Me.btn8.Text = "8"
        Me.btn8.UseVisualStyleBackColor = True
        '
        'btn9
        '
        Me.btn9.Location = New System.Drawing.Point(48, 44)
        Me.btn9.Name = "btn9"
        Me.btn9.Size = New System.Drawing.Size(24, 24)
        Me.btn9.TabIndex = 7
        Me.btn9.TabStop = False
        Me.btn9.Text = "9"
        Me.btn9.UseVisualStyleBackColor = True
        '
        'btnDivide
        '
        Me.btnDivide.Location = New System.Drawing.Point(72, 44)
        Me.btnDivide.Name = "btnDivide"
        Me.btnDivide.Size = New System.Drawing.Size(24, 24)
        Me.btnDivide.TabIndex = 8
        Me.btnDivide.TabStop = False
        Me.btnDivide.Text = "/"
        Me.btnDivide.UseVisualStyleBackColor = True
        '
        'btn4
        '
        Me.btn4.Location = New System.Drawing.Point(0, 68)
        Me.btn4.Name = "btn4"
        Me.btn4.Size = New System.Drawing.Size(24, 24)
        Me.btn4.TabIndex = 9
        Me.btn4.TabStop = False
        Me.btn4.Text = "4"
        Me.btn4.UseVisualStyleBackColor = True
        '
        'btn5
        '
        Me.btn5.Location = New System.Drawing.Point(24, 68)
        Me.btn5.Name = "btn5"
        Me.btn5.Size = New System.Drawing.Size(24, 24)
        Me.btn5.TabIndex = 10
        Me.btn5.TabStop = False
        Me.btn5.Text = "5"
        Me.btn5.UseVisualStyleBackColor = True
        '
        'btn6
        '
        Me.btn6.Location = New System.Drawing.Point(48, 68)
        Me.btn6.Name = "btn6"
        Me.btn6.Size = New System.Drawing.Size(24, 24)
        Me.btn6.TabIndex = 11
        Me.btn6.TabStop = False
        Me.btn6.Text = "6"
        Me.btn6.UseVisualStyleBackColor = True
        '
        'btnTimes
        '
        Me.btnTimes.Location = New System.Drawing.Point(72, 68)
        Me.btnTimes.Name = "btnTimes"
        Me.btnTimes.Size = New System.Drawing.Size(24, 24)
        Me.btnTimes.TabIndex = 12
        Me.btnTimes.TabStop = False
        Me.btnTimes.Text = "X"
        Me.btnTimes.UseVisualStyleBackColor = True
        '
        'btn1
        '
        Me.btn1.Location = New System.Drawing.Point(0, 92)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(24, 24)
        Me.btn1.TabIndex = 13
        Me.btn1.TabStop = False
        Me.btn1.Text = "1"
        Me.btn1.UseVisualStyleBackColor = True
        '
        'btn2
        '
        Me.btn2.Location = New System.Drawing.Point(24, 92)
        Me.btn2.Name = "btn2"
        Me.btn2.Size = New System.Drawing.Size(24, 24)
        Me.btn2.TabIndex = 14
        Me.btn2.TabStop = False
        Me.btn2.Text = "2"
        Me.btn2.UseVisualStyleBackColor = True
        '
        'btn3
        '
        Me.btn3.Location = New System.Drawing.Point(48, 92)
        Me.btn3.Name = "btn3"
        Me.btn3.Size = New System.Drawing.Size(24, 24)
        Me.btn3.TabIndex = 15
        Me.btn3.TabStop = False
        Me.btn3.Text = "3"
        Me.btn3.UseVisualStyleBackColor = True
        '
        'btnMinus
        '
        Me.btnMinus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMinus.Location = New System.Drawing.Point(72, 92)
        Me.btnMinus.Name = "btnMinus"
        Me.btnMinus.Size = New System.Drawing.Size(24, 24)
        Me.btnMinus.TabIndex = 16
        Me.btnMinus.TabStop = False
        Me.btnMinus.Text = "-"
        Me.btnMinus.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnMinus.UseVisualStyleBackColor = True
        '
        'btn0
        '
        Me.btn0.Location = New System.Drawing.Point(0, 116)
        Me.btn0.Name = "btn0"
        Me.btn0.Size = New System.Drawing.Size(48, 24)
        Me.btn0.TabIndex = 17
        Me.btn0.TabStop = False
        Me.btn0.Text = "0"
        Me.btn0.UseVisualStyleBackColor = True
        '
        'btnDot
        '
        Me.btnDot.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDot.Location = New System.Drawing.Point(48, 116)
        Me.btnDot.Name = "btnDot"
        Me.btnDot.Size = New System.Drawing.Size(24, 24)
        Me.btnDot.TabIndex = 18
        Me.btnDot.TabStop = False
        Me.btnDot.Text = "."
        Me.btnDot.UseVisualStyleBackColor = True
        '
        'btnPlus
        '
        Me.btnPlus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPlus.Location = New System.Drawing.Point(72, 116)
        Me.btnPlus.Name = "btnPlus"
        Me.btnPlus.Size = New System.Drawing.Size(24, 24)
        Me.btnPlus.TabIndex = 19
        Me.btnPlus.TabStop = False
        Me.btnPlus.Text = "+"
        Me.btnPlus.UseVisualStyleBackColor = True
        '
        'btnEquals
        '
        Me.btnEquals.Location = New System.Drawing.Point(0, 140)
        Me.btnEquals.Name = "btnEquals"
        Me.btnEquals.Size = New System.Drawing.Size(94, 24)
        Me.btnEquals.TabIndex = 20
        Me.btnEquals.TabStop = False
        Me.btnEquals.Text = "=Enter"
        Me.btnEquals.UseVisualStyleBackColor = True
        '
        'KeypadClass
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.Controls.Add(Me.btnEquals)
        Me.Controls.Add(Me.btnPlus)
        Me.Controls.Add(Me.btnDot)
        Me.Controls.Add(Me.btn0)
        Me.Controls.Add(Me.btnMinus)
        Me.Controls.Add(Me.btn3)
        Me.Controls.Add(Me.btn2)
        Me.Controls.Add(Me.btn1)
        Me.Controls.Add(Me.btnTimes)
        Me.Controls.Add(Me.btn6)
        Me.Controls.Add(Me.btn5)
        Me.Controls.Add(Me.btn4)
        Me.Controls.Add(Me.btnDivide)
        Me.Controls.Add(Me.btn9)
        Me.Controls.Add(Me.btn8)
        Me.Controls.Add(Me.btn7)
        Me.Controls.Add(Me.btnPercent)
        Me.Controls.Add(Me.btnShiftLeft)
        Me.Controls.Add(Me.btnCE)
        Me.Controls.Add(Me.txtNumber)
        Me.Controls.Add(Me.btnC)
        Me.Name = "KeypadClass"
        Me.Size = New System.Drawing.Size(96, 164)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnC As System.Windows.Forms.Button
    Friend WithEvents txtNumber As System.Windows.Forms.TextBox
    Friend WithEvents btnCE As System.Windows.Forms.Button
    Friend WithEvents btnShiftLeft As System.Windows.Forms.Button
    Friend WithEvents btnPercent As System.Windows.Forms.Button
    Friend WithEvents btn7 As System.Windows.Forms.Button
    Friend WithEvents btn8 As System.Windows.Forms.Button
    Friend WithEvents btn9 As System.Windows.Forms.Button
    Friend WithEvents btnDivide As System.Windows.Forms.Button
    Friend WithEvents btn4 As System.Windows.Forms.Button
    Friend WithEvents btn5 As System.Windows.Forms.Button
    Friend WithEvents btn6 As System.Windows.Forms.Button
    Friend WithEvents btnTimes As System.Windows.Forms.Button
    Friend WithEvents btn1 As System.Windows.Forms.Button
    Friend WithEvents btn2 As System.Windows.Forms.Button
    Friend WithEvents btn3 As System.Windows.Forms.Button
    Friend WithEvents btnMinus As System.Windows.Forms.Button
    Friend WithEvents btn0 As System.Windows.Forms.Button
    Friend WithEvents btnDot As System.Windows.Forms.Button
    Friend WithEvents btnPlus As System.Windows.Forms.Button
    Friend WithEvents btnEquals As System.Windows.Forms.Button

End Class
