Imports System.IO

Public Class CheckRegisterClass
    Inherits mvcLibrary.mvcAbstractModel

    Private checkEntryQueue As TellerAssistant2012.CheckRegisterQueueClass
    Private checkEditQueue As TellerAssistant2012.CheckRegisterQueueClass
    Private checkConfirmQueue As TellerAssistant2012.CheckRegisterQueueClass


#Region "Class Properties"

#Region "Navigation"
    Public WriteOnly Property NextCheck() As CheckStatus
        Set(ByVal value As CheckStatus)
            Select Case value
                Case CheckStatus.csAmountPending
                    Me.NotifyObservers(Me, Me.checkEntryQueue.NextCheck(CheckStatus.csAmountPending))
                Case CheckStatus.csEditPending
                    Me.NotifyObservers(Me, Me.checkEditQueue.NextCheck(CheckStatus.csEditPending))
                Case CheckStatus.csConfirmPending
                    Me.NotifyObservers(Me, Me.checkConfirmQueue.NextCheck(CheckStatus.csConfirmPending))
            End Select
        End Set
    End Property

    Public WriteOnly Property PreviousCheck() As CheckStatus
        Set(ByVal value As CheckStatus)
            Select Case value
                Case CheckStatus.csAmountPending
                    Me.NotifyObservers(Me, Me.checkEntryQueue.PreviousCheck(CheckStatus.csAmountPending))
                Case CheckStatus.csEditPending
                    Me.NotifyObservers(Me, Me.checkEditQueue.PreviousCheck(CheckStatus.csEditPending))
                Case CheckStatus.csConfirmPending
                    Me.NotifyObservers(Me, Me.checkConfirmQueue.PreviousCheck(CheckStatus.csConfirmPending))
            End Select
        End Set
    End Property

    Public WriteOnly Property FirstCheck() As CheckStatus
        Set(ByVal value As CheckStatus)
            Select Case value
                Case CheckStatus.csAmountPending
                    Me.NotifyObservers(Me, Me.checkEntryQueue.FirstCheck(CheckStatus.csAmountPending))
                Case CheckStatus.csEditPending
                    Me.NotifyObservers(Me, Me.checkEditQueue.FirstCheck(CheckStatus.csEditPending))
                Case CheckStatus.csConfirmPending
                    Me.NotifyObservers(Me, Me.checkConfirmQueue.FirstCheck(CheckStatus.csConfirmPending))
            End Select
        End Set
    End Property

    Public WriteOnly Property LastCheck() As CheckStatus
        Set(ByVal value As CheckStatus)
            Select Case value
                Case CheckStatus.csAmountPending
                    Me.NotifyObservers(Me, Me.checkEntryQueue.LastCheck(CheckStatus.csAmountPending))
                Case CheckStatus.csEditPending
                    Me.NotifyObservers(Me, Me.checkEditQueue.LastCheck(CheckStatus.csEditPending))
                Case CheckStatus.csConfirmPending
                    Me.NotifyObservers(Me, Me.checkConfirmQueue.LastCheck(CheckStatus.csConfirmPending))
            End Select
        End Set
    End Property

    Public ReadOnly Property CurrentQueueCheck(ByVal chkQueue As CheckStatus) As ChecksClass
        Get
            Select Case chkQueue
                Case CheckStatus.csAmountPending
                    Return Me.checkEntryQueue.CurrentQueueCheck
                Case CheckStatus.csEditPending
                    Return Me.checkEditQueue.CurrentQueueCheck
                Case CheckStatus.csConfirmPending
                    Return Me.checkConfirmQueue.CurrentQueueCheck
            End Select
            Return Nothing
        End Get
    End Property

