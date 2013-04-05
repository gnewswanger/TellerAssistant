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
                Me._myObservers.Remove(CStr(objObject.GetHashCode))
            End If
        End If
    End Sub

    Public Function IsAttached(Observer As IObserver) As Boolean Implements IModel1.IsAttached
        Dim objObject As Object
        If Not Me._myObservers Is Nothing Then
            objObject = Observer
            If Me._myObservers.Contains(CStr(objObject.GetHashCode)) Then
                Return True
            End If
        End If
        Return False
    End Function

    Public Sub NotifyObservers(ByVal sender As Object, ByVal NewEvent As mvcEventArgsBase) Implements IModel1.NotifyObservers
        Dim objTemp As IObserver
        If Not Me._myObservers Is Nothing Then
            For Each objTemp In Me._myObservers
                objTemp.UpdateData(NewEvent)
            Next
        End If
    End Sub

    Public MustOverride Sub UpdateData(ByVal NotifyEvent As mvcEventArgsBase) Implements IObserver.UpdateData

    Public Sub New()
        Me._myObservers = New Collection
    End Sub
End Class
