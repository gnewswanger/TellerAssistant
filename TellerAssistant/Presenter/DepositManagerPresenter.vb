Imports System.IO

Public Class DepositManagerPresenter
    Inherits mvcLibrary.mvcAbstractPresenter

    Private _myModel As DepositManagerModel = CType(MyBase.BaseModel, DepositManagerModel)

    Public Sub New(ByVal aView As IViewFrmMain)
        MyBase.New(aView, New DepositManagerModel())
        MyBase.BaseModel.AttachObserver(Me)
    End Sub

    Public ReadOnly Property IsTicketOpen() As Boolean
        Get
            Return Me._myModel.IsDepositTicketOpen
        End Get
    End Property

    Public Sub SetScannerConnection()
        Me._myModel.ConnectionMode = CType(View, IViewFrmMain).ScannerConnectionMode
    End Sub

    Public Sub SetBankList()
        CType(View, IViewFrmMain).ListViewBanks = GetBankList()
        If Me._myModel.GetCurrentTicket IsNot Nothing Then
            CType(View, IViewFrmMain).SelectedBank = Me._myModel.GetCurrentTicket.BankInfo
        End If
    End Sub

    Public Function GetBankList() As List(Of BankAccountClass)
        Return (Me._myModel.GetBankAccountList)
    End Function

    Public Sub DeleteBank(ByVal acct As BankAccountClass)
        Me._myModel.DeleteBankAccount(acct)
        SetBankList()
    End Sub

    Public Function GetCheckList() As List(Of ChecksClass)
        Return Me._myModel.GetCheckList
    End Function

    Public Sub SetDepositSummaryList()
        CType(View, IViewFrmMain).ListViewDeposits = Me._myModel.GetDepositSummaryList(CType(View, IViewFrmMain).FilterYTDIsChecked)
    End Sub

    Public Sub SetDepositTicket(ByVal depDate As DateTime, ByVal depDesc As String, ByVal bank As BankAccountClass)
        Me._myModel.SetNewDepositTicket(depDate, depDesc, bank)
        CType(Me.View, IViewFrmMain).Donorlist = Me._myModel.GetDonorList
    End Sub
    Public Sub SetDepositTicket(ByVal depTicket As DepositTicketClass)
        Me._myModel.SetDepositTicket(depTicket)
        CType(Me.View, IViewFrmMain).Donorlist = Me._myModel.GetDonorList
    End Sub
    Public Function GetDepositTotals() As DepositBalanceClass
        Return Me._myModel.GetDepositBalances
    End Function
    Public Sub SetCashCount(ByVal type As CashType, ByVal count As Integer)
        Me._myModel.SetCashClass(type, count)
    End Sub
    Public Sub InitializeCashText()
        Dim list As List(Of CashClass) = Me._myModel.GetDepositCashList()
        For Each item As CashClass In list
            CType(View, IViewFrmMain).CashTextCount = item
        Next
        CType(View, IViewFrmMain).DepositTotals = GetDepositTotals()
        CType(View, IViewFrmMain).Checklist = GetCheckList()
    End Sub

#Region "Check Queue Navigation"

    Public Sub DisplayNextCheck(ByVal queue As CheckStatus)
        Me._myModel.NextQueueCheck(queue)
    End Sub
    Public Sub DisplayPrevCheck(ByVal queue As CheckStatus)
        Me._myModel.PrevQueueCheck(queue)
    End Sub

    Public Sub DisplayFirstCheck(ByVal queue As CheckStatus)
        Me._myModel.FirstQueueCheck(queue)
    End Sub

    Public Sub DisplayLastCheck(ByVal queue As CheckStatus)
        Me._myModel.LastQueueCheck(queue)
    End Sub

