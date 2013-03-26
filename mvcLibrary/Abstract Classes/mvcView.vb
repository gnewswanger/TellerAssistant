Public Class mvcView

    Private myModel As mvcAbstractModel
    Private myController As mvcAbstractPresenter

    Public ReadOnly Property Model() As mvcAbstractModel
        Get
            Return myModel
        End Get
    End Property

    Public Property Controller() As mvcAbstractPresenter
        Get
            Return myController
        End Get
        Set(ByVal Value As mvcAbstractPresenter)
            myController = Value
        End Set
    End Property

    Public Overridable Sub Initialize(ByVal aModel As mvcAbstractModel, ByVal aController As mvcAbstractPresenter)
        myModel = aModel
        myModel.AttachObserver(CType(Me, mvcLibrary.IObserver))
        myController = aController
    End Sub

    Public Overridable Sub Display()
        If Me.MdiParent Is Nothing Then
            Me.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
            Me.ShowDialog()
        Else
            Me.Show()
        End If
    End Sub

End Class