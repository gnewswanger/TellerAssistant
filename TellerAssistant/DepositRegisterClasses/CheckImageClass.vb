Imports System.IO
Imports System.Drawing

Public Class CheckImageClass

    Private _chkImage As Bitmap
    Private _rtePath As Drawing2D.GraphicsPath
    Private _acctPath As Drawing2D.GraphicsPath
    Private _numPath As Drawing2D.GraphicsPath
    Private _amtPath As Drawing2D.GraphicsPath
    Private _dtPath As Drawing2D.GraphicsPath
    Private _donorPath As Drawing2D.GraphicsPath
    Private _rteRec As Rectangle
    Private _acctRec As Rectangle
    Private _numRec As Rectangle
    Private _amtRec As Rectangle
    Private _dtRec As Rectangle
    Private _donorRec As Rectangle

    Public Property CheckImage() As Image
        Get
            Return GetCheckImage()
        End Get
        Set(ByVal value As Image)
            SetCheckImage(New Bitmap(value))
        End Set
    End Property

    Public WriteOnly Property RoutingText() As String
        Set(ByVal value As String)
            SetRoutingText(value)
        End Set
    End Property

    Public WriteOnly Property AccountText() As String
        Set(ByVal value As String)
            SetAccountText(value)
        End Set
    End Property

    Public WriteOnly Property CheckNumberText() As String
        Set(ByVal value As String)
            SetCheckNumText(value)
        End Set
    End Property

    Public WriteOnly Property AmountText() As String
        Set(ByVal value As String)
            SetAmountText(value)
        End Set
    End Property

    Public WriteOnly Property DateText() As String
        Set(ByVal value As String)
            SetDateText(value)
        End Set
    End Property

    Public WriteOnly Property DonorText() As String
        Set(ByVal value As String)
            SetDonorText(value)
        End Set
    End Property

    Public Sub New(ByVal fname As String)
        If File.Exists(fname) Then
            Dim fs As New FileStream(fname, FileMode.Open)
            SetCheckImage(New Bitmap(fs))
            fs.Close()
        Else
            SetCheckImage(New Bitmap(CreateNotfoundImage(New Size(1200, 600))))
        End If
    End Sub

    Private Sub SetCheckImage(ByVal img As Bitmap)
        Me._chkImage = New Bitmap(img)
        'rteRec = New Rectangle(26, 156, 145, 15)
        Me._rteRec = New Rectangle(158, 466, 312, 42)
        Me._rtePath = New Drawing2D.GraphicsPath
        'acctRec = New Rectangle(186, 156, 93, 15)
        Me._acctRec = New Rectangle(534, 466, 298, 42)
        Me._acctPath = New Drawing2D.GraphicsPath
        'numRec = New Rectangle(300, 156, 90, 15)
        Me._numRec = New Rectangle(868, 466, 242, 42)
        Me._numPath = New Drawing2D.GraphicsPath
        'amtRec = New Rectangle(310, 72, 115, 20)
        Me._amtRec = New Rectangle(850, 255, 310, 56)
        Me._amtPath = New Drawing2D.GraphicsPath
        'dtRec = New Rectangle(312, 25, 94, 15)
        Me._dtRec = New Rectangle(890, 140, 234, 32)
        Me._dtPath = New Drawing2D.GraphicsPath
        Me._donorRec = New Rectangle(696, 368, 446, 54)
        Me._donorPath = New Drawing2D.GraphicsPath
    End Sub

    Private Function GetCheckImage() As Image
        Dim btmap As New Bitmap(Me._chkImage)
        Dim grph As Graphics = Graphics.FromImage(btmap)
        grph.DrawPath(New Pen(New SolidBrush(Color.DarkSlateBlue), 4), Me._rtePath)
        grph.DrawPath(New Pen(New SolidBrush(Color.DarkSlateBlue), 4), Me._acctPath)
        grph.DrawPath(New Pen(New SolidBrush(Color.DarkSlateBlue), 4), Me._numPath)
        grph.DrawPath(New Pen(New SolidBrush(Color.DarkBlue), 5), Me._amtPath)
        grph.DrawPath(New Pen(New SolidBrush(Color.DarkSlateBlue), 4), Me._dtPath)
        grph.DrawPath(New Pen(New SolidBrush(Color.DarkSlateBlue), 4), Me._donorPath)
        Return btmap
    End Function

    Private Sub SetRoutingText(ByVal value As String)
        If Me._rtePath IsNot Nothing Then
            Me._rtePath.Dispose()
        End If
        Me._rtePath = New Drawing2D.GraphicsPath
        Me._rtePath.AddString(value, New FontFamily("Tahoma"), CInt(FontStyle.Regular), 14.0F * (200 / 72), Me._rteRec, StringFormat.GenericDefault)
    End Sub
    Private Sub SetAccountText(ByVal value As String)
        If Me._acctPath IsNot Nothing Then
            Me._acctPath.Dispose()
        End If
        Me._acctPath = New Drawing2D.GraphicsPath
        Me._acctPath.AddString(value, New FontFamily("Tahoma"), CInt(FontStyle.Regular), 14.0F * (200 / 72), Me._acctRec, StringFormat.GenericDefault)
    End Sub
    Private Sub SetCheckNumText(ByVal value As String)
        If Me._numPath IsNot Nothing Then
            Me._numPath.Dispose()
        End If
        Me._numPath = New Drawing2D.GraphicsPath
        Me._numPath.AddString(value, New FontFamily("Tahoma"), CInt(FontStyle.Regular), 14.0F * (200 / 72), Me._numRec, StringFormat.GenericDefault)
    End Sub
    Private Sub SetAmountText(ByVal value As String)
        If Me._amtPath IsNot Nothing Then
            Me._amtPath.Dispose()
        End If
        Me._amtPath = New Drawing2D.GraphicsPath
        Me._amtPath.AddString(value, New FontFamily("Tahoma"), CInt(FontStyle.Regular), 16.0F * (200 / 72), Me._amtRec, StringFormat.GenericDefault)
    End Sub
    Private Sub SetDateText(ByVal value As String)
        If Me._dtPath IsNot Nothing Then
            Me._dtPath.Dispose()
        End If
        Me._dtPath = New Drawing2D.GraphicsPath
        Me._dtPath.AddString(value, New FontFamily("Tahoma"), CInt(FontStyle.Regular), 14.0F * (200 / 72), Me._dtRec, StringFormat.GenericDefault)
    End Sub
    Private Sub SetDonorText(ByVal value As String)
        If Me._donorPath IsNot Nothing Then
            Me._donorPath.Dispose()
        End If
        Me._donorPath = New Drawing2D.GraphicsPath
        Me._donorPath.AddString(value, New FontFamily("Tahoma"), CInt(FontStyle.Regular), 14.0F * (200 / 72), Me._donorRec, StringFormat.GenericDefault)
    End Sub

    Private Function CreateNotfoundImage(ByVal size As Size) As Image
        Dim retImage As Image
        Dim strPath As New Drawing2D.GraphicsPath
        strPath.AddString("Image Not Found", New FontFamily("Arial"), CInt(FontStyle.Italic), 24.0F * (200 / 72), New Point(10, 40), StringFormat.GenericDefault)
        retImage = New Bitmap(size.Width, size.Height)
        Dim grph As Graphics = Graphics.FromImage(retImage)
        grph.Clear(Color.IndianRed)
        grph.DrawPath(New Pen(Color.Black), strPath)
        Return retImage
    End Function
End Class
