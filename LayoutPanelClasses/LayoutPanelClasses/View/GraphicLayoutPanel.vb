Imports System.IO
Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Runtime.Serialization.Formatters.Binary

Public Class GraphicLayoutPanel
    Implements IViewLayoutPanel


#Region "Class Variables - Private/Public"

    Private _ctrlr As LayoutPanelPresenter

    Private _Status As String
    Public Opt As String
    Private _redimStatus As String = ""
    Private _startX As Integer
    Private _startY As Integer
    Private _shape As Shapes

    Private _Zoom As Single = 1

    Private _dx As Integer = 0
    Private _dy As Integer = 0
    Private _startDX As Integer = 0
    Private _startDY As Integer = 0
    Private _truestartX As Integer = 0
    Private _truestartY As Integer = 0

    Private _offScreenBmp As Bitmap
    Private _offScreenBackBmp As Bitmap
    Private _srcBmp As Bitmap
    '// Grid   
    Private _gridSize As Integer = 0
    Private _fit2grid As Boolean = True

    '// Drawing Rect
    Private _mouseSx As Boolean
    Private _tempX As Integer
    Private _tempY As Integer

    Public CreationPenColor As Color
    Public CreationPenWidth As Single
    Public CreationFillColor As Color
    Public CreationFilled As Boolean

    '//EVENT
    Public Event optionChanged As OptionChanged
    Public Event objectSelected As ObjectSelected

#End Region

    Public Property BackgroundBitmap() As Bitmap
        Get
            If Me._srcBmp Is Nothing Then
                Return New Bitmap(Me.Canvas.Width, Me.Canvas.Height)
            Else
                Return Me._srcBmp
            End If
        End Get
        Set(ByVal value As Bitmap)
            Me._srcBmp = New Bitmap(value)
        End Set
    End Property

#Region "Constructor / Initialize"

    Public Sub New()

        ' me call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        myInit()
    End Sub

    Private Sub myInit()
        changeStatus(String.Empty)
        Opt = "select"
        _shape = New Shapes

        CreationPenColor = Color.Black
        CreationPenWidth = 1.0F
        CreationFillColor = Color.Black
        CreationFilled = False

        AddHandler Me.optionChanged, AddressOf FakeOptionChange
        AddHandler Me.objectSelected, AddressOf FakeObjectSelected

        'offScreenBackBmp = New Bitmap(Me.Canvas.Width, Me.Canvas.Height)
        _offScreenBackBmp = New Bitmap(Me.BackgroundBitmap)

        'offScreenBackBmp = offScreenBackBmp.GetThumbnailImage(Me.Canvas.Width, Me.Canvas.Height, Nothing, 0)
        'offScreenBmp = New Bitmap(Me.Canvas.Width, Me.Canvas.Height)
        _offScreenBmp = New Bitmap(Me.BackgroundBitmap)

    End Sub

#End Region

#Region "Class Properties - Get/Set"

    <CategoryAttribute(" "), DescriptionAttribute("Canvas")> _
    Public ReadOnly Property ObjectType() As String
        Get
            Return "Canvas"
        End Get
    End Property

    <CategoryAttribute(" "), DescriptionAttribute("Grid Size")> _
    Public Property gridSize() As Integer
        Get
            Return _gridSize
        End Get
        Set(ByVal value As Integer)
            If (value >= 0) Then
                _gridSize = value
            End If
            If (_gridSize > 0) Then
                Me.dx = CInt(_gridSize * (Me.dx / _gridSize))
                Me.dy = CInt(_gridSize * (Me.dy / _gridSize))
            End If

            Me.redraw(True)

        End Set
    End Property

    <CategoryAttribute(" "), DescriptionAttribute("Canvas Zoom")> _
    Public Property Zoom() As Single
        Get
            Return _Zoom
        End Get
        Set(ByVal value As Single)
            If (value >= 25) Then
                _Zoom = value / 100
                Me.redraw(True)
                Dim ev As New LayoutPanelEventArgs(CStr(EventName.evnmZoomChanged))
                ev.EvValue = Me
                'Me.Notify(ev)
            Else
                _Zoom = 1.0
                Me.redraw(True)
            End If

        End Set
    End Property

    <CategoryAttribute("  "), DescriptionAttribute("Canvas OriginX")> _
    Public Property dx() As Integer
        Get
            Return _dx
        End Get
        Set(ByVal value As Integer)
            _dx = value
        End Set
    End Property

    <CategoryAttribute("  "), DescriptionAttribute("Canvas OriginY")> _
    Public Property dy() As Integer
        Get
            Return _dy
        End Get
        Set(ByVal value As Integer)
            _dy = value
        End Set
    End Property

