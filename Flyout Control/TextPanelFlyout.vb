Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Windows.Forms.Design

Public Class TextPanelFlyout
    Implements mvcLibrary.IObserver

    Enum eFlyOut
        Auto = -1
        Click = 0
    End Enum

    Enum SideAttached
        saTop
        saBottom
        saLeft
        saRight
    End Enum

    Delegate Sub SetTextCallback(ByVal text As String)
    Private _FlyOut As eFlyOut = eFlyOut.Auto
    Private _attachedSide As SideAttached
    Private _OpenedLength As Integer
    Private _isOpened As Boolean = False

    <Category("Text Panel")> _
    <Description("Does the FlyOut open on MouseOver or Click")> _
    <DefaultValue(eFlyOut.Auto)> _
    Public Property FlyOut() As eFlyOut
        Get
            Return _FlyOut
        End Get
        Set(ByVal value As eFlyOut)
            _FlyOut = value
        End Set
    End Property

    Public Property TextFlyoutText() As String
        Get
            Return txtTextFlyout.Text
        End Get
        Set(ByVal value As String)
            SetTextFlyoutText(value)
        End Set
    End Property

    Public Property OpenedLength() As Integer
        Get
            Return _OpenedLength
        End Get
        Set(ByVal value As Integer)
            _OpenedLength = value
        End Set
    End Property

    Public Property AttachedSide() As SideAttached
        Get
            Return _attachedSide
        End Get
        Set(ByVal value As SideAttached)
            _attachedSide = value

        End Set
    End Property

    Public Property TextPanelWidth() As Integer
        Get
            Return pnlTextFlyout1.Width
        End Get
        Set(ByVal value As Integer)
            pnlTextFlyout1.Width = value
        End Set
    End Property

    Public Property TextPanelHeight() As Integer
        Get
            Return pnlTextFlyout1.Height
        End Get
        Set(ByVal value As Integer)
            pnlTextFlyout1.Height = value
        End Set
    End Property

    Private Sub AutoFlyoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoFlyoutToolStripMenuItem.Click
        If AutoFlyoutToolStripMenuItem.Checked Then
            Me._FlyOut = eFlyOut.Auto
        Else
            Me._FlyOut = eFlyOut.Click
        End If

    End Sub

    Private Sub OpenTextFlyoutPanel()
        pnlTextFlyout2.Visible = True
        Select Case _attachedSide
            Case SideAttached.saTop, SideAttached.saBottom
                pnlTextFlyout1.Height = OpenedLength
                _isOpened = True
            Case SideAttached.saLeft, SideAttached.saRight
                pnlTextFlyout1.Width = OpenedLength
                _isOpened = True
        End Select
        pnlTextFlyout1.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
    End Sub

    Private Sub CloseTextFlyoutPanel()
        Select Case _attachedSide
            Case SideAttached.saTop, SideAttached.saBottom
                pnlTextFlyout1.Height = 6
                _isOpened = False
            Case SideAttached.saLeft, SideAttached.saRight
                pnlTextFlyout1.Width = 6
                _isOpened = False
        End Select
        pnlTextFlyout2.Visible = False
        pnlTextFlyout1.BorderStyle = Windows.Forms.BorderStyle.None

    End Sub

    Private Sub TextPanelFlyout_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AutoFlyoutToolStripMenuItem.Checked = Me._FlyOut = eFlyOut.Auto
    End Sub

    Private Sub pnlTextFlyout1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlTextFlyout1.Click
        If _FlyOut = eFlyOut.Click And _isOpened = False Then
            OpenTextFlyoutPanel()
        End If
    End Sub

    Private Sub pnlTextFlyout1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlTextFlyout1.MouseHover
        If _FlyOut = eFlyOut.Auto And _isOpened = False Then
            OpenTextFlyoutPanel()
        End If

    End Sub

    Private Sub btnTextFlyoutClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTextFlyoutClose.Click
        CloseTextFlyoutPanel()
    End Sub

    Private Sub txtTextFlyout_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTextFlyout.MouseLeave
        If _FlyOut = eFlyOut.Auto And _isOpened = True Then
            CloseTextFlyoutPanel()
        End If
    End Sub

    Private Sub pnlTextFlyout1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlTextFlyout1.Paint
        If Not _isOpened Then
            Dim l, w As Integer
            Dim pts() As Point
            Dim linMode As LinearGradientMode
            Select Case _attachedSide
                Case SideAttached.saTop
                    l = pnlTextFlyout1.Width
                    w = pnlTextFlyout1.Height
                    linMode = LinearGradientMode.Vertical
                    pts = New Point() { _
                        New Point(CInt((l / 2) - 5), 0), _
                        New Point(CInt((l / 2)), 5), _
                        New Point(CInt((l / 2) + 6), 0)}
                Case SideAttached.saBottom
                    l = pnlTextFlyout1.Width
                    w = pnlTextFlyout1.Height
                    linMode = LinearGradientMode.Vertical
                    pts = New Point() { _
                        New Point(CInt((l / 2) - 5), 5), _
                        New Point(CInt((l / 2)), 0), _
                        New Point(CInt((l / 2) + 6), 5)}
                Case SideAttached.saLeft
                    l = pnlTextFlyout1.Height
                    w = pnlTextFlyout1.Width
                    linMode = LinearGradientMode.Horizontal
                    pts = New Point() { _
                        New Point(0, CInt((l / 2) - 5)), _
                        New Point(5, CInt((l / 2))), _
                        New Point(0, CInt((l / 2) + 6))}
                Case Else
                    l = pnlTextFlyout1.Height
                    w = pnlTextFlyout1.Width
                    linMode = LinearGradientMode.Horizontal
                    pts = New Point() { _
                        New Point(5, CInt((l / 2) - 5)), _
                        New Point(0, CInt((l / 2))), _
                        New Point(5, CInt((l / 2) + 6))}
            End Select
            Dim g As Graphics = pnlTextFlyout1.CreateGraphics
            g.SmoothingMode = SmoothingMode.AntiAlias
            Dim gp As New GraphicsPath
            Dim rect As Rectangle = New Rectangle(0, 0, pnlTextFlyout1.Width, pnlTextFlyout1.Height)
            Using lgbr As LinearGradientBrush = New LinearGradientBrush(rect, Color.DarkGray, Color.Transparent, linMode)
                g.FillRectangle(lgbr, rect)
            End Using
            
            g.FillPolygon(Brushes.White, pts)
            g.DrawPolygon(Pens.DarkBlue, pts)
            g.Dispose()
            gp.Dispose()
        End If
    End Sub

    Private Sub SetTextFlyoutText(ByVal text As String)
        If txtTextFlyout.InvokeRequired Then
            '*** switch over to primary UI thread
            Dim handler As New SetTextCallback(AddressOf SetTextFlyoutText)
            Me.BeginInvoke(handler, text)
        Else
            '*** direct call - already running on primary UI thread
            txtTextFlyout.Text += text
        End If

    End Sub

    Public Sub UpdateData(ByVal NewEvent As mvcLibrary.mvcEventArgsBase) Implements mvcLibrary.IObserver.UpdateData

    End Sub
End Class
