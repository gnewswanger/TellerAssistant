Imports System.Drawing
Imports System.ComponentModel

<Serializable()> Public MustInherit Class Handle
    Inherits BaseElement

    Public op As String

    Public Sub New(ByVal e As BaseElement, ByVal o As String)
        op = o
        Me.rePosition(e)
    End Sub

    Public Function isOver(ByVal x As Integer, ByVal y As Integer) As String
        Dim r As Rectangle
        r = New Rectangle(Me.X, Me.Y, Me.X1 - Me.X, Me.Y1 - Me.Y)
        If (r.Contains(x, y)) Then
            Return Me.op
        Else
            Return ""
        End If
    End Function

    Public Overridable Sub rePosition(ByVal e As BaseElement)

    End Sub

End Class
