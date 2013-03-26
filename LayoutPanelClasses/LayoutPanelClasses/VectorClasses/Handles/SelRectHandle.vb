Imports System.Drawing

<Serializable()> Public Class SelRectHandle
    Inherits AbstractSelect

    Public Sub New(ByVal el As BaseElement)
        MyBase.New(el)
        setup()
    End Sub

    Public Sub setup()
        If Not Me.AmIaGroup Then
            '//NW
            Me.handleList.Add(New RedimHandle(Me, "NW"))
            '//SE
            Me.handleList.Add(New RedimHandle(Me, "SE"))
            If Not IsALine Then
                '//N
                Me.handleList.Add(New RedimHandle(Me, "N"))
                If (rotates) Then
                    '//ROT
                    Me.handleList.Add(New RotateHandle(Me, "ROT"))
                End If
                '//NE
                Me.handleList.Add(New RedimHandle(Me, "NE"))
                '//E
                Me.handleList.Add(New RedimHandle(Me, "E"))
                '//S
                Me.handleList.Add(New RedimHandle(Me, "S"))
                '//SW
                Me.handleList.Add(New RedimHandle(Me, "SW"))
                '//W
                Me.handleList.Add(New RedimHandle(Me, "W"))
            End If
        Else
            '//N
            Me.handleList.Add(New RedimHandle(Me, "N"))
            If (rotates) Then
                '//ROT
                Me.handleList.Add(New RotateHandle(Me, "ROT"))
            End If
            '//E
            Me.handleList.Add(New RedimHandle(Me, "E"))
            '//S
            Me.handleList.Add(New RedimHandle(Me, "S"))
            '//W
            Me.handleList.Add(New RedimHandle(Me, "W"))
            '//ZOOM
            Me.handleList.Add(New ZoomHandle(Me, "ZOOM"))

        End If
    End Sub

    Public Overrides Sub Draw(ByVal g As Graphics, ByVal dx As Integer, ByVal dy As Integer, ByVal zoom As Single)
        MyBase.Draw(g, dx, dy, zoom)
        Dim myPen As System.Drawing.Pen = New System.Drawing.Pen(System.Drawing.Color.Blue, 1.5F)
        myPen.DashStyle = Drawing2D.DashStyle.Dash
        If (Me.IsALine) Then
            g.DrawLine(myPen, (Me.X + dx) * zoom, (Me.Y + dy) * zoom, (Me.X1 + dx) * zoom, (Me.Y1 + dy) * zoom)
        Else
            g.DrawRectangle(myPen, (Me.X + dx) * zoom, (Me.Y + dy) * zoom, (Me.X1 - Me.X) * zoom, (Me.Y1 - Me.Y) * zoom)
            myPen.Dispose()
        End If
    End Sub

End Class
