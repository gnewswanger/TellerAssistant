''' <summary>
''' <file>Enumerations.vb</file>
''' <author>Galen Newswanger</author>
''' This file contains various global enumerations
''' </summary>
''' <remarks></remarks>
Public Enum EventName
    evnmEventLoggingChanged
    evnmScannerStatusChanged
    evnmScannerEnableChanged
    evnmScannedImageReady
    evnmScannedImageTransmitted
    evnmCheckStatusChanged
    evnmCheckAmountChanged
    evnmCheckInserted
    evnmCheckUpdated
    evnmCheckOnlyDeleted
    evnmCheckDeleted
    evnmDbCheckDonorUpdated
    evnmDbCheckDonorInserted
    evnmVwDonorInfoChanged
    envmCurrentQueueCheckChanged
    evnmDataTransactionFailed
    evnmCashClassAdded
    evnmCashClassUpdated
    evnmDepositInfoChanged
    evnmBankInfoChanged
    evnmBankInfoDeleted
    evnmCheckSearchRequest
    evnmCheckSearchResult
End Enum

Public Enum ConnectionType
    ctNone
    ctRS232
    ctFTP
End Enum

Public Enum ScannerStatus
    ssNone
    ssNonMICREnabled
    ssNonMICRDisabled
    ssScanEnabled
    ssScanDisabled
End Enum

Public Enum CashType
    Penny = 1
    Nickel = 5
    Dime = 10
    Quarter = 25
    HalfDollar = 50
    DollarCoin = 99
    One = 100
    Two = 200
    Five = 500
    Ten = 1000
    Twenty = 2000
    Fifty = 5000
    OneHundred = 10000
    OneThousand = 100000
End Enum

Public Enum ReceiveDataMode
    ImageComing = 2
    SizeComing = 4
    TextComing = 8
End Enum

Public Enum DataTransactionTypes
    dbFailed
    dbUpdated
    dbInserted
    dbSelected
    dbDeleted
End Enum

Public Enum CheckStatus
    csNone
    csAmountPending
    csEditPending
    csConfirmPending
    csVerified
End Enum

Public Enum ReportMode
    rmNone
    rmDraft
    rmFinal
    rmTicketX3
End Enum

Public Enum DataSearchType
    stCheckSearch
    stDepositNoSearch
    stDepositKeySearch
    stDepositDateSearch
End Enum

Public Enum ViewMode
    vmEntryView
    vmEditView
    vmConfirmView
    vmAddView
End Enum

Public Enum CheckImageView
    civExtraLargeIcon
    civLargeIcon
    civSmallIcon
    civList
    civDetails
End Enum

<Flags()> Public Enum ReceiptRequestStatus
    rrsNone = 0
    rrsRequestedNotSent = 2
    rrsRequestedSent = 4
    rrsAllRequests = rrsRequestedNotSent Or rrsRequestedSent
End Enum

