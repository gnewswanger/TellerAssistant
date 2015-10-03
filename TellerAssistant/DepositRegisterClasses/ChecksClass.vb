Public Class ChecksClass
    Implements mvcLibrary.IObserver

    Private _routing As String = String.Empty
    Private _account As String = String.Empty
    Private _check As String = String.Empty
    Private _chDate As DateTime
    Private _amount As Single
    Private _checkDonor As DonorClass
    Private _depositTicket As String = String.Empty
    Private _imageFilename As String = String.Empty
    Private _imagePath As String = String.Empty
    Private _chkStatus As CheckStatus
    Private _receiptStatus As ReceiptRequestStatus
    Private _manual As Boolean = False

#Region "Class Properties"

    Public Property RoutingNo() As String
        Get
            Return _routing
        End Get
        Set(ByVal Value As String)
            _routing = Value
        End Set
    End Property
    Public Property AccountNo() As String
        Get
            Return _account
        End Get
        Set(ByVal Value As String)
            _account = Value
        End Set
    End Property
    Public Property CheckNo() As String
        Get
            Return _check
        End Get
        Set(ByVal Value As String)
            _check = Value
        End Set
    End Property
    Public Property CheckAmount() As Single
        Get
            Return _amount
        End Get
        Set(ByVal Value As Single)
            _amount = Value
        End Set
    End Property
    Public Property CheckDate() As DateTime
        Get
            Return _chDate
        End Get
        Set(ByVal Value As DateTime)
            _chDate = Value
        End Set
    End Property
    Public Property DepositNo() As String
        Get
            Return _depositTicket
        End Get
        Set(ByVal Value As String)
            _depositTicket = Value
        End Set
    End Property
    Public Property ImageFile() As String
        Get
            If _imageFilename = String.Empty AndAlso Me.CheckName <> String.Empty Then
                Return Me.CheckName & ".tif"
            Else
                Return _imageFilename
            End If
        End Get
        Set(ByVal Value As String)
            _imageFilename = Value
        End Set
    End Property
    Public Property ImageFullPath() As String
        Get
            Return _imagePath
        End Get
        Set(ByVal value As String)
            _imagePath = value
        End Set
    End Property
    Public Property DonorInfo() As DonorClass
        Get
            Return Me._checkDonor
        End Get
        Set(ByVal value As DonorClass)
            Me._checkDonor = value
        End Set
    End Property
    Public ReadOnly Property Donor() As String
        Get
            If Me._checkDonor Is Nothing Then
                Return String.Empty
            Else
                Return Me._checkDonor.Donor
            End If
        End Get
        'Set(ByVal value As String)
        '    If Me._checkDonor Is Nothing Then
        '        Me._checkDonor = New DonorClass(value)
        '    Else
        '        Me._checkDonor.Donor = value
        '    End If
        'End Set
    End Property
    'TODO: Donor above should not create a new instance of donor class before checking for existing donor in database.
    Public Property DonorAddress() As String
        Get
            If Me._checkDonor Is Nothing Then
                Return String.Empty
            Else
                Return Me._checkDonor.Address
            End If
        End Get
        Set(ByVal value As String)
            If Me._checkDonor Is Nothing Then
                MsgBox("No donor has been specified for this donation.")
            Else
                Me._checkDonor.Address = value
            End If
        End Set
    End Property
    Public Property DonorCity() As String
        Get
            If Me._checkDonor Is Nothing Then
                Return String.Empty
            Else
                Return Me._checkDonor.City
            End If
        End Get
        Set(ByVal value As String)
            If Me._checkDonor Is Nothing Then
                MsgBox("No donor has been specified for this donation.")
            Else
                Me._checkDonor.City = value
            End If
        End Set
    End Property
    Public Property DonorState() As String
        Get
            If Me._checkDonor Is Nothing Then
                Return String.Empty
            Else
                Return Me._checkDonor.State
            End If
        End Get
        Set(ByVal value As String)
            If Me._checkDonor Is Nothing Then
                MsgBox("No donor has been specified for this donation.")
            Else
                Me._checkDonor.State = value
            End If
        End Set
    End Property
    Public Property DonorZip() As String
        Get
            If Me._checkDonor Is Nothing Then
                Return String.Empty
            Else
                Return Me._checkDonor.Zip
            End If
        End Get
        Set(ByVal value As String)
            If Me._checkDonor Is Nothing Then
                MsgBox("No donor has been specified for this donation.")
            Else
                Me._checkDonor.Zip = value
            End If
        End Set
    End Property
    Public ReadOnly Property Text() As String
        Get
            Return [String].Format("{0,9}", Trim(_check)) & [String].Format("{0,10:C}", _amount)
        End Get
    End Property
    Public Property Status() As CheckStatus
        Get
            Return Me._chkStatus
        End Get
        Set(ByVal value As CheckStatus)
            Me._chkStatus = value
        End Set
    End Property
    Public Property ReceiptRequest() As ReceiptRequestStatus
        Get
            Return Me._receiptStatus
        End Get
        Set(ByVal value As ReceiptRequestStatus)
            If value = Nothing Then
                Me._receiptStatus = ReceiptRequestStatus.rrsNone
            Else
                Me._receiptStatus = value
            End If
        End Set
    End Property
    Public Property ManualCheck() As Boolean
        Get
            Return _manual
        End Get
        Set(ByVal value As Boolean)
            _manual = value
        End Set
    End Property

    Public ReadOnly Property CheckName() As String
        Get
            Return Me.RoutingNo & Me.AccountNo & Me.CheckNo
        End Get
    End Property

#End Region

    Public Sub New(ByVal dpNum As String, ByVal rt As String, ByVal acct As String, _
            ByVal ckNum As String, Optional ByVal dt As Date = Nothing, _
            Optional ByVal amt As Single = 0, Optional ByVal img As String = "")
        MyBase.New()
        Me._depositTicket = dpNum
        Me._routing = rt
        Me._account = acct
        Me._check = ckNum
        If dt = Nothing Then
            Me._chDate = Today
        Else
            Me._chDate = dt
        End If
        Me._amount = amt
        Me._imageFilename = img
        If amt = 0.0 Then
            Me._chkStatus = CheckStatus.csAmountPending
        Else
            Me._chkStatus = CheckStatus.csConfirmPending
        End If
        Me._receiptStatus = ReceiptRequestStatus.rrsNone
    End Sub

    Public Sub New(ByVal cksClass As ChecksClass)
        MyBase.New()
        Me._depositTicket = cksClass._depositTicket
        Me._routing = cksClass._routing
        Me._account = cksClass._account
        Me._check = cksClass._check
        Me._chDate = cksClass._chDate
        Me._amount = cksClass._amount
        Me._imageFilename = cksClass._imageFilename
        Me._checkDonor = cksClass.DonorInfo
        Me._chkStatus = cksClass._chkStatus
        Me._receiptStatus = cksClass._receiptStatus
        Me._imagePath = cksClass._imagePath
        Me._manual = cksClass._manual
    End Sub

    Public Sub SetCheckData(ByVal dt As Date, ByVal amt As Single)
        Me._chDate = dt
        Me._amount = amt
    End Sub

    Public Sub UpdateData(ByVal NewEvent As mvcLibrary.mvcEventArgsBase) Implements mvcLibrary.IObserver.UpdateData

    End Sub
End Class
