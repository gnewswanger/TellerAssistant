Imports System.Drawing

Public Class TextBlockRecord
    Implements mvcLibrary.IObserver

#Region "Class Variables"
    Private blockType As BlockTypes
    Private pLines As List(Of TextLine)
    Private pGrowRect As Boolean
    Private pRect As Rectangle
    Private pRectHeight As Integer
    Private pDefParams As TextLineParams
    Private pShading As Color
    Private pYPosition As Single
#End Region

#Region "Class Properties"

    Public Property Rect() As Rectangle
        Get
            Return pRect
        End Get
        Set(ByVal value As Rectangle)
            pRect = value
        End Set
    End Property

    Public Property RectHeight() As Integer
        Get
            Return pRectHeight
        End Get
        Set(ByVal value As Integer)
            pRectHeight = value
        End Set
    End Property

    Public Property IsBoxed() As Boolean
        Get
            Return pDefParams.IsBoxed
        End Get
        Set(ByVal value As Boolean)
            pDefParams.IsBoxed = value
        End Set
    End Property

    Public Property DefaultPen() As System.Drawing.Pen
        Get
            Return pDefParams.TextPen
        End Get
        Set(ByVal value As Pen)
            pDefParams.TextPen = value
        End Set
    End Property

    Public Property DefaultFont() As System.Drawing.Font
        Get
            Return pDefParams.TextFont
        End Get
        Set(ByVal value As System.Drawing.Font)
            pDefParams.TextFont = value
        End Set
    End Property
    Public Property Shading() As Color
        Get
            Return pShading
        End Get
        Set(ByVal value As Color)
            pShading = value
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

    Public ReadOnly Property LineCount() As Integer
        Get
            Return pLines.Count
        End Get
    End Property

    Public ReadOnly Property LineColumn(ByVal lineIndex As Integer) As Integer
        Get
            Return CType(pLines(lineIndex), TextLine).ColumnNo
        End Get
    End Property

#End Region

    Public Sub New(ByVal type As BlockTypes, ByVal rect As Rectangle, Optional ByVal boxed As Boolean = False, Optional ByVal growRect As Boolean = True)
        blockType = type
        pRect = rect
        pRectHeight = pRect.Height
        pGrowRect = growRect
        pLines = New List(Of TextLine)
        pDefParams = New TextLineParams
        IsBoxed = boxed
    End Sub

    Public Sub AddTextLine(ByVal line As String, Optional ByVal col As Integer = 0, Optional ByVal parms As TextLineParams = Nothing, Optional ByVal newline As Boolean = False)
        Dim txtLine As New TextLine(line, col, New TextLineParams(parms), newline)
        pLines.Add(txtLine)
        If pGrowRect Then
            If txtLine.NewLine Then
                RectHeight = CInt(RectHeight + txtLine.TextFont.GetHeight)
            Else
                If RectHeight < txtLine.TextFont.GetHeight Then
                    RectHeight = CInt(txtLine.TextFont.GetHeight)
                End If
            End If
            Rect = New Rectangle(Rect.X, Rect.Y, Rect.Width, RectHeight)
        End If
    End Sub
    Public Sub ClearLines()
        pLines.Clear()
    End Sub

    Public Function GetTextLine(ByVal lineIndex As Integer) As TextLine
        Return pLines(lineIndex)
    End Function

    Public Sub UpdateData(ByVal NewEvent As mvcLibrary.mvcEventArgsBase) Implements mvcLibrary.IObserver.UpdateData
        Select Case CType(NewEvent, AbstractPrintEventArgs).Name
            Case PrintEventName.peLandscapeChanged
                If Me.blockType = BlockTypes.btHeader Or Me.blockType = BlockTypes.btFooter Then
                    Dim settings As System.Drawing.Printing.PageSettings = CType(CType(NewEvent, AbstractPrintEventArgs).Value, System.Drawing.Printing.PageSettings)
                    Rect = New Rectangle(settings.Margins.Left, Rect.Y, _
                    settings.Bounds.Width - settings.Margins.Left - settings.Margins.Right, RectHeight)
                End If
            Case PrintEventName.peColumnWidthChanged
                If Me.blockType = BlockTypes.btHeader Or Me.blockType = BlockTypes.btFooter Then
                    Dim value As GRNPrinting.ColumnClass = CType(CType(NewEvent, AbstractPrintEventArgs).Value, ColumnClass)
                    Rect = New Rectangle(value.ColumnLeft, Rect.Y, value.ColumnWidth, RectHeight)
                End If
        End Select

    End Sub
End Class
