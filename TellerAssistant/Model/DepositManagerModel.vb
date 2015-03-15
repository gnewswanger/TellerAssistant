Imports System.IO
Imports System.Xml

''' <summary>
''' This class serves as the main model for Model-View-Controller (MVC) 
''' </summary>
''' <remarks>Main model</remarks>
''' <author>Galen Newswanger</author>
Public Class DepositManagerModel
    Inherits mvcLibrary.mvcAbstractModel

#Region "Private Class Variable Declarations"

    Private _depTicket As DepositTicketClass
    Private _chkRegister As TellerAssistant2012.CheckRegisterClass

    Private _imageSize As Size

    Private _checkScanner As ICheckScanner
    Private _db As DataClass
    Private _printer As DepositReport
    Private _viewMode As ViewMode

#End Region

#Region "Class Properties"
    Public Property ConnectionMode() As ConnectionType
        Get
            If _checkScanner IsNot Nothing Then
                Return _checkScanner.ConnectionMode
            End If
            Return CType([Enum].Parse(GetType(ConnectionType), My.Settings.ImageTransferMethod), ConnectionType)
            'Return CType(ReadSettingFromXml("/TellerAssistant/ImageTransferMethod"), ConnectionType)
        End Get
        Set(ByVal value As ConnectionType)
            If _checkScanner IsNot Nothing AndAlso _checkScanner.ConnectionMode <> value Then
                AttachScanner(value)
            End If
            My.Settings.ImageTransferMethod = [Enum].GetName(GetType(ConnectionType), value)
            'SetSettingToXml("/TellerAssistant/ImageTransferMethod", [Enum].GetName(GetType(ConnectionType), value))
        End Set
    End Property

    Public ReadOnly Property IsDepositTicketOpen() As Boolean
        Get
            Return Not _depTicket Is Nothing
        End Get
    End Property

    Public Property ViewerMode() As ViewMode
        Get
            Return Me._viewMode
        End Get
        Set(ByVal value As ViewMode)
            Me._viewMode = value
        End Set
    End Property
#End Region

    Public Sub New()
        MyBase.New()
        Me._db = DataClass.getInstance(Me, My.Settings.ConnectionString)
        Me._db.AttachObserver(Me)
    End Sub

    Private Sub AttachScanner(ByVal connType As ConnectionType)
        If connType = ConnectionType.ctFTP Then
            _checkScanner = CheckScannerClassFTP.getInstance(Me)
            NotifyObservers(Me, New StatusEventArgs(EventName.evnmScannerStatusChanged, ConnectionType.ctFTP, "MICR Attaching..."))
        ElseIf connType = ConnectionType.ctRS232 Then
            _checkScanner = CheckScannerClassRS232.getInstance(Me, _depTicket.CheckImagePath)
            'checkScanner = New CheckScannerClassRS232(Me, depTicket.CheckImagePath)
            NotifyObservers(Me, New StatusEventArgs(EventName.evnmScannerStatusChanged, ConnectionType.ctRS232, "MICR Attaching..."))
        End If
    End Sub

    Public Function GetDelayInterval() As Integer
        If _checkScanner IsNot Nothing AndAlso _checkScanner.Connected Then
            Return _checkScanner.DelayInterval
        Else
            Return -1
        End If
    End Function

    Public Sub SetDelayInterval(ByVal value As Integer)
        _checkScanner.DelayInterval = value
    End Sub

    Public Function GetBankAccountList() As List(Of BankAccountClass)
        Return _db.GetBankAccountClassList
    End Function

    Public Sub SetBankAccount(ByVal bnk As BankAccountClass)
        _db.SetBankAccountClass(bnk)
    End Sub

    Public Sub DeleteBankAccount(ByVal bnk As BankAccountClass)
        _db.DeleteBankAccount(bnk)
    End Sub

    Public Function GetDepositSummaryList(ByVal filterRange As Integer) As List(Of DepositTicketClass)
        If filterRange = -1 Then
            Return Nothing
        Else
            Return _db.GetDepositTicketList(filterRange)
        End If
    End Function

    Public Function GetDepositSummaryListViewItems(ByVal filterRange As Integer) As List(Of ListViewItem)
        If filterRange = -1 Then
            Return Nothing
        Else
            Return _db.GetDepositListViewCollection(filterRange)
        End If
    End Function

    Public Function GetCurrentTicket() As DepositTicketClass
        If _depTicket Is Nothing Then
            Return Nothing
        Else
            Return _db.GetDepositTicket(_depTicket.DepositNumber, False)
        End If
    End Function

    Public Function SetNewDepositTicket(ByVal depDate As DateTime, ByVal depDesc As String, ByVal bank As BankAccountClass) As DepositTicketClass
        Dim ticket As DepositTicketClass = New DepositTicketClass(_db.GetUniqueNo, depDate, depDesc, bank)
        Return SetDepositTicket(ticket)
    End Function

    Public Function SetDepositTicket(ByVal ticket As DepositTicketClass) As DepositTicketClass
        Me._depTicket = Me._db.SetDepositTicket(ticket)
        Me._chkRegister = New TellerAssistant2012.CheckRegisterClass(Me)
        Me._db.AttachObserver(_chkRegister)
        AttachScanner(CType([Enum].Parse(GetType(ConnectionType), My.Settings.ImageTransferMethod), ConnectionType))
        Me._chkRegister.CheckQueue(CheckStatus.csAmountPending) = Me.GetCheckListByStatus(CheckStatus.csAmountPending)
        Me._chkRegister.CheckQueue(CheckStatus.csEditPending) = Me.GetCheckListByStatus(CheckStatus.csEditPending)
        Me._chkRegister.CheckQueue(CheckStatus.csConfirmPending) = Me.GetCheckListByStatus(CheckStatus.csConfirmPending)
        Return Me._depTicket
    End Function

    Public Function GetDepositTicket(ByVal depNo As String) As DepositTicketClass
        Me._depTicket = Me._db.GetDepositTicket(depNo, False)
        NotifyObservers(Me, New DepositEventArgs(EventName.evnmDepositInfoChanged, Me._depTicket))
        Me._chkRegister = New TellerAssistant2012.CheckRegisterClass(Me)
        Me._db.AttachObserver(_chkRegister)
        AttachScanner(CType([Enum].Parse(GetType(ConnectionType), My.Settings.ImageTransferMethod), ConnectionType))
        Me._chkRegister.CheckQueue(CheckStatus.csAmountPending) = Me.GetCheckListByStatus(CheckStatus.csAmountPending)
        Me._chkRegister.CheckQueue(CheckStatus.csEditPending) = Me.GetCheckListByStatus(CheckStatus.csEditPending)
        Me._chkRegister.CheckQueue(CheckStatus.csConfirmPending) = Me.GetCheckListByStatus(CheckStatus.csConfirmPending)
        Return Me._depTicket
    End Function

    Public Function GetChecksTotal() As Single
        Dim retVal As Single
        If Not Me._depTicket Is Nothing Then
            retVal = Me._db.GetChecksDepositTotal(Me._depTicket.DepositNumber, False)
        Else
            retVal = 0.0
        End If
        Return retVal
    End Function

    Public Function GetCashTotal() As Single
        Dim retVal As Single
        If Not Me._depTicket Is Nothing Then
            retVal = Me._db.GetCashDepositTotal(Me._depTicket.DepositNumber, False) / 100
        Else
            retVal = 0.0
        End If
        Return retVal
    End Function

    Public Function GetDepositBalances() As DepositBalanceClass
        Dim retClass As New DepositBalanceClass
        If Not Me._depTicket Is Nothing Then
            retClass.TotalCoins = Me._db.GetCoinDepositTotal(Me._depTicket.DepositNumber, False)
            retClass.TotalCurrency = Me._db.GetCurrencyDepositTotal(Me._depTicket.DepositNumber, False)
            retClass.TotalChecks = Me._db.GetChecksDepositTotal(Me._depTicket.DepositNumber, False)
        End If
        Return retClass
    End Function

    Public Function GetDepositCashList() As List(Of CashClass)
        Dim retList As New List(Of CashClass)
        Dim s As String = String.Empty
        Dim chtp As Type = GetType(CashType)
        For Each s In [Enum].GetNames(chtp)
            If Me._db.CashDenomExists(Me._depTicket.DepositNumber, CType([Enum].Parse(chtp, s), CashType)) Then
                retList.Add(Me._db.GetCashDenomClass(Me._depTicket.DepositNumber, CType([Enum].Parse(chtp, s), CashType)))
            End If
        Next
        Return retList
    End Function

    Public Sub SetCashClass(ByVal type As CashType, ByVal count As Integer)
        Dim cash As New CashClass(Me._depTicket.DepositNumber, type)
        cash.Count = count
        Me._db.SetCashDenomClass(cash)
    End Sub

    Public Function GetCheckQueueCount(ByVal queue As CheckStatus) As Integer
        Return Me._chkRegister.CheckQueueCount(queue)
    End Function

    Public Sub NextQueueCheck(ByVal queue As CheckStatus)
        Me._chkRegister.NextCheck = queue
    End Sub

    Public Sub PrevQueueCheck(ByVal queue As CheckStatus)
        Me._chkRegister.PreviousCheck = queue
    End Sub

    Public Sub FirstQueueCheck(ByVal queue As CheckStatus)
        Me._chkRegister.FirstCheck = queue
    End Sub

    Public Sub LastQueueCheck(ByVal queue As CheckStatus)
        Me._chkRegister.LastCheck = queue
    End Sub

    Public Function CurrentQueueCheck(ByVal queue As CheckStatus) As ChecksClass
        Return Me._chkRegister.CurrentQueueCheck(queue)
    End Function

    Public Sub ResetCheck(ByVal queue As CheckStatus)
        Me.NotifyObservers(Me, New CheckRegisterEventArgs(EventName.envmCurrentQueueCheckChanged, _chkRegister.CurrentQueueCheck(queue), _chkRegister.CurrentQueueCheck(queue), _chkRegister.CheckQueueCount(queue), _chkRegister.CheckQueueIndex(queue)))
    End Sub

    Public Sub UpdateCheckData(ByVal chkArgs As CheckDataEventArgs)
        Me._db.SetChecksClass(chkArgs, False)
    End Sub

    Public Sub UpdateCheckStatus(ByVal chkArgs As CheckDataEventArgs)
        Me._db.UpdateChecksClassStatus(chkArgs)
    End Sub

    Public Function GetCheckList() As List(Of ChecksClass)
        Dim retList As List(Of ChecksClass) = Me._db.GetDepositCheckList(Me._depTicket.DepositNumber)
        For Each itm As ChecksClass In retList
            If itm.ImageFullPath Is String.Empty Then
                itm.ImageFullPath = Me._depTicket.CheckImagePath
            End If
        Next
        Return retList
    End Function


    Public Function GetCheckListByStatus(ByVal chkStatus As CheckStatus) As List(Of ChecksClass)
        Dim retList As List(Of ChecksClass) = Nothing
        retList = Me._db.GetCheckListByStatus(Me._depTicket.DepositNumber, chkStatus)
        For Each itm As ChecksClass In retList
            If itm.ImageFullPath Is String.Empty Then
                itm.ImageFullPath = Me._depTicket.CheckImagePath
            End If
        Next
        Return retList
    End Function

    'Public Function HandleSearchRequest(ByVal searchArgs As SearchCriteriaClass) As List(Of ChecksClass)
    Public Function HandleSearchRequest(ByVal queryString As String) As List(Of ChecksClass)
        Dim retList As List(Of ChecksClass) = Me._db.HandleSearchRequest(queryString)
        For Each itm As ChecksClass In retList
            If (itm.ImageFullPath Is String.Empty And Me._depTicket IsNot Nothing) Then
                'TODO: Me._depTicket will return nothing if no deposit is open.  
                'Search may include multiple deposits and can't be limited to current open deposit.
                itm.ImageFullPath = Me._depTicket.CheckImagePath
            ElseIf (itm.ImageFullPath Is String.Empty And Me._depTicket Is Nothing) Then
                itm.ImageFullPath = String.Empty
            End If
        Next
        Return retList
    End Function

    Public Sub DeleteCheck(ByVal chk As ChecksClass, ByVal delImage As Boolean)
        Me._db.DeleteCheckDonation(chk, delImage)
    End Sub

    Public Function GetNewManualCheck() As ChecksClass
        Dim retVal As New ChecksClass(Me._depTicket.DepositNumber, "", "", "")
        retVal.ManualCheck = True
        retVal.ImageFile = My.Settings.ManualCheckName
        retVal.ImageFullPath = Me._depTicket.CheckImagePath
        retVal.Status = CheckStatus.csConfirmPending
        'Dim img As Image = [Image].FromFile(Application.StartupPath + "\" + retVal.ImageFile)
        Dim img As Image = [Image].FromHbitmap(My.Resources.ManualCheck200dpi.GetHbitmap)
        If Not File.Exists(retVal.ImageFullPath + retVal.ImageFile) Then
            img.Save(retVal.ImageFullPath + retVal.ImageFile)
        End If
        Return retVal
    End Function

    Public Sub PrintDepositTicket()
        If _db.ChecksUnverifiedStatusExists(_depTicket.DepositNumber) Then
            MsgBox("Not all checks are verified! Use the queue tabs and check list to look for unverified checks and try again.")
        Else
            Dim detail As New DepositDetailClass
            detail.DepositSummary = Me._db.GetDepositTicket(Me._depTicket.DepositNumber, False)
            detail.CashClassList = GetDepositCashList()
            detail.CheckClassList = GetCheckList()
            Me._printer = New DepositReport(detail)
            Me._printer.AttachObserver(Me)
            Me._printer.PrintDepositTicket()
        End If
    End Sub

    Public Function GetDonorList() As List(Of DonorClass)
        Return Me._db.GetDonorInfo()
    End Function

    Public Sub SelectedDonorChanged(ByVal chk As ChecksClass)
        Me.NotifyObservers(Me, New DonorInfoEventArgs(EventName.evnmDbCheckDonorUpdated, Me._db.GetDonorInfo(chk.Donor)(0), chk.Status))
        'Me._chkRegister.CurrentDonorInformation = New DonorInfoEventArgs(EventName.evnmVwDonorInfoChanged, Me._db.GetDonorInfo(chk.Donor), chk.Status)
    End Sub

    Public Sub UpdateDonorInfo(ByVal donor As DonorClass)
        Me._db.SetDonorInformation(donor)
    End Sub

    Public Sub ResetScanner()
        If Me._checkScanner IsNot Nothing Then
            Me._checkScanner.ResetScanner = True
        End If
    End Sub

    Public Sub CloseScanner()
        If Me._checkScanner IsNot Nothing AndAlso Me._checkScanner.Connected Then
            Me._checkScanner.Close()
        End If
    End Sub

    Public Sub ToggleLogging()
        Dim isLoggingOn As Boolean = My.Settings.LoggingTurnedOn
        isLoggingOn = Not isLoggingOn
        My.Settings.LoggingTurnedOn = isLoggingOn
        NotifyObservers(Me, New StatusEventArgs(EventName.evnmEventLoggingChanged, Nothing, isLoggingOn.ToString))
    End Sub

    Private Sub CheckScannerErrorStatus(ByVal err As String, ByVal fname As String)
        Try
            Select Case err
                Case "S01"  'No MICR data: no transit and no account found
                    WriteToErrorLog("DepositManagerModel.vb", "Scanner Status Code", err.Trim, fname.Trim)
                    Dim player As New System.Media.SoundPlayer(My.Resources.NOTIFY)
                    player.Play()
                    If MsgBox("Scanner did not find MICR data. Do you want to accept this document without MICR data?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        Dim index As Integer = 1
                        fname = "TTANoMICR" + index.ToString
                        Do While File.Exists(Me._depTicket.CheckImagePath & fname + ".tif")
                            index += 1
                            fname = "TTANoMICR" + index.ToString
                        Loop
                    Else
                        Me._checkScanner.EnableScanner = True
                        Exit Sub
                    End If
                Case "S03"
                    WriteToErrorLog("DepositManagerModel.vb", "Scanner Status Code", err.Trim, fname.Trim)
                Case "S05", "S07", "S04", "S12"
                    'S05 = (Error: Red Indicator) No transit, bad character, bad length, bad digit
                    'S07 = (Error: Red Indicator) No account, bad character
                    'S04 = (Error: Red Indicator) Bad character in check number
                    'S04 = (Status: Green Indicator) No check number
                    'S12 = (Status: Green Indicator) Short Account (maybe caused by mis-parsed check#)
                    WriteToErrorLog("DepositManagerModel.vb", "Scanner Status Code", err.Trim, fname.Trim)
                    If fname.Length = 0 Then
                        Me._checkScanner.EnableScanner = True
                        Exit Sub
                    End If
                Case "S08"
                    WriteToErrorLog("DepositManagerModel.vb", "Scanner Status Code", err.Trim, fname.Trim)
                    If MsgBox("Canadian checks cannot be combined with US funds. Do you want to accept this document?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        Me._checkScanner.EnableScanner = True
                        Exit Sub
                    End If
                Case "S09"
                    WriteToErrorLog("DepositManagerModel.vb", "Scanner Status Code", err.Trim, fname.Trim)
                    If MsgBox("Mexican checks cannot be combined with US funds. Do you want to accept this document?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        Me._checkScanner.EnableScanner = True
                        Exit Sub
                    End If
                Case "S10"
                    WriteToErrorLog("DepositManagerModel.vb", "Scanner Status Code", err.Trim, fname.Trim)
                Case Else
                    WriteToErrorLog("DepositManagerModel.vb", "Scanner Status Code", err.Trim, fname.Trim)
                    Me._checkScanner.EnableScanner = True
                    Exit Sub
            End Select
        Catch ex As Exception
            MsgBox("Exception caught in DepositManagerModel.CheckScannerErrorStatus method. " + ex.Message)
        End Try
    End Sub

#Region "Baseclass Overrides"
    Public Overrides Sub UpdateData(ByVal NewEvent As mvcLibrary.mvcEventArgsBase)
        Try
            Select Case CType(NewEvent, AbstractEventArgs).Name
                '==evnmScannerStatusChanged==
                Case EventName.evnmScannerStatusChanged
                    NotifyObservers(Me, NewEvent)
                Case EventName.evnmScannerEnableChanged
                    NotifyObservers(Me, NewEvent)
                    '==evnmScannedImageReady==
                Case EventName.evnmScannedImageReady
                    Dim errStatus As String = CType(NewEvent, StatusEventArgs).micrText
                    errStatus = errStatus.Substring(errStatus.LastIndexOf("S"), 3)
                    Dim fname As String = CType(NewEvent, StatusEventArgs).micrText
                    fname = fname.Substring(0, fname.LastIndexOf("S"))
                    Try
                        If Not (errStatus = "S00" Or errStatus = "S11") Then
                            Me.CheckScannerErrorStatus(errStatus, fname)
                        End If
                        Try
                            Dim invalidChars As Char() = Path.GetInvalidFileNameChars
                            Dim editFname As String = fname
                            For i As Integer = 0 To fname.Count - 1
                                If invalidChars.Contains(fname(i)) Then
                                    Dim player As New System.Media.SoundPlayer(My.Resources.NOTIFY)
                                    player.Play()
                                    Dim invalChar As Char = fname(i)
                                    Dim newChar As Char
                                    MainModule.WriteToErrorLog("DepositManagerModel.vb", "Invalid Characters Found", invalChar, editFname)
                                    Do
                                        newChar = InputBox("The scanner could not read some characters on the check." + vbCr _
                                                 + "Please enter character to replace '" + invalChar + "' in sequence. " + editFname.Substring(0, i + 1), "Unrecognized characters")(0)

                                    Loop Until Not invalidChars.Contains(newChar) OrElse newChar = Nothing
                                    If newChar = Nothing Then
                                        MsgBox("Check scan has been cancelled.  Please rescan this check.")
                                        Me._checkScanner.EnableScanner = True
                                        Exit Sub
                                    ElseIf Not invalidChars.Contains(newChar) Then
                                        editFname = editFname.Remove(i, 1)
                                        editFname = editFname.Insert(i, newChar)
                                    End If
                                End If
                            Next i
                            fname = editFname + ".tif"
                            Me._checkScanner.TransmitImage(fname.Trim)
                            'CType(NewEvent, StatusEventArgs).micrText = editFname + ".tif"
                            'Me._checkScanner.TransmitImage(Trim(CType(NewEvent, StatusEventArgs).micrText))
                            Me.NotifyObservers(Me, NewEvent)
                        Catch excpt As Exception
                            MsgBox("Failed search for invalid scanned characters. " & excpt.Message)
                        End Try
                    Catch ex As Exception
                        MsgBox("Failed Select Case. Scan errorStatus = " & errStatus & ". " & ex.Message)
                    End Try
                    '==evnmScannedImageTransmitted==
                Case EventName.evnmScannedImageTransmitted
                    Dim strs() As String = Trim(CType(NewEvent, StatusEventArgs).micrText).Split(New [Char]() {"T"c, "A"c, "S"c, "."c})
                    Dim chk As New ChecksClass(Me._depTicket.DepositNumber, strs(1), strs(2), strs(3), Me._depTicket.DepositDate)
                    chk.ImageFile = CType(NewEvent, StatusEventArgs).micrText
                    chk.ImageFullPath = Me._depTicket.CheckImagePath
                    chk.ManualCheck = False
                    Me._db.SetChecksClass(New CheckDataEventArgs(EventName.evnmCheckSearchResult, chk, chk), False)
                    If CType(NewEvent, StatusEventArgs).chkImage IsNot Nothing Then
                        Dim args As New CheckDataEventArgs(EventName.evnmScannedImageTransmitted, chk, chk, CType(NewEvent, StatusEventArgs).chkImage)
                        Me.NotifyObservers(Me, args)
                    Else
                        Dim args As New CheckDataEventArgs(EventName.evnmScannedImageTransmitted, chk, chk)
                        Me.NotifyObservers(Me, args)
                    End If
                    '==evnmCheckAmountChanged==
                    '==evnmCheckInserted==    '==evnmCheckUpdated==
                Case EventName.evnmCheckInserted, EventName.evnmCheckUpdated, EventName.evnmCheckStatusChanged
                    Me.NotifyObservers(Me, NewEvent)
                Case EventName.evnmCheckOnlyDeleted
                    Me.NotifyObservers(Me, NewEvent)
                    '==evnmCheckDeleted==
                Case EventName.evnmCheckDeleted
                    Try
                        File.Delete(CType(NewEvent, CheckDataEventArgs).Check.ImageFullPath + CType(NewEvent, CheckDataEventArgs).Check.ImageFile)
                        Me.NotifyObservers(Me, NewEvent)
                    Catch ex As Exception
                        MsgBox("Delete check image file failed. " + ex.Message)
                    End Try
                    '==envmCurrentQueueCheckChanged==
                Case EventName.envmCurrentQueueCheckChanged
                    Me.NotifyObservers(Me, NewEvent)
                    '==evnmDataTransactionFailed==
                Case EventName.evnmDataTransactionFailed
                    MsgBox("Data transaction failed. (Model)")
                    '==evnmDepositInfoChanged==
                Case EventName.evnmDepositInfoChanged
                    Me.NotifyObservers(Me, NewEvent)
                    '==evnmCashClassAdded==   '==evnmCashClassUpdated==
                Case EventName.evnmCashClassAdded, EventName.evnmCashClassUpdated
                    Me.NotifyObservers(Me, NewEvent)
                    '==evnmBankInfoChanged==
                Case EventName.evnmBankInfoChanged
                    Me.NotifyObservers(Me, NewEvent)
                    '==evnmBankInfoDeleted==
                Case EventName.evnmBankInfoDeleted
                    Me.NotifyObservers(Me, NewEvent)

                Case Else

            End Select
        Catch ex As Exception
            MsgBox("Exception caught in DepositManagerModel.UpdateData method. " + ex.Message)
        End Try
    End Sub

#End Region
End Class
