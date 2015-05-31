<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain2012
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain2012))
        Dim ListViewGroup7 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup6 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Not Assigned", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup8 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Amount Pending", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup9 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Edit Pending", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup10 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Confirm Pending", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup11 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Verified", System.Windows.Forms.HorizontalAlignment.Left)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ContextMenuLVChecks = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxmnuLVChecksRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxmnuLVChecksView = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxmnuLVChecksEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.txtDepDescript = New System.Windows.Forms.TextBox()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.tpEntryQueue = New System.Windows.Forms.TabPage()
        Me.CheckviewerEntryPanel1 = New TellerAssistant2012.CheckViewerEditPanel()
        Me.tpEditQueue = New System.Windows.Forms.TabPage()
        Me.CheckViewEditPanel1 = New TellerAssistant2012.CheckViewerEditPanel()
        Me.tpConfirmQueue = New System.Windows.Forms.TabPage()
        Me.CheckViewerConfirmPanel1 = New TellerAssistant2012.CheckViewerConfirmPanel()
        Me.tpAddManualCheck = New System.Windows.Forms.TabPage()
        Me.CheckViewerAddPanel1 = New TellerAssistant2012.CheckViewerAddPanel()
        Me.tpView = New System.Windows.Forms.TabPage()
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.toolStripBankInfo = New System.Windows.Forms.ToolStrip()
        Me.toolLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.toolTextBankInfo = New System.Windows.Forms.ToolStripTextBox()
        Me.toolStripDepositTotal = New System.Windows.Forms.ToolStrip()
        Me.ToolLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.toolTextDepositTotal = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripStatus1 = New System.Windows.Forms.ToolStrip()
        Me.toolLabelStatusText = New System.Windows.Forms.ToolStripLabel()
        Me.toolBtnPortIcon = New System.Windows.Forms.ToolStripDropDownButton()
        Me.toolMnuDelayInterval = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolMnuDelayText = New System.Windows.Forms.ToolStripTextBox()
        Me.TextPanelFlyout1 = New Flyout_Control.TextPanelFlyout()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pnlBottomBarExtension = New System.Windows.Forms.Panel()
        Me.ImagePanelFlyout1 = New Flyout_Control.ImagePanelFlyout()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pnlTopBarExtension = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpSelectDeposit = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ckbxNewDep = New System.Windows.Forms.CheckBox()
        Me.dateDepositDate = New System.Windows.Forms.DateTimePicker()
        Me.lvBankAccounts = New System.Windows.Forms.ListView()
        Me.colHdrAcctId = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colHdrAcctType = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colHdrBankName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnGetTicket = New System.Windows.Forms.Button()
        Me.lvDepositsList = New System.Windows.Forms.ListView()
        Me.colHdrDepositNo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colHdrDepositDate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colHdrDescription = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colhdrTotal = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.comboDateRange = New System.Windows.Forms.ComboBox()
        Me.tpViewDeposit = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlCashRegister = New System.Windows.Forms.Panel()
        Me.GroupBoxCurrency = New System.Windows.Forms.GroupBox()
        Me.txtOneCt = New CalculatorClasses.CalculatorTextbox()
        Me.txtFiveCt = New CalculatorClasses.CalculatorTextbox()
        Me.txtTenCt = New CalculatorClasses.CalculatorTextbox()
        Me.txtTwentyCt = New CalculatorClasses.CalculatorTextbox()
        Me.txtFiftyCt = New CalculatorClasses.CalculatorTextbox()
        Me.txtHundredCt = New CalculatorClasses.CalculatorTextbox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtOne = New System.Windows.Forms.TextBox()
        Me.txtFive = New System.Windows.Forms.TextBox()
        Me.txtTen = New System.Windows.Forms.TextBox()
        Me.txtTwenty = New System.Windows.Forms.TextBox()
        Me.txtFifty = New System.Windows.Forms.TextBox()
        Me.txtHundred = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtCurrencyTotal = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.txtCashTotal = New System.Windows.Forms.TextBox()
        Me.GroupBoxCoins = New System.Windows.Forms.GroupBox()
        Me.txtPennyCt = New CalculatorClasses.CalculatorTextbox()
        Me.txtNickelCt = New CalculatorClasses.CalculatorTextbox()
        Me.txtDimeCt = New CalculatorClasses.CalculatorTextbox()
        Me.txtQuarterCt = New CalculatorClasses.CalculatorTextbox()
        Me.txtHalfDollarCt = New CalculatorClasses.CalculatorTextbox()
        Me.txtDollarCoinCt = New CalculatorClasses.CalculatorTextbox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtPenny = New System.Windows.Forms.TextBox()
        Me.txtNickel = New System.Windows.Forms.TextBox()
        Me.txtDime = New System.Windows.Forms.TextBox()
        Me.txtQuarter = New System.Windows.Forms.TextBox()
        Me.txtHalfDollar = New System.Windows.Forms.TextBox()
        Me.txtDollarCoin = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCoinTotal = New System.Windows.Forms.TextBox()
        Me.pnlDepositInfo = New System.Windows.Forms.Panel()
        Me.txtChecksCount = New System.Windows.Forms.TextBox()
        Me.lblDepDate = New System.Windows.Forms.Label()
        Me.lblDepDescript = New System.Windows.Forms.Label()
        Me.txtDepositNo = New System.Windows.Forms.TextBox()
        Me.txtChecksTotal = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.lvChecklist = New System.Windows.Forms.ListView()
        Me.ImageListStates = New System.Windows.Forms.ImageList(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAddManualCheck = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditSelectedCheck = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDeleteSelectedCheck = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPrintTicket = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPrintReport = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPageSetup = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuCheckSearch = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPrintReceipts = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAddEditBanks = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPrintFormSetup = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuInitScanner = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuResetScanner = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCommunicationMode = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFTP = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRS232 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuEditAppSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.EventLoggingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewExceptionLog = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLoggingOn = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuManageImageFiles = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripTop = New System.Windows.Forms.ToolStrip()
        Me.toolbtnPrintTicket = New System.Windows.Forms.ToolStripButton()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolBtnCheckSearch = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolbtnAddCheck = New System.Windows.Forms.ToolStripButton()
        Me.toolbtnEditCheck = New System.Windows.Forms.ToolStripButton()
        Me.toolbtnDeleteCheck = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolBtnExit = New System.Windows.Forms.ToolStripButton()
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog()
        Me.CheckViewerViewPanel1 = New TellerAssistant2012.CheckViewerViewPanel()
        Me.ContextMenuLVChecks.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.tpEntryQueue.SuspendLayout()
        Me.tpEditQueue.SuspendLayout()
        Me.tpConfirmQueue.SuspendLayout()
        Me.tpAddManualCheck.SuspendLayout()
        Me.tpView.SuspendLayout()
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.toolStripBankInfo.SuspendLayout()
        Me.toolStripDepositTotal.SuspendLayout()
        Me.ToolStripStatus1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tpSelectDeposit.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.tpViewDeposit.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.pnlCashRegister.SuspendLayout()
        Me.GroupBoxCurrency.SuspendLayout()
        Me.GroupBoxCoins.SuspendLayout()
        Me.pnlDepositInfo.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStripTop.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "GoLtr.bmp")
        Me.ImageList1.Images.SetKeyName(1, "GoRtl.bmp")
        Me.ImageList1.Images.SetKeyName(2, "PushpinHS.png")
        Me.ImageList1.Images.SetKeyName(3, "OK.bmp")
        Me.ImageList1.Images.SetKeyName(4, "disconnect2.ico")
        Me.ImageList1.Images.SetKeyName(5, "p3oEnetres.ico")
        Me.ImageList1.Images.SetKeyName(6, "Accessibility_Warning.png")
        Me.ImageList1.Images.SetKeyName(7, "ftp_sh 24x24.bmp")
        Me.ImageList1.Images.SetKeyName(8, "local_area_connection24x24.bmp")
        Me.ImageList1.Images.SetKeyName(9, "broken_connection_sh 24x24.bmp")
        '
        'ContextMenuLVChecks
        '
        Me.ContextMenuLVChecks.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ContextMenuLVChecks.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxmnuLVChecksRefresh, Me.ctxmnuLVChecksView, Me.ctxmnuLVChecksEdit})
        Me.ContextMenuLVChecks.Name = "ContextMenuLVChecks"
        Me.ContextMenuLVChecks.Size = New System.Drawing.Size(177, 94)
        '
        'ctxmnuLVChecksRefresh
        '
        Me.ctxmnuLVChecksRefresh.Name = "ctxmnuLVChecksRefresh"
        Me.ctxmnuLVChecksRefresh.Size = New System.Drawing.Size(176, 30)
        Me.ctxmnuLVChecksRefresh.Text = "Refresh"
        '
        'ctxmnuLVChecksView
        '
        Me.ctxmnuLVChecksView.Name = "ctxmnuLVChecksView"
        Me.ctxmnuLVChecksView.Size = New System.Drawing.Size(176, 30)
        Me.ctxmnuLVChecksView.Text = "View Image"
        '
        'ctxmnuLVChecksEdit
        '
        Me.ctxmnuLVChecksEdit.Name = "ctxmnuLVChecksEdit"
        Me.ctxmnuLVChecksEdit.Size = New System.Drawing.Size(176, 30)
        Me.ctxmnuLVChecksEdit.Text = "Edit"
        '
        'txtDepDescript
        '
        Me.txtDepDescript.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDepDescript.Enabled = False
        Me.HelpProvider1.SetHelpKeyword(Me.txtDepDescript, "DepDescr")
        Me.HelpProvider1.SetHelpString(Me.txtDepDescript, "Enter a brief description to identify the deposit.")
        Me.txtDepDescript.Location = New System.Drawing.Point(16, 125)
        Me.txtDepDescript.Name = "txtDepDescript"
        Me.HelpProvider1.SetShowHelp(Me.txtDepDescript, True)
        Me.txtDepDescript.Size = New System.Drawing.Size(540, 26)
        Me.txtDepDescript.TabIndex = 13
        '
        'TabControl2
        '
        Me.TableLayoutPanel3.SetColumnSpan(Me.TabControl2, 2)
        Me.TabControl2.Controls.Add(Me.tpEntryQueue)
        Me.TabControl2.Controls.Add(Me.tpEditQueue)
        Me.TabControl2.Controls.Add(Me.tpConfirmQueue)
        Me.TabControl2.Controls.Add(Me.tpAddManualCheck)
        Me.TabControl2.Controls.Add(Me.tpView)
        Me.TabControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl2.Location = New System.Drawing.Point(4, 359)
        Me.TabControl2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.RightToLeftLayout = True
        Me.TabControl2.SelectedIndex = 0
        Me.HelpProvider1.SetShowHelp(Me.TabControl2, True)
        Me.TabControl2.Size = New System.Drawing.Size(1518, 440)
        Me.TabControl2.TabIndex = 11
        '
        'tpEntryQueue
        '
        Me.tpEntryQueue.Controls.Add(Me.CheckviewerEntryPanel1)
        Me.tpEntryQueue.Location = New System.Drawing.Point(4, 29)
        Me.tpEntryQueue.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tpEntryQueue.Name = "tpEntryQueue"
        Me.tpEntryQueue.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tpEntryQueue.Size = New System.Drawing.Size(1510, 407)
        Me.tpEntryQueue.TabIndex = 0
        Me.tpEntryQueue.Text = "Entry Queue (0)"
        Me.tpEntryQueue.UseVisualStyleBackColor = True
        '
        'CheckviewerEntryPanel1
        '
        Me.CheckviewerEntryPanel1.ApplyonEntryKey = True
        Me.CheckviewerEntryPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckviewerEntryPanel1.Location = New System.Drawing.Point(4, 5)
        Me.CheckviewerEntryPanel1.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.CheckviewerEntryPanel1.Name = "CheckviewerEntryPanel1"
        Me.CheckviewerEntryPanel1.OkButtonLabel = "&Apply"
        Me.CheckviewerEntryPanel1.Size = New System.Drawing.Size(1502, 397)
        Me.CheckviewerEntryPanel1.SpliterDistance = 1040
        Me.CheckviewerEntryPanel1.TabIndex = 0
        '
        'tpEditQueue
        '
        Me.tpEditQueue.Controls.Add(Me.CheckViewEditPanel1)
        Me.tpEditQueue.Location = New System.Drawing.Point(4, 29)
        Me.tpEditQueue.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tpEditQueue.Name = "tpEditQueue"
        Me.tpEditQueue.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tpEditQueue.Size = New System.Drawing.Size(1510, 407)
        Me.tpEditQueue.TabIndex = 1
        Me.tpEditQueue.Text = "Edit Queue (0)"
        Me.tpEditQueue.UseVisualStyleBackColor = True
        '
        'CheckViewEditPanel1
        '
        Me.CheckViewEditPanel1.ApplyonEntryKey = False
        Me.CheckViewEditPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckViewEditPanel1.Location = New System.Drawing.Point(4, 5)
        Me.CheckViewEditPanel1.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.CheckViewEditPanel1.Name = "CheckViewEditPanel1"
        Me.CheckViewEditPanel1.OkButtonLabel = "&Apply"
        Me.CheckViewEditPanel1.Size = New System.Drawing.Size(1502, 397)
        Me.CheckViewEditPanel1.SpliterDistance = 1040
        Me.CheckViewEditPanel1.TabIndex = 0
        '
        'tpConfirmQueue
        '
        Me.tpConfirmQueue.Controls.Add(Me.CheckViewerConfirmPanel1)
        Me.tpConfirmQueue.Location = New System.Drawing.Point(4, 29)
        Me.tpConfirmQueue.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tpConfirmQueue.Name = "tpConfirmQueue"
        Me.tpConfirmQueue.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tpConfirmQueue.Size = New System.Drawing.Size(1510, 407)
        Me.tpConfirmQueue.TabIndex = 2
        Me.tpConfirmQueue.Text = "Confirm Queue (0)"
        Me.tpConfirmQueue.UseVisualStyleBackColor = True
        '
        'CheckViewerConfirmPanel1
        '
        Me.CheckViewerConfirmPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckViewerConfirmPanel1.Location = New System.Drawing.Point(4, 5)
        Me.CheckViewerConfirmPanel1.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.CheckViewerConfirmPanel1.Name = "CheckViewerConfirmPanel1"
        Me.CheckViewerConfirmPanel1.Size = New System.Drawing.Size(1502, 397)
        Me.CheckViewerConfirmPanel1.SpliterDistance = 1092
        Me.CheckViewerConfirmPanel1.TabIndex = 0
        '
        'tpAddManualCheck
        '
        Me.tpAddManualCheck.Controls.Add(Me.CheckViewerAddPanel1)
        Me.tpAddManualCheck.Location = New System.Drawing.Point(4, 29)
        Me.tpAddManualCheck.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tpAddManualCheck.Name = "tpAddManualCheck"
        Me.tpAddManualCheck.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tpAddManualCheck.Size = New System.Drawing.Size(1510, 407)
        Me.tpAddManualCheck.TabIndex = 3
        Me.tpAddManualCheck.Text = "Add Check"
        Me.tpAddManualCheck.UseVisualStyleBackColor = True
        '
        'CheckViewerAddPanel1
        '
        Me.CheckViewerAddPanel1.ApplyonEntryKey = False
        Me.CheckViewerAddPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckViewerAddPanel1.Location = New System.Drawing.Point(4, 5)
        Me.CheckViewerAddPanel1.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.CheckViewerAddPanel1.Name = "CheckViewerAddPanel1"
        Me.CheckViewerAddPanel1.NavButtonsVisible = False
        Me.CheckViewerAddPanel1.OkButtonLabel = "&Apply"
        Me.CheckViewerAddPanel1.Size = New System.Drawing.Size(1502, 397)
        Me.CheckViewerAddPanel1.SpliterDistance = 1084
        Me.CheckViewerAddPanel1.TabIndex = 0
        '
        'tpView
        '
        Me.tpView.Controls.Add(Me.CheckViewerViewPanel1)
        Me.tpView.Location = New System.Drawing.Point(4, 29)
        Me.tpView.Name = "tpView"
        Me.tpView.Padding = New System.Windows.Forms.Padding(3)
        Me.tpView.Size = New System.Drawing.Size(1510, 407)
        Me.tpView.TabIndex = 4
        Me.tpView.Text = "View Confirmed"
        Me.tpView.UseVisualStyleBackColor = True
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.BottomToolStripPanel
        '
        Me.ToolStripContainer1.BottomToolStripPanel.Controls.Add(Me.toolStripBankInfo)
        Me.ToolStripContainer1.BottomToolStripPanel.Controls.Add(Me.toolStripDepositTotal)
        Me.ToolStripContainer1.BottomToolStripPanel.Controls.Add(Me.ToolStripStatus1)
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.TextPanelFlyout1)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.Panel3)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.ImagePanelFlyout1)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.Panel2)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.TableLayoutPanel1)
        Me.ToolStripContainer1.ContentPanel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(1554, 912)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(1554, 1038)
        Me.ToolStripContainer1.TabIndex = 0
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.MenuStrip1)
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStripTop)
        '
        'toolStripBankInfo
        '
        Me.toolStripBankInfo.Dock = System.Windows.Forms.DockStyle.None
        Me.toolStripBankInfo.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.toolStripBankInfo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolLabel1, Me.toolTextBankInfo})
        Me.toolStripBankInfo.Location = New System.Drawing.Point(528, 0)
        Me.toolStripBankInfo.Name = "toolStripBankInfo"
        Me.toolStripBankInfo.Size = New System.Drawing.Size(307, 28)
        Me.toolStripBankInfo.TabIndex = 2
        '
        'toolLabel1
        '
        Me.toolLabel1.Name = "toolLabel1"
        Me.toolLabel1.Size = New System.Drawing.Size(91, 25)
        Me.toolLabel1.Text = "Bank Info:"
        '
        'toolTextBankInfo
        '
        Me.toolTextBankInfo.AutoSize = False
        Me.toolTextBankInfo.BackColor = System.Drawing.SystemColors.Info
        Me.toolTextBankInfo.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.toolTextBankInfo.Name = "toolTextBankInfo"
        Me.toolTextBankInfo.ReadOnly = True
        Me.toolTextBankInfo.Size = New System.Drawing.Size(202, 25)
        '
        'toolStripDepositTotal
        '
        Me.toolStripDepositTotal.Dock = System.Windows.Forms.DockStyle.None
        Me.toolStripDepositTotal.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.toolStripDepositTotal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolLabel4, Me.toolTextDepositTotal})
        Me.toolStripDepositTotal.Location = New System.Drawing.Point(835, 0)
        Me.toolStripDepositTotal.Name = "toolStripDepositTotal"
        Me.toolStripDepositTotal.Size = New System.Drawing.Size(296, 37)
        Me.toolStripDepositTotal.TabIndex = 3
        '
        'ToolLabel4
        '
        Me.ToolLabel4.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolLabel4.Name = "ToolLabel4"
        Me.ToolLabel4.Size = New System.Drawing.Size(162, 34)
        Me.ToolLabel4.Text = "Deposit Total:"
        '
        'toolTextDepositTotal
        '
        Me.toolTextDepositTotal.BackColor = System.Drawing.SystemColors.Info
        Me.toolTextDepositTotal.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toolTextDepositTotal.Name = "toolTextDepositTotal"
        Me.toolTextDepositTotal.ReadOnly = True
        Me.toolTextDepositTotal.Size = New System.Drawing.Size(120, 37)
        Me.toolTextDepositTotal.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ToolStripStatus1
        '
        Me.ToolStripStatus1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripStatus1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStripStatus1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolLabelStatusText, Me.toolBtnPortIcon})
        Me.ToolStripStatus1.Location = New System.Drawing.Point(1131, 0)
        Me.ToolStripStatus1.Name = "ToolStripStatus1"
        Me.ToolStripStatus1.Size = New System.Drawing.Size(239, 31)
        Me.ToolStripStatus1.TabIndex = 4
        '
        'toolLabelStatusText
        '
        Me.toolLabelStatusText.ActiveLinkColor = System.Drawing.Color.Red
        Me.toolLabelStatusText.AutoSize = False
        Me.toolLabelStatusText.BackColor = System.Drawing.SystemColors.Info
        Me.toolLabelStatusText.Name = "toolLabelStatusText"
        Me.toolLabelStatusText.Size = New System.Drawing.Size(185, 22)
        '
        'toolBtnPortIcon
        '
        Me.toolBtnPortIcon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolBtnPortIcon.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolMnuDelayInterval})
        Me.toolBtnPortIcon.Image = CType(resources.GetObject("toolBtnPortIcon.Image"), System.Drawing.Image)
        Me.toolBtnPortIcon.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolBtnPortIcon.Name = "toolBtnPortIcon"
        Me.toolBtnPortIcon.Size = New System.Drawing.Size(42, 28)
        Me.toolBtnPortIcon.Text = "ToolStripButton1"
        Me.toolBtnPortIcon.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        Me.toolBtnPortIcon.ToolTipText = "Scanner Not Connected"
        '
        'toolMnuDelayInterval
        '
        Me.toolMnuDelayInterval.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolMnuDelayText})
        Me.toolMnuDelayInterval.Name = "toolMnuDelayInterval"
        Me.toolMnuDelayInterval.Size = New System.Drawing.Size(191, 30)
        Me.toolMnuDelayInterval.Text = "Delay Interval"
        '
        'toolMnuDelayText
        '
        Me.toolMnuDelayText.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.toolMnuDelayText.Name = "toolMnuDelayText"
        Me.toolMnuDelayText.Size = New System.Drawing.Size(100, 27)
        '
        'TextPanelFlyout1
        '
        Me.TextPanelFlyout1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextPanelFlyout1.AttachedSide = Flyout_Control.TextPanelFlyout.SideAttached.saBottom
        Me.TextPanelFlyout1.AutoSize = True
        Me.TextPanelFlyout1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TextPanelFlyout1.BackColor = System.Drawing.SystemColors.Control
        Me.TextPanelFlyout1.Location = New System.Drawing.Point(1082, 868)
        Me.TextPanelFlyout1.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.TextPanelFlyout1.Name = "TextPanelFlyout1"
        Me.TextPanelFlyout1.OpenedLength = 100
        Me.TextPanelFlyout1.Size = New System.Drawing.Size(408, 16)
        Me.TextPanelFlyout1.TabIndex = 32
        Me.TextPanelFlyout1.TextFlyoutText = ""
        Me.TextPanelFlyout1.TextPanelHeight = 6
        Me.TextPanelFlyout1.TextPanelWidth = 400
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.SystemColors.Control
        Me.Panel3.Controls.Add(Me.pnlBottomBarExtension)
        Me.Panel3.Location = New System.Drawing.Point(4, 866)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(854, 18)
        Me.Panel3.TabIndex = 33
        '
        'pnlBottomBarExtension
        '
        Me.pnlBottomBarExtension.BackColor = System.Drawing.SystemColors.ControlLight
        Me.pnlBottomBarExtension.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottomBarExtension.Location = New System.Drawing.Point(0, 9)
        Me.pnlBottomBarExtension.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.pnlBottomBarExtension.Name = "pnlBottomBarExtension"
        Me.pnlBottomBarExtension.Size = New System.Drawing.Size(854, 9)
        Me.pnlBottomBarExtension.TabIndex = 0
        '
        'ImagePanelFlyout1
        '
        Me.ImagePanelFlyout1.AttachedSide = Flyout_Control.ImagePanelFlyout.KeypadAttachModes.kamTop
        Me.ImagePanelFlyout1.AutoSize = True
        Me.ImagePanelFlyout1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ImagePanelFlyout1.BackColor = System.Drawing.SystemColors.Control
        Me.ImagePanelFlyout1.FlyOut = Flyout_Control.ImagePanelFlyout.FlyOutModes.fomClick
        Me.ImagePanelFlyout1.FlyOutImage = Nothing
        Me.ImagePanelFlyout1.ImagePanelHeight = 6
        Me.ImagePanelFlyout1.ImagePanelWidth = 450
        Me.ImagePanelFlyout1.Location = New System.Drawing.Point(0, 5)
        Me.ImagePanelFlyout1.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ImagePanelFlyout1.Name = "ImagePanelFlyout1"
        Me.ImagePanelFlyout1.OpenedInterval = 3000
        Me.ImagePanelFlyout1.OpenedLength = 250
        Me.ImagePanelFlyout1.Size = New System.Drawing.Size(458, 16)
        Me.ImagePanelFlyout1.TabIndex = 30
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.Panel2.Controls.Add(Me.pnlTopBarExtension)
        Me.Panel2.Location = New System.Drawing.Point(687, 8)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(866, 15)
        Me.Panel2.TabIndex = 31
        '
        'pnlTopBarExtension
        '
        Me.pnlTopBarExtension.BackColor = System.Drawing.SystemColors.ControlLight
        Me.pnlTopBarExtension.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTopBarExtension.Location = New System.Drawing.Point(0, 0)
        Me.pnlTopBarExtension.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.pnlTopBarExtension.Name = "pnlTopBarExtension"
        Me.pnlTopBarExtension.Size = New System.Drawing.Size(866, 9)
        Me.pnlTopBarExtension.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.39394!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.60606!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 731.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TabControl1, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.106796!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 96.8932!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1554, 912)
        Me.TableLayoutPanel1.TabIndex = 32
        '
        'TabControl1
        '
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons
        Me.TableLayoutPanel1.SetColumnSpan(Me.TabControl1, 3)
        Me.TabControl1.Controls.Add(Me.tpSelectDeposit)
        Me.TabControl1.Controls.Add(Me.tpViewDeposit)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(4, 32)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1546, 843)
        Me.TabControl1.TabIndex = 0
        Me.TabControl1.TabStop = False
        '
        'tpSelectDeposit
        '
        Me.tpSelectDeposit.BackColor = System.Drawing.SystemColors.Control
        Me.tpSelectDeposit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tpSelectDeposit.Controls.Add(Me.TableLayoutPanel2)
        Me.tpSelectDeposit.Location = New System.Drawing.Point(4, 32)
        Me.tpSelectDeposit.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tpSelectDeposit.Name = "tpSelectDeposit"
        Me.tpSelectDeposit.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tpSelectDeposit.Size = New System.Drawing.Size(1538, 807)
        Me.tpSelectDeposit.TabIndex = 0
        Me.tpSelectDeposit.Text = "Select Deposit"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 299.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.56306!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.43694!))
        Me.TableLayoutPanel2.Controls.Add(Me.Panel1, 2, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.lvBankAccounts, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel4, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lvDepositsList, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel5, 1, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(4, 5)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 4
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 77.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 192.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1528, 795)
        Me.TableLayoutPanel2.TabIndex = 19
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtDepDescript)
        Me.Panel1.Controls.Add(Me.ckbxNewDep)
        Me.Panel1.Controls.Add(Me.dateDepositDate)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(949, 128)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(575, 182)
        Me.Panel1.TabIndex = 22
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 20)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Deposit Date:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(152, 20)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Deposit Description:"
        '
        'ckbxNewDep
        '
        Me.ckbxNewDep.AutoSize = True
        Me.ckbxNewDep.Location = New System.Drawing.Point(3, 3)
        Me.ckbxNewDep.Name = "ckbxNewDep"
        Me.ckbxNewDep.Size = New System.Drawing.Size(158, 24)
        Me.ckbxNewDep.TabIndex = 12
        Me.ckbxNewDep.Text = "Add New Deposit"
        Me.ckbxNewDep.UseVisualStyleBackColor = True
        '
        'dateDepositDate
        '
        Me.dateDepositDate.Location = New System.Drawing.Point(20, 60)
        Me.dateDepositDate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dateDepositDate.Name = "dateDepositDate"
        Me.dateDepositDate.Size = New System.Drawing.Size(336, 26)
        Me.dateDepositDate.TabIndex = 11
        '
        'lvBankAccounts
        '
        Me.lvBankAccounts.BackColor = System.Drawing.SystemColors.Window
        Me.lvBankAccounts.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colHdrAcctId, Me.colHdrAcctType, Me.colHdrBankName})
        Me.lvBankAccounts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvBankAccounts.FullRowSelect = True
        ListViewGroup7.Header = "ListViewGroup"
        ListViewGroup7.Name = "ListViewGroup1"
        Me.lvBankAccounts.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup7})
        Me.lvBankAccounts.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvBankAccounts.HideSelection = False
        Me.lvBankAccounts.HoverSelection = True
        Me.lvBankAccounts.Location = New System.Drawing.Point(949, 320)
        Me.lvBankAccounts.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.lvBankAccounts.MultiSelect = False
        Me.lvBankAccounts.Name = "lvBankAccounts"
        Me.lvBankAccounts.Size = New System.Drawing.Size(575, 480)
        Me.lvBankAccounts.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvBankAccounts.StateImageList = Me.ImageList1
        Me.lvBankAccounts.TabIndex = 21
        Me.lvBankAccounts.UseCompatibleStateImageBehavior = False
        Me.lvBankAccounts.View = System.Windows.Forms.View.Details
        '
        'colHdrAcctId
        '
        Me.colHdrAcctId.Text = "Account Id"
        Me.colHdrAcctId.Width = 85
        '
        'colHdrAcctType
        '
        Me.colHdrAcctType.Text = "Account Type"
        Me.colHdrAcctType.Width = 100
        '
        'colHdrBankName
        '
        Me.colHdrBankName.Text = "Bank Name"
        Me.colHdrBankName.Width = 300
        '
        'Panel4
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.Panel4, 3)
        Me.Panel4.Controls.Add(Me.btnGetTicket)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(4, 5)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1520, 67)
        Me.Panel4.TabIndex = 0
        '
        'btnGetTicket
        '
        Me.btnGetTicket.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGetTicket.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnGetTicket.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnGetTicket.Enabled = False
        Me.btnGetTicket.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGetTicket.Location = New System.Drawing.Point(50, 9)
        Me.btnGetTicket.Name = "btnGetTicket"
        Me.btnGetTicket.Size = New System.Drawing.Size(1426, 54)
        Me.btnGetTicket.TabIndex = 18
        Me.btnGetTicket.Text = "Get Deposit Ticket"
        Me.btnGetTicket.UseVisualStyleBackColor = False
        '
        'lvDepositsList
        '
        Me.lvDepositsList.BackColor = System.Drawing.SystemColors.Window
        Me.lvDepositsList.CausesValidation = False
        Me.lvDepositsList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colHdrDepositNo, Me.colHdrDepositDate, Me.colHdrDescription, Me.colhdrTotal})
        Me.TableLayoutPanel2.SetColumnSpan(Me.lvDepositsList, 2)
        Me.lvDepositsList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvDepositsList.FullRowSelect = True
        Me.lvDepositsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvDepositsList.HideSelection = False
        Me.lvDepositsList.Location = New System.Drawing.Point(4, 128)
        Me.lvDepositsList.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.lvDepositsList.MultiSelect = False
        Me.lvDepositsList.Name = "lvDepositsList"
        Me.TableLayoutPanel2.SetRowSpan(Me.lvDepositsList, 2)
        Me.lvDepositsList.Size = New System.Drawing.Size(937, 672)
        Me.lvDepositsList.StateImageList = Me.ImageList1
        Me.lvDepositsList.TabIndex = 15
        Me.lvDepositsList.UseCompatibleStateImageBehavior = False
        Me.lvDepositsList.View = System.Windows.Forms.View.Details
        '
        'colHdrDepositNo
        '
        Me.colHdrDepositNo.Text = "Dep. No."
        Me.colHdrDepositNo.Width = 120
        '
        'colHdrDepositDate
        '
        Me.colHdrDepositDate.Text = "Dep. Date"
        Me.colHdrDepositDate.Width = 125
        '
        'colHdrDescription
        '
        Me.colHdrDescription.Text = "Description"
        Me.colHdrDescription.Width = 220
        '
        'colhdrTotal
        '
        Me.colhdrTotal.Text = "Dep. Total"
        Me.colhdrTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colhdrTotal.Width = 100
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 86)
        Me.Label1.Margin = New System.Windows.Forms.Padding(9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(180, 20)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Select Existing Deposit: "
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Label16)
        Me.Panel5.Controls.Add(Me.comboDateRange)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(302, 80)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(640, 40)
        Me.Panel5.TabIndex = 24
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(161, 6)
        Me.Label16.Margin = New System.Windows.Forms.Padding(9)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(163, 20)
        Me.Label16.TabIndex = 25
        Me.Label16.Text = "Filter by Date Range: "
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'comboDateRange
        '
        Me.comboDateRange.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.comboDateRange.FormattingEnabled = True
        Me.comboDateRange.Items.AddRange(New Object() {"This Year", "Last Year", "Last and This Year", "This Quarter", "All"})
        Me.comboDateRange.Location = New System.Drawing.Point(357, 3)
        Me.comboDateRange.Name = "comboDateRange"
        Me.comboDateRange.Size = New System.Drawing.Size(234, 28)
        Me.comboDateRange.TabIndex = 23
        '
        'tpViewDeposit
        '
        Me.tpViewDeposit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tpViewDeposit.Controls.Add(Me.TableLayoutPanel3)
        Me.tpViewDeposit.Location = New System.Drawing.Point(4, 32)
        Me.tpViewDeposit.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tpViewDeposit.Name = "tpViewDeposit"
        Me.tpViewDeposit.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tpViewDeposit.Size = New System.Drawing.Size(1538, 807)
        Me.tpViewDeposit.TabIndex = 1
        Me.tpViewDeposit.Text = "Edit Deposit"
        Me.tpViewDeposit.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 458.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.Controls.Add(Me.pnlCashRegister, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.TabControl2, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.pnlDepositInfo, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lvChecklist, 1, 1)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(4, 5)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 3
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 254.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1526, 793)
        Me.TableLayoutPanel3.TabIndex = 13
        '
        'pnlCashRegister
        '
        Me.pnlCashRegister.Controls.Add(Me.GroupBoxCurrency)
        Me.pnlCashRegister.Controls.Add(Me.Label38)
        Me.pnlCashRegister.Controls.Add(Me.txtCashTotal)
        Me.pnlCashRegister.Controls.Add(Me.GroupBoxCoins)
        Me.pnlCashRegister.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCashRegister.Location = New System.Drawing.Point(4, 5)
        Me.pnlCashRegister.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.pnlCashRegister.Name = "pnlCashRegister"
        Me.TableLayoutPanel3.SetRowSpan(Me.pnlCashRegister, 2)
        Me.pnlCashRegister.Size = New System.Drawing.Size(450, 344)
        Me.pnlCashRegister.TabIndex = 7
        '
        'GroupBoxCurrency
        '
        Me.GroupBoxCurrency.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxCurrency.Controls.Add(Me.txtOneCt)
        Me.GroupBoxCurrency.Controls.Add(Me.txtFiveCt)
        Me.GroupBoxCurrency.Controls.Add(Me.txtTenCt)
        Me.GroupBoxCurrency.Controls.Add(Me.txtTwentyCt)
        Me.GroupBoxCurrency.Controls.Add(Me.txtFiftyCt)
        Me.GroupBoxCurrency.Controls.Add(Me.txtHundredCt)
        Me.GroupBoxCurrency.Controls.Add(Me.Label5)
        Me.GroupBoxCurrency.Controls.Add(Me.Label8)
        Me.GroupBoxCurrency.Controls.Add(Me.txtOne)
        Me.GroupBoxCurrency.Controls.Add(Me.txtFive)
        Me.GroupBoxCurrency.Controls.Add(Me.txtTen)
        Me.GroupBoxCurrency.Controls.Add(Me.txtTwenty)
        Me.GroupBoxCurrency.Controls.Add(Me.txtFifty)
        Me.GroupBoxCurrency.Controls.Add(Me.txtHundred)
        Me.GroupBoxCurrency.Controls.Add(Me.Label9)
        Me.GroupBoxCurrency.Controls.Add(Me.Label10)
        Me.GroupBoxCurrency.Controls.Add(Me.Label11)
        Me.GroupBoxCurrency.Controls.Add(Me.Label12)
        Me.GroupBoxCurrency.Controls.Add(Me.Label13)
        Me.GroupBoxCurrency.Controls.Add(Me.Label14)
        Me.GroupBoxCurrency.Controls.Add(Me.Label15)
        Me.GroupBoxCurrency.Controls.Add(Me.txtCurrencyTotal)
        Me.GroupBoxCurrency.Location = New System.Drawing.Point(225, 49)
        Me.GroupBoxCurrency.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBoxCurrency.Name = "GroupBoxCurrency"
        Me.GroupBoxCurrency.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBoxCurrency.Size = New System.Drawing.Size(218, 278)
        Me.GroupBoxCurrency.TabIndex = 8
        Me.GroupBoxCurrency.TabStop = False
        Me.GroupBoxCurrency.Text = "Currency Denominations"
        '
        'txtOneCt
        '
        Me.txtOneCt.AdvanceOnEnterKey = False
        Me.txtOneCt.DecimalPlaces = 0
        Me.txtOneCt.FormatString = ""
        Me.txtOneCt.Location = New System.Drawing.Point(8, 200)
        Me.txtOneCt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtOneCt.Name = "txtOneCt"
        Me.txtOneCt.Size = New System.Drawing.Size(43, 26)
        Me.txtOneCt.TabIndex = 12
        Me.txtOneCt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFiveCt
        '
        Me.txtFiveCt.AdvanceOnEnterKey = False
        Me.txtFiveCt.DecimalPlaces = 0
        Me.txtFiveCt.FormatString = ""
        Me.txtFiveCt.Location = New System.Drawing.Point(8, 169)
        Me.txtFiveCt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtFiveCt.Name = "txtFiveCt"
        Me.txtFiveCt.Size = New System.Drawing.Size(43, 26)
        Me.txtFiveCt.TabIndex = 11
        Me.txtFiveCt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTenCt
        '
        Me.txtTenCt.AdvanceOnEnterKey = False
        Me.txtTenCt.DecimalPlaces = 0
        Me.txtTenCt.FormatString = ""
        Me.txtTenCt.Location = New System.Drawing.Point(8, 138)
        Me.txtTenCt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtTenCt.Name = "txtTenCt"
        Me.txtTenCt.Size = New System.Drawing.Size(43, 26)
        Me.txtTenCt.TabIndex = 10
        Me.txtTenCt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTwentyCt
        '
        Me.txtTwentyCt.AdvanceOnEnterKey = False
        Me.txtTwentyCt.DecimalPlaces = 0
        Me.txtTwentyCt.FormatString = ""
        Me.txtTwentyCt.Location = New System.Drawing.Point(8, 108)
        Me.txtTwentyCt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtTwentyCt.Name = "txtTwentyCt"
        Me.txtTwentyCt.Size = New System.Drawing.Size(43, 26)
        Me.txtTwentyCt.TabIndex = 9
        Me.txtTwentyCt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFiftyCt
        '
        Me.txtFiftyCt.AdvanceOnEnterKey = False
        Me.txtFiftyCt.DecimalPlaces = 0
        Me.txtFiftyCt.FormatString = ""
        Me.txtFiftyCt.Location = New System.Drawing.Point(8, 77)
        Me.txtFiftyCt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtFiftyCt.Name = "txtFiftyCt"
        Me.txtFiftyCt.Size = New System.Drawing.Size(43, 26)
        Me.txtFiftyCt.TabIndex = 8
        Me.txtFiftyCt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtHundredCt
        '
        Me.txtHundredCt.AdvanceOnEnterKey = False
        Me.txtHundredCt.DecimalPlaces = 0
        Me.txtHundredCt.FormatString = ""
        Me.txtHundredCt.Location = New System.Drawing.Point(8, 46)
        Me.txtHundredCt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtHundredCt.Name = "txtHundredCt"
        Me.txtHundredCt.Size = New System.Drawing.Size(43, 26)
        Me.txtHundredCt.TabIndex = 7
        Me.txtHundredCt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(130, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 20)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Subtotal"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 20)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Count"
        '
        'txtOne
        '
        Me.txtOne.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOne.Location = New System.Drawing.Point(123, 200)
        Me.txtOne.Name = "txtOne"
        Me.txtOne.ReadOnly = True
        Me.txtOne.Size = New System.Drawing.Size(86, 26)
        Me.txtOne.TabIndex = 23
        Me.txtOne.TabStop = False
        Me.txtOne.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFive
        '
        Me.txtFive.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFive.Location = New System.Drawing.Point(123, 169)
        Me.txtFive.Name = "txtFive"
        Me.txtFive.ReadOnly = True
        Me.txtFive.Size = New System.Drawing.Size(86, 26)
        Me.txtFive.TabIndex = 22
        Me.txtFive.TabStop = False
        Me.txtFive.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTen
        '
        Me.txtTen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTen.Location = New System.Drawing.Point(123, 138)
        Me.txtTen.Name = "txtTen"
        Me.txtTen.ReadOnly = True
        Me.txtTen.Size = New System.Drawing.Size(86, 26)
        Me.txtTen.TabIndex = 21
        Me.txtTen.TabStop = False
        Me.txtTen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTwenty
        '
        Me.txtTwenty.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTwenty.Location = New System.Drawing.Point(123, 108)
        Me.txtTwenty.Name = "txtTwenty"
        Me.txtTwenty.ReadOnly = True
        Me.txtTwenty.Size = New System.Drawing.Size(86, 26)
        Me.txtTwenty.TabIndex = 20
        Me.txtTwenty.TabStop = False
        Me.txtTwenty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFifty
        '
        Me.txtFifty.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFifty.Location = New System.Drawing.Point(123, 77)
        Me.txtFifty.Name = "txtFifty"
        Me.txtFifty.ReadOnly = True
        Me.txtFifty.Size = New System.Drawing.Size(86, 26)
        Me.txtFifty.TabIndex = 19
        Me.txtFifty.TabStop = False
        Me.txtFifty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtHundred
        '
        Me.txtHundred.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHundred.Location = New System.Drawing.Point(123, 46)
        Me.txtHundred.Name = "txtHundred"
        Me.txtHundred.ReadOnly = True
        Me.txtHundred.Size = New System.Drawing.Size(86, 26)
        Me.txtHundred.TabIndex = 18
        Me.txtHundred.TabStop = False
        Me.txtHundred.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(60, 82)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 20)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "X $50"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(60, 205)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 20)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "X $1"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(60, 174)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(42, 20)
        Me.Label11.TabIndex = 15
        Me.Label11.Text = "X $5"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(60, 112)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(51, 20)
        Me.Label12.TabIndex = 14
        Me.Label12.Text = "X $20"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(60, 143)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(51, 20)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "X $10"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(60, 51)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(60, 20)
        Me.Label14.TabIndex = 12
        Me.Label14.Text = "X $100"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(3, 243)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(115, 20)
        Me.Label15.TabIndex = 7
        Me.Label15.Text = "Total Currency:"
        '
        'txtCurrencyTotal
        '
        Me.txtCurrencyTotal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCurrencyTotal.Location = New System.Drawing.Point(120, 238)
        Me.txtCurrencyTotal.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtCurrencyTotal.Name = "txtCurrencyTotal"
        Me.txtCurrencyTotal.ReadOnly = True
        Me.txtCurrencyTotal.Size = New System.Drawing.Size(87, 26)
        Me.txtCurrencyTotal.TabIndex = 6
        Me.txtCurrencyTotal.TabStop = False
        Me.txtCurrencyTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(111, 12)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(143, 22)
        Me.Label38.TabIndex = 7
        Me.Label38.Text = "Cash Register:"
        '
        'txtCashTotal
        '
        Me.txtCashTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCashTotal.Location = New System.Drawing.Point(268, 8)
        Me.txtCashTotal.Name = "txtCashTotal"
        Me.txtCashTotal.ReadOnly = True
        Me.txtCashTotal.Size = New System.Drawing.Size(166, 30)
        Me.txtCashTotal.TabIndex = 6
        Me.txtCashTotal.TabStop = False
        '
        'GroupBoxCoins
        '
        Me.GroupBoxCoins.Controls.Add(Me.txtPennyCt)
        Me.GroupBoxCoins.Controls.Add(Me.txtNickelCt)
        Me.GroupBoxCoins.Controls.Add(Me.txtDimeCt)
        Me.GroupBoxCoins.Controls.Add(Me.txtQuarterCt)
        Me.GroupBoxCoins.Controls.Add(Me.txtHalfDollarCt)
        Me.GroupBoxCoins.Controls.Add(Me.txtDollarCoinCt)
        Me.GroupBoxCoins.Controls.Add(Me.Label35)
        Me.GroupBoxCoins.Controls.Add(Me.Label34)
        Me.GroupBoxCoins.Controls.Add(Me.txtPenny)
        Me.GroupBoxCoins.Controls.Add(Me.txtNickel)
        Me.GroupBoxCoins.Controls.Add(Me.txtDime)
        Me.GroupBoxCoins.Controls.Add(Me.txtQuarter)
        Me.GroupBoxCoins.Controls.Add(Me.txtHalfDollar)
        Me.GroupBoxCoins.Controls.Add(Me.txtDollarCoin)
        Me.GroupBoxCoins.Controls.Add(Me.Label25)
        Me.GroupBoxCoins.Controls.Add(Me.Label24)
        Me.GroupBoxCoins.Controls.Add(Me.Label23)
        Me.GroupBoxCoins.Controls.Add(Me.Label22)
        Me.GroupBoxCoins.Controls.Add(Me.Label7)
        Me.GroupBoxCoins.Controls.Add(Me.Label6)
        Me.GroupBoxCoins.Controls.Add(Me.Label2)
        Me.GroupBoxCoins.Controls.Add(Me.txtCoinTotal)
        Me.GroupBoxCoins.Location = New System.Drawing.Point(12, 49)
        Me.GroupBoxCoins.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBoxCoins.Name = "GroupBoxCoins"
        Me.GroupBoxCoins.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBoxCoins.Size = New System.Drawing.Size(207, 278)
        Me.GroupBoxCoins.TabIndex = 1
        Me.GroupBoxCoins.TabStop = False
        Me.GroupBoxCoins.Text = "Coin Denominations"
        '
        'txtPennyCt
        '
        Me.txtPennyCt.AdvanceOnEnterKey = False
        Me.txtPennyCt.DecimalPlaces = 0
        Me.txtPennyCt.FormatString = Nothing
        Me.txtPennyCt.Location = New System.Drawing.Point(8, 200)
        Me.txtPennyCt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtPennyCt.Name = "txtPennyCt"
        Me.txtPennyCt.Size = New System.Drawing.Size(43, 26)
        Me.txtPennyCt.TabIndex = 6
        Me.txtPennyCt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNickelCt
        '
        Me.txtNickelCt.AdvanceOnEnterKey = False
        Me.txtNickelCt.DecimalPlaces = 0
        Me.txtNickelCt.FormatString = Nothing
        Me.txtNickelCt.Location = New System.Drawing.Point(8, 169)
        Me.txtNickelCt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtNickelCt.Name = "txtNickelCt"
        Me.txtNickelCt.Size = New System.Drawing.Size(43, 26)
        Me.txtNickelCt.TabIndex = 5
        Me.txtNickelCt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDimeCt
        '
        Me.txtDimeCt.AdvanceOnEnterKey = False
        Me.txtDimeCt.DecimalPlaces = 0
        Me.txtDimeCt.FormatString = Nothing
        Me.txtDimeCt.Location = New System.Drawing.Point(8, 138)
        Me.txtDimeCt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtDimeCt.Name = "txtDimeCt"
        Me.txtDimeCt.Size = New System.Drawing.Size(43, 26)
        Me.txtDimeCt.TabIndex = 4
        Me.txtDimeCt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtQuarterCt
        '
        Me.txtQuarterCt.AdvanceOnEnterKey = False
        Me.txtQuarterCt.DecimalPlaces = 0
        Me.txtQuarterCt.FormatString = Nothing
        Me.txtQuarterCt.Location = New System.Drawing.Point(8, 108)
        Me.txtQuarterCt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtQuarterCt.Name = "txtQuarterCt"
        Me.txtQuarterCt.Size = New System.Drawing.Size(43, 26)
        Me.txtQuarterCt.TabIndex = 3
        Me.txtQuarterCt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtHalfDollarCt
        '
        Me.txtHalfDollarCt.AdvanceOnEnterKey = False
        Me.txtHalfDollarCt.DecimalPlaces = 0
        Me.txtHalfDollarCt.FormatString = Nothing
        Me.txtHalfDollarCt.Location = New System.Drawing.Point(8, 77)
        Me.txtHalfDollarCt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtHalfDollarCt.Name = "txtHalfDollarCt"
        Me.txtHalfDollarCt.Size = New System.Drawing.Size(43, 26)
        Me.txtHalfDollarCt.TabIndex = 2
        Me.txtHalfDollarCt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDollarCoinCt
        '
        Me.txtDollarCoinCt.AdvanceOnEnterKey = False
        Me.txtDollarCoinCt.DecimalPlaces = 0
        Me.txtDollarCoinCt.FormatString = ""
        Me.txtDollarCoinCt.Location = New System.Drawing.Point(8, 46)
        Me.txtDollarCoinCt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtDollarCoinCt.Name = "txtDollarCoinCt"
        Me.txtDollarCoinCt.Size = New System.Drawing.Size(43, 26)
        Me.txtDollarCoinCt.TabIndex = 1
        Me.txtDollarCoinCt.Text = "0"
        Me.txtDollarCoinCt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(130, 22)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(69, 20)
        Me.Label35.TabIndex = 25
        Me.Label35.Text = "Subtotal"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(6, 22)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(52, 20)
        Me.Label34.TabIndex = 24
        Me.Label34.Text = "Count"
        '
        'txtPenny
        '
        Me.txtPenny.Location = New System.Drawing.Point(134, 200)
        Me.txtPenny.Name = "txtPenny"
        Me.txtPenny.ReadOnly = True
        Me.txtPenny.Size = New System.Drawing.Size(61, 26)
        Me.txtPenny.TabIndex = 23
        Me.txtPenny.TabStop = False
        Me.txtPenny.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNickel
        '
        Me.txtNickel.Location = New System.Drawing.Point(134, 169)
        Me.txtNickel.Name = "txtNickel"
        Me.txtNickel.ReadOnly = True
        Me.txtNickel.Size = New System.Drawing.Size(61, 26)
        Me.txtNickel.TabIndex = 22
        Me.txtNickel.TabStop = False
        Me.txtNickel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDime
        '
        Me.txtDime.Location = New System.Drawing.Point(134, 138)
        Me.txtDime.Name = "txtDime"
        Me.txtDime.ReadOnly = True
        Me.txtDime.Size = New System.Drawing.Size(61, 26)
        Me.txtDime.TabIndex = 21
        Me.txtDime.TabStop = False
        Me.txtDime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtQuarter
        '
        Me.txtQuarter.Location = New System.Drawing.Point(134, 108)
        Me.txtQuarter.Name = "txtQuarter"
        Me.txtQuarter.ReadOnly = True
        Me.txtQuarter.Size = New System.Drawing.Size(61, 26)
        Me.txtQuarter.TabIndex = 20
        Me.txtQuarter.TabStop = False
        Me.txtQuarter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtHalfDollar
        '
        Me.txtHalfDollar.Location = New System.Drawing.Point(134, 78)
        Me.txtHalfDollar.Name = "txtHalfDollar"
        Me.txtHalfDollar.ReadOnly = True
        Me.txtHalfDollar.Size = New System.Drawing.Size(61, 26)
        Me.txtHalfDollar.TabIndex = 19
        Me.txtHalfDollar.TabStop = False
        Me.txtHalfDollar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDollarCoin
        '
        Me.txtDollarCoin.Location = New System.Drawing.Point(134, 46)
        Me.txtDollarCoin.Name = "txtDollarCoin"
        Me.txtDollarCoin.ReadOnly = True
        Me.txtDollarCoin.Size = New System.Drawing.Size(61, 26)
        Me.txtDollarCoin.TabIndex = 18
        Me.txtDollarCoin.TabStop = False
        Me.txtDollarCoin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(60, 82)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(53, 20)
        Me.Label25.TabIndex = 17
        Me.Label25.Text = "X Half"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(60, 205)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(68, 20)
        Me.Label24.TabIndex = 16
        Me.Label24.Text = "X Penny"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(60, 174)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(66, 20)
        Me.Label23.TabIndex = 15
        Me.Label23.Text = "X Nickel"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(60, 112)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(78, 20)
        Me.Label22.TabIndex = 14
        Me.Label22.Text = "X Quarter"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(60, 143)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 20)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "X Dime"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(60, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 20)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "X Dollar"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 243)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 20)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Total Coin:"
        '
        'txtCoinTotal
        '
        Me.txtCoinTotal.Location = New System.Drawing.Point(104, 238)
        Me.txtCoinTotal.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtCoinTotal.Name = "txtCoinTotal"
        Me.txtCoinTotal.ReadOnly = True
        Me.txtCoinTotal.Size = New System.Drawing.Size(91, 26)
        Me.txtCoinTotal.TabIndex = 6
        Me.txtCoinTotal.TabStop = False
        Me.txtCoinTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'pnlDepositInfo
        '
        Me.pnlDepositInfo.Controls.Add(Me.txtChecksCount)
        Me.pnlDepositInfo.Controls.Add(Me.lblDepDate)
        Me.pnlDepositInfo.Controls.Add(Me.lblDepDescript)
        Me.pnlDepositInfo.Controls.Add(Me.txtDepositNo)
        Me.pnlDepositInfo.Controls.Add(Me.txtChecksTotal)
        Me.pnlDepositInfo.Controls.Add(Me.Label30)
        Me.pnlDepositInfo.Controls.Add(Me.Label29)
        Me.pnlDepositInfo.Controls.Add(Me.Label27)
        Me.pnlDepositInfo.Controls.Add(Me.Label26)
        Me.pnlDepositInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDepositInfo.Location = New System.Drawing.Point(462, 5)
        Me.pnlDepositInfo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.pnlDepositInfo.Name = "pnlDepositInfo"
        Me.pnlDepositInfo.Size = New System.Drawing.Size(1060, 90)
        Me.pnlDepositInfo.TabIndex = 8
        '
        'txtChecksCount
        '
        Me.txtChecksCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChecksCount.Location = New System.Drawing.Point(633, 51)
        Me.txtChecksCount.Name = "txtChecksCount"
        Me.txtChecksCount.ReadOnly = True
        Me.txtChecksCount.Size = New System.Drawing.Size(58, 30)
        Me.txtChecksCount.TabIndex = 24
        Me.txtChecksCount.TabStop = False
        '
        'lblDepDate
        '
        Me.lblDepDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepDate.Location = New System.Drawing.Point(112, 51)
        Me.lblDepDate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDepDate.Name = "lblDepDate"
        Me.lblDepDate.Size = New System.Drawing.Size(142, 32)
        Me.lblDepDate.TabIndex = 23
        Me.lblDepDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDepDescript
        '
        Me.lblDepDescript.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepDescript.Location = New System.Drawing.Point(400, 5)
        Me.lblDepDescript.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDepDescript.Name = "lblDepDescript"
        Me.lblDepDescript.Size = New System.Drawing.Size(279, 35)
        Me.lblDepDescript.TabIndex = 22
        Me.lblDepDescript.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDepositNo
        '
        Me.txtDepositNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDepositNo.Location = New System.Drawing.Point(112, 12)
        Me.txtDepositNo.Name = "txtDepositNo"
        Me.txtDepositNo.ReadOnly = True
        Me.txtDepositNo.Size = New System.Drawing.Size(140, 28)
        Me.txtDepositNo.TabIndex = 21
        Me.txtDepositNo.TabStop = False
        '
        'txtChecksTotal
        '
        Me.txtChecksTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChecksTotal.Location = New System.Drawing.Point(444, 51)
        Me.txtChecksTotal.Name = "txtChecksTotal"
        Me.txtChecksTotal.ReadOnly = True
        Me.txtChecksTotal.Size = New System.Drawing.Size(181, 30)
        Me.txtChecksTotal.TabIndex = 20
        Me.txtChecksTotal.TabStop = False
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(276, 55)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(153, 22)
        Me.Label30.TabIndex = 16
        Me.Label30.Text = "Check Register:"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(8, 17)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(96, 20)
        Me.Label29.TabIndex = 15
        Me.Label29.Text = "Deposit No.:"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(276, 14)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(114, 20)
        Me.Label27.TabIndex = 12
        Me.Label27.Text = "Dep. Descript.:"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(3, 57)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(107, 20)
        Me.Label26.TabIndex = 11
        Me.Label26.Text = "Deposit Date:"
        '
        'lvChecklist
        '
        Me.lvChecklist.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lvChecklist.BackColor = System.Drawing.SystemColors.Window
        Me.lvChecklist.ContextMenuStrip = Me.ContextMenuLVChecks
        Me.lvChecklist.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvChecklist.Dock = System.Windows.Forms.DockStyle.Fill
        ListViewGroup6.Header = "Not Assigned"
        ListViewGroup6.Name = "csNone"
        ListViewGroup8.Header = "Amount Pending"
        ListViewGroup8.Name = "csAmountPending"
        ListViewGroup9.Header = "Edit Pending"
        ListViewGroup9.Name = "csEditPending"
        ListViewGroup10.Header = "Confirm Pending"
        ListViewGroup10.Name = "csConfirmPending"
        ListViewGroup11.Header = "Verified"
        ListViewGroup11.Name = "csVerified"
        Me.lvChecklist.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup6, ListViewGroup8, ListViewGroup9, ListViewGroup10, ListViewGroup11})
        Me.lvChecklist.HideSelection = False
        Me.lvChecklist.Location = New System.Drawing.Point(462, 105)
        Me.lvChecklist.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.lvChecklist.MultiSelect = False
        Me.lvChecklist.Name = "lvChecklist"
        Me.lvChecklist.Size = New System.Drawing.Size(1060, 244)
        Me.lvChecklist.StateImageList = Me.ImageListStates
        Me.lvChecklist.TabIndex = 12
        Me.lvChecklist.TileSize = New System.Drawing.Size(120, 15)
        Me.lvChecklist.UseCompatibleStateImageBehavior = False
        Me.lvChecklist.View = System.Windows.Forms.View.Tile
        '
        'ImageListStates
        '
        Me.ImageListStates.ImageStream = CType(resources.GetObject("ImageListStates.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageListStates.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageListStates.Images.SetKeyName(0, "tick.png")
        Me.ImageListStates.Images.SetKeyName(1, "80 yellow flag.png")
        Me.ImageListStates.Images.SetKeyName(2, "flag-yellow.png")
        Me.ImageListStates.Images.SetKeyName(3, "flag-blue.png")
        Me.ImageListStates.Images.SetKeyName(4, "81 blue flag.png")
        Me.ImageListStates.Images.SetKeyName(5, "flag--pencil.png")
        Me.ImageListStates.Images.SetKeyName(6, "tick-small.png")
        Me.ImageListStates.Images.SetKeyName(7, "flag-small.png")
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ToolStripMenuItem1, Me.OptionsToolStripMenuItem, Me.HelpsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip1.Size = New System.Drawing.Size(1554, 33)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolSeparator1, Me.mnuExit})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(50, 29)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'ToolSeparator1
        '
        Me.ToolSeparator1.Name = "ToolSeparator1"
        Me.ToolSeparator1.Size = New System.Drawing.Size(116, 6)
        '
        'mnuExit
        '
        Me.mnuExit.Image = Global.TellerAssistant2012.My.Resources.Resources.Cancel_Red_24
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.Size = New System.Drawing.Size(119, 30)
        Me.mnuExit.Text = "E&xit"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAddManualCheck, Me.mnuEditSelectedCheck, Me.mnuDeleteSelectedCheck})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(54, 29)
        Me.EditToolStripMenuItem.Text = "&Edit"
        '
        'mnuAddManualCheck
        '
        Me.mnuAddManualCheck.Image = Global.TellerAssistant2012.My.Resources.Resources.NewCardHS
        Me.mnuAddManualCheck.Name = "mnuAddManualCheck"
        Me.mnuAddManualCheck.Size = New System.Drawing.Size(218, 30)
        Me.mnuAddManualCheck.Text = "Add New Check"
        '
        'mnuEditSelectedCheck
        '
        Me.mnuEditSelectedCheck.Image = Global.TellerAssistant2012.My.Resources.Resources.EditInformationHS
        Me.mnuEditSelectedCheck.Name = "mnuEditSelectedCheck"
        Me.mnuEditSelectedCheck.Size = New System.Drawing.Size(218, 30)
        Me.mnuEditSelectedCheck.Text = "Edit Check"
        '
        'mnuDeleteSelectedCheck
        '
        Me.mnuDeleteSelectedCheck.Image = Global.TellerAssistant2012.My.Resources.Resources.Trash
        Me.mnuDeleteSelectedCheck.Name = "mnuDeleteSelectedCheck"
        Me.mnuDeleteSelectedCheck.Size = New System.Drawing.Size(218, 30)
        Me.mnuDeleteSelectedCheck.Text = "Delete ChecK"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPrintTicket, Me.mnuPrintReport, Me.mnuPageSetup, Me.ToolStripSeparator5, Me.mnuCheckSearch, Me.mnuPrintReceipts})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(86, 29)
        Me.ToolStripMenuItem1.Text = "&Reports"
        '
        'mnuPrintTicket
        '
        Me.mnuPrintTicket.Image = Global.TellerAssistant2012.My.Resources.Resources.PrintHS
        Me.mnuPrintTicket.Name = "mnuPrintTicket"
        Me.mnuPrintTicket.Size = New System.Drawing.Size(240, 30)
        Me.mnuPrintTicket.Text = "Print Ticket"
        '
        'mnuPrintReport
        '
        Me.mnuPrintReport.Image = Global.TellerAssistant2012.My.Resources.Resources.PrintHSReport
        Me.mnuPrintReport.Name = "mnuPrintReport"
        Me.mnuPrintReport.Size = New System.Drawing.Size(240, 30)
        Me.mnuPrintReport.Text = "Print Report"
        '
        'mnuPageSetup
        '
        Me.mnuPageSetup.Name = "mnuPageSetup"
        Me.mnuPageSetup.Size = New System.Drawing.Size(240, 30)
        Me.mnuPageSetup.Text = "Page/Printer Setup"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(237, 6)
        '
        'mnuCheckSearch
        '
        Me.mnuCheckSearch.Image = Global.TellerAssistant2012.My.Resources.Resources.Folder_Doc_Search_16
        Me.mnuCheckSearch.Name = "mnuCheckSearch"
        Me.mnuCheckSearch.Size = New System.Drawing.Size(240, 30)
        Me.mnuCheckSearch.Text = "Search for Checks"
        '
        'mnuPrintReceipts
        '
        Me.mnuPrintReceipts.Name = "mnuPrintReceipts"
        Me.mnuPrintReceipts.Size = New System.Drawing.Size(240, 30)
        Me.mnuPrintReceipts.Text = "Print Receipts"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAddEditBanks, Me.ToolStripSeparator2, Me.mnuPrintFormSetup, Me.ToolStripSeparator3, Me.mnuInitScanner, Me.mnuResetScanner, Me.mnuCommunicationMode, Me.ToolStripSeparator1, Me.mnuEditAppSettings, Me.ToolStripSeparator4, Me.EventLoggingToolStripMenuItem, Me.mnuManageImageFiles})
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(88, 29)
        Me.OptionsToolStripMenuItem.Text = "&Options"
        '
        'mnuAddEditBanks
        '
        Me.mnuAddEditBanks.Image = Global.TellerAssistant2012.My.Resources.Resources.Bank_List
        Me.mnuAddEditBanks.Name = "mnuAddEditBanks"
        Me.mnuAddEditBanks.Size = New System.Drawing.Size(337, 30)
        Me.mnuAddEditBanks.Text = "&Add/Edit Banks"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(334, 6)
        '
        'mnuPrintFormSetup
        '
        Me.mnuPrintFormSetup.Name = "mnuPrintFormSetup"
        Me.mnuPrintFormSetup.Size = New System.Drawing.Size(337, 30)
        Me.mnuPrintFormSetup.Text = "Print Form Setup"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(334, 6)
        '
        'mnuInitScanner
        '
        Me.mnuInitScanner.Image = Global.TellerAssistant2012.My.Resources.Resources.MICRImageInitialize
        Me.mnuInitScanner.Name = "mnuInitScanner"
        Me.mnuInitScanner.Size = New System.Drawing.Size(337, 30)
        Me.mnuInitScanner.Text = "Initialize Scanner"
        '
        'mnuResetScanner
        '
        Me.mnuResetScanner.Image = Global.TellerAssistant2012.My.Resources.Resources.MICRImageReset3
        Me.mnuResetScanner.Name = "mnuResetScanner"
        Me.mnuResetScanner.Size = New System.Drawing.Size(337, 30)
        Me.mnuResetScanner.Text = "Reset Scanner"
        '
        'mnuCommunicationMode
        '
        Me.mnuCommunicationMode.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFTP, Me.mnuRS232})
        Me.mnuCommunicationMode.Name = "mnuCommunicationMode"
        Me.mnuCommunicationMode.Size = New System.Drawing.Size(337, 30)
        Me.mnuCommunicationMode.Text = "Scanner &Communication Mode"
        '
        'mnuFTP
        '
        Me.mnuFTP.CheckOnClick = True
        Me.mnuFTP.Image = Global.TellerAssistant2012.My.Resources.Resources.NetworkConn
        Me.mnuFTP.Name = "mnuFTP"
        Me.mnuFTP.Size = New System.Drawing.Size(415, 30)
        Me.mnuFTP.Text = "FTP (Connect to Network)"
        '
        'mnuRS232
        '
        Me.mnuRS232.CheckOnClick = True
        Me.mnuRS232.Image = CType(resources.GetObject("mnuRS232.Image"), System.Drawing.Image)
        Me.mnuRS232.Name = "mnuRS232"
        Me.mnuRS232.Size = New System.Drawing.Size(415, 30)
        Me.mnuRS232.Text = "RS232 (Connect to Computer Serial Port)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(334, 6)
        '
        'mnuEditAppSettings
        '
        Me.mnuEditAppSettings.Name = "mnuEditAppSettings"
        Me.mnuEditAppSettings.Size = New System.Drawing.Size(337, 30)
        Me.mnuEditAppSettings.Text = "Edit Application Settings"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(334, 6)
        '
        'EventLoggingToolStripMenuItem
        '
        Me.EventLoggingToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuViewExceptionLog, Me.mnuLoggingOn})
        Me.EventLoggingToolStripMenuItem.Name = "EventLoggingToolStripMenuItem"
        Me.EventLoggingToolStripMenuItem.Size = New System.Drawing.Size(337, 30)
        Me.EventLoggingToolStripMenuItem.Text = "Event Logging"
        '
        'mnuViewExceptionLog
        '
        Me.mnuViewExceptionLog.Name = "mnuViewExceptionLog"
        Me.mnuViewExceptionLog.Size = New System.Drawing.Size(237, 30)
        Me.mnuViewExceptionLog.Text = "View Exception Log"
        '
        'mnuLoggingOn
        '
        Me.mnuLoggingOn.Name = "mnuLoggingOn"
        Me.mnuLoggingOn.Size = New System.Drawing.Size(237, 30)
        Me.mnuLoggingOn.Text = "Turn logging on"
        '
        'mnuManageImageFiles
        '
        Me.mnuManageImageFiles.Name = "mnuManageImageFiles"
        Me.mnuManageImageFiles.Size = New System.Drawing.Size(337, 30)
        Me.mnuManageImageFiles.Text = "Manage Image Files"
        '
        'HelpsToolStripMenuItem
        '
        Me.HelpsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAbout})
        Me.HelpsToolStripMenuItem.Name = "HelpsToolStripMenuItem"
        Me.HelpsToolStripMenuItem.Size = New System.Drawing.Size(61, 29)
        Me.HelpsToolStripMenuItem.Text = "&Help"
        '
        'mnuAbout
        '
        Me.mnuAbout.Name = "mnuAbout"
        Me.mnuAbout.Size = New System.Drawing.Size(134, 30)
        Me.mnuAbout.Text = "About"
        '
        'ToolStripTop
        '
        Me.ToolStripTop.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripTop.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStripTop.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolbtnPrintTicket, Me.ToolSeparator2, Me.toolBtnCheckSearch, Me.ToolStripSeparator7, Me.toolbtnAddCheck, Me.toolbtnEditCheck, Me.toolbtnDeleteCheck, Me.ToolStripSeparator6, Me.toolBtnExit})
        Me.ToolStripTop.Location = New System.Drawing.Point(3, 33)
        Me.ToolStripTop.Name = "ToolStripTop"
        Me.ToolStripTop.Size = New System.Drawing.Size(613, 56)
        Me.ToolStripTop.TabIndex = 0
        '
        'toolbtnPrintTicket
        '
        Me.toolbtnPrintTicket.Image = CType(resources.GetObject("toolbtnPrintTicket.Image"), System.Drawing.Image)
        Me.toolbtnPrintTicket.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.toolbtnPrintTicket.ImageTransparentColor = System.Drawing.Color.Black
        Me.toolbtnPrintTicket.Name = "toolbtnPrintTicket"
        Me.toolbtnPrintTicket.Size = New System.Drawing.Size(102, 53)
        Me.toolbtnPrintTicket.Text = "Print Ticket"
        Me.toolbtnPrintTicket.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.toolbtnPrintTicket.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolSeparator2
        '
        Me.ToolSeparator2.Name = "ToolSeparator2"
        Me.ToolSeparator2.Size = New System.Drawing.Size(6, 56)
        '
        'toolBtnCheckSearch
        '
        Me.toolBtnCheckSearch.Image = Global.TellerAssistant2012.My.Resources.Resources.Folder_Doc_Search_16
        Me.toolBtnCheckSearch.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.toolBtnCheckSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolBtnCheckSearch.Name = "toolBtnCheckSearch"
        Me.toolBtnCheckSearch.Size = New System.Drawing.Size(120, 53)
        Me.toolBtnCheckSearch.Text = "Check Search"
        Me.toolBtnCheckSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.toolBtnCheckSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 56)
        '
        'toolbtnAddCheck
        '
        Me.toolbtnAddCheck.Image = Global.TellerAssistant2012.My.Resources.Resources.NewCardHS
        Me.toolbtnAddCheck.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.toolbtnAddCheck.ImageTransparentColor = System.Drawing.Color.Black
        Me.toolbtnAddCheck.Name = "toolbtnAddCheck"
        Me.toolbtnAddCheck.Size = New System.Drawing.Size(102, 53)
        Me.toolbtnAddCheck.Text = "Add Check"
        Me.toolbtnAddCheck.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.toolbtnAddCheck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'toolbtnEditCheck
        '
        Me.toolbtnEditCheck.Image = Global.TellerAssistant2012.My.Resources.Resources.EditInformationHS
        Me.toolbtnEditCheck.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.toolbtnEditCheck.ImageTransparentColor = System.Drawing.Color.Black
        Me.toolbtnEditCheck.Name = "toolbtnEditCheck"
        Me.toolbtnEditCheck.Size = New System.Drawing.Size(98, 53)
        Me.toolbtnEditCheck.Text = "Edit Check"
        Me.toolbtnEditCheck.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.toolbtnEditCheck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'toolbtnDeleteCheck
        '
        Me.toolbtnDeleteCheck.Image = Global.TellerAssistant2012.My.Resources.Resources.Trash
        Me.toolbtnDeleteCheck.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.toolbtnDeleteCheck.ImageTransparentColor = System.Drawing.Color.Black
        Me.toolbtnDeleteCheck.Name = "toolbtnDeleteCheck"
        Me.toolbtnDeleteCheck.Size = New System.Drawing.Size(118, 53)
        Me.toolbtnDeleteCheck.Text = "Delete Check"
        Me.toolbtnDeleteCheck.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.toolbtnDeleteCheck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 56)
        '
        'toolBtnExit
        '
        Me.toolBtnExit.Image = Global.TellerAssistant2012.My.Resources.Resources.Cancel_Red_24
        Me.toolBtnExit.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.toolBtnExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolBtnExit.Name = "toolBtnExit"
        Me.toolBtnExit.Size = New System.Drawing.Size(43, 53)
        Me.toolBtnExit.Text = "Exit"
        Me.toolBtnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.toolBtnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.toolBtnExit.ToolTipText = "Close program"
        '
        'CheckViewerViewPanel1
        '
        Me.CheckViewerViewPanel1.ApplyonEntryKey = False
        Me.CheckViewerViewPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.CheckViewerViewPanel1.Location = New System.Drawing.Point(3, 3)
        Me.CheckViewerViewPanel1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckViewerViewPanel1.Name = "CheckViewerViewPanel1"
        Me.CheckViewerViewPanel1.NavButtonsVisible = False
        Me.CheckViewerViewPanel1.OkButtonLabel = "&Apply"
        Me.CheckViewerViewPanel1.Size = New System.Drawing.Size(1504, 392)
        Me.CheckViewerViewPanel1.SpliterDistance = 1040
        Me.CheckViewerViewPanel1.TabIndex = 0
        '
        'FormMain2012
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(1554, 1038)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "FormMain2012"
        Me.Text = "Teller's Assistant 2012"
        Me.TransparencyKey = System.Drawing.Color.Gainsboro
        Me.ContextMenuLVChecks.ResumeLayout(False)
        Me.TabControl2.ResumeLayout(False)
        Me.tpEntryQueue.ResumeLayout(False)
        Me.tpEditQueue.ResumeLayout(False)
        Me.tpConfirmQueue.ResumeLayout(False)
        Me.tpAddManualCheck.ResumeLayout(False)
        Me.tpView.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.ContentPanel.PerformLayout()
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.toolStripBankInfo.ResumeLayout(False)
        Me.toolStripBankInfo.PerformLayout()
        Me.toolStripDepositTotal.ResumeLayout(False)
        Me.toolStripDepositTotal.PerformLayout()
        Me.ToolStripStatus1.ResumeLayout(False)
        Me.ToolStripStatus1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.tpSelectDeposit.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.tpViewDeposit.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.pnlCashRegister.ResumeLayout(False)
        Me.pnlCashRegister.PerformLayout()
        Me.GroupBoxCurrency.ResumeLayout(False)
        Me.GroupBoxCurrency.PerformLayout()
        Me.GroupBoxCoins.ResumeLayout(False)
        Me.GroupBoxCoins.PerformLayout()
        Me.pnlDepositInfo.ResumeLayout(False)
        Me.pnlDepositInfo.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStripTop.ResumeLayout(False)
        Me.ToolStripTop.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStripTop As System.Windows.Forms.ToolStrip
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolbtnDeleteCheck As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolbtnPrintTicket As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolbtnAddCheck As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolStripBankInfo As System.Windows.Forms.ToolStrip
    Friend WithEvents toolbtnEditCheck As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripDepositTotal As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolLabel4 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents toolTextDepositTotal As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents toolLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents toolTextBankInfo As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents mnuAddManualCheck As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEditSelectedCheck As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDeleteSelectedCheck As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAddEditBanks As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ToolStripStatus1 As System.Windows.Forms.ToolStrip
    Friend WithEvents toolLabelStatusText As System.Windows.Forms.ToolStripLabel
    Friend WithEvents mnuCommunicationMode As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFTP As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRS232 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuResetScanner As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ContextMenuLVChecks As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ctxmnuLVChecksRefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolBtnPortIcon As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents toolMnuDelayInterval As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolMnuDelayText As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ctxmnuLVChecksView As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxmnuLVChecksEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpSelectDeposit As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tpViewDeposit As System.Windows.Forms.TabPage
    Friend WithEvents lvChecklist As System.Windows.Forms.ListView
    Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
    Friend WithEvents tpEntryQueue As System.Windows.Forms.TabPage
    Friend WithEvents tpEditQueue As System.Windows.Forms.TabPage
    Friend WithEvents tpConfirmQueue As System.Windows.Forms.TabPage
    Friend WithEvents tpAddManualCheck As System.Windows.Forms.TabPage
    Friend WithEvents pnlCashRegister As System.Windows.Forms.Panel
    Friend WithEvents GroupBoxCurrency As System.Windows.Forms.GroupBox
    Friend WithEvents txtOneCt As CalculatorClasses.CalculatorTextbox
    Friend WithEvents txtFiveCt As CalculatorClasses.CalculatorTextbox
    Friend WithEvents txtTenCt As CalculatorClasses.CalculatorTextbox
    Friend WithEvents txtTwentyCt As CalculatorClasses.CalculatorTextbox
    Friend WithEvents txtFiftyCt As CalculatorClasses.CalculatorTextbox
    Friend WithEvents txtHundredCt As CalculatorClasses.CalculatorTextbox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtOne As System.Windows.Forms.TextBox
    Friend WithEvents txtFive As System.Windows.Forms.TextBox
    Friend WithEvents txtTen As System.Windows.Forms.TextBox
    Friend WithEvents txtTwenty As System.Windows.Forms.TextBox
    Friend WithEvents txtFifty As System.Windows.Forms.TextBox
    Friend WithEvents txtHundred As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtCurrencyTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents txtCashTotal As System.Windows.Forms.TextBox
    Friend WithEvents GroupBoxCoins As System.Windows.Forms.GroupBox
    Friend WithEvents txtPennyCt As CalculatorClasses.CalculatorTextbox
    Friend WithEvents txtNickelCt As CalculatorClasses.CalculatorTextbox
    Friend WithEvents txtDimeCt As CalculatorClasses.CalculatorTextbox
    Friend WithEvents txtQuarterCt As CalculatorClasses.CalculatorTextbox
    Friend WithEvents txtHalfDollarCt As CalculatorClasses.CalculatorTextbox
    Friend WithEvents txtDollarCoinCt As CalculatorClasses.CalculatorTextbox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents txtPenny As System.Windows.Forms.TextBox
    Friend WithEvents txtNickel As System.Windows.Forms.TextBox
    Friend WithEvents txtDime As System.Windows.Forms.TextBox
    Friend WithEvents txtQuarter As System.Windows.Forms.TextBox
    Friend WithEvents txtHalfDollar As System.Windows.Forms.TextBox
    Friend WithEvents txtDollarCoin As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCoinTotal As System.Windows.Forms.TextBox
    Friend WithEvents pnlDepositInfo As System.Windows.Forms.Panel
    Friend WithEvents txtChecksCount As System.Windows.Forms.TextBox
    Friend WithEvents lblDepDate As System.Windows.Forms.Label
    Friend WithEvents lblDepDescript As System.Windows.Forms.Label
    Friend WithEvents txtDepositNo As System.Windows.Forms.TextBox
    Friend WithEvents txtChecksTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrintTicket As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrintReport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCheckSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuInitScanner As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrintFormSetup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EventLoggingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewExceptionLog As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLoggingOn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents mnuAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEditAppSettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolBtnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolBtnCheckSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CheckviewerEntryPanel1 As TellerAssistant2012.CheckViewerEditPanel
    Friend WithEvents CheckViewEditPanel1 As TellerAssistant2012.CheckViewerEditPanel
    Friend WithEvents CheckViewerAddPanel1 As TellerAssistant2012.CheckViewerAddPanel
    Friend WithEvents CheckViewerConfirmPanel1 As TellerAssistant2012.CheckViewerConfirmPanel
    Friend WithEvents mnuManageImageFiles As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TextPanelFlyout1 As Flyout_Control.TextPanelFlyout
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pnlTopBarExtension As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents pnlBottomBarExtension As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lvDepositsList As System.Windows.Forms.ListView
    Friend WithEvents colHdrDepositNo As System.Windows.Forms.ColumnHeader
    Friend WithEvents colHdrDepositDate As System.Windows.Forms.ColumnHeader
    Friend WithEvents colHdrDescription As System.Windows.Forms.ColumnHeader
    Friend WithEvents colhdrTotal As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDepDescript As System.Windows.Forms.TextBox
    Friend WithEvents ckbxNewDep As System.Windows.Forms.CheckBox
    Friend WithEvents dateDepositDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lvBankAccounts As System.Windows.Forms.ListView
    Friend WithEvents colHdrAcctId As System.Windows.Forms.ColumnHeader
    Friend WithEvents colHdrAcctType As System.Windows.Forms.ColumnHeader
    Friend WithEvents colHdrBankName As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnGetTicket As System.Windows.Forms.Button
    Friend WithEvents ImagePanelFlyout1 As Flyout_Control.ImagePanelFlyout
    Friend WithEvents mnuPageSetup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ImageListStates As System.Windows.Forms.ImageList
    Friend WithEvents mnuPrintReceipts As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PageSetupDialog1 As System.Windows.Forms.PageSetupDialog
    Friend WithEvents comboDateRange As System.Windows.Forms.ComboBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents tpView As System.Windows.Forms.TabPage
    Friend WithEvents CheckViewerViewPanel1 As TellerAssistant2012.CheckViewerViewPanel
End Class
