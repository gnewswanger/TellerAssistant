Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System.Collections

Public Enum OnGroupResize
    Move
    Resize
    DoNothing
End Enum

<Serializable()> _
Public Class Shapes
    Implements mvcLibrary.IObserver

    Public List As ArrayList
    Public selectRect As SelRectHandle
    Public selEle As BaseElement
    Public minDim As Integer = 10
    Private _snap2Pointlist As List(Of Point)

    <NonSerialized()> Private undoB As UndoBuffer

    Public ReadOnly Property SnapPoints() As List(Of Point)
        Get
            Return _snap2Pointlist
        End Get
    End Property

    Public Sub New()
        List = New ArrayList
        initUndoBuff()
        _snap2Pointlist = New List(Of Point)
    End Sub

    Public Sub SetSnapPoint(ByVal r As Rect)
        _snap2Pointlist.Add(New Point(r.getX, r.getY))
        _snap2Pointlist.Add(New Point(r.getX1, r.getY1))
        _snap2Pointlist.Add(New Point(r.getX + r.Width, r.getY))
        _snap2Pointlist.Add(New Point(r.getX1 - r.Width, r.getY1))
    End Sub

    Private Sub initUndoBuff()
        '// set dim of undo buffer
        undoB = New UndoBuffer(20)
    End Sub


    Public Function IsEmpty() As Boolean
        Return (Me.List.Count <= 0)
    End Function

    Public Sub afterLoad()
        '   // UndoBuff is not serialized, I must reinit it after LOAD from file
        initUndoBuff()
        For Each e As BaseElement In Me.List
            e.AfterLoad()
        Next
    End Sub

    Public Sub CopyMultiSelected(ByVal dx As Integer, ByVal dy As Integer)
        Dim tmpList As ArrayList = New ArrayList
        For Each elem As BaseElement In Me.List
            If elem.Selected Then
                Dim el As BaseElement = elem.Copy
                elem.Selected = False
                el.move(dx, dy)
                tmpList.Add(el)
                selectRect = New SelRectHandle(el)
                selEle = el
                selEle.endMoveRedim()
            End If
        Next
        For Each tmpElem As BaseElement In tmpList
            Me.List.Add(tmpElem)
            '// store the operation in undo/redo buffer
            storeDo("I", tmpElem)
        Next
    End Sub

    Public Function CpSelected() As BaseElement
        If Not Me.selEle Is Nothing Then
            Dim l As BaseElement = selEle.Copy
            Return l
        End If
        Return Nothing
    End Function

    Public Sub CopySelected(ByVal dx As Integer, ByVal dy As Integer)
        If Not Me.selEle Is Nothing Then
            Dim l As BaseElement = Me.CpSelected
            l.move(dx, dy)
            Me.deSelect()
            Me.List.Add(l)
            '// store the operation in undo/redo buffer
            storeDo("I", l)

            selectRect = New SelRectHandle(l)
            selEle = l
            selEle.endMoveRedim()

        End If
    End Sub

    Public Sub rmSelected()
        Dim tmpList As ArrayList = New ArrayList
        For Each elem As BaseElement In Me.List
            If elem.Selected Then
                tmpList.Add(elem)
            End If
        Next
        If Not Me.selEle Is Nothing Then
            selEle = Nothing
            Me.selectRect = Nothing
        End If
        For Each tmpElem As BaseElement In tmpList
            Me.List.Remove(tmpElem)
            '// store the operation in undo/redo buffer
            storeDo("D", tmpElem)
        Next
    End Sub

    Public Sub groupSelected()
        Dim tmpList As ArrayList = New ArrayList
        For Each elem As BaseElement In Me.List
            If elem.Selected Then
                tmpList.Add(elem)
            End If
        Next
        If Not Me.selEle Is Nothing Then
            selEle = Nothing
            Me.selectRect = Nothing
        End If
        For Each tmpElem As BaseElement In tmpList
            Me.List.Remove(tmpElem)
            '// store the operation in undo/redo buffer
            storeDo("D", tmpElem)
        Next
        Dim g As Group = New Group(tmpList)
        Me.List.Add(g)


        selectRect = New SelRectHandle(g)
        selEle = g
        selEle.SelectObj()

        ' // when grouping / degrouping reset undoBuffer
        Me.undoB = New UndoBuffer(20)
    End Sub

    Public Sub deGroupSelected()
        Dim tmpList As ArrayList = New ArrayList
        For Each elem As BaseElement In Me.List
            If elem.Selected Then
                tmpList.Add(elem)
            End If
        Next
        If Not Me.selEle Is Nothing Then
            selEle = Nothing
            Me.selectRect = Nothing
        End If
        Dim found As Boolean = False

        For Each tmpElem As BaseElement In tmpList
            Dim tmpL As ArrayList = tmpElem.deGroup

            If Not tmpL Is Nothing Then
                For Each e1 As BaseElement In tmpL
                    Me.List.Add(e1)
                Next
                Me.List.Remove(tmpElem)
                found = True
            End If
        Next
        If found Then
            ' // when grouping / degrouping reset undoBuffer
            Me.undoB = New UndoBuffer(20)
        End If
    End Sub

    Public Sub move(ByVal dx As Integer, ByVal dy As Integer)
        For Each e As BaseElement In Me.List
            If e.Selected Then
                e.move(dx, dy)
            End If
        Next
    End Sub

    Public Sub Fit2grid(ByVal gridsize As Integer)
        For Each e As BaseElement In Me.List
            If e.Selected Then
                e.Fit2Grid(gridsize)
            End If
        Next
    End Sub

    Public Sub endMove()
        For Each e As BaseElement In Me.List
            If e.Selected Then
                e.endMoveRedim()
                If Not e.AmIaGroup Then
                    storeDo("U", e)
                End If
            End If
        Next

    End Sub

    Public Sub Propertychanged()
        For Each e As BaseElement In Me.List
            If e.Selected Then
                storeDo("U", e)
            End If
        Next
    End Sub

