Public Class DonorInfoEventArgs
    Inherits AbstractEventArgs

    Public DonorInfo As DonorClass
    Public CheckQueue As CheckStatus

    Public Sub New(ByVal evName As EventName, ByVal donor As DonorClass, Optional ByVal queue As CheckStatus = CheckStatus.csNone)
        MyBase.New(evName)
        Me.DonorInfo = donor
        Me.CheckQueue = queue
    End Sub

End Class
