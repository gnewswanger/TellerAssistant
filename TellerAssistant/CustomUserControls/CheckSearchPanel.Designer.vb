<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CheckSearchPanel
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.pnlDetailEdit = New System.Windows.Forms.Panel()
        Me.dtpFromDateIndiv = New System.Windows.Forms.DateTimePicker()
        Me.dtpToDateIndiv = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.groupSelectCriteria = New System.Windows.Forms.GroupBox()
        Me.ckbxCheckAcct = New System.Windows.Forms.CheckBox()
        Me.ckbxDonor = New System.Windows.Forms.CheckBox()
        Me.txtSearchCheckBank = New System.Windows.Forms.TextBox()
        Me.ckbxAmount = New System.Windows.Forms.CheckBox()
        Me.txtSearchCheckAcct = New System.Windows.Forms.TextBox()
        Me.ckbxCheckNo = New System.Windows.Forms.CheckBox()
        Me.txtSearchCheckNo = New System.Windows.Forms.TextBox()
        Me.ckbxBank = New System.Windows.Forms.CheckBox()
        Me.txtSearchCheckAmt = New CalculatorClasses.CalculatorTextbox()
        Me.txtSearchCheckDonor = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCheckLast = New System.Windows.Forms.Button()
        Me.btnCheckFirst = New System.Windows.Forms.Button()
        Me.btnCheckNext = New System.Windows.Forms.Button()
        Me.btnCheckPrev = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpSearchDeposit = New System.Windows.Forms.TabPage()
        Me.pnlDepositCriteria = New System.Windows.Forms.Panel()
        Me.comboCheckStatusByDeposit = New System.Windows.Forms.ComboBox()
        Me.checkbxDepFilterCheckStatus = New System.Windows.Forms.CheckBox()
        Me.comboReceiptByDeposit = New System.Windows.Forms.ComboBox()
        Me.checkbxDepFilterReceiptStatus = New System.Windows.Forms.CheckBox()
        Me.radioDepNoSearch = New System.Windows.Forms.RadioButton()
        Me.txtSearchDepNo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tpSearchDate = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.comboStatusByDate = New System.Windows.Forms.ComboBox()
        Me.checkbxDateFilterCheckStatus = New System.Windows.Forms.CheckBox()
        Me.comboReceiptByDate = New System.Windows.Forms.ComboBox()
        Me.checkbxDateFilterReceiptStatus = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpFromDate = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker()
        Me.tpIndivCriteria = New System.Windows.Forms.TabPage()
        Me.tpCheckInfo = New System.Windows.Forms.TabPage()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtRoutingNo = New System.Windows.Forms.TextBox()
        Me.txtAccountNo = New System.Windows.Forms.TextBox()
        Me.txtCheckNo = New System.Windows.Forms.TextBox()
        Me.txtCheckAmt = New CalculatorClasses.CalculatorTextbox()
        Me.txtCheckDonor = New System.Windows.Forms.TextBox()
        Me.pnlNavButtons = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnCheckReset = New System.Windows.Forms.Button()
        Me.btnExecuteSearch = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ImageViewerPanel1 = New ImageViewerPanel.ImageViewerPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlDetailEdit.SuspendLayout()
        Me.groupSelectCriteria.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tpSearchDeposit.SuspendLayout()
        Me.pnlDepositCriteria.SuspendLayout()
        Me.tpSearchDate.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.tpIndivCriteria.SuspendLayout()
        Me.tpCheckInfo.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlNavButtons.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlDetailEdit
        '
        Me.pnlDetailEdit.Controls.Add(Me.dtpFromDateIndiv)
        Me.pnlDetailEdit.Controls.Add(Me.dtpToDateIndiv)
        Me.pnlDetailEdit.Controls.Add(Me.Label3)
        Me.pnlDetailEdit.Controls.Add(Me.groupSelectCriteria)
        Me.pnlDetailEdit.Controls.Add(Me.Label1)
        Me.pnlDetailEdit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDetailEdit.Location = New System.Drawing.Point(3, 3)
        Me.pnlDetailEdit.Name = "pnlDetailEdit"
        Me.pnlDetailEdit.Size = New System.Drawing.Size(241, 157)
        Me.pnlDetailEdit.TabIndex = 16
        '
        'dtpFromDateIndiv
        '
        Me.dtpFromDateIndiv.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFromDateIndiv.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFromDateIndiv.Location = New System.Drawing.Point(38, 5)
        Me.dtpFromDateIndiv.Name = "dtpFromDateIndiv"
        Me.dtpFromDateIndiv.Size = New System.Drawing.Size(82, 20)
        Me.dtpFromDateIndiv.TabIndex = 45
        '
        'dtpToDateIndiv
        '
        Me.dtpToDateIndiv.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpToDateIndiv.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpToDateIndiv.Location = New System.Drawing.Point(146, 5)
        Me.dtpToDateIndiv.Name = "dtpToDateIndiv"
        Me.dtpToDateIndiv.Size = New System.Drawing.Size(82, 20)
        Me.dtpToDateIndiv.TabIndex = 43
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "From:"
        '
        'groupSelectCriteria
        '
        Me.groupSelectCriteria.Controls.Add(Me.ckbxCheckAcct)
        Me.groupSelectCriteria.Controls.Add(Me.ckbxDonor)
        Me.groupSelectCriteria.Controls.Add(Me.txtSearchCheckBank)
        Me.groupSelectCriteria.Controls.Add(Me.ckbxAmount)
        Me.groupSelectCriteria.Controls.Add(Me.txtSearchCheckAcct)
        Me.groupSelectCriteria.Controls.Add(Me.ckbxCheckNo)
        Me.groupSelectCriteria.Controls.Add(Me.txtSearchCheckNo)
        Me.groupSelectCriteria.Controls.Add(Me.ckbxBank)
        Me.groupSelectCriteria.Controls.Add(Me.txtSearchCheckAmt)
        Me.groupSelectCriteria.Controls.Add(Me.txtSearchCheckDonor)
        Me.groupSelectCriteria.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.groupSelectCriteria.Location = New System.Drawing.Point(0, 27)
        Me.groupSelectCriteria.Name = "groupSelectCriteria"
        Me.groupSelectCriteria.Size = New System.Drawing.Size(241, 130)
        Me.groupSelectCriteria.TabIndex = 40
        Me.groupSelectCriteria.TabStop = False
        Me.groupSelectCriteria.Text = "Select search criteria:"
        '
        'ckbxCheckAcct
        '
        Me.ckbxCheckAcct.AutoSize = True
        Me.ckbxCheckAcct.Location = New System.Drawing.Point(17, 42)
        Me.ckbxCheckAcct.Name = "ckbxCheckAcct"
        Me.ckbxCheckAcct.Size = New System.Drawing.Size(86, 17)
        Me.ckbxCheckAcct.TabIndex = 35
        Me.ckbxCheckAcct.Text = "Account No:"
        Me.ckbxCheckAcct.UseVisualStyleBackColor = True
        '
        'ckbxDonor
        '
        Me.ckbxDonor.AutoSize = True
        Me.ckbxDonor.Location = New System.Drawing.Point(17, 107)
        Me.ckbxDonor.Name = "ckbxDonor"
        Me.ckbxDonor.Size = New System.Drawing.Size(58, 17)
        Me.ckbxDonor.TabIndex = 39
        Me.ckbxDonor.Text = "Donor:"
        Me.ckbxDonor.UseVisualStyleBackColor = True
        '
        'txtSearchCheckBank
        '
        Me.txtSearchCheckBank.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearchCheckBank.Location = New System.Drawing.Point(106, 57)
        Me.txtSearchCheckBank.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSearchCheckBank.Name = "txtSearchCheckBank"
        Me.txtSearchCheckBank.Size = New System.Drawing.Size(121, 20)
        Me.txtSearchCheckBank.TabIndex = 3
        '
        'ckbxAmount
        '
        Me.ckbxAmount.AutoSize = True
        Me.ckbxAmount.Location = New System.Drawing.Point(17, 85)
        Me.ckbxAmount.Name = "ckbxAmount"
        Me.ckbxAmount.Size = New System.Drawing.Size(81, 17)
        Me.ckbxAmount.TabIndex = 38
        Me.ckbxAmount.Text = "Check Amt:"
        Me.ckbxAmount.UseVisualStyleBackColor = True
        '
        'txtSearchCheckAcct
        '
        Me.txtSearchCheckAcct.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearchCheckAcct.Location = New System.Drawing.Point(106, 35)
        Me.txtSearchCheckAcct.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSearchCheckAcct.Name = "txtSearchCheckAcct"
        Me.txtSearchCheckAcct.Size = New System.Drawing.Size(121, 20)
        Me.txtSearchCheckAcct.TabIndex = 4
        '
        'ckbxCheckNo
        '
        Me.ckbxCheckNo.AutoSize = True
        Me.ckbxCheckNo.Location = New System.Drawing.Point(17, 19)
        Me.ckbxCheckNo.Name = "ckbxCheckNo"
        Me.ckbxCheckNo.Size = New System.Drawing.Size(77, 17)
        Me.ckbxCheckNo.TabIndex = 37
        Me.ckbxCheckNo.Text = "Check No:"
        Me.ckbxCheckNo.UseVisualStyleBackColor = True
        '
        'txtSearchCheckNo
        '
        Me.txtSearchCheckNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearchCheckNo.Location = New System.Drawing.Point(106, 13)
        Me.txtSearchCheckNo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSearchCheckNo.Name = "txtSearchCheckNo"
        Me.txtSearchCheckNo.Size = New System.Drawing.Size(121, 20)
        Me.txtSearchCheckNo.TabIndex = 5
        '
        'ckbxBank
        '
        Me.ckbxBank.AutoSize = True
        Me.ckbxBank.Location = New System.Drawing.Point(17, 63)
        Me.ckbxBank.Name = "ckbxBank"
        Me.ckbxBank.Size = New System.Drawing.Size(83, 17)
        Me.ckbxBank.TabIndex = 36
        Me.ckbxBank.Text = "Routing No:"
        Me.ckbxBank.UseVisualStyleBackColor = True
        '
        'txtSearchCheckAmt
        '
        Me.txtSearchCheckAmt.AdvanceOnEnterKey = False
        Me.txtSearchCheckAmt.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearchCheckAmt.DecimalPlaces = 0
        Me.txtSearchCheckAmt.FormatString = "$#,###,##0.00;($#,###,##0.00)"
        Me.txtSearchCheckAmt.Location = New System.Drawing.Point(106, 79)
        Me.txtSearchCheckAmt.Name = "txtSearchCheckAmt"
        Me.txtSearchCheckAmt.Size = New System.Drawing.Size(121, 20)
        Me.txtSearchCheckAmt.TabIndex = 1
        Me.txtSearchCheckAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSearchCheckDonor
        '
        Me.txtSearchCheckDonor.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearchCheckDonor.Location = New System.Drawing.Point(107, 101)
        Me.txtSearchCheckDonor.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSearchCheckDonor.Name = "txtSearchCheckDonor"
        Me.txtSearchCheckDonor.Size = New System.Drawing.Size(121, 20)
        Me.txtSearchCheckDonor.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(125, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 13)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "To:"
        '
        'btnCheckLast
        '
        Me.btnCheckLast.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCheckLast.AutoEllipsis = True
        Me.btnCheckLast.DialogResult = System.Windows.Forms.DialogResult.Yes
        Me.btnCheckLast.Enabled = False
        Me.btnCheckLast.Image = Global.TellerAssistant2012.My.Resources.Resources.DataContainer_MoveLastHS
        Me.btnCheckLast.Location = New System.Drawing.Point(25, 157)
        Me.btnCheckLast.Name = "btnCheckLast"
        Me.btnCheckLast.Size = New System.Drawing.Size(22, 37)
        Me.btnCheckLast.TabIndex = 36
        Me.btnCheckLast.TabStop = False
        Me.btnCheckLast.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCheckLast.UseVisualStyleBackColor = True
        '
        'btnCheckFirst
        '
        Me.btnCheckFirst.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCheckFirst.AutoEllipsis = True
        Me.btnCheckFirst.Enabled = False
        Me.btnCheckFirst.Image = Global.TellerAssistant2012.My.Resources.Resources.DataContainer_MoveFirstHS
        Me.btnCheckFirst.Location = New System.Drawing.Point(3, 157)
        Me.btnCheckFirst.Name = "btnCheckFirst"
        Me.btnCheckFirst.Size = New System.Drawing.Size(22, 37)
        Me.btnCheckFirst.TabIndex = 35
        Me.btnCheckFirst.TabStop = False
        Me.btnCheckFirst.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnCheckFirst.UseVisualStyleBackColor = True
        '
        'btnCheckNext
        '
        Me.btnCheckNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCheckNext.Enabled = False
        Me.btnCheckNext.Image = Global.TellerAssistant2012.My.Resources.Resources.DataContainer_MoveNextHS
        Me.btnCheckNext.Location = New System.Drawing.Point(3, 79)
        Me.btnCheckNext.Name = "btnCheckNext"
        Me.btnCheckNext.Size = New System.Drawing.Size(44, 37)
        Me.btnCheckNext.TabIndex = 32
        Me.btnCheckNext.TabStop = False
        Me.btnCheckNext.Text = "Next"
        Me.btnCheckNext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnCheckNext.UseVisualStyleBackColor = True
        '
        'btnCheckPrev
        '
        Me.btnCheckPrev.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCheckPrev.Enabled = False
        Me.btnCheckPrev.Image = Global.TellerAssistant2012.My.Resources.Resources.DataContainer_MovePreviousHS
        Me.btnCheckPrev.Location = New System.Drawing.Point(3, 119)
        Me.btnCheckPrev.Name = "btnCheckPrev"
        Me.btnCheckPrev.Size = New System.Drawing.Size(44, 37)
        Me.btnCheckPrev.TabIndex = 31
        Me.btnCheckPrev.TabStop = False
        Me.btnCheckPrev.Text = "Prev"
        Me.btnCheckPrev.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnCheckPrev.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tpSearchDeposit)
        Me.TabControl1.Controls.Add(Me.tpSearchDate)
        Me.TabControl1.Controls.Add(Me.tpIndivCriteria)
        Me.TabControl1.Controls.Add(Me.tpCheckInfo)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(59, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(255, 189)
        Me.TabControl1.TabIndex = 18
        '
        'tpSearchDeposit
        '
        Me.tpSearchDeposit.BackColor = System.Drawing.Color.Transparent
        Me.tpSearchDeposit.Controls.Add(Me.pnlDepositCriteria)
        Me.tpSearchDeposit.Location = New System.Drawing.Point(4, 22)
        Me.tpSearchDeposit.Name = "tpSearchDeposit"
        Me.tpSearchDeposit.Padding = New System.Windows.Forms.Padding(3)
        Me.tpSearchDeposit.Size = New System.Drawing.Size(247, 163)
        Me.tpSearchDeposit.TabIndex = 1
        Me.tpSearchDeposit.Text = "by Deposit"
        '
        'pnlDepositCriteria
        '
        Me.pnlDepositCriteria.BackColor = System.Drawing.Color.White
        Me.pnlDepositCriteria.Controls.Add(Me.comboCheckStatusByDeposit)
        Me.pnlDepositCriteria.Controls.Add(Me.checkbxDepFilterCheckStatus)
        Me.pnlDepositCriteria.Controls.Add(Me.comboReceiptByDeposit)
        Me.pnlDepositCriteria.Controls.Add(Me.checkbxDepFilterReceiptStatus)
        Me.pnlDepositCriteria.Controls.Add(Me.radioDepNoSearch)
        Me.pnlDepositCriteria.Controls.Add(Me.txtSearchDepNo)
        Me.pnlDepositCriteria.Controls.Add(Me.Label2)
        Me.pnlDepositCriteria.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDepositCriteria.Location = New System.Drawing.Point(3, 3)
        Me.pnlDepositCriteria.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlDepositCriteria.MinimumSize = New System.Drawing.Size(200, 175)
        Me.pnlDepositCriteria.Name = "pnlDepositCriteria"
        Me.pnlDepositCriteria.Size = New System.Drawing.Size(241, 175)
        Me.pnlDepositCriteria.TabIndex = 0
        '
        'comboCheckStatusByDeposit
        '
        Me.comboCheckStatusByDeposit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboCheckStatusByDeposit.FormattingEnabled = True
        Me.comboCheckStatusByDeposit.Items.AddRange(New Object() {"Amount Pending", "Edit Pending", "Confirm Pending", "Verified"})
        Me.comboCheckStatusByDeposit.Location = New System.Drawing.Point(63, 112)
        Me.comboCheckStatusByDeposit.Name = "comboCheckStatusByDeposit"
        Me.comboCheckStatusByDeposit.Size = New System.Drawing.Size(121, 21)
        Me.comboCheckStatusByDeposit.TabIndex = 7
        '
        'checkbxDepFilterCheckStatus
        '
        Me.checkbxDepFilterCheckStatus.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.checkbxDepFilterCheckStatus.AutoSize = True
        Me.checkbxDepFilterCheckStatus.Location = New System.Drawing.Point(43, 96)
        Me.checkbxDepFilterCheckStatus.Name = "checkbxDepFilterCheckStatus"
        Me.checkbxDepFilterCheckStatus.Size = New System.Drawing.Size(129, 17)
        Me.checkbxDepFilterCheckStatus.TabIndex = 6
        Me.checkbxDepFilterCheckStatus.Text = "Filter by Check Status"
        Me.checkbxDepFilterCheckStatus.UseVisualStyleBackColor = True
        '
        'comboReceiptByDeposit
        '
        Me.comboReceiptByDeposit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboReceiptByDeposit.FormattingEnabled = True
        Me.comboReceiptByDeposit.Items.AddRange(New Object() {"Receipt Requests", "Requests Not Sent", "Requests Sent"})
        Me.comboReceiptByDeposit.Location = New System.Drawing.Point(63, 65)
        Me.comboReceiptByDeposit.Name = "comboReceiptByDeposit"
        Me.comboReceiptByDeposit.Size = New System.Drawing.Size(121, 21)
        Me.comboReceiptByDeposit.TabIndex = 5
        '
        'checkbxDepFilterReceiptStatus
        '
        Me.checkbxDepFilterReceiptStatus.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.checkbxDepFilterReceiptStatus.AutoSize = True
        Me.checkbxDepFilterReceiptStatus.Location = New System.Drawing.Point(43, 49)
        Me.checkbxDepFilterReceiptStatus.Name = "checkbxDepFilterReceiptStatus"
        Me.checkbxDepFilterReceiptStatus.Size = New System.Drawing.Size(135, 17)
        Me.checkbxDepFilterReceiptStatus.TabIndex = 3
        Me.checkbxDepFilterReceiptStatus.Text = "Filter by Receipt Status"
        Me.checkbxDepFilterReceiptStatus.UseVisualStyleBackColor = True
        '
        'radioDepNoSearch
        '
        Me.radioDepNoSearch.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.radioDepNoSearch.AutoSize = True
        Me.radioDepNoSearch.Checked = True
        Me.radioDepNoSearch.Location = New System.Drawing.Point(15, 4)
        Me.radioDepNoSearch.Name = "radioDepNoSearch"
        Me.radioDepNoSearch.Size = New System.Drawing.Size(132, 17)
        Me.radioDepNoSearch.TabIndex = 2
        Me.radioDepNoSearch.TabStop = True
        Me.radioDepNoSearch.Text = "Search by Deposit No."
        Me.radioDepNoSearch.UseVisualStyleBackColor = True
        '
        'txtSearchDepNo
        '
        Me.txtSearchDepNo.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.txtSearchDepNo.Location = New System.Drawing.Point(142, 23)
        Me.txtSearchDepNo.Name = "txtSearchDepNo"
        Me.txtSearchDepNo.Size = New System.Drawing.Size(92, 20)
        Me.txtSearchDepNo.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Enter Deposit Number:"
        '
        'tpSearchDate
        '
        Me.tpSearchDate.Controls.Add(Me.Panel2)
        Me.tpSearchDate.Location = New System.Drawing.Point(4, 22)
        Me.tpSearchDate.Name = "tpSearchDate"
        Me.tpSearchDate.Padding = New System.Windows.Forms.Padding(3)
        Me.tpSearchDate.Size = New System.Drawing.Size(247, 163)
        Me.tpSearchDate.TabIndex = 2
        Me.tpSearchDate.Text = "by Date"
        Me.tpSearchDate.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.comboStatusByDate)
        Me.Panel2.Controls.Add(Me.checkbxDateFilterCheckStatus)
        Me.Panel2.Controls.Add(Me.comboReceiptByDate)
        Me.Panel2.Controls.Add(Me.checkbxDateFilterReceiptStatus)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.dtpFromDate)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.dtpToDate)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(241, 157)
        Me.Panel2.TabIndex = 0
        '
        'comboStatusByDate
        '
        Me.comboStatusByDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboStatusByDate.FormattingEnabled = True
        Me.comboStatusByDate.Items.AddRange(New Object() {"Amount Pending", "Edit Pending", "Confirm Pending", "Verified"})
        Me.comboStatusByDate.Location = New System.Drawing.Point(60, 113)
        Me.comboStatusByDate.Name = "comboStatusByDate"
        Me.comboStatusByDate.Size = New System.Drawing.Size(121, 21)
        Me.comboStatusByDate.TabIndex = 47
        '
        'checkbxDateFilterCheckStatus
        '
        Me.checkbxDateFilterCheckStatus.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.checkbxDateFilterCheckStatus.AutoSize = True
        Me.checkbxDateFilterCheckStatus.Location = New System.Drawing.Point(40, 97)
        Me.checkbxDateFilterCheckStatus.Name = "checkbxDateFilterCheckStatus"
        Me.checkbxDateFilterCheckStatus.Size = New System.Drawing.Size(129, 17)
        Me.checkbxDateFilterCheckStatus.TabIndex = 46
        Me.checkbxDateFilterCheckStatus.Text = "Filter by Check Status"
        Me.checkbxDateFilterCheckStatus.UseVisualStyleBackColor = True
        '
        'comboReceiptByDate
        '
        Me.comboReceiptByDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboReceiptByDate.FormattingEnabled = True
        Me.comboReceiptByDate.Items.AddRange(New Object() {"Receipt Requests", "Requests Not Sent", "Requests Sent"})
        Me.comboReceiptByDate.Location = New System.Drawing.Point(60, 66)
        Me.comboReceiptByDate.Name = "comboReceiptByDate"
        Me.comboReceiptByDate.Size = New System.Drawing.Size(121, 21)
        Me.comboReceiptByDate.TabIndex = 45
        '
        'checkbxDateFilterReceiptStatus
        '
        Me.checkbxDateFilterReceiptStatus.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.checkbxDateFilterReceiptStatus.Location = New System.Drawing.Point(40, 50)
        Me.checkbxDateFilterReceiptStatus.Name = "checkbxDateFilterReceiptStatus"
        Me.checkbxDateFilterReceiptStatus.Size = New System.Drawing.Size(135, 16)
        Me.checkbxDateFilterReceiptStatus.TabIndex = 43
        Me.checkbxDateFilterReceiptStatus.Text = "Filter by Receipt Status"
        Me.checkbxDateFilterReceiptStatus.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(103, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 42
        Me.Label4.Text = "To Date:"
        '
        'dtpFromDate
        '
        Me.dtpFromDate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFromDate.Location = New System.Drawing.Point(18, 21)
        Me.dtpFromDate.Name = "dtpFromDate"
        Me.dtpFromDate.Size = New System.Drawing.Size(82, 20)
        Me.dtpFromDate.TabIndex = 41
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "From Date:"
        '
        'dtpToDate
        '
        Me.dtpToDate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpToDate.Location = New System.Drawing.Point(106, 21)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(82, 20)
        Me.dtpToDate.TabIndex = 39
        '
        'tpIndivCriteria
        '
        Me.tpIndivCriteria.Controls.Add(Me.pnlDetailEdit)
        Me.tpIndivCriteria.Location = New System.Drawing.Point(4, 22)
        Me.tpIndivCriteria.Name = "tpIndivCriteria"
        Me.tpIndivCriteria.Padding = New System.Windows.Forms.Padding(3)
        Me.tpIndivCriteria.Size = New System.Drawing.Size(247, 163)
        Me.tpIndivCriteria.TabIndex = 0
        Me.tpIndivCriteria.Text = "by Individual"
        Me.tpIndivCriteria.UseVisualStyleBackColor = True
        '
        'tpCheckInfo
        '
        Me.tpCheckInfo.Controls.Add(Me.Panel3)
        Me.tpCheckInfo.Location = New System.Drawing.Point(4, 22)
        Me.tpCheckInfo.Name = "tpCheckInfo"
        Me.tpCheckInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCheckInfo.Size = New System.Drawing.Size(247, 163)
        Me.tpCheckInfo.TabIndex = 3
        Me.tpCheckInfo.Text = "Check Info"
        Me.tpCheckInfo.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.GroupBox1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(241, 157)
        Me.Panel3.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtRoutingNo)
        Me.GroupBox1.Controls.Add(Me.txtAccountNo)
        Me.GroupBox1.Controls.Add(Me.txtCheckNo)
        Me.GroupBox1.Controls.Add(Me.txtCheckAmt)
        Me.GroupBox1.Controls.Add(Me.txtCheckDonor)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(0, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(241, 145)
        Me.GroupBox1.TabIndex = 41
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Current Check Information"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(52, 114)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(39, 13)
        Me.Label10.TabIndex = 44
        Me.Label10.Text = "Donor:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(29, 92)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 13)
        Me.Label9.TabIndex = 43
        Me.Label9.Text = "Check Amt:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(27, 70)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 13)
        Me.Label8.TabIndex = 42
        Me.Label8.Text = "Routing No:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(24, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 13)
        Me.Label7.TabIndex = 41
        Me.Label7.Text = "Account No:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(33, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 13)
        Me.Label6.TabIndex = 40
        Me.Label6.Text = "Check No:"
        '
        'txtRoutingNo
        '
        Me.txtRoutingNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRoutingNo.Location = New System.Drawing.Point(99, 67)
        Me.txtRoutingNo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtRoutingNo.Name = "txtRoutingNo"
        Me.txtRoutingNo.Size = New System.Drawing.Size(121, 20)
        Me.txtRoutingNo.TabIndex = 3
        '
        'txtAccountNo
        '
        Me.txtAccountNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAccountNo.Location = New System.Drawing.Point(99, 45)
        Me.txtAccountNo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtAccountNo.Name = "txtAccountNo"
        Me.txtAccountNo.Size = New System.Drawing.Size(121, 20)
        Me.txtAccountNo.TabIndex = 4
        '
        'txtCheckNo
        '
        Me.txtCheckNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCheckNo.Location = New System.Drawing.Point(99, 23)
        Me.txtCheckNo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCheckNo.Name = "txtCheckNo"
        Me.txtCheckNo.Size = New System.Drawing.Size(121, 20)
        Me.txtCheckNo.TabIndex = 5
        '
        'txtCheckAmt
        '
        Me.txtCheckAmt.AdvanceOnEnterKey = False
        Me.txtCheckAmt.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCheckAmt.DecimalPlaces = 0
        Me.txtCheckAmt.FormatString = "$#,###,##0.00;($#,###,##0.00)"
        Me.txtCheckAmt.Location = New System.Drawing.Point(99, 89)
        Me.txtCheckAmt.Name = "txtCheckAmt"
        Me.txtCheckAmt.Size = New System.Drawing.Size(121, 20)
        Me.txtCheckAmt.TabIndex = 1
        Me.txtCheckAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCheckDonor
        '
        Me.txtCheckDonor.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCheckDonor.Location = New System.Drawing.Point(100, 111)
        Me.txtCheckDonor.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCheckDonor.Name = "txtCheckDonor"
        Me.txtCheckDonor.Size = New System.Drawing.Size(121, 20)
        Me.txtCheckDonor.TabIndex = 6
        '
        'pnlNavButtons
        '
        Me.pnlNavButtons.Controls.Add(Me.btnCheckNext)
        Me.pnlNavButtons.Controls.Add(Me.btnCheckPrev)
        Me.pnlNavButtons.Controls.Add(Me.btnCheckLast)
        Me.pnlNavButtons.Controls.Add(Me.btnCheckFirst)
        Me.pnlNavButtons.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlNavButtons.Location = New System.Drawing.Point(3, 3)
        Me.pnlNavButtons.Name = "pnlNavButtons"
        Me.TableLayoutPanel1.SetRowSpan(Me.pnlNavButtons, 2)
        Me.pnlNavButtons.Size = New System.Drawing.Size(50, 219)
        Me.pnlNavButtons.TabIndex = 19
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnCheckReset)
        Me.Panel1.Controls.Add(Me.btnExecuteSearch)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(59, 198)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(255, 24)
        Me.Panel1.TabIndex = 20
        '
        'btnCheckReset
        '
        Me.btnCheckReset.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCheckReset.Image = Global.TellerAssistant2012.My.Resources.Resources.RestartHS
        Me.btnCheckReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCheckReset.Location = New System.Drawing.Point(138, 0)
        Me.btnCheckReset.Name = "btnCheckReset"
        Me.btnCheckReset.Size = New System.Drawing.Size(75, 23)
        Me.btnCheckReset.TabIndex = 10
        Me.btnCheckReset.Text = "&Reset"
        Me.btnCheckReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCheckReset.UseVisualStyleBackColor = True
        '
        'btnExecuteSearch
        '
        Me.btnExecuteSearch.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnExecuteSearch.Enabled = False
        Me.btnExecuteSearch.Image = Global.TellerAssistant2012.My.Resources.Resources.Folder_Doc_Search_16
        Me.btnExecuteSearch.Location = New System.Drawing.Point(57, 0)
        Me.btnExecuteSearch.Name = "btnExecuteSearch"
        Me.btnExecuteSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnExecuteSearch.TabIndex = 9
        Me.btnExecuteSearch.Text = "&Search"
        Me.btnExecuteSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnExecuteSearch.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ImageViewerPanel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(784, 225)
        Me.SplitContainer1.SplitterDistance = 469
        Me.SplitContainer1.TabIndex = 22
        '
        'ImageViewerPanel1
        '
        Me.ImageViewerPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImageViewerPanel1.Image = Nothing
        Me.ImageViewerPanel1.Location = New System.Drawing.Point(0, 0)
        Me.ImageViewerPanel1.Name = "ImageViewerPanel1"
        Me.ImageViewerPanel1.Size = New System.Drawing.Size(469, 225)
        Me.ImageViewerPanel1.TabIndex = 17
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 56.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.TabControl1, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.pnlNavButtons, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 1, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(311, 225)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'CheckSearchPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "CheckSearchPanel"
        Me.Size = New System.Drawing.Size(784, 225)
        Me.pnlDetailEdit.ResumeLayout(False)
        Me.pnlDetailEdit.PerformLayout()
        Me.groupSelectCriteria.ResumeLayout(False)
        Me.groupSelectCriteria.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tpSearchDeposit.ResumeLayout(False)
        Me.pnlDepositCriteria.ResumeLayout(False)
        Me.pnlDepositCriteria.PerformLayout()
        Me.tpSearchDate.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.tpIndivCriteria.ResumeLayout(False)
        Me.tpCheckInfo.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlNavButtons.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlDetailEdit As System.Windows.Forms.Panel
    Friend WithEvents btnCheckLast As System.Windows.Forms.Button
    Friend WithEvents btnCheckFirst As System.Windows.Forms.Button
    Friend WithEvents txtSearchCheckDonor As System.Windows.Forms.TextBox
    Friend WithEvents txtSearchCheckAmt As CalculatorClasses.CalculatorTextbox
    Friend WithEvents btnCheckNext As System.Windows.Forms.Button
    Friend WithEvents btnCheckPrev As System.Windows.Forms.Button
    Friend WithEvents txtSearchCheckNo As System.Windows.Forms.TextBox
    Friend WithEvents txtSearchCheckAcct As System.Windows.Forms.TextBox
    Friend WithEvents txtSearchCheckBank As System.Windows.Forms.TextBox
    Friend WithEvents ImageViewerPanel1 As ImageViewerPanel.ImageViewerPanel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpIndivCriteria As System.Windows.Forms.TabPage
    Friend WithEvents tpSearchDeposit As System.Windows.Forms.TabPage
    Friend WithEvents pnlNavButtons As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnCheckReset As System.Windows.Forms.Button
    Friend WithEvents btnExecuteSearch As System.Windows.Forms.Button
    Friend WithEvents pnlDepositCriteria As System.Windows.Forms.Panel
    Friend WithEvents radioDepNoSearch As System.Windows.Forms.RadioButton
    Friend WithEvents txtSearchDepNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tpSearchDate As System.Windows.Forms.TabPage
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents checkbxDepFilterReceiptStatus As System.Windows.Forms.CheckBox
    Friend WithEvents checkbxDateFilterReceiptStatus As System.Windows.Forms.CheckBox
    Friend WithEvents groupSelectCriteria As System.Windows.Forms.GroupBox
    Friend WithEvents ckbxCheckAcct As System.Windows.Forms.CheckBox
    Friend WithEvents ckbxDonor As System.Windows.Forms.CheckBox
    Friend WithEvents ckbxAmount As System.Windows.Forms.CheckBox
    Friend WithEvents ckbxCheckNo As System.Windows.Forms.CheckBox
    Friend WithEvents ckbxBank As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFromDateIndiv As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpToDateIndiv As System.Windows.Forms.DateTimePicker
    Friend WithEvents tpCheckInfo As System.Windows.Forms.TabPage
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtRoutingNo As System.Windows.Forms.TextBox
    Friend WithEvents txtAccountNo As System.Windows.Forms.TextBox
    Friend WithEvents txtCheckNo As System.Windows.Forms.TextBox
    Friend WithEvents txtCheckAmt As CalculatorClasses.CalculatorTextbox
    Friend WithEvents txtCheckDonor As System.Windows.Forms.TextBox
    Friend WithEvents comboReceiptByDeposit As System.Windows.Forms.ComboBox
    Friend WithEvents comboCheckStatusByDeposit As System.Windows.Forms.ComboBox
    Friend WithEvents checkbxDepFilterCheckStatus As System.Windows.Forms.CheckBox
    Friend WithEvents comboStatusByDate As System.Windows.Forms.ComboBox
    Friend WithEvents checkbxDateFilterCheckStatus As System.Windows.Forms.CheckBox
    Friend WithEvents comboReceiptByDate As System.Windows.Forms.ComboBox

End Class
