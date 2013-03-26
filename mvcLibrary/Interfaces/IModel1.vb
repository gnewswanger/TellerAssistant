<CLSCompliant(True)> _
Public Interface IModel1

    Sub AttachObserver(ByVal Observer As IObserver)
    Sub DetachObserver(ByVal Observer As IObserver)
    Sub NotifyObservers(ByVal sender As Object, ByVal NewEvent As mvcEventArgsBase)

End Interface
