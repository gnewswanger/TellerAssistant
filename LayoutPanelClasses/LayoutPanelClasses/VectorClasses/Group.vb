Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class Group
    Inherits BaseElement
    Implements mvcLibrary.IObserver

    Private objs As ArrayList
    Private _graphPath As Boolean = False
    Private _groupname As String = ""
    Public Shared Ngrp As Integer   'Used to generate names

    Public Sub New(ByVal a As ArrayList)
        Me.IsGrouped = True
        objs = a

        Dim minX As Integer = +32000
        Dim maxX As Integer = -32000
        Dim minY As Integer = +32000
        Dim maxY As Integer = -32000
        For Each e As BaseElement In objs
            If e.getX < minX Then
                minX = e.getX
            End If
            If e.getY < minY Then
                minY = e.getY
            End If
            If e.getX1 > maxX Then
                maxX = e.getX1
            End If
            If e.getY1 > maxY Then
                maxY = e.getY1
            End If
        Next
        Me.X = minX
        Me.Y = minY
        Me.X1 = maxX
        Me.Y1 = maxY
        Me.Selected = True
        Me.endMoveRedim()
        'Me.Rotation = 0
        Me.rotates = True
        Me.Name = "Itm" + Ngrp.ToString()
        Ngrp += 1

    End Sub


#Region "Class Properties"

    <CategoryAttribute("GroupZoom"), DescriptionAttribute("X Scale Zoom ")> _
            Public Property GrpZoomX() As Single
        Get
            Return Me.gprZoomX
        End Get
        Set(ByVal value As Single)
            If (value > 0) Then
                Me.gprZoomX = value
            End If
        End Set
    End Property



    <CategoryAttribute("GroupZoom"), DescriptionAttribute("Y Scale Zoom ")> _
            Public Property GrpZoomY() As Single
        Get
            Return Me.gprZoomY
        End Get
        Set(ByVal value As Single)
            If (value > 0) Then
                Me.gprZoomY = value
            End If
        End Set
    End Property

    <CategoryAttribute("GradientBrush"), DescriptionAttribute("True: use gradient fill color")> _
    Public Overrides Property UseGradientLineColor() As Boolean
        Get
            Return MyBase.UseGradientLineColor
        End Get
        Set(ByVal value As Boolean)
            MyBase.UseGradientLineColor = value
            If Not Me.objs Is Nothing Then
                For Each e As BaseElement In Me.objs
                    e.UseGradientLineColor = value
                Next
            End If
        End Set
    End Property

    <CategoryAttribute("GradientBrush"), DescriptionAttribute("End Color Position [0..1])")> _
       Public Overrides Property EndColorPosition() As Single
        Get
            Return MyBase.EndColorPosition
        End Get
        Set(ByVal value As Single)
            MyBase.EndColorPosition = value
            If Not Me.objs Is Nothing Then
                For Each e As BaseElement In Me.objs
                    e.EndColorPosition = value
                Next
            End If
        End Set
    End Property

    <CategoryAttribute("GradientBrush"), DescriptionAttribute("Gradient End Color")> _
     Public Overrides Property EndColor() As Color
        Get
            Return MyBase.EndColor
        End Get
        Set(ByVal value As Color)
            MyBase.EndColor = value
            If Not Me.objs Is Nothing Then
                For Each e As BaseElement In Me.objs
                    e.EndColor = value
                Next
            End If
        End Set
    End Property

    <CategoryAttribute("GradientBrush"), DescriptionAttribute("End Color Trasparency")> _
    Public Overrides Property EndAlpha() As Integer
        Get
            Return MyBase.EndAlpha
        End Get
        Set(ByVal value As Integer)
            MyBase.EndAlpha = value
            If Not Me.objs Is Nothing Then
                For Each e As BaseElement In Me.objs
                    e.EndAlpha = value
                Next
            End If
        End Set
    End Property

    <CategoryAttribute("GradientBrush"), DescriptionAttribute("Gradient Dimension")> _
