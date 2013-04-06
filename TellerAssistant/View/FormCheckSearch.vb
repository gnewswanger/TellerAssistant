''' <summary>
''' <file>FormCheckSearch.vb</file>
''' This class defines the view for displaying the results of a query to the database.
''' </summary>
''' <remarks></remarks>
Public Class FormCheckSearch
    Implements IViewFrmCheckSearch

    Delegate Sub SetCheckListCallback(ByVal value As List(Of ChecksClass))
    Delegate Sub BoolByRefCallback(ByRef value As Boolean)
    Delegate Sub NoArgsCallback()
    Private ctrlr As CheckSearchPresenter


#Region "Class Properties"

    Public WriteOnly Property Checklist() As System.Collections.Generic.List(Of ChecksClass) Implements IViewFrmCheckSearch.Checklist
        Set(ByVal value As System.Collections.Generic.List(Of ChecksClass))
            Me.lvSearchResults.CheckQueue = value
            If Me.lvSearchResults.ItemsCount > 0 Then
                Me.lvSearchResults.ItemsSelectedItem = 0
                Me.CheckSearchPanel1.CurrentCheck = New CheckRegisterEventArgs(EventName.evnmCheckSearchResult, _
                                                                          Me.lvSearchResults.GetCheckAtItem(0), Nothing, _
                                                                          Me.lvSearchResults.CheckQueueCount, _
                                                                          Me.lvSearchResults.QueueIndex)
            End If
            Me.Cursor = Cursors.Default
        End Set
    End Property

    Public WriteOnly Property ActiveDepNo() As String Implements IViewFrmCheckSearch.ActiveDepNo
        Set(ByVal value As String)
            Me.CheckSearchPanel1.ActiveDepNo = value
        End Set
    End Property

    Public WriteOnly Property CheckAdded() As ChecksClass Implements IViewFrmCheckSearch.CheckAdded
        Set(ByVal value As ChecksClass)
            If Me.CheckSearchPanel1.TabControl1.SelectedTab Is Me.CheckSearchPanel1.tpSearchDeposit _
                And Me.CheckSearchPanel1.txtSearchDepNo.Text.Trim = value.DepositNo Then
                lvSearchResults.CheckQueueUpdate = value
            ElseIf Me.CheckSearchPanel1.TabControl1.SelectedTab Is Me.CheckSearchPanel1.tpSearchDate _
            And value.CheckDate >= Me.CheckSearchPanel1.dtpFromDate.Value And value.CheckDate <= Me.CheckSearchPanel1.dtpToDate.Value Then
                lvSearchResults.CheckQueueUpdate = value
            End If
        End Set
    End Property

    Public WriteOnly Property CheckChanged() As ChecksClass Implements IViewFrmCheckSearch.CheckChanged
        Set(ByVal value As ChecksClass)
            If Me.CheckSearchPanel1.TabControl1.SelectedTab Is Me.CheckSearchPanel1.tpSearchDeposit _
                And Me.CheckSearchPanel1.txtSearchDepNo.Text.Trim = value.DepositNo Then
                Me.lvSearchResults.CheckQueueUpdate = value
            ElseIf Me.CheckSearchPanel1.TabControl1.SelectedTab Is Me.CheckSearchPanel1.tpSearchDate _
            And value.CheckDate >= Me.CheckSearchPanel1.dtpFromDate.Value And value.CheckDate <= Me.CheckSearchPanel1.dtpToDate.Value Then
                Me.lvSearchResults.CheckQueueUpdate = value
            End If
        End Set
    End Property

    Public WriteOnly Property CheckDeleted() As ChecksClass Implements IViewFrmCheckSearch.CheckDeleted
        Set(ByVal value As ChecksClass)
            If Me.CheckSearchPanel1.TabControl1.SelectedTab Is Me.CheckSearchPanel1.tpSearchDeposit _
                And Me.CheckSearchPanel1.txtSearchDepNo.Text.Trim = value.DepositNo Then
                Me.lvSearchResults.CheckQueueDelete = value
            ElseIf Me.CheckSearchPanel1.TabControl1.SelectedTab Is Me.CheckSearchPanel1.tpSearchDate _
            And value.CheckDate >= Me.CheckSearchPanel1.dtpFromDate.Value And value.CheckDate <= Me.CheckSearchPanel1.dtpToDate.Value Then
                Me.lvSearchResults.CheckQueueDelete = value
            End If
        End Set
    End Property

#End Region

#Region "Constructor, Initialization, and Activation"

    Public Sub New(ByRef aModel As DepositManagerModel)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ToolTip1.SetToolTip(Me.CheckSearchPanel1.TabControl1, "Enter data for at least 1 field.")
        Me.ctrlr = New CheckSearchPresenter(Me, aModel)

        Me.CheckSearchPanel1.CurrentCheck = New CheckRegisterEventArgs(EventName.evnmCheckSearchResult, New ChecksClass("", "", "", ""), Nothing, -1, -1)
    End Sub

    Private Sub frmCheckSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    End Sub
#End Region

#Region "Menu Events"
    Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
        Me.Close()
    End Sub

    Private Sub toolBtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolBtnExit.Click
        Me.Close()
    End Sub

    Private Sub mnuPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrint.Click
        Dim params As New GRNPrinting.TextLineParams
        params.IsBoxed = False
        params.BoxPen = Pens.DodgerBlue
        params.TextFont = New Font("Times New Roman", 12, FontStyle.Bold)
        params.TextPen = Pens.Black
        params.Alignment = StringAlignment.Center
        params.LineAlignment = StringAlignment.Center

        Dim rpt As New CheckSearchReport
        rpt.AddTitleTextLine("Check Search Results", 0, params, True)

        params.TextFont = New Font("Times New Roman", 10, FontStyle.Bold)
        'rpt.AddTitleTextLine("From " + CStr(Me.CheckSearchPanel1.dtpFromDate.Value) + " to " + CStr(Me.CheckSearchPanel1.dtpToDate.Value), , params, True)

        Dim criteria As String = String.Empty
        If Me.CheckSearchPanel1.SearchMode = CheckSearchPanel.SearchModes.smByDate Then
            rpt.AddTitleTextLine("From " + CStr(Me.CheckSearchPanel1.dtpFromDate.Value) + " to " + CStr(Me.CheckSearchPanel1.dtpToDate.Value), , params, True)
        ElseIf Me.CheckSearchPanel1.SearchMode = CheckSearchPanel.SearchModes.smByDeposit Then
            rpt.AddTitleTextLine("Search Criteria: Deposit Number = " + Me.CheckSearchPanel1.txtSearchDepNo.Text.Trim, , params, True)
            criteria = ""
        ElseIf Me.CheckSearchPanel1.SearchMode = CheckSearchPanel.SearchModes.smByIndividual Then
            rpt.AddTitleTextLine("From " + CStr(Me.CheckSearchPanel1.dtpFromDateIndiv.Value) + " to " + CStr(Me.CheckSearchPanel1.dtpToDateIndiv.Value), , params, True)
            criteria = "Search Criteria: Transit = " + Me.CheckSearchPanel1.txtSearchCheckBank.Text.Trim _
                                  + ";  Check No. = " + Me.CheckSearchPanel1.txtSearchCheckNo.Text.Trim _
                                  + ";  Account = " + Me.CheckSearchPanel1.txtSearchCheckAcct.Text.Trim _
                                  + ";  Check Amount = " + String.Format("C", Me.CheckSearchPanel1.txtSearchCheckAmt.Text) _
                                  + ";  Donor = " + Me.CheckSearchPanel1.txtSearchCheckDonor.Text.Trim
        End If

        If Me.CheckSearchPanel1.SearchMode = CheckSearchPanel.SearchModes.smByDeposit Then
            If Me.CheckSearchPanel1.checkbxFilterReceiptStatus.Checked Then
                If Me.CheckSearchPanel1.radioDepReceiptNotSent.Checked Then
                    criteria += " Filtered by Receipt Requests Not Sent"
                ElseIf Me.CheckSearchPanel1.radioDepReceiptSent.Checked Then
                    criteria += " Filtered by Receipt Requests Sent"
                Else
                    criteria += " Filtered by All Receipt Requests"
                End If
            End If
        ElseIf Me.CheckSearchPanel1.SearchMode = CheckSearchPanel.SearchModes.smByDate Then
            If Me.CheckSearchPanel1.checkbxDateFilterReceiptStatus.Checked Then
                If Me.CheckSearchPanel1.radioRequestsNotSent.Checked Then
                    criteria += " Filtered by Receipt Requests Not Sent"
                ElseIf Me.CheckSearchPanel1.radioRequestsSent.Checked Then
                    criteria += " Filtered by Receipt Requests Sent"
                Else
                    criteria += " Filtered by All Receipt Requests"
                End If
            End If
        End If
        params.TextFont = New Font("Times New Roman", 8, FontStyle.Bold)
        rpt.AddTitleTextLine(criteria, , params, True)

        rpt.PrintCheckList(lvSearchResults.Items)

    End Sub

    Private Sub ExtraLargeIconToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExtraLargeIconToolStripMenuItem.Click
        Me.lvSearchResults.View = CheckImageView.civExtraLargeIcon
    End Sub

    Private Sub mnuViewLargeIcon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewLargeIcon.Click
        Me.lvSearchResults.View = CheckImageView.civLargeIcon
    End Sub

    Private Sub mnuViewList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewList.Click
        Me.lvSearchResults.View = CheckImageView.civList
    End Sub

    Private Sub toolBtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolBtnPrint.Click
        Me.mnuPrint_Click(sender, e)
    End Sub

#End Region

#Region "Button Events"

    Private Sub CheckSearchPanel1_CheckviewApplyClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckSearchPanel1.CheckviewApplyClick
        Me.Cursor = Cursors.WaitCursor
        Me.ctrlr.HandleSearchRequest(Me.CheckSearchPanel1.QueryString)
    End Sub

    Private Sub CheckSearchPanel1_CheckviewFirstNavClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckSearchPanel1.CheckviewFirstNavClick
        Me.lvSearchResults.FirstCheck()
    End Sub

    Private Sub CheckSearchPanel1_CheckviewLastNavClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckSearchPanel1.CheckviewLastNavClick
        Me.lvSearchResults.LastCheck()
    End Sub

    Private Sub CheckSearchPanel1_CheckviewNextNavClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckSearchPanel1.CheckviewNextNavClick
        Me.lvSearchResults.NextCheck()
    End Sub

    Private Sub CheckSearchPanel1_CheckviewPrevNavClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckSearchPanel1.CheckviewPrevNavClick
        Me.lvSearchResults.PreviousCheck()
    End Sub

    Private Sub lvSearchResults_SelectedCheckIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvSearchResults.SelectedCheckIndexChanged
        Me.CheckSearchPanel1.CurrentCheck = CType(e, CheckRegisterEventArgs)
    End Sub

    Private Sub CheckSearchPanel1_CheckviewResetClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckSearchPanel1.CheckviewResetClick
        Me.lvSearchResults.ItemsClear = True
    End Sub
#End Region

   
    Private Sub ToolStripStatusLabel1_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel1.Click

    End Sub
End Class