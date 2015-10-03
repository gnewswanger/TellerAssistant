Public Class FormDonorInformation
    Implements IViewDonorInformation

    Private ctrlr As DepositManagerPresenter

    Public WriteOnly Property CheckImage() As CheckRegisterEventArgs Implements IViewDonorInformation.CheckImage
        Set(ByVal value As CheckRegisterEventArgs)
            CheckViewerReceiptInfoPanel1.CurrentCheckArgs = value
        End Set
    End Property

    Private Sub CheckViewerReceiptInfoPanel1_CheckviewApplyClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckViewerReceiptInfoPanel1.CheckviewApplyClick
        If CheckViewerReceiptInfoPanel1.CurrentCheckArgs IsNot Nothing And Me.CheckViewerReceiptInfoPanel1.Donor IsNot Nothing Then
            ctrlr.UpdateDonorInfo(Me.CheckViewerReceiptInfoPanel1.Donor)
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub CheckViewerReceiptInfoPanel1_CheckviewResetClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckViewerReceiptInfoPanel1.CheckviewResetClick
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub


    Public Sub New(ByRef control As DepositManagerPresenter, ByRef chkArg As CheckRegisterEventArgs)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.ctrlr = control
        Me.CheckViewerReceiptInfoPanel1.CurrentCheckArgs = chkArg
    End Sub

    Private Sub FormDonorInformation_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.CheckViewerReceiptInfoPanel1.txtCheckAmt.Enabled = False
        Me.CheckViewerReceiptInfoPanel1.txtDonorAddr.Focus()
    End Sub

End Class