Imports System.Threading
Imports System.ComponentModel
Imports System.Media
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class FormMain2012
    Implements IViewFrmMain

    Delegate Sub SetTextCallback(ByVal text As String)
    Delegate Sub SetConnectionTypeCallback(ByVal value As ConnectionType)
    Delegate Sub SetImageCallback(ByVal value As Image)
    Delegate Sub SetTwoIntegerCallback(ByVal val1 As Integer, ByVal val2 As Integer)
    Delegate Sub SetDateCallback(ByVal value As Date)
    Delegate Sub SetBooleanCallback(ByVal value As Boolean)
    Delegate Sub SetCheckListCallback(ByVal value As List(Of ChecksClass))
    Delegate Sub GenericEventHandler(ByVal sender As Object, ByVal e As EventArgs)
    Public Shared Event MainFormShowing As GenericEventHandler

    Private ctrlr As DepositManagerPresenter
    Private myPages(2) As TabPage
    Private isActivated As Boolean = False

#Region "Implemented Interface Methods"

    Public Property ChecksTotal() As Single Implements IViewFrmMain.ChecksTotal
        Get
            Return CSng(CStr(toolTextDepositTotal.Text))
        End Get
        Set(ByVal value As Single)
            toolTextDepositTotal.Text = value.ToString("C")
        End Set
    End Property

    Public WriteOnly Property DepositTicket() As DepositTicketClass Implements IViewFrmMain.DepositTicket
        Set(ByVal value As DepositTicketClass)
            txtDepositNo.Text = value.DepositNumber
            lblDepDate.Text = value.DepositDate.ToString("d")
            lblDepDescript.Text = value.Description
            toolTextBankInfo.Text = value.BankInfo.DepositBankNo + "  " + value.BankInfo.DepositBank
            ChecksTotal = value.DepositTotal
        End Set
    End Property

    Public ReadOnly Property NewDepositIsChecked() As Boolean Implements IViewFrmMain.NewDepositIsChecked
        Get
            Return ckbxNewDep.Checked
        End Get
    End Property

    Public Property ScannerConnectionMode() As ConnectionType Implements IViewFrmMain.ScannerConnectionMode
        Get
            If mnuFTP.Checked Then
                Return ConnectionType.ctFTP
            Else
                Return ConnectionType.ctRS232
            End If
        End Get
        Set(ByVal value As ConnectionType)
            If value = ConnectionType.ctFTP Then
                mnuFTP.Checked = True
            Else
                mnuRS232.Checked = True
            End If
        End Set
    End Property

    Public ReadOnly Property FilterYTDIsChecked() As Boolean Implements IViewFrmMain.FilterYTDIsChecked
        Get
            Return ckbxFilterYTD.Checked
        End Get
    End Property

    Public WriteOnly Property ListViewDeposits() As System.Collections.Generic.List(Of DepositTicketClass) Implements IViewFrmMain.ListViewDeposits
        Set(ByVal value As System.Collections.Generic.List(Of DepositTicketClass))
            lvDepositsList.Items.Clear()
            For Each dep As DepositTicketClass In value
                Dim itm As New ListViewItem
                itm.Text = dep.DepositNumber
                itm.SubItems.Add(dep.DepositDate.ToString)
                itm.SubItems.Add(dep.Description)
                itm.SubItems.Add(dep.DepositTotal.ToString("C"))
                itm.Tag = dep
                Dim group As ListViewGroup = New ListViewGroup(dep.DepositDate.ToString("Y"), dep.DepositDate.ToString("Y"))
                If lvDepositsList.Groups(group.Name) Is Nothing Then
                    lvDepositsList.Groups.Add(group)
                End If
                itm.Group = lvDepositsList.Groups(group.Name)
                lvDepositsList.Items.Add(itm)
            Next
        End Set
    End Property

    Public WriteOnly Property ListViewBanks() As System.Collections.Generic.List(Of BankAccountClass) Implements IViewFrmMain.ListViewBanks
        Set(ByVal value As System.Collections.Generic.List(Of BankAccountClass))
            Me.lvBankAccounts.Items.Clear()
            For Each acct As BankAccountClass In value
                Dim itm As New ListViewItem
                itm.Text = acct.AccountNo
                itm.SubItems.Add(acct.AccountType)
                itm.SubItems.Add(acct.DepositBank)
                'itm.SubItems.Add(acct.DepositBankAddress.Item(1))
                'itm.SubItems.Add(acct.DepositBankAddress.Item(2))
                'itm.SubItems.Add(acct.DepositBankNo.Trim)
                itm.Tag = acct
                Dim group As ListViewGroup = New ListViewGroup(acct.AccountType, acct.AccountType)
                If lvBankAccounts.Groups(group.Name) Is Nothing Then
                    lvBankAccounts.Groups.Add(group)
                End If
                itm.Group = lvBankAccounts.Groups(group.Name)
                Me.lvBankAccounts.Items.Add(itm)
            Next
        End Set
    End Property

    Public Property SelectedBank() As BankAccountClass Implements IViewFrmMain.SelectedBank
        Get
            If lvBankAccounts.SelectedItems.Count > 0 Then
                Return CType(lvBankAccounts.SelectedItems(0).Tag, BankAccountClass)
            End If
            Return Nothing
        End Get
        Set(ByVal value As BankAccountClass)
            Dim itm As New ListViewItem
            itm.Text = value.AccountNo
            itm.SubItems.Add(value.AccountType)
            itm.SubItems.Add(value.DepositBank)
            'itm.SubItems.Add(value.DepositBankAddress.Item(1))
            'itm.SubItems.Add(value.DepositBankAddress.Item(2))
            'itm.SubItems.Add(value.DepositBankNo.Trim)
            itm.Tag = value
            lvBankAccounts.FindItemWithText(itm.Text).Selected = True
        End Set
    End Property

    Public WriteOnly Property CashText() As CashClass Implements IViewFrmMain.CashText
        Set(ByVal value As CashClass)
            Select Case value.Denomination
                Case CashType.Penny
                    txtPenny.Text = (value.Count * value.CashTypeValue).ToString("C")
                Case CashType.Nickel
                    txtNickel.Text = (value.Count * value.CashTypeValue).ToString("C")
                Case CashType.Dime
                    txtDime.Text = (value.Count * value.CashTypeValue).ToString("C")
                Case CashType.Quarter
                    txtQuarter.Text = (value.Count * value.CashTypeValue).ToString("C")
                Case CashType.HalfDollar
                    txtHalfDollar.Text = (value.Count * value.CashTypeValue).ToString("C")
                Case CashType.DollarCoin
                    txtDollarCoin.Text = (value.Count * value.CashTypeValue).ToString("C")
                Case CashType.One
                    txtOne.Text = (value.Count * value.CashTypeValue).ToString("C")
                Case CashType.Five
                    txtFive.Text = (value.Count * value.CashTypeValue).ToString("C")
                Case CashType.Ten
                    txtTen.Text = (value.Count * value.CashTypeValue).ToString("C")
                Case CashType.Twenty
                    txtTwenty.Text = (value.Count * value.CashTypeValue).ToString("C")
                Case CashType.Fifty
                    txtFifty.Text = (value.Count * value.CashTypeValue).ToString("C")
                Case CashType.OneHundred
                    txtHundred.Text = (value.Count * value.CashTypeValue).ToString("C")
            End Select

        End Set
    End Property

    Public WriteOnly Property CashTextCount() As CashClass Implements IViewFrmMain.CashTextCount
        Set(ByVal value As CashClass)
            Select Case value.Denomination
                Case CashType.Penny
                    txtPennyCt.Text = value.Count.ToString
                Case CashType.Nickel
                    txtNickelCt.Text = value.Count.ToString
                Case CashType.Dime
                    txtDimeCt.Text = value.Count.ToString
                Case CashType.Quarter
                    txtQuarterCt.Text = value.Count.ToString
                Case CashType.HalfDollar
                    txtHalfDollarCt.Text = value.Count.ToString
                Case CashType.DollarCoin
                    txtDollarCoinCt.Text = value.Count.ToString
                Case CashType.One
                    txtOneCt.Text = value.Count.ToString
                Case CashType.Five
                    txtFiveCt.Text = value.Count.ToString
                Case CashType.Ten
                    txtTenCt.Text = value.Count.ToString
                Case CashType.Twenty
                    txtTwentyCt.Text = value.Count.ToString
                Case CashType.Fifty
                    txtFiftyCt.Text = value.Count.ToString
                Case CashType.OneHundred
                    txtHundredCt.Text = value.Count.ToString
                Case Else
                    Exit Property
            End Select
            CashText = value
        End Set
    End Property

    Public WriteOnly Property DepositTotals() As DepositBalanceClass Implements IViewFrmMain.DepositTotals
        Set(ByVal value As DepositBalanceClass)
            txtCoinTotal.Text = value.TotalCoins.ToString("C")
            txtCurrencyTotal.Text = value.TotalCurrency.ToString("C")
            txtCashTotal.Text = (value.TotalCoins + value.TotalCurrency).ToString("C")
            txtChecksTotal.Text = value.TotalChecks.ToString("C")
            toolTextDepositTotal.Text = value.TotalDeposit.ToString("C")
        End Set
    End Property

    Public WriteOnly Property MICRStatusFlyout() As String Implements IViewFrmMain.MICRStatusFlyout
        Set(ByVal value As String)
            TextPanelFlyout1.TextFlyoutText = value
            SetToolStripStatusLabelText(value)
        End Set
    End Property

    Public WriteOnly Property CheckImageFlyout() As Image Implements IViewFrmMain.CheckImageFlyout
        Set(ByVal value As Image)
            'ImagePanelFlyout1.FlyOutImage = Nothing
            ImagePanelFlyout1.FlyOutImage = value
        End Set
    End Property

    Public WriteOnly Property CheckImage() As CheckRegisterEventArgs Implements IViewFrmMain.CheckImage
        Set(ByVal value As CheckRegisterEventArgs)
            Select Case value.origCheck.Status
                Case CheckStatus.csAmountPending
                    CheckviewerEntryPanel1.CurrentCheckArgs = value
                Case CheckStatus.csEditPending
                    CheckViewEditPanel1.CurrentCheckArgs = value
                Case CheckStatus.csConfirmPending
                    CheckViewerConfirmPanel1.CurrentCheckArgs = value
            End Select
            CheckQueueCount = value
        End Set
    End Property

    Public WriteOnly Property CheckQueueCount() As CheckRegisterEventArgs Implements IViewFrmMain.CheckQueueCount
        Set(ByVal value As CheckRegisterEventArgs)
            Select Case value.origCheck.Status
                Case CheckStatus.csAmountPending
                    SetTpEntryQueueText(value.QueueIndex, value.QueueCount)
                Case CheckStatus.csEditPending
                    SetTpEditQueueText(value.QueueIndex, value.QueueCount)
                Case CheckStatus.csConfirmPending
                    SetTpConfirmQueueText(value.QueueCount.ToString)
            End Select
        End Set
    End Property

    Public WriteOnly Property Checklist() As List(Of ChecksClass) Implements IViewFrmMain.Checklist
        Set(ByVal value As List(Of ChecksClass))
            lvChecklist.SuspendLayout()
            SetCheckListlvCheckList(value)
            lvChecklist.ResumeLayout()
        End Set
    End Property

    Public WriteOnly Property PortTypeIcon() As ConnectionType Implements IViewFrmMain.PortTypeIcon
        Set(ByVal value As ConnectionType)
            SetToolBtnPortIcon(value)
        End Set
    End Property

    Public WriteOnly Property DelayInterval() As Integer Implements IViewFrmMain.DelayInterval
        Set(ByVal value As Integer)
            SetToolMnuDelayText(CStr(value))
        End Set
    End Property

    Public WriteOnly Property ScannerEnabled() As Boolean Implements IViewFrmMain.ScannerEnabled
        Set(ByVal value As Boolean)
            SetScannerIconEnabled(value)
        End Set
    End Property

    Public WriteOnly Property LoggingToggle() As Boolean Implements IViewFrmMain.LoggingToggle
        Set(ByVal value As Boolean)
            mnuLoggingOn.Checked = value
        End Set
    End Property

    Public WriteOnly Property Donorlist() As System.Collections.Generic.List(Of DonorClass) Implements IViewFrmMain.Donorlist
        Set(ByVal value As System.Collections.Generic.List(Of DonorClass))
            Me.SetDonorList(value)
        End Set
    End Property

