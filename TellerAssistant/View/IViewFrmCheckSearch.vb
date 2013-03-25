Public Interface IViewFrmCheckSearch
    Inherits mvcLibrary.IView

    WriteOnly Property Checklist() As List(Of ChecksClass)
    WriteOnly Property ActiveDepNo() As String
    WriteOnly Property CheckAdded() As ChecksClass
    WriteOnly Property CheckChanged() As ChecksClass
    WriteOnly Property CheckDeleted() As ChecksClass

End Interface
