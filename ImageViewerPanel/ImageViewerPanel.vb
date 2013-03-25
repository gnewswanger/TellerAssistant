Imports System.Windows.Forms
Imports System.Drawing
Imports System.IO

Public Class ImageViewerPanel

    Delegate Sub GenericCallback(ByVal sender As System.Object, ByVal e As System.EventArgs)

    Public Property Image() As Image
        Get
            Return picsBox.Image
        End Get
        Set(ByVal value As Image)
            If value Is Nothing Then
                picsBox.Image = Nothing
            Else
                picsBox.Image = New Bitmap(value)
                'ResizeImage(pnlPicsBox.Size, picsBox)
                ZoomPix(False, pnlPicsBox, picsBox)
            End If
        End Set
    End Property

    Public Sub ShowImageNotFound()
        picsBox.Image = CreateNotfoundImage(pnlPicsBox.Size)
    End Sub

#Region "Picturebox Methods"

    Private moveStartPoint As Point
    Private entryZoomed As Boolean = False
    Private editZoomed As Boolean = False
    Private confirmZoomed As Boolean = False

    Private Sub picsBox_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles picsBox.DoubleClick
        ZoomPix(Not editZoomed, pnlPicsBox, picsBox)
        editZoomed = Not editZoomed
    End Sub

    Private Sub picsBox_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picsBox.MouseDown
        If (e.Button = Windows.Forms.MouseButtons.Left) Then
            moveStartPoint = picsBox.PointToScreen(New Point(e.X, e.Y))
        End If
    End Sub

    Private Sub picsBox_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picsBox.MouseMove
        If (e.Button = Windows.Forms.MouseButtons.Left) Then
            Dim currentPoint As Point = picsBox.PointToScreen(New Point(e.X, e.Y))
            picsBox.Location = New Point(picsBox.Location.X - (moveStartPoint.X - currentPoint.X), picsBox.Location.Y - (moveStartPoint.Y - currentPoint.Y))
            moveStartPoint = currentPoint
        End If
    End Sub

    Private Sub ZoomPix(ByVal plus As Boolean, ByVal aPanel As Panel, ByRef aPix As PictureBox)
        Dim sz As New Size(aPix.Size.Width, aPix.Size.Height)
        Try
            If plus Then
                sz.Height = CInt(sz.Height + sz.Height * 0.7)
                sz.Width = CInt(sz.Width + sz.Width * 0.7)
                aPix.Size = sz
            Else
                ResizeImage(aPanel.Size, aPix)
            End If
            aPix.Location = New Point(CInt((aPanel.Width / 2) - (aPix.Width / 2)), CInt((aPanel.Height / 2) - (aPix.Height / 2)))
            aPix.Refresh()
        Catch ex As Exception
            MsgBox("ZOOM failed. " & ex.Message)
        End Try
    End Sub

    Private Sub ResizeImage(ByVal viewSize As Size, ByRef aPix As PictureBox)
        If ImageRatio(aPix.Image) >= ImageRatio(New Bitmap(viewSize.Width, viewSize.Height)) Then
            If aPix.Image.Height <= viewSize.Height Then
                aPix.Height = aPix.Image.Height - 5
                aPix.Width = aPix.Image.Width - 5
            Else
                aPix.Height = viewSize.Height - 5
                aPix.Width = viewSize.Width - 5
            End If
        Else
            If aPix.Image.Width <= viewSize.Width Then
                aPix.Width = aPix.Image.Width - 5
                aPix.Height = aPix.Image.Height - 5
            Else
                aPix.Width = viewSize.Width - 5
                aPix.Height = viewSize.Height - 5
            End If
        End If
    End Sub

    Private Function ImageRatio(ByVal img As Image) As Single
        Dim imgRatio As Single = CSng(img.Height / img.Width)
        Return imgRatio
    End Function

    Private Function CropImage(ByVal viewSize As Size, ByVal img As Image) As Image
        Dim bmpImg As New Bitmap(img)
        Dim grph As Graphics
        Dim cropRect As New Rectangle(0, 0, viewSize.Width, viewSize.Height)
        Dim cropBmp As New Bitmap(cropRect.Width, cropRect.Height, bmpImg.PixelFormat)
        Dim destRect As New Rectangle(0, 0, viewSize.Width, viewSize.Height)
        grph = Graphics.FromImage(cropBmp)
        grph.DrawImage(bmpImg, destRect, bmpImg.Width - cropRect.Width, cropRect.Y, cropRect.Width, _
                cropRect.Height, GraphicsUnit.Pixel)
        Return CType(cropBmp, Image)
    End Function

    Private Function CreateNotfoundImage(ByVal size As Size) As Image
        Dim retImage As Image
        Dim strPath As New Drawing2D.GraphicsPath
        strPath.AddString("Image Not Found", New FontFamily("Arial"), CInt(FontStyle.Italic), 24, New Point(10, 40), StringFormat.GenericDefault)
        retImage = New Bitmap(size.Width, size.Height)
        Dim grph As Graphics = Graphics.FromImage(retImage)
        grph.Clear(Color.IndianRed)
        grph.DrawPath(New Pen(Color.Black), strPath)
        Return retImage
    End Function
#End Region

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class