Public Overrides Property GradientLen() As Integer
        Get
            Return MyBase.GradientLen
        End Get
        Set(ByVal value As Integer)
            MyBase.GradientLen = value
            If Not Me.objs Is Nothing Then
                For Each e As BaseElement In objs
                    e.GradientLen = value
                Next
            End If
        End Set
    End Property


    <CategoryAttribute("GradientBrush"), DescriptionAttribute("Gradient Angle")> _
            Public Overrides Property GradientAngle() As Integer
        Get
            Return MyBase.GradientAngle
        End Get
        Set(ByVal value As Integer)
            MyBase.GradientAngle = value
            If Not Me.objs Is Nothing Then
                For Each e As BaseElement In objs
                    e.GradientAngle = value
                Next
            End If
        End Set
    End Property

    Public Overrides Property alpha() As Integer
        Get
            Return MyBase.alpha
        End Get
        Set(ByVal value As Integer)
            MyBase.alpha = value
            If Not Me.objs Is Nothing Then
                For Each e As BaseElement In Me.objs
                    e.alpha = value
                Next
            End If
        End Set
    End Property

    Public Property GroupName() As String
        Get
            Return _groupname
        End Get
        Set(ByVal value As String)
            If (value <> "") Then
                _groupname = value
            End If
        End Set
    End Property

    <DescriptionAttribute("Manage group as a graphic path.")> _
            Public Property graphPath() As Boolean
        Get
            Return _graphPath
        End Get
        Set(ByVal value As Boolean)
            _graphPath = value
        End Set
    End Property

    <DescriptionAttribute("Rotation Angle.")> _
              Public Property Rotation() As Integer
        Get
            Return _rotation
        End Get
        Set(ByVal value As Integer)
            _rotation = value
        End Set
    End Property

    Public Overrides Property fillColor() As Color
        Get
            Return MyBase.fillColor
        End Get
        Set(ByVal value As Color)
            MyBase.fillColor = value
            If Not Me.objs Is Nothing Then
                For Each e As BaseElement In Me.objs
                    e.fillColor = value
                Next
            End If
        End Set
    End Property

    Public Overrides Property filled() As Boolean
        Get
            Return MyBase.filled
        End Get
        Set(ByVal value As Boolean)
            MyBase.filled = value
            If Not Me.objs Is Nothing Then
                For Each e As BaseElement In Me.objs
                    e.filled = value
                Next
            End If
        End Set
    End Property

    Public Overrides Property penColor() As Color
        Get
            Return MyBase.penColor
        End Get
        Set(ByVal value As Color)
            MyBase.penColor = value
            If Not Me.objs Is Nothing Then
                For Each e As BaseElement In Me.objs
                    e.penColor = value
                Next
            End If
        End Set
    End Property

    Public Overrides Property penWidth() As Single
        Get
            Return MyBase.penWidth
        End Get
        Set(ByVal value As Single)
            MyBase.penWidth = value
            If Not Me.objs Is Nothing Then
                For Each e As BaseElement In Me.objs
                    e.penWidth = value
                Next
            End If
        End Set
    End Property

    Public Overrides Property showBorder() As Boolean
        Get
            Return MyBase.showBorder
        End Get
        Set(ByVal value As Boolean)
            MyBase.showBorder = value
            If Not Me.objs Is Nothing Then
                For Each e As BaseElement In Me.objs
                    e.showBorder = value
                Next
            End If
        End Set
    End Property

    Public Overrides Property dashLineStyle() As System.Drawing.Drawing2D.DashStyle
        Get
            Return MyBase.dashLineStyle
        End Get
        Set(ByVal value As System.Drawing.Drawing2D.DashStyle)
            MyBase.dashLineStyle = value
            If Not Me.objs Is Nothing Then
                For Each e As BaseElement In Me.objs
                    e.dashLineStyle = value
                Next
            End If
        End Set
    End Property


