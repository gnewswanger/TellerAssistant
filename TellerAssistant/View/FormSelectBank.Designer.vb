<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSelectBank
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
        Dim ListViewGroup2 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSelectBank))
        Me.pnlSelectList = New System.Windows.Forms.Panel
        Me.lvBankAccounts = New System.Windows.Forms.ListView
        Me.colHdrBankName = New System.Windows.Forms.ColumnHeader
        Me.colHdrBankCity = New System.Windows.Forms.ColumnHeader
        Me.colHdrBankState = New System.Windows.Forms.ColumnHeader
        Me.colHdrAcctId = New System.Windows.Forms.ColumnHeader
        Me.colHdrAcctType = New System.Windows.Forms.ColumnHeader
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnAddAccount = New System.Windows.Forms.ToolStripButton
        Me.btnEditSelection = New System.Windows.Forms.ToolStripButton
        Me.btnDeleteSelection = New System.Windows.Forms.ToolStripButton
        Me.btnApply = New System.Windows.Forms.ToolStripButton
        Me.btnCancel = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnClose = New System.Windows.Forms.ToolStripButton
        Me.pnlAddEdit = New System.Windows.Forms.Panel
        Me.cmboEditAcctType = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtEditAcctName = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtEditAcctId = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtEditBankZip = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtEditBankState = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtEditBankCity = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtEditBankAddress = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtEditBankName = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtEditBankId = New System.Windows.Forms.TextBox
        Me.pnlSelectList.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.pnlAddEdit.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlSelectList
        '
        Me.pnlSelectList.Controls.Add(Me.lvBankAccounts)
        Me.pnlSelectList.Location = New System.Drawing.Point(0, 242)
        Me.pnlSelectList.Name = "pnlSelectList"
        Me.pnlSelectList.Size = New System.Drawing.Size(621, 208)
        Me.pnlSelectList.TabIndex = 3
        '
        'lvBankAccounts
        '
        Me.lvBankAccounts.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colHdrBankName, Me.colHdrBankCity, Me.colHdrBankState, Me.colHdrAcctId, Me.colHdrAcctType})
        Me.lvBankAccounts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvBankAccounts.FullRowSelect = True
        ListViewGroup2.Header = "ListViewGroup"
        ListViewGroup2.Name = "ListViewGroup1"
        Me.lvBankAccounts.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup2})
        Me.lvBankAccounts.Location = New System.Drawing.Point(0, 0)
        Me.lvBankAccounts.MultiSelect = False
        Me.lvBankAccounts.Name = "lvBankAccounts"
        Me.lvBankAccounts.Size = New System.Drawing.Size(621, 208)
        Me.lvBankAccounts.TabIndex = 5
        Me.lvBankAccounts.TileSize = New System.Drawing.Size(200, 200)
        Me.lvBankAccounts.UseCompatibleStateImageBehavior = False
        Me.lvBankAccounts.View = System.Windows.Forms.View.Details
        '
        'colHdrBankName
        '
        Me.colHdrBankName.Text = "Bank Name"
        Me.colHdrBankName.Width = 200
        '
        'colHdrBankCity
        '
        Me.colHdrBankCity.Text = "City"
        Me.colHdrBankCity.Width = 125
        '
        'colHdrBankState
        '
        Me.colHdrBankState.Text = "State"
        '
        'colHdrAcctId
        '
        Me.colHdrAcctId.Text = "Account Id"
        Me.colHdrAcctId.Width = 80
        '
        'colHdrAcctType
        '
        Me.colHdrAcctType.Text = "Account Type"
        Me.colHdrAcctType.Width = 150
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAddAccount, Me.btnEditSelection, Me.btnDeleteSelection, Me.btnApply, Me.btnCancel, Me.ToolStripSeparator1, Me.btnClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(620, 25)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnAddAccount
        '
        Me.btnAddAccount.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnAddAccount.Image = CType(resources.GetObject("btnAddAccount.Image"), System.Drawing.Image)
        Me.btnAddAccount.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAddAccount.Name = "btnAddAccount"
        Me.btnAddAccount.Size = New System.Drawing.Size(81, 22)
        Me.btnAddAccount.Text = "Add Account"
        '
        'btnEditSelection
        '
        Me.btnEditSelection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnEditSelection.Image = CType(resources.GetObject("btnEditSelection.Image"), System.Drawing.Image)
        Me.btnEditSelection.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEditSelection.Name = "btnEditSelection"
        Me.btnEditSelection.Size = New System.Drawing.Size(82, 22)
        Me.btnEditSelection.Text = "Edit Selection"
        '
        'btnDeleteSelection
        '
        Me.btnDeleteSelection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnDeleteSelection.Image = CType(resources.GetObject("btnDeleteSelection.Image"), System.Drawing.Image)
        Me.btnDeleteSelection.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDeleteSelection.Name = "btnDeleteSelection"
        Me.btnDeleteSelection.Size = New System.Drawing.Size(95, 22)
        Me.btnDeleteSelection.Text = "Delete Selection"
        '
        'btnApply
        '
        Me.btnApply.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnApply.Image = CType(resources.GetObject("btnApply.Image"), System.Drawing.Image)
        Me.btnApply.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(42, 22)
        Me.btnApply.Text = "Apply"
        '
        'btnCancel
        '
        Me.btnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(47, 22)
        Me.btnCancel.Text = "Cancel"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnClose
        '
        Me.btnClose.Image = Global.TellerAssistant2012.My.Resources.Resources.Cancel_Red_24
        Me.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(56, 22)
        Me.btnClose.Text = "Close"
        Me.btnClose.ToolTipText = "Close"
        '
        'pnlAddEdit
        '
        Me.pnlAddEdit.Controls.Add(Me.cmboEditAcctType)
        Me.pnlAddEdit.Controls.Add(Me.Label11)
        Me.pnlAddEdit.Controls.Add(Me.Label10)
        Me.pnlAddEdit.Controls.Add(Me.txtEditAcctName)
        Me.pnlAddEdit.Controls.Add(Me.Label9)
        Me.pnlAddEdit.Controls.Add(Me.txtEditAcctId)
        Me.pnlAddEdit.Controls.Add(Me.Label8)
        Me.pnlAddEdit.Controls.Add(Me.txtEditBankZip)
        Me.pnlAddEdit.Controls.Add(Me.Label7)
        Me.pnlAddEdit.Controls.Add(Me.txtEditBankState)
        Me.pnlAddEdit.Controls.Add(Me.Label6)
        Me.pnlAddEdit.Controls.Add(Me.txtEditBankCity)
        Me.pnlAddEdit.Controls.Add(Me.Label5)
        Me.pnlAddEdit.Controls.Add(Me.txtEditBankAddress)
        Me.pnlAddEdit.Controls.Add(Me.Label3)
        Me.pnlAddEdit.Controls.Add(Me.txtEditBankName)
        Me.pnlAddEdit.Controls.Add(Me.Label2)
        Me.pnlAddEdit.Controls.Add(Me.txtEditBankId)
        Me.pnlAddEdit.Location = New System.Drawing.Point(0, 28)
        Me.pnlAddEdit.Name = "pnlAddEdit"
        Me.pnlAddEdit.Size = New System.Drawing.Size(621, 208)
        Me.pnlAddEdit.TabIndex = 5
        Me.pnlAddEdit.Visible = False
        '
        'cmboEditAcctType
        '
        Me.cmboEditAcctType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmboEditAcctType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmboEditAcctType.FormattingEnabled = True
        Me.cmboEditAcctType.Items.AddRange(New Object() {"Checking", "Savings"})
        Me.cmboEditAcctType.Location = New System.Drawing.Point(432, 79)
        Me.cmboEditAcctType.Name = "cmboEditAcctType"
        Me.cmboEditAcctType.Size = New System.Drawing.Size(175, 21)
        Me.cmboEditAcctType.TabIndex = 20
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(350, 82)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(77, 13)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "Account Type:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(350, 56)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(81, 13)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Account Name:"
        '
        'txtEditAcctName
        '
        Me.txtEditAcctName.Location = New System.Drawing.Point(432, 53)
        Me.txtEditAcctName.Name = "txtEditAcctName"
        Me.txtEditAcctName.Size = New System.Drawing.Size(175, 20)
        Me.txtEditAcctName.TabIndex = 16
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(350, 29)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 13)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Account No.:"
        '
        'txtEditAcctId
        '
        Me.txtEditAcctId.Location = New System.Drawing.Point(432, 26)
        Me.txtEditAcctId.Name = "txtEditAcctId"
        Me.txtEditAcctId.Size = New System.Drawing.Size(175, 20)
        Me.txtEditAcctId.TabIndex = 14
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(38, 161)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 13)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Bank Zip:"
        '
        'txtEditBankZip
        '
        Me.txtEditBankZip.Location = New System.Drawing.Point(131, 158)
        Me.txtEditBankZip.Name = "txtEditBankZip"
        Me.txtEditBankZip.Size = New System.Drawing.Size(205, 20)
        Me.txtEditBankZip.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(38, 135)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Bank State:"
        '
        'txtEditBankState
        '
        Me.txtEditBankState.Location = New System.Drawing.Point(131, 132)
        Me.txtEditBankState.Name = "txtEditBankState"
        Me.txtEditBankState.Size = New System.Drawing.Size(205, 20)
        Me.txtEditBankState.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(38, 109)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Bank City:"
        '
        'txtEditBankCity
        '
        Me.txtEditBankCity.Location = New System.Drawing.Point(131, 106)
        Me.txtEditBankCity.Name = "txtEditBankCity"
        Me.txtEditBankCity.Size = New System.Drawing.Size(205, 20)
        Me.txtEditBankCity.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(38, 83)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Bank Address:"
        '
        'txtEditBankAddress
        '
        Me.txtEditBankAddress.Location = New System.Drawing.Point(131, 80)
        Me.txtEditBankAddress.Name = "txtEditBankAddress"
        Me.txtEditBankAddress.Size = New System.Drawing.Size(205, 20)
        Me.txtEditBankAddress.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(38, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Bank Name:"
        '
        'txtEditBankName
        '
        Me.txtEditBankName.Location = New System.Drawing.Point(131, 53)
        Me.txtEditBankName.Name = "txtEditBankName"
        Me.txtEditBankName.Size = New System.Drawing.Size(205, 20)
        Me.txtEditBankName.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(38, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Bank Routing No.:"
        '
        'txtEditBankId
        '
        Me.txtEditBankId.Location = New System.Drawing.Point(131, 26)
        Me.txtEditBankId.Name = "txtEditBankId"
        Me.txtEditBankId.Size = New System.Drawing.Size(205, 20)
        Me.txtEditBankId.TabIndex = 0
        '
        'frmSelectBank
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(620, 237)
        Me.Controls.Add(Me.pnlAddEdit)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.pnlSelectList)
        Me.Name = "frmSelectBank"
        Me.Text = "Bank Accounts"
        Me.pnlSelectList.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.pnlAddEdit.ResumeLayout(False)
        Me.pnlAddEdit.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlSelectList As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnAddAccount As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEditSelection As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnApply As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents pnlAddEdit As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtEditAcctName As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtEditAcctId As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtEditBankZip As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtEditBankState As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtEditBankCity As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtEditBankAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtEditBankName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtEditBankId As System.Windows.Forms.TextBox
    Friend WithEvents cmboEditAcctType As System.Windows.Forms.ComboBox
    Friend WithEvents lvBankAccounts As System.Windows.Forms.ListView
    Friend WithEvents colHdrBankName As System.Windows.Forms.ColumnHeader
    Friend WithEvents colHdrBankCity As System.Windows.Forms.ColumnHeader
    Friend WithEvents colHdrBankState As System.Windows.Forms.ColumnHeader
    Friend WithEvents colHdrAcctId As System.Windows.Forms.ColumnHeader
    Friend WithEvents colHdrAcctType As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnDeleteSelection As System.Windows.Forms.ToolStripButton
End Class
