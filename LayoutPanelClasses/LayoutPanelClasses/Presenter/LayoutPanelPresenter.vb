
Public Class LayoutPanelPresenter
    Inherits mvcLibrary.mvcAbstractPresenter


    Public Sub New(ByVal aView As IViewLayoutPanel)
        MyBase.New(aView, New LayoutPanelModel())
        MyBase.BaseModel.AttachObserver(Me)
    End Sub


    Public Overrides Sub UpdateData(ByVal NewEvent As mvcLibrary.mvcEventArgsBase)

    End Sub
End Class
