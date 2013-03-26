Imports System.Drawing


Public Class RedimHandle
    Inherits Handle

    Public Sub New(ByVal e As BaseElement, ByVal o As String)
        MyBase.New(e, o)
        Me.fillColor = Color.Black
    End Sub

    Public Overrides Sub rePosition(ByVal e As BaseElement)
        Select Case Me.op
            Case "NW"
                Me.X = e.getX() - 2
                Me.Y = e.getY() - 2

            Case "N"
                Me.X = CInt(e.getX() - 2 + ((e.getX1() - e.getX()) / 2))
                Me.Y = e.getY() - 2

            Case "NE"
                Me.X = e.getX1() - 2
                Me.Y = e.getY() - 2

            Case "E"
                Me.X = e.getX1() - 2
                Me.Y = CInt(e.getY() - 2 + (e.getY1() - e.getY()) / 2)

            Case "SE"
                Me.X = e.getX1() - 2
                Me.Y = e.getY1() - 2

            Case "S"
                Me.X = CInt(e.getX() - 2 + (e.getX1() - e.getX()) / 2)
                Me.Y = e.getY1() - 2

            Case "SW"
                Me.X = e.getX() - 2
                Me.Y = e.getY1() - 2

            Case "W"
                Me.X = e.getX() - 2
                Me.Y = CInt(e.getY() - 2 + (e.getY1() - e.getY()) / 2)

        End Select
        Me.X1 = Me.X + 5
        Me.Y1 = Me.Y + 5
    End Sub

    Public Overrides Sub Draw(ByVal g As Graphics, ByVal dx As Integer, ByVal dy As Integer, ByVal zoom As Single)
        Dim myBrush As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(Me.fillColor)
        myBrush.Color = Me.Transparency(Color.Black, 80)
        Dim whitePen As System.Drawing.Pen = New System.Drawing.Pen(System.Drawing.Color.White)
        g.FillRectangle(myBrush, New RectangleF((Me.X + dx) * zoom, (Me.Y + dy) * zoom, (Me.X1 - Me.X) * zoom, (Me.Y1 - Me.Y) * zoom))
        g.DrawRectangle(whitePen, (Me.X + dx) * zoom, (Me.Y + dy) * zoom, (Me.X1 - Me.X) * zoom, (Me.Y1 - Me.Y) * zoom)
        myBrush.Dispose()
        whitePen.Dispose()
    End Sub


End Class
   