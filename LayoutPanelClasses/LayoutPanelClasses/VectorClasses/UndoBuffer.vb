Public Class buffEle
    Public objRef As BaseElement
    Public op As String 'U:Update, I:Insert, D:Delete
    Public oldE As BaseElement  'Start Point
    Public newE As BaseElement  'Start Point

    Public Sub New(ByVal refEle As BaseElement, ByVal newEle As BaseElement, ByVal oldEle As BaseElement, ByVal o As String)
        Me.objRef = refEle
        Me.oldE = oldEle
        Me.newE = newEle
        Me.op = o

    End Sub
End Class

Public Class buffObj
    Public NextObj As buffObj
    Public PrevObj As buffObj
    Public elem As Object

    Public Sub New(ByVal o As Object)
        elem = o
    End Sub
End Class

<Serializable()> _
Public Class UndoBuffer
    Private Top As buffObj
    Private Bottom As buffObj
    Private Current As buffObj
    Private _BuffSize As Integer
    Private _N_elem As Integer
    Private At_Bottom As Boolean

    Public Sub New(ByVal i As Integer)
        Me.BuffSize = i
        Me._N_elem = 0
        Me.Top = Nothing
        Me.Bottom = Nothing
        Me.Current = Nothing
        Me.At_Bottom = True
    End Sub

    Public Property BuffSize() As Integer
        Get
            Return _BuffSize
        End Get
        Set(ByVal value As Integer)
            _BuffSize = value
        End Set
    End Property

    Public ReadOnly Property N_elem() As Integer
        Get
            Return _N_elem
        End Get
    End Property

    Public Sub add2Buff(ByVal o As Object)
        If Not o Is Nothing Then
            Dim g As buffObj = New buffObj(o)
            If Me.N_elem = 0 Then
                g.NextObj = Nothing
                g.PrevObj = Nothing
                Top = g
                Bottom = g
                Current = g
            Else
                g.PrevObj = Current
                g.NextObj = Nothing
                Current.NextObj = g
                Top = g
                Current = g
                If Me.N_elem = 1 Then
                    Bottom.NextObj = g
                End If
            End If
            Me._N_elem += 1
            If Me.BuffSize < Me.N_elem Then
                Me.Bottom = Me.Bottom.NextObj
                Me.Bottom.PrevObj = Nothing
                Me._N_elem -= 1
            End If
            At_Bottom = False
        End If
    End Sub

    Public Function Undo() As Object
        If Not Current Is Nothing Then
            Dim obj As Object = Current.elem
            If Not Current.PrevObj Is Nothing Then
                Current = Current.PrevObj
                Me._N_elem -= 1
                Me.At_Bottom = False
            Else
                Me.At_Bottom = True
            End If
            Return obj
        End If
        Return Nothing
    End Function

    Public Function Redo() As Object
        If Not Current Is Nothing Then
            Dim obj As Object
            If Not At_Bottom Then
                If Not Current.NextObj Is Nothing Then
                    Current = Current.NextObj
                    Me._N_elem += 1
                End If
            Else
                Me.At_Bottom = False
            End If
            obj = Current.elem
            Return obj
        End If
        Return Nothing
    End Function

    Public Function unDoable() As Boolean
        Return Not Me.At_Bottom
    End Function

    Public Function unRedoable() As Boolean
        If Me.Current Is Nothing Then
            Return False
        End If
        If Me.Current.NextObj Is Nothing Then
            Return False
        End If
        Return True
    End Function

End Class
