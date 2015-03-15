Imports System.Data.SqlClient
Imports System.Xml
Imports System.Text

Public Class DataClass
    Inherits mvcLibrary.mvcAbstractModel

    Private conn As SqlConnection
    Private Shared instance As DataClass

    Friend Shared Function getInstance(ByVal sender As Object, ByVal connString As String) As DataClass
        If instance Is Nothing Then
            instance = New DataClass(connString)
            Return instance
        Else
            Return instance
        End If
    End Function

    Private Sub New(ByVal connString As String)
        MyBase.New()
        conn = New SqlConnection(connString)
    End Sub


#Region "Baseclass Overrides"
    Public Overrides Sub UpdateData(ByVal NewEvent As mvcLibrary.mvcEventArgsBase)

    End Sub

#End Region

#Region "Bank Account Methods - dbo.Bank"

    Public Function BankExists(ByVal bnkId As String, ByVal leaveConnOpen As Boolean) As Boolean
        Dim sqlSelect As String = "SELECT BankId FROM Bank " _
            + " WHERE BankId = '" + Trim(bnkId) + "'"
        Dim sqlCmd As New SqlCommand(sqlSelect, conn)
        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
        Try
            If IsNothing(sqlCmd.ExecuteScalar) Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("BankExists ExecuteScalar failed. " + ex.Message)
        Finally
            If Not leaveConnOpen Then
                conn.Close()
            End If
        End Try
    End Function

    Public Function BankAccountExists(ByVal bnkId As String, ByVal acctId As String, ByVal leaveConnOpen As Boolean) As Boolean
        Dim sqlSelect As String = "SELECT AccountID FROM BankAccount " _
            + " WHERE BankId = '" + Trim(bnkId) + "' AND AccountID = '" + acctId + "'"
        Dim sqlCmd As New SqlCommand(sqlSelect, conn)
        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
        Try
            If IsNothing(sqlCmd.ExecuteScalar) Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("BankExists ExecuteScalar failed. " + ex.Message)
        Finally
            If Not leaveConnOpen Then
                conn.Close()
            End If
        End Try
    End Function

    Public Function GetBankAccountClass(ByVal bankid As String, ByVal acctid As String, ByVal leaveConnOpen As Boolean) As BankAccountClass
        Dim retClass As BankAccountClass = New BankAccountClass(bankid, acctid)
        Dim sqlSelect As String = "SELECT Bank.BankName, Bank.BankAddr1, Bank.BankCity, " _
         + "Bank.BankState, Bank.BankZip, BankAccount.AccountName, BankAccount.AccountType FROM Bank, BankAccount " _
         + " WHERE BankAccount.AccountID = '" + acctid + "' AND Bank.BankId = '" + bankid + "'"
        Dim sqlCmd As New SqlCommand(sqlSelect, conn)
        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
        Try
            Dim rdr As SqlDataReader = sqlCmd.ExecuteReader
            Try
                If rdr.Read Then
                    retClass.DepositBank = rdr.GetString(0)
                    retClass.DepositBankAddress = rdr.GetString(1)
                    retClass.DepositBankCity = rdr.GetString(2)
                    retClass.DepositBankState = rdr.GetString(3)
                    retClass.DepositBankZip = rdr.GetString(4)
                    retClass.AccountName = rdr.GetString(5)
                    retClass.AccountType = rdr.GetString(6)
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                MsgBox("GetBankAccountClass SqlDataReader failed. " + ex.Message)
                Return Nothing
            Finally
                rdr.Close()
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            If Not leaveConnOpen Then
                conn.Close()
            End If
        End Try

        Return retClass
    End Function

    Public Function GetBankAccountClassList() As List(Of BankAccountClass)
        Dim retList As New List(Of BankAccountClass)
        Dim sqlSelect As String = "SELECT BankAccount.BankId, BankAccount.AccountID, BankAccount.AccountName, BankAccount.AccountType, " _
            + "Bank.BankName, Bank.BankAddr1, Bank.BankCity, Bank.BankState, Bank.BankZip " _
            + "FROM BankAccount, Bank" _
            + " WHERE Bank.BankId = BankAccount.BankId"
        Dim sqlCmd As New SqlCommand(sqlSelect, conn)
        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
        Try
            Dim rdr As SqlDataReader = sqlCmd.ExecuteReader
            Try
                While rdr.Read
                    Dim bnkClass As New BankAccountClass(rdr.GetString(0), rdr.GetString(1))
                    bnkClass.AccountName = rdr.GetString(2)
                    bnkClass.AccountType = rdr.GetString(3)
                    bnkClass.DepositBank = rdr.GetString(4)
                    bnkClass.DepositBankAddress = rdr.GetString(5)
                    bnkClass.DepositBankCity = rdr.GetString(6)
                    bnkClass.DepositBankState = rdr.GetString(7)
                    bnkClass.DepositBankZip = rdr.GetString(8)
                    retList.Add(bnkClass)
                End While
            Catch ex As Exception
                MsgBox("GetBankAccountClassList SqlDataReader failed. " + ex.Message)
                Return Nothing
            Finally
                rdr.Close()
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            conn.Close()
        End Try

        Return retList
    End Function

    Public Function GetAccountName(ByVal bkid As String, ByVal acctid As String) As String
        Dim sqlSelect As String = "SELECT AccountName FROM BankAccount " _
            + " WHERE BankId = '" + bkid + "' AND AccountId = '" + acctid + "'"
        Dim sqlCmd As New SqlCommand(sqlSelect, conn)
        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
        Try
            Dim rdr As SqlDataReader = sqlCmd.ExecuteReader
            Try
                If rdr.Read Then
                    Return Trim(rdr.GetString(0))
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                MsgBox("SqlDataReader failed. " + ex.Message)
                Return Nothing
            Finally
                rdr.Close()
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            conn.Close()
        End Try
    End Function

    Public Function GetAccountAddress(ByVal bkid As String, ByVal acctid As String) As ArrayList
        Dim sqlSelect As String = "SELECT AccountName, AccountAddr1, AccountAddr2, AccountCity, " _
            + "AccountState, AccountZip FROM BankAccount " _
            + " WHERE BankId = '" + bkid + "' AND AccountId = '" + acctid + "'"
        Dim sqlCmd As New SqlCommand(sqlSelect, conn)
        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
        Try
            Dim rdr As SqlDataReader = sqlCmd.ExecuteReader
            Try
                Dim RetList As New ArrayList
                If rdr.Read Then
                    For i As Integer = 0 To rdr.FieldCount - 1
                        If rdr.IsDBNull(i) Then
                            RetList.Add("")
                        Else
                            RetList.Add(Trim(rdr.GetString(i)))
                        End If
                    Next
                    Return RetList
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                MsgBox("SqlDataReader failed. " + ex.Message)
                Return Nothing
            Finally
                rdr.Close()
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            conn.Close()
        End Try
    End Function

    Public Function GetBankName(ByVal bkid As String) As String
        Dim sqlSelect As String = "SELECT BankName FROM Bank " _
            + " WHERE BankId = '" + bkid + "'"
        Dim sqlCmd As New SqlCommand(sqlSelect, conn)
        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
        Try
            Dim rdr As SqlDataReader = sqlCmd.ExecuteReader
            Try
                If rdr.Read Then
                    Return Trim(rdr.GetString(0))
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                MsgBox("SqlDataReader failed. " + ex.Message)
                Return Nothing
            Finally
                rdr.Close()
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            conn.Close()
        End Try
    End Function

    Public Function GetBankAddress(ByVal bkid As String) As ArrayList
        Dim sqlSelect As String = "SELECT BankName, BankAddr1, BankAddr2, BankCity, " _
            + "BankState, BankZip FROM Bank " _
            + " WHERE BankId = '" + bkid + "'"
        Dim sqlCmd As New SqlCommand(sqlSelect, conn)
        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
        Try
            Dim rdr As SqlDataReader = sqlCmd.ExecuteReader
            Try
                Dim RetList As New ArrayList
                If rdr.Read Then
                    For i As Integer = 0 To rdr.FieldCount - 1
                        If rdr.IsDBNull(i) Then
                            RetList.Add("")
                        Else
                            RetList.Add(Trim(rdr.GetString(i)))
                        End If
                    Next
                    Return RetList
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                MsgBox("SqlDataReader failed. " + ex.Message)
                Return Nothing
            Finally
                rdr.Close()
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            conn.Close()
        End Try
    End Function

    Public Function GetAcctType(ByVal bkid As String, ByVal acctid As String, ByVal leaveConnOpen As Boolean) As String
        Dim sqlSelect As String = "SELECT AccountType FROM BankAccount " _
            + " WHERE BankId = '" + bkid + "' AND AccountId = '" + acctid + "'"
        Dim sqlCmd As New SqlCommand(sqlSelect, conn)
        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
        Try
            Dim rdr As SqlDataReader = sqlCmd.ExecuteReader
            Try
                If rdr.Read Then
                    Return rdr.GetString(0)
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                MsgBox("SqlDataReader failed. " + ex.Message)
                Return Nothing
            Finally
                rdr.Close()
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            If Not leaveConnOpen Then
                conn.Close()
            End If
        End Try
    End Function

    Public Function SetBankAccountClass(ByVal acct As BankAccountClass) As BankAccountClass
        If BankAccountExists(acct.DepositBankNo, acct.AccountNo, True) Then
            Return UpdateBankAccount(acct)
        Else
            Return InsertBankAccount(acct)
        End If
    End Function

    Private Function InsertBank(ByVal acct As BankAccountClass, ByVal leaveConnOpen As Boolean) As Boolean
        Try
            If Not BankExists(acct.DepositBankNo, True) Then
                Dim sqlCmd As New SqlCommand("INSERT INTO dbo.Bank (BankId, BankName, BankAddr1, " _
                    + "BankCity, BankState, BankZip) " _
                    + "VALUES (@BankID, @BankName, @BankAddr1, @BankCity, @BankState, @BankZip) ", conn)

                If Not conn.State = ConnectionState.Open Then
                    conn.Open()
                End If
                sqlCmd.Parameters.Add("@BankID", SqlDbType.VarChar, 10).Value = acct.DepositBankNo.Trim
                sqlCmd.Parameters.Add("@BankName", SqlDbType.VarChar, 50).Value = acct.DepositBank.Trim
                sqlCmd.Parameters.Add("@BankAddr1", SqlDbType.VarChar, 50).Value = acct.DepositBankAddress.Trim
                sqlCmd.Parameters.Add("@BankCity", SqlDbType.VarChar, 50).Value = acct.DepositBankCity.Trim
                sqlCmd.Parameters.Add("@BankState", SqlDbType.VarChar, 10).Value = acct.DepositBankState.Trim
                sqlCmd.Parameters.Add("@BankZip", SqlDbType.VarChar, 10).Value = acct.DepositBankZip.Trim
                sqlCmd.Prepare()
                sqlCmd.ExecuteNonQuery()
                Return True
            End If
        Catch ex As Exception
            MsgBox("InsertBank ExecuteNonQuery failed. " + ex.Message)
        Finally
            If Not leaveConnOpen Then
                conn.Close()
            End If
        End Try
        Return False
    End Function

    Private Function InsertBankAccount(ByVal acct As BankAccountClass) As BankAccountClass
        Try
            If BankExists(acct.DepositBankNo, True) Then
                UpdateBank(acct, True)
            Else
                InsertBank(acct, True)
            End If

            Dim sqlCmd As New SqlCommand("INSERT INTO dbo.BankAccount (BankId, AccountID, AccountName, AccountType)  " _
                + "VALUES (@BankId, @AccountID, @AccountName, @AccountType) ", conn)

            If Not conn.State = ConnectionState.Open Then
                conn.Open()
            End If
            sqlCmd.Parameters.Add("@BankId", SqlDbType.VarChar, 10).Value = acct.DepositBankNo.Trim
            sqlCmd.Parameters.Add("@AccountID", SqlDbType.VarChar, 10).Value = acct.AccountNo.Trim
            sqlCmd.Parameters.Add("@AccountName", SqlDbType.VarChar, 50).Value = acct.AccountName.Trim
            sqlCmd.Parameters.Add("@AccountType", SqlDbType.VarChar, 10).Value = acct.AccountType.Trim
            sqlCmd.Prepare()
            sqlCmd.ExecuteNonQuery()
            NotifyObservers(Me, New BankAccountEventArgs(EventName.evnmBankInfoChanged, acct))
            Return acct
        Catch ex As Exception
            MsgBox("InsertBankAccount ExecuteNonQuery failed. " + ex.Message)
        Finally
            conn.Close()
        End Try
        Return Nothing
    End Function

    Public Function UpdateBank(ByVal acct As BankAccountClass, ByVal leaveConnOpen As Boolean) As Boolean
        Dim sqlCmd As New SqlCommand("UPDATE dbo.Bank SET  BankId = @BankID, BankName = @BankName, " _
            + "Bank.BankAddr1 = @BankAddr1, BankCity = @BankCity, BankState = @BankState, " _
            + "Bank.BankZip = @BankZip " _
            + " WHERE BankId = '" + acct.DepositBankNo.Trim + "'", conn)
        Try
            If Not conn.State = ConnectionState.Open Then
                conn.Open()
            End If
            sqlCmd.Parameters.Add("@BankID", SqlDbType.VarChar, 10).Value = acct.DepositBankNo.Trim
            sqlCmd.Parameters.Add("@BankName", SqlDbType.VarChar, 50).Value = acct.DepositBank.Trim
            sqlCmd.Parameters.Add("@BankAddr1", SqlDbType.VarChar, 50).Value = acct.DepositBankAddress.Trim
            sqlCmd.Parameters.Add("@BankCity", SqlDbType.VarChar, 50).Value = acct.DepositBankCity.Trim
            sqlCmd.Parameters.Add("@BankState", SqlDbType.VarChar, 10).Value = acct.DepositBankState.Trim
            sqlCmd.Parameters.Add("@BankZip", SqlDbType.VarChar, 10).Value = acct.DepositBankZip.Trim
            sqlCmd.Prepare()
            sqlCmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox("UpdateBank ExecuteNonQuery failed. " + ex.Message)
        Finally
            If Not leaveConnOpen Then
                conn.Close()
            End If
        End Try

        Return False
    End Function
    Public Function UpdateBankAccount(ByVal acct As BankAccountClass) As BankAccountClass
        Try
            If BankExists(acct.DepositBankNo, True) Then
                UpdateBank(acct, True)
            End If
            Dim sqlCmd As New SqlCommand("UPDATE dbo.BankAccount SET BankID = @BankID, AccountID = @AccountID, " _
                + "AccountName = @AccountName, AccountType = @AccountType  " _
                + " WHERE BankId = '" + acct.DepositBankNo.Trim _
                + "' AND AccountID = '" + acct.AccountNo.Trim + "'", conn)

            If Not conn.State = ConnectionState.Open Then
                conn.Open()
            End If
            sqlCmd.Parameters.Add("@BankID", SqlDbType.VarChar, 10).Value = acct.DepositBankNo.Trim
            sqlCmd.Parameters.Add("@AccountID", SqlDbType.VarChar, 10).Value = acct.AccountNo.Trim
            sqlCmd.Parameters.Add("@AccountName", SqlDbType.VarChar, 50).Value = acct.AccountName.Trim
            sqlCmd.Parameters.Add("@AccountType", SqlDbType.VarChar, 10).Value = acct.AccountType.Trim
            sqlCmd.Prepare()
            sqlCmd.ExecuteNonQuery()
            NotifyObservers(Me, New BankAccountEventArgs(EventName.evnmBankInfoChanged, acct))
            Return acct
        Catch ex As Exception
            MsgBox("UpdateBankAccount ExecuteNonQuery failed. " + ex.Message)
        Finally
            conn.Close()
        End Try
        Return Nothing
    End Function

    Public Sub DeleteBankAccount(ByVal acct As BankAccountClass)
        If BankAccountExists(acct.DepositBankNo, acct.AccountNo, True) Then
            Dim sqlText As String = "DELETE FROM BankAccount " _
                + " WHERE BankId = '" + acct.DepositBankNo.Trim _
                + "' AND AccountID = '" + acct.AccountNo.Trim + "'"
            Dim sqlCmd As New SqlCommand(sqlText, conn)
            If Not conn.State = ConnectionState.Open Then
                conn.Open()
            End If
            Try
                If sqlCmd.ExecuteNonQuery() > 0 Then
                    If GetAccountsByBank(acct.DepositBankNo).Count = 0 Then
                        DeleteBank(acct.DepositBankNo)
                    End If
                    NotifyObservers(Me, New BankAccountEventArgs(EventName.evnmBankInfoDeleted, acct))
                Else
                    NotifyObservers(Me, New BankAccountEventArgs(EventName.evnmDataTransactionFailed, acct))
                End If
            Catch ex As Exception
                MsgBox("DeleteBankAccount ExecuteNonQuery failed. " + ex.Message)
            Finally
                conn.Close()
            End Try
        End If
    End Sub

    Public Sub DeleteBank(ByVal bnk As String)
        If BankExists(bnk, True) Then
            Dim sqlText As String = "DELETE FROM Bank " _
                + " WHERE BankId = '" + bnk.Trim + "'"
            Dim sqlCmd As New SqlCommand(sqlText, conn)
            If Not conn.State = ConnectionState.Open Then
                conn.Open()
            End If
            Try
                If sqlCmd.ExecuteNonQuery() > 0 Then

                End If
            Catch ex As Exception
                MsgBox("DeleteBank ExecuteNonQuery failed. " + ex.Message)
            Finally
                conn.Close()
            End Try
        End If
    End Sub

    Public Function GetAccountsByBank(ByVal bnk As String) As List(Of BankAccountClass)
        Dim retList As New List(Of BankAccountClass)
        Dim sqlSelect As String = "SELECT BankAccount.BankId, BankAccount.AccountID, BankAccount.AccountName, BankAccount.AccountType, " _
            + "Bank.BankName, Bank.BankAddr1, Bank.BankCity, Bank.BankState, Bank.BankZip " _
            + "FROM BankAccount, Bank" _
            + " WHERE Bank.BankId = BankAccount.BankId AND BankAccount.BankId = '" + bnk + "'"
        Dim sqlCmd As New SqlCommand(sqlSelect, conn)
        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
        Try
            Dim rdr As SqlDataReader = sqlCmd.ExecuteReader
            Try
                While rdr.Read
                    Dim bnkClass As New BankAccountClass(rdr.GetString(0), rdr.GetString(1))
                    bnkClass.AccountName = rdr.GetString(2)
                    bnkClass.AccountType = rdr.GetString(3)
                    bnkClass.DepositBank = rdr.GetString(4)
                    bnkClass.DepositBankAddress = rdr.GetString(5)
                    bnkClass.DepositBankCity = rdr.GetString(6)
                    bnkClass.DepositBankState = rdr.GetString(7)
                    bnkClass.DepositBankZip = rdr.GetString(8)
                    retList.Add(bnkClass)
                End While
            Catch ex As Exception
                MsgBox("GetBankAccountClassList SqlDataReader failed. " + ex.Message)
                Return Nothing
            Finally
                rdr.Close()
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            conn.Close()
        End Try

        Return retList

        Return Nothing
    End Function
