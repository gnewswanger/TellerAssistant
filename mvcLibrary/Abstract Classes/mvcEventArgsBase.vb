<CLSCompliant(True)> _
Public MustInherit Class mvcEventArgsBase
    Inherits EventArgs

    Private mstrName As String

    Protected ReadOnly Property Name() As String
        Get
            Return mstrName
        End Get
    End Property

    Protected Sub New(ByVal eventName As String)
        MyBase.New()
        mstrName = eventName

    End Sub

End Class
