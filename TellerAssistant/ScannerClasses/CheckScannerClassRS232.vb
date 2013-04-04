Imports System.IO.Ports
Imports System.Media
Imports System.Xml
Imports System.Security.Principal
Imports System.IO

Public Class CheckScannerClassRS232
    Inherits mvcLibrary.mvcAbstractModel
    Implements ICheckScanner

    Private Shared Instance As CheckScannerClassRS232
    Private _currImageDir As String = String.Empty
    Private _currImageFilename As String = String.Empty
    Friend WithEvents SerialPort1 As New System.IO.Ports.SerialPort

    Private _transferMode As ReceiveDataMode = ReceiveDataMode.TextComing
    Private _bytesReceived As Integer
    Private _imageLength As Integer
    Private _imageBuffer() As Byte
    Private _fs As IO.FileStream
    Private _delay As Integer = My.Settings.ImageTransferDelayRS232

#Region "Class Properties and Baseclass Implementation"

    Public Overrides Sub UpdateData(ByVal NewEvent As mvcLibrary.mvcEventArgsBase)

    End Sub

    Public ReadOnly Property Connected() As Boolean Implements ICheckScanner.Connected
        Get
            Return Me.SerialPort1.IsOpen
        End Get
    End Property

    Public ReadOnly Property ConnectionMode() As ConnectionType Implements ICheckScanner.ConnectionMode
        Get
            Return ConnectionType.ctRS232
        End Get
    End Property

    'Public Property ImageDirectory() As String
    '    Get
    '        Return Me._currImageDir
    '    End Get
    '    Set(ByVal value As String)
    '        Me._currImageDir = value
    '    End Set
    'End Property

    Public WriteOnly Property ResetScanner() As Boolean Implements ICheckScanner.ResetScanner
        Set(ByVal value As Boolean)
            If value = True AndAlso SerialPort1.IsOpen Then
                Me.SerialPort1.WriteLine("RS" + vbCrLf)
            End If
        End Set
    End Property

    Public Property DelayInterval() As Integer Implements ICheckScanner.DelayInterval
        Get
            Return Me._delay
        End Get
        Set(ByVal value As Integer)
            Me._delay = value
            My.Settings.ImageTransferDelayRS232 = value
        End Set
    End Property

    Public Sub Close() Implements ICheckScanner.Close
        Me.SerialPort1.Close()
        Me.NotifyObservers(Me, New StatusEventArgs(EventName.evnmScannerStatusChanged, ConnectionType.ctNone, "MICR Not Attached" + vbCr))
    End Sub

    Public WriteOnly Property EnableScanner() As Boolean Implements ICheckScanner.EnableScanner
        Set(ByVal value As Boolean)
            If Me.SerialPort1.IsOpen Then
                If value = True Then
                    Me.SerialPort1.WriteLine("EM" + vbCrLf)
                    Me.NotifyObservers(Me, New StatusEventArgs(EventName.evnmScannerEnableChanged, ConnectionType.ctRS232, CStr(ScannerStatus.ssScanEnabled)))
                Else
                    Me.SerialPort1.WriteLine("DM" + vbCrLf)
                    Me.NotifyObservers(Me, New StatusEventArgs(EventName.evnmScannerEnableChanged, ConnectionType.ctRS232, CStr(ScannerStatus.ssScanDisabled)))
                End If
            End If
        End Set
    End Property

#End Region

