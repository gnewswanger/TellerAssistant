Imports System.ComponentModel

Public Class CheckViewerNavViewPanel
    Inherits CheckViewerPanelBaseClass

    Delegate Sub SetDateCallback(ByVal value As Date)
    Delegate Sub TwoIntegerCallback(ByVal val1 As Integer, ByVal val2 As Integer)
    Public Event CheckviewNextNavClick As GenericCallback
    Public Event CheckviewPrevNavClick As GenericCallback
    Public Event CheckviewFirstNavClick As GenericCallback
    Public Event CheckviewLastNavClick As GenericCallback
    Public Event CheckviewApplyClick As GenericCallback
    Public Event CheckviewResetClick As GenericCallback

    Protected _navButtonsVisible As Boolean
    Protected _applyOnEnterKey As Boolean

#Region "Class Properties"

    <DefaultValue(True)> _
    Public Property NavButtonsVisible() As Boolean
        Get
            Return _navButtonsVisible
        End Get
        Set(ByVal value As Boolean)
            _navButtonsVisible = value
            SetNavButtonVisible(_navButtonsVisible)
        End Set
    End Property

    Public Property OkButtonLabel() As String
        Get
            Return btnCheckApply.Text
        End Get
        Set(ByVal value As String)
            SetBtnCheckApplyText(value)
        End Set
    End Property

    Public Property ApplyonEntryKey() As Boolean
        Get
            Return _applyOnEnterKey
        End Get
        Set(ByVal value As Boolean)
            _applyOnEnterKey = value
        End Set
    End Property

#End Region