#End Region

#Region "Class Constructor and Initialization"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        mnuLoggingOn.Checked = My.Settings.LoggingTurnedOn
        ctrlr = New DepositManagerPresenter(Me)
        ClearFormRegisters()
    End Sub

    Public Sub OnMainFormShowing(ByVal Sender As Object, ByVal e As EventArgs)
        RaiseEvent MainFormShowing(Me, e)
    End Sub

    Private Sub frmMain2008_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        OnMainFormShowing(Me, e)
        isActivated = True
    End Sub

    Private Sub frmMain2008_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ctrlr.CloseScanner()
    End Sub

    Private Sub frmMain2008_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        For i As Integer = TabControl1.TabPages.Count - 1 To 0 Step -1
            Dim tp = TabControl1.TabPages(i)
            myPages(i) = tp
        Next
        If CType([Enum].Parse(GetType(ConnectionType), My.Settings.ImageTransferMethod), ConnectionType) = ConnectionType.ctFTP Then
            mnuFTP.Checked = True
            mnuRS232.Checked = False
        Else
            mnuRS232.Checked = True
            mnuFTP.Checked = False
        End If

        SetSelectionPage()
        SetMenuItemsVisible()
        SetToolBar1ButtonsVisible()
        ctrlr.SetDepositSummaryList()
        ctrlr.SetBankList()
    End Sub

    Private Sub SetSelectionPage()
        For i As Integer = TabControl1.TabPages.Count - 1 To 0 Step -1
            If i > 0 Then
                TabControl1.Controls.Remove(TabControl1.TabPages(i))
            End If
            TabControl1.SelectedIndex = 0
        Next
    End Sub