#Region "undo/redo "

    Public Function UndoEnabled() As Boolean
        Return Me.undoB.unDoable()
    End Function

    Public Function RedoEnabled() As Boolean
        Return Me.undoB.unRedoable
    End Function

    Public Sub storeDo(ByVal opt As String, ByVal e As BaseElement)
        Dim olde As BaseElement = Nothing
        If Not e.undoEle Is Nothing Then
            olde = e.undoEle.Copy
            Dim newe As BaseElement = e.Copy
            Dim buff As buffEle = New buffEle(e, newe, olde, opt)
            Me.undoB.add2Buff(buff)
            e.undoEle = e.Copy
        End If
    End Sub

    Public Sub Undo()
        Dim buff As buffEle = CType(Me.undoB.Undo, buffEle)
        If Not buff Is Nothing Then
            Select Case buff.op
                Case "U"
                    buff.objRef.CopyFrom(buff.oldE)
                Case "I"
                    Me.List.Remove(buff.objRef)
                Case "D"
                    Me.List.Add(buff.objRef)
            End Select
        End If
    End Sub

    Public Sub Redo()
        Dim buff As buffEle = CType(Me.undoB.Redo, buffEle)
        If Not buff Is Nothing Then
            Select Case buff.op
                Case "U"
                    buff.objRef.CopyFrom(buff.newE)
                Case "I"
                    Me.List.Add(buff.objRef)
                Case "D"
                    Me.List.Remove(buff.objRef)
            End Select
        End If

    End Sub


