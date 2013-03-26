Public Class KeypadClass

    Public Delegate Sub CloseClickHandler(ByVal sender As Object, ByVal e As CalculatorClasses.RegisterEventArgs)
    Public Event CloseClick As CloseClickHandler

    Private Shared _instance As KeypadClass
    Private _decPlaces As Integer
    Private _calc As New CalculatorClass
    Private _assocControl As Object

    Public Property CurrentControl() As Object
        Get
            Return Me._assocControl
        End Get
        Set(ByVal Value As Object)
            Me._assocControl = Value
        End Set
    End Property

    Public Property DecimalPlaces() As Integer
        Get
            Return Me._decPlaces
        End Get
        Set(ByVal Value As Integer)
            Me._decPlaces = Value
        End Set
    End Property

    Friend Shared Function GetInstance() As KeypadClass
        If _instance Is Nothing Then
            _instance = New KeypadClass
        End If
        Return _instance
    End Function

    Private Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub KeypadClass_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler Me._calc.RegisterChanged, AddressOf OnRegisterChanged
        txtNumber.Focus()
    End Sub

    Private Sub KeypadClass_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        Me.Visible = False
    End Sub

    Private Sub KeypadClass_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then
            txtNumber.Focus()
        End If
    End Sub

    Public Sub OnCloseClick(ByVal Sender As Object, ByVal e As CalculatorClasses.RegisterEventArgs)
        e.Value = Me._calc.Register1
        Me._calc.nfi.NumberDecimalDigits = Me._decPlaces
        e.Text = Me._calc.Register1.ToString("N", Me._calc.nfi)
        RaiseEvent CloseClick(Me, e)
        Me.Hide()
    End Sub

    Public Sub OnRegisterChanged(ByVal sender As Object, ByVal e As CalculatorClasses.RegisterEventArgs)
        txtNumber.Text = e.Text
    End Sub

#Region "Calculator Button Click Methods"

    Private Sub btn0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn0.Click
        _calc.ProcessKeypress(PadKey.pkey0)
        txtNumber.Focus()
    End Sub

    Private Sub btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1.Click
        _calc.ProcessKeypress(PadKey.pkey1)
        txtNumber.Focus()
    End Sub

    Private Sub btn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn2.Click
        _calc.ProcessKeypress(PadKey.pkey2)
        txtNumber.Focus()
    End Sub

    Private Sub btn3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn3.Click
        _calc.ProcessKeypress(PadKey.pkey3)
        txtNumber.Focus()
    End Sub

    Private Sub btn4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn4.Click
        _calc.ProcessKeypress(PadKey.pkey4)
        txtNumber.Focus()
    End Sub

    Private Sub btn5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn5.Click
        _calc.ProcessKeypress(PadKey.pkey5)
        txtNumber.Focus()
    End Sub

    Private Sub btn6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn6.Click
        _calc.ProcessKeypress(PadKey.pkey6)
        txtNumber.Focus()
    End Sub

    Private Sub btn7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn7.Click
        _calc.ProcessKeypress(PadKey.pkey7)
        txtNumber.Focus()
    End Sub

    Private Sub btn8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn8.Click
        _calc.ProcessKeypress(PadKey.pkey8)
        txtNumber.Focus()
    End Sub

    Private Sub btn9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn9.Click
        _calc.ProcessKeypress(PadKey.pkey9)
        txtNumber.Focus()
    End Sub

    Private Sub btnDot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDot.Click
        _calc.ProcessKeypress(PadKey.pkeyDot)
        txtNumber.Focus()
    End Sub

    Private Sub btnPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlus.Click
        _calc.ProcessKeypress(PadKey.pkeyPlus)
        txtNumber.Focus()
    End Sub

    Private Sub btnMinus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMinus.Click
        _calc.ProcessKeypress(PadKey.pkeyMinus)
        txtNumber.Focus()
    End Sub

    Private Sub btnTimes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimes.Click
        _calc.ProcessKeypress(PadKey.pkeyTimes)
        txtNumber.Focus()
    End Sub

    Private Sub btnDivide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDivide.Click
        _calc.ProcessKeypress(PadKey.pkeyDivide)
        txtNumber.Focus()
    End Sub

    Private Sub btnPercent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPercent.Click
        _calc.ProcessKeypress(PadKey.pkeyPercent)
        txtNumber.Focus()
    End Sub

    Private Sub btnShiftLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShiftLeft.Click
        _calc.ProcessKeypress(PadKey.pkeyBackspace)
        txtNumber.Focus()
    End Sub

    Private Sub btnCE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCE.Click
        _calc.ProcessKeypress(PadKey.pkeyClearEntry)
        txtNumber.Focus()
    End Sub

    Private Sub btnC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnC.Click
        _calc.ProcessKeypress(PadKey.pkeyClear)
        txtNumber.Focus()
        OnCloseClick(sender, New RegisterEventArgs)
    End Sub

    Private Sub btnEquals_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEquals.Click
        _calc.ProcessKeypress(PadKey.pkeyEquals)
        OnCloseClick(sender, New RegisterEventArgs)
    End Sub

