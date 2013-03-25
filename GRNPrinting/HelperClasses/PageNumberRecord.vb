Imports System.drawing

Public Class PageNumberRecord

    Private pText As TextLine
    Private pRect As Rectangle
    Private pYPosition As Single
    Private pShowTotalPages As Boolean

    Public Property ColumnNo() As Integer
        Get
            Return pText.ColumnNo
        End Get
        Set(ByVal value As Integer)
            pText.ColumnNo = value
        End Set
    End Property

    Public Property Text() As String
        Get
            Return pText.Text
        End Get
        Set(ByVal value As String)
            pText.Text = value
        End Set
    End Property

    Public Property TextFont() As Font
        Get
            Return pText.TextFont
        End Get
        Set(ByVal value As Font)
            pText.TextFont = value
        End Set
    End Property

    Public Property Rect() As Rectangle
        Get
            Return pRect
        End Get
        Set(ByVal value As Rectangle)
            pRect = value
        End Set
    End Property

    Public Property Pen() As System.Drawing.Pen
        Get
            Return pText.TextPen
        End Get
        Set(ByVal value As Pen)
            pText.TextPen = value
        End Set
    End Property

    Public Property YPosition() As Integer
        Get
            Return CInt(pYPosition)
        End Get
        Set(ByVal value As Integer)
            pYPosition = value
        End Set
    End Property

    Public Property ShowTotalPages() As Boolean
        Get
            Return pShowTotalPages
        End Get
        Set(ByVal value As Boolean)
            pShowTotalPages = value
        End Set
    End Property

    Public Sub New()
        pText = New TextLine("")
    End Sub

End Class
