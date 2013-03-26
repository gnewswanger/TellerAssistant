Imports System.Drawing
Imports System.ComponentModel
Imports System.Drawing.Drawing2D

<Serializable()> Public Class Rect
    Inherits BaseElement
    Implements mvcLibrary.IObserver


    Public Sub New(ByVal elName As String, ByVal x As Integer, ByVal y As Integer, ByVal x1 As Integer, ByVal y1 As Integer) ', ByVal drawVerticle As Boolean)
        'If drawVerticle Then
        Me.Name = elName
        Me.X = x
        Me.Y = y
        Me.X1 = x1
        Me.Y1 = y1
        'Else
        'Me.X = y
        'Me.Y = x
        'Me.X1 = y1
        'Me.Y1 = x1
        'End If
        Me.Selected = True
        Me.endMoveRedim()
        Me.rotates = False
        Me.filled = False
    End Sub

    Public Overridable ReadOnly Property ObjectType() As String
        Get
            Return "Rectangle"
        End Get
    End Property

    Public Overrides ReadOnly Property TopLeft() As System.Drawing.Point
        Get
            Return MyBase.TopLeft
        End Get
    End Property

    Public Overrides ReadOnly Property TopRight() As System.Drawing.Point
        Get
            Return MyBase.TopRight
        End Get
    End Property

    Public Overrides ReadOnly Property BottomLeft() As System.Drawing.Point
        Get
            Return MyBase.BottomLeft
        End Get
    End Property

    Public Overrides ReadOnly Property BottomRight() As System.Drawing.Point
        Get
            Return MyBase.BottomRight
        End Get
    End Property

    Public Overridable ReadOnly Property SnapPoints() As System.Collections.Generic.List(Of System.Drawing.Point)
        Get
            Dim retList As New List(Of Point)
            retList.Add(MyBase.TopLeft)
            retList.Add(MyBase.TopRight)
            retList.Add(MyBase.BottomLeft)
            retList.Add(MyBase.BottomRight)
            Return retList
        End Get
    End Property

    Public Property Rotation() As Integer
        Get
            Return MyBase._rotation
        End Get
        Set(ByVal value As Integer)
            MyBase._rotation = value
        End Set
    End Property

    Public Overrides Function Copy() As BaseElement
        Dim newE As Rect = New Rect(Me.Name, Me.X, Me.Y, Me.X1, Me.Y1)
        newE.penColor = Me.penColor
        newE.penWidth = Me.penWidth
        newE.fillColor = Me.fillColor
        newE.filled = Me.filled
        newE.dashstyle = Me.dashstyle
        newE.alpha = Me.alpha
        newE.IsALine = Me.IsALine
        newE.Rotation = Me.Rotation
        newE.showBorder = Me.showBorder

        newE.OnGrpXRes = Me.OnGrpXRes
        newE.OnGrpX1Res = Me.OnGrpX1Res
        newE.OnGrpYRes = Me.OnGrpYRes
        newE.OnGrpY1Res = Me.OnGrpY1Res

        newE.copyGradprop(Me)

        Return newE
    End Function

    Public Overrides Sub CopyFrom(ByVal ele As BaseElement)
        Me.copyStdProp(ele, Me)
        Me.Rotation = CType(ele, Rect).Rotation
    End Sub

    Public Overrides Sub SelectObj()
        Me.undoEle = Me.Copy()
    End Sub

    Public Overrides Sub AddGp(ByVal gp As GraphicsPath, ByVal dx As Integer, ByVal dy As Integer, ByVal zoom As Single)
        gp.AddRectangle(New RectangleF((Me.X + dx) * zoom, (Me.Y + dy) * zoom, (Me.X1 - Me.X) * zoom, (Me.Y1 - Me.Y) * zoom))
    End Sub

    Public Overrides Sub Draw(ByVal g As Graphics, ByVal dx As Integer, ByVal dy As Integer, ByVal zoom As Single)
        Dim myBrush As System.Drawing.SolidBrush = CType(getBrush(dx, dy, zoom), SolidBrush)
        Dim myPen As System.Drawing.Pen = New System.Drawing.Pen(Me.penColor, scaledPenWidth(zoom))
        myPen.DashStyle = Drawing2D.DashStyle.Dash

        If (Me.Selected) Then
            myPen.Color = Color.Red
            myPen.Color = Me.Transparency(myPen.Color, 120)
            myPen.Width = myPen.Width + 1
        End If

        ' // Create a path and add the object.
        Dim myPath As GraphicsPath = New GraphicsPath()
        myPath.AddRectangle(New RectangleF((Me.X + dx) * zoom, (Me.Y + dy) * zoom, (Me.X1 - Me.X) * zoom, (Me.Y1 - Me.Y) * zoom))
        Dim translateMatrix As Matrix = New Matrix()
        translateMatrix.RotateAt(Me.Rotation, New PointF((Me.X + dx + CInt((Me.X1 - Me.X) / 2) * zoom), (Me.Y + dy + CInt((Me.Y1 - Me.Y) / 2) * zoom)))
        myPath.Transform(translateMatrix)

        ' // Draw the transformed ellipse to the screen.
        If Me.filled Then
            g.FillPath(myBrush, myPath)
            If (Me.showBorder) Then
                g.DrawPath(myPen, myPath)
            End If
        Else
            g.DrawPath(myPen, myPath)
        End If

        myPath.Dispose()
        myPen.Dispose()

        If Not myBrush Is Nothing Then
            myBrush.Dispose()
        End If

    End Sub

    Public Sub UpdateData(ByVal NewEvent As mvcLibrary.mvcEventArgsBase) Implements mvcLibrary.IObserver.UpdateData

    End Sub
End Class
