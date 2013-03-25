Public Class DonorClass
    Implements mvcLibrary.IObserver

    Private _donor As String = String.Empty
    Private _address As String = String.Empty
    Private _city As String = String.Empty
    Private _state As String = String.Empty
    Private _zip As String = String.Empty

    Public Property Donor() As String
        Get
            Return Me._donor
        End Get
        Set(ByVal value As String)
            Me._donor = value
        End Set
    End Property
    Public Property Address() As String
        Get
            Return Me._address
        End Get
        Set(ByVal value As String)
            Me._address = value
        End Set
    End Property
    Public Property City() As String
        Get
            Return Me._city
        End Get
        Set(ByVal value As String)
            Me._city = value
        End Set
    End Property
    Public Property State() As String
        Get
            Return Me._state
        End Get
        Set(ByVal value As String)
            Me._state = value
        End Set
    End Property
    Public Property Zip() As String
        Get
            Return Me._zip
        End Get
        Set(ByVal value As String)
            Me._zip = value
        End Set
    End Property

    Public Sub New(ByVal aDonor As String)
        Me._donor = aDonor
    End Sub

    Public Shared Function Clone(ByVal dClass As DonorClass) As DonorClass
        Dim retVal As New DonorClass(dClass.Donor)
        retVal.Address = dClass.Address
        retVal.City = dClass.City
        retVal.State = dClass.State
        retVal.Zip = dClass.Zip
        Return retVal
    End Function

    Public Sub UpdateData(ByVal NewEvent As mvcLibrary.mvcEventArgsBase) Implements mvcLibrary.IObserver.UpdateData

    End Sub
End Class
