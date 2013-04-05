<CLSCompliant(True)> _
Public Interface IModel1

    Sub AttachObserver(ByVal Observer As IObserver)
    Sub DetachObserver(ByVal Observer As IObserver)
    Function IsAttached(ByVal Observer As IObserver) As Boolean
    Sub NotifyObservers(ByVal sender As Object, ByVal NotifyEvent As mvcEventArgsBase)

End Interface
