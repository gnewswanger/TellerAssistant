Imports System.IO

Public Class StatusEventArgs
    Inherits TellerAssistant2012.AbstractEventArgs

    Public portType As ConnectionType
    Public micrText As String = String.Empty
    Public hilite As Boolean
    Public chkImage As Image

    Public Sub New(ByVal evName As EventName, ByVal port As ConnectionType, Optional ByVal micrtxt As String = "", Optional imageData As MemoryStream = Nothing)
        MyBase.New(evName)
        portType = port
        micrText = micrtxt
        hilite = (micrText.StartsWith("MICR Not Attached"))
        If imageData IsNot Nothing Then
            chkImage = New Bitmap(imageData)
        End If
    End Sub
End Class