#End Region

    Public Sub AddRect(ByVal elName As String, ByVal value As System.Drawing.Rectangle)
        Me._shape.addRect(elName, value.X, value.Y, value.X + value.Width, value.Y + value.Height, Me.CreationPenColor, CreationFillColor, CreationPenWidth, CreationFilled)
    End Sub

#Region "Zoom Public Methods"

    Public Sub zoomIn(Optional ByVal delta As Integer = 1)
        Me.Zoom = Me.Zoom + delta
    End Sub

    Public Sub zoomOut(Optional ByVal delta As Integer = 1)
        Me.Zoom = CInt(Me.Zoom - delta)
    End Sub
    Public Sub zoomAll()
        For Each e As BaseElement In Me._shape.List
            e.Selected = True
        Next
        Me.groupSelected()
    End Sub

#End Region

#Region "Class Events"

    Private Sub changeOption(ByVal s As String)
        Me.Opt = s
        Dim e As OptionEventArgs = New OptionEventArgs(Me.Opt)
        RaiseEvent optionChanged(Me, e)
    End Sub

    Public Sub propertyChanged()
        Me._shape.Propertychanged()
    End Sub

    Private Sub FakeOptionChange(ByVal sender As Object, ByVal e As OptionEventArgs)

    End Sub

    Private Sub FakeObjectSelected(ByVal sender As Object, ByVal e As PropertyEventArgs)

    End Sub

    Private Sub changeStatus(ByVal s As String)
        Me._Status = s
    End Sub

#End Region

#Region "Redo / Undo Methods"

    Public Function UndoEnabled() As Boolean
        Return Me._shape.UndoEnabled()
    End Function

    Public Function RedoEnabled() As Boolean
        Return Me._shape.RedoEnabled()
    End Function

    Public Sub Undo()
        Me._shape.Undo()
        Me._shape.deSelect()
        Me.redraw(True)
    End Sub

    Public Sub Redo()
        Me._shape.Redo()
        Me._shape.deSelect()
        Me.redraw(True)
    End Sub

#End Region

#Region "SELECTED SHAPE COMMANDS"

    Public Sub setPenColor(ByVal c As Color)
        CreationPenColor = c
        If Not _shape.selEle Is Nothing Then
            Me._shape.selEle.penColor = c
        End If
    End Sub

    Public Sub setFillColor(ByVal c As Color)
        CreationFillColor = c
        If Not _shape.selEle Is Nothing Then
            Me._shape.selEle.fillColor = c
        End If
    End Sub

    Public Sub setFilled(ByVal f As Boolean)
        CreationFilled = f
        If Not _shape.selEle Is Nothing Then
            Me._shape.selEle.filled = f
        End If
    End Sub

    Public Sub setPenWidth(ByVal f As Single)
        CreationPenWidth = f
        If Not _shape.selEle Is Nothing Then
            Me._shape.selEle.penWidth = f
        End If
    End Sub

    Public Sub groupSelected()
        Me._shape.groupSelected()
        Dim e1 As PropertyEventArgs = New PropertyEventArgs(Me._shape.getSelectedArray(), Me._shape.RedoEnabled(), Me._shape.UndoEnabled())
        RaiseEvent objectSelected(Me, e1) '// raise event
        redraw(True)
    End Sub

    Public Sub deGroupSelected()
        Me._shape.deGroupSelected()
        '            // show properties
        Dim e1 As PropertyEventArgs = New PropertyEventArgs(Me._shape.getSelectedArray(), Me._shape.RedoEnabled(), Me._shape.UndoEnabled())
        RaiseEvent objectSelected(Me, e1) '// raise event
        redraw(True)
    End Sub

    Public Sub rmSelected()
        Me._shape.rmSelected()
        redraw(True)
    End Sub

    Public Sub cpSelected()
        Me._shape.CopyMultiSelected(25, 15)
        redraw(True)
    End Sub

    Public Sub Bring2Front()
        Me._shape.Bring2Front()
        redraw(True)
    End Sub

    Public Sub Send2Back()
        Me._shape.Send2Back()
        redraw(True)
    End Sub