#End Region

    Public Overrides Sub AfterLoad()
        MyBase.AfterLoad()
        For Each e As BaseElement In objs
            e.AfterLoad()
        Next
    End Sub

    Public Overrides Sub endMoveRedim()
        MyBase.endMoveRedim()
        For Each e As BaseElement In Me.objs
            e.endMoveRedim()
        Next
    End Sub

    Public Overrides Function deGroup() As ArrayList
        Return Me.objs
    End Function

    Public Overrides Sub move(ByVal x As Integer, ByVal y As Integer)
        For Each e As BaseElement In Me.objs
            e.move(x, y)
        Next
        Me.X = Me.startX - x
        Me.Y = Me.startY - y
        Me.X1 = Me.startX1 - x
        Me.Y1 = Me.startY1 - y
    End Sub

    <CategoryAttribute("1"), DescriptionAttribute("GroupObj")> _
    Public ReadOnly Property ObjectType() As String
        Get
            Return "Group"
        End Get
    End Property

    'Public Overrides Sub ShowEditor(ByVal f As richForm2)
    '    For Each e As BaseElement In Me.objs
    '        If e.OnGrpClick Then
    '            e.ShowEditor(f)
    '        End If
    '    Next
    'End Sub

    'Public Sub Load_IMG()
    '    For Each e As BaseElement In Me.objs
    '        If e.OnGrpClick Then
    '            If TypeOf (e) Is ImgBox Then
    '                CType(e, ImgBox).Load_IMG()
    '            End If
    '            If TypeOf (e) Is Group Then
    '                CType(e, Group).Load_IMG()
    '            End If
    '        End If
    '    Next
    'End Sub

    Public Sub setZoom(ByVal x As Integer, ByVal y As Integer)
        Dim dx As Single = (Me.X1 - x) * 2
        Dim dy As Single = (Me.Y1 - y) * 2
        Me.GrpZoomX = (Me.Width - dx) / Me.Width
        Me.GrpZoomY = (Me.Height - dy) / Me.Height
    End Sub

    Public Overrides Function Copy() As BaseElement
        Dim list1 As ArrayList = New ArrayList
        For Each e As BaseElement In Me.objs
            Dim e1 = e.Copy
            list1.Add(e1)
        Next
        Dim newE As Group = New Group(list1)
        newE.Rotation = Me.Rotation

        newE._graphPath = Me._graphPath
        newE.gprZoomX = Me.gprZoomX
        newE.gprZoomY = Me.gprZoomY
        newE.IsGrouped = Me.IsGrouped
        newE._groupname = Me.Name + "_" + Group.Ngrp.ToString()
        newE.OnGrpClick = Me.OnGrpClick
        newE.OnGrpXRes = Me.OnGrpXRes
        newE.OnGrpX1Res = Me.OnGrpX1Res
        newE.OnGrpYRes = Me.OnGrpYRes
        newE.OnGrpY1Res = Me.OnGrpY1Res

        If newE.graphPath Then
            newE.penColor = Me.penColor
            newE.penWidth = Me.penWidth
            newE.fillColor = Me.fillColor
            newE.filled = Me.filled
            newE.dashstyle = Me.dashstyle
            newE.alpha = Me.alpha
            newE.IsALine = Me.IsALine
            newE.Rotation = Me.Rotation
            newE.showBorder = Me.showBorder

            newE.UseGradientLineColor = Me.UseGradientLineColor
            newE.GradientAngle = Me.GradientAngle
            newE.GradientLen = Me.GradientLen
            newE.EndAlpha = Me.EndAlpha
            newE.EndColor = Me.EndColor
            newE.EndColorPosition = Me.EndColorPosition
        End If
        Return newE
    End Function

    Public Overrides Sub CopyFrom(ByVal ele As BaseElement)
        Me.copyStdProp(ele, Me)
    End Sub

    Public Overrides Sub SelectObj()
        Me.undoEle = Me.Copy()
    End Sub

    Public Overrides Sub redimension(ByVal x As Integer, ByVal y As Integer, ByVal redimSt As String)
        For Each e As BaseElement In objs
            Select Case redimSt
                Case "N"
                    MyBase.redimension(x, y, redimSt)
                    If e.OnGrpYRes <> OnGroupResize.DoNothing Then
                        If e.OnGrpYRes = OnGroupResize.Move Then
                            e.move(0, -y)
                        Else
                            e.redimension(0, y, redimSt)
                        End If
                    End If
                Case "E"
                    MyBase.redimension(x, y, redimSt)
                    If e.OnGrpX1Res <> OnGroupResize.DoNothing Then
                        If e.OnGrpX1Res = OnGroupResize.Move Then
                            e.move(-x, 0)
                        Else
                            e.redimension(0, x, redimSt)
                        End If
                    End If
                Case "S"
                    MyBase.redimension(x, y, redimSt)
                    If e.OnGrpY1Res <> OnGroupResize.DoNothing Then
                        If e.OnGrpY1Res = OnGroupResize.Move Then
                            e.move(0, -y)
                        Else
                            e.redimension(0, y, redimSt)
                        End If

                    End If

                Case "W"
                    MyBase.redimension(x, y, redimSt)
                    If e.OnGrpXRes <> OnGroupResize.DoNothing Then
                        If e.OnGrpXRes = OnGroupResize.Move Then
                            e.move(-x, 0)
                        Else
                            e.redimension(x, 0, redimSt)
                        End If
                    End If
            End Select
        Next

    End Sub

    Public Overrides Sub AddGp(ByVal Gp As System.Drawing.Drawing2D.GraphicsPath, ByVal dx As Integer, ByVal dy As Integer, ByVal zoom As Single)
        For Each e As BaseElement In Me.objs
            e.AddGp(Gp, dx, dy, zoom)
        Next
    End Sub

    Public Overrides Sub Draw(ByVal g As System.Drawing.Graphics, ByVal dx As Integer, ByVal dy As Integer, ByVal zoom As Single)
        Dim prevMx As Matrix = g.Transform.Clone
        Dim mx As Matrix = g.Transform
        Dim p As PointF = New PointF(CSng(zoom * (Me.X + dx + (Me.X1 - Me.X) / 2)), CSng(zoom * (Me.Y + dy + (Me.Y1 - Me.Y) / 2)))
        If Me.Rotation > 0 Then
            mx.RotateAt(Me.Rotation, p, MatrixOrder.Append)
        End If
        If Me.GrpZoomX > 0 And Me.GrpZoomY > 0 Then
            mx.Translate(CSng((-1) * zoom * (Me.X + dx + (Me.X1 - Me.X) / 2)), CSng((-1) * zoom * (Me.Y + dy + (Me.Y1 - Me.Y) / 2)), MatrixOrder.Append)
            mx.Scale(Me.GrpZoomX, Me.GrpZoomY, MatrixOrder.Append)
            mx.Translate(CSng(zoom * (Me.X + dx + (Me.X1 - Me.X) / 2)), CSng(zoom * (Me.Y + dy + (Me.Y1 - Me.Y) / 2)), MatrixOrder.Append)
        End If
        g.Transform = mx

        If Me._graphPath Then
            Dim myBrush As Brush = getBrush(dx, dy, zoom)
            Dim myPen As System.Drawing.Pen = New System.Drawing.Pen(Me.penColor, scaledPenWidth(zoom))
            myPen.DashStyle = Me.dashstyle

            If Me.Selected Then
                myPen.Color = Color.Red
                myPen.Color = Me.Transparency(myPen.Color, 120)
                myPen.Width = myPen.Width + 1
            End If

            Dim gp As GraphicsPath = New GraphicsPath
            For Each e As BaseElement In objs
                e.AddGp(gp, dx, dy, zoom)
            Next

            If Me.filled Then
                g.FillPath(myBrush, gp)
                If Me.showBorder Then
                    g.DrawPath(myPen, gp)
                End If
            Else
                g.DrawPath(myPen, gp)
            End If
            myPen.Dispose()
        Else
            For Each e As BaseElement In objs
                e.Draw(g, dx, dy, zoom)
            Next
        End If
        g.Transform = prevMx
        If Me.Selected Then
            Dim myBrush As Brush = getBrush(dx, dy, zoom)
            Dim myPen As System.Drawing.Pen = New System.Drawing.Pen(Me.penColor, scaledPenWidth(zoom))
            myPen.DashStyle = Me.dashstyle
            myPen.Color = Color.Red
            myPen.Color = Me.Transparency(myPen.Color, 120)
            myPen.Width = myPen.Width + 1
            g.DrawRectangle(myPen, (Me.X + dx) * zoom, (Me.Y + dy) * zoom, (Me.X1 - Me.X) * zoom, (Me.Y1 - Me.Y) * zoom)
            If Not myBrush Is Nothing Then
                myBrush.Dispose()
            End If
            myPen.Dispose()
        End If
        mx.Dispose()
        prevMx.Dispose()
    End Sub

    Public Sub UpdateData(ByVal NewEvent As mvcLibrary.mvcEventArgsBase) Implements mvcLibrary.IObserver.UpdateData

    End Sub
End Class
