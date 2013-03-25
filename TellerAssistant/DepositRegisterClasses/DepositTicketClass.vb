Imports System.IO

Public Class DepositTicketClass

    Private _depNo As String = String.Empty
    Private _depDate As DateTime
    Private _depDescription As String = String.Empty
    Private _depTotal As Single
    Private _bankAcct As BankAccountClass
    Private _imgPath As String = String.Empty

#Region "Class Properties"
    Public ReadOnly Property DepositNumber() As String
        Get
            Return Me._depNo.Trim
        End Get
    End Property

    Public ReadOnly Property DepositDate() As DateTime
        Get
            Return Me._depDate
        End Get
    End Property

    Public ReadOnly Property Description() As String
        Get
            Return Me._depDescription.Trim
        End Get
    End Property

    Public Property DepositTotal() As Single
        Get
            Return Me._depTotal
        End Get
        Set(ByVal value As Single)
            Me._depTotal = value
        End Set
    End Property

    Public Property BankInfo() As BankAccountClass
        Get
            Return Me._bankAcct
        End Get
        Set(ByVal value As BankAccountClass)
            Me._bankAcct = value
        End Set
    End Property

    Public Property CheckImagePath() As String
        Get
            If Me._imgPath Is Nothing OrElse Me._imgPath = String.Empty OrElse Not Directory.Exists(Me._imgPath) Then
                Return DefaultImageFullPath()
            Else
                Return Me._imgPath
            End If
        End Get
        Set(ByVal value As String)
            Me._imgPath = value
        End Set
    End Property

    Public ReadOnly Property DefaultImageFullPath() As String
        Get
            Dim path As String = Application.LocalUserAppDataPath & "\" & My.Settings.DefaultImageFolder
            If Not path.EndsWith("\") Then
                path += "\"
            End If
            path += Me._depDate.ToString("yyyy_MM_MMM") & "\" & Me.DepositNumber & "\"
            If Not Directory.Exists(path) Then
                Directory.CreateDirectory(path)
            End If
            Return path
        End Get
    End Property

#End Region

    Public Sub New(ByVal number As String, ByVal aDate As DateTime, ByVal descript As String, Optional ByVal total As Single = 0.0)
        Me._depNo = number
        Me._depDate = aDate
        Me._depDescription = descript
        Me._depTotal = total
        Me.SetDefaultImagePath()
    End Sub

    Public Sub New(ByVal number As String, ByVal aDate As DateTime, ByVal descript As String, ByVal bank As BankAccountClass, Optional ByVal total As Single = 0.0)
        Me._depNo = number
        Me._depDate = aDate
        Me._depDescription = descript
        Me._bankAcct = bank
        Me._depTotal = total
        Me.SetDefaultImagePath()
    End Sub

    Private Sub SetDefaultImagePath()
        If Not My.Settings.DefaultImageFolder = String.Empty AndAlso Not My.Settings.DefaultImageFolder.EndsWith("\") Then
            My.Settings.DefaultImageFolder = My.Settings.DefaultImageFolder + "\"
        End If
        Me._imgPath = Me.DefaultImageFullPath
    End Sub

End Class
