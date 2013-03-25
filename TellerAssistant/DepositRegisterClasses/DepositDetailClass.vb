Public Class DepositDetailClass

    Private depSumm As DepositTicketClass
    Private checkList As List(Of ChecksClass)
    Private cashList As List(Of CashClass)

#Region "Class Properties"
    Public Property DepositSummary() As DepositTicketClass
        Get
            Return depSumm
        End Get
        Set(ByVal value As DepositTicketClass)
            depSumm = value
        End Set
    End Property

    Public Property CheckClassList() As List(Of ChecksClass)
        Get
            Return checkList
        End Get
        Set(ByVal value As List(Of ChecksClass))
            checkList = value
        End Set
    End Property

    Public WriteOnly Property CashClassList() As List(Of CashClass)
        Set(ByVal value As List(Of CashClass))
            cashList = value
        End Set
    End Property

#End Region

    Public Sub New()

    End Sub

    Public Function GetCheckCount() As Integer
        Return checkList.Count
    End Function

    Public Function GetCashDenomCount(ByVal denom As CashType) As Integer
        For Each cash As CashClass In cashList
            If cash.Denomination = denom Then
                Return cash.Count
            End If
        Next
        Return Nothing
    End Function

    Public Function GetCashDenomTotal(ByVal denom As CashType) As Single
        For Each cash As CashClass In cashList
            If cash.Denomination = denom Then
                Return cash.Count * cash.CashTypeValue
            End If
        Next
        Return Nothing
    End Function

    Public Function GetTotalCoins() As Single
        Dim retVal As Single = 0.0
        For Each cash As CashClass In cashList
            If cash.CashTypeValue < 100 OrElse cash.Denomination = CashType.DollarCoin Then
                retVal += (cash.Count * cash.CashTypeValue)
            End If
        Next
        Return retVal
    End Function

    Public Function GetTotalCurrency() As Single
        Dim retVal As Single = 0.0
        For Each cash As CashClass In cashList
            If cash.CashTypeValue >= 100 AndAlso Not cash.Denomination = CashType.DollarCoin Then
                retVal += (cash.Count * cash.CashTypeValue)
            End If
        Next
        Return retVal
    End Function

    Public Function GetTotalChecks() As Single
        Dim retVal As Single
        For Each check As ChecksClass In checkList
            retVal += check.CheckAmount
        Next
        Return retVal
    End Function

    Public Function GetTotalDeposit() As Single
        Return GetTotalCoins() + GetTotalCurrency() + GetTotalChecks()
    End Function

End Class
