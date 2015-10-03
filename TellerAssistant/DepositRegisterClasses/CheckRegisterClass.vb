Public Class CheckRegisterClass
    Inherits mvcLibrary.mvcAbstractModel

    Private checkEntryQueue As TellerAssistant2012.CheckRegisterQueueClass
    Private checkEditQueue As TellerAssistant2012.CheckRegisterQueueClass
    Private checkConfirmQueue As TellerAssistant2012.CheckRegisterQueueClass
    Private checkVerifiedQueue As TellerAssistant2012.CheckRegisterQueueClass

#Region "Class Properties"

#Region "Navigation"
    Public WriteOnly Property NextCheck() As CheckStatus
        Set(ByVal value As CheckStatus)
            Select Case value
                Case CheckStatus.csAmountPending
                    Me.checkEntryQueue.NextCheck = CheckStatus.csAmountPending
                Case CheckStatus.csEditPending
                    Me.checkEditQueue.NextCheck = CheckStatus.csEditPending
                Case CheckStatus.csConfirmPending
                    Me.checkConfirmQueue.NextCheck = CheckStatus.csConfirmPending
                Case CheckStatus.csVerified
                    Me.checkVerifiedQueue.NextCheck = CheckStatus.csVerified
            End Select
        End Set
    End Property

    Public WriteOnly Property PreviousCheck() As CheckStatus
        Set(ByVal value As CheckStatus)
            Select Case value
                Case CheckStatus.csAmountPending
                    Me.checkEntryQueue.PreviousCheck = CheckStatus.csAmountPending
                Case CheckStatus.csEditPending
                    Me.checkEditQueue.PreviousCheck = CheckStatus.csEditPending
                Case CheckStatus.csConfirmPending
                    Me.checkConfirmQueue.PreviousCheck = CheckStatus.csConfirmPending
                Case CheckStatus.csVerified
                    Me.checkVerifiedQueue.PreviousCheck = CheckStatus.csVerified
            End Select
        End Set
    End Property

    Public WriteOnly Property FirstCheck() As CheckStatus
        Set(ByVal value As CheckStatus)
            Select Case value
                Case CheckStatus.csAmountPending
                    Me.checkEntryQueue.FirstCheck = CheckStatus.csAmountPending
                Case CheckStatus.csEditPending
                    Me.checkEditQueue.FirstCheck = CheckStatus.csEditPending
                Case CheckStatus.csConfirmPending
                    Me.checkConfirmQueue.FirstCheck = CheckStatus.csConfirmPending
                Case CheckStatus.csVerified
                    Me.checkVerifiedQueue.FirstCheck = CheckStatus.csVerified
            End Select
        End Set
    End Property

    Public WriteOnly Property LastCheck() As CheckStatus
        Set(ByVal value As CheckStatus)
            Select Case value
                Case CheckStatus.csAmountPending
                    Me.checkEntryQueue.LastCheck = CheckStatus.csAmountPending
                Case CheckStatus.csEditPending
                    Me.checkEditQueue.LastCheck = CheckStatus.csEditPending
                Case CheckStatus.csConfirmPending
                    Me.checkConfirmQueue.LastCheck = CheckStatus.csConfirmPending
                Case CheckStatus.csVerified
                    Me.checkVerifiedQueue.LastCheck = CheckStatus.csVerified
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
                Case CheckStatus.csVerified
                    Return Me.checkVerifiedQueue.CurrentQueueCheck
            End Select
            Return Nothing
        End Get
    End Property

#End Region


    Public Property CheckQueue(ByVal chkQueue As CheckStatus) As List(Of ChecksClass)
        Get
            Select Case chkQueue
                Case CheckStatus.csAmountPending
                    Return Me.checkEntryQueue.CheckQueue
                Case CheckStatus.csEditPending
                    Return Me.checkEditQueue.CheckQueue
                Case CheckStatus.csConfirmPending
                    Return Me.checkConfirmQueue.CheckQueue
                Case CheckStatus.csVerified
                    Return checkVerifiedQueue.CheckQueue
            End Select
            Return Nothing
        End Get
        Set(ByVal value As List(Of ChecksClass))
            Select Case chkQueue
                Case CheckStatus.csAmountPending
                    Me.checkEntryQueue.CheckQueue = value
                Case CheckStatus.csEditPending
                    Me.checkEditQueue.CheckQueue = value
                Case CheckStatus.csConfirmPending
                    Me.checkConfirmQueue.CheckQueue = value
                Case CheckStatus.csVerified
                    Me.checkVerifiedQueue.CheckQueue = value
            End Select
        End Set
    End Property

    Public ReadOnly Property CheckQueueCount(ByVal chkQueue As CheckStatus) As Integer
        Get
            Select Case chkQueue
                Case CheckStatus.csAmountPending
                    Return Me.checkEntryQueue.CheckQueueCount
                Case CheckStatus.csEditPending
                    Return Me.checkEditQueue.CheckQueueCount
                Case CheckStatus.csConfirmPending
                    Return Me.checkConfirmQueue.CheckQueueCount
                Case CheckStatus.csVerified
                    Return Me.checkVerifiedQueue.CheckQueueCount
            End Select
        End Get
    End Property

    Public ReadOnly Property CheckQueueIndex(ByVal chkQueue As CheckStatus) As Integer
        Get
            Select Case chkQueue
                Case CheckStatus.csAmountPending
                    Return Me.checkEntryQueue.CheckQueueIndex
                Case CheckStatus.csEditPending
                    Return Me.checkEditQueue.CheckQueueIndex
                Case CheckStatus.csConfirmPending
                    Return Me.checkConfirmQueue.CheckQueueIndex
                Case CheckStatus.csVerified
                    Return Me.checkVerifiedQueue.CheckQueueIndex
            End Select
        End Get
    End Property

#End Region

    Public Sub New(ByVal obs As mvcLibrary.IObserver)
        MyBase.New()
        Me.checkEntryQueue = New TellerAssistant2012.CheckRegisterQueueClass(CheckStatus.csAmountPending)
        Me.checkEntryQueue.AttachObserver(obs)
        Me.AttachObserver(Me.checkEntryQueue)
        Me.checkEditQueue = New TellerAssistant2012.CheckRegisterQueueClass(CheckStatus.csEditPending)
        Me.checkEditQueue.AttachObserver(obs)
        Me.AttachObserver(Me.checkEditQueue)
        Me.checkConfirmQueue = New TellerAssistant2012.CheckRegisterQueueClass(CheckStatus.csConfirmPending)
        Me.checkConfirmQueue.AttachObserver(obs)
        Me.AttachObserver(Me.checkConfirmQueue)
        Me.checkVerifiedQueue = New TellerAssistant2012.CheckRegisterQueueClass(CheckStatus.csVerified)
        checkVerifiedQueue.AttachObserver(obs)
        Me.AttachObserver(Me.checkVerifiedQueue)
    End Sub

    Public Overrides Sub UpdateData(ByVal NewEvent As mvcLibrary.mvcEventArgsBase)
        Select Case CType(NewEvent, AbstractEventArgs).Name
            Case EventName.evnmCheckInserted
                NotifyObservers(Me, NewEvent)
            Case EventName.evnmCheckDeleted, EventName.evnmCheckOnlyDeleted
                NotifyObservers(Me, NewEvent)
            Case EventName.evnmCheckUpdated, EventName.evnmCheckStatusChanged
                NotifyObservers(Me, NewEvent)
            Case EventName.evnmDbCheckDonorInserted, EventName.evnmDbCheckDonorUpdated
                NotifyObservers(Me, NewEvent)
        End Select
    End Sub
End Class