#Region "Class Constructors and Initialization"

    Protected Sub New(ByVal sender As Object)
        MyBase.New()
        Me.AttachObserver(CType(sender, mvcLibrary.IObserver))
        Me.NotifyObservers(Me, New StatusEventArgs(EventName.evnmScannerStatusChanged, ConnectionType.ctRS232, "MICR Attaching..."))
        Dim wid As WindowsIdentity = WindowsIdentity.GetCurrent
        MainModule.WriteToErrorLog("WindowsIdentity", "CheckScannerClassRS232.vb", "WID name", wid.Name & ": " & wid.IsAuthenticated)
    End Sub

    Public Sub New(ByVal sender As Object, ByVal path As String)
        MyBase.New()
        Me.AttachObserver(CType(sender, mvcLibrary.IObserver))
        'Dim wid As WindowsIdentity = WindowsIdentity.GetCurrent
        'MainModule.WriteToErrorLog("WindowsIdentity", "CheckScannerClassRS232.vb", "WID name", wid.Name & ": " & wid.IsAuthenticated)
        Me._currImageDir = path
        Me.Initialize()
    End Sub

    Friend Shared Function getInstance(ByVal sender As Object, ByVal path As String) As CheckScannerClassRS232
        If Instance Is Nothing Then
            Instance = New CheckScannerClassRS232(sender)
        Else
            Instance.ResetScanner = True
        End If
        Instance._currImageDir = path
        Instance.Initialize()
        Return Instance
    End Function

    Private Sub Initialize()
        If PortOpen() Then
            Me.AttachDevice()
        End If
    End Sub

    Private Sub GetPortSettings()
        Me.SerialPort1.PortName = My.Settings.PortSettingPortName
        Me.SerialPort1.BaudRate = My.Settings.PortSettingBaudRate
        Me.SerialPort1.Parity = CType([Enum].Parse(GetType(Parity), My.Settings.PortSettingParity), Parity)
        Me.SerialPort1.DataBits = My.Settings.PortSettingDataBits
        Me.SerialPort1.StopBits = CType(My.Settings.PortSettingStopBits, StopBits)
        Me.SerialPort1.Handshake = Handshake.None
        Me.SerialPort1.DtrEnable = False
        Me.SerialPort1.RtsEnable = False
        Me.SerialPort1.ReadBufferSize = 8192
        'Me.SerialPort1.Dispose()
        Me.SerialPort1.ReadTimeout = 6000
        Me.SerialPort1.WriteTimeout = 6000
    End Sub

    Private Function PortOpen() As Boolean
        If Me.SerialPort1.IsOpen Then
            Me.SerialPort1.Close()
            System.Threading.Thread.Sleep(500)
        End If
        GetPortSettings()
        Me.SerialPort1.Open()
        If Me.SerialPort1.IsOpen Then
            'Me.NotifyObservers(Me, New StatusEventArgs(EventName.evnmScannerStatusChanged, ConnectionType.ctRS232, "MICR Attached"))
            Return True
        Else
            Me.NotifyObservers(Me, New StatusEventArgs(EventName.evnmScannerStatusChanged, ConnectionType.ctNone, "MICR Not Attached"))
            Return False
        End If
    End Function

    Private Sub AttachDevice()
        If My.Settings.InitializeScannerSettingsAtStartup Then
            Dim xmlSettinngs As MICRScannerSettings = New MICRScannerSettings
            AddHandler MICRScannerSettings.SendScannerCommand, AddressOf SendCommandToScanner
            'xmlSettinngs.SetupMICRImmageSwitches()
            xmlSettinngs.GetScannerSwitchSettings()
            'xmlSettinngs.SetupMICRImmageProperties()
            xmlSettinngs.GetScannerPropertiesSettings()
            My.Settings.InitializeScannerSettingsAtStartup = False
            'RemoveHandler MICRScannerSettings.SendScannerCommand, AddressOf SendCommandToScanner
        End If
        Me.SendCommandToScanner(Me, "VR")
    End Sub

