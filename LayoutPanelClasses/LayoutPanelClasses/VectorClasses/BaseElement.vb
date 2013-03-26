Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.Windows.Forms
<Serializable()> _
Public MustInherit Class BaseElement
    Inherits Object

    Protected Name As String
    Protected IsGrouped As Boolean = False
    Protected rotates As Boolean
    '        //Start point
    Protected X As Integer
    Protected Y As Integer
    '        //End point
    Protected X1 As Integer
    Protected Y1 As Integer
    '        //Grouped objs properties. When you decide to create a group with the
    '        // selected objs, U can preset these pprops in the objs: Move,Resize,Nothing
    '        // Move: On the resize of the group the grouped obj moves
    '        // Resize: On the resize of the group the grouped obj resizes
    '        // Nothing: On the resize of the group the grouped obj mantains its position and dimension.
    '        // When you resize the group using the X handle (West):
    Protected _onGroupXRes As OnGroupResize = OnGroupResize.Resize
    '        // When you resize the group using the X1 handle (East):
    Protected _onGroupX1Res As OnGroupResize = OnGroupResize.Resize
    '        // When you resize the group using the Y handle (North):
    Protected _onGroupYRes As OnGroupResize = OnGroupResize.Resize
    '        // When you resize the group using the Y handle (South):
    Protected _onGroupY1Res As OnGroupResize = OnGroupResize.Resize

    '        // When double click on Group obj, forward it to sub-obj
    Protected _onGroupDoubleClick As Boolean = True

    '        // Store start position during moving/resizing
    Protected startX As Integer
    Protected startY As Integer
    Protected startX1 As Integer
    Protected startY1 As Integer
    '        // some pen properties
    Protected startCap As LineCap
    Protected endCap As LineCap
    Protected dashstyle As System.Drawing.Drawing2D.DashStyle

    Protected _rotation As Integer

    Private _penColor As Color
    Private _penWidth As Single
    Private _fillColor As Color
    Private _filled As Boolean
    Private _showBorder As Boolean
    Private _dashStyle As System.Drawing.Drawing2D.DashStyle
    Private _alpha As Integer

    '        //LINEAR GRADIENT
    Private _useGradientLine As Boolean = False
    Private _endColor As Color = Color.White
    Private _endalpha As Integer = 255
    Private _gradientLen As Integer = 0
    Private _gradientAngle As Integer = 0
    Private _endColorPos As Single = 1.0F

    '        //Group obj zoom 
    Protected gprZoomX As Single = 1.0F
    Protected gprZoomY As Single = 1.0F

    Public IsALine As Boolean

    Public Selected As Boolean
    Public Deleted As Boolean
    Public undoEle As BaseElement

    Public Sub New()
        Me.penColor = Color.Black
        Me.penWidth = 1.0F
        Me.fillColor = Color.Black
        Me.filled = False
        Me.showBorder = True
        Me.dashstyle = dashstyle.Solid
        Me.alpha = 255

    End Sub