#End Region

#Region "LOAD/SAVE"

    Public Function loader() As Boolean
        Try
            Dim strmRead As Stream
            Dim OpenFileDlg As OpenFileDialog = New OpenFileDialog
            OpenFileDlg.DefaultExt = "shape"
            OpenFileDlg.Title = "Load shape"
            OpenFileDlg.Filter = "frame files (*.shape)|*.shape|All files (*.*)|*.*"""
            If OpenFileDlg.ShowDialog = DialogResult.OK Then
                strmRead = OpenFileDlg.OpenFile
                If Not strmRead Is Nothing Then
                    Dim BinaryRead As BinaryFormatter = New BinaryFormatter
                    Me._shape = CType(BinaryRead.Deserialize(strmRead), Shapes)
                    strmRead.Close()

                    Me._shape.afterLoad()

                    Me.redraw(True)
                    Return True
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Exception:" + ex.ToString(), "Load error:")
        End Try
        Return False
    End Function

    Public Function Saver() As Boolean
        Try
            Dim StrmWrite As Stream
            Dim SaveDlg As SaveFileDialog = New SaveFileDialog
            SaveDlg.DefaultExt = "shape"
            SaveDlg.Title = "Save as shape"
            SaveDlg.Filter = "shape files (*.shape)|*.shape|All files (*.*)|*.*"
            If SaveDlg.ShowDialog = DialogResult.OK Then
                StrmWrite = SaveDlg.OpenFile
                If Not StrmWrite Is Nothing Then
                    Dim BinaryWrite As BinaryFormatter = New BinaryFormatter
                    BinaryWrite.Serialize(StrmWrite, Me._shape)
                    StrmWrite.Close()
                    Return True
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Exception:" + ex.ToString(), "Save error:")
        End Try
        Return False
    End Function

    Public Function SaveSelected() As Boolean
        Dim list As ArrayList = Me._shape.getSelectedList
        If Not list Is Nothing And list.Count > 0 Then
            Try
                Dim strmWrite As Stream
                Dim SaveFileDlg As SaveFileDialog = New SaveFileDialog
                SaveFileDlg.DefaultExt = "sobj"
                SaveFileDlg.Title = "Save as sobj"
                SaveFileDlg.Filter = "sobj files (*.sobj)|*.sobj|All files (*.*)|*.*"
                If SaveFileDlg.ShowDialog = DialogResult.OK Then
                    strmWrite = SaveFileDlg.OpenFile
                    If Not strmWrite Is Nothing Then
                        Dim binaryWrite As BinaryFormatter = New BinaryFormatter
                        binaryWrite.Serialize(strmWrite, list)
                        strmWrite.Close()
                        Return True
                    End If
                End If
                Return True
            Catch ex As Exception
                MessageBox.Show("Exception:" + ex.ToString(), "Save error:")
            End Try
        End If
        Return False
    End Function

    Public Function LoadObj() As Boolean
        Try
            Dim strmRead As Stream
            Dim OpenFileDlg As OpenFileDialog = New OpenFileDialog
            OpenFileDlg.DefaultExt = "sobj"
            OpenFileDlg.Title = "Load sobj"
            OpenFileDlg.Filter = "frame files (*.sobj)|*.sobj|All files (*.*)|*.*"""
            If OpenFileDlg.ShowDialog = DialogResult.OK Then
                strmRead = OpenFileDlg.OpenFile
                If Not strmRead Is Nothing Then
                    Dim BinaryRead As BinaryFormatter = New BinaryFormatter
                    Dim lst As ArrayList = CType(BinaryRead.Deserialize(strmRead), ArrayList)
                    Me._shape.setList(lst)
                    strmRead.Close()
                    Me._shape.afterLoad()
                    Me.redraw(True)
                    Return True
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Exception:" + ex.ToString(), "Load error:")
        End Try
        Return False
    End Function

