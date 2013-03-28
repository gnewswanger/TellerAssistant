Imports System.IO
''' <summary>
''' <file>File: CheckSearchPanel.vb</file>
''' <author>Author: Galen Newswanger</author>
''' This user control class provides a check image viewer for searching and viewing contents of 
''' a CheckListView object.
''' </summary>
''' <remarks>
''' </remarks>
Public Class CheckSearchPanel
    Implements IViewChecksPanel

    Delegate Sub SetTextCallback(ByVal text As String)
    Delegate Sub SetImageCallback()
    Delegate Sub TwoIntegerCallback(ByVal val1 As Integer, ByVal val2 As Integer)
    Delegate Sub SetBooleanCallback(ByVal value As Boolean)
    Delegate Sub SetDateCallback(ByVal value As Date)
    Delegate Sub GenericCallback(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Public Event CheckviewNextNavClick As GenericCallback
    Public Event CheckviewPrevNavClick As GenericCallback
    Public Event CheckviewFirstNavClick As GenericCallback
    Public Event CheckviewLastNavClick As GenericCallback
    Public Event CheckviewApplyClick As GenericCallback
    Public Event CheckviewResetClick As GenericCallback

    Private Enum SearchMode
        smByDeposit
        smByDate
        smByIndividual
    End Enum

    Private _currCheck As ChecksClass
    Private _updatedCheck As ChecksClass
    Private _myPages(4) As TabPage
    Private _searchMode As SearchMode

#Region "Class Properties"

    Public WriteOnly Property ActiveDepNo() As String
        Set(ByVal value As String)
            Me.txtSearchDepNo.Text = value
            If value <> String.Empty Then
                Me.TabControl1.SelectedTab = tpSearchDeposit
            End If
        End Set
    End Property

    Public Property CurrentCheck() As CheckRegisterEventArgs Implements IViewChecksPanel.CurrentCheck
        Get
            Return New CheckRegisterEventArgs(EventName.evnmCheckSearchResult, Me._currCheck, Nothing, Nothing)
        End Get
        Set(ByVal value As CheckRegisterEventArgs)
            If value IsNot Nothing Then
                Me.SetCurrentCheck(value)
            End If
        End Set
    End Property

    Public ReadOnly Property QueryString() As String
        Get
            Return Me.GenerateQueryString(Me._searchMode)
        End Get
    End Property

    Public Property StartDate As Date
        Get
            If (Me.TabControl1.SelectedTab Is tpSearchDate) Then
                Return Me.dtpFromDate.Value
            ElseIf (Me.TabControl1.SelectedTab Is tpIndivCriteria) Then
                Return Me.dtpFromDateIndiv.Value
            Else
                Return New Date(Today.Year, 1, 1)
            End If
        End Get
        Set(value As Date)
            If (Me.TabControl1.SelectedTab Is tpSearchDate) Then
                Me.SetSearchStartDate(value)
            ElseIf (Me.TabControl1.SelectedTab Is tpIndivCriteria) Then
                Me.SetSearchStartDateIndiv(value)
            Else
                Me.SetSearchStartDate(value)
                Me.SetSearchStartDateIndiv(value)
            End If
        End Set
    End Property

#End Region

#Region "Set Current Check"

    Private Sub SetCurrentCheck(ByVal value As CheckRegisterEventArgs)
        If value.origCheck Is Nothing Then
            Me._updatedCheck = Nothing
            Me.SetCheckPixImage()
            Me.SetSearchStartDate(Today)
            Me.SetCheckAmtText(CSng(0).ToString("C"))
            Me.SetCheckBankText("")
            Me.SetCheckAcctText("")
            Me.SetCheckNoText("")
            Me.SetCheckDonorText("")
        Else
            Me._currCheck = value.origCheck
            Me._updatedCheck = New ChecksClass(_currCheck)
            Me.SetCheckPixImage()
            Me.SetSearchStartDate(Me._currCheck.CheckDate)
            Me.SetCheckAmtText(Me._currCheck.CheckAmount.ToString("C"))
            Me.SetCheckBankText(Me._currCheck.RoutingNo)
            Me.SetCheckAcctText(Me._currCheck.AccountNo)
            Me.SetCheckNoText(Me._currCheck.CheckNo)
            Me.SetCheckDonorText(Me._currCheck.Donor)
        End If
        Me.SetNavButtonsEnabled(value.QueueCount, value.QueueIndex)
        Me.IsDirty()
    End Sub

    Private Sub SetCheckPixImage()
        If InvokeRequired Then
            Me.Invoke(New SetImageCallback(AddressOf SetCheckPixImage))
        Else
            If Me._currCheck Is Nothing OrElse Me._currCheck.ImageFile Is Nothing OrElse Me._currCheck.ImageFile = "" Then
                Me.ImageViewerPanel1.Image = Nothing
            Else
                Dim fname As String = Me._currCheck.ImageFullPath + Me._currCheck.ImageFile
                Dim img As New CheckImageClass(fname)
                Me.ImageViewerPanel1.Image = img.CheckImage
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

    Private Sub SetSearchStartDateIndiv(ByVal dt As DateTime)
        If Me.dtpToDate.InvokeRequired Then
            Me.BeginInvoke(New SetDateCallback(AddressOf SetSearchStartDate), dt)
        Else
            Me.dtpToDate.Value = dt
        End If
    End Sub

    Private Sub SetSearchStartDate(ByVal dt As DateTime)
        If Me.dtpToDate.InvokeRequired Then
            Me.BeginInvoke(New SetDateCallback(AddressOf SetSearchStartDate), dt)
        Else
            Me.dtpToDate.Value = dt
        End If
    End Sub

    Private Sub SetSearchDepositNoText(text As String)
        If Me.txtSearchDepNo.InvokeRequired Then
            Me.BeginInvoke(New SetTextCallback(AddressOf SetSearchDepositNoText), text)
        Else
            Me.txtSearchDepNo.Text = text
            Me.IsDirty()
        End If
    End Sub

    Private Sub SetCheckAmtText(ByVal text As String)
        If Me.txtCheckAmt.InvokeRequired Then
            Me.BeginInvoke(New SetTextCallback(AddressOf SetCheckAmtText), text)
        Else
            Me.txtCheckAmt.Text = text
        End If
    End Sub

    Private Sub SetCheckBankText(ByVal text As String)
        If Me.txtRoutingNo.InvokeRequired Then
            Me.BeginInvoke(New SetTextCallback(AddressOf SetCheckBankText), text)
        Else
            Me.txtRoutingNo.Text = text
        End If
    End Sub

    Private Sub SetCheckAcctText(ByVal text As String)
        If Me.txtAccountNo.InvokeRequired Then
            Me.BeginInvoke(New SetTextCallback(AddressOf SetCheckAcctText), text)
        Else
            Me.txtAccountNo.Text = text
        End If
    End Sub

    Private Sub SetCheckNoText(ByVal text As String)
        If Me.txtCheckNo.InvokeRequired Then
            Me.BeginInvoke(New SetTextCallback(AddressOf SetCheckNoText), text)
        Else
            Me.txtCheckNo.Text = text
        End If
    End Sub

    Private Sub SetCheckDonorText(ByVal text As String)
        If Me.txtCheckDonor.InvokeRequired Then
            Me.BeginInvoke(New SetTextCallback(AddressOf SetCheckDonorText), text)
        Else
            Me.txtCheckDonor.Text = text
        End If
    End Sub

    Private Sub SettxtCheckAmtFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.txtCheckAmt.InvokeRequired Then
            Me.BeginInvoke(New GenericCallback(AddressOf SettxtCheckAmtFocus), sender, e)
        Else
            Me.txtCheckAmt.Focus()
        End If
    End Sub

    Private Sub SetBtnExecuteSearchText(ByVal Value As String)
        If InvokeRequired Then
            Me.BeginInvoke(New SetTextCallback(AddressOf SetBtnExecuteSearchText), Value)
        Else
            btnExecuteSearch.Text = Value
        End If
    End Sub

#End Region

#Region "Button Click Methods"

    Private Sub btnCheckNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckNext.Click
        RaiseEvent CheckviewNextNavClick(sender, e)
        Me.txtAccountNo.Focus()
    End Sub

    Private Sub btnCheckPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckPrev.Click
        RaiseEvent CheckviewPrevNavClick(sender, e)
        Me.txtAccountNo.Focus()
    End Sub

    Private Sub btnCheckFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckFirst.Click
        RaiseEvent CheckviewFirstNavClick(sender, e)
        Me.txtAccountNo.Focus()
    End Sub

    Private Sub btnCheckLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckLast.Click
        RaiseEvent CheckviewLastNavClick(sender, e)
        Me.txtAccountNo.Focus()
    End Sub

    Private Sub btnExecuteSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExecuteSearch.Click
        Me._currCheck = Me._updatedCheck
        Me.groupSelectCriteria.Enabled = False

        If Me.TabControl1.TabPages.IndexOf(tpCheckInfo) = -1 Then
            Me.TabControl1.TabPages.Add(Me._myPages(Array.IndexOf(Me._myPages, tpCheckInfo)))
        End If
        Me.TabControl1.SelectedTab = tpCheckInfo
        RaiseEvent CheckviewApplyClick(sender, e)
    End Sub

    Private Sub btnCheckReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckReset.Click
        If MsgBox("You are about to reset to original settings. You will loose any changes. Do you want to continue?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Me.CurrentCheck = New CheckRegisterEventArgs(EventName.evnmCheckSearchRequest, Nothing, Nothing, 0, 0)
            RaiseEvent CheckviewResetClick(sender, e)
            Me.ImageViewerPanel1.Image = Nothing
            Me.groupSelectCriteria.Enabled = True
            If (Me.TabControl1.SelectedTab Is tpIndivCriteria) Then
                Me.ResetGroupIndivCriteria()
            ElseIf (Me.TabControl1.SelectedTab Is tpSearchDate) Then
                Me.ResetGroupReceiptByDate()
            End If
            Me.InitializeTabPages2Start()
            Me.IsDirty()
            Me.txtAccountNo.Focus()
        End If
        Me.IsDirty()
        Me.txtAccountNo.Focus()
    End Sub

#End Region

#Region "Button Enabled Methods"

    Private Sub SetCheckNextEnabled(ByVal cnt As Integer, ByVal indx As Integer)
        If Me.btnCheckNext.InvokeRequired Then
            Me.Invoke(New TwoIntegerCallback(AddressOf SetCheckNextEnabled), cnt, indx)
        Else
            Me.btnCheckNext.Enabled = cnt > 0 AndAlso indx < cnt - 1
        End If
    End Sub

    Private Sub SetCheckPrevEnabled(ByVal cnt As Integer, ByVal indx As Integer)
        If Me.btnCheckPrev.InvokeRequired Then
            Me.Invoke(New TwoIntegerCallback(AddressOf SetCheckNextEnabled), cnt, indx)
        Else
            Me.btnCheckPrev.Enabled = cnt > 0 AndAlso indx > 0
        End If
    End Sub

    Private Sub SetCheckFirstEnabled(ByVal cnt As Integer, ByVal indx As Integer)
        If Me.btnCheckFirst.InvokeRequired Then
            Me.Invoke(New TwoIntegerCallback(AddressOf SetCheckNextEnabled), cnt, indx)
        Else
            Me.btnCheckFirst.Enabled = cnt > 1 AndAlso indx > 0
        End If
    End Sub

    Private Sub SetCheckLastEnabled(ByVal cnt As Integer, ByVal indx As Integer)
        If Me.btnCheckLast.InvokeRequired Then
            Me.Invoke(New TwoIntegerCallback(AddressOf SetCheckNextEnabled), cnt, indx)
        Else
            Me.btnCheckLast.Enabled = cnt > 1 AndAlso indx < cnt - 1
        End If
    End Sub

    Private Sub SetNavButtonsEnabled(ByVal cnt As Integer, ByVal indx As Integer)
        Me.SetCheckNextEnabled(cnt, indx)
        Me.SetCheckPrevEnabled(cnt, indx)
        Me.SetCheckFirstEnabled(cnt, indx)
        Me.SetCheckLastEnabled(cnt, indx)
    End Sub

    Private Sub SetSearchTextboxEnabled()
        If InvokeRequired Then
            Me.Invoke(New SetImageCallback(AddressOf SetSearchTextboxEnabled))
        Else
            Me.txtSearchCheckAmt.Enabled = Me.ckbxAmount.Checked
            Me.txtSearchCheckBank.Enabled = Me.ckbxBank.Checked
            Me.txtSearchCheckAcct.Enabled = Me.ckbxCheckAcct.Checked
            Me.txtSearchCheckNo.Enabled = Me.ckbxCheckNo.Checked
            Me.txtSearchCheckDonor.Enabled = Me.ckbxDonor.Checked
        End If
        Me.IsDirty()
    End Sub

    Private Sub SetDepSrchRadiobuttonsEnabled(ByVal value As Boolean)
        If InvokeRequired Then
            Me.Invoke(New SetBooleanCallback(AddressOf SetDepSrchRadiobuttonsEnabled), value)
        Else
            Me.groupReceiptByDeposit.Enabled = value
        End If
    End Sub

    Private Sub SetDateSrchRadiobuttonsEnabled(ByVal value As Boolean)
        If InvokeRequired Then
            Me.Invoke(New SetBooleanCallback(AddressOf SetDateSrchRadiobuttonsEnabled), value)
        Else
            Me.groupReceiptByDate.Enabled = value
        End If
    End Sub

    Private Sub ResetGroupIndivCriteria()
        Me.dtpFromDateIndiv.Value = New Date(Today.Year, 1, 1)
        Me.dtpToDateIndiv.Value = Today
        Me.groupSelectCriteria.Enabled = True
        With Me.groupSelectCriteria
            For Each ctrl As Control In .Controls
                If (TypeOf ctrl Is CheckBox) Then
                    CType(ctrl, CheckBox).Checked = False
                End If
                If (TypeOf ctrl Is TextBox) Then
                    ctrl.Enabled = False
                End If
            Next
        End With
    End Sub

    Private Sub ResetGroupReceiptByDate()
        Me.dtpFromDate.Value = New Date(Today.Year, 1, 1)
        Me.dtpToDate.Value = Today
        Me.checkbxDateFilterReceiptStatus.Checked = False
    End Sub


#End Region

#Region "Textbox Keyup Methods"

    Private Sub txtSearchCheckAmt_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearchCheckAmt.KeyUp
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.groupSelectCriteria.SelectNextControl(txtCheckAmt, True, True, True, True)
        Else
            Me.IsDirty()
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txtSearchCheckBank_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearchCheckBank.KeyUp
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.groupSelectCriteria.SelectNextControl(txtRoutingNo, True, True, True, True)
        Else
            Me.IsDirty()
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txtSearchCheckAcct_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearchCheckAcct.KeyUp
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.groupSelectCriteria.SelectNextControl(txtAccountNo, True, True, True, True)
        Else
            Me.IsDirty()
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txtSearchCheckNo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearchCheckNo.KeyUp
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.groupSelectCriteria.SelectNextControl(txtCheckNo, True, True, True, True)
        Else
            Me.IsDirty()
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txtSearchCheckDonor_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearchCheckDonor.KeyUp
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.groupSelectCriteria.SelectNextControl(txtCheckDonor, True, True, True, True)
        Else
            Me.IsDirty()
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub dtpCheckDate_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.pnlDetailEdit.SelectNextControl(dtpToDate, True, True, True, True)
        Else
            Me.IsDirty()
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txtSearchDepNo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearchDepNo.KeyUp
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            If Me.IsDirty() Then
                Me.btnExecuteSearch.Focus()
            End If
        Else
            Me.IsDirty()
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txtSearchKeyword_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            If Me.IsDirty() Then
                Me.btnExecuteSearch.Focus()
            End If
        Else
            Me.IsDirty()
        End If
        e.SuppressKeyPress = True
    End Sub
#End Region

#Region "Textbox Leave Methods"

    Private Sub txtCheckAmt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCheckAmt.Leave
        If IsDirty() Then
            Me._updatedCheck.CheckAmount = CSng(txtCheckAmt.Text)
        End If
    End Sub

    Private Sub txtCheckBank_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRoutingNo.Leave
        If txtSearchCheckBank.Modified Then
            Me._updatedCheck.RoutingNo = txtRoutingNo.Text
        End If
    End Sub

    Private Sub txtCheckAcct_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAccountNo.Leave
        If txtSearchCheckAcct.Modified Then
            Me._updatedCheck.AccountNo = txtAccountNo.Text
        End If
    End Sub

    Private Sub txtCheckNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCheckNo.Leave
        If txtSearchCheckNo.Modified Then
            Me._updatedCheck.CheckNo = txtCheckNo.Text
        End If
    End Sub

    Private Sub txtCheckDonor_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCheckDonor.Leave
        If txtSearchCheckDonor.Modified Then
            Me._updatedCheck.DonorInfo.Donor = txtCheckDonor.Text
        End If
    End Sub

#End Region

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        'Me.dtpFromDate.Value = New Date(Today.Year, 1, 1)
    End Sub

    Private Sub CheckSearchPanel_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.checkbxFilterReceiptStatus.Checked Then
            Me.SetDepSrchRadiobuttonsEnabled(True)
        Else
            Me.SetDepSrchRadiobuttonsEnabled(False)
        End If
        Me.ResetGroupIndivCriteria()
        Me.ResetGroupReceiptByDate()
        Me.InitializeTabPages2Start()
    End Sub

    Private Sub InitializeTabPages2Start()
        For i As Integer = Me.TabControl1.TabPages.Count - 1 To 0 Step -1
            Me._myPages(i) = Me.TabControl1.TabPages(i)
            If Me.TabControl1.TabPages(i) Is tpCheckInfo Then
                Me.TabControl1.Controls.Remove(Me.TabControl1.TabPages(i))
            End If
        Next
    End Sub

    Private Function GenerateQueryString(mode As SearchMode) As String
        Dim retString As String = String.Empty
        Select Case True
            Case mode = SearchMode.smByIndividual
                retString = " @StartDate = '" + Me.dtpFromDateIndiv.Value.ToShortDateString + "', " _
                 + " @EndDate = '" + Me.dtpToDateIndiv.Value.ToShortDateString + "'"
                If ((Me.ckbxAmount.Checked) AndAlso (CSng(Me.txtSearchCheckAmt.Text.Trim) > 0)) Then
                    If retString <> String.Empty Then
                        retString += ","
                    End If
                    retString += " @CheckAmount = " + Me.txtSearchCheckAmt.Text.Trim
                End If
                If (Me.ckbxCheckNo.Checked) Then
                    If retString <> String.Empty Then
                        retString += ","
                    End If
                    retString += " @CheckNo = '" + Me.txtSearchCheckNo.Text.Trim + "'"
                End If
                If (Me.ckbxCheckAcct.Checked) Then
                    If retString <> String.Empty Then
                        retString += ","
                    End If
                    retString += " @AccountNo = '" + Me.txtSearchCheckAcct.Text.Trim + "'"
                End If
                If (Me.ckbxBank.Checked) Then
                    If retString <> String.Empty Then
                        retString += ","
                    End If
                    retString += " @RoutingNo = '" + Me.txtSearchCheckBank.Text.Trim + "'"
                End If
                If Me.txtSearchCheckDonor.Text <> String.Empty Then
                    If retString <> String.Empty Then
                        retString += ","
                    End If
                    retString += " @DonorNo = '" + Me.txtSearchCheckDonor.Text.Trim + "'"
                End If
            Case mode = SearchMode.smByDeposit
                If Me.txtSearchDepNo.Text <> String.Empty Then
                    retString = " @DepositNo = '" + Me.txtSearchDepNo.Text.Trim + "'"
                    If Me.checkbxFilterReceiptStatus.Checked Then
                        retString += ", @ReceiptStatus = " & Me.SelectedReceiptRequestStatus(tpSearchDeposit)
                    End If
                End If
            Case mode = SearchMode.smByDate
                retString = " @StartDate = '" + Me.dtpFromDate.Value.ToShortDateString + "', " _
                 + " @EndDate = '" + Me.dtpToDate.Value.ToShortDateString + "'"
                If Me.checkbxDateFilterReceiptStatus.Checked Then
                    retString += ", @ReceiptStatus = " & Me.SelectedReceiptRequestStatus(tpSearchDate)
                End If
        End Select

        Return retString
    End Function

    Private Function SelectedReceiptRequestStatus(ByVal tp As TabPage) As ReceiptRequestStatus
        If tp Is tpSearchDeposit Then
            If Me.radioDepReceiptRequests.Checked Then
                Return ReceiptRequestStatus.rrsAllRequests
            ElseIf Me.radioDepReceiptNotSent.Checked Then
                Return ReceiptRequestStatus.rrsRequestedNotSent
            ElseIf Me.radioDepReceiptSent.Checked Then
                Return ReceiptRequestStatus.rrsRequestedSent
            End If
        ElseIf tp Is tpSearchDate Then
            If Me.radioReceiptRequests.Checked Then
                Return ReceiptRequestStatus.rrsAllRequests
            ElseIf Me.radioRequestsNotSent.Checked Then
                Return ReceiptRequestStatus.rrsRequestedNotSent
            ElseIf Me.radioRequestsSent.Checked Then
                Return ReceiptRequestStatus.rrsRequestedSent
            End If
        End If
        Return Nothing
    End Function

    Private Sub checkbxFilterReceiptStatus_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles checkbxFilterReceiptStatus.CheckStateChanged
        If Me.checkbxFilterReceiptStatus.CheckState = CheckState.Checked Then
            Me.SetDepSrchRadiobuttonsEnabled(True)
        Else
            Me.SetDepSrchRadiobuttonsEnabled(False)
        End If
        Me.IsDirty()
    End Sub

    Private Sub checkbxDateFilterReceiptStatus_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles checkbxDateFilterReceiptStatus.CheckStateChanged
        If Me.checkbxDateFilterReceiptStatus.CheckState = CheckState.Checked Then
            Me.SetDateSrchRadiobuttonsEnabled(True)
        Else
            Me.SetDateSrchRadiobuttonsEnabled(False)
        End If
        Me.IsDirty()
    End Sub

    Private Sub checkbox_Click(sender As Object, e As EventArgs) Handles ckbxAmount.Click, ckbxBank.Click, ckbxCheckAcct.Click, ckbxCheckNo.Click, ckbxDonor.Click
        Me.SetSearchTextboxEnabled()
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If Me.TabControl1.SelectedTab Is tpSearchDeposit Then
            Me._searchMode = SearchMode.smByDeposit
        ElseIf Me.TabControl1.SelectedTab Is tpSearchDate Then
            Me._searchMode = SearchMode.smByDate
        ElseIf Me.TabControl1.SelectedTab Is tpIndivCriteria Then
            Me._searchMode = SearchMode.smByIndividual
        End If
        Me.IsDirty()
    End Sub

    Private Function IsDirty() As Boolean
        Dim dirty As Boolean = False
        If Me.TabControl1.SelectedTab Is tpSearchDeposit Then
            If Me.txtSearchDepNo.Text <> String.Empty Then
                dirty = True
            Else
                dirty = False
            End If
        ElseIf Me.TabControl1.SelectedTab Is tpSearchDate Then
            If Me.dtpFromDate.Value <> Today Then
                dirty = True
            Else
                dirty = False
            End If
        ElseIf Me.TabControl1.SelectedTab Is tpIndivCriteria Then
            If Me.ckbxCheckNo.Checked AndAlso Me.txtSearchCheckNo.Text <> String.Empty Then
                dirty = True
            ElseIf Me.ckbxCheckAcct.Checked AndAlso Me.txtSearchCheckAcct.Text <> String.Empty Then
                dirty = True
            ElseIf Me.ckbxBank.Checked AndAlso Me.txtSearchCheckBank.Text <> String.Empty Then
                dirty = True
            ElseIf Me.ckbxAmount.Checked AndAlso Me.txtSearchCheckAmt.Text <> String.Empty Then
                dirty = True
            ElseIf Me.ckbxDonor.Checked AndAlso Me.txtSearchCheckDonor.Text <> String.Empty Then
                dirty = True
            Else
                dirty = False
            End If
        End If
        Me.btnExecuteSearch.Enabled = dirty
        Return dirty
    End Function

End Class
