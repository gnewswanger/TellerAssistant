Imports System.Net
Imports System.Net.Sockets
Imports System.ComponentModel
Imports System.Media
Imports System.Xml

Public Class CheckScannerClassFTP
    Inherits mvcLibrary.mvcAbstractModel
    Implements ICheckScanner

    Private clientSocket As Socket
    Private ascii As New System.Text.ASCIIEncoding
    Private Shared instance As CheckScannerClassFTP
    Private MICRAddr As String = My.Settings.ScannerIP
    'Private currImageDir As String = String.Empty
    Private currImageFilename As String = String.Empty
    Private transmittingImage As Boolean = False
    Private delay As Integer = My.Settings.ImageTransferDelayFTP

#Region "Class Properties and Baseclass Implementation"

    Public ReadOnly Property Connected() As Boolean Implements ICheckScanner.Connected
        Get
            Return clientSocket.Connected
        End Get
    End Property

    Public ReadOnly Property ConnectionMode() As ConnectionType Implements ICheckScanner.ConnectionMode
        Get
            Return ConnectionType.ctFTP
        End Get
    End Property

    Public WriteOnly Property ResetScanner() As Boolean Implements ICheckScanner.ResetScanner
        Set(ByVal value As Boolean)
            If value = True Then
                Reset()
            End If
        End Set
    End Property

    Public Sub TransmitImage(ByVal value As String) Implements ICheckScanner.TransmitImage
        Try
            Dim bytes() As Byte
            currImageFilename = value
            Dim str As String = "TI N " & currImageFilename & vbCr
            bytes = ascii.GetBytes(str)
            transmittingImage = True
            clientSocket.Send(bytes)
            'Threading.Thread.Sleep(delay)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public WriteOnly Property EnableScanner() As Boolean Implements ICheckScanner.EnableScanner
        Set(ByVal value As Boolean)
            If value = True Then
                clientSocket.Send(ascii.GetBytes("EM" + vbCr))
                NotifyObservers(Me, New StatusEventArgs(EventName.evnmScannerEnableChanged, ConnectionType.ctFTP, ScannerStatus.ssScanEnabled.ToString))
            Else
                clientSocket.Send(ascii.GetBytes("DM" + vbCr))
                NotifyObservers(Me, New StatusEventArgs(EventName.evnmScannerEnableChanged, ConnectionType.ctFTP, ScannerStatus.ssScanDisabled.ToString))
            End If
        End Set
    End Property

    Public Property DelayInterval() As Integer Implements ICheckScanner.DelayInterval
        Get
            Return delay
        End Get
        Set(ByVal value As Integer)
            delay = value
            My.Settings.ImageTransferDelayFTP = value
        End Set
    End Property

    Public Sub Close() Implements ICheckScanner.Close
        clientSocket.Disconnect(True)
        NotifyObservers(Me, New StatusEventArgs(EventName.evnmScannerStatusChanged, ConnectionType.ctNone, "MICR Not Attached"))
    End Sub

    Public Overrides Sub UpdateData(ByVal NewEvent As mvcLibrary.mvcEventArgsBase)

    End Sub

