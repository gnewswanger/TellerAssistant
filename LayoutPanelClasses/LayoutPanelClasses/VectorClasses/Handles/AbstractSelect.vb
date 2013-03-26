Imports System.Drawing

<Serializable()> Public MustInherit Class AbstractSelect
    Inherits BaseElement

    Protected handleList As ArrayList

    Public Sub New(ByVal el As BaseElement)
        Me.X = el.getX()
        Me.Y = el.getY()
        Me.X1 = el.getX1()
        Me.Y1 = el.getY1()
        Me.Selected = False
        Me.rotates = el.canRotate()
        Me._rotation = el.getRotation()
        Me.gprZoomX = el.getGprZoomX()
        Me.gprZoomY = el.getGprZoomY()
        Me.IsALine = el.IsALine
        Me.IsGrouped = el.AmIaGroup()
        Me.handleList = New ArrayList()
        Me.endMoveRedim()
    End Sub

    Public Overrides Sub endMoveRedim()
        MyBase.endMoveRedim()
        For Each h As Handle In handleList
            h.endMoveRedim()
        Next
    End Sub

    Public Sub setZoom(ByVal x As Single, ByVal y As Single)
        Me.gprZoomX = x
        Me.gprZoomY = y
        For Each h As Handle In handleList
            h.rePosition(Me)
        Next
    End Sub

    Public Overrides Sub Rotate(ByVal x As Single, ByVal y As Single)
        MyBase.Rotate(x, y)
        For Each h As Handle In handleList
            h.rePosition(Me)
        Next
    End Sub

    Public Overrides Sub move(ByVal x As Integer, ByVal y As Integer)
        MyBase.move(x, y)
        For Each h As Handle In handleList
            h.rePosition(Me)
        Next
    End Sub

    Public Sub showHandles(ByVal i As Boolean)
        Me.IsGrouped = i
    End Sub

    Public Function isOver(ByVal x As Integer, ByVal y As Integer) As String
        Dim ret As String
        For Each h As Handle In handleList
            ret = h.isOver(x, y)
            If Not ret = "" Then
                Return ret
            End If
        Next
        If (Me.contains(x, y)) Then
            Return "C"
        End If
        Return "NO"
    End Function

    Public Overrides Sub SelectObj()
        Me.undoEle = Me.Copy()
    End Sub

    Public Overrides Sub redimension(ByVal x As Integer, ByVal y As Integer, ByVal redimSt As String)
        MyBase.redimension(x, y, redimSt)
        For Each h As Handle In handleList
            h.rePosition(Me)
        Next

    End Sub

    Public Overrides Sub Draw(ByVal g As Graphics, ByVal dx As Integer, ByVal dy As Integer, ByVal zoom As Single)
        For Each h As Handle In handleList
            h.Draw(g, dx, dy, zoom)
        Next
    End Sub


End Class