#End Region

    Private Function countSelected() As Integer
        Dim i As Integer = 0
        For Each e As BaseElement In Me.List
            If e.Selected Then
                i += 1
            End If
        Next
        Return i
    End Function

    Public Function getSelectedArray() As BaseElement()
        Dim myArray(Me.countSelected - 1) As BaseElement
        Dim i As Integer = 0
        For Each e As BaseElement In Me.List
            If e.Selected Then
                myArray(i) = e
                i += 1
            End If
        Next
        Return myArray
    End Function

    Public Function getSelectedList() As ArrayList
        Dim tmpL As ArrayList = New ArrayList
        For Each e As BaseElement In Me.List
            If e.Selected Then
                tmpL.Add(e)
            End If
        Next
        Return tmpL
    End Function

    Public Sub setList(ByVal a As ArrayList)
        For Each e As BaseElement In a
            Me.List.Add(e)
        Next
    End Sub
    'Bring2Front
    Public Sub Bring2Front()
        If Not Me.selEle Is Nothing Then
            Me.List.Remove(selEle)
            Me.List.Add(selEle)
        End If
    End Sub
    'Send2Back
    Public Sub Send2Back()
        If Not Me.selEle Is Nothing Then
            Me.List.Remove(selEle)
            Me.List.Insert(0, selEle)
            Me.deSelect()
        End If

    End Sub

    Public Sub deSelect()
        For Each obj As BaseElement In Me.List
            obj.Selected = False
        Next
        selEle = Nothing
        selectRect = Nothing

    End Sub

#Region "DRAW   -"

    Public Sub Draw(ByVal g As Graphics, ByVal dx As Integer, ByVal dy As Integer, ByVal zoom As Single)
        Dim almostOneSelected As Boolean = False
        For Each obj As BaseElement In Me.List
            obj.Draw(g, dx, dy, zoom)
            If (obj.Selected) Then
                almostOneSelected = True
            End If
        Next
        If (almostOneSelected) Then
            If Not selectRect Is Nothing Then
                selectRect.Draw(g, dx, dy, zoom)
            End If
        End If
    End Sub

    Public Sub DrawUnselected(ByVal g As Graphics, ByVal dx As Integer, ByVal dy As Integer, ByVal zoom As Single)
        g.PageScale = 10
        For Each obj As BaseElement In Me.List
            If Not obj.Selected Then
                obj.Draw(g, dx, dy, zoom)
            End If
        Next
    End Sub

    Public Sub DrawUnselected(ByVal g As Graphics)
        g.PageScale = 10
        For Each obj As BaseElement In Me.List
            If Not obj.Selected Then
                obj.Draw(g, 0, 0, 1)
            End If
        Next
    End Sub

    Public Sub DrawSelected(ByVal g As Graphics, ByVal dx As Integer, ByVal dy As Integer, ByVal zoom As Single)
        Dim almostOneSelected As Boolean = False
        For Each obj As BaseElement In Me.List
            If (obj.Selected) Then
                obj.Draw(g, dx, dy, zoom)
                almostOneSelected = True
            End If
        Next
        If (almostOneSelected) Then
            If Not selectRect Is Nothing Then
                selectRect.Draw(g, dx, dy, zoom)
            End If
        End If
    End Sub

    Public Sub DrawSelected(ByVal g As Graphics)
        Dim almostOneSelected As Boolean = False
        For Each obj As BaseElement In Me.List
            If (obj.Selected) Then
                obj.Draw(g, 0, 0, 1)
                almostOneSelected = True
            End If
        Next
        If (almostOneSelected) Then
            If Not selectRect Is Nothing Then
                selectRect.Draw(g, 0, 0, 1)
            End If
        End If
    End Sub

