Imports System.IO

Public Class CheckViewerPanelBaseClass
    Implements IViewChecksPanel

    Delegate Sub SetImageCallback()
    Delegate Sub GenericCallback(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Delegate Sub SetTextCallback(ByVal text As String)
    Delegate Sub SetBooleanCallback(ByVal val As Boolean)
    Public Event CheckviewSetCurrentCheck As GenericCallback

    Private _origCheck As ChecksClass
    Private _updatedCheck As ChecksClass
    Private _isDirty As Boolean = False

#Region "Class Properties"

    Public Property SpliterDistance() As Integer
        Get
            Return Me.SplitContainer1.SplitterDistance
        End Get
        Set(ByVal value As Integer)
            Me.SplitContainer1.SplitterDistance = value
        End Set
    End Property

    Protected Property UpdatedCheck() As ChecksClass
        Get
            Return Me._updatedCheck
        End Get
        Set(ByVal value As ChecksClass)
            Me._updatedCheck = value
        End Set
    End Property

    Protected Property OriginalCheck() As ChecksClass
        Get
            Return Me._origCheck
        End Get
        Set(ByVal value As ChecksClass)
            Me._origCheck = value
        End Set
    End Property

    Protected Property IsDirty() As Boolean
        Get
            Return Me._isDirty
        End Get
        Set(ByVal value As Boolean)
            Me._isDirty = value
        End Set
    End Property

    Public Property CurrentCheckArgs() As CheckRegisterEventArgs Implements IViewChecksPanel.CurrentCheck
        Get
            Return New CheckRegisterEventArgs(EventName.evnmCheckSearchResult, _origCheck, _updatedCheck, Nothing, Nothing)
        End Get
        Set(ByVal value As CheckRegisterEventArgs)
            If value IsNot Nothing Then
                SetCurrentCheck(value)
            End If
        End Set
    End Property

#End Region

#Region "Set Current Check"

    Private Sub SetCurrentCheck(ByVal value As CheckRegisterEventArgs)
        If value.origCheck Is Nothing Then
            _origCheck = New ChecksClass("", "", "", "")
            _updatedCheck = New ChecksClass("", "", "", "")
        Else
            Me.OriginalCheck = value.origCheck
            _updatedCheck = New ChecksClass(_origCheck)
        End If
        'SetCheckPixImage()
        RaiseEvent CheckviewSetCurrentCheck(Me, New CheckRegisterEventArgs(value.Name, Me.OriginalCheck, Me.UpdatedCheck, value.QueueCount, value.QueueIndex))
        _isDirty = False
    End Sub

    Protected Sub SetCurrentDonorInfo(ByVal donor As DonorClass)
        Me.UpdatedCheck.DonorInfo = New DonorClass(donor.Donor)
        Me.UpdatedCheck.DonorAddress = donor.Address
        Me.UpdatedCheck.DonorCity = donor.City
        Me.UpdatedCheck.DonorState = donor.State
        Me.UpdatedCheck.DonorZip = donor.Zip
        Me.UpdatedCheck.DonorInfo.EnvelopeNo = donor.EnvelopeNo
        Me.UpdatedCheck.DonorInfo.Bank = Me.OriginalCheck.RoutingNo
        Me.UpdatedCheck.DonorInfo.Account = Me.OriginalCheck.AccountNo
    End Sub

    Protected Overridable Sub SetCheckPixImage()
        If InvokeRequired Then
            Me.Invoke(New SetImageCallback(AddressOf SetCheckPixImage))
        Else
            If _origCheck Is Nothing OrElse _origCheck.ImageFile Is Nothing OrElse _origCheck.ImageFile = "" Then
                ImageViewerPanel1.Image = Nothing
            Else
                Dim fname As String = _origCheck.ImageFullPath + _origCheck.ImageFile
                If File.Exists(fname) Then
                    Dim img As New Bitmap(fname)
                    ImageViewerPanel1.Image = New Bitmap(img)
                    img.Dispose()
                Else
                    ImageViewerPanel1.ShowImageNotFound()
                End If
            End If
        End If
    End Sub

#End Region
End Class
