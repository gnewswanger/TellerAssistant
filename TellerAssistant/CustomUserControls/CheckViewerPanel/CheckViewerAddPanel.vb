Public Class CheckViewerAddPanel
    Inherits CheckViewerViewPanel


    Public Event CheckviewDeleteCurrentCheckOnly As GenericCallback

    Private _manualCheckImage As CheckImageClass

#Region "Button Enabled Methods"

    'Private Sub SetApplyButtonEnabled()
    '    btnCheckApply.Enabled = Me.IsDirty
    'End Sub

    Private Sub btnCheckApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckApply.Click
        Dim newFilename As String = txtCheckBank.Text.Trim + txtCheckAcct.Text.Trim + txtCheckNo.Text.Trim
        If newFilename = "" Then
            MsgBox("You must enter at least a check number.")
            txtCheckNo.Focus()
        Else
            newFilename = "MAN" + newFilename + ".tif"
            Me.UpdatedCheck.ImageFile = newFilename
            'Me.OriginalCheck = Me.UpdatedCheck
            'Me.UpdatedCheck = Nothing
            Me._manualCheckImage.CheckImage.Save(Me.UpdatedCheck.ImageFullPath & Me.UpdatedCheck.ImageFile)
            If UpdatedCheck.CheckAmount > 0 Then
                UpdatedCheck.Status = CheckStatus.csConfirmPending
            Else
                UpdatedCheck.Status = CheckStatus.csAmountPending
            End If
            Me.OnCheckviewApply(sender, e)
        End If
    End Sub

    Private Sub btnCheckReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckReset.Click
        If MsgBox("You are about to cancel inputing. Any data already input will be lost. Do you want to continue?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Me.UpdatedCheck = New ChecksClass(Me.OriginalCheck)
            Me.OnCheckviewReset(sender, e)
        End If
        txtCheckAmt.Focus()
    End Sub

#End Region

#Region "Set Current Check"

    Protected Overrides Sub SetCheckPixImage()
        If InvokeRequired Then
            Me.Invoke(New SetImageCallback(AddressOf SetCheckPixImage))
        Else
            If Me.OriginalCheck Is Nothing OrElse Me.OriginalCheck.ImageFile Is Nothing Then
                Me.ImageViewerPanel1.Image = Nothing
            Else
                Dim fname As String = Me.OriginalCheck.ImageFullPath & Me.OriginalCheck.ImageFile
                Me._manualCheckImage = New CheckImageClass(fname)
                Me.ImageViewerPanel1.Image = Me._manualCheckImage.CheckImage
            End If
        End If
    End Sub

#End Region

#Region "TextChanged Events"

    Private Sub txtCheckBank_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCheckBank.TextChanged
        If Me._manualCheckImage IsNot Nothing Then
            Me._manualCheckImage.RoutingText = txtCheckBank.Text
            Me.ImageViewerPanel1.Image = Me._manualCheckImage.CheckImage
            Me.UpdatedCheck.RoutingNo = txtCheckBank.Text.Trim
        End If
    End Sub

    Private Sub txtCheckAcct_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCheckAcct.TextChanged
        If Me._manualCheckImage IsNot Nothing Then
            Me._manualCheckImage.AccountText = txtCheckAcct.Text
            Me.ImageViewerPanel1.Image = Me._manualCheckImage.CheckImage
            Me.UpdatedCheck.AccountNo = txtCheckAcct.Text.Trim
        End If
    End Sub

    Private Sub txtCheckNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCheckNo.TextChanged
        If Me._manualCheckImage IsNot Nothing Then
            Me._manualCheckImage.CheckNumberText = txtCheckNo.Text
            Me.ImageViewerPanel1.Image = Me._manualCheckImage.CheckImage
            Me.UpdatedCheck.CheckNo = Me.txtCheckNo.Text.Trim
        End If
    End Sub

    Private Sub txtCheckAmt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCheckAmt.TextValueChanged
        If Me._manualCheckImage IsNot Nothing Then
            Me._manualCheckImage.AmountText = txtCheckAmt.Text
            Me.ImageViewerPanel1.Image = Me._manualCheckImage.CheckImage
            txtCheckAmt.Modified = True
            UpdatedCheck.CheckAmount = CSng(Me.txtCheckAmt.Text)
        End If
    End Sub

    Private Sub dtpCheckDate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpCheckDate.ValueChanged
        If Me._manualCheckImage IsNot Nothing Then
            Me._manualCheckImage.DateText = dtpCheckDate.Text
            Me.ImageViewerPanel1.Image = Me._manualCheckImage.CheckImage
            Me.UpdatedCheck.CheckDate = dtpCheckDate.Value
        End If
    End Sub

    Private Sub txtCheckDonor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me._manualCheckImage IsNot Nothing Then
            Me._manualCheckImage.DonorText = Me.comboDonor.Text
            Me.ImageViewerPanel1.Image = Me._manualCheckImage.CheckImage
            Me.UpdatedCheck.DonorInfo.Donor = Me.comboDonor.Text.Trim
        End If
    End Sub

#End Region

End Class
