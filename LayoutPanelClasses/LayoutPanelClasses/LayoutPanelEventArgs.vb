Public Class LayoutPanelEventArgs
    Inherits mvcLibrary.mvcEventArgsBase

    Private _value As Object
    Private _size As System.Drawing.Size

    Public ReadOnly Property CanvasWidth() As Integer
        Get
            Return _size.Width
        End Get
    End Property

    Public ReadOnly Property CanvasHeight() As Integer
        Get
            Return _size.Height
        End Get
    End Property

    Public Property EvValue() As Object
        Get
            Return _value
        End Get
        Set(ByVal value As Object)
            _value = value
        End Set
    End Property

    Public Sub New(ByVal eventName As String)
        MyBase.New(eventName)

    End Sub

    Public Sub New(ByVal eventName As String, ByVal value As Object, ByVal size As System.Drawing.Size)
        MyBase.New(eventName)
        _value = value
        _size = size
    End Sub


End Class
