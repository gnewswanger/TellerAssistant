Public Class CheckSearchEventArgs
    Inherits AbstractEventArgs

    Public check As ChecksClass
    Public DateRangeStart As DateTime
    Public DateRangeEnd As DateTime

    Public Sub New(ByVal evName As EventName, ByVal chk As ChecksClass, ByVal fromDate As DateTime, ByVal toDate As DateTime)
        MyBase.New(evName)
        check = chk
        DateRangeStart = fromDate
        DateRangeEnd = toDate
    End Sub

End Class
