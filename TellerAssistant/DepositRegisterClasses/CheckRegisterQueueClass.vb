Public Class CheckRegisterQueueClass

    Private _checkQueue As New List(Of ChecksClass)
    Private _queueIndex As Integer
    Private _checkCountText As String = String.Empty
    Private _queueCheckStatus As CheckStatus

#Region "Class Properties"

    Public Function NextCheck(value As CheckStatus) As CheckRegisterEventArgs
        If (Me._checkQueue.Count - 1) > Me._queueIndex Then
            Me._queueIndex += 1
        End If
        Return New CheckRegisterEventArgs(EventName.evnmVwCurrentQueueCheckChanged, Me.CurrentQueueCheck, Me.CurrentQueueCheck, Me.CheckQueueCount, Me.CheckQueueIndex)
    End Function

    Public Function PreviousCheck(value As CheckStatus) As CheckRegisterEventArgs
        If (Me._checkQueue.Count - 1) >= Me._queueIndex Then
            Me._queueIndex -= 1
        End If
        Return New CheckRegisterEventArgs(EventName.evnmVwCurrentQueueCheckChanged, Me.CurrentQueueCheck, Me.CurrentQueueCheck, Me.CheckQueueCount, Me.CheckQueueIndex)
    End Function

    Public Function FirstCheck(value As CheckStatus) As CheckRegisterEventArgs
        Me._queueIndex = 0
        Return New CheckRegisterEventArgs(EventName.evnmVwCurrentQueueCheckChanged, Me.CurrentQueueCheck, Me.CurrentQueueCheck, Me.CheckQueueCount, Me.CheckQueueIndex)
    End Function

    Public Function LastCheck(value As CheckStatus) As CheckRegisterEventArgs
        Me._queueIndex = _checkQueue.Count - 1
        Return New CheckRegisterEventArgs(EventName.evnmVwCurrentQueueCheckChanged, Me.CurrentQueueCheck, Me.CurrentQueueCheck, Me.CheckQueueCount, Me.CheckQueueIndex)
    End Function

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

    Public Property ChecksQueue() As List(Of ChecksClass)
        Get
            Dim retlist As New List(Of ChecksClass)
            retlist.AddRange(Me._checkQueue)
            Return retlist
        End Get
        Set(ByVal value As List(Of ChecksClass))
            Me._checkQueue = value
            If Me.CheckQueueCount > 0 Then
                Me._queueIndex = 0
            End If
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

    Friend Function AddCheck(ByVal chkEvent As CheckDataEventArgs) As Boolean
        Dim retVal As Boolean = False
        If chkEvent.Check.Status = Me._queueCheckStatus Then
            If chkEvent.modCheck IsNot Nothing Then
                Me._checkQueue.Add(chkEvent.modCheck)
                retVal = True
            Else
                Me._checkQueue.Add(chkEvent.Check)
                retVal = True
            End If
            If Me._checkQueue.Count = 1 Then
                Me._queueIndex = 0
            End If
        End If
        Return retVal
        'NotifyObservers(Me, New CheckRegisterEventArgs(EventName.envmCurrentQueueCheckChanged, Me._checkQueue(Me.CheckQueueIndex), Me._checkQueue(Me.CheckQueueIndex), Me._checkQueue.Count, Me.CheckQueueIndex))
    End Function

    Friend Function RemoveCheck(ByVal chkEvent As CheckDataEventArgs) As Boolean
        For i As Integer = 0 To Me._checkQueue.Count - 1
            If Me._checkQueue.Item(i).RoutingNo.Trim = chkEvent.Check.RoutingNo.Trim _
            AndAlso Me._checkQueue.Item(i).AccountNo.Trim = chkEvent.Check.AccountNo.Trim _
            AndAlso Me._checkQueue.Item(i).CheckNo.Trim = chkEvent.Check.CheckNo.Trim Then
                Me._checkQueue.RemoveAt(i)
                Return True
                'NotifyObservers(Me, New CheckRegisterEventArgs(EventName.envmCurrentQueueCheckChanged, Me.CurrentQueueCheck, Me.CurrentQueueCheck, Me.CheckQueueCount, Me.CheckQueueIndex))
            End If
        Next
        Return False
    End Function

    Friend Function UpdateDonorInfo(ByVal chkEvent As CheckDataEventArgs) As Boolean
        If chkEvent.Check.Status = Me._queueCheckStatus Then
            For Each item As ChecksClass In Me._checkQueue
                If item.DonorInfo.Donor = chkEvent.Check.DonorInfo.Donor Then
                    item.DonorInfo = chkEvent.Check.DonorInfo
                    Return True
                End If
            Next
        End If
        Return False
    End Function

    Public Sub New(ByVal ChkStatus As CheckStatus)
        MyBase.New()
        Me._queueCheckStatus = ChkStatus
    End Sub

    'Public Overrides Sub UpdateData(ByVal NewEvent As mvcLibrary.mvcEventArgsBase)
    '    Select Case CType(NewEvent, AbstractEventArgs).Name
    '        Case EventName.evnmCheckInserted
    '            If CType(NewEvent, CheckDataEventArgs).Check.Status = Me._queueCheckStatus Then
    '                AddCheck(CType(NewEvent, CheckDataEventArgs))
    '            End If
    '        Case EventName.evnmCheckDeleted, EventName.evnmCheckOnlyDeleted
    '            RemoveCheck(CType(NewEvent, CheckDataEventArgs))
    '        Case EventName.evnmCheckUpdated, EventName.evnmCheckStatusChanged
    '            RemoveCheck(CType(NewEvent, CheckDataEventArgs))
    '            If CType(NewEvent, CheckDataEventArgs).modCheck.Status = Me._queueCheckStatus Then
    '                AddCheck(CType(NewEvent, CheckDataEventArgs))
    '            End If
    '        Case EventName.evnmDbCheckDonorInserted, EventName.evnmDbCheckDonorUpdated
    '            Me.UpdateDonorInfo(CType(NewEvent, DonorInfoEventArgs))

    '    End Select
    'End Sub
End Class