#End Region


    'Friend Shared Function getInstance(ByVal sender As Object, ByVal path As String) As CheckScannerClassFTP
    Friend Shared Function getInstance(ByVal sender As Object) As CheckScannerClassFTP
        If instance Is Nothing Then
            instance = New CheckScannerClassFTP(sender)
            Return instance
        Else
            instance.AttachDevice()
            'instance.ImageDirectory = path
            instance.Reset()
            Return instance
        End If
    End Function

    Public Sub New(ByVal sender As Object) ', ByVal imageDir As String)
        MyBase.New()
        AttachObserver(CType(sender, mvcLibrary.IObserver))
        AttachDevice()
        'ImageDirectory = imageDir
    End Sub

    Public Sub AttachDevice()
        Dim addr As IPAddress = IPAddress.Parse(MICRAddr)
        'Dns.GetHostEntry(MICRAddr).AddressList(0)
        If Not addr Is Nothing Then
            Dim ep As New IPEndPoint(addr, 23)
            clientSocket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            clientSocket.BeginConnect(ep, AddressOf ConnectCallback, Nothing)
            Threading.Thread.Sleep(500)
            If Not clientSocket.Connected Then
                NotifyObservers(Me, New StatusEventArgs(EventName.evnmScannerStatusChanged, ConnectionType.ctNone, "MICR Not Attached"))
            End If
        End If
    End Sub

    Private Sub ConnectCallback(ByVal ar As IAsyncResult)
        If clientSocket.Connected Then
            clientSocket.EndConnect(ar)
            NotifyObservers(Me, New StatusEventArgs(EventName.evnmScannerStatusChanged, ConnectionType.ctFTP, "MICR Connected"))
            Dim bytes(8192) As Byte
            clientSocket.BeginReceive(bytes, 0, bytes.Length, SocketFlags.None, AddressOf ReceivedCallback, bytes)
        Else
            clientSocket.Close()
            NotifyObservers(Me, New StatusEventArgs(EventName.evnmScannerStatusChanged, ConnectionType.ctNone, "MICR Not Attached"))
        End If
    End Sub

    Private Sub ReceivedCallback(ByVal ar As IAsyncResult)
        Dim bytes() As Byte = CType(ar.AsyncState, Byte())
        If clientSocket.Connected AndAlso bytes(0) <> 0 Then
            EnableScanner = False 'clientSocket.Send(ascii.GetBytes("DM" + vbCr))
            Dim numBytes As Int32 = clientSocket.EndReceive(ar)
            Dim Recvd As String = ascii.GetString(bytes, 0, numBytes)
            If Recvd.StartsWith("T") Then
                currImageFilename = Recvd.Trim + ".tif"
                NotifyObservers(Me, New StatusEventArgs(EventName.evnmScannedImageReady, ConnectionType.ctFTP, currImageFilename))
                NotifyObservers(Me, New StatusEventArgs(EventName.evnmScannerStatusChanged, ConnectionType.ctFTP, Recvd.Trim))
            ElseIf Recvd.LastIndexOf("MICRImage Telnet Connection") > -1 Then
                If My.Settings.InitializeScannerSettingsAtStartup Then
                    Dim xmlSettinngs As New MICRScannerSettings
                    AddHandler MICRScannerSettings.SendScannerCommand, AddressOf SendCommandToScanner
                    'xmlSettinngs.SetupMICRImmageSwitches()
                    xmlSettinngs.GetScannerSwitchSettings()
                    'xmlSettinngs.SetupMICRImmageProperties()
                    xmlSettinngs.GetScannerPropertiesSettings()
                    My.Settings.InitializeScannerSettingsAtStartup = False
                    'RemoveHandler MICRScannerSettings.SendScannerCommand, AddressOf SendCommandToScanner
                End If
                EnableScanner = True
                'ImageDirectory = currImageDir
                NotifyObservers(Me, New StatusEventArgs(EventName.evnmScannerStatusChanged, ConnectionType.ctFTP, Recvd.Trim))
            ElseIf Recvd.LastIndexOf("OK") > -1 AndAlso transmittingImage Then
                Threading.Thread.Sleep(delay)
                NotifyObservers(Me, New StatusEventArgs(EventName.evnmScannedImageTransmitted, ConnectionType.ctFTP, currImageFilename))
                transmittingImage = False
                Dim player As New SoundPlayer(My.Resources.AutoAlert)
                player.Play()
                NotifyObservers(Me, New StatusEventArgs(EventName.evnmScannerStatusChanged, ConnectionType.ctFTP, Recvd.Trim))
                EnableScanner = True
            ElseIf Recvd.StartsWith("?") Then
                MsgBox("Command was not recognized!")
                EnableScanner = True
                NotifyObservers(Me, New StatusEventArgs(EventName.evnmScannedImageReady, ConnectionType.ctFTP, currImageFilename))
                NotifyObservers(Me, New StatusEventArgs(EventName.evnmScannerStatusChanged, ConnectionType.ctFTP, Recvd.Trim))
            ElseIf Recvd.LastIndexOf("NO MICR") > -1 Then

            Else
                NotifyObservers(Me, New StatusEventArgs(EventName.evnmScannerStatusChanged, ConnectionType.ctFTP, Recvd.Trim))
                'transmittingImage = False
            End If
            Array.Clear(bytes, 0, numBytes)
            clientSocket.BeginReceive(bytes, 0, bytes.Length, SocketFlags.None, AddressOf ReceivedCallback, bytes)
        Else
            'MsgBox("Client socket not connected>")
        End If
    End Sub

