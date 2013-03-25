Public Class BankAccountEventArgs
    Inherits TellerAssistant2012.AbstractEventArgs

    Public BankAccount As BankAccountClass

    Public Sub New(ByVal evName As EventName, ByVal bnk As BankAccountClass)
        MyBase.New(evName)
        BankAccount = bnk
    End Sub

End Class
