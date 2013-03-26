Imports System.ComponentModel

Public Class CalculatorTextbox
    Inherits System.Windows.Forms.TextBox

    Public Delegate Sub GenericEventHandler(ByVal sender As Object, ByVal e As EventArgs)
    Public Event ReturnPressed As GenericEventHandler
    Public Event TextValueChanged As GenericEventHandler

    Private decPlaces As Integer
    Private fmtString As String '= "$#,###,##0.00;($#,###,##0.00)"
    '$#,###,##0.00;($#,###,##0.00)
    Private isDirty As Boolean = False
    Private _advanceOnEnterKey As Boolean
    <Browsable(True), DefaultValue(2)> Public Property DecimalPlaces() As Integer
        Get
            Return decPlaces
        End Get
        Set(ByVal value As Integer)
            decPlaces = value
        End Set
    End Property

    Public Property FormatString() As String
        Get
            Return fmtString
        End Get
        Set(ByVal value As String)
            fmtString = value
        End Set
    End Property

    Public ReadOnly Property HasChanged() As Boolean
        Get
            Return isDirty
        End Get
    End Property

    <Browsable(True), DefaultValue(True)> _
   Public Property AdvanceOnEnterKey() As Boolean
        Get
            Return Me._advanceOnEnterKey
        End Get
        Set(ByVal value As Boolean)
            Me._advanceOnEnterKey = value
        End Set
    End Property

    Public Sub New()
        MyBase.New()

        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        'Me.KeypadClass1 = KeypadClass.GetInstance
        Me.SuspendLayout()
        '
        'KeypadClass1
        '
        'Me.KeypadClass1.CurrentControl = Nothing
        'Me.KeypadClass1.DecimalPlaces = 2
        'Me.KeypadClass1.Location = New System.Drawing.Point(0, 0)
        'Me.KeypadClass1.Name = "KeypadClass1"
        'Me.KeypadClass1.Size = New System.Drawing.Size(96, 164)
        'Me.KeypadClass1.TabIndex = 0
        '
        'CalculatorTextbox
        '
        Me.TextAlign = Windows.Forms.HorizontalAlignment.Right
        Me.ResumeLayout(False)

    End Sub

    Private Sub CalculatorTextbox_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        Me.Text = CStr(UnFmtText(Me))
        Me.SelectionStart = 0
        Me.SelectionLength = Me.Text.Trim.Length
    End Sub

    Private Sub CalculatorTextbox_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Enter
        Me.Text = CStr(UnFmtText(Me))
        Me.SelectionStart = 0
        Me.SelectionLength = Me.Text.Trim.Length
    End Sub

    Private Sub CalculatorTextbox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Windows.Forms.Keys.Add Or e.KeyCode = Windows.Forms.Keys.Subtract _
        Or e.KeyCode = Windows.Forms.Keys.Divide Or e.KeyCode = Windows.Forms.Keys.Multiply Then
            Me.Select(0, 0)
            Dim keypad1 As KeypadClass = KeypadClass.GetInstance
            keypad1.ShowCalculator(Me, Chr(e.KeyCode), New Drawing.Point(Me.Left, Me.Top + Me.Height))
            AddHandler keypad1.CloseClick, AddressOf OnKeyPadClose
        ElseIf (e.KeyCode >= Windows.Forms.Keys.D0 And e.KeyCode <= Windows.Forms.Keys.D9) _
        Or e.KeyCode = Windows.Forms.Keys.OemPeriod Or (e.KeyCode >= Windows.Forms.Keys.NumPad0 _
        And e.KeyCode <= Windows.Forms.Keys.NumPad9) Or e.KeyCode = Windows.Forms.Keys.Decimal _
        Or e.KeyCode = Windows.Forms.Keys.Back Then
            isDirty = True
        Else
            e.SuppressKeyPress = True
            e.Handled = True
        End If
    End Sub

    Private Sub CalculatorTextbox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            If Me._advanceOnEnterKey Then
                Me.Parent.SelectNextControl(Me, True, True, True, True)
            End If
            RaiseEvent ReturnPressed(Me, New EventArgs)
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub CalculatorTextbox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            Exit Sub
        End If
        'I changed this argument from (Asc(Val(e.KeyChar),Me) 
        e.Handled = CkKeyPressNumeric(Asc(e.KeyChar), Me) = 0
        If e.Handled Then
            isDirty = True
            Me.Modified = True
        End If
    End Sub

    Private Sub CalculatorTextbox_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave
        Me.Text = FmtText(Me)
        If isDirty Then
            RaiseEvent TextValueChanged(Me, New EventArgs)
            isDirty = False
        End If
    End Sub
    Private Sub OnKeyPadClose(ByVal Sender As Object, ByVal e As CalculatorClasses.RegisterEventArgs)
        Me.Text = e.Text
        Me.Focus()
        RemoveHandler CType(Sender, KeypadClass).CloseClick, AddressOf OnKeyPadClose
    End Sub

