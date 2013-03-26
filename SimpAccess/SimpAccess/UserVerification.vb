Imports System
Imports System.Runtime.InteropServices
Imports System.Security.Principal
Imports System.Security.Permissions

<Assembly: SecurityPermissionAttribute(SecurityAction.RequestMinimum, UnmanagedCode:=True), _
 Assembly: PermissionSetAttribute(SecurityAction.RequestMinimum, Name:="FullTrust")> 
Public Class UserVerification


End Class
