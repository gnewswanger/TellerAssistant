Public Class TextLine

    Private pColumnNo As Integer
    Private pText As String
    Private pParams As TextLineParams
    Private pNewLine As Boolean

#Region "Class Properties"

    Public Property ColumnNo() As Integer
        Get
            Return pColumnNo
        End Get
        Set(ByVal value As Integer)
            pColumnNo = value
        End Set
    End Property

    Public Property Text() As String
        Get
            Return pText
        End Get
        Set(ByVal value As String)
            pText = value
        End Set
    End Property

    Public Property TextFont() As System.Drawing.Font
        Get
            Return pParams.TextFont
        End Get
        Set(ByVal value As System.Drawing.Font)
            pParams.TextFont = value
        End Set
    End Property

    Public Property TextPen() As System.Drawing.Pen
        Get
            Return pParams.TextPen
        End Get
        Set(ByVal value As System.Drawing.Pen)
            pParams.TextPen = value
        End Set
    End Property

    'Horizontal Alignment
    Public Property LineAlignment() As System.Drawing.StringAlignment
        Get
            Return pParams.LineAlignment
        End Get
        Set(ByVal value As System.Drawing.StringAlignment)
            pParams.LineAlignment = value
        End Set
    End Property

    Public Property Alignment() As System.Drawing.StringAlignment
        Get
            Return pParams.Alignment
        End Get
        Set(ByVal value As System.Drawing.StringAlignment)
            pParams.Alignment = value
        End Set
    End Property

    Public ReadOnly Property TextFormat() As System.Drawing.StringFormat
        Get
            Return pParams.TextFormat
        End Get
    End Property

    Public Property IsBoxed() As Boolean
        Get
            Return pParams.IsBoxed
        End Get
        Set(ByVal value As Boolean)
            pParams.IsBoxed = value
        End Set
    End Property

    Public Property BoxPen() As System.Drawing.Pen
        Get
            Return pParams.BoxPen
        End Get
        Set(ByVal value As System.Drawing.Pen)
            pParams.BoxPen = value
        End Set
    End Property

    Public Property NewLine() As Boolean
        Get
            Return pNewLine
        End Get
        Set(ByVal value As Boolean)
            pNewLine = value
        End Set
    End Property

#End Region

    Public Sub New(ByVal text As String, Optional ByVal col As Integer = 0, Optional ByVal parms As GRNPrinting.TextLineParams = Nothing, Optional ByVal newline As Boolean = False)
        pText = text
        pColumnNo = col
        pNewLine = newline
        If parms Is Nothing Then
            pParams = New GRNPrinting.TextLineParams
        Else
            pParams = parms
        End If

    End Sub
End Class
