Public Class CheckViewerEditPanel
    Inherits CheckViewerViewPanel

    Public Event CheckviewDeleteCurrentCheckOnly As GenericCallback


    Private Sub btnCheckApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckApply.Click
        If btnCheckApply.InvokeRequired Then
            Me.BeginInvoke(New GenericCallback(AddressOf btnCheckApply_Click))
        Else
            Dim appliedCheck As New ChecksClass(Me.UpdatedCheck)
            If appliedCheck.ManualCheck Then
                Dim updatedImage As New CheckImageClass(appliedCheck.ImageFullPath + My.Settings.ManualCheckName)
                updatedImage.DateText = appliedCheck.CheckDate.ToShortDateString
                updatedImage.RoutingText = appliedCheck.RoutingNo
                updatedImage.AccountText = appliedCheck.AccountNo
                updatedImage.CheckNumberText = appliedCheck.CheckNo
                updatedImage.AmountText = appliedCheck.CheckAmount.ToString("C")
                updatedImage.DonorText = appliedCheck.Donor
                appliedCheck.ImageFile = "MAN" + txtCheckBank.Text.Trim + txtCheckAcct.Text.Trim + txtCheckNo.Text.Trim + ".tif"
                updatedImage.CheckImage.Save(appliedCheck.ImageFullPath + appliedCheck.ImageFile)
            End If
            If appliedCheck.CheckAmount > 0 OrElse MsgBox("Check amount is " + appliedCheck.CheckAmount.ToString + ". Do you want to save changes and enter amount later?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If appliedCheck.ManualCheck AndAlso appliedCheck.RoutingNo.ToString + appliedCheck.AccountNo.ToString + appliedCheck.CheckNo.ToString <> _
                Me.OriginalCheck.RoutingNo.ToString + Me.OriginalCheck.AccountNo.ToString + Me.OriginalCheck.CheckNo.ToString Then
                    Dim eArgs As New CheckStatusEventArgs(EventName.evnmCheckUpdated, Me.OriginalCheck, CheckStatus.csNone)
                    RaiseEvent CheckviewDeleteCurrentCheckOnly(Me, eArgs)
                End If
                Me.UpdatedCheck = New ChecksClass(appliedCheck)
                If UpdatedCheck.CheckAmount > 0 Then
                    UpdatedCheck.Status = CheckStatus.csConfirmPending
                Else
                    UpdatedCheck.Status = CheckStatus.csAmountPending
                End If
                Me.OnCheckviewApply(sender, e)
            End If
            Me.txtCheckAmt.Focus()
            Me.txtCheckAmt.SelectAll()
        End If
    End Sub

    Private Sub btnCheckReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckReset.Click
        If MsgBox("You are about to reset to original settings. You will loose any changes. Do you want to continue?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            '_currCheck = _updatedCheck
            Me.OnCheckviewReset(sender, e)
        End If
        txtCheckAmt.Focus()
    End Sub

    Private Sub txtCheckAmt_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCheckAmt.KeyUp
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            If Me.ApplyonEntryKey Then
                Me.UpdatedCheck.CheckAmount = CSng(txtCheckAmt.Text)
                Me.btnCheckApply_Click(sender, e)
            End If
        End If
    End Sub
End Class
