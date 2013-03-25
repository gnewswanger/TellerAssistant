Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Windows.Forms.Design

Public Class ImagePanelFlyout
    Implements mvcLibrary.IObserver

    Enum FlyOutModes
        fomAuto = -1
        fomClick = 0
    End Enum

    Enum KeypadAttachModes
        kamTop
        kamBottom
        kamLeft
        kamRight
    End Enum

    Delegate Sub SetImageCallback(ByVal value As Image)
    Delegate Sub SetTimerCallback(ByVal value As Boolean)
    Delegate Sub GenericCallback()

    Private _FlyOut As FlyOutModes = FlyOutModes.fomAuto
    Private _attachedSide As KeypadAttachModes
    Private _openedLength As Integer
    Private _isOpened As Boolean = False
    Private _moveStartPoint As Point

    <Category("Text Panel")> _
    <Description("Does the FlyOut open on MouseOver or Click")> _
    <DefaultValue(FlyOutModes.fomAuto)> _
    Public Property FlyOut() As FlyOutModes
        Get
            Return Me._FlyOut
        End Get
        Set(ByVal value As FlyOutModes)
            Me._FlyOut = value
        End Set
    End Property

    Public Property OpenedLength() As Integer
        Get
            Return Me._openedLength
        End Get
        Set(ByVal value As Integer)
            Me._openedLength = value
        End Set
    End Property

    Public Property OpenedInterval() As Integer
        Get
            Return Timer1.Interval
        End Get
        Set(ByVal value As Integer)
            Timer1.Interval = value
        End Set
    End Property

    Public Property AttachedSide() As KeypadAttachModes
        Get
            Return Me._attachedSide
        End Get
        Set(ByVal value As KeypadAttachModes)
            Me._attachedSide = value

        End Set
    End Property

    Public Property ImagePanelWidth() As Integer
        Get
            Return pnlImageFlyout1.Width
        End Get
        Set(ByVal value As Integer)
            pnlImageFlyout1.Width = value
        End Set
    End Property

    Public Property ImagePanelHeight() As Integer
        Get
            Return pnlImageFlyout1.Height
        End Get
        Set(ByVal value As Integer)
            pnlImageFlyout1.Height = value
        End Set
    End Property

    Public Property FlyOutImage() As Image
        Get
            'Return PictureBox1.Image
            Return ImageViewerPanel1.Image
        End Get
        Set(ByVal value As Image)
            If Not Me._isOpened Then
                Me.OpenImageFlyoutPanel()
            End If
            SetFlyOutImage(value)
        End Set
    End Property

    Public Sub ShowImageNotFound()
        ImageViewerPanel1.ShowImageNotFound()
    End Sub

    Private Sub SetFlyOutImage(ByVal img As Image)
        If ImageViewerPanel1.InvokeRequired Then
            ImageViewerPanel1.Invoke(New SetImageCallback(AddressOf SetFlyOutImage), img)
        Else
            ImageViewerPanel1.Image = img
            If Timer1.Enabled Then
                Timer1.Stop()
            End If
            Timer1.Enabled = Timer1.Interval > 100
        End If

    End Sub

    Private Sub ImagePanelFlyout_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AutoFlyoutToolStripMenuItem.Checked = Me._FlyOut = FlyOutModes.fomAuto

    End Sub

    Private Sub OpenImageFlyoutPanel()
        If pnlPictureContainer.InvokeRequired Then
            pnlPictureContainer.Invoke(New GenericCallback(AddressOf OpenImageFlyoutPanel))
        Else
            pnlPictureContainer.Visible = True
            Select Case Me._attachedSide
                Case KeypadAttachModes.kamTop, KeypadAttachModes.kamBottom
                    pnlImageFlyout1.Height = OpenedLength
                    Me._isOpened = True
                Case KeypadAttachModes.kamLeft, KeypadAttachModes.kamRight
                    pnlImageFlyout1.Width = OpenedLength
                    Me._isOpened = True
            End Select
            pnlPictureContainer.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
        End If
    End Sub

    Private Sub CloseImageFlyoutPanel()
        If pnlPictureContainer.InvokeRequired Then
            pnlPictureContainer.Invoke(New GenericCallback(AddressOf CloseImageFlyoutPanel))
        Else
            Select Case Me._attachedSide
                Case KeypadAttachModes.kamTop, KeypadAttachModes.kamBottom
                    pnlImageFlyout1.Height = 6
                    Me._isOpened = False
                Case KeypadAttachModes.kamLeft, KeypadAttachModes.kamRight
                    pnlImageFlyout1.Width = 6
                    Me._isOpened = False
            End Select
            pnlPictureContainer.Visible = False
            pnlImageFlyout1.BorderStyle = Windows.Forms.BorderStyle.None
        End If
    End Sub

    Private Sub pnlImageFlyout1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlImageFlyout1.Click
        If Me._FlyOut = FlyOutModes.fomClick And Me._isOpened = False Then
            OpenImageFlyoutPanel()
        End If
    End Sub

    Private Sub pnlImageFlyout1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlImageFlyout1.MouseHover
        If Me._FlyOut = FlyOutModes.fomAuto And Me._isOpened = False Then
            OpenImageFlyoutPanel()
        End If
    End Sub

    Private Sub PictureBox1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me._FlyOut = FlyOutModes.fomAuto And Me._isOpened = True Then
            CloseImageFlyoutPanel()
        End If
    End Sub

    Private Sub AutoFlyoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoFlyoutToolStripMenuItem.Click
        If AutoFlyoutToolStripMenuItem.Checked Then
            Me._FlyOut = FlyOutModes.fomAuto
        Else
            Me._FlyOut = FlyOutModes.fomClick
        End If
    End Sub

    Private Sub btnTextFlyoutClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTextFlyoutClose.Click
        CloseImageFlyoutPanel()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        CloseImageFlyoutPanel()
        Timer1.Enabled = False
    End Sub

    Private Sub pnlImageFlyout1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlImageFlyout1.Paint
        If Not Me._isOpened Then
            Dim l, w As Integer
            Dim pts() As Point
            Dim linMode As LinearGradientMode
            Select Case Me._attachedSide
                Case KeypadAttachModes.kamTop
                    l = pnlImageFlyout1.Width
                    w = pnlImageFlyout1.Height
                    linMode = LinearGradientMode.Vertical
                    pts = New Point() { _
                        New Point(CInt((l / 2) - 5), 0), _
                        New Point(CInt((l / 2)), 5), _
                        New Point(CInt((l / 2) + 6), 0)}
                Case KeypadAttachModes.kamBottom
                    l = pnlImageFlyout1.Width
                    w = pnlImageFlyout1.Height
                    linMode = LinearGradientMode.Vertical
                    pts = New Point() { _
                        New Point(CInt((l / 2) - 5), 5), _
                        New Point(CInt((l / 2)), 0), _
                        New Point(CInt((l / 2) + 6), 5)}
                Case KeypadAttachModes.kamLeft
                    l = pnlImageFlyout1.Height
                    w = pnlImageFlyout1.Width
                    linMode = LinearGradientMode.Horizontal
                    pts = New Point() { _
                        New Point(0, CInt((l / 2) - 5)), _
                        New Point(5, CInt((l / 2))), _
                        New Point(0, CInt((l / 2) + 6))}
                Case Else
                    l = pnlImageFlyout1.Height
                    w = pnlImageFlyout1.Width
                    linMode = LinearGradientMode.Horizontal
                    pts = New Point() { _
                        New Point(5, CInt((l / 2) - 5)), _
                        New Point(0, CInt((l / 2))), _
                        New Point(5, CInt((l / 2) + 6))}
            End Select
            Dim g As Graphics = pnlImageFlyout1.CreateGraphics
            g.SmoothingMode = SmoothingMode.AntiAlias
            Dim gp As New GraphicsPath
            Dim rect As Rectangle = New Rectangle(0, 0, pnlImageFlyout1.Width, pnlImageFlyout1.Height)
            Using lgbr As LinearGradientBrush = New LinearGradientBrush(rect, Color.DarkGray, Color.Transparent, linMode)
                g.FillRectangle(lgbr, rect)
            End Using

            g.FillPolygon(Brushes.White, pts)
            g.DrawPolygon(Pens.DarkBlue, pts)
            g.Dispose()
            gp.Dispose()
        End If
    End Sub

    '#Region "Check Picturebox Methods"

    '    Private Sub Zoom(ByVal plus As Boolean, ByVal e As System.EventArgs)
    '        Dim sz As New Size(PictureBox1.Size.Width, PictureBox1.Size.Height)
    '        Try
    '            If plus Then
    '                sz.Height += sz.Height * 0.7
    '                sz.Width += sz.Width * 0.7
    '            Else
    '                sz.Height = pnlPictureContainer.Height
    '                sz.Width = pnlPictureContainer.Width
    '            End If
    '            PictureBox1.Size = sz
    '            PictureBox1.Location = New Point(pnlPictureContainer.Width - PictureBox1.Width, (pnlPictureContainer.Height - PictureBox1.Height) / 2)
    '            PictureBox1.Refresh()
    '         Catch ex As Exception
    '            MsgBox("frmMain.ZOOM failed. " & ex.Message)
    '        End Try
    '    End Sub

    '    Private Sub PictureBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '        If (e.Button = Windows.Forms.MouseButtons.Left) Then
    '            moveStartPoint = PictureBox1.PointToScreen(New Point(e.X, e.Y))
    '        End If
    '    End Sub

    '    Private Sub PictureBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '        If (e.Button = Windows.Forms.MouseButtons.Left) Then
    '            Dim currentPoint As Point = PictureBox1.PointToScreen(New Point(e.X, e.Y))
    '            PictureBox1.Location = New Point(PictureBox1.Location.X - (moveStartPoint.X - currentPoint.X), PictureBox1.Location.Y - (moveStartPoint.Y - currentPoint.Y))
    '            moveStartPoint = currentPoint
    '        End If

    '    End Sub

    '    Private Function ResizeImage(ByVal viewSize As Size, ByVal img As Image) As Image
    '        Select Case Me._attachedSide
    '            Case SideAttached.saTop, SideAttached.saBottom
    '                viewSize.Height = OpenedLength
    '            Case SideAttached.saLeft, SideAttached.saRight
    '                viewSize.Width = OpenedLength
    '        End Select
    '        Dim imgRatio As Single = img.Width \ img.Height
    '        Dim hScale As Single = viewSize.Height / img.Height
    '        Dim bmpSrc As New Bitmap(img)
    '        Dim bmpDest As Bitmap
    '        bmpDest = New Bitmap(CInt(bmpSrc.Width * hScale), CInt(bmpSrc.Height * hScale))
    '        Dim grph As Graphics = Graphics.FromImage(bmpDest)
    '        grph.DrawImage(bmpSrc, 0, 0, bmpDest.Width + 1, bmpDest.Height + 1)
    '        Return CType(bmpDest, Image)
    '    End Function

    '    Private Function CropImage(ByVal viewSize As Size, ByVal img As Image) As Image
    '        Dim bmpImg As New Bitmap(img)
    '        Dim grph As Graphics
    '        Dim cropRect As New Rectangle(0, 0, viewSize.Width, viewSize.Height)
    '        Dim cropBmp As New Bitmap(cropRect.Width, cropRect.Height, bmpImg.PixelFormat)
    '        Dim destRect As New Rectangle(0, 0, viewSize.Width, viewSize.Height)
    '        grph = Graphics.FromImage(cropBmp)
    '        grph.DrawImage(bmpImg, destRect, bmpImg.Width - cropRect.Width, cropRect.Y, cropRect.Width, _
    '                cropRect.Height, GraphicsUnit.Pixel)
    '        Return CType(cropBmp, Image)
    '    End Function


    '#End Region

#Region "Observer Method"
    Public Sub UpdateData(ByVal NewEvent As mvcLibrary.mvcEventArgsBase) Implements mvcLibrary.IObserver.UpdateData

    End Sub
#End Region


End Class
