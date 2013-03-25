Public Class SearchCriteriaClass

    Private _startdate As DateTime
    Private _enddate As DateTime
    Private _transit As String = String.Empty
    Private _account As String = String.Empty
    Private _checkno As String = String.Empty
    Private _donor As String = String.Empty
    Private _amount As Single
    Private _depositNo As String = String.Empty
    Private _descriptionKeyword As String = String.Empty
    Private _searchType As DataSearchType
    Private _receiptStatus As ReceiptRequestStatus = ReceiptRequestStatus.rrsNone

    Public Property StartDate() As DateTime
        Get
            Return _startdate
        End Get
        Set(ByVal value As DateTime)
            _startdate = value
        End Set
    End Property

    Public Property EndDate() As DateTime
        Get
            Return _enddate
        End Get
        Set(ByVal value As DateTime)
            _enddate = value
        End Set
    End Property

    Public Property Transit() As String
        Get
            Return _transit
        End Get
        Set(ByVal value As String)
            _transit = value
        End Set
    End Property

    Public Property Account() As String
        Get
            Return _account
        End Get
        Set(ByVal value As String)
            _account = value
        End Set
    End Property

    Public Property CheckNo() As String
        Get
            Return _checkno
        End Get
        Set(ByVal value As String)
            _checkno = value
        End Set
    End Property

    Public Property Donor() As String
        Get
            Return _donor
        End Get
        Set(ByVal value As String)
            _donor = value
        End Set
    End Property

    Public Property Amount() As Single
        Get
            Return _amount
        End Get
        Set(ByVal value As Single)
            _amount = value
        End Set
    End Property

    Public Property SearchType() As DataSearchType
        Get
            Return _searchType
        End Get
        Set(ByVal value As DataSearchType)
            _searchType = value
        End Set
    End Property

    Public Property DepositNo() As String
        Get
            Return _depositNo
        End Get
        Set(ByVal value As String)
            _depositNo = value
        End Set
    End Property

    Public Property DescriptionKeyword() As String
        Get
            Return _descriptionKeyword
        End Get
        Set(ByVal value As String)
            _descriptionKeyword = value
        End Set
    End Property

    Public Property ReceiptRequest() As ReceiptRequestStatus
        Get
            Return Me._receiptStatus
        End Get
        Set(ByVal value As ReceiptRequestStatus)
            Me._receiptStatus = value
        End Set
    End Property

    Public Sub New(ByVal value As DataSearchType)
        _searchType = value
    End Sub

    Public Function ReceiptStatusContains(ByVal status As ReceiptRequestStatus) As Boolean
        Return ((status And Me._receiptStatus) = status)
    End Function
End Class
