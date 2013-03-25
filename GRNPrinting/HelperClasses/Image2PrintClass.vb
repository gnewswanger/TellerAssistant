Imports System.Drawing

Public Class Image2PrintClass
    Implements mvcLibrary.IObserver


    Private _imgRect As RectangleF
    Private _image2Print As Image
    Private _imageText As String

    Public ReadOnly Property PrintImage() As Image
        Get
            Return _image2Print
        End Get
    End Property

    Public ReadOnly Property PrintRectangle() As RectangleF
        Get
            Return _imgRect
        End Get
    End Property

    Public ReadOnly Property ImageCaption() As String
        Get
            Return _imageText
        End Get
    End Property

    Public Sub New(ByVal img As Image, ByVal rect As RectangleF, Optional ByVal text As String = Nothing, Optional ByVal font As Drawing.Font = Nothing)
        _image2Print = ConstructReportImageBlock(Rectangle.Round(rect), img, text, font)
        _imgRect = rect
        _imageText = text
    End Sub

    Public Function ConstructReportImageBlock(ByVal rptRect As Rectangle, ByVal img As Image, _
                                              Optional ByVal txt As String = Nothing, _
                                              Optional ByVal txtFont As Drawing.Font = Nothing) As Image
        Dim bmpImg As New Bitmap(img)
        Dim retImage As New Bitmap(rptRect.Width, rptRect.Height)
        Dim grphCanvas As Graphics = Graphics.FromImage(retImage)
        Dim imageHeight As Integer = rptRect.Height
        If txt IsNot Nothing AndAlso txtFont IsNot Nothing Then
            Dim textRect As RectangleF = GetTextRect(rptRect, txt, txtFont)
            imageHeight = CInt(rptRect.Height - textRect.Height)
            Dim stringFormat As New StringFormat
            stringFormat.Alignment = StringAlignment.Center
            textRect.Y = rptRect.Height - textRect.Height
            grphCanvas.DrawString(txt, txtFont, Brushes.Black, textRect, stringFormat)
        End If
        Dim imgRect As New RectangleF(0, 0, rptRect.Width, imageHeight)
        grphCanvas.DrawImage(CreateThumbnailImage(New Size(CInt(imgRect.Width), CInt(imgRect.Height)), bmpImg), imgRect)
        Return retImage
    End Function

    Private Function GetTextRect(ByVal rect As Rectangle, ByVal text As String, ByVal font As Drawing.Font) As RectangleF
        Dim characterRanges As CharacterRange() = {New CharacterRange(0, text.Length)}
        Dim stringFormat As New StringFormat
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.SetMeasurableCharacterRanges(characterRanges)
        Dim layoutRect As RectangleF = RectangleF.op_Implicit(rect)
        layoutRect.X = 0
        layoutRect.Y = 0
        Dim txtGrph As Graphics = Graphics.FromImage(New Bitmap(rect.Width, rect.Height))
        txtGrph.DrawString(text, font, Brushes.Black, layoutRect.X, layoutRect.Y, stringFormat)
        Dim stringRegions() As [Region] = txtGrph.MeasureCharacterRanges(text, font, layoutRect, stringFormat)
        Dim measureRect1 As RectangleF = stringRegions(0).GetBounds(txtGrph)
        Return measureRect1
    End Function

    Private Function CreateThumbnailImage(ByVal thumbSize As Size, ByVal img As Image) As Bitmap
        Dim templateBitmap As Bitmap = New Bitmap(img)
        Dim smallImage As Image = templateBitmap.GetThumbnailImage(thumbSize.Width, thumbSize.Height, Nothing, Nothing)
        Dim thumbnailBitmap As Bitmap = New Bitmap(thumbSize.Width, thumbSize.Height, Imaging.PixelFormat.Format32bppArgb)
        Dim thumbnailGraphics As Graphics = Graphics.FromImage(thumbnailBitmap)
        thumbnailGraphics.DrawImage(smallImage, 2, 2, thumbSize.Width, thumbSize.Height)
        Return thumbnailBitmap
    End Function

    Public Sub UpdateData(ByVal NewEvent As mvcLibrary.mvcEventArgsBase) Implements mvcLibrary.IObserver.UpdateData

    End Sub

End Class
