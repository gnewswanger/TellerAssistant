
Public Class ListOfColumnClass
    Inherits ArrayList

    Public Class ColumnComparer
        Implements IComparer

        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
            Dim colx, coly As ColumnClass
            colx = CType(x, ColumnClass)
            coly = CType(y, ColumnClass)
            Return New CaseInsensitiveComparer().Compare(colx.ColumnID, coly.ColumnID)
        End Function
    End Class

    Private myComparer As ColumnComparer

    Public Sub New()
        MyBase.New()
        myComparer = New ColumnComparer
    End Sub

    Public Shadows Sub Sort()
        MyBase.Sort(myComparer)
    End Sub

    Public Function GetItemByID(ByVal id As String) As ColumnClass
        For Each itm As ColumnClass In Me
            If itm.ColumnID = CDbl(id) Then
                Return itm
            End If
        Next
        Return Nothing
    End Function

    Public Shadows Sub Add(ByVal value As ColumnClass)
        Dim col As ColumnClass = Me.GetItemByID(CStr(CType(value, GRNPrinting.ColumnClass).ColumnID))
        If col Is Nothing Then
            MyBase.Add(value)
        Else
            col.ColumnLeft = CType(value, GRNPrinting.ColumnClass).ColumnLeft
            col.ColumnWidth = CType(value, GRNPrinting.ColumnClass).ColumnWidth
        End If
    End Sub

    Public Shadows Sub Clear()
        Dim col0 As New GRNPrinting.ColumnClass(CType(MyBase.Item(0), ColumnClass))
        MyBase.Clear()
        MyBase.Add(col0)
    End Sub
End Class