#End Region


    Public Property ChecksQueue(ByVal chksQueue As CheckStatus) As List(Of ChecksClass)
        Get
            Select Case chksQueue
                Case CheckStatus.csAmountPending
                    Return Me.checkEntryQueue.ChecksQueue
                Case CheckStatus.csEditPending
                    Return Me.checkEditQueue.ChecksQueue
                Case CheckStatus.csConfirmPending
                    Return Me.checkConfirmQueue.ChecksQueue
            End Select
            Return Nothing
        End Get
        Set(ByVal value As List(Of ChecksClass))
            Select Case chksQueue
                Case CheckStatus.csAmountPending
                    Me.checkEntryQueue.ChecksQueue = value
                    Me.NotifyObservers(Me, New CheckRegisterEventArgs(EventName.evnmVwCurrentQueueCheckChanged, _
                                                                      Me.checkEntryQueue.CurrentQueueCheck, Me.checkEntryQueue.CurrentQueueCheck, _
                                                                      Me.checkEntryQueue.CheckQueueCount, Me.checkEntryQueue.CheckQueueIndex))
                Case CheckStatus.csEditPending
                    Me.checkEditQueue.ChecksQueue = value
                    Me.NotifyObservers(Me, New CheckRegisterEventArgs(EventName.evnmVwCurrentQueueCheckChanged, _
                                                                      Me.checkEditQueue.CurrentQueueCheck, Me.checkEditQueue.CurrentQueueCheck, _
                                                                      Me.checkEditQueue.CheckQueueCount, Me.checkEditQueue.CheckQueueIndex))
                Case CheckStatus.csConfirmPending
                    Me.checkConfirmQueue.ChecksQueue = value
                    Me.NotifyObservers(Me, New CheckRegisterEventArgs(EventName.evnmVwCurrentQueueCheckChanged, _
                                                                      Me.checkConfirmQueue.CurrentQueueCheck, Me.checkConfirmQueue.CurrentQueueCheck, _
                                                                      Me.checkConfirmQueue.CheckQueueCount, Me.checkConfirmQueue.CheckQueueIndex))
            End Select
        End Set
    End Property

    Public ReadOnly Property CheckQueueCount(ByVal chksQueue As CheckStatus) As Integer
        Get
            Select Case chksQueue
                Case CheckStatus.csAmountPending
                    Return Me.checkEntryQueue.CheckQueueCount
                Case CheckStatus.csEditPending
                    Return Me.checkEditQueue.CheckQueueCount
                Case CheckStatus.csConfirmPending
                    Return Me.checkConfirmQueue.CheckQueueCount
            End Select
        End Get
    End Property

    Public ReadOnly Property CheckQueueIndex(ByVal chksQueue As CheckStatus) As Integer
        Get
            Select Case chksQueue
                Case CheckStatus.csAmountPending
                    Return Me.checkEntryQueue.CheckQueueIndex
                Case CheckStatus.csEditPending
                    Return Me.checkEditQueue.CheckQueueIndex
                Case CheckStatus.csConfirmPending
                    Return Me.checkConfirmQueue.CheckQueueIndex
            End Select
        End Get
    End Property

    Private Function RemoveCheck(args As CheckDataEventArgs) As Boolean
        Dim retVal As Boolean = False
        If Me.checkEntryQueue.RemoveCheck(args) Then
            retVal = True
            NotifyObservers(Me, New CheckRegisterEventArgs(EventName.evnmVwCurrentQueueCheckChanged, _
                                                           Me.checkEntryQueue.CurrentQueueCheck, Me.checkEntryQueue.CurrentQueueCheck, _
                                                           Me.checkEntryQueue.CheckQueueCount, Me.checkEntryQueue.CheckQueueIndex))
        ElseIf Me.checkEditQueue.RemoveCheck(args) Then
            retVal = True
            NotifyObservers(Me, New CheckRegisterEventArgs(EventName.evnmVwCurrentQueueCheckChanged, _
                                                           Me.checkEditQueue.CurrentQueueCheck, Me.checkEditQueue.CurrentQueueCheck, _
                                                           Me.checkEditQueue.CheckQueueCount, Me.checkEditQueue.CheckQueueIndex))
        ElseIf Me.checkConfirmQueue.RemoveCheck(args) Then
            retVal = True
            NotifyObservers(Me, New CheckRegisterEventArgs(EventName.evnmVwCurrentQueueCheckChanged, _
                                                           Me.checkConfirmQueue.CurrentQueueCheck, Me.checkConfirmQueue.CurrentQueueCheck, _
                                                           Me.checkConfirmQueue.CheckQueueCount, Me.checkConfirmQueue.CheckQueueIndex))
        End If
        Return retVal
    End Function

    Private Function AddCheck(args As CheckDataEventArgs) As Boolean
        Dim retVal As Boolean = False
        If Me.checkEntryQueue.AddCheck(args) Then
            retVal = True
            NotifyObservers(Me, New CheckRegisterEventArgs(EventName.evnmVwCurrentQueueCheckChanged, _
                                                           Me.checkEntryQueue.CurrentQueueCheck, Me.checkEntryQueue.CurrentQueueCheck, _
                                                           Me.checkEntryQueue.CheckQueueCount, Me.checkEntryQueue.CheckQueueIndex))
        ElseIf Me.checkEditQueue.AddCheck(args) Then
            retVal = True
            NotifyObservers(Me, New CheckRegisterEventArgs(EventName.evnmVwCurrentQueueCheckChanged, _
                                                           Me.checkEditQueue.CurrentQueueCheck, Me.checkEditQueue.CurrentQueueCheck, _
                                                           Me.checkEditQueue.CheckQueueCount, Me.checkEditQueue.CheckQueueIndex))
        ElseIf Me.checkConfirmQueue.AddCheck(args) Then
            retVal = True
            NotifyObservers(Me, New CheckRegisterEventArgs(EventName.evnmVwCurrentQueueCheckChanged, _
                                                           Me.checkConfirmQueue.CurrentQueueCheck, Me.checkConfirmQueue.CurrentQueueCheck, _
                                                           Me.checkConfirmQueue.CheckQueueCount, Me.checkConfirmQueue.CheckQueueIndex))
        End If
        Return retVal
    End Function

    Private Function UpdateDonorInfo(args As CheckDataEventArgs) As Boolean
        Dim retVal As Boolean = False
        If Me.checkEntryQueue.UpdateDonorInfo(args) Then
            retVal = True
            NotifyObservers(Me, New CheckRegisterEventArgs(EventName.evnmVwDonorInfoChanged, _
                                                           Me.checkEntryQueue.CurrentQueueCheck, Me.checkEntryQueue.CurrentQueueCheck, _
                                                           Me.checkEntryQueue.CheckQueueCount, Me.checkEntryQueue.CheckQueueIndex))
        ElseIf Me.checkEditQueue.AddCheck(args) Then
            retVal = True
            NotifyObservers(Me, New CheckRegisterEventArgs(EventName.evnmVwDonorInfoChanged, _
                                                           Me.checkEditQueue.CurrentQueueCheck, Me.checkEditQueue.CurrentQueueCheck, _
                                                           Me.checkEditQueue.CheckQueueCount, Me.checkEditQueue.CheckQueueIndex))
        ElseIf Me.checkConfirmQueue.AddCheck(args) Then
            retVal = True
            NotifyObservers(Me, New CheckRegisterEventArgs(EventName.evnmVwDonorInfoChanged, _
                                                           Me.checkConfirmQueue.CurrentQueueCheck, Me.checkConfirmQueue.CurrentQueueCheck, _
                                                           Me.checkConfirmQueue.CheckQueueCount, Me.checkConfirmQueue.CheckQueueIndex))
        End If
        Return retVal
    End Function

    Public Sub ResetCheck(ByVal queue As CheckStatus)
        Me.NotifyObservers(Me, New CheckRegisterEventArgs(EventName.evnmVwCurrentQueueCheckChanged, Me.CurrentQueueCheck(queue), _
                                                          Me.CurrentQueueCheck(queue), Me.CheckQueueCount(queue), Me.CheckQueueIndex(queue)))
    End Sub