#End Region

    Private Sub VectorShapes_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'srcBmp = New Bitmap([Image].FromHbitmap(My.Resources.Deposit_Slip.GetHbitmap))
        'offScreenBackBmp = New Bitmap(Me.Width, Me.Height)
        'offScreenBmp = New Bitmap(Me.Width, Me.Height)
        Dim destBmp As New Bitmap(Me.Width, Me.Height)

        Dim grph As Graphics = Graphics.FromImage(destBmp)
        grph.DrawImage(Me.BackgroundBitmap, 0, 0, destBmp.Width + 1, destBmp.Height + 1)
        _offScreenBackBmp = destBmp
        _offScreenBmp = destBmp
    End Sub

#Region "DRAWING"

    Public Sub redraw(ByVal All As Boolean)
        If _fit2grid And Me.gridSize > 0 Then
            Me._startX = Me.gridSize * CInt(_startX / Me.gridSize)
            Me._startY = Me.gridSize * CInt(_startY / Me.gridSize)
        End If

        Dim g As Graphics = Me.Canvas.CreateGraphics
        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias

        If All Then
            Dim backG As Graphics
            backG = Graphics.FromImage(_offScreenBackBmp)
            backG.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias
            backG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
            'backG.Clear(Me.BackColor)
            backG.DrawImage(Me.BackgroundBitmap, 0, 0, Me.Width + 1, Me.Height + 1)

            If Me.gridSize > 0 Then
                Dim myPen As System.Drawing.Pen = New System.Drawing.Pen(System.Drawing.Color.LightGray)
                Dim nX As Integer = CInt(Me.Width / Me.gridSize * Zoom)
                For i As Integer = 0 To nX
                    backG.DrawLine(myPen, i * Me.gridSize * Zoom, 0, i * Me.gridSize * Zoom, Me.Height)
                Next
                myPen.Dispose()
            End If
            _shape.DrawUnselected(backG, Me.dx, Me.dy, Me.Zoom)
            backG.Dispose()
        End If

        Dim offScreenDC As Graphics
        offScreenDC = Graphics.FromImage(_offScreenBmp)
        offScreenDC.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias
        offScreenDC.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
        'offScreenDC.Clear(Me.BackColor)
        offScreenDC.DrawImageUnscaled(Me._offScreenBackBmp, 0, 0)
        _shape.DrawSelected(offScreenDC, Me.dx, Me.dy, Me.Zoom)

        For Each e As BaseElement In _shape.List
            Dim pt As Point = PointCompare(e.TopLeft)
            If pt <> Nothing Then
                offScreenDC.DrawLine(New Pen(Color.Fuchsia, 4), pt, New Point(pt.X + 4, pt.Y + 4))
            End If
        Next
        If (Me._mouseSx And Me._Status = "drawrect") Then
            Dim myPen As System.Drawing.Pen = New System.Drawing.Pen(System.Drawing.Color.Red, 1.5F)
            myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot
            myPen.StartCap = System.Drawing.Drawing2D.LineCap.DiamondAnchor

            If Me.Opt = "LI" Then
                offScreenDC.DrawLine(myPen, (_startX + Me.dx) * Me.Zoom, (_startY + Me.dy) * Me.Zoom, (_tempX + Me.dx) * Me.Zoom, (_tempY + Me.dy) * Me.Zoom)
            Else
                offScreenDC.DrawRectangle(myPen, (Me._startX + Me.dx) * Me.Zoom, (Me._startY + Me.dy) * Me.Zoom, (_tempX - Me._startX) * Me.Zoom, (_tempY - Me._startY) * Me.Zoom)
            End If
            myPen.Dispose()
        End If

        If (Me._mouseSx And Me._Status = "selrect") Then
            Dim myPen As System.Drawing.Pen = New System.Drawing.Pen(System.Drawing.Color.Green, 1.5F)
            myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
            offScreenDC.DrawRectangle(myPen, (Me._startX + Me.dx) * Me.Zoom, (Me._startY + Me.dy) * Me.Zoom, (_tempX - Me._startX) * Me.Zoom, (_tempY - Me._startY) * Me.Zoom)
            myPen.Dispose()
        End If

        g.DrawImageUnscaled(_offScreenBmp, 0, 0)
        offScreenDC.Dispose()
        g.Dispose()
    End Sub

