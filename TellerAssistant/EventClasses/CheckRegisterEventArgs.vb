Public Class CheckRegisterEventArgs
    Inherits TellerAssistant2012.AbstractEventArgs

    Public modCheck As ChecksClass
    Public origCheck As ChecksClass
    Private _queueCount As Integer
    Private _queueIndex As Integer

    Public ReadOnly Property QueueCount() As Integer
        Get
            Return _queueCount
        End Get
    End Property
    Public ReadOnly Property QueueIndex() As Integer
        Get
            Return _queueIndex
        End Get
    End Property

    Public Sub New(ByVal evName As EventName, ByVal origChk As ChecksClass, ByVal newChk As ChecksClass, Optional ByVal queCount As Integer = Nothing, Optional ByVal queIndex As Integer = Nothing)
        MyBase.New(evName)
        Me.modCheck = newChk
        Me.origCheck = origChk
        _queueCount = queCount
        _queueIndex = queIndex
    End Sub

    Public Sub New(ByVal dataEventArg As CheckDataEventArgs, ByVal queCount As Integer, ByVal queIndex As Integer)
        MyBase.New(dataEventArg.Name)
        Me.origCheck = dataEventArg.Check
        If Not dataEventArg.modCheck Is Nothing Then
            Me.modCheck = dataEventArg.modCheck
        End If
        _queueCount = queCount
        _queueIndex = queIndex
    End Sub

    Public Function ToCheckDataEventArgs() As CheckDataEventArgs
        Dim retVal As New CheckDataEventArgs(Me.Name, Me.origCheck, Me.modCheck)
        Return retVal
    End Function

End Class
