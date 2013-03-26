Imports System.Drawing

<Serializable()> Public Class ZoomHandle
    Inherits Handle

    Public Sub New(ByVal e As BaseElement, ByVal o As Object)
        MyBase.New(e, CStr(o))
        Me.fillColor = Color.Red
    End Sub

    Public Overrides Sub rePosition(ByVal e As BaseElement)
        Dim zx As Single = (e.Width - (e.Width * e.getGprZoomX())) / 2
        Dim zy As Single = (e.Height - (e.Height * e.getGprZoomY())) / 2
        Me.X = CInt((e.getX1() - 2) - zx)
        Me.Y = CInt((e.getY1() - 2) - zy)
        Me.X1 = Me.X + 5
        Me.Y1 = Me.Y + 5
    End Sub

    Public Overrides Sub Draw(ByVal g As Graphics, ByVal dx As Integer, ByVal dy As Integer, ByVal zoom As Single)
        Dim myBrush As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(Me.fillColor)
        myBrush.Color = Me.Transparency(myBrush.Color, 80)
        Dim whitePen As System.Drawing.Pen = New System.Drawing.Pen(System.Drawing.Color.White)
        Dim fillPen As System.Drawing.Pen = New System.Drawing.Pen(Me.fillColor)
        g.FillRectangle(myBrush, New RectangleF((Me.X + dx) * zoom, (Me.Y + dy) * zoom, (Me.X1 - Me.X) * zoom, (Me.Y1 - Me.Y) * zoom))
        g.DrawRectangle(whitePen, (Me.X + dx) * zoom, (Me.Y + dy) * zoom, (Me.X1 - Me.X) * zoom, (Me.Y1 - Me.Y) * zoom)
        g.DrawRectangle(fillPen, (Me.X + dx) * zoom, (Me.Y + dy) * zoom, (Me.X1 - Me.X) * zoom, (Me.Y1 - Me.Y) * zoom)
        myBrush.Dispose()
        whitePen.Dispose()
        fillPen.Dispose()
    End Sub
    

End Class
