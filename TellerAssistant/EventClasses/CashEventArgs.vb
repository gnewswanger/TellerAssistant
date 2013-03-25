Public Class CashEventArgs
    Inherits TellerAssistant2012.AbstractEventArgs

    Public Cash As CashClass

    Public Image As Bitmap

    Public Sub New(ByVal evName As EventName, ByVal aCash As CashClass)
        MyBase.New(evName)
        Cash = aCash
    End Sub

End Class