#End Region

#Region "MOUSE EVENT MANAGMENT"

    Private Sub Canvas_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Canvas.MouseDown
        'Private Sub VectorShapes_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        Me._startX = CInt((e.X / Zoom) - Me.dx)
        Me._startY = CInt((e.Y / Zoom) - Me.dy)

        Me._truestartX = CInt(e.X)
        Me._truestartY = CInt(e.Y)

        If e.Button = MouseButtons.Left Then
            Me._mouseSx = True
            Select Case Me.Opt
                Case "select"
                    If Me._redimStatus <> "" Then
                        changeStatus("redim")
                    Else
                        changeStatus("selrect")
                    End If
                Case Else
                    changeStatus("drawrect")
            End Select
        Else
            Me._startDX = Me.dx
            Me._startDY = Me.dy
            Me.Cursor = Cursors.Cross
        End If

    End Sub

    Private Sub Canvas_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Canvas.MouseMove
        'Private Sub VectorShapes_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        Dim pnt As Point = CType(New Size(Me.Canvas.PointToClient(New Point(e.X, e.Y))), Point)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If Me._mouseSx Then
                _tempX = CInt(e.X / Zoom)
                _tempY = CInt(e.Y / Zoom)
                If (_fit2grid And Me.gridSize > 0) Then
                    _tempX = Me.gridSize * CInt((e.X / Zoom) / Me.gridSize)
                    _tempY = Me.gridSize * CInt((e.Y / Zoom) / Me.gridSize)
                End If

                _tempX = _tempX - Me.dx
                _tempY = _tempY - Me.dy
            End If
            If Me._Status = "redim" Then
                Dim tmpX As Integer = CInt(e.X / Zoom - Me.dx)
                Dim tmpY As Integer = CInt(e.Y / Zoom - Me.dy)
                Dim tmpstartX As Integer = _startX
                Dim tmpstartY As Integer = _startY
                If _fit2grid And Me.gridSize > 0 Then
                    tmpX = Me.gridSize * CInt((e.X / Zoom - Me.dx) / Me.gridSize)
                    tmpY = Me.gridSize * CInt((e.Y / Zoom - Me.dy) / Me.gridSize)
                    tmpstartX = Me.gridSize * CInt(_startX / Me.gridSize)
                    tmpstartY = Me.gridSize * CInt(_startY / Me.gridSize)
                    _shape.Fit2grid(Me.gridSize)
                    _shape.selectRect.Fit2Grid(Me.gridSize)
                End If
                Select Case Me._redimStatus
                    Case "C"
                        If Not _shape.selEle Is Nothing And Not _shape.selectRect Is Nothing Then
                            _shape.move(tmpstartX - tmpX, tmpstartY - tmpY)
                            _shape.selectRect.move(tmpstartX - tmpX, tmpstartY - tmpY)
                        End If
                    Case "ROT"
                        If Not _shape.selEle Is Nothing And Not _shape.selectRect Is Nothing Then
                            _shape.selEle.Rotate(tmpX, tmpY)
                            _shape.selectRect.Rotate(tmpX, tmpY)
                        End If
                    Case "ZOOM"
                        If Not _shape.selEle Is Nothing And Not _shape.selectRect Is Nothing Then
                            If TypeOf (_shape.selEle) Is Group Then
                                CType(_shape.selEle, Group).setZoom(tmpX, tmpY)
                                _shape.selectRect.setZoom(CType(_shape.selEle, Group).GrpZoomX, CType(_shape.selEle, Group).GrpZoomY)
                            End If
                        End If
                    Case Else
                        If Not _shape.selEle Is Nothing And Not _shape.selectRect Is Nothing Then
                            _shape.selEle.redimension(tmpX - tmpstartX, tmpY - tmpstartY, Me._redimStatus)
                            _shape.selectRect.redimension(tmpX - tmpstartX, tmpY - tmpstartY, Me._redimStatus)
                        End If
                End Select
            End If
            redraw(False)
        Else
            If e.Button = MouseButtons.Right Then
                Me.dx = (Me._startDX + Me._truestartX - e.X)
                Me.dy = (Me._startDY + Me._truestartY - e.Y)
                If (_fit2grid And Me.gridSize > 0) Then
                    Me.dx = Me.gridSize * CInt(Me.dx / Me.gridSize)
                    Me.dy = Me.gridSize * CInt(Me.dy / Me.gridSize)
                End If
                Me.redraw(True)
            Else
                If Me.Opt = "select" Then
                    If Not Me._shape.selectRect Is Nothing Then
                        Dim st As String = Me._shape.selectRect.isOver(CInt(e.X / Zoom) - Me.dx, CInt(e.Y / Zoom - Me.dy))
                        Me._redimStatus = st
                        Select Case st
                            Case "ROT"
                                Me.Cursor = Cursors.SizeAll
                            Case "C"
                                Me.Cursor = Cursors.Hand
                            Case "NW"
                                Me.Cursor = Cursors.SizeNWSE
                            Case "N"
                                Me.Cursor = Cursors.SizeNS
                            Case "NE"
                                Me.Cursor = Cursors.SizeNESW
                            Case "E"
                                Me.Cursor = Cursors.SizeWE
                            Case "SE"
                                Me.Cursor = Cursors.SizeNWSE
                            Case "S"
                                Me.Cursor = Cursors.SizeNS
                            Case "SW"
                                Me.Cursor = Cursors.SizeNESW
                            Case "W"
                                Me.Cursor = Cursors.SizeWE
                            Case "ZOOM"
                                Me.Cursor = Cursors.SizeNWSE

                            Case Else
                                Me.Cursor = Cursors.Default
                                _redimStatus = ""
                        End Select
                    Else
                        Me.Cursor = Cursors.Default
                        _redimStatus = ""
                    End If
                Else
                    Me.Cursor = Cursors.Default
                    _redimStatus = ""
                End If
            End If
        End If
    End Sub

    Private Sub Canvas_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Canvas.MouseUp
        'Private Sub VectorShapes_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim tmpX As Integer = CInt(e.X / Zoom - Me.dx)
            Dim tmpY As Integer = CInt(e.Y / Zoom - Me.dy)
            If _fit2grid And Me.gridSize > 0 Then
                tmpX = Me.gridSize * CInt((e.X / Zoom - Me.dx) / Me.gridSize)
                tmpY = Me.gridSize * CInt((e.Y / Zoom - Me.dy) / Me.gridSize)
            End If
            Select Case Me.Opt
                Case "select"
                    If Me._Status <> "redim" Then
                        Me._shape.click(CInt((e.X) / Zoom - Me.dx), CInt((e.Y) / Zoom - Me.dy)) ', Me.r)
                    End If
                    If Me._Status = "selrect" Then
                        If (((e.X) / Zoom - Me.dx - Me._startX) + ((e.Y) / Zoom - Me.dy - Me._startY)) > 12 Then
                            Me._shape.multiSelect(Me._startX, Me._startY, CInt((e.X) / Zoom - Me.dx), CInt((e.Y) / Zoom - Me.dy))  ', Me.r)
                        End If
                    End If
                    changeStatus("")
                    'Case "DR"
                    '    If Me.Status = "drawrect" Then
                    '        Me.shape.addRect(startX, startY, tmpX, tmpY, Me.CreationPenColor, CreationFillColor, CreationPenWidth, CreationFilled)
                    '        changeOption("select")
                    '    End If
                Case Else
                    changeStatus("")
            End Select
            If Not Me._shape.selEle Is Nothing Then
                If Me._redimStatus <> "" Then
                    Me._shape.endMove()
                End If
                If Not Me._shape.selectRect Is Nothing Then
                    Me._shape.selectRect.endMoveRedim()
                End If
            End If
            Dim e1 As PropertyEventArgs = New PropertyEventArgs(Me._shape.getSelectedArray, Me._shape.RedoEnabled, Me._shape.UndoEnabled)
            RaiseEvent objectSelected(Me, e1)

            redraw(True)
            Me._mouseSx = False
        Else
            Dim e1 As PropertyEventArgs = New PropertyEventArgs(Me._shape.getSelectedArray, Me._shape.RedoEnabled, Me._shape.UndoEnabled)
            RaiseEvent objectSelected(Me, e1)
        End If
    End Sub

