Public Class BankAccountClass

    Private bankId As String = String.Empty
    Private bankName As String = String.Empty
    Private bankAddress As String = String.Empty
    Private bankCity As String = String.Empty
    Private bankState As String = String.Empty
    Private bankZip As String = String.Empty
    Private bankAccountType As String = String.Empty
    Private bankAcctId As String = String.Empty
    Private bankAcctName As String = String.Empty
 
    Public ReadOnly Property DepositBankNo() As String
        Get
            Return bankId
        End Get
    End Property
    Public Property DepositBank() As String
        Get
            Return bankName
        End Get
        Set(ByVal value As String)
            bankName = value
        End Set
    End Property
    Public Property DepositBankAddress() As String
        Get
            Return bankAddress
        End Get
        Set(ByVal value As String)
            bankAddress = value
        End Set
    End Property
    Public Property DepositBankCity() As String
        Get
            Return bankCity
        End Get
        Set(ByVal value As String)
            bankCity = value
        End Set
    End Property
    Public Property DepositBankState() As String
        Get
            Return bankState
        End Get
        Set(ByVal value As String)
            bankState = value
        End Set
    End Property
    Public Property DepositBankZip() As String
        Get
            Return bankZip
        End Get
        Set(ByVal value As String)
            bankZip = value
        End Set
    End Property
    Public Property AccountType() As String
        Get
            Return bankAccountType
        End Get
        Set(ByVal value As String)
            bankAccountType = value
        End Set
    End Property
    Public ReadOnly Property AccountNo() As String
        Get
            Return bankAcctId
        End Get
    End Property
    Public Property AccountName() As String
        Get
            Return bankAcctName
        End Get
        Set(ByVal value As String)
            bankAcctName = value
        End Set
    End Property

    Public Sub New(ByVal routNo As String, ByVal accountNo As String)
        bankId = routNo
        bankAcctId = accountNo
    End Sub

End Class
