Imports System.ComponentModel

Public Class CheckViewerViewPanel
    Inherits CheckViewerNavViewPanel

    Delegate Sub SetReceiptStatusCallback(ByVal val As ReceiptRequestStatus)
    Public Event CheckviewDonorClick As GenericCallback
    Public Event CheckviewDonorChanged As GenericCallback

#Region "Class Properties"

    Protected Property SendReceiptCheckboxVisible() As Boolean
        Get
            Return Me.chkbxSendReceipt.Visible
        End Get
        Set(ByVal value As Boolean)
            Me.chkbxSendReceipt.Visible = value
        End Set
    End Property

    Public WriteOnly Property DonorList() As List(Of DonorClass)
        Set(ByVal value As List(Of DonorClass))
            Me.comboDonor.Items.Clear()
            Me.comboDonor.Items.AddRange(value.ToArray)
            Me.comboDonor.DisplayMember = "Donor"
        End Set
    End Property
#End Region

#Region "Set Current Check"

    Private Sub SetCurrentCheck(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.CheckviewSetCurrentCheck
        Dim args As CheckRegisterEventArgs = CType(e, CheckRegisterEventArgs)
        SetCheckPixImage()
        SetCheckBankText(args.origCheck.RoutingNo)
        SetCheckAcctText(args.origCheck.AccountNo)
        SetCheckNoText(args.origCheck.CheckNo)
        SetCheckDonorText(args.origCheck.Donor)
        SetButtonEditDonorInfoVisible(args.origCheck.DonorInfo IsNot Nothing AndAlso args.origCheck.Donor <> "")
        SetCheckReceiptChecked((args.origCheck.ReceiptRequest And ReceiptRequestStatus.rrsAllRequests) <> 0)
        SetSendReceiptEnabled(args.origCheck.ReceiptRequest)

    End Sub

#End Region

#Region "Control Callback methods"

    Private Sub SetCheckBankText(ByVal text As String)
        If txtCheckBank.InvokeRequired Then
            Me.BeginInvoke(New SetTextCallback(AddressOf SetCheckBankText), text)
        Else
            txtCheckBank.Text = text
        End If
    End Sub

    Private Sub SetCheckAcctText(ByVal text As String)
        If txtCheckAcct.InvokeRequired Then
            Me.BeginInvoke(New SetTextCallback(AddressOf SetCheckAcctText), text)
        Else
            txtCheckAcct.Text = text
        End If
    End Sub

    Private Sub SetCheckNoText(ByVal text As String)
        If txtCheckNo.InvokeRequired Then
            Me.BeginInvoke(New SetTextCallback(AddressOf SetCheckNoText), text)
        Else
            txtCheckNo.Text = text
        End If
    End Sub

    Private Sub SetCheckDonorText(ByVal text As String)
        If Me.comboDonor.InvokeRequired Then
            Me.BeginInvoke(New SetTextCallback(AddressOf SetCheckDonorText), text)
        Else
            If text Is Nothing OrElse text.Trim = String.Empty Then
                Me.comboDonor.SelectedIndex = -1
                Me.comboDonor.Text = String.Empty
            Else
                Me.comboDonor.Text = text
            End If
        End If
    End Sub

    Private Sub SetCheckReceiptChecked(ByVal checked As Boolean)
        If Me.chkbxSendReceipt.InvokeRequired Then
            Me.BeginInvoke(New SetBooleanCallback(AddressOf SetCheckReceiptChecked), checked)
        Else
            If chkbxSendReceipt.Checked <> checked Then
                Me.chkbxSendReceipt.Checked = checked
            End If
        End If
    End Sub

#End Region

#Region "Button Visible / Enabled"

    Private Sub SetSendReceiptEnabled(ByVal recpt As ReceiptRequestStatus)
        If Me.chkbxSendReceipt.InvokeRequired Then
            Me.Invoke(New SetReceiptStatusCallback(AddressOf SetSendReceiptEnabled), recpt)
        Else
            Me.chkbxSendReceipt.Enabled = ((ReceiptRequestStatus.rrsAllRequests And recpt) <> ReceiptRequestStatus.rrsRequestedSent)
        End If
    End Sub

    Private Sub SetButtonEditDonorInfoVisible(ByVal donorNotBlank As Boolean)
        If btnEditDonor.InvokeRequired Then
            Me.BeginInvoke(New SetBooleanCallback(AddressOf SetButtonEditDonorInfoVisible), donorNotBlank)
        Else
            Me.btnEditDonor.Visible = donorNotBlank
        End If
    End Sub

#End Region

#Region "Button Click methods"

    Private Sub btnEditDonor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditDonor.Click
        If Me.comboDonor.Text <> String.Empty Then
            Me.IsDirty = True
            SetApplyButtonEnabled(sender, e)
            RaiseEvent CheckviewDonorClick(sender, e)
            txtCheckAmt.Focus()
        End If
    End Sub


#End Region

#Region "Text KeyPress Methods"

    Private Sub txtCheckBank_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCheckBank.KeyPress
        If e.KeyChar = vbCr Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtCheckAcct_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCheckAcct.KeyPress
        If e.KeyChar = vbCr Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtCheckNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCheckNo.KeyPress
        If e.KeyChar = vbCr Then
            e.Handled = True
        End If
    End Sub


    Private Sub comboDonor_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles comboDonor.DropDownClosed
        If Me.comboDonor.SelectedIndex > -1 Then
            Me.SetButtonEditDonorInfoVisible(True)
            Me.SetCurrentDonorInfo(CType(Me.comboDonor.SelectedItem, DonorClass))
            Me.OriginalCheck.DonorInfo = Me.UpdatedCheck.DonorInfo
            'RaiseEvent CheckviewDonorChanged(sender, e)
            Me.IsDirty = True
            SetApplyButtonEnabled(sender, e)
        End If
    End Sub

#End Region

#Region "Textbox Leave Methods"

    Private Sub txtCheckBank_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCheckBank.Leave
        If txtCheckBank.Modified Then
            Me.UpdatedCheck.RoutingNo = txtCheckBank.Text
        End If
    End Sub

    Private Sub txtCheckAcct_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCheckAcct.Leave
        If txtCheckAcct.Modified Then
            Me.UpdatedCheck.AccountNo = txtCheckAcct.Text
        End If
    End Sub

    Private Sub txtCheckNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCheckNo.Leave
        If txtCheckNo.Modified Then
            Me.UpdatedCheck.CheckNo = txtCheckNo.Text
        End If
    End Sub

    Private Sub comboDonor_KeyDown(sender As Object, e As KeyEventArgs) Handles comboDonor.KeyDown
        If e.KeyCode = Keys.Enter AndAlso Me.comboDonor.Text <> "" Then
            Me.SetButtonEditDonorInfoVisible(True)
            e.Handled = True
        End If
    End Sub

    Private Sub comboDonor_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles comboDonor.Leave
        If Me.comboDonor.SelectedIndex = -1 And Me.comboDonor.Text <> "" Then
            Me.btnEditDonor.Visible = True
            Me.btnEditDonor.Enabled = True
            Me.UpdatedCheck.DonorInfo = New DonorClass(Me.comboDonor.Text.Trim)
            Me.OriginalCheck.DonorInfo = Me.UpdatedCheck.DonorInfo
            RaiseEvent CheckviewDonorChanged(sender, e)
            txtCheckAmt.Focus()
        End If
    End Sub

    Private Sub chkbxSendReceipt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkbxSendReceipt.CheckedChanged
        If Me.UpdatedCheck IsNot Nothing Then
            If chkbxSendReceipt.Checked AndAlso (Me.UpdatedCheck.ReceiptRequest And ReceiptRequestStatus.rrsAllRequests) = 0 Then
                Me.UpdatedCheck.ReceiptRequest = ReceiptRequestStatus.rrsRequestedNotSent
            ElseIf chkbxSendReceipt.Checked = False AndAlso (Me.UpdatedCheck.ReceiptRequest And ReceiptRequestStatus.rrsAllRequests) <> 0 Then
                If MsgBox("You are about to unset the receipt request. Do you wish to continue?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Me.UpdatedCheck.ReceiptRequest = ReceiptRequestStatus.rrsNone
                End If
            End If
        End If
        Me.IsDirty = True
        SetApplyButtonEnabled(sender, e)
        txtCheckAmt.Focus()
    End Sub
#End Region

#Region "Textbox Keyup Methods"

    Private Sub txtCheckBank_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCheckBank.KeyUp
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            txtCheckBank.DeselectAll()
            Me.SplitContainer1.Panel2.SelectNextControl(Me.txtCheckBank, True, True, True, True)
        Else
            Me.IsDirty = True
            SetApplyButtonEnabled(sender, e)
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txtCheckAcct_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCheckAcct.KeyUp
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            txtCheckAcct.DeselectAll()
            Me.SplitContainer1.Panel2.SelectNextControl(Me.txtCheckAcct, True, True, True, True)
        Else
            Me.IsDirty = True
            SetApplyButtonEnabled(sender, e)
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txtCheckNo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCheckNo.KeyUp
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            txtCheckNo.DeselectAll()
            Me.SplitContainer1.Panel2.SelectNextControl(txtCheckNo, True, True, True, True)
        Else
            Me.IsDirty = True
            SetApplyButtonEnabled(sender, e)
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub dtpCheckDate_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.SplitContainer1.Panel2.SelectNextControl(dtpCheckDate, True, True, True, True)
        Else
            Me.IsDirty = True
            SetApplyButtonEnabled(sender, e)
        End If
        e.SuppressKeyPress = True
    End Sub
#End Region

    Private Sub comboDonor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles comboDonor.SelectedIndexChanged
        Me.IsDirty = True
        SetApplyButtonEnabled(sender, e)
    End Sub

End Class
