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
        End Set
    End Property

    Public ReadOnly Property CheckQueueCount() As Integer
        Get
            Return Me._checkQueue.Count
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

    'Friend Function AddCheck(ByVal chkEvent As CheckDataEventArgs) As Boolean
    '    Dim retVal As Boolean = False
    '    If chkEvent.Check.Status = Me._queueCheckStatus Then
    '        If chkEvent.modCheck IsNot Nothing Then
    '            Me._checkQueue.Add(chkEvent.modCheck)
    '            retVal = True
    '        Else
    '            Me._checkQueue.Add(chkEvent.Check)
    '            retVal = True
    '        End If
    '        If Me._checkQueue.Count = 1 Then
    '            Me._queueIndex = 0
    '        End If
    '    End If
    '    Return retVal
    'End Function

    'Friend Function UpdateDonorInfo(ByVal chkEvent As CheckDataEventArgs) As Boolean
    '    If chkEvent.Check.Status = Me._queueCheckStatus Then
    '        For Each item As ChecksClass In Me._checkQueue
    '            If item.DonorInfo.Donor = chkEvent.Check.DonorInfo.Donor Then
    '                item.DonorInfo = chkEvent.Check.DonorInfo
    '                Return True
    '            End If
    '        Next
    '    End If
    '    Return False
    'End Function

    Public Sub New(ByVal ChkStatus As CheckStatus)
        MyBase.New()
        Me._queueCheckStatus = ChkStatus
    End Sub

End Class
