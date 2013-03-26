<CLSCompliant(True)> _
Public MustInherit Class mvcAbstractPresenter
    Implements IObserver

    Protected BaseView As IView
    Protected BaseModel As mvcLibrary.IModel1

    Public ReadOnly Property View() As IView
        Get
            Return Me.BaseView
        End Get
    End Property

    Public Sub New(ByVal aView As IView, ByVal aModel As mvcLibrary.IModel1)
        Me.BaseView = aView
        BaseModel = aModel
    End Sub

    Public MustOverride Sub UpdateData(ByVal NewEvent As mvcEventArgsBase) Implements IObserver.UpdateData

End Class
