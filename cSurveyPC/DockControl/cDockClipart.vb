Imports System.IO
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Drawings
Imports System.Xml
Imports System.ComponentModel
Imports cSurveyPC.cSurvey.Design.Items
Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports DevExpress.XtraTab
Imports DevExpress.XtraBars
Imports DevExpress.XtraVerticalGrid.Events
Imports cSurveyPC.cSurvey
Imports DevExpress.XtraBars.Navigation

Friend Class cDockClipart
    Private bLoaded As Boolean

    Private oSurvey As cSurvey.cSurvey

    Private bLoadItems As Boolean

    Private sPath As String
    Private sName As String

    Public Enum ViewModeEnum
        Gallery = 0
        Survey = 1
    End Enum

    Private iView As ViewModeEnum

    Public Class OnItemEventArgs
        Private oBag As cSurvey.Helper.Editor.cEditToolsBag
        Private sName As String
        Private sFilename As String

        Public ReadOnly Property Bag As cSurvey.Helper.Editor.cEditToolsBag
            Get
                Return oBag
            End Get
        End Property

        Public ReadOnly Property Name As String
            Get
                Return sName
            End Get
        End Property

        Public ReadOnly Property Filename As String
            Get
                Return sFilename
            End Get
        End Property

        Friend Sub New(ByVal Bag As cSurvey.Helper.Editor.cEditToolsBag, ByVal Name As String, ByVal Filename As String)
            oBag = Bag
            sName = Name
            sFilename = Filename
        End Sub
    End Class

    Friend Event OnItemCreate(ByVal Sender As Object, ByVal e As OnItemEventArgs)

    Private oDragItem As OnItemEventArgs
    Private oDragboxFromMouseDown As Rectangle
    Private oDragScreenOffset As Point

    Private oMousePointer As cMousePointer

    Public Sub SetSurvey(ByVal Survey As cSurveyPC.cSurvey.cSurvey)
        oSurvey = Survey
    End Sub

    Friend Function GetGalleryCount() As Integer
        Return tabGallery.Pages.Count
    End Function

    Friend Function GalleryIndexByCategory(Category As cIItem.cItemCategoryEnum) As Integer
        For i As Integer = 0 To tabGallery.Pages.Count - 1
            If GetGalleryBag(i).Category = Category Then
                Return i
            End If
        Next
        Return -1
    End Function

    Friend Function GetGalleryItems(Index As Integer) As List(Of cGalleryItem)
        Dim oResults As List(Of cGalleryItem) = New List(Of cGalleryItem)
        For Each oItem As cGalleryItem In DirectCast(DirectCast(tabGallery.Pages(Index).Tag, cGallery).Grid, DevExpress.XtraGrid.GridControl).DataSource
            Call oResults.Add(oItem)
        Next
        Return oResults
    End Function

    Friend Function GetGalleryBag(Index As Integer) As cSurvey.Helper.Editor.cEditToolsBag
        Return DirectCast(tabGallery.Pages(Index).Tag, cGallery).Grid.Tag
    End Function

    Friend Function GetGalleryText(Index As Integer) As String
        With tabGallery.Pages(Index)
            Return .Text
        End With
    End Function

    Friend Function GetGalleryName(Index As Integer) As String
        With DirectCast(tabGallery.Pages(Index).Tag, cGallery)
            Return .Name
        End With
    End Function

    Friend Function GetGalleryPath(Index As Integer) As String
        With DirectCast(tabGallery.Pages(Index).Tag, cGallery)
            Return IO.Path.Combine(.ParentPath, .Name)
        End With
    End Function

    Friend Sub AddGallery(ByVal ParentPath As String, ByVal Bag As cSurvey.Helper.Editor.cEditToolsBag, ByVal Name As String, ByVal Text As String, Groupable As Boolean)
        Dim oGrid As DevExpress.XtraGrid.GridControl = New DevExpress.XtraGrid.GridControl
        oGrid.Name = "gridview_" & Name
        Dim oExplorerView As DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView = New DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView(oGrid)
        oGrid.MainView = oExplorerView
        oExplorerView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        oExplorerView.OptionsView.Style = DevExpress.XtraGrid.Views.WinExplorer.WinExplorerViewStyle.Medium
        oExplorerView.OptionsView.ImageLayoutMode = DevExpress.Utils.Drawing.ImageLayoutMode.MiddleCenter
        oExplorerView.OptionsFind.AllowFindPanel = True
        oGrid.Tag = Bag

        oGrid.DataSource = New BindingList(Of cGalleryItem)

        Dim oColumnName As DevExpress.XtraGrid.Columns.GridColumn = oExplorerView.Columns.Add()
        oColumnName.FieldName = "Name"
        Dim oColumnCaption As DevExpress.XtraGrid.Columns.GridColumn = oExplorerView.Columns.Add()
        oColumnCaption.FieldName = "Caption"
        Dim oColumnAuthor As DevExpress.XtraGrid.Columns.GridColumn = oExplorerView.Columns.Add()
        oColumnAuthor.FieldName = "Author"
        Dim oColumnNote As DevExpress.XtraGrid.Columns.GridColumn = oExplorerView.Columns.Add()
        oColumnNote.FieldName = "Note"
        Dim oColumnCategory As DevExpress.XtraGrid.Columns.GridColumn = oExplorerView.Columns.Add()
        oColumnCategory.FieldName = "Category"
        Dim oColumnPreview As DevExpress.XtraGrid.Columns.GridColumn = oExplorerView.Columns.Add()
        oColumnPreview.FieldName = "Preview"
        If Groupable Then oExplorerView.ColumnSet.GroupColumn = oColumnCategory
        oExplorerView.ColumnSet.TextColumn = oColumnName
        oExplorerView.ColumnSet.MediumImageColumn = oColumnPreview
        oExplorerView.OptionsBehavior.Editable = False

        AddHandler oExplorerView.ItemDoubleClick, AddressOf oExplorerview_ItemDoubleClick
        AddHandler oExplorerView.DoubleClick, AddressOf oExplorerview_DoubleClick
        AddHandler oExplorerView.MouseDown, AddressOf oExplorerview_MouseDown
        AddHandler oExplorerView.MouseMove, AddressOf oExplorerview_MouseMove
        AddHandler oExplorerView.MouseUp, AddressOf oExplorerview_MouseUp

        AddHandler oExplorerView.FocusedRowObjectChanged, AddressOf oExplorerview_FocusedRowObjectChanged

        'Dim oLv As ListView = New ListView
        'oLv.Name = "listview_" & Name
        'oLv.LargeImageList = iml
        'oLv.SmallImageList = iml
        'oLv.BorderStyle = BorderStyle.None
        'oLv.Tag = Bag
        'AddHandler oLv.DoubleClick, AddressOf lv_DoubleClick
        'AddHandler oLv.MouseDown, AddressOf lv_MouseDown
        'AddHandler oLv.MouseMove, AddressOf lv_MouseMove
        'AddHandler oLv.MouseUp, AddressOf lv_MouseUp
        'AddHandler oLv.SelectedIndexChanged, AddressOf lv_SelectedIndexChanged
        'Call oTabPage.Controls.Add(oLv)
        'oLv.MultiSelect = False
        'oLv.HideSelection = False
        'oLv.Dock = DockStyle.Fill
        'oLv.ContextMenuStrip = mnuLvContext

        'Call oTabPage.Controls.Add(oGrid)
        'Call spMain.Panel1.Controls.Add(oGrid)


        Dim oPage As TabNavigationPage = New TabNavigationPage
        oPage.PageText = Text
        oPage.Name = "tabpage_" & Name
        oPage.Tag = New cGallery(ParentPath, Name, Groupable, oGrid)
        tabGallery.Pages.Add(oPage)
        Call oPage.Controls.Add(oGrid)

        oGrid.Dock = DockStyle.Fill
        oGrid.BringToFront()
        oGrid.Visible = True

    End Sub

    Private Function pGetCurrentGrid() As DevExpress.XtraGrid.GridControl
        If tabGallery.SelectedPage Is Nothing Then
            Return Nothing
        Else
            If tabGallery.SelectedPage.Tag Is Nothing Then
                Return Nothing
            Else
                Return DirectCast(tabGallery.SelectedPage.Tag, cGallery).Grid
            End If
        End If
    End Function

    Private Function pGetCurrentItem() As cGalleryItem
        Dim oGrid As DevExpress.XtraGrid.GridControl = pGetCurrentGrid()
        If oGrid Is Nothing Then
            Return Nothing
        Else
            Return DirectCast(oGrid.MainView, DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView).GetFocusedRow()
        End If
    End Function

    Private Sub pMetadataLoad()
        If pGetCurrentGrid() Is Nothing Then
            prpProperties.SelectedObject = Nothing
            prpProperties.Enabled = False
            btnAdd.Enabled = False
            btnRemove.Enabled = False
        Else
            Dim oItem As cGalleryItem = pGetCurrentItem()
            If oItem Is Nothing Then
                prpProperties.SelectedObject = Nothing
                prpProperties.Enabled = False
                btnAdd.Enabled = False
                btnRemove.Enabled = False
            Else
                prpProperties.SelectedObject = pGetCurrentItem.Metadata
                prpProperties.Enabled = True
                btnAdd.Enabled = True
                btnRemove.Enabled = (iView = ViewModeEnum.Gallery)
            End If
        End If
    End Sub

    Private Sub pAddGroups(Lv As ListView)
        Call Lv.Groups.Clear()
        For Each oValue In System.Enum.GetValues(GetType(Items.cIItemSign.SignCategoryEnum))
            Dim oGroup As ListViewGroup = New ListViewGroup(oValue, GetLocalizedString("main.category" & oValue))
            Call Lv.Groups.Add(oGroup)
        Next
    End Sub

    Private Sub pLoadGridItems(Items As BindingList(Of cGalleryItem), Bag As cSurvey.Helper.Editor.cEditToolsBag)
        Dim oBase As Object = oSurvey.GetType.InvokeMember(Bag.Cliparts, Reflection.BindingFlags.GetProperty Or Reflection.BindingFlags.Public Or Reflection.BindingFlags.IgnoreCase Or Reflection.BindingFlags.Instance, Nothing, oSurvey, Nothing)
        Dim oCliparts As List(Of cSurvey.cClipart) = oBase.getcliparts(Bag.Category)
        For Each oBaseItem As cSurvey.cClipart In oCliparts
            Dim oItem As cGalleryItem = New cGalleryItem(oBaseItem)
            Call Items.Add(oItem)
        Next
    End Sub

    Private Sub pLoadGridItems(Items As BindingList(Of cGalleryItem), ByVal Path As String, ByVal Name As String)
        Dim fd As DirectoryInfo = New DirectoryInfo(IO.Path.Combine(Path, Name))
        If fd.Exists Then
            For Each fl As FileInfo In fd.GetFiles("*.svg")
                If Not fl.Name Like "_*" Then
                    Try
                        Dim oItem As cGalleryItem = New cGalleryItem(fl)
                        Call Items.Add(oItem)
                    Catch ex As Exception
                    End Try
                End If
            Next
        End If
    End Sub

    Private Sub oExplorerview_DoubleClick(sender As Object, e As EventArgs)
        Dim oView As DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView = sender
        Dim oHitInfo As DevExpress.XtraGrid.Views.WinExplorer.ViewInfo.WinExplorerViewHitInfo = oView.CalcHitInfo(oView.GridControl.PointToClient(Cursor.Position))
        If (oHitInfo.HitTest = DevExpress.XtraGrid.Views.WinExplorer.ViewInfo.WinExplorerViewHitTest.GroupCaption) Then
            DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = True
        End If
    End Sub

    Private Sub oExplorerview_ItemDoubleClick(sender As Object, e As DevExpress.XtraGrid.Views.WinExplorer.WinExplorerViewItemDoubleClickEventArgs)
        Call pItemCreate()
    End Sub

    Private Sub oExplorerview_FocusedRowObjectChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs)
        Call pMetadataLoad()
    End Sub

    Private Sub pDisposeItems(Items As BindingList(Of cGalleryItem))
        For Each oItem As cGalleryItem In Items
            Call oItem.Dispose()
        Next
        Call Items.Clear()
    End Sub

    Private Sub pClipartLoadItems(Grid As DevExpress.XtraGrid.GridControl, ByVal Path As String, ByVal Name As String, Groupable As Boolean)
        Call oMousePointer.Push(Cursors.WaitCursor)

        Dim oExplorerView As DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView = Grid.MainView

        Call oExplorerView.BeginUpdate()
        Dim oItems As BindingList(Of cSurvey.cGalleryItem) = Grid.DataSource
        Call pDisposeItems(oItems)
        Select Case iView
            Case ViewModeEnum.Gallery
                Call pLoadGridItems(oItems, Path, Name)
            Case ViewModeEnum.Survey
                Dim oBag As cSurvey.Helper.Editor.cEditToolsBag = Grid.Tag
                Call pLoadGridItems(oItems, oBag)
        End Select
        Call oExplorerView.EndUpdate()

        'Dim oLv As ListView = Controls.Find("listview_" & Name, True)(0)
        'oLv.Enabled = False
        'Call oLv.BeginUpdate()
        'Call oLv.Items.Clear()
        'Select Case iView
        '    Case ViewModeEnum.Gallery
        '        If Groupable Then Call pAddGroups(oLv)
        '        Dim fd As DirectoryInfo = New DirectoryInfo(IO.Path.Combine(Path, Name))
        '        If fd.Exists Then
        '            For Each fl As FileInfo In fd.GetFiles("*.svg")
        '                If Not fl.Name Like "_*" Then
        '                    Try
        '                        Dim oClipart As cDrawClipArt = New cDrawClipArt(fl.FullName)
        '                        Dim oPreview As Image = oClipart.GetThumbnailImage(48, 48)
        '                        Dim oMetadata As cMetadata = New cMetadata(oClipart, fl.FullName)

        '                       Dim oItem As ListViewItem = New ListViewItem
        '                        Dim sName As String = oClipart.UserData.GetValue("caption" & "." & My.Application.CurrentLanguage, oClipart.UserData.GetValue("caption", IO.Path.GetFileNameWithoutExtension(fl.Name)))
        '                        Dim sImageName As String = Name & "_" & sName
        '                        If iml.Images.ContainsKey(sImageName) Then
        '                            Call iml.Images.RemoveByKey(sImageName)
        '                        End If
        '                        Call iml.Images.Add(sImageName, oPreview)

        '                        oItem.Text = sName
        '                        oItem.ImageKey = sImageName
        '                        oItem.Tag = {"file://" & fl.FullName, oClipart, oMetadata}
        '                        oItem.ToolTipText = fl.FullName
        '                        If Groupable Then
        '                            Dim sGroup As String = oMetadata.Sign And Items.cIItemSign.SignCategoryEnum.Mask
        '                            oItem.Group = oLv.Groups(sGroup)
        '                        End If
        '                        Call oLv.Items.Add(oItem)
        '                    Catch ex As Exception
        '                    End Try
        '                End If
        '            Next
        '        End If
        '    Case ViewModeEnum.Survey
        '        If Groupable Then Call pAddGroups(oLv)
        '        Dim oBase As Object = oSurvey.GetType.InvokeMember(oLv.Tag.cliparts, Reflection.BindingFlags.GetProperty Or Reflection.BindingFlags.Public Or Reflection.BindingFlags.IgnoreCase Or Reflection.BindingFlags.Instance, Nothing, oSurvey, Nothing)
        '        Dim oCliparts As List(Of cSurvey.cClipart) = oBase.getcliparts(oLv.Tag.category)
        '        For Each oBaseItem As cSurvey.cClipart In oCliparts
        '            Dim oClipart As cDrawClipArt = oBaseItem.Clipart
        '            Dim oPreview As Image = oClipart.GetThumbnailImage(48, 48)
        '            Dim oMetadata As cMetadata = New cMetadata(oClipart, oBaseItem.ID)

        '            Dim oItem As ListViewItem = New ListViewItem
        '            Dim sName As String = oClipart.UserData.GetValue("caption" & "." & My.Application.CurrentLanguage, oClipart.UserData.GetValue("caption", IO.Path.GetFileNameWithoutExtension(oBaseItem.Name)))
        '            Dim sImageName As String = Name & "_" & oBaseItem.ID
        '            If iml.Images.ContainsKey(sImageName) Then
        '                Call iml.Images.RemoveByKey(sImageName)
        '            End If
        '            Call iml.Images.Add(sImageName, oPreview)

        '            oItem.Text = sName
        '            oItem.ImageKey = sImageName
        '            oItem.Tag = {"id://" & oBaseItem.ID, oClipart, oMetadata}
        '            oItem.ToolTipText = sName
        '            If Groupable Then
        '                Dim sGroup As String = oMetadata.Sign And Items.cIItemSign.SignCategoryEnum.Mask
        '                oItem.Group = oLv.Groups(sGroup)
        '            End If
        '            Call oLv.Items.Add(oItem)
        '        Next
        'End Select
        'Call oLv.EndUpdate()
        'oLv.Enabled = True
        Call oMousePointer.Pop()
    End Sub

    Private Sub lv_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Call pItemCreate()
    End Sub

    Private Sub oExplorerview_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim oGrid As DevExpress.XtraGrid.GridControl = pGetCurrentGrid()
        If Not oGrid Is Nothing Then
            Dim oView As DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView = oGrid.MainView
            Dim oHitInfo As DevExpress.XtraGrid.Views.WinExplorer.ViewInfo.WinExplorerViewHitInfo = oView.CalcHitInfo(e.Location)
            If oHitInfo.InItem Then
                Dim oItem As cGalleryItem = oView.GetRow(oHitInfo.RowHandle)
                If Not oItem Is Nothing Then
                    oDragItem = New OnItemEventArgs(oGrid.Tag, oGrid.Name, oItem.Filename)
                    Dim oDragSize As Size = SystemInformation.DragSize
                    oDragboxFromMouseDown = New Rectangle(New Point(e.X - (oDragSize.Width / 2), e.Y - (oDragSize.Height / 2)), oDragSize)
                Else
                    oDragboxFromMouseDown = Rectangle.Empty
                End If
            End If
        End If
    End Sub

    Private Sub oExplorerview_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If ((e.Button And MouseButtons.Left) = MouseButtons.Left) Then
            If (Rectangle.op_Inequality(oDragboxFromMouseDown, Rectangle.Empty) And Not oDragboxFromMouseDown.Contains(e.X, e.Y)) Then
                Dim oGrid As DevExpress.XtraGrid.GridControl = pGetCurrentGrid()
                oDragScreenOffset = SystemInformation.WorkingArea.Location
                Dim oDropEffect As DragDropEffects = oGrid.DoDragDrop(oDragItem, DragDropEffects.Copy)
            End If
        End If
    End Sub

    Private Sub oExplorerview_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        oDragboxFromMouseDown = Rectangle.Empty
        If (e.Button = MouseButtons.Right) Then
            Dim oView As DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView = sender
            Call mnuGridContext.ShowPopup(oView.GridControl.PointToScreen(e.Location))
        End If
    End Sub

    Private Sub pItemRemove()
        Dim oGrid As DevExpress.XtraGrid.GridControl = pGetCurrentGrid()
        If Not oGrid Is Nothing Then
            Dim oItem As cGalleryItem = pGetCurrentItem()
            If Not oItem Is Nothing Then
                If cSurvey.UIHelpers.Dialogs.Msgbox(modMain.GetLocalizedString("clipartgallery.warning1"), MsgBoxStyle.YesNo Or MsgBoxStyle.Question, modMain.GetLocalizedString("clipartgallery.warningtitle")) = vbYes Then
                    Dim sOldFilename As String = oItem.Filename
                    If sOldFilename.StartsWith("file://") Then
                        sOldFilename = sOldFilename.Substring(7)
                    End If
                    Dim sNewFilename As String = Path.Combine(Path.GetDirectoryName(sOldFilename), "_" & Path.GetFileName(sOldFilename))
                    Call My.Computer.FileSystem.MoveFile(sOldFilename, sNewFilename, True)
                    DirectCast(oGrid.DataSource, BindingList(Of cGalleryItem)).Remove(oItem)
                End If
            End If
        End If
    End Sub

    Private Sub pItemCreate()
        Dim oGrid As DevExpress.XtraGrid.GridControl = pGetCurrentGrid()
        If Not oGrid Is Nothing Then
            Dim oItem As cGalleryItem = pGetCurrentItem()
            If Not oItem Is Nothing Then
                Dim sName As String = oGrid.Name
                Dim oBag As cSurvey.Helper.Editor.cEditToolsBag = oGrid.Tag
                Dim sFilename As String = pGetCurrentItem.Filename
                RaiseEvent OnItemCreate(Me, New OnItemEventArgs(oBag, sName, sFilename))
            End If
        End If
    End Sub

    Private Sub pRefresh()
        Dim oItem As TabNavigationPage = tabGallery.SelectedPage
        Dim oGallery As cGallery = oItem.Tag
        Call pClipartLoadItems(oGallery.Grid, oGallery.ParentPath, oGallery.Name, oGallery.Groupable)
    End Sub

    Public Sub New()
        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        oMousePointer = New cMousePointer
        Call pSetViewState(ViewModeEnum.Gallery)

        Call pMetadataHide()
        'Call pMetadataLoad()
    End Sub

    Private Sub pSetViewState(NewView As ViewModeEnum)
        If iView <> NewView Then
            iView = NewView
            Select Case iView
                Case ViewModeEnum.Gallery
                    btnViewGallery.Checked = True
                    btnViewSurvey.Checked = False
                    btnAdd.Enabled = False
                    btnRemove.Enabled = False
                Case ViewModeEnum.Survey
                    btnViewGallery.Checked = False
                    btnViewSurvey.Checked = True
                    btnAdd.Enabled = False
                    btnRemove.Enabled = False
            End Select

            For Each oItem As TabNavigationPage In tabGallery.Pages
                Dim oGrid As DevExpress.XtraGrid.GridControl = DirectCast(oItem.Tag, cGallery).Grid
                Call oGrid.DataSource.clear
            Next

            Call pClipartLoad()

            'Call iml.Images.Clear()
            'For Each oTab As XtraTabPage In tabGallery.TabPages
            '    Dim oData As Object = oTab.Tag
            '    Dim sPath As String = oData(0)
            '    Dim sName As String = oData(1)
            '    Dim oLv As ListView = Controls.Find("listview_" & sName, True)(0)
            '    Call oLv.Items.Clear()
            'Next
        End If
    End Sub

    Public Sub LoadGalleries()
        Call pClipartLoad(True)
    End Sub

    Private Sub pClipartLoad(Optional Force As Boolean = False)
        If Force OrElse Not modMain.bIsInDebug Then
            For Each oItem As TabNavigationPage In tabGallery.Pages
                Dim oGallery As cGallery = oItem.Tag
                If (oGallery.Grid.DataSource Is Nothing) OrElse (oGallery.Grid.DataSource.count = 0) Then
                    Call pClipartLoadItems(oGallery.Grid, oGallery.ParentPath, oGallery.Name, oGallery.Groupable)
                End If
            Next
        End If
    End Sub

    Private Sub pMetadataHide()
        spMain.SetPanelCollapsed(True)
        btnEditMetadata.Checked = False
    End Sub

    Private Sub pMetadataShow()
        spMain.SetPanelCollapsed(False)
        btnEditMetadata.Checked = True
    End Sub

    Private Sub btnRefresh_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnRefresh.ItemClick
        Call pRefresh()
    End Sub

    Private Sub btnEditMetadata_CheckedChanged(sender As Object, e As ItemClickEventArgs) Handles btnEditMetadata.CheckedChanged
        If btnEditMetadata.Checked Then
            Call pMetadataShow()
        Else
            Call pMetadataHide()
        End If
    End Sub

    Private Sub btnViewSurvey_CheckedChanged(sender As Object, e As ItemClickEventArgs) Handles btnViewSurvey.CheckedChanged
        If btnViewSurvey.Checked Then
            Call pSetViewState(ViewModeEnum.Survey)
        End If
    End Sub

    Private Sub prpProperties_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles prpProperties.CellValueChanged
        Dim oMetadata As cGalleryMetadata = prpProperties.SelectedObject
        Call oMetadata.Save()
    End Sub

    Private Sub btnViewGallery_CheckedChanged(sender As Object, e As ItemClickEventArgs) Handles btnViewGallery.CheckedChanged
        If btnViewGallery.Checked Then
            Call pSetViewState(ViewModeEnum.Gallery)
        End If
    End Sub

    Private Sub btnAdd_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnAdd.ItemClick
        Call pItemCreate()
    End Sub

    Private Sub btnRemove_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnRemove.ItemClick
        Call pItemRemove()
    End Sub

    Private Sub btnOpenInExplorer_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnOpenInExplorer.ItemClick
        Dim sPath As String = GetGalleryPath(tabGallery.SelectedPageIndex)
        Call Process.Start(sPath)
    End Sub

    Private Sub tabGallery_SelectedPageChanged(sender As Object, e As SelectedPageChangedEventArgs) Handles tabGallery.SelectedPageChanged
        'Dim oGrid As DevExpress.XtraGrid.GridControl = DirectCast(DirectCast(e.Page, NavigationPage).Tag, cGallery).Grid
        'oGrid.Focus()
        Call pMetadataLoad()
    End Sub

    Private bFirstShown As Boolean = True

    Private Sub cDockClipart_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Visible Then
            If bFirstShown Then
                bFirstShown = False
                Call pClipartLoad()
            End If
        End If
    End Sub
End Class
