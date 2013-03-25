Imports System.Drawing
Imports System.IO

Public Class CheckListView

    Delegate Sub ListofChecksclassCallback(ByVal value As List(Of ChecksClass))
    Delegate Sub ChecksclassCallback(ByVal chk As ChecksClass)
    Delegate Sub ChecksclassIntegerCallback(ByVal chk As ChecksClass, ByVal indx As Integer)
    Delegate Sub GenericCallback(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Public Event SelectedCheckIndexChanged As GenericCallback

    Private _queueIndex As Integer
    Private _thumbnailImagesLg As ImageList
    Private _thumbnailImagesSm As ImageList
    Private _thumbnailImagesEx As ImageList

#Region "Class Properties"

    Public Function NextCheck() As Boolean
        If (lvCheckSearchQueue.Items.Count - 1) > QueueIndex Then
            _queueIndex += 1
            Me.lvCheckSearchQueue.Items(_queueIndex).Selected = True
            If Me.lvCheckSearchQueue.Items.Count - 1 > QueueIndex Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function PreviousCheck() As Boolean
        If Me.lvCheckSearchQueue.Items.Count - 1 > QueueIndex - 1 AndAlso QueueIndex > 0 Then
            QueueIndex -= 1
            Me.lvCheckSearchQueue.Items(QueueIndex).Selected = True
            If QueueIndex > 0 Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function FirstCheck() As Boolean
        If Me.lvCheckSearchQueue.Items.Count >= 0 Then
            QueueIndex = 0
            Me.lvCheckSearchQueue.Items(QueueIndex).Selected = True
            Return True
        Else
            Return False
        End If
    End Function

    Public Function LastCheck() As Boolean
        If Me.lvCheckSearchQueue.Items.Count >= 0 Then
            QueueIndex = Me.lvCheckSearchQueue.Items.Count - 1
            Me.lvCheckSearchQueue.Items(QueueIndex).Selected = True
            Return True
        Else
            Return False
        End If
    End Function

    Public Property QueueIndex() As Integer
        Get
            If Me.lvCheckSearchQueue.IsHandleCreated Then
                If Me.lvCheckSearchQueue.SelectedIndices.Count > 0 Then
                    _queueIndex = Me.lvCheckSearchQueue.SelectedIndices(0)
                Else
                    _queueIndex = -1
                End If
            End If
            Return _queueIndex
        End Get
        Set(ByVal value As Integer)
            If Me.IsHandleCreated Then
                If Me.lvCheckSearchQueue.Items.Count - 1 >= value Then
                    _queueIndex = value
                    Me.lvCheckSearchQueue.Items(_queueIndex).Selected = True
                End If
            End If
        End Set
    End Property

    Public ReadOnly Property Items() As ListView.ListViewItemCollection
        Get
            Return Me.lvCheckSearchQueue.Items
        End Get
    End Property

    Public WriteOnly Property ItemsClear() As Boolean
        Set(ByVal value As Boolean)
            If value Then
                Me.lvCheckSearchQueue.Clear()
            End If
        End Set
    End Property
    Public ReadOnly Property ItemsCount() As Integer
        Get
            Return Me.lvCheckSearchQueue.Items.Count
        End Get
    End Property
    Public Property ItemsSelectedItem() As Integer
        Get
            Return Me.lvCheckSearchQueue.SelectedIndices(0)
        End Get
        Set(ByVal value As Integer)
            Me.lvCheckSearchQueue.Items(value).Selected = True
        End Set
    End Property
    Public WriteOnly Property CheckQueue() As List(Of ChecksClass)
        Set(ByVal value As List(Of ChecksClass))
            SetCheckListlvCheckList(value)
            If Me.lvCheckSearchQueue.Items.Count > 0 Then
                QueueIndex = 0
                Me.lvCheckSearchQueue.Items(QueueIndex).Selected = True
            End If
        End Set
    End Property

    Public ReadOnly Property CheckQueueCount() As Integer
        Get
            Return Me.lvCheckSearchQueue.Items.Count
        End Get
    End Property

    Public WriteOnly Property CheckQueueUpdate() As ChecksClass
        Set(ByVal value As ChecksClass)
            Me.AddCheckToList(value)
            Me.lvCheckSearchQueue.Sort()
        End Set
    End Property

    Public WriteOnly Property CheckQueueDelete() As ChecksClass
        Set(ByVal value As ChecksClass)
            Me.DeleteCheckFromList(value)
            Me.lvCheckSearchQueue.Sort()
        End Set
    End Property

    Public WriteOnly Property View() As TellerAssistant2012.CheckImageView
        Set(ByVal value As TellerAssistant2012.CheckImageView)
            SetViewMode(value)
        End Set
    End Property

#End Region


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me._thumbnailImagesLg = New ImageList
        Me._thumbnailImagesLg.ImageSize = New Size(135, 65)
        Me._thumbnailImagesSm = New ImageList
        Me._thumbnailImagesSm.ImageSize = New Size(50, 25)
        Me._thumbnailImagesEx = New ImageList
        Me._thumbnailImagesEx.ImageSize = New Size(256, 120)
    End Sub

    Private Sub SetCheckListlvCheckList(ByVal value As List(Of ChecksClass))
        If Me.lvCheckSearchQueue.InvokeRequired Then
            Me.lvCheckSearchQueue.BeginInvoke(New ListofChecksclassCallback(AddressOf SetCheckListlvCheckList), value)
        Else
            Me.lvCheckSearchQueue.Items.Clear()
            Me.lvCheckSearchQueue.SuspendLayout()
            Dim index As Integer = 0
            For Each chk As ChecksClass In value
                AddCheckToList(chk)
                index += 1
            Next
            If Me.lvCheckSearchQueue.Columns.Count > 0 Then
                Me.lvCheckSearchQueue.Columns(0).TextAlign = HorizontalAlignment.Right
            End If
            Me.lvCheckSearchQueue.LargeImageList = Me._thumbnailImagesLg
            Me.lvCheckSearchQueue.SmallImageList = Me._thumbnailImagesSm
            Me.lvCheckSearchQueue.ResumeLayout()
        End If
    End Sub

#Region "Public Methods"

    Public Function ThumbnailCallback() As Boolean
        Return False
    End Function

    Public Function GetCheckAtItem(ByVal num As Integer) As ChecksClass
        Return CType(Me.lvCheckSearchQueue.Items(num).Tag, ChecksClass)
    End Function

#End Region

    Private Sub AddCheckToList(ByVal chk As ChecksClass)
        Try
            If Me.lvCheckSearchQueue.InvokeRequired Then
                Me.BeginInvoke(New ChecksclassCallback(AddressOf AddCheckToList), chk)
            Else
                Dim imgFile As String = chk.ImageFullPath + chk.ImageFile
                Dim chkImage As New CheckImageClass(imgFile)
                Dim depText As String = String.Empty
                If (chk.ImageFullPath.LastIndexOf("\") > 0) Then
                    depText = chk.ImageFullPath.Substring(chk.ImageFullPath.LastIndexOf("\") - 6, 6)
                Else
                    depText = chk.DepositNo
                End If
                Dim itm As ListViewItem
                Dim indx As Integer = Me.lvCheckSearchQueue.Items.IndexOfKey(chk.CheckName)
                If indx > -1 Then
                    itm = Me.lvCheckSearchQueue.Items.Item(indx)

                    Me._thumbnailImagesEx.Images.Item(indx) = Me.ResizeImage(chkImage.CheckImage, Me._thumbnailImagesEx.ImageSize, Color.Black)
                    Me._thumbnailImagesEx.Images.SetKeyName(indx, chk.CheckName)

                    Me._thumbnailImagesLg.Images.Item(indx) = Me.ResizeImage(chkImage.CheckImage, Me._thumbnailImagesLg.ImageSize, Color.Black)
                    'CreateThumbnailImage(Me._thumbnailImagesLg.ImageSize, chkImage.CheckImage))
                    Me._thumbnailImagesLg.Images.SetKeyName(indx, chk.CheckName)

                    Me._thumbnailImagesSm.Images.Item(indx) = Me.ResizeImage(chkImage.CheckImage, Me._thumbnailImagesSm.ImageSize, Color.Black)
                    'CreateThumbnailImage(Me._thumbnailImagesSm.ImageSize, chkImage.CheckImage))
                    Me._thumbnailImagesSm.Images.SetKeyName(indx, chk.CheckName)
                Else
                    itm = New ListViewItem
                    Me.lvCheckSearchQueue.Items.Add(itm)
                    Me._thumbnailImagesEx.Images.Add(chk.CheckName, Me.ResizeImage(chkImage.CheckImage, Me._thumbnailImagesEx.ImageSize, Color.Black))
                    'Me._thumbnailImagesLg.Images.Add(chk.CheckName, CreateThumbnailImage(Me._thumbnailImagesLg.ImageSize, chkImage.CheckImage))
                    Me._thumbnailImagesLg.Images.Add(chk.CheckName, Me.ResizeImage(chkImage.CheckImage, Me._thumbnailImagesLg.ImageSize, Color.Black))
                    'Me._thumbnailImagesSm.Images.Add(chk.CheckName, CreateThumbnailImage(Me._thumbnailImagesSm.ImageSize, chkImage.CheckImage))
                    Me._thumbnailImagesSm.Images.Add(chk.CheckName, Me.ResizeImage(chkImage.CheckImage, Me._thumbnailImagesSm.ImageSize, Color.Black))
                End If
                itm.Text = depText + "   " + chk.Text
                itm.Name = chk.CheckName
                itm.SubItems.Add(chk.CheckAmount.ToString("C"))
                itm.Tag = chk
                itm.ImageIndex = Me._thumbnailImagesSm.Images.IndexOfKey(itm.Name)
                itm.ToolTipText = itm.Text & "; " & chk.CheckAmount.ToString("C") & "; " & chk.Donor
                If chk.ManualCheck Then
                    itm.BackColor = Color.Beige
                End If
                End If
        Catch ex As Exception
            MsgBox("AddCheckToList failed in CheckListView. " & ex.Message)
        End Try
    End Sub

    Private Sub DeleteCheckFromList(ByVal chk As ChecksClass)
        Try
            If Me.lvCheckSearchQueue.InvokeRequired Then
                Me.BeginInvoke(New ChecksclassCallback(AddressOf DeleteCheckFromList), chk)
            Else
                Me.lvCheckSearchQueue.Items.RemoveByKey(chk.CheckName)
                Me._thumbnailImagesSm.Images.RemoveByKey(chk.CheckName)
                Me._thumbnailImagesLg.Images.RemoveByKey(chk.CheckName)
                Me._thumbnailImagesEx.Images.RemoveByKey(chk.CheckName)
            End If
        Catch ex As Exception
            MsgBox("DeleteCheckFromList failed in CheckListView. " & ex.Message)
        End Try
    End Sub

    Private Sub lvCheckSearchQueue_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lvCheckSearchQueue.ItemSelectionChanged
        If QueueIndex >= 0 AndAlso Me.lvCheckSearchQueue.Items(QueueIndex).Selected Then
            RaiseEvent SelectedCheckIndexChanged(Me, New CheckRegisterEventArgs(EventName.evnmCheckSearchResult, CType(lvCheckSearchQueue.Items(QueueIndex).Tag, ChecksClass), Nothing, CheckQueueCount, QueueIndex))
        End If
    End Sub

    Private Sub SetViewMode(ByVal mode As TellerAssistant2012.CheckImageView)
        Select Case mode
            Case TellerAssistant2012.CheckImageView.civDetails
                Me.lvCheckSearchQueue.Columns.Add("Deposit# / Check#", 150, HorizontalAlignment.Right)
                Me.lvCheckSearchQueue.Columns.Add("Check Amount", 60, HorizontalAlignment.Right)
                Me.lvCheckSearchQueue.ShowGroups = False
                Me.lvCheckSearchQueue.SmallImageList = Me._thumbnailImagesSm
                Me.lvCheckSearchQueue.View = Windows.Forms.View.Details
            Case TellerAssistant2012.CheckImageView.civExtraLargeIcon
                Me.lvCheckSearchQueue.ShowGroups = False
                Me.lvCheckSearchQueue.LargeImageList = Me._thumbnailImagesEx
                Me.lvCheckSearchQueue.View = Windows.Forms.View.LargeIcon
            Case TellerAssistant2012.CheckImageView.civLargeIcon
                Me.lvCheckSearchQueue.ShowGroups = False
                Me.lvCheckSearchQueue.LargeImageList = Me._thumbnailImagesLg
                Me.lvCheckSearchQueue.View = Windows.Forms.View.LargeIcon
            Case TellerAssistant2012.CheckImageView.civSmallIcon
                Me.lvCheckSearchQueue.ShowGroups = False
                Me.lvCheckSearchQueue.SmallImageList = Me._thumbnailImagesSm
                Me.lvCheckSearchQueue.View = Windows.Forms.View.SmallIcon
            Case TellerAssistant2012.CheckImageView.civList
                Me.lvCheckSearchQueue.ShowGroups = False
                Me.lvCheckSearchQueue.SmallImageList = Me._thumbnailImagesSm
                Me.lvCheckSearchQueue.View = Windows.Forms.View.List
        End Select
        Me.lvCheckSearchQueue.Update()

    End Sub

    'Private Sub SetViewMode(ByVal mode As Windows.Forms.View)
    '    Select Case mode
    '        Case Windows.Forms.View.Details
    '            Me.lvCheckSearchQueue.Columns.Add("Deposit# / Check#", 150, HorizontalAlignment.Right)
    '            Me.lvCheckSearchQueue.Columns.Add("Check Amount", 60, HorizontalAlignment.Right)
    '            Me.lvCheckSearchQueue.ShowGroups = False
    '            Me.lvCheckSearchQueue.SmallImageList = Me._thumbnailImagesSm
    '        Case Windows.Forms.View.LargeIcon
    '            Me.lvCheckSearchQueue.ShowGroups = False
    '            Me.lvCheckSearchQueue.LargeImageList = Me._thumbnailImagesLg
    '        Case Windows.Forms.View.SmallIcon
    '            Me.lvCheckSearchQueue.ShowGroups = False
    '            Me.lvCheckSearchQueue.SmallImageList = Me._thumbnailImagesSm
    '        Case Windows.Forms.View.List
    '            Me.lvCheckSearchQueue.ShowGroups = False
    '            Me.lvCheckSearchQueue.SmallImageList = Me._thumbnailImagesSm
    '    End Select
    '    Me.lvCheckSearchQueue.View = mode
    '    Me.lvCheckSearchQueue.Update()

    'End Sub

    Private Function CreateThumbnailImage(ByVal thumbSize As Size, ByVal img As Image) As Image
        Dim templateBitmap As Bitmap = New Bitmap(img)
        Dim smallImage As Image
        smallImage = templateBitmap.GetThumbnailImage(thumbSize.Width, thumbSize.Height, New Image.GetThumbnailImageAbort(AddressOf ThumbnailCallback), System.IntPtr.Zero)
        Return smallImage
    End Function

    Private Function ResizeImage(ByVal Original As Image, ByVal MaxSize As Size, ByVal BorderColor As Color) As Image
        Dim width, height As Integer
        If Original.Height > Original.Width Then
            height = MaxSize.Height
            width = CInt(Math.Round(Original.Width / (Original.Height / height)))
        ElseIf Original.Width > Original.Height Then
            width = MaxSize.Width
            height = CInt(Math.Round(Original.Height / (Original.Width / width)))
        Else
            width = MaxSize.Width
            height = MaxSize.Height
        End If
        Dim bmp2 As New Bitmap(MaxSize.Width, MaxSize.Height)
        Dim g As Graphics = Graphics.FromImage(bmp2)
        g.Clear(BorderColor)
        g.DrawImage(Original, CInt(Math.Round((bmp2.Width - width) / 2)) + 1, CInt(Math.Round((bmp2.Height - height) / 2)) + 1, width - 3, height - 1)
        Dim image2 As Image = bmp2
        Return image2
    End Function


End Class