#End Region

    Public Sub EditDonorInformation(ByRef checkArgs As CheckRegisterEventArgs)
        Dim dlg As New FormDonorInformation(Me, checkArgs)
        If dlg.ShowDialog() = DialogResult.OK Then
            CType(View, IViewFrmMain).CheckImage = checkArgs
        End If
    End Sub

    Public Sub SelectedDonorChanged(ByVal chk As ChecksClass)
        Me._myModel.SelectedDonorChanged(chk)
    End Sub

    Public Sub UpdateDonorInfo(ByVal donor As DonorClass)
        Me._myModel.UpdateDonorInfo(donor)
    End Sub

    Public Sub UpdateCheckData(ByVal chkArgs As CheckDataEventArgs)
        Me._myModel.UpdateCheckData(chkArgs)
    End Sub

    Public Sub UpdateCheckStatus(ByVal chkArgs As CheckDataEventArgs)
        Me._myModel.UpdateCheckStatus(chkArgs)
    End Sub

    Public Sub DeleteCheck(ByVal chk As ChecksClass, ByVal delImage As Boolean)
        Me._myModel.DeleteCheck(chk, delImage)
    End Sub

    Public Sub ResetCheck(ByVal queue As CheckStatus)
        Me._myModel.ResetCheck(queue)
    End Sub

    Public Sub PrintDepositTicket()
        Me._myModel.PrintDepositTicket()
    End Sub

    Public Sub ResetScanner()
        Me._myModel.ResetScanner()
    End Sub

    Public Sub CloseScanner()
        Me._myModel.CloseScanner()
    End Sub

    Public Sub SetScannerDelay(ByVal value As Integer)
        Me._myModel.SetDelayInterval(value)
    End Sub

    Public Function GetNewCheck() As ChecksClass
        Return Me._myModel.GetNewManualCheck
    End Function

    Private Sub OnBankAccountUpdated(ByVal sender As Object, ByVal e As BankAccountEventArgs)
        Select Case e.Name
            Case EventName.evnmBankInfoChanged
                Me._myModel.SetBankAccount(e.BankAccount)
                SetBankList()
                If sender IsNot Nothing Then
                    CType(sender, TellerAssistant2012.FormSelectBank).InitializeList(GetBankList)
                End If
            Case EventName.evnmBankInfoDeleted
                DeleteBank(e.BankAccount)
                If sender IsNot Nothing Then
                    CType(sender, TellerAssistant2012.FormSelectBank).InitializeList(GetBankList)
                End If
        End Select
    End Sub

    Public Sub AddEditBanks()
        Dim dlg As New FormSelectBank
        AddHandler FormSelectBank.BankAccountEvent, AddressOf OnBankAccountUpdated
        dlg.InitializeList(GetBankList)
        dlg.ShowDialog()
    End Sub

    Public Sub SearchForChecks()
        Dim dlg As FormCheckSearch
        dlg = New FormCheckSearch(Me._myModel)
        dlg.Show()
    End Sub

    Public Sub ToggleLogging()
        Me._myModel.ToggleLogging()
    End Sub
    Public Sub UpdateViewerMode(ByVal mode As ViewMode)
        Me._myModel.ViewerMode = mode
    End Sub