#End Region

#Region "Drag-Drop Events"

    Private Function PointCompare(ByVal pt As Point) As Point
        Dim retval As Point
        For Each e As BaseElement In Me._shape.List
            If e.getX < pt.X And e.getY < pt.Y Then
                retval = New Point(pt.X, pt.Y)
            End If
        Next
        Return retval
    End Function

    Private Sub Canvas_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Canvas.DragEnter
        Dim fmts() As String = e.Data.GetFormats(True)
        If e.Data.GetDataPresent(fmts(0)) Then
            Me._mouseSx = True
            e.Effect = DragDropEffects.Copy Or DragDropEffects.Move
        End If

    End Sub

    Private Sub Canvas_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Canvas.DragDrop
        Dim fmt() As String = e.Data.GetFormats(True)
        If e.Data.GetDataPresent(fmt(0)) Then
            Dim item As LayoutPanelClasses.Rect = CType(CType(e.Data.GetData(fmt(0)), Rect).Copy, Rect)
            Me.Opt = "DR"
            Dim pnt As New Point(CType(Me.Canvas.PointToClient(New Point(e.X, e.Y)), Size))
            Me._startX = CInt((pnt.X / Zoom) - Me.dx)
            Me._startY = CInt((pnt.Y / Zoom) - Me.dy)

            Me._truestartX = CInt(pnt.X)
            Me._truestartY = CInt(pnt.Y)

            'Me.shape.addRect(Me.startX, Me.startY, Me.startX + CType(item, LayoutPanelClasses.Rect).Width, Me.startY + CType(item, LayoutPanelClasses.Rect).Height, Me.CreationPenColor, CreationFillColor, CreationPenWidth, CreationFilled)
            changeOption("select")
            Dim e1 As PropertyEventArgs = New PropertyEventArgs(Me._shape.getSelectedArray, Me._shape.RedoEnabled, Me._shape.UndoEnabled)
            RaiseEvent objectSelected(Me, e1)

            redraw(True)
            Me._mouseSx = False

        End If
    End Sub

#End Region


    Private Sub Canvas_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Canvas.Paint
        Me.redraw(False)

    End Sub
End Class