#End Region

    Public Sub addRect(ByVal elName As String, ByVal x As Integer, ByVal y As Integer, ByVal x1 As Integer, ByVal y1 As Integer, ByVal penC As Color, ByVal fillC As Color, ByVal penW As Single, ByVal filled As Boolean)
        If (x1 - minDim <= x) Then
            x1 = x + minDim
        End If
        If (y1 - minDim <= y) Then
            y1 = y + minDim
        End If
        Me.deSelect()
        Dim r As Rect = New Rect(elName, x, y, x1, y1)
        r.penColor = penC
        r.penWidth = penW
        r.fillColor = fillC
        r.filled = filled

        Me.List.Add(r)
        storeDo("I", r)

        selectRect = New SelRectHandle(r)
        selEle = r
        selEle.SelectObj()
        SetSnapPoint(r)
    End Sub

    'Public Sub addArc(ByVal x As Integer, ByVal y As Integer, ByVal x1 As Integer, ByVal y1 As Integer, ByVal penC As Color, ByVal fillC As Color, ByVal penW As Single, ByVal filled As Boolean)
    '    If (x1 - minDim <= x) Then
    '        x1 = x + minDim
    '    End If
    '    If (y1 - minDim <= y) Then
    '        y1 = y + minDim
    '    End If

    '    Me.deSelect()

    '    Dim r As Arc = New Arc(x, y, x1, y1)
    '    r.penColor = penC
    '    r.penWidth = penW
    '    r.fillColor = fillC
    '    r.filled = filled
    '    Me.List.Add(r)

    '    ' // store the operation in undo/redo buffer
    '    storeDo("I", r)

    '    selectRect = New SelRectHandle(r)
    '    selEle = r
    '    selEle.SelectObj()
    'End Sub

    'Public Sub addLine(ByVal x As Integer, ByVal y As Integer, ByVal x1 As Integer, ByVal y1 As Integer, ByVal penC As Color, ByVal penW As Single)
    '    If ((x1 = x) And (y1 = y)) Then
    '        x1 = x + minDim
    '        y1 = y + minDim
    '    End If
    '    Me.deSelect()

    '    Dim r As Linea = New Linea(x, y, x1, y1)
    '    r.penColor = penC
    '    r.penWidth = penW

    '    Me.List.Add(r)
    '    '// store the operation in undo/redo buffer
    '    storeDo("I", r)

    '    selectRect = New SelRectHandle(r)
    '    selEle = r
    '    selEle.SelectObj()
    'End Sub

    'Public Sub addTextBox(ByVal x As Integer, ByVal y As Integer, ByVal x1 As Integer, ByVal y1 As Integer, ByVal t As RichTextBox, ByVal penC As Color, ByVal fillC As Color, ByVal penW As Single, ByVal filled As Boolean)
    '    If (x1 - minDim <= x) Then
    '        x1 = x + minDim
    '    End If
    '    If (y1 - minDim <= y) Then
    '        y1 = y + minDim
    '    End If

    '    Me.deSelect()

    '    Dim r As BoxTesto = New BoxTesto(x, y, x1, y1)
    '    r.penColor = penC
    '    r.penWidth = penW
    '    r.fillColor = fillC
    '    r.filled = filled

    '    '  //Queste due riche sono alternative in base al tipo di textbox che si utilizza
    '    r.rtf = t.Rtf

    '    Me.List.Add(r)
    '    ' // store the operation in undo/redo buffer
    '    storeDo("I", r)

    '    selectRect = New SelRectHandle(r)
    '    selEle = r
    '    selEle.SelectObj()

    'End Sub

    'Public Sub addRRect(ByVal x As Integer, ByVal y As Integer, ByVal x1 As Integer, ByVal y1 As Integer, ByVal penC As Color, ByVal fillC As Color, ByVal penW As Single, ByVal filled As Boolean)
    '    If (x1 - minDim <= x) Then
    '        x1 = x + minDim
    '    End If
    '    If (y1 - minDim <= y) Then
    '        y1 = y + minDim
    '    End If

    '    Me.deSelect()

    '    Dim r As RRect = New RRect(x, y, x1, y1)
    '    r.penColor = penC
    '    r.penWidth = penW
    '    r.fillColor = fillC
    '    r.filled = filled

    '    Me.List.Add(r)

    '    '  // store the operation in undo/redo buffer
    '    storeDo("I", r)

    '    selectRect = New SelRect(r)
    '    selEle = r
    '    selEle.SelectObj()
    'End Sub

    'Public Sub addImgBox(ByVal x As Integer, ByVal y As Integer, ByVal x1 As Integer, ByVal y1 As Integer, ByVal st As String, ByVal penC As Color, ByVal penW As Single)
    '    If (x1 - minDim <= x) Then
    '        x1 = x + minDim
    '    End If
    '    If (y1 - minDim <= y) Then
    '        y1 = y + minDim
    '    End If

    '    Me.deSelect()

    '    Dim r As ImgBox = New ImgBox(x, y, x1, y1)
    '    r.penColor = penC
    '    r.penWidth = penW

    '    Me.List.Add(r)
    '    ' // store the operation in undo/redo buffer
    '    storeDo("I", r)

    '    If Not st Is Nothing Then
    '        Try
    '            Dim loadTexture As Bitmap = New Bitmap(st)
    '            r.img = loadTexture
    '            selectRect = New SelRectHandle(r)
    '            selEle = r
    '            selEle.SelectObj()
    '        Catch ex As Exception

    '        End Try
    '    End If
    'End Sub

    'Public Sub addEllipse(ByVal x As Integer, ByVal y As Integer, ByVal x1 As Integer, ByVal y1 As Integer, ByVal penC As Color, ByVal fillC As Color, ByVal penW As Single, ByVal filled As Boolean)
    '    If (x1 - minDim <= x) Then
    '        x1 = x + minDim
    '    End If
    '    If (y1 - minDim <= y) Then
    '        y1 = y + minDim
    '    End If

    '    Me.deSelect()
    '    Dim r As Ellips = New Ellips(x, y, x1, y1)
    '    r.penColor = penC
    '    r.penWidth = penW
    '    r.fillColor = fillC
    '    r.filled = filled

    '    Me.List.Add(r)
    '    '  // store the operation in undo/redo buffer
    '    storeDo("I", r)

    '    selectRect = New SelRectHandle(r)
    '    selEle = r
    '    selEle.SelectObj()
    'End Sub

    Public Sub click(ByVal x As Integer, ByVal y As Integer) ', ByVal r As RichTextBox)
        selectRect = Nothing
        selEle = Nothing
        For Each obj As BaseElement In Me.List
            obj.Selected = False
            If obj.contains(x, y) Then
                selEle = obj
            End If
        Next
        If Not selEle Is Nothing Then
            selEle.Selected = True
            selEle.SelectObj()
            'selEle.SelectObj(r)
            selectRect = New SelRectHandle(selEle)  '//create handling rect
        End If
    End Sub

    Public Sub multiSelect(ByVal startX As Integer, ByVal startY As Integer, ByVal endX As Integer, ByVal endY As Integer)  ', ByVal r As RichTextBox)
        selectRect = Nothing
        selEle = Nothing
        For Each obj As BaseElement In Me.List
            obj.Selected = False
            Dim x As Integer = obj.getX()
            Dim x1 As Integer = obj.getX1()
            Dim y As Integer = obj.getY()
            Dim y1 As Integer = obj.getY1()
            Dim c As Integer = 0
            If (x > x1) Then
                c = x
                x = x1
                x1 = c
            End If
            If (y > y1) Then
                c = y
                y = y1
                y1 = c
            End If
            ' //if (obj.getX() <= endX & obj.getX1() >= startX & obj.getY() <= endY & obj.getY1() >= startY)
            If (x <= endX And x1 >= startX And y <= endY And y1 >= startY) Then
                selEle = obj
                obj.Selected = True
                obj.SelectObj()
                'obj.SelectObj(r)
            End If
        Next
        If Not selEle Is Nothing Then
            selectRect = New SelRectHandle(selEle)
        End If

    End Sub

    Public Sub UpdateData(ByVal NewEvent As mvcLibrary.mvcEventArgsBase) Implements mvcLibrary.IObserver.UpdateData

    End Sub
End Class
