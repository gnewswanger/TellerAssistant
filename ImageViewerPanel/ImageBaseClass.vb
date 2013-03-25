Imports System.Drawing

Public MustInherit Class ImageBaseClass
    Private _anImage As Bitmap
    Private _imageFilename As String

    Public Property TheImage() As Image
        Get
            Return GetAnImage()
        End Get
        Set(ByVal value As Image)
            _anImage = CType(value, Bitmap)
        End Set
    End Property

    Public Property ImageFile() As String
        Get
            Return _imageFilename
        End Get
        Set(ByVal value As String)
            _imageFilename = value
        End Set
    End Property

    Protected Overridable Function GetAnImage() As Image
        Dim btmap As New Bitmap(_anImage)

        Return btmap
    End Function

End Class
