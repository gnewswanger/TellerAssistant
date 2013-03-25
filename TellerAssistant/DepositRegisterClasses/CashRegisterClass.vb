
Public Class CashRegisterClass
    Implements TellerAssistant2008.mvcLibrary.IObserver

    Private cashList As List(Of CashClass)

    Public Sub New(ByVal depNum As String)
        MyBase.New()
    End Sub

    Public Sub AddCurrency(ByVal cash As CashClass)
        cashList.Add(cash)
    End Sub

    Public Sub UpdateCurrency(ByVal cash As CashClass)
        For Each item As CashClass In cashList
            If item.Denomination = cash.Denomination Then
                item = cash
                Exit For
            End If
        Next
    End Sub

    Public Sub DeleteCurrency(ByVal denom As CashType)
        For Each item As CashClass In cashList
            If item.Denomination = denom Then
                cashList.Remove(item)
                Exit For
            End If
        Next
    End Sub

    Public Function GetTotalAmount() As Single
        Dim retVal As Single
        For Each i As CashClass In cashList
            retVal += (i.CashTypeValue * i.Count)
        Next
        Return retVal
    End Function

    Public Function GetTotalCoins() As Single
        Dim retVal As Single = 0
        For Each i As CashClass In cashList
            If i.Denomination <= CashType.DollarCoin Then
                retVal += (i.CashTypeValue * i.Count)
            End If
        Next
        Return retVal
    End Function

    Public Function GetTotalCurrency() As Single
        Dim retVal As Single = 0
        For Each i As CashClass In cashList
            If i.Denomination > CashType.One Then
                retVal += (i.CashTypeValue * i.Count)
            End If
        Next
        Return retVal
    End Function

    Public Function GetDenomTotal(ByVal denom As CashType) As Single
        Dim retVal As Single = 0
        For Each i As CashClass In cashList
            If i.Denomination = denom Then
                retVal += (i.CashTypeValue * i.Count)
            End If
        Next
        Return retVal
    End Function

    Public Function GetDenomCount(ByVal denom As CashType) As Integer
        Dim retVal As Integer = 0
        For Each i As CashClass In cashList
            If i.Denomination = denom Then
                retVal += i.Count
            End If
        Next
        Return retVal
    End Function

    Public Sub UpdateData(ByVal NewEvent As mvcLibrary.mvcEventArgsBase) Implements mvcLibrary.IObserver.UpdateData
        Select Case CType(NewEvent, AbstractEventArgs).Name
            Case EventName.evnmCashClassAdded
                AddCurrency(CType(NewEvent, CashEventArgs).Cash)
            Case EventName.evnmCashClassUpdated
                UpdateCurrency(CType(NewEvent, CashEventArgs).Cash)
            Case EventName.evnmCheckDeleted
                DeleteCurrency(CType(NewEvent, CashEventArgs).Cash.Denomination)
        End Select
    End Sub
End Class
