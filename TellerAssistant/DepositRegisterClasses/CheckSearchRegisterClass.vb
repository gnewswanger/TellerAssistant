Public Class CheckSearchRegisterClass
    Inherits mvcLibrary.mvcAbstractModel

    Delegate Sub SetCheckListCallback(ByVal value As List(Of ChecksClass))
    Private _checkSearchQueue As ListView
    Private _queueIndex As Integer
    Private _checkCountText As String = String.Empty

#Region "Class Properties"

    Public WriteOnly Property NextCheck() As CheckStatus
        Set(ByVal value As CheckStatus)
            If (_checkSearchQueue.Items.Count - 1) > _queueIndex Then
                _queueIndex += 1
            End If
            If _checkSearchQueue.Items.Count < 1 Then
                Dim chk As New ChecksClass("", "", "", "")
                chk.Status = value
                NotifyObservers(Me, New CheckRegisterEventArgs(EventName.envmCurrentQueueCheckChanged, chk, Nothing, _checkSearchQueue.Items.Count, _queueIndex))
            Else
                NotifyObservers(Me, New CheckRegisterEventArgs(EventName.envmCurrentQueueCheckChanged, CType(_checkSearchQueue.Items(_queueIndex).Tag, ChecksClass), Nothing, _checkSearchQueue.Items.Count, _queueIndex))
            End If
        End Set
    End Property

    Public WriteOnly Property PreviousCheck() As CheckStatus
        Set(ByVal value As CheckStatus)
            If (_checkSearchQueue.Items.Count - 1) >= _queueIndex AndAlso _queueIndex > 0 Then
                _queueIndex -= 1
            End If
            If _checkSearchQueue.Items.Count < 1 Then
                Dim chk As New ChecksClass("", "", "", "")
                chk.Status = value
                NotifyObservers(Me, New CheckRegisterEventArgs(EventName.envmCurrentQueueCheckChanged, chk, Nothing, _checkSearchQueue.Items.Count, _queueIndex))
            Else
                NotifyObservers(Me, New CheckRegisterEventArgs(EventName.envmCurrentQueueCheckChanged, CType(_checkSearchQueue.Items(_queueIndex).Tag, ChecksClass), Nothing, _checkSearchQueue.Items.Count, _queueIndex))
            End If
        End Set
    End Property

    Public WriteOnly Property FirstCheck() As CheckStatus
        Set(ByVal value As CheckStatus)
            If _checkSearchQueue.Items.Count < 1 Then
                Dim chk As New ChecksClass("", "", "", "")
                chk.Status = value
                NotifyObservers(Me, New CheckRegisterEventArgs(EventName.envmCurrentQueueCheckChanged, chk, Nothing, _checkSearchQueue.Items.Count, _queueIndex))
            Else
                _queueIndex = 0
                NotifyObservers(Me, New CheckRegisterEventArgs(EventName.envmCurrentQueueCheckChanged, CType(_checkSearchQueue.Items(_queueIndex).Tag, ChecksClass), Nothing, _checkSearchQueue.Items.Count, _queueIndex))
            End If
        End Set
    End Property

    Public WriteOnly Property LastCheck() As CheckStatus
        Set(ByVal value As CheckStatus)
            If _checkSearchQueue.Items.Count < 1 Then
                Dim chk As New ChecksClass("", "", "", "")
                chk.Status = value
                NotifyObservers(Me, New CheckRegisterEventArgs(EventName.envmCurrentQueueCheckChanged, chk, Nothing, _checkSearchQueue.Items.Count, _queueIndex))
            Else
                _queueIndex = _checkSearchQueue.Items.Count - 1
                NotifyObservers(Me, New CheckRegisterEventArgs(EventName.envmCurrentQueueCheckChanged, ctype(_checkSearchQueue.Items(_queueIndex).Tag,ChecksClass), Nothing, _checkSearchQueue.Items.Count, _queueIndex))
            End If
        End Set
    End Property

    Public ReadOnly Property CurrentQueueCheck() As ChecksClass
        Get
            If _checkSearchQueue.Items.Count > _queueIndex Then
                Return CType(_checkSearchQueue.Items(_queueIndex).Tag, ChecksClass)
            End If
            Return Nothing
        End Get
    End Property

    Public Property CheckQueue() As List(Of ChecksClass)
        Get
            Dim retlist As New List(Of ChecksClass)
            retlist.AddRange(CType(_checkSearchQueue.Items, System.Collections.Generic.IEnumerable(Of ChecksClass)))
            Return retlist
        End Get
        Set(ByVal value As List(Of ChecksClass))
            SetCheckListlvCheckList(value)
            If _checkSearchQueue.Items.Count > 0 Then
                _queueIndex = 0
            ElseIf _checkSearchQueue.Items.Count < 1 Then
                Dim chk As New ChecksClass("", "", "", "")
                NotifyObservers(Me, New CheckRegisterEventArgs(EventName.envmCurrentQueueCheckChanged, chk, Nothing, _checkSearchQueue.Items.Count, _queueIndex))
                Exit Property
            End If
            NotifyObservers(Me, New CheckRegisterEventArgs(EventName.envmCurrentQueueCheckChanged, CType(_checkSearchQueue.Items(_queueIndex).Tag, ChecksClass), Nothing, _checkSearchQueue.Items.Count, _queueIndex))
        End Set
    End Property

    Public ReadOnly Property CheckQueueCount(ByVal chkQueue As CheckStatus) As Integer
        Get
            Return _checkSearchQueue.Items.Count
        End Get
    End Property

    Public ReadOnly Property ChecksCountText() As String
        Get
            Return _checkCountText
        End Get
    End Property
