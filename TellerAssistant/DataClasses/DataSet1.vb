Partial Class DataSet1


    Partial Class upGetChecksListWithDonorDataTable

        Private Sub upGetChecksListWithDonorDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.CheckDateColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

End Class

Namespace DataSet1TableAdapters

    Partial Public Class upGetDepositTicketListTableAdapter
    End Class
End Namespace
