Public MustInherit Class AbstractEventArgs
    Inherits mvcLibrary.mvcEventArgsBase

    Public Overloads ReadOnly Property Name() As EventName
        Get
            Return CType([Enum].Parse(GetType(EventName), MyBase.Name), EventName)
        End Get
    End Property

    Public Sub New(ByVal evName As EventName)
        MyBase.New([Enum].GetName(GetType(EventName), evName))

    End Sub


End Class
