Public Class DepositBalanceClass

    Private depNo As String = String.Empty
    Private depCurrency As Single
    Private depCoins As Single
    Private depChecks As Single
    Private depCheckCt As Integer

    Public Property DepositNo() As String
        Get
            Return depNo
        End Get
        Set(ByVal value As String)
            depNo = value
        End Set
    End Property

    Public Property TotalCurrency() As Single
        Get
            Return depCurrency
        End Get
        Set(ByVal value As Single)
            depCurrency = value
        End Set
    End Property

    Public Property TotalCoins() As Single
        Get
            Return depCoins
        End Get
        Set(ByVal value As Single)
            depCoins = value
        End Set
    End Property

    Public Property TotalChecks() As Single
        Get
            Return depChecks
        End Get
        Set(ByVal value As Single)
            depChecks = value
        End Set
    End Property

    Public Property CheckCount() As Integer
        Get
            Return depCheckCt
        End Get
        Set(ByVal value As Integer)
            depCheckCt = value
        End Set
    End Property

    Public ReadOnly Property TotalDeposit() As Single
        Get
            Return depCurrency + depCoins + depChecks
        End Get
    End Property

    Public Sub New()

    End Sub

End Class