#Region "Baseclass Overrides"

    Public Overrides Sub UpdateData(ByVal NewEvent As mvcLibrary.mvcEventArgsBase)
        Select Case CType(NewEvent, AbstractEventArgs).Name
            Case EventName.evnmEventLoggingChanged
                CType(View, IViewFrmMain).LoggingToggle = CBool(CType(NewEvent, StatusEventArgs).micrText)
                '==evnmScannerStatusChanged()==
            Case EventName.evnmScannerStatusChanged
                CType(View, IViewFrmMain).MICRStatusFlyout = CType(NewEvent, StatusEventArgs).micrText + vbCr
                CType(View, IViewFrmMain).PortTypeIcon = CType(NewEvent, StatusEventArgs).portType
                Dim delay As Integer = Me._myModel.GetDelayInterval
                If delay <> -1 Then
                    CType(View, IViewFrmMain).DelayInterval = delay
                End If
            Case EventName.evnmScannerEnableChanged
                Dim value As ScannerStatus = CType([Enum].Parse(GetType(ScannerStatus), CType(NewEvent, StatusEventArgs).micrText), ScannerStatus)
                Select Case value
                    Case ScannerStatus.ssNonMICREnabled
                    Case ScannerStatus.ssNonMICRDisabled

                    Case ScannerStatus.ssScanEnabled
                        CType(View, IViewFrmMain).ScannerEnabled = True
                    Case ScannerStatus.ssScanDisabled
                        CType(View, IViewFrmMain).ScannerEnabled = False
                End Select
                '==evnmScannedImageReady()==
            Case EventName.evnmScannedImageReady
                CType(View, IViewFrmMain).MICRStatusFlyout = CType(NewEvent, StatusEventArgs).micrText + vbCr
                '==evnmScannedImageTransmitted()==
            Case EventName.evnmScannedImageTransmitted
                If CType(NewEvent, CheckDataEventArgs).currImage IsNot Nothing Then
                    CType(View, IViewFrmMain).CheckImageFlyout = CType(NewEvent, CheckDataEventArgs).currImage
                Else
                    Dim fName As String = CType(NewEvent, CheckDataEventArgs).Check.ImageFullPath + CType(NewEvent, CheckDataEventArgs).Check.ImageFile
                    'Threading.Thread.Sleep(500)
                    If File.Exists(fName) AndAlso FileNotInUse(fName) Then
                        Dim img As New Bitmap(fName)
                        CType(View, IViewFrmMain).CheckImageFlyout = img
                        img.Dispose()
                    Else
                        Threading.Thread.Sleep(500)
                        If FileNotInUse(fName) Then
                            Dim img As New Bitmap(fName)
                            CType(View, IViewFrmMain).CheckImageFlyout = img
                        End If
                        CType(View, IViewFrmMain).CheckImageFlyout = Nothing
                    End If
                End If
                ''==evnmCheckAmountChanged()==
                '==evnmCheckInserted()==
                '==evnmCheckDeleted()==
            Case EventName.evnmCheckOnlyDeleted

            Case EventName.evnmCheckDeleted

                '==evnmCheckUpdated()==
                '==envmCurrentQueueCheckChanged()==
            Case EventName.envmCurrentQueueCheckChanged
                CType(View, IViewFrmMain).Checklist = GetCheckList()
                CType(View, IViewFrmMain).DepositTotals = GetDepositTotals()
                CType(View, IViewFrmMain).CheckImage = CType(NewEvent, CheckRegisterEventArgs)
                '==evnmDataTransactionFailed()==
            Case EventName.evnmDataTransactionFailed
                MsgBox("Data Transaction failed. (Presenter)")
                '==evnmCashClassAdded()==   '==evnmCashClassUpdated()==
            Case EventName.evnmCashClassAdded, EventName.evnmCashClassUpdated
                CType(View, IViewFrmMain).CashText = (CType(NewEvent, CashEventArgs).Cash)
                CType(View, IViewFrmMain).Checklist = GetCheckList()
                CType(View, IViewFrmMain).DepositTotals = GetDepositTotals()
                '==evnmDepositInfoChanged()==
            Case EventName.evnmDepositInfoChanged
                CType(View, IViewFrmMain).DepositTicket = CType(NewEvent, DepositEventArgs).DepositTicket
                '==evnmBankInfoChanged()==
            Case EventName.evnmBankInfoChanged
                SetBankList()
                '==evnmBankInfoDeleted()==
            Case EventName.evnmBankInfoDeleted
                SetBankList()
            Case EventName.evnmDbCheckDonorInserted, EventName.evnmDbCheckDonorUpdated
                CType(View, IViewFrmMain).Donorlist = Me._myModel.GetDonorList
        End Select
    End Sub

    Private Function FileNotInUse(ByVal fname As String) As Boolean
        Try
            Dim fs As New FileStream(fname, FileMode.Open, FileAccess.ReadWrite, FileShare.None)
            fs.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

#End Region

End Class
