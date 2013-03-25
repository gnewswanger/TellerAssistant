Public Class CheckDataEventArgs
    Inherits TellerAssistant2012.AbstractEventArgs

    Public Check As ChecksClass
    Public modCheck As ChecksClass
    Public currImage As Image

    Public Sub New(ByVal evName As EventName, ByVal origChk As ChecksClass, ByVal newChk As ChecksClass, Optional chkImage As Image = Nothing)
        MyBase.New(evName)
        Check = origChk
        If Not newChk Is Nothing Then
            modCheck = newChk
        End If
    End Sub
End Class