#End Region

    Private Sub SendCommandToScanner(ByVal sender As Object, ByVal cmd As String)
        If My.Settings.LogScannerCmds Then
            MainModule.WriteToErrorLog("ScannerCommand", "SendCommandToScanner", cmd.Trim(CChar(vbCrLf)), "CheckScannerClassRS232vb")
        End If
        Me.SerialPort1.WriteLine(cmd.Trim & vbCrLf)
    End Sub

    Public Sub TransmitImage(ByVal value As String) Implements ICheckScanner.TransmitImage
        If Not My.Computer.FileSystem.DirectoryExists(Me._currImageDir) Then
            My.Computer.FileSystem.CreateDirectory(Me._currImageDir)
        End If
        Me._currImageFilename = value
        Me._bytesReceived = 0
        Me.RequestImageSize()
    End Sub

    Private Sub RequestImageSize()
        Me._transferMode = ReceiveDataMode.SizeComing
        Me.SerialPort1.ReceivedBytesThreshold = 1
        Me.SerialPort1.Write("IS" & vbCrLf)
    End Sub

    Private Async Sub ImageToFileAsync(buffer() As Byte, imageFileName As String, imageSize As Integer)
        Me._fs = New IO.FileStream(Me._currImageDir + imageFileName, IO.FileMode.Create, IO.FileAccess.Write)
        Await Me._fs.WriteAsync(buffer, 0, (imageSize))
        Me._fs.Close()
        Dim player As New SoundPlayer(My.Resources.AutoAlert)
        player.Play()
        Me.NotifyObservers(Me, New StatusEventArgs(EventName.evnmScannedImageTransmitted, ConnectionType.ctRS232, imageFileName, New MemoryStream(buffer)))
        Me.EnableScanner = True 'Me.SerialPort1.WriteLine("EM" + vbCr)
    End Sub

    Private Sub SerialPort1_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        If Me._transferMode = ReceiveDataMode.ImageComing Then
            System.Threading.Thread.Sleep(Me._delay)
            While SerialPort1.BytesToRead > 0
                Me._bytesReceived += Me.SerialPort1.Read(Me._imageBuffer, Me._bytesReceived, Me.SerialPort1.BytesToRead)
            End While

            If Me._bytesReceived < Me._imageLength Then
                Me._transferMode = ReceiveDataMode.ImageComing
            Else
                Me._transferMode = ReceiveDataMode.TextComing
                Me.SerialPort1.ReceivedBytesThreshold = 1
                Me.ImageToFileAsync(Me._imageBuffer, Me._currImageFilename, Me._bytesReceived)
            End If

        ElseIf Me._transferMode = ReceiveDataMode.SizeComing Then
            System.Threading.Thread.Sleep(Me._delay)
            Dim Recvd As String = Me.SerialPort1.ReadExisting
            If Recvd = "" Then
                System.Threading.Thread.Sleep(Me._delay * 3)
                Recvd = Me.SerialPort1.ReadExisting()
            End If
            Dim strs() As String = Recvd.Split(CChar(","))
            If strs.Count < 3 OrElse strs(1) = "" Then
                Dim player As New SoundPlayer(My.Resources.NOTIFY)
                player.Play()
                MsgBox("Scanner failed to read last check, " + Me._currImageFilename + ". Please rescan.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                Me._imageLength = CInt(strs(1))
                Me._transferMode = ReceiveDataMode.ImageComing
                Me.SerialPort1.ReceivedBytesThreshold = Me._imageLength
                ReDim Me._imageBuffer(Me._imageLength + 1)
                MainModule.WriteToErrorLog("CheckScannerClassRS232.vb", "Scanner Status", "Calling TI again", Recvd.Replace(",", "-").Trim(CChar(vbCrLf)))
                Me.SerialPort1.Write("TI" & vbCrLf)
            End If
        Else
            Dim Recvd As String = Me.SerialPort1.ReadExisting
            If Recvd.StartsWith("T") Then
                Me.EnableScanner = False
                System.Threading.Thread.Sleep(Me._delay)
                Recvd += Me.SerialPort1.ReadExisting
                Me._currImageFilename = Recvd.Trim + ".tif"
                Me.NotifyObservers(Me, New StatusEventArgs(EventName.evnmScannedImageReady, ConnectionType.ctRS232, Recvd.Trim))
            ElseIf Recvd.LastIndexOf("OK") > -1 Then
                Dim player As New SoundPlayer(My.Resources.AutoAlert)
                player.Play()
                Me.EnableScanner = True 'Me.SerialPort1.WriteLine("EM" + vbCr)
                Me.NotifyObservers(Me, New StatusEventArgs(EventName.evnmScannerStatusChanged, ConnectionType.ctRS232, Recvd.Trim))
            ElseIf Recvd.StartsWith("?") Then
                MsgBox("Scanner Command was not recognized!")
                Me.NotifyObservers(Me, New StatusEventArgs(EventName.evnmScannerStatusChanged, ConnectionType.ctRS232, Recvd.Trim))
                MainModule.WriteToErrorLog("CheckScannerClassRS232.vb", "Scanner Status", "Scanner Command was not recognized!", Recvd.Replace(",", "-").Trim(CChar(vbCrLf)))
            Else
                If Not Recvd = "" Then
                    Me.NotifyObservers(Me, New StatusEventArgs(EventName.evnmScannerStatusChanged, ConnectionType.ctRS232, Recvd))
                End If
                'MainModule.WriteToErrorLog("CheckScannerClassRS232.vb", "Scanner Status", "last else", Recvd.Trim(vbCrLf))
            End If
        End If
    End Sub

End Class