#Region "Validate Contents"
    ' Format contents of textbox when it loses focus.
    Public Function FmtText(ByVal txtBox As CalculatorTextbox) As String
        On Error Resume Next
        If InStr(1, txtBox.FormatString, ";", CompareMethod.Text) > 0 Then
            If InStr(txtBox.Text, "-") > 0 Or _
               (InStr(txtBox.Text, "(") > 0 And _
               InStr(txtBox.Text, ")") > 0) Then
                Return Format(Math.Abs(Val(txtBox.Text)), _
                   Mid$(txtBox.FormatString, InStr(txtBox.FormatString, ";") + 1))
            Else
                Return Format$(Math.Abs(Val(txtBox.Text)), _
                   Microsoft.VisualBasic.Left(txtBox.FormatString, _
                   InStr(txtBox.FormatString, ";") - 1))
            End If
        ElseIf InStr(1, txtBox.FormatString, "%", CompareMethod.Text) > 0 Then
            Return Format$(txtBox.Text, txtBox.FormatString)
        Else
            Return Format$(txtBox.Text, txtBox.FormatString)
        End If
    End Function

    ' Unformat the textbox when it receives focus
    Public Function UnFmtText(ByVal txtBox As CalculatorTextbox) As Object
        On Error Resume Next
        Dim retVal As Object
        retVal = Val(Replace(Replace(Replace(Replace(Replace _
          (txtBox.Text, "$", ""), ",", ""), ")", ""), "(", ""), "%", ""))
        If InStr(txtBox.Text, "%") > 0 Then
            retVal = CSng(retVal) / 100
        End If
        If InStr(txtBox.Text, "(") > 0 And InStr(txtBox.Text, ")") > 0 Then
            retVal = CSng(retVal) * -1
        End If
        Return retVal
    End Function

    ' validate keyboard input
    Private Function CkKeyPressNumeric(ByVal riKeyAscii As Integer, _
       ByVal txtBox As CalculatorTextbox) As Integer
        Dim liKeyReturn As Integer
        ' allow 0-9,., Back, Del,-,Ins, and / if in FormatString format
        On Error Resume Next
        CkKeyPressNumeric = riKeyAscii
        If riKeyAscii = Windows.Forms.Keys.Back Or _
           riKeyAscii = Windows.Forms.Keys.Insert Or _
           riKeyAscii = Windows.Forms.Keys.Delete Or _
           riKeyAscii = 46 Or _
           (riKeyAscii >= Windows.Forms.Keys.D0 And riKeyAscii <= Windows.Forms.Keys.D9) Or _
           riKeyAscii = 45 Or _
           riKeyAscii = 46 Or _
           (InStr(txtBox.FormatString, "/") > 0 And riKeyAscii = Windows.Forms.Keys.Divide) _
           Then
            If txtBox.SelectionLength = 0 Then
                If InStr(txtBox.Text, ".") > 0 Then
                    If Len(Mid(txtBox.Text, InStr(txtBox.Text, ".") + 1)) > 1 Then
                        Windows.Forms.SendKeys.Send("{TAB}")
                        CkKeyPressNumeric = 0
                    End If
                End If
            Else
                txtBox.Text = ""
            End If
            Return CkKeyPressNumeric
        End If
        Return 0
    End Function


#End Region

    Private Sub CalculatorTextbox_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        CalculatorTextbox_Enter(sender, e)
    End Sub


End Class