#End Region

    Public Sub New(ByRef lstview As ListView)
        MyBase.New()
        _checkSearchQueue = lstview
        _queueIndex = 0
    End Sub

    Public Sub AddCheck(ByVal chkEvent As CheckDataEventArgs)
        If _checkSearchQueue.InvokeRequired Then
            _checkSearchQueue.BeginInvoke(New SetCheckListCallback(AddressOf SetCheckListlvCheckList), chkEvent)
        Else
            Dim itm As New ListViewItem
            itm.Text = chkEvent.check.Text
            itm.SubItems.Add(chkEvent.check.CheckAmount.ToString("C"))
            itm.Tag = chkEvent.check

            itm.ToolTipText = itm.Text
            If chkEvent.check.ManualCheck Then
                itm.BackColor = Color.Beige
            End If
            _checkSearchQueue.Items.Add(itm)
            Dim group As ListViewGroup = New ListViewGroup(chkEvent.check.CheckDate.ToString("Y"), chkEvent.check.CheckDate.ToString("Y"))
            If _checkSearchQueue.Groups(group.Name) Is Nothing Then
                _checkSearchQueue.Groups.Add(group)
            End If
            itm.Group = _checkSearchQueue.Groups(group.Name)

        End If
        '_checkSearchQueue.Items.Add(chkEvent.check)
        'If _checkSearchQueue.Count = 1 Then
        '    _queueIndex = 0
        'End If
        'NotifyObservers(Me, New CheckRegisterEventArgs(EventName.envmCurrentQueueCheckChanged, _checkSearchQueue.Item(_queueIndex), _checkSearchQueue.Count, _queueIndex))

    End Sub

    Private Sub SetCheckListlvCheckList(ByVal value As List(Of ChecksClass))
        If _checkSearchQueue.InvokeRequired Then
            _checkSearchQueue.BeginInvoke(New SetCheckListCallback(AddressOf SetCheckListlvCheckList), value)
        Else
            _checkSearchQueue.Items.Clear()
            _checkSearchQueue.SuspendLayout()
            For Each chk As ChecksClass In value
                Dim itm As New ListViewItem
                itm.Text = chk.Text
                itm.SubItems.Add(chk.CheckAmount.ToString("C"))
                itm.Tag = chk

                itm.ToolTipText = itm.Text
                If chk.ManualCheck Then
                    itm.BackColor = Color.Beige
                End If
                _checkSearchQueue.Items.Add(itm)
                Dim group As ListViewGroup = New ListViewGroup(chk.CheckDate.ToString("Y"), chk.CheckDate.ToString("Y"))
                If _checkSearchQueue.Groups(group.Name) Is Nothing Then
                    _checkSearchQueue.Groups.Add(group)
                End If
                itm.Group = _checkSearchQueue.Groups(group.Name)
            Next
            If _checkSearchQueue.Columns.Count > 0 Then
                _checkSearchQueue.Columns(0).TextAlign = HorizontalAlignment.Right
            End If
            _checkSearchQueue.ResumeLayout()
            _checkCountText = value.Count.ToString
        End If
    End Sub

    Private Sub DeleteCheck(ByVal chkData As CheckDataEventArgs)
        For i As Integer = 0 To _checkSearchQueue.Items.Count - 1
            If CType(_checkSearchQueue.Items(i).Tag, ChecksClass).RoutingNo.Trim = chkData.Check.RoutingNo.Trim _
            AndAlso CType(_checkSearchQueue.Items(i).Tag, ChecksClass).AccountNo.Trim = chkData.Check.AccountNo.Trim _
            AndAlso CType(_checkSearchQueue.Items(i).Tag, ChecksClass).CheckNo.Trim = chkData.Check.CheckNo.Trim Then
                _checkSearchQueue.Items.RemoveAt(i)
                If _checkSearchQueue.Items.Count = 1 Then
                    _queueIndex = 0
                ElseIf _queueIndex > _checkSearchQueue.Items.Count - 1 Then
                    _queueIndex = _checkSearchQueue.Items.Count - 1
                End If
                Dim chk As ChecksClass
                If _checkSearchQueue.Items.Count = 0 Then
                    chk = New ChecksClass("", "", "", "")
                Else
                    chk = CType(_checkSearchQueue.Items(_queueIndex).Tag, ChecksClass)
                End If
                chk.Status = CheckStatus.csAmountPending
                NotifyObservers(Me, New CheckRegisterEventArgs(EventName.envmCurrentQueueCheckChanged, chk, Nothing, _checkSearchQueue.Items.Count, _queueIndex))
                Exit For
            End If
        Next
    End Sub

    Public Overrides Sub UpdateData(ByVal NewEvent As mvcLibrary.mvcEventArgsBase)
        Select Case CType(NewEvent, AbstractEventArgs).Name
            Case EventName.evnmCheckInserted
                AddCheck(CType(NewEvent, CheckDataEventArgs))
            Case EventName.evnmCheckDeleted, EventName.evnmCheckOnlyDeleted
                DeleteCheck(CType(NewEvent, CheckDataEventArgs))
            Case EventName.evnmCheckUpdated
                DeleteCheck(CType(NewEvent, CheckDataEventArgs))
                AddCheck(CType(NewEvent, CheckDataEventArgs))
        End Select
    End Sub
End Class
