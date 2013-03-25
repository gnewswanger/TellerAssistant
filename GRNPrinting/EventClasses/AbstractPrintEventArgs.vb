Public MustInherit Class AbstractPrintEventArgs
    Inherits mvcLibrary.mvcEventArgsBase

    Private mobjValue As Object

    Public Property Value() As Object
        Get
            Value = mobjValue
        End Get
        Set(ByVal Value As Object)
            mobjValue = Value
        End Set
    End Property

    Public Overloads ReadOnly Property Name() As PrintEventName
        Get
            Return CType([Enum].Parse(GetType(PrintEventName), MyBase.Name), PrintEventName)
        End Get
    End Property

    Public Sub New(ByVal evName As PrintEventName)
        MyBase.New([Enum].GetName(GetType(PrintEventName), evName))

    End Sub


End Class
