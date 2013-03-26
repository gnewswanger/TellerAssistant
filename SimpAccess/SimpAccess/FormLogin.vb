Imports System
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Security.Principal
Imports System.Security.Permissions

''' <summary>
''' <file>FormLogin.vb</file>
''' 
''' </summary>
''' <remarks></remarks>
''' <author>Galen Newswanger</author>
Public Class FormLogin

    Private _canClose As Boolean = True
    Private _success As Boolean = False

    Private Declare Auto Function LogonUser Lib "advapi32.dll" (ByVal lpszUsername As [String], _
    ByVal lpszDomain As [String], ByVal lpszPassword As [String], _
    ByVal dwLogonType As Integer, ByVal dwLogonProvider As Integer, _
    ByRef phToken As IntPtr) As Boolean

    <DllImport("kernel32.dll")> _
    Public Shared Function FormatMessage(ByVal dwFlags As Integer, ByRef lpSource As IntPtr, _
        ByVal dwMessageId As Integer, ByVal dwLanguageId As Integer, ByRef lpBuffer As [String], _
        ByVal nSize As Integer, ByRef Arguments As IntPtr) As Integer

    End Function

    Public Declare Auto Function CloseHandle Lib "kernel32.dll" (ByVal handle As IntPtr) As Boolean


    Public Declare Auto Function DuplicateToken Lib "advapi32.dll" (ByVal ExistingTokenHandle As IntPtr, _
            ByVal SECURITY_IMPERSONATION_LEVEL As Integer, _
            ByRef DuplicateTokenHandle As IntPtr) As Boolean

    Public WriteOnly Property LogoImage() As Image
        Set(ByVal value As Image)
            Me.LogoPictureBox.Image = value
        End Set
    End Property

    Public Property InitialUser() As String
        Get
            Return txtUsername.Text
        End Get
        Set(ByVal Value As String)
            txtUsername.Text = Value
        End Set
    End Property

    Public ReadOnly Property LoginSucceeded() As Boolean
        Get
            Return _success
        End Get
    End Property
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Const LOGON32_PROVIDER_DEFAULT As Integer = 0
        'This parameter causes LogonUser to create a primary token.
        Const LOGON32_LOGON_INTERACTIVE As Integer = 2

        Dim tokenHandle As New IntPtr(0)
        tokenHandle = IntPtr.Zero

        ' Call LogonUser to obtain a handle to an access token.
        Me._success = LogonUser(txtUsername.Text, My.Computer.Name, txtPassword.Text, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, tokenHandle)
        If Me._success Then
            _canClose = True
        Else
            Me._canClose = False
            MsgBox("Incorrect username/password")
            Me.txtUsername.Focus()
        End If
        Me.Close()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me._canClose = True
        Me.Close()
    End Sub

    Private Sub FormLogin_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        txtPassword.Focus()
    End Sub

    Private Sub FormLogin_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = Not _canClose
    End Sub
End Class
