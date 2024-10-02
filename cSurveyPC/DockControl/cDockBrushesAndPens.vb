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
Imports DevExpress.XtraGrid.Views.Base

Friend Class cDockBrushesAndPens
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
        Private oItem As cICustomPaintElement

        Public ReadOnly Property Item As cICustomPaintElement
            Get
                Return oItem
            End Get
        End Property

        Friend Sub New(ByVal Item As cICustomPaintElement)
            oItem = Item
        End Sub
    End Class

    Friend Event OnItemApplyTo(ByVal Sender As Object, ByVal e As OnItemEventArgs)
    Friend Event OnElementDelete(sender As Object, e As OnItemEventArgs)
    Friend Event OnElementCustomToUser(sender As Object, e As OnItemEventArgs)

    Private oDragItem As OnItemEventArgs
    Private oDragboxFromMouseDown As Rectangle
    Private oDragScreenOffset As Point

    Public Sub SetSurvey(ByVal Survey As cSurveyPC.cSurvey.cSurvey)
        oSurvey = Survey
    End Sub

    Friend Function GetGalleryCount() As Integer
        Return tabGallery.Pages.Count
    End Function

    'Friend Function GetGalleryItems(Index As Integer) As List(Of cGalleryItem)
    '    Dim oResults As List(Of cGalleryItem) = New List(Of cGalleryItem)
    '    For Each oItem As cGalleryItem In DirectCast(DirectCast(tabGallery.Pages(Index).Tag, cGallery).Grid, DevExpress.XtraGrid.GridControl).DataSource
    '        Call oResults.Add(oItem)
    '    Next
    '    Return oResults
    'End Function

    Friend Function GetGalleryPath(Index As Integer) As String
        Return modMain.GetUserApplicationPath
    End Function

    Friend Function GetGalleryText(Index As Integer) As String
        Return tabGallery.Pages(Index).PageText
    End Function

    Friend Function GetGalleryName(Index As Integer) As String
        Return tabGallery.Pages(Index).Controls(0).Tag(0)
    End Function


    Private Sub oExplorerview_FocusedRowObjectChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs)
        Dim oItem As cCustomPaintElementBag = sender.GetRow(e.FocusedRowHandle)
        If oItem Is Nothing Then
            btnApplyTo.Enabled = False
            btnRemove.Enabled = False
            btnCustomToUser.Enabled = False
        Else
            btnApplyTo.Enabled = True
            btnRemove.Enabled = True
            btnCustomToUser.Enabled = True
        End If
    End Sub

    Private Function pGetCurrentGrid() As DevExpress.XtraGrid.GridControl
        If tabGallery.SelectedPage Is Nothing Then
            Return Nothing
        Else
            Return tabGallery.SelectedPage.Controls(0)
        End If
    End Function

    Private Function pGetCurrentBagItem() As cCustomPaintElementBag
        Dim oGrid As DevExpress.XtraGrid.GridControl = pGetCurrentGrid()
        If oGrid Is Nothing Then
            Return Nothing
        Else
            Return DirectCast(oGrid.MainView, DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView).GetFocusedRow()
        End If
    End Function

    Private Function pGetCurrentItem() As cICustomPaintElement
        Dim oGrid As DevExpress.XtraGrid.GridControl = pGetCurrentGrid()
        If oGrid Is Nothing Then
            Return Nothing
        Else
            Dim oItem As cCustomPaintElementBag = DirectCast(oGrid.MainView, DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView).GetFocusedRow()
            If oItem Is Nothing Then
                Return Nothing
            Else
                Return oItem.Item
            End If
        End If
    End Function

    Private Sub oExplorerview_DoubleClick(sender As Object, e As EventArgs)
        Dim oView As DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView = sender
        Dim oHitInfo As DevExpress.XtraGrid.Views.WinExplorer.ViewInfo.WinExplorerViewHitInfo = oView.CalcHitInfo(oView.GridControl.PointToClient(Cursor.Position))
        If (oHitInfo.HitTest = DevExpress.XtraGrid.Views.WinExplorer.ViewInfo.WinExplorerViewHitTest.GroupCaption) Then
            DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = True
        End If
    End Sub

    Private Sub oExplorerview_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs)

    End Sub
    Private Sub oExplorerview_ItemDoubleClick(sender As Object, e As DevExpress.XtraGrid.Views.WinExplorer.WinExplorerViewItemDoubleClickEventArgs)
        Call pItemApplyTo()
    End Sub

    'Private Sub pDisposeItems(Items As BindingList(Of cGalleryItem))
    '    For Each oItem As cGalleryItem In Items
    '        Call oItem.Dispose()
    '    Next
    '    Call Items.Clear()
    'End Sub

    Private Sub pFillBrushesGalleryFromFile(Grid As DevExpress.XtraGrid.GridControl, Imagelist As DevExpress.Utils.SvgImageCollection)
        Dim oItems As BindingList(Of cCustomPaintElementBag) = Grid.DataSource
        oItems.Clear()
        Imagelist.Clear()
        For Each sFilename As String In My.Computer.FileSystem.GetFiles(modMain.GetUserApplicationPath, FileIO.SearchOption.SearchTopLevelOnly, {"*.cbrush"})
            Dim oBrush As cCustomBrush = New cCustomBrush(oSurvey, sFilename)
            If oBrush.Type = cBrush.BrushTypeEnum.User Then
                Imagelist.Add(pGetBrushSvgImage(oBrush))
                Call oItems.Add(New cCustomPaintElementBag(oBrush, Imagelist.Count - 1))
            End If
        Next
    End Sub
    Private Function pGetBrushSvgImage(Brush As cCustomBrush) As DevExpress.Utils.Svg.SvgImage
        Using oms As MemoryStream = New MemoryStream
            Brush.GetThumbnailSVG(oSurvey.Options.Item("_design.plan"), cItem.PaintOptionsEnum.FullLayerDraw, False, 32, 32, Color.DarkGray, Color.White).Save(oms)
            Call oms.Seek(0, SeekOrigin.Begin)
            Return DevExpress.Utils.Svg.SvgImage.FromStream(oms)
        End Using
    End Function

    'Private Function pGetBrushImage(Brush As cCustomBrush) As Image
    '    Return Brush.GetThumbnailImage(oSurvey.Options.Item("_design.plan"), cItem.PaintOptionsEnum.FullLayerDraw, False, 32, 32, Color.DarkGray, Color.White)
    'End Function

    Private Sub pFillBrushesGalleryFromSurvey(Grid As DevExpress.XtraGrid.GridControl, Imagelist As DevExpress.Utils.SvgImageCollection)
        Dim oItems As BindingList(Of cCustomPaintElementBag) = Grid.DataSource
        oItems.Clear()
        Imagelist.Clear()
        For Each oBrush As cCustomBrush In oSurvey.Brushes
            If oBrush.Type = cBrush.BrushTypeEnum.User Then
                Imagelist.Add(pGetBrushSvgImage(oBrush))
                Call oItems.Add(New cCustomPaintElementBag(oBrush, Imagelist.Count - 1))
            End If
        Next
    End Sub
    'Private Function pGetPenImage(Pen As cCustomPen) As Image
    '    Return Pen.GetThumbnailImage(oSurvey.Options.Item("_design.plan"), cItem.PaintOptionsEnum.FullLayerDraw, False, 32, 32, Color.DarkGray, Color.White)
    'End Function

    Private Function pGetPenSvgImage(Pen As cCustomPen) As DevExpress.Utils.Svg.SvgImage
        Using oms As MemoryStream = New MemoryStream
            Pen.GetThumbnailSVG(oSurvey.Options.Item("_design.plan"), cItem.PaintOptionsEnum.FullLayerDraw, False, 32, 32, Color.DarkGray, Color.White).Save(oms)
            Call oms.Seek(0, SeekOrigin.Begin)
            Return DevExpress.Utils.Svg.SvgImage.FromStream(oms)
        End Using
    End Function

    Private Sub pFillPensGalleryFromFile(Grid As DevExpress.XtraGrid.GridControl, Imagelist As DevExpress.Utils.SvgImageCollection)
        Dim oItems As BindingList(Of cCustomPaintElementBag) = Grid.DataSource
        oItems.Clear()
        Imagelist.Clear()
        For Each sFilename As String In My.Computer.FileSystem.GetFiles(modMain.GetUserApplicationPath, FileIO.SearchOption.SearchTopLevelOnly, {"*.cpen"})
            Dim oPen As cCustomPen = New cCustomPen(oSurvey, sFilename)
            If oPen.Type = cPen.PenTypeEnum.User Then
                Imagelist.Add(pGetPenSvgImage(oPen))
                Call oItems.Add(New cCustomPaintElementBag(oPen, Imagelist.Count - 1))
            End If
        Next
    End Sub

    Private Sub pFillPensGalleryFromSurvey(Grid As DevExpress.XtraGrid.GridControl, Imagelist As DevExpress.Utils.SvgImageCollection)
        Dim oItems As BindingList(Of cCustomPaintElementBag) = Grid.DataSource
        oItems.Clear()
        Imagelist.Clear()
        For Each oPen As cCustomPen In oSurvey.Pens
            If oPen.Type = cPen.PenTypeEnum.User Then
                Imagelist.Add(pGetPenSvgImage(oPen))
                Call oItems.Add(New cCustomPaintElementBag(oPen, Imagelist.Count - 1))
            End If
        Next
    End Sub

    Private Sub pLoadItems(Grid As DevExpress.XtraGrid.GridControl, Imagelist As DevExpress.Utils.SvgImageCollection)
        'Call oMousePointer.Push(Cursors.WaitCursor)

        Dim oExplorerView As DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView = Grid.MainView

        Call oExplorerView.BeginUpdate()
        Dim sType As String = Grid.Tag(0).ToString
        Select Case iView
            Case ViewModeEnum.Gallery
                Select Case sType
                    Case "cbrush"
                        Call pFillBrushesGalleryFromFile(Grid, Imagelist)
                    Case "cpen"
                        Call pFillPensGalleryFromFile(Grid, Imagelist)
                End Select
            Case ViewModeEnum.Survey
                Select Case sType
                    Case "cbrush"
                        Call pFillBrushesGalleryFromSurvey(Grid, Imagelist)
                    Case "cpen"
                        Call pFillPensGalleryFromSurvey(Grid, Imagelist)
                End Select
        End Select
        Call oExplorerView.EndUpdate()
        'Call oMousePointer.Pop()
    End Sub

    Private Sub lv_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Call pItemApplyTo()
    End Sub

    Private Sub oExplorerview_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim oGrid As DevExpress.XtraGrid.GridControl = pGetCurrentGrid()
        If Not oGrid Is Nothing Then
            Dim oView As DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView = oGrid.MainView
            Dim oHitInfo As DevExpress.XtraGrid.Views.WinExplorer.ViewInfo.WinExplorerViewHitInfo = oView.CalcHitInfo(e.Location)
            If oHitInfo.InItem Then
                Dim oItem As cCustomPaintElementBag = oView.GetRow(oHitInfo.RowHandle)
                If Not oItem Is Nothing Then
                    oDragItem = New OnItemEventArgs(oItem.Item)
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
        Dim oBagItem As cCustomPaintElementBag = pGetCurrentBagItem()
        If iView = ViewModeEnum.Gallery Then
            If UIHelpers.Dialogs.Msgbox(String.Format(modMain.GetLocalizedString("main.warning36"), oBagItem.Filename, oBagItem.Name), MsgBoxStyle.Critical Or MsgBoxStyle.YesNo, modMain.GetLocalizedString("main.warningtitle")) = MsgBoxResult.Yes Then
                My.Computer.FileSystem.DeleteFile(oBagItem.Filename, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin)
                Call oGrid.DataSource.remove(oBagItem)
            End If
        ElseIf iView = ViewModeEnum.Survey Then
            If UIHelpers.Dialogs.Msgbox(String.Format(modMain.GetLocalizedString("main.warning37"), oBagItem.Filename, oBagItem.Name), MsgBoxStyle.Critical Or MsgBoxStyle.YesNo, modMain.GetLocalizedString("main.warningtitle")) = MsgBoxResult.Yes Then
                RaiseEvent OnElementDelete(Me, New OnItemEventArgs(oBagItem.Item))
                Call oGrid.DataSource.remove(oBagItem)
            End If
        End If
    End Sub

    Private Sub pItemApplyTo()
        Dim oItem As cICustomPaintElement = pGetCurrentItem()
        RaiseEvent OnItemApplyTo(Me, New OnItemEventArgs(oItem))
    End Sub

    Public Sub GalleryRefresh(View As Integer, GalleryName As String)
        Call GalleryRefresh(View, tabGallery.Pages.FirstOrDefault(Function(oPage) oPage.Name = "tabpage_" & GalleryName).TabIndex)
    End Sub

    Public Sub GalleryRefresh(View As Integer, GalleryIndex As Integer)
        If iView = View Then
            Dim oItem As TabNavigationPage = tabGallery.Pages(GalleryIndex)
            Dim oGrid As DevExpress.XtraGrid.GridControl = oItem.Controls(0)
            Dim oImagelist As DevExpress.Utils.SvgImageCollection = DirectCast(oGrid.MainView, DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView).MediumImages
            Call pLoadItems(oGrid, oImagelist)
        End If
    End Sub

    Private Sub pRefresh()
        Call GalleryRefresh(iView, tabGallery.SelectedPage.TabIndex)
    End Sub

    Public Sub New()
        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        'oMousePointer = New cMousePointer
        Call pSetViewState(ViewModeEnum.Gallery)
        pAddGalleryBrushes()
        pAddGalleryPens()

        'pAddGallery(My.Computer.FileSystem.GetFiles(modMain.GetUserApplicationPath, FileIO.SearchOption.SearchTopLevelOnly, {"*.cpen"}), New BindingList(Of cCustomPen), "pens", "Pen")

        'Call pMetadataHide()
        'Call pMetadataLoad()
    End Sub

    Private Class cCustomPaintElementBag
        Private oItem As cICustomPaintElement
        Private iPreviewIndex As Integer

        Public ReadOnly Property Item As cICustomPaintElement
            Get
                Return oItem
            End Get
        End Property

        Public Sub New(Item As cICustomPaintElement, PreviewIndex As Integer)
            oItem = Item
            iPreviewIndex = PreviewIndex
        End Sub

        Public ReadOnly Property PreviewIndex As Integer
            Get
                Return iPreviewIndex
            End Get
        End Property

        Public ReadOnly Property Filename As String
            Get
                Return oItem.Filename
            End Get
        End Property

        Public ReadOnly Property ID As String
            Get
                Return oItem.ID
            End Get
        End Property

        Public Property Name As String
            Get
                Return oItem.Name
            End Get
            Set(value As String)
                oItem.Name = value
            End Set
        End Property
    End Class

    Private Sub pAddGalleryBrushes()
        Dim oImagelist As DevExpress.Utils.SvgImageCollection = New DevExpress.Utils.SvgImageCollection(Me.components)
        oImagelist.ImageSize = New Size(48, 48)

        Dim oGrid As DevExpress.XtraGrid.GridControl = New DevExpress.XtraGrid.GridControl
        oGrid.Name = "gridview_brushes"
        oGrid.Tag = {"cbrush"}

        Dim oExplorerView As DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView = New DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView(oGrid)
        oGrid.MainView = oExplorerView
        oExplorerView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        oExplorerView.OptionsView.Style = DevExpress.XtraGrid.Views.WinExplorer.WinExplorerViewStyle.Medium
        oExplorerView.OptionsView.ImageLayoutMode = DevExpress.Utils.Drawing.ImageLayoutMode.MiddleCenter
        oExplorerView.OptionsFind.AllowFindPanel = True
        oExplorerView.MediumImages = oImagelist

        oGrid.DataSource = New BindingList(Of cCustomPaintElementBag)

        Dim oColumnName As DevExpress.XtraGrid.Columns.GridColumn = oExplorerView.Columns.Add()
        oColumnName.FieldName = "Name"
        'Dim oColumnCaption As DevExpress.XtraGrid.Columns.GridColumn = oExplorerView.Columns.Add()
        'oColumnCaption.FieldName = "Caption"
        'Dim oColumnAuthor As DevExpress.XtraGrid.Columns.GridColumn = oExplorerView.Columns.Add()
        'oColumnAuthor.FieldName = "Author"
        'Dim oColumnNote As DevExpress.XtraGrid.Columns.GridColumn = oExplorerView.Columns.Add()
        'oColumnNote.FieldName = "Note"
        'Dim oColumnCategory As DevExpress.XtraGrid.Columns.GridColumn = oExplorerView.Columns.Add()
        'oColumnCategory.FieldName = "Category"
        Dim oColumnPreview As DevExpress.XtraGrid.Columns.GridColumn = oExplorerView.Columns.Add()
        'oColumnPreview.UnboundDataType = GetType(Object)
        oColumnPreview.FieldName = "PreviewIndex"
        Dim oPreview As DevExpress.XtraEditors.Repository.RepositoryItemImageEdit = New DevExpress.XtraEditors.Repository.RepositoryItemImageEdit
        oPreview.SvgImageSize = New Size(48, 48)
        oColumnPreview.ColumnEdit = oPreview

        'If Groupable Then oExplorerView.ColumnSet.GroupColumn = oColumnCategory
        oExplorerView.ColumnSet.TextColumn = oColumnName
        oExplorerView.ColumnSet.MediumImageIndexColumn = oColumnPreview
        oExplorerView.OptionsBehavior.Editable = False

        AddHandler oExplorerView.ItemDoubleClick, AddressOf oExplorerview_ItemDoubleClick
        AddHandler oExplorerView.DoubleClick, AddressOf oExplorerview_DoubleClick
        AddHandler oExplorerView.MouseDown, AddressOf oExplorerview_MouseDown
        AddHandler oExplorerView.MouseMove, AddressOf oExplorerview_MouseMove
        AddHandler oExplorerView.MouseUp, AddressOf oExplorerview_MouseUp
        'AddHandler oExplorerView.CustomUnboundColumnData, AddressOf oExplorerview_CustomUnboundColumnData

        AddHandler oExplorerView.FocusedRowObjectChanged, AddressOf oExplorerview_FocusedRowObjectChanged

        Dim oPage As TabNavigationPage = New TabNavigationPage
        oPage.PageText = "Brushes"
        oPage.Name = "tabpage_brushes"
        tabGallery.Pages.Add(oPage)
        Call oPage.Controls.Add(oGrid)

        oGrid.Dock = DockStyle.Fill
        oGrid.BringToFront()
        oGrid.Visible = True

    End Sub

    'Private Sub oExplorerview_CustomUnboundColumnData(sender As Object, e As CustomColumnDataEventArgs)
    '    If e.IsGetData Then
    '        If e.Column.FieldName = "_preview" Then
    '            e.Value = e.Row.PreviewImage
    '        End If
    '    End If
    'End Sub

    Private Sub pAddGalleryPens()
        Dim oImagelist As DevExpress.Utils.SvgImageCollection = New DevExpress.Utils.SvgImageCollection(Me.components)
        oImagelist.ImageSize = New Size(48, 48)

        Dim oGrid As DevExpress.XtraGrid.GridControl = New DevExpress.XtraGrid.GridControl
        oGrid.Name = "gridview_pens"
        oGrid.Tag = {"cpen"}

        Dim oExplorerView As DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView = New DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView(oGrid)
        oGrid.MainView = oExplorerView
        oExplorerView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        oExplorerView.OptionsView.Style = DevExpress.XtraGrid.Views.WinExplorer.WinExplorerViewStyle.Medium
        oExplorerView.OptionsView.ImageLayoutMode = DevExpress.Utils.Drawing.ImageLayoutMode.MiddleCenter
        oExplorerView.OptionsFind.AllowFindPanel = True
        oExplorerView.MediumImages = oImagelist

        oGrid.DataSource = New BindingList(Of cCustomPaintElementBag)

        Dim oColumnName As DevExpress.XtraGrid.Columns.GridColumn = oExplorerView.Columns.Add()
        oColumnName.FieldName = "Name"
        'Dim oColumnCaption As DevExpress.XtraGrid.Columns.GridColumn = oExplorerView.Columns.Add()
        'oColumnCaption.FieldName = "Caption"
        'Dim oColumnAuthor As DevExpress.XtraGrid.Columns.GridColumn = oExplorerView.Columns.Add()
        'oColumnAuthor.FieldName = "Author"
        'Dim oColumnNote As DevExpress.XtraGrid.Columns.GridColumn = oExplorerView.Columns.Add()
        'oColumnNote.FieldName = "Note"
        'Dim oColumnCategory As DevExpress.XtraGrid.Columns.GridColumn = oExplorerView.Columns.Add()
        'oColumnCategory.FieldName = "Category"
        Dim oColumnPreview As DevExpress.XtraGrid.Columns.GridColumn = oExplorerView.Columns.Add()
        oColumnPreview.FieldName = "PreviewIndex"
        oColumnPreview.ColumnEdit = New DevExpress.XtraEditors.Repository.RepositoryItemImageEdit
        Dim oPreview As DevExpress.XtraEditors.Repository.RepositoryItemImageEdit = New DevExpress.XtraEditors.Repository.RepositoryItemImageEdit
        oPreview.SvgImageSize = New Size(48, 48)
        oColumnPreview.ColumnEdit = oPreview

        'If Groupable Then oExplorerView.ColumnSet.GroupColumn = oColumnCategory
        oExplorerView.ColumnSet.TextColumn = oColumnName
        oExplorerView.ColumnSet.MediumImageIndexColumn = oColumnPreview
        oExplorerView.OptionsBehavior.Editable = False

        AddHandler oExplorerView.FocusedRowChanged, AddressOf oExplorerview_FocusedRowChanged
        AddHandler oExplorerView.ItemDoubleClick, AddressOf oExplorerview_ItemDoubleClick
        AddHandler oExplorerView.DoubleClick, AddressOf oExplorerview_DoubleClick
        AddHandler oExplorerView.MouseDown, AddressOf oExplorerview_MouseDown
        AddHandler oExplorerView.MouseMove, AddressOf oExplorerview_MouseMove
        AddHandler oExplorerView.MouseUp, AddressOf oExplorerview_MouseUp

        AddHandler oExplorerView.FocusedRowObjectChanged, AddressOf oExplorerview_FocusedRowObjectChanged

        Dim oPage As TabNavigationPage = New TabNavigationPage
        oPage.PageText = "Pens"
        oPage.Name = "tabpage_pens"
        tabGallery.Pages.Add(oPage)
        Call oPage.Controls.Add(oGrid)

        oGrid.Dock = DockStyle.Fill
        oGrid.BringToFront()
        oGrid.Visible = True

    End Sub

    Private Sub pSetViewState(NewView As ViewModeEnum)
        If iView <> NewView Then
            iView = NewView
            Select Case iView
                Case ViewModeEnum.Gallery
                    btnViewGallery.Checked = True
                    btnViewSurvey.Checked = False
                    btnApplyTo.Enabled = False
                    btnRemove.Enabled = False
                    btnCustomToUser.Enabled = False
                    'btnReplaceWith.Visibility = BarItemVisibility.Never
                    'btnReplaceWith.Enabled = False
                Case ViewModeEnum.Survey
                    btnViewGallery.Checked = False
                    btnViewSurvey.Checked = True
                    btnApplyTo.Enabled = False
                    btnRemove.Enabled = False
                    btnCustomToUser.Enabled = False
                    'TODO: to be implemented
                    'btnReplaceWith.Visibility = BarItemVisibility.Always
                    'btnReplaceWith.Enabled = True
            End Select

            For Each oItem As TabNavigationPage In tabGallery.Pages
                Dim oGrid As DevExpress.XtraGrid.GridControl = oItem.Controls(0)
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
                Dim oGrid As DevExpress.XtraGrid.GridControl = oItem.Controls(0)
                Dim oImagelist As DevExpress.Utils.SvgImageCollection = DirectCast(oGrid.MainView, DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView).MediumImages
                Call pLoadItems(oGrid, oImagelist)
            Next
        End If
    End Sub

    'Private Sub pMetadataHide()
    '    spMain.SetPanelCollapsed(True)
    '    btnEditMetadata.Checked = False
    'End Sub

    'Private Sub pMetadataShow()
    '    spMain.SetPanelCollapsed(False)
    '    btnEditMetadata.Checked = True
    'End Sub

    Private Sub btnRefresh_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnRefresh.ItemClick
        Call pRefresh()
    End Sub

    'Private Sub btnEditMetadata_CheckedChanged(sender As Object, e As ItemClickEventArgs) Handles btnEditMetadata.CheckedChanged
    '    If btnEditMetadata.Checked Then
    '        Call pMetadataShow()
    '    Else
    '        Call pMetadataHide()
    '    End If
    'End Sub

    Private Sub btnViewSurvey_CheckedChanged(sender As Object, e As ItemClickEventArgs) Handles btnViewSurvey.CheckedChanged
        If btnViewSurvey.Checked Then
            Call pSetViewState(ViewModeEnum.Survey)
        End If
    End Sub

    Private Sub btnViewGallery_CheckedChanged(sender As Object, e As ItemClickEventArgs) Handles btnViewGallery.CheckedChanged
        If btnViewGallery.Checked Then
            Call pSetViewState(ViewModeEnum.Gallery)
        End If
    End Sub

    Private Sub btnApplyTo_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnApplyTo.ItemClick
        Call pItemApplyTo()
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
    End Sub

    Private bFirstShown As Boolean = True

    Private Sub cDockBrushesAndPens_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Visible Then
            If bFirstShown Then
                bFirstShown = False
                Call pClipartLoad()
            End If
        End If
    End Sub

    Private Sub pElementCustomToUser()
        Dim oItem As cICustomPaintElement = pGetCurrentItem()
        RaiseEvent OnElementCustomToUser(Me, New OnItemEventArgs(oItem))
    End Sub

    Private Sub btnReplaceWith_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnReplaceWith.ItemClick
    End Sub

    Private Sub btnCustomToUser_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnCustomToUser.ItemClick
        Call pElementCustomToUser()
    End Sub
End Class