#End Region

    Private Sub txtNumber_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumber.KeyUp
        Dim kc As PadKey = CType([Enum].Parse(GetType(PadKey), e.KeyData.ToString), PadKey)
        If e.KeyData = kc Then
            If e.KeyData = Windows.Forms.Keys.Enter Then
                btnEquals_Click(sender, e)
            ElseIf e.KeyData = Windows.Forms.Keys.Escape Then
                btnC_Click(sender, e)
            Else
                Me._calc.ProcessKeypress(kc)
            End If
        End If
    End Sub

    Public Sub ShowCalculator(ByVal sender As Object, ByVal key As Char, ByVal loc As Drawing.Point)
        Me._assocControl = sender
        'Me.Parent = assocControl.parent
        Me.Parent = CType(Me._assocControl, Windows.Forms.Control).Parent
        Me.Location = loc
        Dim myParentBottom As Integer = Me.Parent.Height
        If Me.Parent.FindForm Is Me.Parent Then
            myParentBottom = CType(Me.Parent, System.Windows.Forms.Form).ClientSize.Height()
        End If
        Dim myBottom As Integer = Me.Height + Me.Top
        If myBottom > myParentBottom Then
            Me.Top -= (myBottom - myParentBottom)
            If Me.Parent.ClientRectangle.Width - CType(Me._assocControl, Windows.Forms.Control).Right > Me.Width Then
                Me.Left = CType(Me._assocControl, Windows.Forms.Control).Right
            ElseIf CType(Me._assocControl, Windows.Forms.Control).Left > Me.Width Then
                Me.Left = CType(Me._assocControl, Windows.Forms.Control).Left - Me.Width
            ElseIf CType(Me._assocControl, Windows.Forms.Control).Left > Me.Parent.ClientRectangle.Width - CType(Me._assocControl, Windows.Forms.Control).Right Then
                Me.Left = Me.Parent.ClientRectangle.Left
            Else
                Me.Left = Me.Parent.ClientRectangle.Width - Me.Width
            End If
        End If
        Me.BringToFront()
        If CType(sender, Windows.Forms.Control).Text = "" Then
            CType(sender, Windows.Forms.Control).Text = CStr(0)
        End If
        Me.SetRegister(CSng(CType(sender, Windows.Forms.Control).Text))
        Select Case key
            Case CChar("+")
                Me._calc.cMode = CalculatorMode.cmAdd
            Case CChar("-")
                Me._calc.cMode = CalculatorMode.cmSubtract
            Case CChar("*")
                Me._calc.cMode = CalculatorMode.cmMultiply
            Case CChar("/")
                Me._calc.cMode = CalculatorMode.cmDivide
        End Select
        Me.Show()

    End Sub

    Public Sub SetRegister(ByVal num As Single)
        Me._calc.Register1 = num
    End Sub

    Public Sub SetMode(ByVal mode As CalculatorClasses.CalculatorMode)
        Me._calc.cMode = mode
    End Sub


End Class
    