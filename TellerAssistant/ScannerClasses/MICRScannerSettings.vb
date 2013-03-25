Imports System.Xml
Imports System.Security.Principal

Public Class MICRScannerSettings

    Delegate Sub SetCmdTextCallback(ByVal sender As Object, ByVal text As String)
    Public Shared Event SendScannerCommand As SetCmdTextCallback
    Private xd As XmlDocument = New XmlDocument

    Public Sub New()
        xd.Load(Application.LocalUserAppDataPath & "\" & My.Settings.MySettingsFilename)
        Dim wid As WindowsIdentity = WindowsIdentity.GetCurrent
        If My.Settings.LogScannerCmds Then
            WriteToErrorLog("WindowsIdentity", "ReadSettingFromXml", "WID name", wid.Name & ": " & wid.IsAuthenticated)
        End If
    End Sub

#Region "Port & MICR Settings"

    Friend Sub GetScannerSwitchSettings()
        Try
            Dim element As XmlElement = xd.DocumentElement("SwitchSettingsRS232")
            Dim nlist As XmlNodeList = element.ChildNodes
            For Each node As XmlNode In nlist
                Select Case node.Attributes("name").Value
                    Case "SWA"
                        Me.SendSettingToScanner("SWA=" & node.InnerText)
                    Case "SWB"
                        Me.SendSettingToScanner("SWB=" & node.InnerText)
                    Case "SWC"
                        Me.SendSettingToScanner("SWC=" & node.InnerText)
                    Case "SWD"
                        Me.SendSettingToScanner("SWD=" & node.InnerText)
                    Case "SWE"
                        Me.SendSettingToScanner("SWE=" & node.InnerText)
                    Case "SWI"
                        Me.SendSettingToScanner("SWI=" & node.InnerText)
                    Case "HW"
                        Me.SendSettingToScanner("HW=" & node.InnerText)
                    Case "FC"
                        'Me.SendSettingToScanner("FC=" & node.InnerText)
                End Select
            Next
        Catch ex As Exception
            MsgBox("at Sub GetScannerSwitchSettings in MICRScannerSettings: " & ex.Message)
        End Try
    End Sub

    Friend Sub GetScannerPropertiesSettings()
        Try
            Dim element As XmlElement = xd.DocumentElement("PropertySettings")
            Dim nlist As XmlNodeList = element.ChildNodes
            For Each node As XmlNode In nlist
                Select Case node.Attributes("name").Value
                    Case "PR1"
                        Me.SendSettingToScanner("PR1=" & node.InnerText)
                    Case "PR2"
                        Me.SendSettingToScanner("PR2=" & node.InnerText)
                    Case "PR3"
                        Me.SendSettingToScanner("PR3=" & node.InnerText)
                    Case "PR4"
                        Me.SendSettingToScanner("PR4=" & node.InnerText)
                    Case "PR5"
                        Me.SendSettingToScanner("PR5=" & node.InnerText)
                    Case "PR6"
                        Me.SendSettingToScanner("PR6=" & node.InnerText)
                    Case "PR7"
                        Me.SendSettingToScanner("PR7=" & node.InnerText)
                    Case "PR8"
                        Me.SendSettingToScanner("PR8=" & node.InnerText)
                    Case "PR9"
                        Me.SendSettingToScanner("PR9=" & node.InnerText)
                    Case "PR10"
                        Me.SendSettingToScanner("PR10=" & node.InnerText)
                    Case "PR11"
                        Me.SendSettingToScanner("PR11=" & node.InnerText)
                    Case "PR12"
                        Me.SendSettingToScanner("PR12=" & node.InnerText)
                    Case "PR13"
                        Me.SendSettingToScanner("PR13=" & node.InnerText)
                    Case "PR14"
                        Me.SendSettingToScanner("PR14=" & node.InnerText)
                    Case "PR15"
                        Me.SendSettingToScanner("PR15=" & node.InnerText)
                    Case "PR19"
                        Me.SendSettingToScanner("PR19=" & node.InnerText)
                End Select
            Next
        Catch ex As Exception
            MsgBox("at Sub GetScannerPropertiesSettings in MICRScannerSettings: " & ex.Message)
        End Try
    End Sub

    Private Sub SendSettingToScanner(ByVal cmd As String)
        RaiseEvent SendScannerCommand(Me, cmd)
        Threading.Thread.Sleep(30)
    End Sub

#End Region



End Class