#End Region

    Private Sub SetDonorList(ByVal list As List(Of DonorClass))
        Me.CheckViewEditPanel1.DonorList = list
        Me.CheckViewerAddPanel1.DonorList = list
        Me.CheckviewerEntryPanel1.DonorList = list
    End Sub


#Region "User Control Changed Methods"

    Private Sub TabControl1_Deselecting(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles TabControl1.Deselecting
        If TabControl1.SelectedTab Is tpViewDeposit Then
            If MessageBox.Show("Leaving 'Edit Deposit' view will close the deposit ticket and require reopening.  Do you want to continue?", "Closing Ticket", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedTab Is tpViewDeposit Then
            TabControl1.TabPages(0).Text = "Close Ticket"
            Me.Cursor = Cursors.WaitCursor
            If btnGetTicket.Enabled Then
                If lvDepositsList.SelectedItems.Count > 0 Then
                    ctrlr.OpenDepositTicket(CType(lvDepositsList.SelectedItems(0).Tag, DepositTicketClass))
                    ctrlr.InitializeCashText()
                ElseIf NewDepositIsChecked Then
                    If SelectedBank IsNot Nothing Then
                        ctrlr.OpenDepositTicket(dateDepositDate.Value, txtDepDescript.Text, SelectedBank)
                    Else
                        TabControl1.SelectedIndex = TabControl1.TabPages.IndexOf(tpSelectDeposit)
                    End If
                Else
                    TabControl1.SelectedIndex = TabControl1.TabPages.IndexOf(tpSelectDeposit)
                End If
            Else
                TabControl1.SelectedIndex = TabControl1.TabPages.IndexOf(tpSelectDeposit)
            End If
            Me.Cursor = Cursors.Default
        ElseIf TabControl1.SelectedTab Is tpSelectDeposit Then
            TabControl1.TabPages(0).Text = "Select Deposit"
            SetSelectionPage()
            Me.CloseDepositTicket()
        End If
        SetToolBar1ButtonsVisible()

    End Sub

    Private Sub CloseDepositTicket()
        If ctrlr IsNot Nothing Then
            Me.ctrlr.CloseDepositTicket()
            'ctrlr.CloseScanner()
            'ctrlr.SetDepositSummaryList()
        End If
    End Sub

    Private Sub ScannerModeChanged()
        If isActivated Then
            If MsgBox("You are about to change the method for communicating with the check scanner." & vbCr & "Do you want to continue?", MsgBoxStyle.YesNo, "Scanner Connection") = MsgBoxResult.Yes Then
                ctrlr.SetScannerConnection()
            End If
        End If
    End Sub

    Private Sub ckbxNewDep_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbxNewDep.CheckedChanged
        If ckbxNewDep.Checked Then
            lvDepositsList.SelectedItems.Clear()
            If lvBankAccounts.Items.Count = 1 Then
                lvBankAccounts.Items(0).Selected = True
            Else
                lvBankAccounts.SelectedItems.Clear()
            End If
        Else
            lvBankAccounts.SelectedItems.Clear()
        End If
        dateDepositDate.Enabled = ckbxNewDep.Checked
        txtDepDescript.Enabled = ckbxNewDep.Checked
        SetBtnGetTicketEnabled()
    End Sub


    Private Sub lvChecklist_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvChecklist.SelectedIndexChanged
        SetMenuItemsEnabled()
    End Sub

#End Region

#Region "Enable/Disable Controls"

    Private Sub SetBtnGetTicketEnabled()
        btnGetTicket.Enabled = lvDepositsList.SelectedItems.Count > 0 Or _
            (NewDepositIsChecked And txtDepDescript.Text <> "")
    End Sub

    Private Sub txtDepDescript_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDepDescript.KeyPress
        If e.KeyChar = Chr(13) AndAlso btnGetTicket.Enabled Then
            e.Handled = True
            btnGetTicket_Click(sender, e)
        End If
    End Sub

    Private Sub txtDepDescript_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDepDescript.TextChanged
        SetBtnGetTicketEnabled()
    End Sub

    Private Sub lvDepositsList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvDepositsList.DoubleClick
        If btnGetTicket.Enabled Then
            btnGetTicket_Click(sender, e)
        End If
    End Sub

    Private Sub lvDepositsList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvDepositsList.SelectedIndexChanged
        SetBtnGetTicketEnabled()
        If lvDepositsList.SelectedItems.Count > 0 Then
            ckbxNewDep.Checked = False
            SelectedBank = CType(lvDepositsList.SelectedItems(0).Tag, DepositTicketClass).BankInfo
        End If
        For i As Integer = 0 To lvDepositsList.Items.Count - 1
            If lvDepositsList.Items(i).Selected Then
                lvDepositsList.Items(i).StateImageIndex = 2
            Else
                lvDepositsList.Items(i).StateImageIndex = -1
            End If
        Next
    End Sub

    Private Sub SetToolBar1ButtonsVisible()
        SetMenuItemsVisible()
        toolbtnPrintTicket.Visible = TabControl1.SelectedTab Is tpViewDeposit
        toolbtnAddCheck.Visible = TabControl1.SelectedTab Is tpViewDeposit
        toolbtnEditCheck.Visible = TabControl1.SelectedTab Is tpViewDeposit
        toolbtnDeleteCheck.Visible = TabControl1.SelectedTab Is tpViewDeposit
        toolStripDepositTotal.Visible = TabControl1.SelectedTab Is tpViewDeposit
        toolStripBankInfo.Visible = TabControl1.SelectedTab Is tpViewDeposit
        SetToolBar1ButtonsEnabled()
    End Sub

    Private Sub SetToolBar1ButtonsEnabled()
        If Not IsNothing(ctrlr) AndAlso ctrlr.IsTicketOpen Then
            toolbtnPrintTicket.Enabled = mnuPrintTicket.Enabled
            toolbtnAddCheck.Enabled = mnuAddManualCheck.Enabled
            toolbtnEditCheck.Enabled = mnuEditSelectedCheck.Enabled
            toolbtnDeleteCheck.Enabled = mnuEditSelectedCheck.Enabled
        End If

    End Sub

    Private Sub SetMenuItemsVisible()
        '==TabControl1.SelectedTab is tpSelectDeposit==
        mnuAddEditBanks.Visible = TabControl1.SelectedTab Is tpSelectDeposit
        mnuCommunicationMode.Visible = TabControl1.SelectedTab Is tpSelectDeposit
        '==TabControl1.SelectedTab Is tpViewDeposit==
        mnuEditSelectedCheck.Visible = TabControl1.SelectedTab Is tpViewDeposit
        mnuAddManualCheck.Visible = TabControl1.SelectedTab Is tpViewDeposit
        mnuDeleteSelectedCheck.Visible = TabControl1.SelectedTab Is tpViewDeposit
        mnuPrintReport.Visible = TabControl1.SelectedTab Is tpViewDeposit
        mnuPrintTicket.Visible = TabControl1.SelectedTab Is tpViewDeposit
        mnuResetScanner.Visible = TabControl1.SelectedTab Is tpViewDeposit
        mnuInitScanner.Visible = TabControl1.SelectedTab Is tpViewDeposit
        SetMenuItemsEnabled()
    End Sub

    Private Sub SetMenuItemsEnabled()
        If Not IsNothing(ctrlr) AndAlso ctrlr.IsTicketOpen Then
            mnuPrintTicket.Enabled = True
            mnuPrintReport.Enabled = mnuPrintTicket.Enabled
            mnuAddManualCheck.Enabled = True
        End If
        mnuEditSelectedCheck.Enabled = lvChecklist.SelectedItems.Count > 0
        mnuDeleteSelectedCheck.Enabled = lvChecklist.SelectedItems.Count > 0

        SetToolBar1ButtonsEnabled()
    End Sub

#End Region

#Region "Set, Clear, Update Registers"

    Private Sub ClearFormRegisters()
        txtDollarCoinCt.Text = CStr(0)
        txtHalfDollarCt.Text = CStr(0)
        txtQuarterCt.Text = CStr(0)
        txtDimeCt.Text = CStr(0)
        txtNickelCt.Text = CStr(0)
        txtPennyCt.Text = CStr(0)
        txtHundredCt.Text = CStr(0)
        txtFiftyCt.Text = CStr(0)
        txtTwentyCt.Text = CStr(0)
        txtTenCt.Text = CStr(0)
        txtFiveCt.Text = CStr(0)
        txtOneCt.Text = CStr(0)
    End Sub

    Private Sub SetCheckRegister()
        '    lbxChecklist.Items.Clear()
        '    lbxChecklist.ValueMember = "Text"
        '    'depositView.SetCheckList()
        '    lbxChecklist.Items.AddRange(depositView.GetAmtEnteredChecksList.ToArray)
        '    If lbxChecklist.Items.Count > 0 Then
        '        Dim width As Integer = CInt(lbxChecklist.CreateGraphics().MeasureString(CType(lbxChecklist.Items(lbxChecklist.Items.Count - 1),  _
        '            TellerAssistant.ChecksClass).Text, lbxChecklist.Font).Width)
        '        lbxChecklist.ColumnWidth = width
        '    End If
        'UpdateTotalRegisters()
    End Sub
#End Region

#Region "Denomination Count TextChanged"

    Private Sub txtDollarCoinCt_TextValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDollarCoinCt.TextValueChanged, txtDollarCoinCt.ReturnPressed
        If isActivated Then
            ctrlr.SetCashCount(CashType.DollarCoin, CInt(txtDollarCoinCt.Text))
        End If
    End Sub

    Private Sub txtHalfDollarCt_TextValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHalfDollarCt.TextValueChanged, txtHalfDollarCt.ReturnPressed
        If isActivated Then
            ctrlr.SetCashCount(CashType.HalfDollar, CInt(txtHalfDollarCt.Text))
        End If
    End Sub

    Private Sub txtQuarterCt_TextValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQuarterCt.TextValueChanged, txtQuarterCt.ReturnPressed
        If isActivated Then
            ctrlr.SetCashCount(CashType.Quarter, CInt(txtQuarterCt.Text))
        End If
    End Sub

    Private Sub txtDimeCt_TextValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDimeCt.TextValueChanged, txtDimeCt.ReturnPressed
        If isActivated Then
            ctrlr.SetCashCount(CashType.Dime, CInt(txtDimeCt.Text))
        End If
    End Sub

    Private Sub txtNickelCt_TextValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNickelCt.TextValueChanged, txtNickelCt.ReturnPressed
        If isActivated Then
            ctrlr.SetCashCount(CashType.Nickel, CInt(txtNickelCt.Text))
        End If
    End Sub

    Private Sub txtPennyCt_TextValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPennyCt.TextValueChanged, txtPennyCt.ReturnPressed
        If isActivated Then
            ctrlr.SetCashCount(CashType.Penny, CInt(txtPennyCt.Text))
        End If
    End Sub

    Private Sub txtHundredCt_TextValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHundredCt.TextValueChanged, txtHundredCt.ReturnPressed
        If isActivated Then
            ctrlr.SetCashCount(CashType.OneHundred, CInt(txtHundredCt.Text))
        End If
    End Sub

    Private Sub txtFiftyCt_TextValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFiftyCt.TextValueChanged, txtFiftyCt.ReturnPressed
        If isActivated Then
            ctrlr.SetCashCount(CashType.Fifty, CInt(txtFiftyCt.Text))
        End If
    End Sub

    Private Sub txtTwentyCt_TextValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTwentyCt.TextValueChanged, txtTwentyCt.ReturnPressed
        If isActivated Then
            ctrlr.SetCashCount(CashType.Twenty, CInt(txtTwentyCt.Text))
        End If
    End Sub

    Private Sub txtTenCt_TextValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTenCt.TextValueChanged, txtTenCt.ReturnPressed
        If isActivated Then
            ctrlr.SetCashCount(CashType.Ten, CInt(txtTenCt.Text))
        End If
    End Sub

    Private Sub txtFiveCt_TextValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFiveCt.TextValueChanged, txtFiveCt.ReturnPressed
        If isActivated Then
            ctrlr.SetCashCount(CashType.Five, CInt(txtFiveCt.Text))
        End If
    End Sub

    Private Sub txtOneCt_TextValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOneCt.TextValueChanged, txtOneCt.ReturnPressed
        If isActivated Then
            ctrlr.SetCashCount(CashType.One, CInt(txtOneCt.Text))
        End If
    End Sub

#End Region

#Region "Button Click Methods"

    Private Sub btnGetTicket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetTicket.Click
        If NewDepositIsChecked Then
            If SelectedBank Is Nothing Then
                MsgBox("You must select a bank account to use.", MsgBoxStyle.Exclamation, )
                Exit Sub
            End If
        ElseIf lvDepositsList.SelectedItems.Count <= 0 Then
            MsgBox("You must select a deposit to open.", MsgBoxStyle.Exclamation, )
            Exit Sub
        End If
        If TabControl1.TabPages.IndexOf(tpViewDeposit) = -1 Then
            TabControl1.TabPages.Add(myPages(Array.IndexOf(myPages, tpViewDeposit)))
        End If
        TabControl1.SelectedIndex = TabControl1.TabPages.IndexOf(tpViewDeposit)

    End Sub

#Region "CheckEntryPanel"

    Private Sub CheckviewerEntryPanel1_CheckviewDonorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckviewerEntryPanel1.CheckviewDonorChanged
        'Me.ctrlr.SelectedDonorChanged(CheckviewerEntryPanel1.CurrentCheckArgs.modCheck)
    End Sub

    Private Sub btnEntryCheckPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckviewerEntryPanel1.CheckviewPrevNavClick
        ctrlr.DisplayPrevCheck(CheckStatus.csAmountPending)
    End Sub

    Private Sub CheckEntryPanel1_CheckviewNextNavClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckviewerEntryPanel1.CheckviewNextNavClick
        ctrlr.DisplayNextCheck(CheckStatus.csAmountPending)
    End Sub

    Private Sub CheckEntryPanel1_CheckviewFirstNavClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckviewerEntryPanel1.CheckviewFirstNavClick
        ctrlr.DisplayFirstCheck(CheckStatus.csAmountPending)
    End Sub

    Private Sub CheckEntryPanel1_CheckviewLastNavClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckviewerEntryPanel1.CheckviewLastNavClick
        ctrlr.DisplayLastCheck(CheckStatus.csAmountPending)
    End Sub

    Private Sub CheckEntryPanel1_CheckviewDeleteCurrentCheckOnly(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckviewerEntryPanel1.CheckviewDeleteCurrentCheckOnly
        ctrlr.DeleteCheck(CType(e, CheckStatusEventArgs).check, False)
    End Sub

    Private Sub CheckEntryPanel1_CheckviewApplyClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckviewerEntryPanel1.CheckviewApplyClick
        If CheckviewerEntryPanel1.CurrentCheckArgs IsNot Nothing Then
            ctrlr.UpdateCheckData(CheckviewerEntryPanel1.CurrentCheckArgs.ToCheckDataEventArgs)
        End If
    End Sub

    Private Sub CheckEntryPanel1_CheckviewResetClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckviewerEntryPanel1.CheckviewResetClick
        ctrlr.ResetCheck(CheckStatus.csAmountPending)
    End Sub

    Private Sub CheckEntryPanel1_DonorInfo(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckviewerEntryPanel1.CheckviewDonorClick
        ctrlr.EditDonorInformation(CheckviewerEntryPanel1.CurrentCheckArgs)
    End Sub

#End Region

#Region "CheckEditPanel"

    Private Sub CheckViewEditPanel1_CheckviewDonorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckViewEditPanel1.CheckviewDonorChanged
        Me.ctrlr.SelectedDonorChanged(CheckViewEditPanel1.CurrentCheckArgs.modCheck)
    End Sub

    Private Sub CheckEditPanel1_CheckviewPrevNavClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckViewEditPanel1.CheckviewPrevNavClick
        ctrlr.DisplayPrevCheck(CheckStatus.csEditPending)
    End Sub

    Private Sub CheckEditPanel1_CheckviewNextNavClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckViewEditPanel1.CheckviewNextNavClick
        ctrlr.DisplayNextCheck(CheckStatus.csEditPending)
    End Sub

    Private Sub CheckEditPanel1_CheckviewFirstNavClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckViewEditPanel1.CheckviewFirstNavClick
        ctrlr.DisplayFirstCheck(CheckStatus.csEditPending)
    End Sub

    Private Sub CheckEditPanel1_CheckviewLastNavClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckViewEditPanel1.CheckviewLastNavClick
        ctrlr.DisplayLastCheck(CheckStatus.csEditPending)
    End Sub

    Private Sub CheckEditPanel1_CheckviewDeleteCurrentCheckOnly(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckViewEditPanel1.CheckviewDeleteCurrentCheckOnly
        ctrlr.DeleteCheck(CType(e, CheckStatusEventArgs).check, False)
    End Sub

    Private Sub CheckEditPanel1_CheckviewApplyClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckViewEditPanel1.CheckviewApplyClick
        If CheckViewEditPanel1.CurrentCheckArgs IsNot Nothing Then
            ctrlr.UpdateCheckData(CheckViewEditPanel1.CurrentCheckArgs.ToCheckDataEventArgs)
        End If
    End Sub

    Private Sub CheckEditPanel1_CheckviewResetClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckViewEditPanel1.CheckviewResetClick
        ctrlr.ResetCheck(CheckStatus.csEditPending)
    End Sub

    Private Sub CheckEditPanel1_DonorInfo(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckViewEditPanel1.CheckviewDonorClick
        ctrlr.EditDonorInformation(CheckViewEditPanel1.CurrentCheckArgs)
    End Sub
#End Region

#Region "CheckConfirmPanel"

    Private Sub CheckConfirmPanel1_CheckviewApplyClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckViewerConfirmPanel1.CheckviewApplyClick
        If CheckViewerConfirmPanel1.CurrentCheckArgs IsNot Nothing Then
            ctrlr.UpdateCheckStatus(CheckViewerConfirmPanel1.CurrentCheckArgs.ToCheckDataEventArgs)
        End If
    End Sub

    Private Sub CheckConfirmPanel1_CheckviewSkipClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckViewerConfirmPanel1.CheckviewSkipClick
        ctrlr.DisplayNextCheck(CheckStatus.csConfirmPending)
    End Sub

#End Region

#Region "CheckAddPanel"
    Private Sub CheckViewerAddPanel1_CheckviewDonorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckViewerAddPanel1.CheckviewDonorChanged
        'Me.ctrlr.SelectedDonorChanged(CheckViewerAddPanel1.CurrentCheckArgs.modCheck)
    End Sub

    Private Sub CheckAddPanel1_CheckviewApplyClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckViewerAddPanel1.CheckviewApplyClick
        If CheckViewerAddPanel1.CurrentCheckArgs IsNot Nothing Then
            ctrlr.UpdateCheckData(CheckViewerAddPanel1.CurrentCheckArgs.ToCheckDataEventArgs)
            CheckViewerAddPanel1.CurrentCheckArgs = New CheckRegisterEventArgs(EventName.evnmDbCheckStatusChanged, ctrlr.GetNewCheck, Nothing, -1, -1)
        End If
    End Sub

    Private Sub CheckAddPanel1_CheckviewResetClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckViewerAddPanel1.CheckviewResetClick
        CheckViewerAddPanel1.CurrentCheckArgs = New CheckRegisterEventArgs(EventName.evnmDbCheckUpdated, ctrlr.GetNewCheck, Nothing, -1, -1)
    End Sub

    Private Sub CheckAddPanel1_DonorInfo(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckViewerAddPanel1.CheckviewDonorClick
        ctrlr.EditDonorInformation(CheckViewerAddPanel1.CurrentCheckArgs)
    End Sub

#End Region

#End Region

#Region "Menu Events"

    Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
        Close()
    End Sub

    Private Sub mnuAddEditBanks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAddEditBanks.Click
        ctrlr.AddEditBanks()
    End Sub

    Private Sub mnuEditSelectedCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEditSelectedCheck.Click, toolbtnEditCheck.Click
        If lvChecklist.SelectedItems(0) IsNot Nothing Then
            Dim chk As ChecksClass = CType(lvChecklist.SelectedItems(0).Tag, ChecksClass)
            chk.Status = CheckStatus.csEditPending
            ctrlr.UpdateCheckStatus(New CheckDataEventArgs(EventName.evnmCheckSearchResult, CType(lvChecklist.SelectedItems(0).Tag, ChecksClass), chk))
        End If
    End Sub

    Private Sub mnuDeleteSelectedCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDeleteSelectedCheck.Click, toolbtnDeleteCheck.Click
        If lvChecklist.SelectedItems(0) IsNot Nothing Then
            Dim dlg As New DialogCheckDelete
            If dlg.ShowDialog = Windows.Forms.DialogResult.Yes Then
                ctrlr.DeleteCheck(CType(lvChecklist.SelectedItems(0).Tag, ChecksClass), dlg.ckbxDeleteImage.Checked)
            End If
        End If
    End Sub

    Private Sub mnuFTP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFTP.Click
        If mnuFTP.Checked Then
            mnuRS232.Checked = False
            ScannerModeChanged()
        End If
    End Sub

    Private Sub mnuRS232_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRS232.Click
        If mnuRS232.Checked Then
            mnuFTP.Checked = False
            ScannerModeChanged()
        End If
    End Sub

    Private Sub PrintTicket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolbtnPrintTicket.Click, mnuPrintTicket.Click
        ctrlr.PrintDepositTicket()
    End Sub

    Private Sub mnuPrintReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrintReport.Click

    End Sub

    Private Sub mnuCheckSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCheckSearch.Click, toolBtnCheckSearch.Click
        ctrlr.SearchForChecks()
    End Sub

    Private Sub mnuResetScanner_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuResetScanner.Click
        ctrlr.ResetScanner()
    End Sub

    Private Sub mnuAddManualCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAddManualCheck.Click, toolbtnAddCheck.Click
        TabControl2.SelectTab(tpAddManualCheck)
    End Sub


#End Region

#Region "Control Callback Methods"

    Private Sub SetTpEntryQueueText(ByVal indx As Integer, ByVal ct As Integer)
        If tpEntryQueue.InvokeRequired Then
            Me.BeginInvoke(New SetTwoIntegerCallback(AddressOf SetTpEntryQueueText), indx, ct)
        Else
            tpEntryQueue.Text = "Entry Queue (" + (indx + 1).ToString + " of " + ct.ToString + ")"
        End If
    End Sub
    Private Sub SetTpEditQueueText(ByVal indx As Integer, ByVal ct As Integer)
        If tpEditQueue.InvokeRequired Then
            Me.BeginInvoke(New SetTwoIntegerCallback(AddressOf SetTpEditQueueText), indx, ct)
        Else
            tpEditQueue.Text = "Edit Queue (" + (indx + 1).ToString + " of " + ct.ToString + ")"
        End If
    End Sub
    Private Sub SetTpConfirmQueueText(ByVal text As String)
        If tpConfirmQueue.InvokeRequired Then
            Me.BeginInvoke(New SetTextCallback(AddressOf SetTpConfirmQueueText), text)
        Else
            tpConfirmQueue.Text = "Confirm Queue (" + text + ")"
        End If
    End Sub

    Private Sub SetCheckListlvCheckList(ByVal value As List(Of ChecksClass))
        If lvChecklist.InvokeRequired Then
            Me.BeginInvoke(New SetCheckListCallback(AddressOf SetCheckListlvCheckList), value)
        Else
            lvChecklist.Items.Clear()
            For Each chk As ChecksClass In value
                Dim itm As New ListViewItem
                itm.Text = chk.Text
                itm.SubItems.Add(chk.CheckAmount.ToString("C"))
                itm.Tag = chk
                itm.ToolTipText = itm.Text
                If chk.ManualCheck Then
                    itm.BackColor = Color.Beige
                End If
                If chk.ReceiptRequest = ReceiptRequestStatus.rrsRequestedNotSent Then
                    itm.StateImageIndex = 1
                    itm.BackColor = Color.LightGoldenrodYellow
                ElseIf chk.ReceiptRequest = ReceiptRequestStatus.rrsRequestedSent Then
                    itm.StateImageIndex = 0
                    itm.BackColor = Color.LightGreen
                Else
                    itm.StateImageIndex = -1
                End If
                lvChecklist.Items.Add(itm)
                itm.Group = lvChecklist.Groups([Enum].GetName(GetType(CheckStatus), chk.Status))
            Next
            If lvChecklist.Columns.Count > 0 Then
                lvChecklist.Columns(0).TextAlign = HorizontalAlignment.Right
            End If
            txtChecksCount.Text = value.Count.ToString
        End If
    End Sub

    Private Sub SetToolStripStatusLabelText(ByVal value As String)
        If Me.InvokeRequired Then
            Me.BeginInvoke(New SetTextCallback(AddressOf SetToolStripStatusLabelText), value)
        Else
            toolLabelStatusText.Text = value
        End If
    End Sub

    Private Sub SetToolBtnPortIcon(ByVal value As ConnectionType)
        If Me.InvokeRequired Then
            Me.BeginInvoke(New SetConnectionTypeCallback(AddressOf SetToolBtnPortIcon), value)
        Else
            Select Case value
                Case ConnectionType.ctNone
                    toolBtnPortIcon.Image = ImageList1.Images.Item(9)
                    toolBtnPortIcon.ToolTipText = "Scanner Not Connected"
                Case ConnectionType.ctFTP
                    toolBtnPortIcon.Image = ImageList1.Images.Item(7)
                    toolBtnPortIcon.ToolTipText = "Local Network: FTP Connection"
                Case ConnectionType.ctRS232
                    toolBtnPortIcon.Image = ImageList1.Images.Item(8)
                    toolBtnPortIcon.ToolTipText = "Serial Comport: RS232 Connection"
            End Select
        End If
    End Sub

    Public Sub SetToolMnuDelayText(ByVal value As String)
        If Me.InvokeRequired Then
            Me.BeginInvoke(New SetTextCallback(AddressOf SetToolMnuDelayText), value)
        Else
            toolMnuDelayText.Text = value
        End If
    End Sub

    Public Sub SetScannerIconEnabled(ByVal value As Boolean)
        If Me.InvokeRequired Then
            Me.BeginInvoke(New SetBooleanCallback(AddressOf SetScannerIconEnabled), value)
        Else
            toolBtnPortIcon.Enabled = value
        End If
    End Sub

#End Region

    Private Sub lvChecklist_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvChecklist.DoubleClick
        If lvChecklist.SelectedItems(0) IsNot Nothing Then
            Dim fname As String = CType(lvChecklist.SelectedItems(0).Tag, ChecksClass).ImageFullPath + CType(lvChecklist.SelectedItems(0).Tag, ChecksClass).ImageFile
            If File.Exists(fname) Then
                If FileNotInUse(fname) Then
                    Dim img As New Bitmap(CType(lvChecklist.SelectedItems(0).Tag, ChecksClass).ImageFullPath + CType(lvChecklist.SelectedItems(0).Tag, ChecksClass).ImageFile)
                    CheckImageFlyout = img
                    img.Dispose()
                Else
                    CheckImageFlyout = Nothing
                End If
            Else
                ImagePanelFlyout1.ShowImageNotFound()
            End If
        End If
    End Sub

    Private Function FileNotInUse(ByVal fname As String) As Boolean
        Try
            Dim fs As New FileStream(fname, FileMode.Open, FileAccess.ReadWrite, FileShare.None)
            fs.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub lvBankAccounts_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvBankAccounts.SelectedIndexChanged
        For i As Integer = 0 To lvBankAccounts.Items.Count - 1
            If lvBankAccounts.Items(i).Selected Then
                lvBankAccounts.Items(i).StateImageIndex = 2
            Else
                lvBankAccounts.Items(i).StateImageIndex = -1
            End If
        Next

    End Sub


    Private Sub pnlTopBarExtension_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlTopBarExtension.Paint
        Dim l, w As Integer
        l = pnlTopBarExtension.Width
        w = pnlTopBarExtension.Height
        Dim g As Graphics = pnlTopBarExtension.CreateGraphics
        Dim linMode As LinearGradientMode
        linMode = LinearGradientMode.Vertical
        g.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect As Rectangle = New Rectangle(0, 0, pnlTopBarExtension.Width, pnlTopBarExtension.Height)
        Using lgbr As LinearGradientBrush = New LinearGradientBrush(rect, Color.DarkGray, Color.Transparent, linMode)
            g.FillRectangle(lgbr, rect)
        End Using
        g.Dispose()

    End Sub

    Private Sub pnlBottomBarExtension_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlBottomBarExtension.Paint
        Dim l, w As Integer
        l = pnlBottomBarExtension.Width
        w = pnlBottomBarExtension.Height
        Dim g As Graphics = pnlBottomBarExtension.CreateGraphics
        Dim linMode As LinearGradientMode
        linMode = LinearGradientMode.Vertical
        g.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect As Rectangle = New Rectangle(0, 0, pnlBottomBarExtension.Width, pnlBottomBarExtension.Height)
        Using lgbr As LinearGradientBrush = New LinearGradientBrush(rect, Color.DarkGray, Color.Transparent, linMode)
            g.FillRectangle(lgbr, rect)
        End Using
        g.Dispose()

    End Sub

    Private Sub ctxmnuLVChecksRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxmnuLVChecksRefresh.Click
        Me.Checklist = ctrlr.GetCheckList()
    End Sub

    Private Sub ctxmnuLVChecksEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ctxmnuLVChecksEdit.Click
        mnuEditSelectedCheck_Click(sender, e)
    End Sub

    Private Sub ctxmnuLVChecksView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ctxmnuLVChecksView.Click
        Me.lvChecklist_DoubleClick(sender, e)
    End Sub

    Private Sub toolMnuDelayText_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolMnuDelayText.TextChanged
        ctrlr.SetScannerDelay(CInt(toolMnuDelayText.Text))
    End Sub

    Private Sub TabControl2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl2.SelectedIndexChanged
        Try
            If TabControl2.SelectedTab Is tpAddManualCheck Then
                Me.ctrlr.UpdateViewerMode(ViewMode.vmAddView)
                If CheckViewerAddPanel1.CurrentCheckArgs.origCheck Is Nothing Then
                    CheckViewerAddPanel1.CurrentCheckArgs = New CheckRegisterEventArgs(EventName.evnmDbCheckUpdated, ctrlr.GetNewCheck, Nothing, -1, -1)
                End If
            ElseIf TabControl2.SelectedTab Is tpEditQueue Then
                Me.ctrlr.UpdateViewerMode(ViewMode.vmEditView)
            ElseIf TabControl2.SelectedTab Is tpConfirmQueue Then
                Me.ctrlr.UpdateViewerMode(ViewMode.vmConfirmView)
            Else
                Me.ctrlr.UpdateViewerMode(ViewMode.vmEntryView)
            End If
        Catch ex As Exception
            MsgBox("at TabControl2_SelectedIndexChanged: " & ex.Message)
        End Try
    End Sub

    Private Sub ckbxFilterYTD_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbxFilterYTD.CheckedChanged
        If ctrlr IsNot Nothing Then
            ctrlr.SetDepositSummaryList()
        End If
    End Sub

    Private Sub mnuPrintFormSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrintFormSetup.Click
        Dim dlg As New FormPrintPageSetup
        dlg.ShowDialog()

    End Sub

    Private Sub mnuPrintReport_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrintReport.Click

    End Sub

    Private Sub mnuViewExceptionLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewExceptionLog.Click
        Dim dlg As FormLogViewer
        dlg = New FormLogViewer(Application.StartupPath & "\Log\Exceptions.log")
        dlg.ShowDialog()
    End Sub

    Private Sub mnuLoggingOn_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLoggingOn.Click
        ctrlr.ToggleLogging()
    End Sub

    Private Sub mnuEditAppSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEditAppSettings.Click
        Dim dlg As New DialogEditAppSettings
        dlg.ShowDialog()
    End Sub

    Private Sub toolBtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolBtnExit.Click
        Close()
    End Sub

    Private Sub mnuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAbout.Click
        With New FormSplash
            .Label1.Visible = True
            .ShowDialog()
        End With
    End Sub


    Private Sub mnuManageImageFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuManageImageFiles.Click
        Dim dlg As New FileManagerUtility.FormFileManager
        dlg.ShowDialog()

    End Sub

    Private Sub mnuPageSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPageSetup.Click
        Dim dlg As New PageSetupDialog
        If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then


        End If
    End Sub

    Private Sub mnuPrintReceipts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrintReceipts.Click

    End Sub
End Class