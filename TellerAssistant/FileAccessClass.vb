Imports System.IO
Imports System.Xml

Public Class FileAccessClass
    Private xd As XmlDocument = New XmlDocument

    Public Sub New()
        xd.Load(My.Settings.MySettingsFilepath)

    End Sub

    Public Function ReadSettingFromXml(ByVal xmlPath As String) As String
        Try
            Dim retVal As String = String.Empty
            retVal = xd.SelectSingleNode(xmlPath).InnerText
            If retVal = Nothing Then
                Return String.Empty
            Else
                Return retVal
            End If
        Catch xex As XmlException
            MessageBox.Show("xml exception in Function ReadSettingFromXml. " & My.Settings.MySettingsFilepath & xmlPath & vbCr & xex.Message & vbCr & xex.LineNumber & vbCr & xex.LinePosition)
            Return Nothing
        Catch ex As Exception
            MessageBox.Show("exception in Function ReadSettingFromXml. " & My.Settings.MySettingsFilepath & vbCr & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Sub WriteSettingToXml(ByVal xmlPath As String, ByVal value As String)
        Try
            xd.SelectSingleNode(xmlPath).InnerText = value
            xd.Save(My.Settings.MySettingsFilepath)
        Catch ex As XmlException
            MessageBox.Show(My.Settings.MySettingsFilepath & vbCr & ex.Message & vbCr & ex.LineNumber & vbCr & ex.LinePosition)
        End Try
    End Sub

 

End Class
