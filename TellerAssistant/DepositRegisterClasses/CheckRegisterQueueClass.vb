Public Class CheckRegisterQueueClass
    Inherits mvcLibrary.mvcAbstractModel

    Delegate Sub SetCheckListCallback(ByVal value As List(Of ChecksClass))
    Private _checkQueue As New List(Of ChecksClass)
    Private _queueIndex As Integer
    Private _checkCountText As String = String.Empty
    Private _queueCheckStatus As CheckStatus

#Region "Class Properties"

    Public WriteOnly Property NextCheck() As CheckStatus
        Set(ByVal value As CheckStatus)
            If (Me._checkQueue.Count - 1) > Me._queueIndex Then
                Me._queueIndex += 1
            End If
            NotifyObservers(Me, New CheckRegisterEventArgs(EventName.envmCurrentQueueCheckChanged, Me.CurrentQueueCheck, Me.CurrentQueueCheck, Me.CheckQueueCount, Me.CheckQueueIndex))
        End Set
    End Property

    Public WriteOnly Property PreviousCheck() As CheckStatus
        Set(ByVal value As CheckStatus)
            If (Me._checkQueue.Count - 1) >= Me._queueIndex Then
                Me._queueIndex -= 1
            End If
            NotifyObservers(Me, New CheckRegisterEventArgs(EventName.envmCurrentQueueCheckChanged, Me.CurrentQueueCheck, Me.CurrentQueueCheck, Me.CheckQueueCount, Me.CheckQueueIndex))
        End Set
    End Property

    Public WriteOnly Property FirstCheck() As CheckStatus
        Set(ByVal value As CheckStatus)
            NotifyObservers(Me, New CheckRegisterEventArgs(EventName.envmCurrentQueueCheckChanged, Me.CurrentQueueCheck, Me.CurrentQueueCheck, Me.CheckQueueCount, Me.CheckQueueIndex))
            Me._queueIndex = 0
        End Set
    End Property

    Public WriteOnly Property LastCheck() As CheckStatus
        Set(ByVal value As CheckStatus)
            NotifyObservers(Me, New CheckRegisterEventArgs(EventName.envmCurrentQueueCheckChanged, Me.CurrentQueueCheck, Me.CurrentQueueCheck, Me.CheckQueueCount, Me.CheckQueueIndex))
            Me._queueIndex = _checkQueue.Count - 1
        End Set
    End Property

    Public ReadOnly Property CurrentQueueCheck() As ChecksClass
        Get
            If Me._checkQueue.Count < 1 Then
                Dim chk As New ChecksClass("", "", "", "")
                chk.Status = Me._queueCheckStatus
                Return chk
            Else
            Return Me._checkQueue.Item(CheckQueueIndex)
            End If
        End Get
    End Property

    Public Property CheckQueue() As List(Of ChecksClass)
        Get
            Dim retlist As New List(Of ChecksClass)
            retlist.AddRange(Me._checkQueue)
            Return retlist
        End Get
        Set(ByVal value As List(Of ChecksClass))
            Me._checkQueue = value
            If Me.CheckQueueCount > 0 Then
                _queueIndex = 0
            End If
            NotifyObservers(Me, New CheckRegisterEventArgs(EventName.envmCurrentQueueCheckChanged, Me.CurrentQueueCheck, Me.CurrentQueueCheck, Me.CheckQueueCount, Me.CheckQueueIndex))
        End Set
    End Property

    Public ReadOnly Property CheckQueueCount() As Integer
        Get
            Return _checkQueue.Count
        End Get
    End Property

    Public ReadOnly Property CheckQueueIndex() As Integer
        Get
            If Me._checkQueue.Count = 1 Then
                Me._queueIndex = 0
            ElseIf Me._queueIndex > (Me._checkQueue.Count - 1) Then
                Me._queueIndex = Me._checkQueue.Count - 1
            End If
            Return Me._queueIndex
        End Get
    End Property

    Public ReadOnly Property ChecksCountText() As String
        Get
            Return _checkCountText
        End Get
    End Property

#End Region

    Public Sub AddCheck(ByVal chkEvent As CheckDataEventArgs)
        If chkEvent.modCheck IsNot Nothing Then
            Me._checkQueue.Add(chkEvent.modCheck)
        Else
            Me._checkQueue.Add(chkEvent.Check)
        End If
        If Me._checkQueue.Count = 1 Then
            Me._queueIndex = 0
        End If
        NotifyObservers(Me, New CheckRegisterEventArgs(EventName.envmCurrentQueueCheckChanged, Me._checkQueue(Me.CheckQueueIndex), Me._checkQueue(Me.CheckQueueIndex), Me._checkQueue.Count, Me.CheckQueueIndex))

    End Sub

    Private Sub RemoveCheck(ByVal chkData As CheckDataEventArgs)
        For i As Integer = 0 To Me._checkQueue.Count - 1
            If Me._checkQueue.Item(i).RoutingNo.Trim = chkData.Check.RoutingNo.Trim _
            AndAlso Me._checkQueue.Item(i).AccountNo.Trim = chkData.Check.AccountNo.Trim _
            AndAlso Me._checkQueue.Item(i).CheckNo.Trim = chkData.Check.CheckNo.Trim Then
                Me._checkQueue.RemoveAt(i)
                NotifyObservers(Me, New CheckRegisterEventArgs(EventName.envmCurrentQueueCheckChanged, Me.CurrentQueueCheck, Me.CurrentQueueCheck, Me.CheckQueueCount, Me.CheckQueueIndex))
                Exit For
            End If
        Next
    End Sub

    Private Sub UpdateDonorInfo(ByVal donorInfo As DonorInfoEventArgs)
        If Me.CheckQueueIndex >= 0 AndAlso Me.CurrentQueueCheck.DonorInfo.Donor = donorInfo.DonorInfo.Donor Then
            Me._checkQueue.Item(CheckQueueIndex).DonorInfo = donorInfo.DonorInfo
        End If
    End Sub

    Public Sub New(ByVal ChkStatus As CheckStatus)
        MyBase.New()
        Me._queueCheckStatus = ChkStatus
    End Sub

    Public Overrides Sub UpdateData(ByVal NewEvent As mvcLibrary.mvcEventArgsBase)
        Select Case CType(NewEvent, AbstractEventArgs).Name
            Case EventName.evnmCheckInserted
                If CType(NewEvent, CheckDataEventArgs).Check.Status = Me._queueCheckStatus Then
                    AddCheck(CType(NewEvent, CheckDataEventArgs))
                End If
            Case EventName.evnmCheckDeleted, EventName.evnmCheckOnlyDeleted
                RemoveCheck(CType(NewEvent, CheckDataEventArgs))
            Case EventName.evnmCheckUpdated, EventName.evnmCheckStatusChanged
                RemoveCheck(CType(NewEvent, CheckDataEventArgs))
                If CType(NewEvent, CheckDataEventArgs).modCheck.Status = Me._queueCheckStatus Then
                    AddCheck(CType(NewEvent, CheckDataEventArgs))
                End If
            Case EventName.evnmDbCheckDonorInserted, EventName.evnmDbCheckDonorUpdated
                Me.UpdateDonorInfo(CType(NewEvent, DonorInfoEventArgs))

        End Select
    End Sub
End Class
