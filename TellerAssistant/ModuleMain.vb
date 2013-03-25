Imports System.Threading
Imports System.Security.Principal
Imports System.Security.Permissions
Imports System.Diagnostics
Imports System.Configuration
Imports System.Net
Imports System.IO

Module MainModule
    'Private accessFiles As FileAccessClass = New FileAccessClass

    <STAThread()> Sub Main()
        Try
            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal)
            If LoginUser() Then
                Dim wid As WindowsIdentity = WindowsIdentity.GetCurrent
                WriteToErrorLog("WindowsIdentity", "Sub Main", "WID name", wid.Name & ": " & wid.IsAuthenticated)
                Dim splashDlg As New FormSplash
                splashDlg.Show()
                Application.EnableVisualStyles()
                Application.DoEvents()
                Application.Run(New FormMain2012)
                splashDlg.Close()
            Else
                Application.Exit()
            End If
        Catch ex As Exception
            MsgBox("At sub main; " & ex.Message)
        End Try
    End Sub

    Public Function LoginUser() As Boolean
        Dim user As WindowsPrincipal = CType(System.Threading.Thread.CurrentPrincipal, WindowsPrincipal)
        WriteToErrorLog("WindowsIdentity", "Function LoginUser", "WID name", user.Identity.Name & ": " & user.Identity.IsAuthenticated)
        Try
            Dim frm As New SimpAccess.FormLogin
            frm.LogoImage = My.Resources.prospe_micrimage_mn
            frm.Text = "Teller's Assistant: User Verification"
            frm.InitialUser = user.Identity.Name.Substring(user.Identity.Name.LastIndexOf("\") + 1)
            frm.ShowDialog()
            Return frm.LoginSucceeded
        Catch ex As Exception
            MsgBox("at LoginUser: " & ex.Message)
        End Try
    End Function

    Public Function GetVersionString() As String
        Dim ver As New Version(System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString)
        Dim retVal As String = String.Empty
        Dim verDt As New DateTime(2000, 1, 1, 0, 0, 0)
        verDt = verDt.AddDays(ver.Build)
        verDt = verDt.AddSeconds(ver.Revision)
        retVal = ver.ToString & " " & verDt.ToLongTimeString
        Return retVal
    End Function

    Public Sub WriteToErrorLog(ByVal title As String, ByVal msg As String, ByVal excpt As String, Optional ByVal detail As String = "")
        If My.Settings.LoggingTurnedOn Then
            If Not System.IO.Directory.Exists(Application.LocalUserAppDataPath & "\Log\") Then
                System.IO.Directory.CreateDirectory(Application.LocalUserAppDataPath & "\Log\")
            End If
            'check the file
            Dim fs As FileStream = New FileStream(Application.LocalUserAppDataPath & "\Log\Exceptions.log", FileMode.OpenOrCreate, FileAccess.ReadWrite)
            Dim s As StreamWriter = New StreamWriter(fs)
            s.Close()
            fs.Close()
            'log it
            Dim fs1 As FileStream = New FileStream(Application.LocalUserAppDataPath & "\Log\Exceptions.log", FileMode.Append, FileAccess.Write)
            Dim s1 As StreamWriter = New StreamWriter(fs1)
            s1.WriteLine(title & "," & msg & "," & excpt & "," & detail & "," & DateTime.Now.ToString)
            s1.Close()
            fs1.Close()
        End If
    End Sub

    Public Sub RewriteErrorLog(ByVal list As List(Of String))
        'log it
        Dim fs1 As FileStream = New FileStream(Application.LocalUserAppDataPath & "\Log\Exceptions.log", FileMode.Truncate, FileAccess.Write)
        Dim s1 As StreamWriter = New StreamWriter(fs1)
        's1.WriteLine(title & "," & msg & "," & excpt & "," & detail & "," & exceptDate)
        For index As Integer = 0 To list.Count - 1
            s1.WriteLine(list.Item(index))
        Next
        s1.Close()
        fs1.Close()
    End Sub


End Module