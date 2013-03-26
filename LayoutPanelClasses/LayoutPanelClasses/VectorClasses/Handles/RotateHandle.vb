Imports System.Drawing

<Serializable()> Public Class RotateHandle
    Inherits Handle

    Public Sub New(ByVal e As BaseElement, ByVal o As Object)
        MyBase.New(e, CStr(o))
    End Sub

    Public Overrides Sub rePosition(ByVal e As BaseElement)
        Dim midX As Single = 0
        Dim midY As Single = 0
        midX = CSng((e.getX1() - e.getX()) / 2)
        midY = CSng((e.getY1() - e.getY()) / 2)
        Dim Hp As PointF = New PointF(0, -25)
        Dim RotHP As PointF = Me.rotatePoint(Hp, e.getRotation())
        midX += RotHP.X
        midY += RotHP.Y

        Me.X = e.getX() + CInt(midX - 2)
        Me.Y = e.getY() + CInt(midY - 2)
        Me._rotation = e.getRotation()

        Me.X1 = Me.X + 5
        Me.Y1 = Me.Y + 5
    End Sub

    Public Overrides Sub Draw(ByVal g As Graphics, ByVal dx As Integer, ByVal dy As Integer, ByVal zoom As Single)
        Dim myBrush As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(System.Drawing.Color.Black)
        myBrush.Color = Me.Transparency(Color.Black, 80)
        Dim whitePen As System.Drawing.Pen = New System.Drawing.Pen(System.Drawing.Color.White)
        Dim myPen As System.Drawing.Pen = New System.Drawing.Pen(System.Drawing.Color.Blue, 1.5F)
        myPen.DashStyle = Drawing2D.DashStyle.Dash
        g.FillRectangle(myBrush, New RectangleF((Me.X + dx) * zoom, (Me.Y + dy) * zoom, (Me.X1 - Me.X) * zoom, (Me.Y1 - Me.Y) * zoom))
        g.DrawRectangle(whitePen, (Me.X + dx) * zoom, (Me.Y + dy) * zoom, (Me.X1 - Me.X) * zoom, (Me.Y1 - Me.Y) * zoom)

        '//CENTER POINT  
        Dim midX As Single = 0
        Dim midY As Single = 0
        midX = CSng((Me.X1 - Me.X) / 2)
        midY = CSng((Me.Y1 - Me.Y) / 2)

        Dim Hp As PointF = New PointF(0, 25)
        Dim RotHP As PointF = Me.rotatePoint(Hp, Me._rotation)
        RotHP.X += Me.X
        RotHP.Y += Me.Y

        g.FillEllipse(myBrush, (RotHP.X + midX + dx - 3) * zoom, (RotHP.Y + dy - 3 + midY) * zoom, 6 * zoom, 6 * zoom)
        g.DrawEllipse(whitePen, (RotHP.X + midX + dx - 3) * zoom, (RotHP.Y + dy - 3 + midY) * zoom, 6 * zoom, 6 * zoom)
        g.DrawLine(myPen, (Me.X + midX + dx) * zoom, (Me.Y + midY + dy) * zoom, (RotHP.X + midX + dx) * zoom, (RotHP.Y + midY + dy) * zoom)

        myPen.Dispose()
        myBrush.Dispose()
        whitePen.Dispose()
    End Sub



End Class


    