Public Class DepositEventArgs
    Inherits TellerAssistant2012.AbstractEventArgs

    Public DepositTicket As DepositTicketClass

    Public Sub New(ByVal evName As EventName, ByVal aTicket As DepositTicketClass)
        MyBase.New(evName)
        DepositTicket = aTicket
    End Sub

End Class
