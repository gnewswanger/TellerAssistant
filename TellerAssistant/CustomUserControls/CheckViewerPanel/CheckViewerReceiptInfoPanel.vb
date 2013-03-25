Imports System.ComponentModel

Public Class CheckViewerReceiptInfoPanel
    Inherits CheckViewerNavViewPanel

    Public Event CheckviewDeleteCurrentCheckOnly As GenericCallback

 
    Public WriteOnly Property ReceiptCompleted() As Boolean
        Set(ByVal value As Boolean)
            Me.SetLabelReceiptCompleteVisible(value)
        End Set
    End Property
    Public Property Donor() As DonorClass
        Get
            Return Me.GetDonorInfo
        End Get
        Set(ByVal value As DonorClass)
            Me.SetDonorInfo(value)
        End Set
    End Property

    Public Sub New()
        MyBase.new()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.IsDirty = True
    End Sub

#Region "Set Current Check / Donor Methods"

    Private Sub SetCurrentCheck(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.CheckviewSetCurrentCheck
        Dim args As CheckRegisterEventArgs = CType(e, CheckRegisterEventArgs)
        SetCheckPixImage()
        SetCheckDonorText(args.origCheck.Donor)
        SetCheckAddressText(args.origCheck.DonorAddress)
        SetCheckCityText(args.origCheck.DonorCity)
        SetCheckStateText(args.origCheck.DonorState)
        SetCheckZipChecked(args.origCheck.DonorZip)
    End Sub

    Private Function GetDonorInfo() As DonorClass
        Dim aDonor As New DonorClass(Me.txtDonorName.Text.Trim)
        aDonor.Address = Me.txtDonorAddr.Text.Trim
        aDonor.City = Me.txtDonorCity.Text.Trim
        aDonor.State = Me.txtDonorState.Text.Trim
        aDonor.Zip = Me.txtDonorZip.Text.Trim
        Return aDonor
    End Function

    Private Sub SetDonorInfo(ByVal aDonor As DonorClass)
        Me.SetCheckDonorText(aDonor.Donor)
        Me.SetCheckAddressText(aDonor.Address)
        Me.SetCheckCityText(aDonor.City)
        Me.SetCheckStateText(aDonor.State)
        Me.SetCheckZipChecked(aDonor.Zip)
    End Sub

#End Region

#Region "Control Callback methods"

    Private Sub SetCheckDonorText(ByVal text As String)
        If Me.txtDonorName.InvokeRequired Then
            Me.BeginInvoke(New SetTextCallback(AddressOf SetCheckDonorText), text)
        Else
            Me.txtDonorName.Text = text
        End If
    End Sub

    Private Sub SetCheckAddressText(ByVal text As String)
        If Me.txtDonorAddr.InvokeRequired Then
            Me.BeginInvoke(New SetTextCallback(AddressOf SetCheckAddressText), text)
        Else
            Me.txtDonorAddr.Text = text
        End If
    End Sub
    Private Sub SetCheckCityText(ByVal text As String)
        If Me.txtDonorCity.InvokeRequired Then
            Me.BeginInvoke(New SetTextCallback(AddressOf SetCheckCityText), text)
        Else
            Me.txtDonorCity.Text = text
        End If
    End Sub
    Private Sub SetCheckStateText(ByVal text As String)
        If Me.txtDonorState.InvokeRequired Then
            Me.BeginInvoke(New SetTextCallback(AddressOf SetCheckStateText), text)
        Else
            Me.txtDonorState.Text = text
        End If
    End Sub
    Private Sub SetCheckZipChecked(ByVal text As String)
        If Me.txtDonorZip.InvokeRequired Then
            Me.BeginInvoke(New SetTextCallback(AddressOf SetCheckZipChecked), text)
        Else
            Me.txtDonorZip.Text = text
        End If
    End Sub
#End Region

#Region "Button Visible / Enabled"

    Private Sub SetLabelReceiptCompleteVisible(ByVal value As Boolean)
        If Me.labelReceiptComplete.InvokeRequired Then
            Me.Invoke(New SetBooleanCallback(AddressOf SetLabelReceiptCompleteVisible), value)
        Else
            Me.labelReceiptComplete.Visible = value
        End If
    End Sub

#End Region

#Region "Text KeyPress Methods"

    Private Sub txtDonorAddr_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDonorAddr.KeyPress
        If e.KeyChar = vbCr Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDonorCity_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDonorCity.KeyPress
        If e.KeyChar = vbCr Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDonorState_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDonorState.KeyPress
        If e.KeyChar = vbCr Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDonorZip_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDonorZip.KeyPress
        If e.KeyChar = vbCr Then
            e.Handled = True
        End If
    End Sub
#End Region

#Region "Textbox Leave Methods"

    Private Sub txtDonorAddr_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDonorAddr.Leave
        If txtDonorAddr.Modified Then
            Me.UpdatedCheck.DonorAddress = txtDonorAddr.Text
        End If
    End Sub

    Private Sub txtDonorCity_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDonorCity.Leave
        If txtDonorCity.Modified Then
            Me.UpdatedCheck.DonorCity = txtDonorCity.Text
        End If
    End Sub

    Private Sub txtDonorState_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDonorState.Leave
        If txtDonorState.Modified Then
            Me.UpdatedCheck.DonorState = txtDonorState.Text.ToUpper
        End If
    End Sub

    Private Sub txtDonorZip_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDonorZip.Leave
        If txtDonorZip.Modified Then
            Me.UpdatedCheck.DonorZip = txtDonorZip.Text
        End If
    End Sub

#End Region

#Region "Textbox Keyup Methods"

    Private Sub txtDonorAddr_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDonorAddr.KeyUp
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            txtDonorAddr.DeselectAll()
            Me.SplitContainer1.Panel2.SelectNextControl(Me.txtDonorAddr, True, True, True, True)
        Else
            Me.IsDirty = True
            SetApplyButtonEnabled(sender, e)
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txtDonorCity_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDonorCity.KeyUp
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            txtDonorCity.DeselectAll()
            Me.SplitContainer1.Panel2.SelectNextControl(Me.txtDonorCity, True, True, True, True)
        Else
            Me.IsDirty = True
            SetApplyButtonEnabled(sender, e)
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txtDonorState_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDonorState.KeyUp
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            txtDonorState.DeselectAll()
            Me.SplitContainer1.Panel2.SelectNextControl(Me.txtDonorState, True, True, True, True)
        Else
            Me.IsDirty = True
            SetApplyButtonEnabled(sender, e)
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txtDonorZip_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDonorZip.KeyUp
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            txtDonorZip.DeselectAll()
            Me.SplitContainer1.Panel2.SelectNextControl(Me.txtDonorZip, True, True, True, True)
        Else
            Me.IsDirty = True
            SetApplyButtonEnabled(sender, e)
        End If
        e.SuppressKeyPress = True
    End Sub

#End Region

    Private Sub btnCheckApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckApply.Click
        If btnCheckApply.InvokeRequired Then
            Me.BeginInvoke(New GenericCallback(AddressOf btnCheckApply_Click))
        Else
            Me.OnCheckviewApply(sender, e)
        End If
    End Sub

    Private Sub CheckViewerReceiptInfoPanel_CheckviewResetClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCheckReset.Click
        Me.OnCheckviewReset(sender, e)
    End Sub

    Private Sub CheckViewerReceiptInfoPanel_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.txtDonorAddr.Focus()
    End Sub
End Class
