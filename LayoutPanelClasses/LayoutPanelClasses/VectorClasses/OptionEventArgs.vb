
Public Delegate Sub OptionChanged(ByVal sender As Object, ByVal e As OptionEventArgs)

Public Class OptionEventArgs
    Inherits EventArgs

    Public eOption As String

    Public Sub New(ByVal s As String)
        Me.eOption = s
    End Sub
End Class
