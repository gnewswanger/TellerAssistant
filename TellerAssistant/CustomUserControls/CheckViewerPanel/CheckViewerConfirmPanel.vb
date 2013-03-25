Public Class CheckViewerConfirmPanel
    Inherits CheckViewerPanelBaseClass

    Delegate Sub GenericConfirmCallback(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Public Event CheckviewSkipClick As GenericConfirmCallback
    Public Event CheckviewApplyClick As GenericCallback

    Private Sub SetCurrentCheck(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.CheckviewSetCurrentCheck
        Dim args As CheckRegisterEventArgs = CType(e, CheckRegisterEventArgs)
        SetCheckPixImage()
        SetCheckAmtText(args.origCheck.CheckAmount.ToString("C"))
        Me.SetReceiptStatusFlag(Me.OriginalCheck.ReceiptRequest <> ReceiptRequestStatus.rrsNone)
    End Sub

    Private Sub SetCheckAmtText(ByVal text As String)
        If txtConfirmCheckAmt.InvokeRequired Then
            Me.BeginInvoke(New SetTextCallback(AddressOf SetCheckAmtText), text)
        Else
            txtConfirmCheckAmt.Text = text
        End If
    End Sub

    Private Sub SetReceiptStatusFlag(ByVal required As Boolean)
        If Me.picReceiptFlag.InvokeRequired Then
            Me.BeginInvoke(New SetBooleanCallback(AddressOf Me.SetReceiptStatusFlag), required)
        Else
            Me.picReceiptFlag.Visible = required
        End If
    End Sub

#Region "Button Click Methods"

    Private Sub btnConfirmCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirmCheck.Click
        Me.UpdatedCheck.Status = CheckStatus.csVerified
        RaiseEvent CheckviewApplyClick(sender, e)
        btnConfirmCheck.Focus()
    End Sub

    Private Sub btnSkipConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSkipConfirm.Click
        RaiseEvent CheckviewSkipClick(sender, e)
        btnConfirmCheck.Focus()
    End Sub

    Private Sub btnEditCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditCheck.Click
        Me.UpdatedCheck.Status = CheckStatus.csEditPending
        RaiseEvent CheckviewApplyClick(sender, e)
        btnConfirmCheck.Focus()
    End Sub

#End Region

    Private Sub CheckConfirmPanel_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        btnConfirmCheck.Focus()
    End Sub

End Class
