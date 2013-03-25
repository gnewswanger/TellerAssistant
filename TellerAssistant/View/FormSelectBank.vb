Public Class FormSelectBank

    Public Delegate Sub BankAccountEventHandler(ByVal sender As Object, ByVal e As BankAccountEventArgs)
    Public Shared Event BankAccountEvent As BankAccountEventHandler
    Public currBank As BankAccountClass
    Private isDirty As Boolean

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        pnlAddEdit.Location = New Point(0, 28)
        pnlSelectList.Location = New Point(0, 28)
    End Sub

    Public Sub InitializeList(ByVal bnkList As List(Of BankAccountClass))
        lvBankAccounts.Items.Clear()
        For Each acct As BankAccountClass In bnkList
            Dim itm As New ListViewItem
            itm.Text = acct.DepositBankNo.Trim
            itm.SubItems.Add(acct.DepositBank)
            itm.SubItems.Add(acct.DepositBankCity)
            itm.SubItems.Add(acct.DepositBankState)
            itm.SubItems.Add(acct.AccountType)
            itm.Tag = acct
            lvBankAccounts.Items.Add(itm)
        Next
    End Sub

    Private Sub frmSelectBank_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetToolBar1ButtonsVisible()
    End Sub

    Private Sub frmSelectBank_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If isDirty Then
            If MsgBox("Changes were made that were not saved. Do you want to continue?", MsgBoxStyle.YesNo, "Changes Were Not Saved!") = MsgBoxResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub lvBankAccounts_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvBankAccounts.SelectedIndexChanged
        SetToolBar1ButtonsVisible()
    End Sub

#Region "Visible Controls Methods"
    Private Sub SetToolBar1ButtonsVisible()
        btnAddAccount.Visible = pnlSelectList.Visible
        btnEditSelection.Visible = pnlSelectList.Visible
        btnDeleteSelection.Visible = pnlSelectList.Visible
        btnClose.Visible = pnlSelectList.Visible
        btnApply.Visible = pnlAddEdit.Visible
        btnCancel.Visible = pnlAddEdit.Visible
        SetToolBar1ButtonsEnabled()
    End Sub

    Private Sub SetToolBar1ButtonsEnabled()
        btnEditSelection.Enabled = lvBankAccounts.SelectedItems.Count > 0
        btnDeleteSelection.Enabled = lvBankAccounts.SelectedItems.Count > 0
        btnApply.Enabled = isDirty AndAlso AllFieldsAreFilled()

    End Sub

    Private Sub EditTextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles txtEditBankId.TextChanged, txtEditAcctId.TextChanged, txtEditAcctName.TextChanged, txtEditBankAddress.TextChanged, _
    txtEditBankCity.TextChanged, txtEditBankName.TextChanged, txtEditBankState.TextChanged, txtEditBankZip.TextChanged
        isDirty = True
        SetToolBar1ButtonsEnabled()
    End Sub
    Private Function AllFieldsAreFilled() As Boolean
        Return txtEditAcctId.Text.Length > 0 AndAlso txtEditAcctName.Text.Length > 0 AndAlso txtEditBankAddress.Text.Length > 0 _
        AndAlso txtEditBankCity.Text.Length > 0 AndAlso txtEditBankId.Text.Length > 0 AndAlso txtEditBankName.Text.Length > 0 _
        AndAlso txtEditBankState.Text.Length > 0 AndAlso txtEditBankZip.Text.Length > 0
    End Function
#End Region

#Region "Button Click Methods"
    Private Sub btnAddAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddAccount.Click
        pnlAddEdit.Visible = True
        pnlSelectList.Visible = False
        SetToolBar1ButtonsVisible()
        ClearEditFields()
    End Sub

    Private Sub btnEditSelection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditSelection.Click
        pnlAddEdit.Visible = True
        pnlSelectList.Visible = False
        SetToolBar1ButtonsVisible()
        SetEditFields(CType(lvBankAccounts.SelectedItems(0).Tag, BankAccountClass))
    End Sub

    Private Sub btnDeleteSelection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteSelection.Click
        If MsgBox("The Selected Account is about to be deleted.  Do you wish to continue?", MsgBoxStyle.YesNo, "Delete Selection") = MsgBoxResult.Yes Then
            RaiseEvent BankAccountEvent(Me, New BankAccountEventArgs(EventName.evnmBankInfoDeleted, CType(lvBankAccounts.SelectedItems(0).Tag, BankAccountClass)))

        End If
    End Sub

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        UpdateBankAccounts()
        pnlAddEdit.Visible = False
        pnlSelectList.Visible = True
        SetToolBar1ButtonsVisible()
        ClearEditFields()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        ClearEditFields()
        pnlAddEdit.Visible = False
        pnlSelectList.Visible = True
        SetToolBar1ButtonsVisible()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Close()
    End Sub

#End Region

#Region "Edit Fields Methods"
    Private Sub SetEditFields(ByVal acct As BankAccountClass)
        If acct IsNot Nothing Then
            txtEditBankId.Text = acct.DepositBankNo
            txtEditBankName.Text = acct.DepositBank
            txtEditBankAddress.Text = acct.DepositBankAddress
            txtEditBankCity.Text = acct.DepositBankCity
            txtEditBankState.Text = acct.DepositBankState
            txtEditBankZip.Text = acct.DepositBankZip
            txtEditAcctId.Text = acct.AccountNo
            txtEditAcctName.Text = acct.AccountName
            cmboEditAcctType.Text = acct.AccountType
            isDirty = False
        End If
    End Sub

    Private Sub ClearEditFields()
        txtEditBankId.Clear()
        txtEditBankName.Clear()
        txtEditBankAddress.Clear()
        txtEditBankCity.Clear()
        txtEditBankState.Clear()
        txtEditBankZip.Clear()
        txtEditAcctId.Clear()
        txtEditAcctName.Clear()
        cmboEditAcctType.SelectedIndex = 0
        isDirty = False
    End Sub

    Private Sub UpdateBankAccounts()
        Dim acct As New BankAccountClass(txtEditBankId.Text, txtEditAcctId.Text)
        acct.AccountName = txtEditAcctName.Text
        acct.AccountType = cmboEditAcctType.Text
        acct.DepositBank = txtEditBankName.Text
        acct.DepositBankAddress = txtEditBankAddress.Text
        acct.DepositBankCity = txtEditBankCity.Text
        acct.DepositBankState = txtEditBankState.Text
        acct.DepositBankZip = txtEditBankZip.Text
        RaiseEvent BankAccountEvent(Me, New BankAccountEventArgs(EventName.evnmBankInfoChanged, acct))
    End Sub

#End Region

End Class