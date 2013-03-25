Imports System.Drawing

Public Class TextLineParams

    Private pTextFont As Font
    Private pTextPen As Pen
    Private pTextFormat As System.Drawing.StringFormat
    Private pIsBoxed As Boolean
    Private pBoxPen As Pen

#Region "Class Properties"

    Public Property TextFont() As System.Drawing.Font
        Get
            Return pTextFont
        End Get
        Set(ByVal value As System.Drawing.Font)
            pTextFont = value
        End Set
    End Property

    Public Property TextPen() As System.Drawing.Pen
        Get
            Return pTextPen
        End Get
        Set(ByVal value As System.Drawing.Pen)
            pTextPen = value
        End Set
    End Property

    'Horizontal Alignment
    Public Property LineAlignment() As System.Drawing.StringAlignment
        Get
            Return pTextFormat.LineAlignment
        End Get
        Set(ByVal value As System.Drawing.StringAlignment)
            pTextFormat.LineAlignment = value
        End Set
    End Property

    'Vertical Alignment
    Public Property Alignment() As System.Drawing.StringAlignment
        Get
            Return pTextFormat.Alignment
        End Get
        Set(ByVal value As System.Drawing.StringAlignment)
            pTextFormat.Alignment = value
        End Set
    End Property

    Public ReadOnly Property TextFormat() As System.Drawing.StringFormat
        Get
            Return pTextFormat
        End Get
    End Property

    Public Property IsBoxed() As Boolean
        Get
            Return pIsBoxed
        End Get
        Set(ByVal value As Boolean)
            pIsBoxed = value
        End Set
    End Property

    Public Property BoxPen() As System.Drawing.Pen
        Get
            Return pBoxPen
        End Get
        Set(ByVal value As System.Drawing.Pen)
            pBoxPen = value
        End Set
    End Property

#End Region

    Public Sub New()
        SetDefaultParams()
    End Sub

    Public Sub New(ByVal parms As TextLineParams)
        If parms Is Nothing Then
            SetDefaultParams()
        Else
            pTextFormat = New StringFormat(parms.TextFormat)
            pTextFont = New Font(parms.TextFont, parms.TextFont.Style)
            pTextPen = New Pen(parms.TextPen.Color)
            pIsBoxed = parms.IsBoxed
            pBoxPen = New Pen(parms.BoxPen.Color)
        End If
    End Sub

    Private Sub SetDefaultParams()
        pTextFormat = New System.Drawing.StringFormat
        pTextFormat.Alignment = StringAlignment.Near
        pTextFormat.LineAlignment = StringAlignment.Near
        pTextFont = New Font("Times New Roman", 10, FontStyle.Bold)
        pTextPen = New Pen(Color.Black)
        pIsBoxed = False
        pBoxPen = New Pen(Color.DodgerBlue)
    End Sub

End Class
