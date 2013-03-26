

Public Delegate Sub ObjectSelected(ByVal sender As Object, ByVal e As PropertyEventArgs)

Public Class PropertyEventArgs
    Inherits EventArgs

    Public ele As BaseElement()
    Public Undoable As Boolean
    Public Redoable As Boolean

    Public Sub New(ByVal a As BaseElement(), ByVal r As Boolean, ByVal u As Boolean)
        Me.ele = a
        Me.Undoable = u
        Me.Redoable = r
    End Sub
End Class
'public class PropertyEventArgs : EventArgs
' {
'     public Ele[] ele;
'     public bool Undoable; //for enable/disable udo/redoBtn
'     public bool Redoable; //for enable/disable udo/redoBtn
'     //Constructor.
'     public PropertyEventArgs(Ele[] a,bool r, bool u)
'     {
'         this.ele = a;
'         this.Undoable = u;
'         this.Redoable = r;
'     }
' }