#Region "Set Current Check"

    Private Sub SetCurrentCheck(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.CheckviewSetCurrentCheck
        Dim args As CheckRegisterEventArgs = CType(e, CheckRegisterEventArgs)
        'SetCheckPixImage()
        SetCheckDate(args.origCheck.CheckDate)
        SetCheckAmtText(args.origCheck.CheckAmount.ToString("C"))
        SetNavButtonsEnabled(args.QueueCount, args.QueueIndex)
        SetApplyButtonEnabled(sender, e)

    End Sub

#End Region

#Region "Control Callback methods"

    Protected Sub SetCheckDate(ByVal dt As DateTime)
        If dtpCheckDate.InvokeRequired Then
            Me.BeginInvoke(New SetDateCallback(AddressOf SetCheckDate), dt)
        Else
            dtpCheckDate.Value = dt
        End If
    End Sub

    Protected Sub SetCheckAmtText(ByVal text As String)
        If txtCheckAmt.InvokeRequired Then
            Me.BeginInvoke(New SetTextCallback(AddressOf SetCheckAmtText), text)
        Else
            txtCheckAmt.Text = text
        End If
    End Sub

    Protected Sub SettxtCheckAmtFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If txtCheckAmt.InvokeRequired Then
            Me.BeginInvoke(New GenericCallback(AddressOf SettxtCheckAmtFocus), sender, e)
        Else
            Me.txtCheckAmt.Focus()
        End If
    End Sub

    Protected Sub SetBtnCheckApplyText(ByVal Value As String)
        If btnCheckApply.InvokeRequired Then
            Me.BeginInvoke(New SetTextCallback(AddressOf SetBtnCheckApplyText), Value)
        Else
            btnCheckApply.Text = Value
        End If
    End Sub

#End Region

#Region "Button Visible / Enabled"

    Protected Sub SetNavButtonVisible(ByVal value As Boolean)
        btnNavFirst.Visible = value
        btnNavLast.Visible = value
        btnCheckNext.Visible = value
        btnCheckPrev.Visible = value
    End Sub

    Protected Sub SetCheckNextEnabled(ByVal cnt As Integer, ByVal indx As Integer)
        If btnCheckNext.InvokeRequired Then
            Me.Invoke(New TwoIntegerCallback(AddressOf SetCheckNextEnabled), cnt, indx)
        Else
            btnCheckNext.Enabled = cnt > 0 AndAlso indx < cnt - 1
        End If
    End Sub

    Protected Sub SetCheckPrevEnabled(ByVal cnt As Integer, ByVal indx As Integer)
        If btnCheckPrev.InvokeRequired Then
            Me.Invoke(New TwoIntegerCallback(AddressOf SetCheckNextEnabled), cnt, indx)
        Else
            btnCheckPrev.Enabled = cnt > 0 AndAlso indx > 0
        End If
    End Sub

    Protected Sub SetCheckFirstEnabled(ByVal cnt As Integer, ByVal indx As Integer)
        If btnNavFirst.InvokeRequired Then
            Me.Invoke(New TwoIntegerCallback(AddressOf SetCheckNextEnabled), cnt, indx)
        Else
            btnNavFirst.Enabled = cnt > 1 AndAlso indx > 0
        End If
    End Sub

    Protected Sub SetCheckLastEnabled(ByVal cnt As Integer, ByVal indx As Integer)
        If btnNavLast.InvokeRequired Then
            Me.Invoke(New TwoIntegerCallback(AddressOf SetCheckNextEnabled), cnt, indx)
        Else
            btnNavLast.Enabled = cnt > 1 AndAlso indx < cnt - 1
        End If
    End Sub


    Protected Sub SetApplyButtonEnabled(sender As Object, e As EventArgs)
        If Me.btnCheckApply.InvokeRequired Then
            Me.Invoke(New GenericCallback(AddressOf SetApplyButtonEnabled), sender, e)
        Else
            If Me.UpdatedCheck IsNot Nothing Then
                btnCheckApply.Enabled = Me.IsDirty OrElse Me.UpdatedCheck.CheckAmount > 0
            Else
                btnCheckApply.Enabled = Me.IsDirty
            End If
            btnCheckReset.Enabled = Me.IsDirty
        End If
    End Sub

    Protected Sub SetNavButtonsEnabled(ByVal cnt As Integer, ByVal indx As Integer)
        SetCheckNextEnabled(cnt, indx)
        SetCheckPrevEnabled(cnt, indx)
        SetCheckFirstEnabled(cnt, indx)
        SetCheckLastEnabled(cnt, indx)
    End Sub
#End Region

#Region "Button Click methods"

    Private Sub btnCheckNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckNext.Click
        RaiseEvent CheckviewNextNavClick(sender, e)
        txtCheckAmt.Focus()
    End Sub

    Private Sub btnCheckPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckPrev.Click
        RaiseEvent CheckviewPrevNavClick(sender, e)
        txtCheckAmt.Focus()
    End Sub

    Private Sub btnCheckFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNavFirst.Click
        RaiseEvent CheckviewFirstNavClick(sender, e)
        txtCheckAmt.Focus()
    End Sub

    Private Sub btnCheckLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNavLast.Click
        RaiseEvent CheckviewLastNavClick(sender, e)
        txtCheckAmt.Focus()
    End Sub

#End Region

#Region "Text KeyPress Methods"

    Private Sub txtCheckAmt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCheckAmt.KeyPress
        If e.KeyChar <> vbCr OrElse e.KeyChar <> vbTab Then
            Me.IsDirty = True
            SetApplyButtonEnabled(sender, e)
        End If
    End Sub

#End Region

#Region "Textbox Leave Methods"

    Private Sub txtCheckAmt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCheckAmt.Leave
        If Me.IsDirty Then
            Me.UpdatedCheck.CheckAmount = CSng(txtCheckAmt.Text)
        End If
    End Sub

    Private Sub dtpCheckDate_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpCheckDate.ValueChanged
        If Me.UpdatedCheck IsNot Nothing Then
            Me.UpdatedCheck.CheckDate = dtpCheckDate.Value
        End If
    End Sub

#End Region

#Region "Textbox Keyup Methods"

    Private Sub txtCheckAmt_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCheckAmt.KeyUp
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            If Me.ApplyonEntryKey Then

            Else
                txtCheckAmt.DeselectAll()
                SplitContainer1.Panel2.SelectNextControl(txtCheckAmt, True, True, True, True)
            End If
        End If
    End Sub

    Private Sub dtpCheckDate_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpCheckDate.KeyUp
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.SplitContainer1.Panel2.SelectNextControl(dtpCheckDate, True, True, True, True)
        Else
            Me.IsDirty = True
            SetApplyButtonEnabled(sender, e)
        End If
        e.SuppressKeyPress = True
    End Sub
#End Region

    'Private Sub resetAll(ByVal container As CheckViewerPanelBaseClass)
    '    Dim ctrlX As Control
    '    For Each ctrlX In container.Controls
    '        If TypeOf ctrlX Is TextBox Then CType(ctrlX, TextBox).Text = ""
    '        If TypeOf ctrlX Is CheckBox Then CType(ctrlX, CheckBox).Checked = False
    '        If TypeOf ctrlX Is ComboBox Then CType(ctrlX, ComboBox).Text = ""
    '    Next ctrlX

    'End Sub

    Protected Overridable Sub OnCheckviewReset(ByVal sender As Object, ByVal e As System.EventArgs)
        RaiseEvent CheckviewResetClick(sender, e)
    End Sub

    Protected Overridable Sub OnCheckviewApply(ByVal sender As Object, ByVal e As System.EventArgs)
        RaiseEvent CheckviewApplyClick(sender, e)
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.txtCheckAmt.AdvanceOnEnterKey = False
    End Sub

End Class
