Public Interface IViewFrmMain
    Inherits mvcLibrary.IView

    WriteOnly Property ListViewDeposits() As List(Of DepositTicketClass)
    WriteOnly Property DepositTicket() As DepositTicketClass
    WriteOnly Property ListViewBanks() As List(Of BankAccountClass)
    WriteOnly Property PortTypeIcon() As ConnectionType
    Property SelectedBank() As BankAccountClass
    ReadOnly Property NewDepositIsChecked() As Boolean
    ReadOnly Property FilterYTDIsChecked() As Boolean
    Property ChecksTotal() As Single
    Property ScannerConnectionMode() As ConnectionType
    WriteOnly Property DelayInterval() As Integer
    WriteOnly Property CashText() As CashClass
    WriteOnly Property CashTextCount() As CashClass
    WriteOnly Property DepositTotals() As DepositBalanceClass
    WriteOnly Property MICRStatusFlyout() As String
    WriteOnly Property CheckImageFlyout() As Image
    WriteOnly Property CheckImage() As CheckRegisterEventArgs
    WriteOnly Property CheckQueueCount() As CheckRegisterEventArgs
    WriteOnly Property Checklist() As List(Of ChecksClass)
    WriteOnly Property Donorlist() As List(Of DonorClass)
    WriteOnly Property ScannerEnabled() As Boolean
    WriteOnly Property LoggingToggle() As Boolean
End Interface