#End Region

    Public Sub New()
        MyBase.New()
        Me.checkEntryQueue = New TellerAssistant2012.CheckRegisterQueueClass(CheckStatus.csAmountPending)
        Me.checkEditQueue = New TellerAssistant2012.CheckRegisterQueueClass(CheckStatus.csEditPending)
        Me.checkConfirmQueue = New TellerAssistant2012.CheckRegisterQueueClass(CheckStatus.csConfirmPending)
    End Sub

    Public Overrides Sub UpdateData(ByVal NewEvent As mvcLibrary.mvcEventArgsBase)
        Select Case CType(NewEvent, AbstractEventArgs).Name
            Case EventName.evnmDbCheckInserted
                If Not AddCheck(CType(NewEvent, CheckDataEventArgs)) Then
                    MsgBox("Failed to add check to queue, " + CType(NewEvent, CheckDataEventArgs).Check.Status.ToString)
                End If

            Case EventName.evnmDbCheckDeleted, EventName.evnmDbCheckOnlyDeleted
                If Not Me.RemoveCheck(CType(NewEvent, CheckDataEventArgs)) Then
                    MsgBox("Failed to remove check from queue.")
                End If

            Case EventName.evnmDbCheckUpdated, EventName.evnmDbCheckStatusChanged
                If Not Me.RemoveCheck(CType(NewEvent, CheckDataEventArgs)) Then
                    MsgBox("Failed to remove check from queue.")
                End If
                If Not AddCheck(CType(NewEvent, CheckDataEventArgs)) Then
                    MsgBox("Failed to add check to queue, " + CType(NewEvent, CheckDataEventArgs).Check.Status.ToString)
                End If

            Case EventName.evnmDbCheckDonorInserted, EventName.evnmDbCheckDonorUpdated
                Me.UpdateDonorInfo(CType(NewEvent, CheckDataEventArgs))

            Case EventName.evnmDBDepositInfoChanged
                Me.NotifyObservers(Me, New DepositEventArgs(EventName.evnmVwDepositInfoChanged, CType(NewEvent, DepositEventArgs).DepositTicket))

            Case EventName.evnmDbCheckOnlyDeleted
                NotifyObservers(Me, New CheckDataEventArgs(EventName.evnmVWCheckOnlyDeleted, CType(NewEvent, CheckDataEventArgs).Check, CType(NewEvent, CheckDataEventArgs).Check))

            Case EventName.evnmDbCheckDeleted
                Try
                    File.Delete(CType(NewEvent, CheckDataEventArgs).Check.ImageFullPath + CType(NewEvent, CheckDataEventArgs).Check.ImageFile)
                    NotifyObservers(Me, New CheckDataEventArgs(EventName.evnmVwCheckDeleted, CType(NewEvent, CheckDataEventArgs).Check, CType(NewEvent, CheckDataEventArgs).Check))
                Catch ex As Exception
                    MsgBox("Delete check image file failed. " + ex.Message)
                End Try

            Case EventName.evnmBankInfoChanged
                NotifyObservers(Me, New BankAccountEventArgs(EventName.evnmBankInfoDeleted, CType(NewEvent, BankAccountEventArgs).BankAccount))

            Case EventName.evnmBankInfoDeleted
                NotifyObservers(Me, New BankAccountEventArgs(EventName.evnmBankInfoDeleted, CType(NewEvent, BankAccountEventArgs).BankAccount))

            Case EventName.evnmDbCashClassAdded, EventName.evnmDbCashClassUpdated
                NotifyObservers(Me, New CashEventArgs(EventName.evnmVwCashClassAdded, CType(NewEvent, CashEventArgs).Cash))

            Case EventName.evnmDbTransactionFailed
                MsgBox("Data transaction failed. (Model)")

        End Select
    End Sub
End Class
