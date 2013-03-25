Public Class ColumnClass
    Implements mvcLibrary.IObserver

    Private colID As Integer
    Private colLeft As Single
    Private colWidth As Single
  
    Public ReadOnly Property ColumnID() As Integer
        Get
            Return colID
        End Get
    End Property

    Public Property ColumnLeft() As Integer
        Get
            Return CInt(colLeft)
        End Get
        Set(ByVal value As Integer)
            colLeft = value
       End Set
    End Property

    Public Property ColumnWidth() As Integer
        Get
            Return CInt(colWidth)
        End Get
        Set(ByVal value As Integer)
            colWidth = value
         End Set
    End Property


    Public Sub New(ByVal colNo As Integer, ByVal left As Integer, ByVal width As Integer)
        colID = colNo
        colLeft = left
        colWidth = width
    End Sub

    Public Sub New(ByVal col As ColumnClass)
        colID = col.colID
        colLeft = col.colLeft
        colWidth = col.ColumnWidth
    End Sub


    Public Sub UpdateData(ByVal NewEvent As mvcLibrary.mvcEventArgsBase) Implements mvcLibrary.IObserver.UpdateData
        Select Case CType(NewEvent, AbstractPrintEventArgs).Name
            Case PrintEventName.peLandscapeChanged
                If Me.colID = 0 Then
                    Dim settings As System.Drawing.Printing.PageSettings = CType(CType(NewEvent, AbstractPrintEventArgs).Value, System.Drawing.Printing.PageSettings)
                    colWidth = settings.Bounds.Width - settings.Margins.Left - settings.Margins.Right
                End If

        End Select

    End Sub
End Class
   