Public Class CashClass

    Private cashDenom As CashType
    Private denomCount As Int32
    Private depNo As String = String.Empty

    Public Property Count() As Int32
        Get
            Return denomCount
        End Get
        Set(ByVal value As Int32)
            denomCount = value
        End Set
    End Property

    Public ReadOnly Property Denomination() As CashType
        Get
            Return cashDenom
        End Get
    End Property

    Public ReadOnly Property CashTypeValue() As Single
        Get
            If cashDenom = CashType.DollarCoin Then
                Return 1.0
            Else
                Return CSng(cashDenom / 100)
            End If
        End Get
    End Property

    Public ReadOnly Property DepositNo() As String
        Get
            Return depNo
        End Get
    End Property

    Public Sub New(ByVal depositNo As String, ByVal aType As CashType)
        cashDenom = aType
        denomCount = 0
        depNo = depositNo
    End Sub

    'Public Shared Function CashClassPredicate(ByVal ch As CashClass) As Boolean
    '    If ch.Denomination = CashType.Dime Then
    '        Return True
    '    Else
    '        Return False
    '    End If
    'End Function

End Class