#Region "Properties - Get / Set"

    Public ReadOnly Property canRotate() As Boolean
        Get
            Return rotates
        End Get
    End Property

    Public ReadOnly Property getRotation() As Integer
        Get
            If canRotate Then
                Return _rotation
            Else
                Return 0
            End If
        End Get
    End Property

    Public WriteOnly Property addRotation(ByVal a As Integer) As Integer
        Set(ByVal value As Integer)
            Me._rotation += a
        End Set
    End Property

    Public ReadOnly Property AmIaGroup() As Boolean
        Get
            Return Me.IsGrouped
        End Get
    End Property

    <CategoryAttribute("Position"), DescriptionAttribute("X ")> _
    Public ReadOnly Property PosX() As Integer
        Get
            Return Me.X
        End Get
    End Property

    <CategoryAttribute("Position"), DescriptionAttribute("Y ")> _
      Public ReadOnly Property PosY() As Integer
        Get
            Return Me.Y
        End Get
    End Property

    Public Overridable ReadOnly Property TopLeft() As Point
        Get
            Return New Point(Me.X, Me.Y)
        End Get
    End Property

    Public Overridable ReadOnly Property TopRight() As Point
        Get
            Return New Point(Me.X1, Me.Y)
        End Get
    End Property

    Public Overridable ReadOnly Property BottomLeft() As Point
        Get
            Return New Point(Me.X, Me.Y1)
        End Get
    End Property

    Public Overridable ReadOnly Property BottomRight() As Point
        Get
            Return New Point(Me.X1, Me.Y1)
        End Get
    End Property

    <CategoryAttribute("Dimention"), DescriptionAttribute("Width ")> _
    Public ReadOnly Property Width() As Integer
        Get
            Return System.Math.Abs(Me.X1 - Me.X)
        End Get
    End Property

    <CategoryAttribute("Dimention"), DescriptionAttribute("Height ")> _
    Public ReadOnly Property Height() As Integer
        Get
            Return System.Math.Abs(Me.Y1 - Me.Y)
        End Get
    End Property

    <CategoryAttribute("Dimention"), DescriptionAttribute("Size ")> _
     Public ReadOnly Property Size() As System.Drawing.Size
        Get
            Return New System.Drawing.Size(System.Math.Abs(Me.X1 - Me.X), System.Math.Abs(Me.Y1 - Me.Y))
        End Get
    End Property

    <CategoryAttribute("Group Behav"), DescriptionAttribute("On Group Resize X")> _
    Public Property OnGrpXRes() As OnGroupResize
        Get
            Return _onGroupXRes
        End Get
        Set(ByVal value As OnGroupResize)
            _onGroupXRes = value
        End Set
    End Property

    <CategoryAttribute("Group Behav"), DescriptionAttribute("On Group Resize X1")> _
    Public Property OnGrpX1Res() As OnGroupResize
        Get
            Return _onGroupX1Res
        End Get
        Set(ByVal value As OnGroupResize)
            _onGroupX1Res = value
        End Set
    End Property

    <CategoryAttribute("Group Behav"), DescriptionAttribute("On Group Resize Y")> _
    Public Property OnGrpYRes() As OnGroupResize
        Get
            Return _onGroupYRes
        End Get
        Set(ByVal value As OnGroupResize)
            _onGroupYRes = value
        End Set
    End Property

    <CategoryAttribute("Group Behav"), DescriptionAttribute("On Group Resize Y1")> _
    Public Property OnGrpY1Res() As OnGroupResize
        Get
            Return _onGroupY1Res
        End Get
        Set(ByVal value As OnGroupResize)
            _onGroupY1Res = value
        End Set
    End Property
    <CategoryAttribute("Group Behav"), DescriptionAttribute("Manage On Group Double Click")> _
    Public Property OnGrpClick() As Boolean
        Get
            Return _onGroupDoubleClick
        End Get
        Set(ByVal value As Boolean)
            _onGroupDoubleClick = value
        End Set
    End Property

    <CategoryAttribute("Appearance"), DescriptionAttribute("Set Border Dash Style ")> _
    Public Overridable Property dashLineStyle() As System.Drawing.Drawing2D.DashStyle
        Get
            Return Me._dashStyle
        End Get
        Set(ByVal value As DashStyle)
            Me._dashStyle = value
        End Set
    End Property

    <CategoryAttribute("Appearance"), DescriptionAttribute("Show border when filled or contains Text")> _
    Public Overridable Property showBorder() As Boolean
        Get
            Return _showBorder
        End Get
        Set(ByVal value As Boolean)
            _showBorder = value
        End Set
    End Property

    <CategoryAttribute("Appearance"), DescriptionAttribute("Pen Color")> _
    Public Overridable Property penColor() As Color
        Get
            Return _penColor
        End Get
        Set(ByVal value As Color)
            _penColor = value
        End Set
    End Property

    <CategoryAttribute("Appearance"), DescriptionAttribute("Fill Color")> _
    Public Overridable Property fillColor() As Color
        Get
            Return _fillColor
        End Get
        Set(ByVal value As Color)
            _fillColor = value
        End Set
    End Property

    <CategoryAttribute("Appearance"), DescriptionAttribute("Pen Width")> _
    Public Overridable Property penWidth() As Single
        Get
            Return _penWidth
        End Get
        Set(ByVal value As Single)
            _penWidth = value
        End Set
    End Property

    <CategoryAttribute("Appearance"), DescriptionAttribute("Filled/Unfilled")> _
    Public Overridable Property filled() As Boolean
        Get
            Return _filled
        End Get
        Set(ByVal value As Boolean)
            _filled = value
        End Set
    End Property

    <CategoryAttribute("Appearance"), DescriptionAttribute("Trasparency")> _
    Public Overridable Property alpha() As Integer
        Get
            Return _alpha
        End Get
        Set(ByVal value As Integer)
            If (value < 0) Then
                _alpha = 0
            ElseIf (value > 255) Then
                _alpha = 255
            Else
                _alpha = value
            End If
        End Set
    End Property

    <CategoryAttribute("GradientBrush"), DescriptionAttribute("True: use gradient fill color")> _
    Public Overridable Property UseGradientLineColor() As Boolean
        Get
            Return _useGradientLine
        End Get
        Set(ByVal value As Boolean)
            _useGradientLine = value
        End Set
    End Property

    <CategoryAttribute("GradientBrush"), DescriptionAttribute("End Color Position [0..1])")> _
    Public Overridable Property EndColorPosition() As Single
        Get
            Return _endColorPos
        End Get
        Set(ByVal value As Single)
            If value > 1 Then
                value = 1
            End If
            If value < 0 Then
                value = 0
            End If
            _endColorPos = value
        End Set
    End Property

    <CategoryAttribute("GradientBrush"), DescriptionAttribute("Gradient End Color")> _
    Public Overridable Property EndColor() As Color
        Get
            Return _endColor
        End Get
        Set(ByVal value As Color)
            _endColor = value
        End Set
    End Property

    <CategoryAttribute("GradientBrush"), DescriptionAttribute("End Color Trasparency")> _
    Public Overridable Property EndAlpha() As Integer
        Get
            Return _endalpha
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                _endalpha = 0
            ElseIf value > 255 Then
                _endalpha = 255
            Else
                _endalpha = value
            End If
        End Set
    End Property

    <CategoryAttribute("GradientBrush"), DescriptionAttribute("Gradient Dimension")> _
    Public Overridable Property GradientLen() As Integer
        Get
            Return _gradientLen
        End Get
        Set(ByVal value As Integer)
            If value >= 0 Then
                _gradientLen = value
            Else
                _gradientLen = 0
            End If
        End Set
    End Property

    <CategoryAttribute("GradientBrush"), DescriptionAttribute("Gradient Angle")> _
    Public Overridable Property GradientAngle() As Integer
        Get
            Return _gradientAngle
        End Get
        Set(ByVal value As Integer)
            _gradientAngle = value
        End Set
    End Property

    Public ReadOnly Property getX() As Integer
        Get
            Return X
        End Get
    End Property
    Public ReadOnly Property getY() As Integer
        Get
            Return Y
        End Get
    End Property
    Public ReadOnly Property getX1() As Integer
        Get
            Return X1
        End Get
    End Property
    Public ReadOnly Property getY1() As Integer
        Get
            Return Y1
        End Get
    End Property
    Public ReadOnly Property getGprZoomX() As Single
        Get
            Return gprZoomX
        End Get
    End Property
    Public ReadOnly Property getGprZoomY() As Single
        Get
            Return gprZoomY
        End Get
    End Property