#End Region

#Region "Bank Deposit Methods - dbo.DepositTickets"

    Public Function GetUniqueNo() As String
        Dim sqlCmd As New SqlCommand("Select MAX(Number) " _
                + " FROM dbo.DonationDeposits", conn)
        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
        Try
            Dim retVal As String = String.Empty
            If IsDBNull(sqlCmd.ExecuteScalar) Then
                retVal = "DEP100"
            Else
                retVal = CStr(sqlCmd.ExecuteScalar)
                Dim num As Integer = CInt(retVal)
                num += 1
                retVal = "DEP" & num
            End If
            Return retVal
        Catch ex As Exception
            MsgBox("ExecuteScalar failed in GetUniqueNo. " & ex.Message)
            Return Nothing
        Finally
            conn.Close()
        End Try
    End Function

    Public Function GetDepositNos() As ArrayList
        Dim retList As New ArrayList
        Dim sql As String = "SELECT DepositNo from DonationDeposits ORDER BY Number"
        Dim cmd As New SqlCommand(sql, conn)
        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
        Try
            Dim reader As SqlDataReader = cmd.ExecuteReader
            While reader.Read
                retList.Add(Trim(reader.GetString(0)))
            End While
            Return retList
        Catch ex As Exception
            MsgBox("SqlDataReader failed in GetDepositNos. " + ex.Message)
            Return Nothing
        Finally
            conn.Close()
        End Try
    End Function

    'Public Function GetDepositTicketList(ByVal ytd As Boolean) As List(Of DepositTicketClass)
    '    Dim retList As New List(Of DepositTicketClass)
    '    Dim filter As String = String.Empty
    '    If ytd Then
    '        filter = "WHERE DepDate >= '01/01/" & Today.Year.ToString & "'"
    '    Else
    '        filter = ""
    '    End If
    '    Dim sql As String = "SELECT DepositNo, DepDate, DepDescript, BankId, AccountId, ImagePath from DonationDeposits " & filter & " ORDER BY DepositNo DESC"
    '    Dim cmd As New SqlCommand(sql, conn)
    '    If Not conn.State = ConnectionState.Open Then
    '        conn.Open()
    '    End If
    '    Try
    '        Dim rdr As SqlDataReader = cmd.ExecuteReader
    '        While rdr.Read
    '            Dim depSummary As DepositTicketClass
    '            depSummary = New DepositTicketClass(rdr.GetString(0), rdr.GetDateTime(1), rdr.GetString(2), New BankAccountClass(rdr.GetString(3), rdr.GetString(4)))
    '            If IsDBNull(rdr.GetValue(5)) Then
    '                depSummary.CheckImagePath = depSummary.CheckImagePath
    '            Else
    '                depSummary.CheckImagePath = Trim(rdr.GetString(5))
    '            End If
    '            retList.Add(depSummary)
    '        End While
    '        rdr.Close()
    '        For Each item As DepositTicketClass In retList
    '            item.BankInfo = GetBankAccountClass(item.BankInfo.DepositBankNo, item.BankInfo.AccountNo, True)
    '            item.DepositTotal = (GetCashDepositTotal(item.DepositNumber, True) / 100) + GetChecksDepositTotal(item.DepositNumber, False)
    '        Next
    '        Return retList
    '    Catch ex As Exception
    '        MsgBox("SqlDataReader failed in GetDepositTicketList. " + ex.Message)
    '        Return Nothing
    '    Finally
    '        conn.Close()
    '    End Try
    'End Function

    Public Function GetDepositListViewCollection(ByVal dateRange As Integer) As List(Of ListViewItem)
        Dim retList As New List(Of ListViewItem)
        Dim filterStart As DateTime
        Dim filterEnd As DateTime
        Select Case dateRange
            Case 0  'Ths Year
                filterStart = New DateTime(Today.Year, 1, 1)
                filterEnd = New DateTime(Today.Year, 12, 31)
            Case 1  'Last Year
                Dim yr As Integer
                yr = Today.Year - 1
                filterStart = New DateTime(yr, 1, 1)
                filterEnd = New DateTime(yr, 12, 31)
            Case 2  'This year and last year
                Dim yr As Integer
                yr = Today.Year - 1
                filterStart = New DateTime(yr, 1, 1)
                filterEnd = New DateTime(Today.Year, 12, 31)
            Case 3  'This quarter
                Dim mon As Integer = Today.Month
                If mon <= 3 Then
                    filterStart = New DateTime(Today.Year, 1, 1)
                    filterEnd = New DateTime(Today.Year, 3, 31)
                ElseIf mon <= 6 Then
                    filterStart = New DateTime(Today.Year, 4, 1)
                    filterEnd = New DateTime(Today.Year, 6, 30)
                ElseIf mon <= 9 Then
                    filterStart = New DateTime(Today.Year, 7, 1)
                    filterEnd = New DateTime(Today.Year, 9, 30)
                Else
                    filterStart = New DateTime(Today.Year, 10, 1)
                    filterEnd = New DateTime(Today.Year, 12, 31)
                End If
            Case Else   'All records
                filterStart = New DateTime(1990, 10, 1)
                filterEnd = New DateTime(Today.Year, 12, 31)
        End Select
        Try

            Dim dt As New DataSet1.upGetDepositTicketListDataTable
            Dim adptr As New DataSet1TableAdapters.upGetDepositTicketListTableAdapter
            adptr.Fill(dt, filterStart, filterEnd)


            For Each row As DataSet1.upGetDepositTicketListRow In dt
                Dim itm As New ListViewItem
                itm.Text = row.DepositNo.Trim
                itm.SubItems.Add(row.DepDate.ToShortDateString)
                itm.SubItems.Add(row.DepDescript.Trim)
                Dim amt As Single = row.CashTotal + row.CheckTotal
                itm.SubItems.Add(amt.ToString("C"))
                itm.Tag = row.AccountId.Trim
                retList.Add(itm)
            Next

            'Dim cmd As SqlCommand = New SqlCommand("[upGetDepositTicketList]", Me.conn)
            'cmd.CommandType = CommandType.StoredProcedure
            'cmd.Parameters.AddWithValue("@filterStart", Nothing)
            'cmd.Parameters.AddWithValue("@filterEnd", Nothing)

            'If Not conn.State = ConnectionState.Open Then
            '    conn.Open()
            'End If
            'Try
            '    Dim rdr As SqlDataReader = cmd.ExecuteReader
            '    While rdr.Read
            '        Dim itm As New ListViewItem
            '        itm.Text = rdr.GetString(1)
            '        itm.SubItems.Add(rdr.GetDateTime(2).ToShortDateString)
            '        itm.SubItems.Add(rdr.GetString(3))
            '        Dim amt As Single = rdr.GetDecimal(9) + rdr.GetDecimal(10)
            '        itm.SubItems.Add(amt.ToString("C"))
            '        itm.Tag = rdr.GetString(6)

            '        retList.Add(itm)
            '    End While
            '    rdr.Close()
            'For Each item As ListViewItem In retList
            '    Dim dep As Single = Me.GetDepositTotals(item.Text.Trim, True)
            '    item.SubItems.Add(dep.ToString("C"))
            'Next
            Return retList
        Catch ex As Exception
            MsgBox("SqlDataReader failed in GetDepositListViewCollection. " + ex.Message)
            Return Nothing
        End Try
        'Finally
        '    conn.Close()
        'End Try
    End Function

    Public Function GetDepositTotals(dep As String, ByVal leaveConnOpen As Boolean) As Single
        Dim retVal As Single = 0

        Dim cmd As SqlCommand = New SqlCommand("[spGetDepositTotals]", Me.conn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@depositNo", dep)

        If Not Me.conn.State = ConnectionState.Open Then
            Me.conn.Open()
        End If
        Try
            Dim rdr As SqlDataReader = cmd.ExecuteReader
            While rdr.Read
                If Not IsDBNull(rdr.GetValue(0)) Then
                    retVal += CSng(rdr.GetValue(0))
                End If
            End While
            rdr.Close()
        Catch ex As Exception
            MsgBox("SqlDataReader failed in GetDepositTotals. " + ex.Message)
            Return Nothing
        Finally
            If Not leaveConnOpen Then
                conn.Close()
            End If
        End Try
        Return retVal
    End Function

    Public Function GetDepositTicketList(ByVal dateRange As Integer) As List(Of DepositTicketClass)
        Dim retList As New List(Of DepositTicketClass)
        Dim filter As String = String.Empty
        Select Case dateRange
            Case 0  'Ths Year
                filter = "WHERE DepDate >= '01/01/" & Today.Year.ToString & "'"
            Case 1  'Last Year
                Dim yr As Integer
                yr = Today.Year - 1
                filter = "WHERE DepDate >= '01/01/" & yr.ToString & "' AND DepDate <= '12/31/" & yr.ToString & "'"
            Case 2  'This year and last year
                Dim yr As Integer
                yr = Today.Year - 1
                filter = "WHERE DepDate >= '01/01/" & yr.ToString & "' AND DepDate <= '12/31/" & Today.Year.ToString & "'"
            Case 3  'This quarter
                Dim mon As Integer = Today.Month
                If mon <= 3 Then
                    filter = "WHERE DepDate >= '01/01/" & Today.Year.ToString & "' AND DepDate <= '03/31/" & Today.Year.ToString & "'"
                ElseIf mon <= 6 Then
                    filter = "WHERE DepDate >= '04/01/" & Today.Year.ToString & "' AND DepDate <= '06/30/" & Today.Year.ToString & "'"
                ElseIf mon <= 9 Then
                    filter = "WHERE DepDate >= '07/01/" & Today.Year.ToString & "' AND DepDate <= '09/30/" & Today.Year.ToString & "'"
                Else
                    filter = "WHERE DepDate >= '10/01/" & Today.Year.ToString & "' AND DepDate <= '12/31/" & Today.Year.ToString & "'"
                End If
            Case Else   'All records
                filter = ""
        End Select

        Dim sql As String = "SELECT DepositNo, DepDate, DepDescript, BankId, AccountId, ImagePath from DonationDeposits " & filter & " ORDER BY DepositNo DESC"
        Dim cmd As New SqlCommand(sql, conn)
        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
        Try
            Dim rdr As SqlDataReader = cmd.ExecuteReader
            While rdr.Read
                Dim depSummary As DepositTicketClass
                depSummary = New DepositTicketClass(rdr.GetString(0), rdr.GetDateTime(1), rdr.GetString(2), New BankAccountClass(rdr.GetString(3), rdr.GetString(4)))
                If IsDBNull(rdr.GetValue(5)) Then
                    depSummary.CheckImagePath = depSummary.CheckImagePath
                Else
                    depSummary.CheckImagePath = Trim(rdr.GetString(5))
                End If
                retList.Add(depSummary)
            End While
            rdr.Close()
            For Each item As DepositTicketClass In retList
                item.BankInfo = GetBankAccountClass(item.BankInfo.DepositBankNo, item.BankInfo.AccountNo, True)
                item.DepositTotal = (GetCashDepositTotal(item.DepositNumber, True) / 100) + GetChecksDepositTotal(item.DepositNumber, False)
            Next
            Return retList
        Catch ex As Exception
            MsgBox("SqlDataReader failed in GetDepositTicketList. " + ex.Message)
            Return Nothing
        Finally
            conn.Close()
        End Try
    End Function

    Public Function DepositExists(ByVal dep As DepositTicketClass, ByVal leaveConnOpen As Boolean) As Boolean
        Dim sqlSelect As String = "SELECT DepositNo FROM DonationDeposits " _
            + " WHERE DepositNo = '" + Trim(dep.DepositNumber) + "'"
        Dim sqlCmd As New SqlCommand(sqlSelect, conn)
        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
        Try
            If IsNothing(sqlCmd.ExecuteScalar) Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ExecuteScalar failed in DepositExists. " + ex.Message)
        Finally
            If Not leaveConnOpen Then
                conn.Close()
            End If
        End Try
    End Function

    Public Function GetDepositTicket(ByVal depNo As String, ByVal leaveConnOpen As Boolean) As DepositTicketClass
        Dim retVal As DepositTicketClass
        Dim sql As String = "SELECT DepositNo, DepDate, DepDescript, BankId, AccountId, ImagePath from DonationDeposits WHERE DepositNo = '" & depNo & "'"
        Dim cmd As New SqlCommand(sql, conn)
        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
        Try
            Dim rdr As SqlDataReader = cmd.ExecuteReader
            If rdr.Read Then
                retVal = New DepositTicketClass(rdr.GetString(0), rdr.GetDateTime(1), rdr.GetString(2))
                Dim bnkInf() As String = {rdr.GetString(3), rdr.GetString(4)}
                If Not IsDBNull(rdr.GetValue(5)) Then
                    retVal.CheckImagePath = Trim(rdr.GetString(5))
                End If
                rdr.Close()
                retVal.BankInfo = GetBankAccountClass(bnkInf(0), bnkInf(1), True)
                retVal.DepositTotal = GetCashDepositTotal(retVal.DepositNumber, False) + GetChecksDepositTotal(retVal.DepositNumber, False)
                Return retVal
            End If
        Catch ex As Exception
            MsgBox("SqlDataReader failed in GetDepositTicket. " + ex.Message)
            Return Nothing
        Finally
            If Not leaveConnOpen Then
                conn.Close()
            End If
        End Try
        Return Nothing
    End Function

    Public Function GetDepositCheckImageDirectory(ByVal depNo As String, ByVal leaveConnOpen As Boolean) As String
        Dim retVal As String = String.Empty
        Dim sql As String = "SELECT DepositNo, ImagePath from DonationDeposits WHERE DepositNo = '" & depNo & "'"
        Dim cmd As New SqlCommand(sql, conn)
        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
        Try
            Dim rdr As SqlDataReader = cmd.ExecuteReader
            If rdr.Read Then
                If IsDBNull(rdr.GetValue(1)) Then
                    rdr.Close()
                    Return String.Empty
                Else
                    retVal = Trim(rdr.GetString(1))
                    rdr.Close()
                    Return retVal
                End If
            End If
            Return Nothing
        Catch ex As Exception
            MsgBox("SqlDataReader failed in GetDepositCheckImageDirectory. " + ex.Message)
            Return Nothing
        Finally
            If Not leaveConnOpen Then
                conn.Close()
            End If
        End Try
        Return retVal
    End Function


    Public Function SetDepositTicket(ByVal ticket As DepositTicketClass) As DepositTicketClass
        If DepositExists(ticket, True) Then
            Return UpdateDepositTicket(ticket)
        Else
            Return InsertDepositTicket(ticket)
        End If
    End Function

    Public Function UpdateDepositTicket(ByVal ticket As DepositTicketClass) As DepositTicketClass
        Dim sqlCmd As New SqlCommand("UPDATE dbo.DonationDeposits SET Number = @Number, DepositNo = @DepositNo, DepDate = @DepDate, " _
            + "DepDescript = @DepDescript, BankId = @BankID, AccountId = @AccountId, ImagePath = @ImagePath " _
            + " WHERE DepositNo = '" + ticket.DepositNumber.Trim + "'", conn)
        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
        sqlCmd.Parameters.Add("@Number", SqlDbType.Int).Value = CInt(ticket.DepositNumber.Substring(3))
        sqlCmd.Parameters.Add("@DepositNo", SqlDbType.VarChar, 10).Value = ticket.DepositNumber.Trim
        sqlCmd.Parameters.Add("@DepDate", SqlDbType.DateTime, 8).Value = ticket.DepositDate
        sqlCmd.Parameters.Add("@DepDescript", SqlDbType.VarChar, 50).Value = ticket.Description.Trim
        sqlCmd.Parameters.Add("@BankId", SqlDbType.VarChar, 10).Value = ticket.BankInfo.DepositBankNo.Trim
        sqlCmd.Parameters.Add("@AccountId", SqlDbType.VarChar, 10).Value = ticket.BankInfo.AccountNo.Trim
        sqlCmd.Parameters.Add("@ImagePath", SqlDbType.NVarChar, 200).Value = ticket.CheckImagePath
        Try
            sqlCmd.Prepare()
            sqlCmd.ExecuteNonQuery()
            NotifyObservers(Me, New DepositEventArgs(EventName.evnmDepositInfoChanged, ticket))
            Return ticket
        Catch ex As Exception
            MsgBox("ExecuteNonQuery failed in UpdateDepositTicket. " + ex.Message)
        Finally
            conn.Close()
        End Try
        Return Nothing
    End Function

    Private Function InsertDepositTicket(ByVal ticket As DepositTicketClass) As DepositTicketClass
        Dim num As String = GetUniqueNo()
        Dim sqlCmd As New SqlCommand("INSERT INTO  dbo.DonationDeposits (Number, DepositNo, DepDate, DepDescript, " _
            + "BankId, AccountId, ImagePath) " _
            + " VALUES (@Number, @DepositNo, @DepDate, @DepDescript, @BankID, @AccountId, @ImagePath)", conn)
        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
        sqlCmd.Parameters.Add("@Number", SqlDbType.Int).Value = CInt(ticket.DepositNumber.Substring(3))
        sqlCmd.Parameters.Add("@DepositNo", SqlDbType.VarChar, 10).Value = num
        sqlCmd.Parameters.Add("@DepDate", SqlDbType.DateTime, 8).Value = ticket.DepositDate
        sqlCmd.Parameters.Add("@DepDescript", SqlDbType.VarChar, 50).Value = ticket.Description
        sqlCmd.Parameters.Add("@BankId", SqlDbType.VarChar, 10).Value = ticket.BankInfo.DepositBankNo
        sqlCmd.Parameters.Add("@AccountId", SqlDbType.VarChar, 10).Value = ticket.BankInfo.AccountNo
        sqlCmd.Parameters.Add("@ImagePath", SqlDbType.NVarChar, 200).Value = ticket.CheckImagePath
        Try
            sqlCmd.Prepare()
            sqlCmd.ExecuteNonQuery()
            NotifyObservers(Me, New DepositEventArgs(EventName.evnmDepositInfoChanged, ticket))
            Return GetDepositTicket(num, True)
        Catch ex As Exception
            MsgBox("ExecuteNonQuery failed in InsertDepositTicket. " + ex.Message)
        Finally
            conn.Close()
        End Try
        Return Nothing
    End Function

#End Region

#Region "Check  Methods - dbo.CheckDonations"

    Public Function CheckExists(ByVal chk As ChecksClass, ByVal leaveConnOpen As Boolean) As Boolean
        Dim sqlSelect As String = "SELECT DepositNo FROM CheckDonations " _
            + " WHERE DepositNo = '" + Trim(chk.DepositNo) + "' AND RoutingNo = '" + Trim(chk.RoutingNo) _
            + "' AND AccountNo = '" + Trim(chk.AccountNo) + "' AND CheckNo = '" + Trim(chk.CheckNo) + "'"
        Dim sqlCmd As New SqlCommand(sqlSelect, conn)
        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
        Try
            If IsNothing(sqlCmd.ExecuteScalar) Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("CheckExists ExecuteScalar failed. " + ex.Message)
        Finally
            If Not leaveConnOpen Then
                conn.Close()
            End If
        End Try
    End Function

    Public Function SetChecksClass(ByVal chkargs As CheckDataEventArgs, ByVal leaveConnOpen As Boolean) As Integer

        Dim sqlCmd As New SqlCommand
        sqlCmd.CommandType = CommandType.StoredProcedure
        sqlCmd.CommandText = "[spSetCheck2]"
        sqlCmd.Connection = Me.conn
        If Not Me.conn.State = ConnectionState.Open Then
            Me.conn.Open()
        End If
        Try
            sqlCmd.Parameters.Add("@DepositNo", SqlDbType.NVarChar)
            sqlCmd.Parameters.Item("@DepositNo").Direction = ParameterDirection.Input
            sqlCmd.Parameters.Item("@DepositNo").Value = Trim(chkargs.modCheck.DepositNo)

            sqlCmd.Parameters.Add("@RoutingNo", SqlDbType.NVarChar)
            sqlCmd.Parameters.Item("@RoutingNo").Direction = ParameterDirection.Input
            sqlCmd.Parameters.Item("@RoutingNo").Value = Trim(chkargs.modCheck.RoutingNo)

            sqlCmd.Parameters.Add("@AccountNo", SqlDbType.NVarChar)
            sqlCmd.Parameters.Item("@AccountNo").Direction = ParameterDirection.Input
            sqlCmd.Parameters.Item("@AccountNo").Value = Trim(chkargs.modCheck.AccountNo)

            sqlCmd.Parameters.Add("@CheckNo", SqlDbType.NVarChar)
            sqlCmd.Parameters.Item("@CheckNo").Direction = ParameterDirection.Input
            sqlCmd.Parameters.Item("@CheckNo").Value = Trim(chkargs.modCheck.CheckNo)

            sqlCmd.Parameters.Add("@DonorNo", SqlDbType.NVarChar)
            sqlCmd.Parameters.Item("@DonorNo").Direction = ParameterDirection.Input
            sqlCmd.Parameters.Item("@DonorNo").Value = Trim(chkargs.modCheck.Donor)

            sqlCmd.Parameters.Add("@CheckDate", SqlDbType.DateTime)
            sqlCmd.Parameters.Item("@CheckDate").Direction = ParameterDirection.Input
            sqlCmd.Parameters.Item("@CheckDate").Value = chkargs.modCheck.CheckDate

            sqlCmd.Parameters.Add("@CheckAmount", SqlDbType.Decimal)
            sqlCmd.Parameters.Item("@CheckAmount").Direction = ParameterDirection.Input
            sqlCmd.Parameters.Item("@CheckAmount").Value = chkargs.modCheck.CheckAmount


            sqlCmd.Parameters.Add("@CheckStatus", SqlDbType.NVarChar)
            sqlCmd.Parameters.Item("@CheckStatus").Direction = ParameterDirection.Input
            sqlCmd.Parameters.Item("@CheckStatus").Value = [Enum].GetName(GetType(CheckStatus), chkargs.modCheck.Status)

            sqlCmd.Parameters.Add("@ReceiptStatus", SqlDbType.Int)
            sqlCmd.Parameters.Item("@ReceiptStatus").Direction = ParameterDirection.Input
            sqlCmd.Parameters.Item("@ReceiptStatus").Value = chkargs.modCheck.ReceiptRequest

            sqlCmd.Parameters.Add("@ImageFile", SqlDbType.NVarChar)
            sqlCmd.Parameters.Item("@ImageFile").Direction = ParameterDirection.Input
            sqlCmd.Parameters.Item("@ImageFile").Value = chkargs.modCheck.ImageFile

            sqlCmd.Parameters.Add("@Manual", SqlDbType.NChar)
            sqlCmd.Parameters.Item("@Manual").Direction = ParameterDirection.Input
            sqlCmd.Parameters.Item("@Manual").Value = chkargs.modCheck.ManualCheck

            sqlCmd.Parameters.Add("@TargetAccount", SqlDbType.NVarChar)
            sqlCmd.Parameters.Item("@TargetAccount").Direction = ParameterDirection.Input
            sqlCmd.Parameters.Item("@TargetAccount").Value = chkargs.Check.AccountNo

            sqlCmd.Parameters.Add("@TargetCheckNo", SqlDbType.NVarChar)
            sqlCmd.Parameters.Item("@TargetCheckNo").Direction = ParameterDirection.Input
            sqlCmd.Parameters.Item("@TargetCheckNo").Value = chkargs.Check.CheckNo

            sqlCmd.Parameters.Add("@RetVal", SqlDbType.Int)
            sqlCmd.Parameters.Item("@RetVal").Direction = ParameterDirection.ReturnValue

            sqlCmd.Prepare()
            Dim retVal As Integer = 0
            sqlCmd.ExecuteNonQuery()
            retVal = CInt(sqlCmd.Parameters("@RetVal").Value)
            If chkargs.modCheck.DonorInfo IsNot Nothing AndAlso chkargs.modCheck.Donor <> String.Empty Then
                Me.SetDonorInformation(chkargs.modCheck, True)
            End If
            Dim retCheck As ChecksClass = Me.GetChecksClass(chkargs.modCheck.DepositNo, chkargs.modCheck.RoutingNo, chkargs.modCheck.AccountNo, chkargs.modCheck.CheckNo)
            If retVal = 1 Then
                NotifyObservers(Me, New CheckDataEventArgs(EventName.evnmCheckUpdated, retCheck, retCheck))
                'NotifyObservers(Me, New CheckDataEventArgs(EventName.evnmCheckUpdated, chkargs.modCheck, chkargs.modCheck))
                Return DataTransactionTypes.dbUpdated
            ElseIf retVal = 2 Then
                'NotifyObservers(Me, New CheckDataEventArgs(EventName.evnmCheckInserted, chk, chk))
                NotifyObservers(Me, New CheckDataEventArgs(EventName.evnmCheckInserted, retCheck, retCheck))
                Return DataTransactionTypes.dbInserted
            Else
                NotifyObservers(Me, New CheckDataEventArgs(EventName.evnmDataTransactionFailed, chkargs.modCheck, chkargs.modCheck))
                Return DataTransactionTypes.dbFailed
            End If
        Catch ex As Exception
            MsgBox("Stored procedure [spSetCheck] ExecuteNonQuery in DataClass.SetCheck failed. " + ex.Message)
        Finally
            If Not leaveConnOpen Then
                Me.conn.Close()
            End If
        End Try
        Return 0
    End Function

    Public Function GetDepositCheckCount(ByVal depNo As String, ByVal leaveConnOpen As Boolean) As Integer
        Dim retVal As Integer = 0
        Dim sqlSelect As String = "SELECT COUNT(CheckNo) as CheckCnt FROM CheckDonations " _
             + " WHERE DepositNo = '" + depNo + "'"
        Dim sqlCmd As New SqlCommand(sqlSelect, conn)
        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
        Try
            Dim rdr As SqlDataReader = sqlCmd.ExecuteReader
            If rdr.Read Then
                retVal = rdr.GetInt32(0)
                rdr.Close()
            End If
            Return retVal
        Catch ex As Exception
            MsgBox("GetDepositCheckCount SqlDataReader failed. " + ex.Message)
        Finally
            If Not leaveConnOpen Then
                conn.Close()
            End If
        End Try

    End Function

    Public Function GetCheckListByStatus(ByVal depNo As String, ByVal chkStatus As CheckStatus) As List(Of ChecksClass)
        Dim sqlFilter As String = " AND d1.DepositNo = '" + Trim(depNo) + "' AND d1.CheckStatus = '" & [Enum].GetName(GetType(CheckStatus), chkStatus) + "' ORDER BY d1.CheckNo "
        Return GetChecksListBySqlString(sqlFilter)
    End Function

    Public Function GetCheckListByReceiptRequestStatus(ByVal depno As String, ByVal receiptStatus As ReceiptRequestStatus) As List(Of ChecksClass)
        Dim sqlFilter As String = " AND d1.DepositNo = '" + Trim(depno) + "' AND ((d1.ReceiptStatus & " + CStr(receiptStatus) + ") <> 0) ORDER BY d1.CheckNo "
        Return GetChecksListBySqlString(sqlFilter) '(([ReceiptStatus] & @ReceiptStatus) <> 0)
    End Function

    Public Function GetDepositCheckList(ByVal depNo As String) As List(Of ChecksClass)
        Dim sqlFilter As String = " AND d1.DepositNo = '" + Trim(depNo) + "' ORDER BY d1.CheckNo "
        Return GetChecksListBySqlString(sqlFilter)
    End Function

    Private Function GetChecksListBySqlString_old(ByVal sqlFilterStr As String) As List(Of ChecksClass)
        Dim sqlSelect As String = "SELECT d1.DepositNo, d1.RoutingNo, d1.AccountNo, d1.CheckNo, d1.DonorNo, " _
        & "d1.CheckDate, d1.CheckAmount, d1.CheckStatus, d1.ReceiptStatus, d1.ImageFile, d1.Manual, d2.ImagePath, " _
        & "d3.Address, d3.City, d3.State, d3.Zip, d3.Bank, d3.Account " _
        & "FROM CheckDonations AS d1 LEFT OUTER JOIN DonorInfo as d3 ON d3.Donor = d1.DonorNo JOIN DonationDeposits AS d2 " _
        & "ON d2.DepositNo = d1.DepositNo "

        Dim sqlCmd As New SqlCommand(sqlSelect & sqlFilterStr, conn)
        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
        Dim rdr As SqlDataReader
        rdr = sqlCmd.ExecuteReader
        Try
            Dim retClass As ChecksClass
            Dim retList As New List(Of ChecksClass)

            'd1.DepositNo 0, d1.RoutingNo 1, d1.AccountNo 2, d1.CheckNo 3, d1.DonorNo 4, d1.CheckDate 5, d1.CheckAmount 6
            'd1.CheckStatus 7, d1.ReceiptStatus 8, d1.ImageFile 9, d1.Manual 10, d2.ImagePath 11, d3.Address 12, d3.City 13
            'd3.State 14, d3.Zip 15, d3.Bank 16, d3.Ac

            While rdr.Read
                retClass = New ChecksClass(Trim(rdr.GetString(0)), Trim(rdr.GetString(1)), Trim(rdr.GetString(2)), Trim(rdr.GetString(3)), _
                    rdr.GetDateTime(5), rdr.GetDecimal(6), Trim(rdr.GetString(9)))
                retClass.Status = CType([Enum].Parse(GetType(CheckStatus), rdr.GetString(7)), CheckStatus)
                If IsDBNull(rdr.GetValue(8)) Then
                    retClass.ReceiptRequest = ReceiptRequestStatus.rrsNone
                Else
                    retClass.ReceiptRequest = CType([Enum].Parse(GetType(ReceiptRequestStatus), CStr(rdr.GetValue(8))), ReceiptRequestStatus)
                End If
                If IsDBNull(rdr.GetValue(10)) Then
                    retClass.ManualCheck = False
                Else
                    retClass.ManualCheck = Boolean.Parse(rdr.GetString(10))
                End If
                If IsDBNull(rdr.GetValue(11)) Then
                    retClass.ImageFullPath = String.Empty
                Else
                    retClass.ImageFullPath = Trim(rdr.GetString(11))
                    If Not retClass.ImageFullPath.EndsWith("\") Then
                        retClass.ImageFullPath += "\"
                    End If
                End If
                If Not IsDBNull(rdr.GetValue(4)) Then
                    retClass.DonorInfo = New DonorClass(rdr.GetString(4))
                    If IsDBNull(rdr.GetValue(12)) Then
                        retClass.DonorAddress = String.Empty
                    Else
                        retClass.DonorAddress = rdr.GetString(12)
                    End If
                    If IsDBNull(rdr.GetValue(13)) Then
                        retClass.DonorCity = String.Empty
                    Else
                        retClass.DonorCity = rdr.GetString(13)
                    End If
                    If IsDBNull(rdr.GetValue(14)) Then
                        retClass.DonorState = String.Empty
                    Else
                        retClass.DonorState = rdr.GetString(14)
                    End If
                    If IsDBNull(rdr.GetValue(15)) Then
                        retClass.DonorZip = String.Empty
                    Else
                        retClass.DonorZip = rdr.GetString(15)
                    End If
                    If IsDBNull(rdr.GetValue(16)) Then
                        retClass.DonorInfo.Bank = String.Empty
                    Else
                        retClass.DonorInfo.Bank = rdr.GetString(16)
                    End If
                    If IsDBNull(rdr.GetValue(17)) Then
                        retClass.DonorInfo.Account = String.Empty
                    Else
                        retClass.DonorInfo.Account = rdr.GetString(17)
                    End If
                End If
                retList.Add(retClass)
            End While
            Return retList
        Catch ex As Exception
            MsgBox("SqlDataReader failed in GetChecksListBySqlString. " + ex.Message)
            Return Nothing
        Finally
            rdr.Close()
            conn.Close()
        End Try

    End Function

    Private Function GetChecksListBySqlString(ByVal sqlFilterStr As String) As List(Of ChecksClass)
        Dim sqlSelect As String = "SELECT d1.DepositNo, d1.RoutingNo, d1.AccountNo, d1.CheckNo, d1.DonorNo, " _
                                  & "d1.CheckDate, d1.CheckAmount, d1.CheckStatus, d1.ReceiptStatus, d1.ImageFile, d1.Manual, d2.ImagePath " _
                                  & "FROM CheckDonations AS d1 JOIN DonationDeposits AS d2 " _
                                  & "ON d2.DepositNo = d1.DepositNo "

        Dim sqlCmd As New SqlCommand(sqlSelect & sqlFilterStr, conn)
        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
        Dim rdr As SqlDataReader
        rdr = sqlCmd.ExecuteReader
        Try
            Dim retClass As ChecksClass
            Dim retList As New List(Of ChecksClass)
            Dim retDonors As New List(Of String)

            'd1.DepositNo 0, d1.RoutingNo 1, d1.AccountNo 2, d1.CheckNo 3, d1.DonorNo 4, d1.CheckDate 5, d1.CheckAmount 6
            'd1.CheckStatus 7, d1.ReceiptStatus 8, d1.ImageFile 9, d1.Manual 10, d2.ImagePath 11

            While rdr.Read
                retClass = New ChecksClass(Trim(rdr.GetString(0)), Trim(rdr.GetString(1)), Trim(rdr.GetString(2)), Trim(rdr.GetString(3)), _
                    rdr.GetDateTime(5), rdr.GetDecimal(6), Trim(rdr.GetString(9)))
                If IsDBNull(rdr.GetValue(4)) Then
                    retDonors.Add(String.Empty)
                Else
                    retDonors.Add(rdr.GetString(4).Trim)
                End If

                retClass.Status = CType([Enum].Parse(GetType(CheckStatus), rdr.GetString(7)), CheckStatus)
                If IsDBNull(rdr.GetValue(8)) Then
                    retClass.ReceiptRequest = ReceiptRequestStatus.rrsNone
                Else
                    retClass.ReceiptRequest = CType([Enum].Parse(GetType(ReceiptRequestStatus), CStr(rdr.GetValue(8))), ReceiptRequestStatus)
                End If
                If IsDBNull(rdr.GetValue(10)) Then
                    retClass.ManualCheck = False
                Else
                    retClass.ManualCheck = Boolean.Parse(rdr.GetString(10))
                End If
                If IsDBNull(rdr.GetValue(11)) Then
                    retClass.ImageFullPath = String.Empty
                Else
                    retClass.ImageFullPath = Trim(rdr.GetString(11))
                    If Not retClass.ImageFullPath.EndsWith("\") Then
                        retClass.ImageFullPath += "\"
                    End If
                End If
                retList.Add(retClass)
            End While
            rdr.Close()
            For i As Integer = 0 To retList.Count - 1
                If retDonors(i) <> String.Empty Then
                    retList(i).DonorInfo = Me.GetDonorInfo(retDonors(i))(0)
                End If
                If retList(i).DonorInfo Is Nothing Then
                    retList(i).DonorInfo = Me.GetDonorInfoByAccount(retList(i).RoutingNo, retList(i).AccountNo)
                End If
            Next
            Return retList
        Catch ex As Exception
            MsgBox("SqlDataReader failed in GetChecksListBySqlString. " + ex.Message)
            Return Nothing
        Finally
            rdr.Close()
            conn.Close()
        End Try
    End Function

    Public Function GetChecksClass(ByVal depNo As String, ByVal rtg As String, ByVal acctNo As String, ByVal chkNo As String) As ChecksClass
        Dim retClass As ChecksClass = Nothing
        Dim retDonor As String = String.Empty
        Dim sqlSelect As String = "Execute  [spGetCheck] @DepositNo = '" & depNo.Trim & "', @RoutingNo = '" & rtg.Trim & "', @AccountNo = '" & acctNo.Trim & "', @CheckNo = '" & chkNo.Trim & "'"
        Dim sqlCmd As New SqlCommand(sqlSelect, conn)
        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
        Try
            Dim rdr As SqlDataReader = sqlCmd.ExecuteReader
            'DepositNo 0,RoutingNo 1,AccountNo 2,CheckNo 3,DonorNo 4,CheckDate 5,CheckAmount 6,CheckStatus 7,ReceiptStatus 8,ImageFile 9,Manual 10

            If rdr.Read Then
                If IsDBNull(rdr.GetValue(0)) Then
                    retClass = Nothing
                Else
                    retClass = New ChecksClass(depNo, rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), _
                        rdr.GetDateTime(5), rdr.GetDecimal(6), rdr.GetString(9))
                    retClass.Status = CType([Enum].Parse(GetType(CheckStatus), rdr.GetString(7)), CheckStatus)
                    retClass.ReceiptRequest = CType([Enum].Parse(GetType(ReceiptRequestStatus), CStr(rdr.GetValue(8))), ReceiptRequestStatus)
                    If IsDBNull(rdr.GetValue(10)) Then
                        retClass.ManualCheck = False
                    Else
                        retClass.ManualCheck = Boolean.Parse(rdr.GetString(10))
                    End If

                    If IsDBNull(rdr.GetString(4)) Then
                        retDonor = String.Empty
                    Else
                        retDonor = rdr.GetString(4)
                    End If
                    rdr.Close()
                    retClass.ImageFullPath = GetDepositCheckImageDirectory(depNo, True)
                    If Not retClass.ImageFullPath.EndsWith("\") Then
                        retClass.ImageFullPath += "\"
                    End If
                    If retDonor <> String.Empty Then
                        retClass.DonorInfo = Me.GetDonorInfo(retDonor)(0)
                    End If
                    If retClass.DonorInfo Is Nothing Then
                        retClass.DonorInfo = Me.GetDonorInfoByAccount(retClass.RoutingNo, retClass.AccountNo)
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox("GetChecksClass SqlDataReader failed. " + ex.Message)
        Finally
            conn.Close()
        End Try
        Return retClass
    End Function

    Public Function GetChecksDepositTotal(ByVal depNo As String, ByVal leaveConnOpen As Boolean) As Single
        Dim retVal As Single
        Dim sqlSelect As String = "SELECT SUM(CheckAmount) FROM CheckDonations " _
             + " WHERE DepositNo = '" + depNo + "'"
        Dim sqlCmd As New SqlCommand(sqlSelect, conn)
        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
        Try
            Dim rdr As SqlDataReader = sqlCmd.ExecuteReader
            If rdr.Read AndAlso Not rdr.IsDBNull(0) Then
                retVal = rdr.GetDecimal(0)
            End If
            rdr.Close()
            Return retVal
        Catch ex As Exception
            MsgBox("GetChecksDepositTotal SqlDataReader failed. " + ex.Message)
        Finally
            If Not leaveConnOpen Then
                conn.Close()
            End If
        End Try
    End Function

    Public Function ChecksStatusExists(ByVal depNo As String, ByVal status As CheckStatus) As Boolean
        Dim sqlSelect As String = "SELECT DepositNo, CheckStatus FROM CheckDonations " _
            + " WHERE DepositNo = '" + Trim(depNo) + "' AND CheckStatus = " & status
        Dim sqlCmd As New SqlCommand(sqlSelect, conn)
        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
        Try
            If IsNothing(sqlCmd.ExecuteScalar) Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ChecksStatusExists ExecuteScalar failed. " + ex.Message)
        Finally
            conn.Close()
        End Try
    End Function

    Public Function ChecksUnverifiedStatusExists(ByVal depNo As String) As Boolean
        Dim sqlSelect As String = "SELECT DepositNo, CheckStatus FROM CheckDonations " _
            + " WHERE DepositNo = '" + Trim(depNo) + "' AND CheckStatus <> '" & [Enum].GetName(GetType(CheckStatus), CheckStatus.csVerified) & "'"

        Dim sqlCmd As New SqlCommand(sqlSelect, conn)
        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
        Try
            If IsNothing(sqlCmd.ExecuteScalar) Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ChecksUnverifiedStatusExists ExecuteScalar failed. " + ex.Message)
        Finally
            conn.Close()
        End Try
    End Function

    Public Sub UpdateChecksClassStatus(ByVal chkArgs As CheckDataEventArgs)
        Dim sqlUpdate As String = String.Empty
        If CheckExists(chkArgs.Check, False) Then
            sqlUpdate = "UPDATE CheckDonations " _
                    + "SET CheckStatus = '" + [Enum].GetName(GetType(CheckStatus), chkArgs.modCheck.Status) _
                    + "' WHERE DepositNo = '" + Trim(chkArgs.Check.DepositNo) + "' AND RoutingNo = '" + Trim(chkArgs.Check.RoutingNo) _
                    + "' AND AccountNo = '" + Trim(chkArgs.Check.AccountNo) + "' AND CheckNo = '" + Trim(chkArgs.Check.CheckNo) + "'"
            Dim sqlCmd As New SqlCommand(sqlUpdate, conn)
            If Not conn.State = ConnectionState.Open Then
                conn.Open()
            End If
            Try
                If sqlCmd.ExecuteNonQuery() > 0 Then
                    NotifyObservers(Me, New CheckDataEventArgs(EventName.evnmCheckStatusChanged, chkArgs.Check, chkArgs.modCheck))
                Else
                    NotifyObservers(Me, New CheckDataEventArgs(EventName.evnmDataTransactionFailed, chkArgs.Check, chkArgs.modCheck))
                End If
            Catch ex As Exception
                MsgBox("UpdateChecksClassStatus ExecuteNonQuery failed. " + ex.Message)
            Finally
                conn.Close()
            End Try
        End If
    End Sub

    Public Function DeleteCheckDonation(ByVal chk As ChecksClass, ByVal delImage As Boolean) As DataTransactionTypes
        If CheckExists(chk, True) Then
            Dim sqlText As String = "DELETE FROM CheckDonations " _
                + " WHERE DepositNo = '" + Trim(chk.DepositNo) + "' AND RoutingNo = '" + chk.RoutingNo + "' AND AccountNo = '" + chk.AccountNo + "' AND CheckNo = '" + chk.CheckNo + "'"
            Dim sqlCmd As New SqlCommand(sqlText, conn)
            If Not conn.State = ConnectionState.Open Then
                conn.Open()
            End If
            Try
                If sqlCmd.ExecuteNonQuery() > 0 Then
                    If delImage Then
                        NotifyObservers(Me, New CheckDataEventArgs(EventName.evnmCheckDeleted, chk, chk))
                    Else
                        NotifyObservers(Me, New CheckDataEventArgs(EventName.evnmCheckOnlyDeleted, chk, chk))
                    End If
                    Return DataTransactionTypes.dbDeleted
                Else
                    MsgBox("Delete Failed at DataClass")
                    NotifyObservers(Me, New CheckDataEventArgs(EventName.evnmDataTransactionFailed, chk, chk))
                    Return DataTransactionTypes.dbFailed
                End If
            Catch ex As Exception
                MsgBox("DeleteCheckDonation ExecuteNonQuery failed. " + ex.Message)
            Finally
                conn.Close()
            End Try
        End If
    End Function
    '[spGetChecksByReceiptRequest]
    Public Function GetChecksclassList(ByVal queryParameters As String) As List(Of ChecksClass)
        Dim sqlSelect As String = "Execute  [spGetChecksList] " & queryParameters
        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
        Dim sqlCmd As New SqlCommand(sqlSelect, Me.conn)
        Dim rdr As SqlDataReader = sqlCmd.ExecuteReader
        Dim retList As New List(Of ChecksClass)
        Try
            Dim retClass As ChecksClass = Nothing
            Dim retDonors As New List(Of String)

            '[DepositNo 0],[RoutingNo 1],[AccountNo 2],[CheckNo 3],[DonorNo 4],[CheckDate 5],[CheckAmount 6]
            '[CheckStatus 7],[ReceiptStatus 8],[ImageFile 9],[Manual 10], [ImagePath 11] 
            While rdr.Read
                retClass = New ChecksClass(Trim(rdr.GetString(0)), Trim(rdr.GetString(1)), Trim(rdr.GetString(2)), Trim(rdr.GetString(3)), _
                    rdr.GetDateTime(5), rdr.GetDecimal(6), Trim(rdr.GetString(9)))
                retClass.Status = CType([Enum].Parse(GetType(CheckStatus), rdr.GetString(7)), CheckStatus)
                retClass.ReceiptRequest = CType([Enum].Parse(GetType(ReceiptRequestStatus), CStr(rdr.GetValue(8))), ReceiptRequestStatus)
                If IsDBNull(rdr.GetValue(4)) Then
                    retDonors.Add(String.Empty)
                Else
                    retDonors.Add(rdr.GetString(4).Trim)
                End If
                If Not IsDBNull(rdr.GetValue(11)) Then
                    retClass.ImageFullPath = rdr.GetString(11).Trim
                End If
                If IsDBNull(rdr.GetValue(10)) Then
                    retClass.ManualCheck = False
                Else
                    retClass.ManualCheck = Boolean.Parse(rdr.GetString(10))
                End If
                retList.Add(retClass)
            End While
            rdr.Close()
            For i As Integer = 0 To retList.Count - 1
                If retDonors(i) <> String.Empty Then
                    retList(i).DonorInfo = Me.GetDonorInfo(retDonors(i))(0)
                End If
                If retList(i).DonorInfo Is Nothing Then
                    retList(i).DonorInfo = Me.GetDonorInfoByAccount(retList(i).RoutingNo, retList(i).AccountNo)
                End If
            Next
        Catch ex As Exception
            MsgBox("spGetChecksList failed in GetChecksclassByReceiptStatus. " + ex.Message)
            Return Nothing
        Finally
            rdr.Close()
            conn.Close()
        End Try
        Return retList
    End Function

    Public Function HandleSearchRequest(ByVal queryString As String) As List(Of ChecksClass)
        Return Me.GetChecksclassList(queryString)
    End Function

    'GetChecksClass SQLReader
#End Region

#Region "Cash Methods - dbo.CashDonations"

    Public Function CashDenomExists(ByVal depNo As String, ByVal denom As CashType) As Boolean
        Dim sql As String = "SELECT DepositNo, CurrencyType FROM CashDonations " _
            + " WHERE DepositNo = '" + depNo.Trim + "' AND CurrencyType = '" + System.Enum.GetName(GetType(CashType), denom) + "'"
        Dim sqlCmd As New SqlCommand(sql, conn)
        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
        Try
            If IsNothing(sqlCmd.ExecuteScalar) Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("CashDenomExists ExecuteScalar failed. " + ex.Message)
        Finally
            conn.Close()
        End Try
    End Function

    Public Function SetCashDenomClass(ByVal cash As CashClass) As DataTransactionTypes
        If CashDenomExists(cash.DepositNo, cash.Denomination) Then
            Return UpdateCashDenomClass(cash)
        Else
            Return InsertCashDenom(cash)
        End If
    End Function

    Private Function InsertCashDenom(ByVal cash As CashClass) As DataTransactionTypes
        Dim sql As String = "INSERT INTO CashDonations (DepositNo, CurrencyType, Quantity, ValueEach) " _
            + " VALUES (@DepositNo, @CurrencyType, @Quantity, @ValueEach)"
        Dim sqlCmd As New SqlCommand(sql, conn)
        sqlCmd.Parameters.Add("@DepositNo", SqlDbType.VarChar, 10).Value = cash.DepositNo
        sqlCmd.Parameters.Add("@CurrencyType", SqlDbType.VarChar, 25).Value = System.Enum.GetName(GetType(CashType), cash.Denomination)
        sqlCmd.Parameters.Add("@Quantity", SqlDbType.Int, 4).Value = cash.Count
        If cash.Denomination = CashType.DollarCoin Then
            sqlCmd.Parameters.Add("@ValueEach", SqlDbType.Money, 8).Value = 100
        Else
            sqlCmd.Parameters.Add("@ValueEach", SqlDbType.Money, 8).Value = cash.Denomination
        End If
        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
        Try
            sqlCmd.Prepare()
            If sqlCmd.ExecuteNonQuery() > 0 Then
                NotifyObservers(Me, New CashEventArgs(EventName.evnmCashClassAdded, cash))
                Return DataTransactionTypes.dbInserted
            Else
                NotifyObservers(Me, New CashEventArgs(EventName.evnmDataTransactionFailed, cash))
                Return DataTransactionTypes.dbFailed
            End If
        Catch ex As Exception
            MsgBox("InsertCashDenom ExecuteNonQuery failed. " + ex.Message)
        Finally
            conn.Close()
        End Try
    End Function

    Public Function UpdateCashDenomClass(ByVal cash As CashClass) As DataTransactionTypes
        Dim sql As String = "UPDATE CashDonations " _
            + " SET Quantity = " + cash.Count.ToString _
            + " WHERE DepositNo = '" + cash.DepositNo.Trim + "' AND CurrencyType = '" + System.Enum.GetName(GetType(CashType), cash.Denomination) + "'"
        Dim sqlCmd As New SqlCommand(sql, conn)
        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
        Try
            If sqlCmd.ExecuteNonQuery() > 0 Then
                NotifyObservers(Me, New CashEventArgs(EventName.evnmCashClassUpdated, cash))
                Return DataTransactionTypes.dbUpdated
            Else
                NotifyObservers(Me, New CashEventArgs(EventName.evnmDataTransactionFailed, cash))
                Return DataTransactionTypes.dbFailed
            End If
        Catch ex As Exception
            MsgBox("UpdateCashDenomClass ExecuteNonQuery failed. " + ex.Message)
        Finally
            conn.Close()
        End Try
    End Function

    Public Function GetCashDenomCount(ByVal depNo As String, ByVal denom As CashType) As Integer
        Dim sql As String = "SELECT DepositNo, CurrencyType, Quantity  " _
            + "FROM CashDonations WHERE DepositNo = '" + depNo + "' AND CurrencyType = '" + System.Enum.GetName(GetType(CashType), denom) + "'"
        Dim cmd As New SqlCommand(sql, conn)
        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
        Try
            Dim reader As SqlDataReader = cmd.ExecuteReader
            While reader.Read
                If Not reader.IsDBNull(2) Then
                    Return reader.GetInt32(2)
                End If
            End While
        Catch ex As Exception
            MsgBox("GetCashDenomCount SqlDataReader failed. " + ex.Message)
        Finally
            conn.Close()
        End Try
    End Function

    Public Function GetCashDenomClass(ByVal depNo As String, ByVal denom As CashType) As CashClass
        Dim sqlSelect As String = "SELECT DepositNo, CurrencyType, Quantity FROM CashDonations " _
            + " WHERE DepositNo = '" + depNo + "' AND CurrencyType = '" + System.Enum.GetName(GetType(CashType), denom) + "'"
        Dim sqlCmd As New SqlCommand(sqlSelect, conn)
        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
        Try
            Dim rdr As SqlDataReader = sqlCmd.ExecuteReader
            Dim retClass As New CashClass(depNo, denom)
            If rdr.Read Then
                retClass.Count = CInt(rdr.GetValue(2))
                rdr.Close()
            Else
                rdr.Close()
                conn.Close()
                InsertCashDenom(retClass)
            End If
            Return retClass
        Catch ex As Exception
            MsgBox("GetCashDenomClass SqlDataReader failed. " + ex.Message)
            Return Nothing
        Finally
            conn.Close()
        End Try
    End Function

    Public Function GetCashDepositTotal(ByVal depNo As String, ByVal leaveConnOpen As Boolean) As Single
        Dim retVal As Single
        Dim sqlSelect As String = "SELECT SUM(Quantity * ValueEach) FROM CashDonations " _
             + " WHERE DepositNo = '" + depNo + "'"
        Dim sqlCmd As New SqlCommand(sqlSelect, conn)
        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
        Try
            Dim rdr As SqlDataReader = sqlCmd.ExecuteReader
            If rdr.Read AndAlso Not rdr.IsDBNull(0) Then
                retVal = rdr.GetDecimal(0)
            End If
            rdr.Close()
            Return retVal
        Catch ex As Exception
            MsgBox("GetCashDepositTotal SqlDataReader failed. " + ex.Message)
        Finally
            If Not leaveConnOpen Then
                conn.Close()
            End If
        End Try

    End Function

    Public Function GetCoinDepositTotal(ByVal depNo As String, ByVal leaveConnOpen As Boolean) As Single
        Dim retVal As Single
        Dim sqlSelect As String = "SELECT SUM(Quantity * ValueEach) FROM CashDonations " _
             + " WHERE DepositNo = '" + depNo.Trim + "' AND (ValueEach < 100.00 OR CurrencyType =  'DollarCoin')"
        Dim sqlCmd As New SqlCommand(sqlSelect, conn)
        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
        Try
            Dim rdr As SqlDataReader = sqlCmd.ExecuteReader
            If rdr.Read AndAlso Not rdr.IsDBNull(0) Then
                retVal = rdr.GetDecimal(0)
            End If
            rdr.Close()
            Return retVal / 100
        Catch ex As Exception
            MsgBox("GetCoinDepositTotal SqlDataReader failed. " + ex.Message)
        Finally
            If Not leaveConnOpen Then
                conn.Close()
            End If
        End Try

    End Function

    Public Function GetCurrencyDepositTotal(ByVal depNo As String, ByVal leaveConnOpen As Boolean) As Single
        Dim retVal As Single
        Dim sqlSelect As String = "SELECT SUM(Quantity * ValueEach) FROM CashDonations " _
             + " WHERE DepositNo = '" + depNo.Trim + "' AND (ValueEach > 100.00 OR CurrencyType = 'One')"
        Dim sqlCmd As New SqlCommand(sqlSelect, conn)
        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
        Try
            Dim rdr As SqlDataReader = sqlCmd.ExecuteReader
            If rdr.Read AndAlso Not rdr.IsDBNull(0) Then
                retVal = rdr.GetDecimal(0)
            End If
            rdr.Close()
            Return retVal / 100
        Catch ex As Exception
            MsgBox("GetCurrencyDepositTotal SqlDataReader failed. " + ex.Message)
        Finally
            If Not leaveConnOpen Then
                conn.Close()
            End If
        End Try

    End Function
#End Region

#Region "Donor Information Methods dbo.donorinfo"

    '    [spGetDonorInfo2] 
    '[DonorID 0],[Donor 1],[Address 2],[City 3],[State 4],[Zip5],[Envelope6],[Bank7],[Account8] 
    Public Function GetDonorInfo(Optional ByVal donor As String = "") As List(Of DonorClass)
        Dim retList As New List(Of DonorClass)
        Dim sqlSelect As String = "Execute  [spGetDonorInfo2] "
        If donor <> String.Empty Then
            sqlSelect += "@Donor = '" & donor & "'"
        End If
        Dim sqlCmd As New SqlCommand(sqlSelect, Me.conn)
        If Not Me.conn.State = ConnectionState.Open Then
            Me.conn.Open()
        End If
        Dim rdr As SqlDataReader = sqlCmd.ExecuteReader
        Try
            While rdr.Read
                Dim retClass As DonorClass = New DonorClass(rdr.GetString(0))
                retClass.Address = rdr.GetString(2)
                retClass.City = rdr.GetString(3)
                retClass.State = rdr.GetString(4)
                retClass.Zip = rdr.GetString(5)
                If IsDBNull(rdr.GetValue(6)) Then
                    retClass.EnvelopeNo = String.Empty
                Else
                    retClass.EnvelopeNo = rdr.GetString(6)
                End If
                If IsDBNull(rdr.GetValue(7)) Then
                    retClass.Bank = String.Empty
                Else
                    retClass.Bank = rdr.GetString(7)
                End If
                If IsDBNull(rdr.GetValue(8)) Then
                    retClass.Account = String.Empty
                Else
                    retClass.Account = rdr.GetString(8)
                End If
                retList.Add(retClass)
            End While
            If retList.Count > 0 AndAlso retList(0) IsNot Nothing Then
                Return retList
            End If
        Catch ex As Exception
            MsgBox("GetDonorInfo [spGetDonorInfo2] SqlDataReader failed. " + ex.Message)
        Finally
            rdr.Close()
            conn.Close()
        End Try
        Return Nothing
    End Function

    Public Function GetDonorInfoByAccount(ByVal bank As String, acct As String) As DonorClass
        '[DonorID 0],[Donor 1],[Address 2],[City 3],[State 4],[Zip5]
        Dim retClass As DonorClass = Nothing
        Dim sqlSelect As String = "Execute  [spGetDonorInfoByAcct] @Bank = '" & bank & "', @Account = '" & acct & "'"
        Dim sqlCmd As New SqlCommand(sqlSelect, Me.conn)
        If Not Me.conn.State = ConnectionState.Open Then
            Me.conn.Open()
        End If
        Try
            Dim rdr As SqlDataReader = sqlCmd.ExecuteReader
            If rdr.Read Then
                retClass = New DonorClass(rdr.GetString(0))
                retClass.Address = rdr.GetString(2)
                retClass.City = rdr.GetString(3)
                retClass.State = rdr.GetString(4)
                retClass.Zip = rdr.GetString(5)
            End If
            rdr.Close()
        Catch ex As Exception
            MsgBox("GetDonorInfoByAccountNo SqlDataReader failed. " + ex.Message)
        Finally
            conn.Close()
        End Try
        Return retClass
    End Function

    Private Function SetDonorInformation(ByVal chk As ChecksClass, ByVal leaveConnOpen As Boolean) As Integer
        Dim sqlCmd As New SqlCommand
        sqlCmd.CommandType = CommandType.StoredProcedure
        sqlCmd.CommandText = "[spSetDonorInfo2]"
        sqlCmd.Connection = Me.conn
        If Not Me.conn.State = ConnectionState.Open Then
            Me.conn.Open()
        End If
        Try
            sqlCmd.Parameters.Add("@DonorID", SqlDbType.NVarChar)
            sqlCmd.Parameters.Item("@DonorID").Direction = ParameterDirection.Input
            sqlCmd.Parameters.Item("@DonorID").Value = Trim(chk.Donor)

            sqlCmd.Parameters.Add("@Donor", SqlDbType.NVarChar)
            sqlCmd.Parameters.Item("@Donor").Direction = ParameterDirection.Input
            sqlCmd.Parameters.Item("@Donor").Value = Trim(chk.Donor)

            sqlCmd.Parameters.Add("@Address", SqlDbType.NVarChar)
            sqlCmd.Parameters.Item("@Address").Direction = ParameterDirection.Input
            sqlCmd.Parameters.Item("@Address").Value = Trim(chk.DonorAddress)

            sqlCmd.Parameters.Add("@City", SqlDbType.NVarChar)
            sqlCmd.Parameters.Item("@City").Direction = ParameterDirection.Input
            sqlCmd.Parameters.Item("@City").Value = Trim(chk.DonorCity)

            sqlCmd.Parameters.Add("@State", SqlDbType.NVarChar)
            sqlCmd.Parameters.Item("@State").Direction = ParameterDirection.Input
            sqlCmd.Parameters.Item("@State").Value = Trim(chk.DonorState)

            sqlCmd.Parameters.Add("@Zip", SqlDbType.NVarChar)
            sqlCmd.Parameters.Item("@Zip").Direction = ParameterDirection.Input
            sqlCmd.Parameters.Item("@Zip").Value = Trim(chk.DonorZip)

            sqlCmd.Parameters.Add("@Envelope", SqlDbType.NVarChar)
            sqlCmd.Parameters.Item("@Envelope").Direction = ParameterDirection.Input
            sqlCmd.Parameters.Item("@Envelope").Value = Trim(chk.DonorInfo.EnvelopeNo)

            sqlCmd.Parameters.Add("@Bank", SqlDbType.NVarChar)
            sqlCmd.Parameters.Item("@Bank").Direction = ParameterDirection.Input
            sqlCmd.Parameters.Item("@Bank").Value = Trim(chk.RoutingNo)

            sqlCmd.Parameters.Add("@Account", SqlDbType.NVarChar)
            sqlCmd.Parameters.Item("@Account").Direction = ParameterDirection.Input
            sqlCmd.Parameters.Item("@Account").Value = Trim(chk.AccountNo)

            sqlCmd.Parameters.Add("@RetStatus", SqlDbType.Int)
            sqlCmd.Parameters.Item("@RetStatus").Direction = ParameterDirection.ReturnValue

            sqlCmd.Prepare()
            sqlCmd.ExecuteNonQuery()
            Dim retVal As Integer = CInt(sqlCmd.Parameters("@RetStatus").Value)
            If retVal = 1 Then
                NotifyObservers(Me, New DonorInfoEventArgs(EventName.evnmDbCheckDonorUpdated, chk.DonorInfo, chk.Status))
                Return DataTransactionTypes.dbUpdated
            ElseIf retVal = 2 Then
                NotifyObservers(Me, New DonorInfoEventArgs(EventName.evnmDbCheckDonorInserted, chk.DonorInfo, chk.Status))
                Return DataTransactionTypes.dbInserted
            Else
                NotifyObservers(Me, New DonorInfoEventArgs(EventName.evnmDataTransactionFailed, chk.DonorInfo, chk.Status))
                Return DataTransactionTypes.dbFailed
            End If
        Catch ex As SqlException
            'MsgBox("SqlException: " & ex.Message)
            Dim errorMessages As New StringBuilder()
            Dim i As Integer
            For i = 0 To ex.Errors.Count - 1
                errorMessages.Append("Index #" & i.ToString() & ControlChars.NewLine _
                    & "Message: " & ex.Errors(i).Message & ControlChars.NewLine _
                    & "LineNumber: " & ex.Errors(i).LineNumber & ControlChars.NewLine _
                    & "Source: " & ex.Errors(i).Source & ControlChars.NewLine _
                    & "Procedure: " & ex.Errors(i).Procedure & ControlChars.NewLine)
            Next i
            MsgBox(errorMessages.ToString)
        Catch ex As Exception
            MsgBox("[spSetDonorInfo2] ExecuteNonQuery in SetDonorInformation failed. " + ex.Message)
        Finally
            If Not leaveConnOpen Then
                Me.conn.Close()
            End If
        End Try
        Return 0
    End Function

    Public Function SetDonorInformation(ByVal donor As DonorClass) As Integer
        Dim sqlCmd As New SqlCommand
        sqlCmd.CommandType = CommandType.StoredProcedure
        sqlCmd.CommandText = "[spSetDonorInfo2]"
        sqlCmd.Connection = Me.conn
        If Not Me.conn.State = ConnectionState.Open Then
            Me.conn.Open()
        End If
        Try
            sqlCmd.Parameters.Add("@DonorID", SqlDbType.NVarChar)
            sqlCmd.Parameters.Item("@DonorID").Direction = ParameterDirection.Input
            sqlCmd.Parameters.Item("@DonorID").Value = Trim(donor.Donor)

            sqlCmd.Parameters.Add("@Donor", SqlDbType.NVarChar)
            sqlCmd.Parameters.Item("@Donor").Direction = ParameterDirection.Input
            sqlCmd.Parameters.Item("@Donor").Value = Trim(donor.Donor)

            sqlCmd.Parameters.Add("@Address", SqlDbType.NVarChar)
            sqlCmd.Parameters.Item("@Address").Direction = ParameterDirection.Input
            sqlCmd.Parameters.Item("@Address").Value = Trim(donor.Address)

            sqlCmd.Parameters.Add("@City", SqlDbType.NVarChar)
            sqlCmd.Parameters.Item("@City").Direction = ParameterDirection.Input
            sqlCmd.Parameters.Item("@City").Value = Trim(donor.City)

            sqlCmd.Parameters.Add("@State", SqlDbType.NVarChar)
            sqlCmd.Parameters.Item("@State").Direction = ParameterDirection.Input
            sqlCmd.Parameters.Item("@State").Value = Trim(donor.State)

            sqlCmd.Parameters.Add("@Zip", SqlDbType.NVarChar)
            sqlCmd.Parameters.Item("@Zip").Direction = ParameterDirection.Input
            sqlCmd.Parameters.Item("@Zip").Value = Trim(donor.Zip)

            sqlCmd.Parameters.Add("@Envelope", SqlDbType.NVarChar)
            sqlCmd.Parameters.Item("@Envelope").Direction = ParameterDirection.Input
            sqlCmd.Parameters.Item("@Envelope").Value = Trim(donor.EnvelopeNo)

            sqlCmd.Parameters.Add("@Bank", SqlDbType.NVarChar)
            sqlCmd.Parameters.Item("@Bank").Direction = ParameterDirection.Input
            sqlCmd.Parameters.Item("@Bank").Value = Trim(donor.Bank)

            sqlCmd.Parameters.Add("@Account", SqlDbType.NVarChar)
            sqlCmd.Parameters.Item("@Account").Direction = ParameterDirection.Input
            sqlCmd.Parameters.Item("@Account").Value = Trim(donor.Account)

            sqlCmd.Parameters.Add("@RetStatus", SqlDbType.Int)
            sqlCmd.Parameters.Item("@RetStatus").Direction = ParameterDirection.ReturnValue

            sqlCmd.Prepare()
            sqlCmd.ExecuteNonQuery()
            Dim retVal As Integer = CInt(sqlCmd.Parameters("@RetStatus").Value)
            If retVal = 1 Then
                NotifyObservers(Me, New DonorInfoEventArgs(EventName.evnmDbCheckDonorUpdated, donor))
                Return DataTransactionTypes.dbUpdated
            ElseIf retVal = 2 Then
                NotifyObservers(Me, New DonorInfoEventArgs(EventName.evnmDbCheckDonorInserted, donor))
                Return DataTransactionTypes.dbInserted
            Else
                NotifyObservers(Me, New DonorInfoEventArgs(EventName.evnmDataTransactionFailed, donor))
                Return DataTransactionTypes.dbFailed
            End If
        Catch ex As SqlException
            'MsgBox("SqlException: " & ex.Message)
            Dim errorMessages As New StringBuilder()
            Dim i As Integer
            For i = 0 To ex.Errors.Count - 1
                errorMessages.Append("Index #" & i.ToString() & ControlChars.NewLine _
                    & "Message: " & ex.Errors(i).Message & ControlChars.NewLine _
                    & "LineNumber: " & ex.Errors(i).LineNumber & ControlChars.NewLine _
                    & "Source: " & ex.Errors(i).Source & ControlChars.NewLine _
                    & "Procedure: " & ex.Errors(i).Procedure & ControlChars.NewLine)
            Next i
            MsgBox(errorMessages.ToString)
        Catch ex As Exception
            MsgBox("[spSetDonorInfo2] ExecuteNonQuery in SetDonorInformation failed. " + ex.Message)
        Finally
            Me.conn.Close()
        End Try
        Return 0
    End Function

#End Region
End Class