#Region "Port & MICR Settings"

    Private Sub SendCommandToScanner(ByVal sender As Object, ByVal cmd As String)
        Dim bytes() As Byte = ascii.GetBytes(cmd & vbCrLf)
        clientSocket.Send(bytes)
    End Sub


    'Private Sub SetupMICRImmageSwitches()
    '    'Dim setupStr As String = _
    '    '"SWA " & ReadSettingFromXml("/TellerAssistant/SwitchSettingsFTP/SwitchSetting[@name='SWA']") & vbCr _
    '    '& "SWB " & ReadSettingFromXml("/TellerAssistant/SwitchSettingsFTP/SwitchSetting[@name='SWB']") & vbCr _
    '    '& "SWC " & ReadSettingFromXml("/TellerAssistant/SwitchSettingsFTP/SwitchSetting[@name='SWC']") & vbCr _
    '    '& "SWE " & ReadSettingFromXml("/TellerAssistant/SwitchSettingsFTP/SwitchSetting[@name='SWE']") & vbCr _
    '    '& "SWI " & ReadSettingFromXml("/TellerAssistant/SwitchSettingsFTP/SwitchSetting[@name='SWI']") & vbCr _
    '    '& "HW " & ReadSettingFromXml("/TellerAssistant/SwitchSettingsFTP/SwitchSetting[@name='HW']") & vbCr _
    '    '& "FC" & ReadSettingFromXml("/TellerAssistant/SwitchSettingsFTP/SwitchSetting[@name='FC']") & vbCr _
    '    '& "SA" & vbCr
    '    'Dim bytes() As Byte = ascii.GetBytes(setupStr)
    '    'clientSocket.Send(bytes)
    'End Sub

    Private Sub Reset()
        If clientSocket.Connected Then
            Try
                clientSocket.Send(ascii.GetBytes("RS" + vbCr))
                NotifyObservers(Me, New StatusEventArgs(EventName.evnmScannerStatusChanged, ConnectionType.ctNone, "MICR Not Attached"))
                Threading.Thread.Sleep(500)
                AttachDevice()
            Catch ex As Exception
                MsgBox("Reset scanner error. " + ex.Message, MsgBoxStyle.Critical)
            End Try
        End If
    End Sub

    'Private Sub SetupMICRImmageProperties()
    '    'Dim setupStr As String = "PR0=" & MICRAddr & vbCr _
    '    '    & "PR1=" & ReadSettingFromXml("/TellerAssistant/PropertySettings/PropertySetting[@name='PR1']") & vbCr _
    '    '    & "PR2=" & ReadSettingFromXml("/TellerAssistant/PropertySettings/PropertySetting[@name='PR2']") & vbCr _
    '    '    & "PR3=" & ReadSettingFromXml("/TellerAssistant/PropertySettings/PropertySetting[@name='PR3']") & vbCr _
    '    '    & "PR4=" & ReadSettingFromXml("/TellerAssistant/PropertySettings/PropertySetting[@name='PR4']") & vbCr _
    '    '    & "PR5=" & ReadSettingFromXml("/TellerAssistant/PropertySettings/PropertySetting[@name='PR5']") & vbCr _
    '    '    & "PR6=" & ReadSettingFromXml("/TellerAssistant/PropertySettings/PropertySetting[@name='PR6']") & vbCr _
    '    '    & "PR7=" & ReadSettingFromXml("/TellerAssistant/PropertySettings/PropertySetting[@name='PR7']") & vbCr _
    '    '    & "PR8=" & ReadSettingFromXml("/TellerAssistant/PropertySettings/PropertySetting[@name='PR8']") & vbCr _
    '    '    & "PR9=" & ReadSettingFromXml("/TellerAssistant/PropertySettings/PropertySetting[@name='PR9']") & vbCr _
    '    '    & "PR10=" & ReadSettingFromXml("/TellerAssistant/PropertySettings/PropertySetting[@name='PR10']") & vbCr _
    '    '    & "PR11=" & ReadSettingFromXml("/TellerAssistant/PropertySettings/PropertySetting[@name='PR11']") & vbCr _
    '    '    & "PR12=" & ReadSettingFromXml("/TellerAssistant/PropertySettings/PropertySetting[@name='PR12']") & vbCr _
    '    '    & "PR13=" & ReadSettingFromXml("/TellerAssistant/PropertySettings/PropertySetting[@name='PR13']") & vbCr _
    '    '    & "PR14=" & ReadSettingFromXml("/TellerAssistant/PropertySettings/PropertySetting[@name='PR14']") & vbCr _
    '    '    & "PR15=" & ReadSettingFromXml("/TellerAssistant/PropertySettings/PropertySetting[@name='PR15']") & vbCr _
    '    '    & "PR19=" & ReadSettingFromXml("/TellerAssistant/PropertySettings/PropertySetting[@name='PR19']") & vbCr _
    '    '    & "SA" & vbCr
    '    ''& "PR6=" & GetLocalIP() & vbCr _
    '    'Dim bytes() As Byte = ascii.GetBytes(setupStr)
    '    'clientSocket.Send(bytes)
    '    'EnableScanner = True
    'End Sub

#End Region

    Public Function KillCurrentImage() As Double
        Dim retVal As Double = 0
        Dim bytes() As Byte
        bytes = ascii.GetBytes("IS K" & vbCr)
        clientSocket.Send(bytes)
        Return retVal
    End Function

    Public Function GetLocalIP() As String
        'To get local address
        Dim sHostName As String = System.Net.Dns.GetHostName
        Dim ipString As String = System.Net.Dns.GetHostAddresses(sHostName).GetValue(0).ToString
        Return ipString
    End Function
End Class
