Public Interface ICheckScanner

    ReadOnly Property ConnectionMode() As ConnectionType
    ReadOnly Property Connected() As Boolean
    WriteOnly Property ResetScanner() As Boolean
    WriteOnly Property EnableScanner() As Boolean
    'Property ImageDirectory() As String
    Property DelayInterval() As Integer
    Sub TransmitImage(ByVal value As String)
    Sub Close()

End Interface




