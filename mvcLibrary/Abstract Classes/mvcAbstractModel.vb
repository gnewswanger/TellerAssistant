<CLSCompliant(True)> _
Public MustInherit Class mvcAbstractModel
    Implements mvcLibrary.IModel1, mvcLibrary.IObserver

    Private _myObservers As Collection

    Public Sub AttachObserver(ByVal Observer As IObserver) Implements IModel1.AttachObserver
        Dim objObject As Object
        If Me._myObservers Is Nothing Then
            Me._myObservers = New Collection()
        End If
        objObject = Observer
        If Not Me._myObservers.Contains(CStr(objObject.GetHashCode)) Then
            Me._myObservers.Add(Observer, CStr(objObject.GetHashCode))
        End If
    End Sub

    Public Sub DetachObserver(ByVal Observer As IObserver) Implements IModel1.DetachObserver
        Dim objObject As Object
        If Not Me._myObservers Is Nothing Then
            objObject = Observer
            If Me._myObservers.Contains(CStr(objObject.GetHashCode)) Then
                Me._myObservers.Remove(objObject.GetHashCode)
            End If
        End If
    End Sub

    Public Sub NotifyObservers(ByVal sender As Object, ByVal NewEvent As mvcEventArgsBase) Implements IModel1.NotifyObservers
        Dim objTemp As IObserver
        If Not Me._myObservers Is Nothing Then
            For Each objTemp In Me._myObservers
                objTemp.UpdateData(NewEvent)
            Next
        End If
    End Sub

    Public MustOverride Sub UpdateData(ByVal NewEvent As mvcEventArgsBase) Implements IObserver.UpdateData

    Public Sub New()
        Me._myObservers = New Collection
    End Sub
End Class
