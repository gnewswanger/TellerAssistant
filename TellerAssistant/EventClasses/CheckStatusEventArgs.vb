Public Class CheckStatusEventArgs
    Inherits TellerAssistant2012.AbstractEventArgs

    Public check As ChecksClass
    Public originalStatus As CheckStatus
  
    Public Sub New(ByVal evName As EventName, ByVal chk As ChecksClass, ByVal oldStatus As CheckStatus)
        MyBase.New(evName)
        check = chk
        originalStatus = oldStatus
    End Sub

    Public Function ToCheckDataEventArgs() As CheckDataEventArgs
        Dim retVal As New CheckDataEventArgs(Me.Name, check, check)
         Return retVal
    End Function
End Class