#End Region


#Region "Overridable Methods"

    Public Overridable Sub Draw(ByVal g As Graphics, ByVal dx As Integer, ByVal dy As Integer, ByVal zoom As Single)

    End Sub

    Public Overridable Sub AddGp(ByVal Gp As GraphicsPath, ByVal dx As Integer, ByVal dy As Integer, ByVal zoom As Single)

    End Sub

    Public Overridable Function deGroup() As ArrayList
        Return Nothing
    End Function

    Public Overridable Sub SelectObj()

    End Sub

    Public Overridable Sub AfterLoad()

    End Sub

    Public Overridable Sub CopyFrom(ByVal ele As BaseElement)

    End Sub

    Public Overridable Function Copy() As BaseElement
        Return Nothing
    End Function

    Protected Sub copyGradprop(ByVal ele As BaseElement)
        _useGradientLine = ele._useGradientLine
        _endColor = ele._endColor
        _endalpha = ele._endalpha
        _gradientLen = ele._gradientLen
        _gradientAngle = ele._gradientAngle
        _endColorPos = ele._endColorPos

    End Sub


#End Region

    Protected Function scaledPenWidth(ByVal zoom As Single) As Single
        If zoom < 0.1F Then
            zoom = 0.1F
        End If
        Return Me.penWidth * zoom
    End Function

    Public Sub Fit2Grid(ByVal gridsize As Integer)
        Me.startX = CInt(gridsize * (Me.startX / gridsize))
        Me.startY = CInt(gridsize * (Me.startY / gridsize))
        Me.startX1 = CInt(gridsize * (Me.startX1 / gridsize))
        Me.startY1 = CInt(gridsize * (Me.startY1 / gridsize))
    End Sub

    Public Overridable Sub Rotate(ByVal xPos As Single, ByVal yPos As Single)
        Dim tmp As Single = _rotate(xPos, yPos)
        Me._rotation = CInt(tmp)
    End Sub

    Protected Function rotatePoint(ByVal p As PointF, ByVal RotAng As Integer) As PointF
        Dim RotAngF As Double = RotAng * Math.PI / 180
        Dim SinVal As Double = Math.Sin(RotAngF)
        Dim CosVal As Double = Math.Cos(RotAngF)
        Dim Nx As Single = CSng(p.X * CosVal - p.Y * SinVal)
        Dim Ny As Single = CSng(p.Y * CosVal + p.X * SinVal)
        Return New PointF(Nx, Ny)
    End Function

    Protected Function _rotate(ByVal xPos As Single, ByVal yPos As Single) As Single
        Dim c As Point = New Point(CInt(Me.X + (Me.X1 - Me.X) / 2), CInt(Me.Y + (Me.Y1 - Me.Y) / 2))
        Dim dx As Single = xPos - c.X
        Dim dy As Single = yPos - c.Y
        Dim b As Single = 0.0F
        Dim alpha As Single = 0.0F
        Dim f As Single = 0.0F
        If dx > 0 And dy > 0 Then
            b = 90
            alpha = CSng(Math.Abs(Math.Atan(dy / dx) * (180 / Math.PI)))
        Else
            If dx <= 0 And dy >= 0 Then
                b = 180
                If dy > 0 Then
                    alpha = CSng(Math.Abs(Math.Atan(dx / dy) * (180 / Math.PI)))
                End If
            Else
                If dx < 0 And dy < 0 Then
                    b = 270
                    alpha = CSng(Math.Abs(Math.Atan(dy / dx) * (180 / Math.PI)))
                Else
                    b = 0
                    alpha = CSng(Math.Abs(Math.Atan(dx / dy) * (180 / Math.PI)))
                End If
            End If
        End If
        f = (b + alpha)
        Return f
    End Function

    Private Function getDimX() As Single
        Return CSng((Math.Sqrt(Math.Pow(Me.Width, 2) + System.Math.Pow(Me.Height, 2)) - Me.Width) / 2)
    End Function

    Private Function getDimY() As Single
        Return CSng((System.Math.Sqrt(System.Math.Pow(Me.Width, 2) + System.Math.Pow(Me.Height, 2)) - Me.Height) / 2)
    End Function

    Protected Function getBrush(ByVal dxPos As Integer, ByVal dyPos As Integer, ByVal zoom As Single) As Brush
        If Me.filled Then
            If Me.UseGradientLineColor Then
                Dim wid As Single
                Dim hei As Single
                If Me.GradientLen > 0 Then
                    wid = Me.GradientLen
                    hei = Me.GradientLen
                Else
                    wid = (Me.X1 - Me.X) + 2 * getDimX() * zoom
                    hei = (Me.Y1 - Me.Y) + 2 * getDimY() * zoom
                End If
                Dim br As LinearGradientBrush = New LinearGradientBrush( _
                New RectangleF((Me.X - getDimX() + dxPos) * zoom, (Me.Y - getDimY() + dyPos) * zoom, wid, hei), _
                Me.Transparency(Me.fillColor, Me.alpha), _
                Me.Transparency(Me.EndColor, Me.EndAlpha), _
                Me.GradientAngle, True)
                br.SetBlendTriangularShape(Me.EndColorPosition, 0.95F)
                br.WrapMode = WrapMode.TileFlipXY
                Return br
            Else
                Return New SolidBrush(Me.Transparency(Me.fillColor, Me.alpha))
            End If
        Else
            Return Nothing
        End If

    End Function

    Protected Sub copyStdProp(ByVal fromEle As BaseElement, ByVal toEle As BaseElement)
        toEle.X = fromEle.X
        toEle.X1 = fromEle.X1
        toEle.Y = fromEle.Y
        toEle.Y1 = fromEle.Y1
        toEle.startCap = fromEle.startCap
        toEle.startX = fromEle.startX
        toEle.startX1 = fromEle.startX1
        toEle.startY = fromEle.startY
        toEle.startY1 = fromEle.startY1
        toEle.IsALine = fromEle.IsALine
        toEle.alpha = fromEle.alpha
        toEle.dashstyle = fromEle.dashstyle
        toEle.fillColor = fromEle.fillColor
        toEle.filled = fromEle.filled
        toEle.penColor = fromEle.penColor
        toEle._penWidth = fromEle.penWidth
        toEle.showBorder = fromEle.showBorder
        toEle._onGroupX1Res = fromEle._onGroupX1Res
        toEle._onGroupXRes = fromEle._onGroupXRes
        toEle._onGroupY1Res = fromEle._onGroupY1Res
        toEle._onGroupYRes = fromEle._onGroupYRes

        toEle._useGradientLine = fromEle._useGradientLine
        toEle._endColor = fromEle._endColor
        toEle._endalpha = fromEle._endalpha
        toEle._gradientLen = fromEle._gradientLen
        toEle._gradientAngle = fromEle._gradientAngle
        toEle._endColorPos = fromEle._endColorPos

    End Sub

    Protected Function Transparency(ByVal c As Color, ByVal v As Integer) As Color
        If v < 0 Then
            v = 0
        End If
        If v > 255 Then
            v = 255
        End If
        Return Color.FromArgb(v, c)

    End Function

    Protected Function Dist(ByVal xPos As Integer, ByVal yPos As Integer, ByVal x1Pos As Integer, ByVal y1Pos As Integer) As Integer
        Return CInt(System.Math.Sqrt(System.Math.Pow((xPos - x1Pos), 2) + System.Math.Pow((yPos - y1Pos), 2)))
    End Function

    Protected Function dark(ByVal c As Color, ByVal v As Integer, ByVal a As Integer) As Color
        Dim r As Integer = c.R
        r = r - v
        If (r < 0) Then
            r = 0
        End If
        If (r > 255) Then
            r = 255
        End If
        Dim green As Integer = c.G
        green = green - v

        If (green < 0) Then
            green = 0
        End If
        If (green > 255) Then
            green = 255
        End If
        Dim b As Integer = c.B
        b = b - v
        If (b < 0) Then
            b = 0
        End If
        If (b > 255) Then
            b = 255
        End If
        If (a > 255) Then
            a = 255
        End If
        If (a < 0) Then
            a = 0
        End If
        Return Color.FromArgb(a, r, green, b)
    End Function

    Public Function contains(ByVal xPos As Integer, ByVal yPos As Integer) As Boolean
        If IsALine Then
            Dim appo As Integer = Dist(xPos, yPos, Me.X, Me.Y) + Dist(xPos, yPos, Me.X1, Me.Y1)
            Dim appo1 = Dist(Me.X1, Me.Y1, Me.X, Me.Y) + 7
            Return appo < appo1
        Else
            Return New Rectangle(Me.X, Me.Y, Me.X1 - Me.X, Me.Y1 - Me.Y).Contains(xPos, yPos)
        End If

    End Function

    Public Overridable Sub move(ByVal xPos As Integer, ByVal yPos As Integer)
        Me.X = Me.startX - xPos
        Me.Y = Me.startY - yPos
        Me.X1 = Me.startX1 - xPos
        Me.Y1 = Me.startY1 - yPos

    End Sub

    Public Overridable Sub move(ByVal xPos As Integer, ByVal startXPos As Integer, ByVal yPos As Integer, ByVal startYPos As Integer)
        Dim dx As Integer = startXPos - xPos
        Dim dy As Integer = startYPos - yPos
        Me.X = Me.X - dx
        Me.Y = Me.Y - dy
        Me.X1 = Me.X1 - dx
        Me.Y1 = Me.Y1 - dy
    End Sub

    Public Overridable Sub redimension(ByVal xPos As Integer, ByVal yPos As Integer, ByVal redimSt As String)
        Select Case redimSt
            Case "NW"
                Me.X = Me.startX + xPos
                Me.Y = Me.startY + yPos
            Case "N"
                Me.Y = Me.startY + yPos
            Case "NE"
                Me.X1 = Me.startX1 + xPos
                Me.Y = Me.startY + yPos
            Case "E"
                Me.X1 = Me.startX1 + xPos
            Case "SE"
                Me.X1 = Me.startX1 + xPos
                Me.Y1 = Me.startY1 + yPos
            Case "S"
                Me.Y1 = Me.startY1 + yPos
            Case "SW"
                Me.X = Me.startX + xPos
                Me.Y1 = Me.startY1 + yPos
            Case "W"
                Me.X = Me.startX + xPos
        End Select
        If Not Me.IsALine Then
            If Me.X1 <= Me.X Then
                Me.X1 = Me.X + 10
            End If
        End If
        If Me.Y1 <= Me.Y Then
            Me.Y1 = Me.Y + 10
        End If
    End Sub

    Public Overridable Sub endMoveRedim()
        Me.startX = Me.X
        Me.startY = Me.Y
        Me.startX1 = Me.X1
        Me.startY1 = Me.Y1
    End Sub

End Class


