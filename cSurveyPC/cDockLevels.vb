Imports System.Linq
Imports System.ComponentModel
Imports BrightIdeasSoftware
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items
Imports DevExpress
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraTreeList.Nodes
Imports cSurveyPC.cSurvey.Helper.Editor
Imports DevExpress.XtraBars
Imports System.Threading.Tasks

Friend Class cDockLevels
    Private oSurvey As cSurveyPC.cSurvey.cSurvey
    Private oDesign As cDesign
    Private WithEvents oDesignTools As Helper.Editor.cEditDesignTools
    Private oCurrentOptions As cOptionsDesign
    Private oDefaultOptions As cOptions

    Private bLayersShowItemPreview As Boolean

    Public Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        bLayersShowItemPreview = False
    End Sub

    Public Sub ShowFindPanel()
        Call tvLayers.ShowFindPanel()
    End Sub

    'Private Sub pSurveySetupTreeLayers()
    '    tvLayers.UseCellFormatEvents = True
    '    tvLayers.CanExpandGetter = Function(Value As Object)
    '                                   If TypeOf Value Is cLayer Then
    '                                       Return True
    '                                   Else
    '                                       Return False
    '                                   End If
    '                               End Function
    '    'I have to use a special enumeration to get objects that are hiddenindesign...
    '    tvLayers.ParentGetter = Function(Value As Object)
    '                                If TypeOf Value Is cLayer Then
    '                                    Return Nothing
    '                                Else
    '                                    Return DirectCast(Value, cItem).Layer
    '                                End If
    '                            End Function
    '    tvLayers.ChildrenGetter = Function(Value As Object)
    '                                  If TypeOf Value Is cLayer Then
    '                                      Dim oLayer As cLayer = DirectCast(Value, cLayer)
    '                                      Dim oResultItems As List(Of cItem) = New List(Of cItem)
    '                                      For Each oItem As cItem In oLayer.Items
    '                                          If modDesign.GetIfItemMustBeDrawedByCaveAndBranch(oCurrentOptions, oItem, oDesignTools.CurrentCave, oDesignTools.CurrentBranch) Then
    '                                              If Not oItem.FilteredInDesign Then
    '                                                  Call oResultItems.Add(oItem)
    '                                              End If
    '                                          End If
    '                                      Next
    '                                      Return oResultItems
    '                                      'Return DirectCast(Value, cLayer).GetAllVisibleItems(oCurrentOptions, pGetCurrentDesignTools.CurrentCave, pGetCurrentDesignTools.CurrentBranch)
    '                                  Else
    '                                      Return Nothing
    '                                  End If
    '                              End Function
    '    colLayersCaveBranchColor.AspectGetter = Function(Value As Object)
    '                                                Return " "
    '                                            End Function
    '    colLayersHiddenInDesign.HeaderImageKey = "edit"
    '    colLayersHiddenInDesign.ImageIndex = 5
    '    colLayersHiddenInDesign.AspectGetter = Function(Value As Object)
    '                                               If TypeOf Value Is cLayer Then
    '                                                   Return Not DirectCast(Value, cLayer).HiddenInDesign
    '                                               Else
    '                                                   Return Not DirectCast(Value, cItem).HiddenInDesign
    '                                               End If
    '                                           End Function
    '    colLayersHiddenInPreview.HeaderImageKey = "print"
    '    colLayersHiddenInPreview.ImageIndex = 4
    '    colLayersHiddenInPreview.AspectGetter = Function(Value As Object)
    '                                                If TypeOf Value Is cLayer Then
    '                                                    Return Not DirectCast(Value, cLayer).HiddenInPreview
    '                                                Else
    '                                                    Return Not DirectCast(Value, cItem).HiddenInPreview
    '                                                End If
    '                                            End Function

    '    colLayersHiddenInDesign.AspectPutter = Sub(rowObject As Object, newValue As Object)
    '                                               If TypeOf rowObject Is cLayer Then
    '                                                   DirectCast(rowObject, cLayer).HiddenInDesign = Not newValue
    '                                                   Call pMapInvalidate()
    '                                               Else
    '                                                   DirectCast(rowObject, cItem).HiddenInDesign = Not newValue
    '                                                   Call pMapInvalidate()
    '                                               End If
    '                                           End Sub
    '    colLayersHiddenInPreview.AspectPutter = Sub(rowObject As Object, newValue As Object)
    '                                                If TypeOf rowObject Is cLayer Then
    '                                                    DirectCast(rowObject, cLayer).HiddenInPreview = Not newValue
    '                                                    Call pMapInvalidate()
    '                                                Else
    '                                                    DirectCast(rowObject, cItem).HiddenInPreview = Not newValue
    '                                                    Call pMapInvalidate()
    '                                                End If
    '                                            End Sub
    '    'colLayersPreview.IsVisible = bLayersShowItemPreview
    '    colLayersType.Renderer = New TreeListView.TreeRenderer
    '    colLayersType.AspectGetter = Function(Value As Object)
    '                                     If TypeOf Value Is cLayer Then
    '                                         Return DirectCast(Value, cLayer).Type.ToString
    '                                     Else
    '                                         Dim oItem As cItem = DirectCast(Value, cItem)
    '                                         Dim sText As String = oItem.Type.ToString
    '                                         If oItem.HaveText Then
    '                                             Dim oItemText As cIItemText = oItem
    '                                             sText = sText & " " & Chr(34) & oItemText.Text & Chr(34)
    '                                         End If
    '                                         Return sText
    '                                     End If
    '                                 End Function
    '    colLayersType.ImageGetter = Function(Value As Object)
    '                                    If TypeOf Value Is cLayer Then
    '                                        Return oLayerImage
    '                                    Else
    '                                        Dim oItem As cItem = DirectCast(Value, cItem)
    '                                        If oItem.HavePaintProblem Then
    '                                            Return "generic_error"
    '                                        Else
    '                                            Return oItemImage
    '                                        End If
    '                                    End If
    '                                End Function
    '    colLayersName.AspectGetter = Function(Value As Object)
    '                                     If TypeOf Value Is cLayer Then
    '                                         Return DirectCast(Value, cLayer).Name.ToString
    '                                     Else
    '                                         Return DirectCast(Value, cItem).Name
    '                                     End If
    '                                 End Function
    '    colLayersCave.AspectGetter = Function(Value As Object)
    '                                     If TypeOf Value Is cLayer Then
    '                                         Return ""
    '                                     Else
    '                                         Return DirectCast(Value, cItem).Cave
    '                                     End If
    '                                 End Function
    '    colLayersBranch.AspectGetter = Function(Value As Object)
    '                                       If TypeOf Value Is cLayer Then
    '                                           Return ""
    '                                       Else
    '                                           Return DirectCast(Value, cItem).Branch
    '                                       End If
    '                                   End Function
    '    Call tvLayers.RebuildColumns()
    'End Sub

    'Private Class cTreeView
    '    Implements XtraTreeList.TreeList.IVirtualTreeListData

    '    Public Sub VirtualTreeGetChildNodes(info As VirtualTreeGetChildNodesInfo) Implements TreeList.IVirtualTreeListData.VirtualTreeGetChildNodes
    '        info.Children = DirectCast(info.Node, cLayer).Items.ToList
    '    End Sub

    '    Public Sub VirtualTreeGetCellValue(info As VirtualTreeGetCellValueInfo) Implements TreeList.IVirtualTreeListData.VirtualTreeGetCellValue
    '        If TypeOf info.Node Is cLayer Then
    '            Dim oLayer As cLayer = info.Node
    '            Select Case info.Column.FieldName.ToLower
    '                Case "name"
    '                    info.CellData = oLayer.Name
    '            End Select
    '        Else
    '            Dim oItem As cItem = info.Node
    '            Select Case info.Column.FieldName.ToLower
    '                Case "name"
    '                    info.CellData = oItem.Name
    '            End Select
    '        End If
    '    End Sub

    '    Public Sub VirtualTreeSetCellValue(info As VirtualTreeSetCellValueInfo) Implements TreeList.IVirtualTreeListData.VirtualTreeSetCellValue
    '        Throw New NotImplementedException()
    '    End Sub
    'End Class

    Public Event OnMapInvalidate(Sender As Object, e As EventArgs)

    'Private Sub tvLayers_KeyUp(sender As Object, e As KeyEventArgs)
    '    If e.KeyCode = Keys.H Then
    '        If e.Shift Then
    '            Dim oSelectedItem As Object = tvLayers.SelectedObject
    '            If TypeOf oSelectedItem Is cItem Then
    '                Dim oItem As cItem = oSelectedItem
    '                oItem.HiddenInPreview = Not oItem.HiddenInPreview
    '            ElseIf TypeOf oSelectedItem Is cLayer Then
    '                Dim oLayer As cLayer = oSelectedItem
    '                oLayer.HiddenInPreview = Not oLayer.HiddenInPreview
    '            End If
    '        Else
    '            Dim oSelectedItem As Object = tvLayers.SelectedObject
    '            If TypeOf oSelectedItem Is cItem Then
    '                Dim oItem As cItem = oSelectedItem
    '                oItem.HiddenInDesign = Not oItem.HiddenInDesign
    '            ElseIf TypeOf oSelectedItem Is cLayer Then
    '                Dim oLayer As cLayer = oSelectedItem
    '                oLayer.HiddenInDesign = Not oLayer.HiddenInDesign
    '            End If
    '        End If
    '        Call tvLayers.RefreshSelectedObjects()
    '        Call pMapInvalidate()
    '    End If
    'End Sub

    Public Sub pMapInvalidate()
        RaiseEvent OnMapInvalidate(Me, EventArgs.Empty)
    End Sub

    Public Sub SetDesign(Design As cDesign, DesignTools As Helper.Editor.cEditDesignTools, CurrentOptions As cOptionsDesign)
        oDesign = Design
        oDesignTools = DesignTools
        oCurrentOptions = CurrentOptions
        Call pSurveyLoadTreeLayers()
    End Sub

    Private WithEvents oLayer0 As BindingList(Of cItem)
    Private WithEvents oLayer1 As BindingList(Of cItem)
    Private WithEvents oLayer2 As BindingList(Of cItem)
    Private WithEvents oLayer3 As BindingList(Of cItem)
    Private WithEvents oLayer4 As BindingList(Of cItem)
    Private WithEvents oLayer5 As BindingList(Of cItem)
    Private WithEvents oLayer6 As BindingList(Of cItem)

    Private Delegate Sub pSurveyLoadTreeLayersDelegate()
    Private Sub pSurveyLoadTreeLayers()
        If InvokeRequired Then
            Call Me.BeginInvoke(New pSurveyLoadTreeLayersDelegate(AddressOf pSurveyLoadTreeLayers))
        Else
            Call tvLayers.BeginUpdate()
            If oDesign Is Nothing Then
                oLayer0 = Nothing
                oLayer1 = Nothing
                oLayer2 = Nothing
                oLayer3 = Nothing
                oLayer4 = Nothing
                oLayer5 = Nothing
                oLayer6 = Nothing
                tvLayers.DataSource = Nothing
            Else
                Dim oLayers As BindingList(Of cLayer) = oDesign.Layers.List
                oLayer0 = oLayers(cLayers.LayerTypeEnum.Base).ItemsList
                oLayer1 = oLayers(cLayers.LayerTypeEnum.Soil).ItemsList
                oLayer2 = oLayers(cLayers.LayerTypeEnum.WaterAndFloorMorphologies).ItemsList
                oLayer3 = oLayers(cLayers.LayerTypeEnum.RocksAndConcretion).ItemsList
                oLayer4 = oLayers(cLayers.LayerTypeEnum.CeilingMorphologies).ItemsList
                oLayer5 = oLayers(cLayers.LayerTypeEnum.Borders).ItemsList
                oLayer6 = oLayers(cLayers.LayerTypeEnum.Signs).ItemsList
                tvLayers.DataSource = oLayers
            End If
            Call tvLayers.EndUpdate()
            'Call tvLayers.ExpandAll()
        End If
    End Sub

    Public Sub SetSurvey(Survey As cSurveyPC.cSurvey.cSurvey)
        oSurvey = Survey
        oDefaultOptions = oSurvey.Options("_design.plan").DefaultOptions
        Call SetDesign(Nothing, Nothing, Nothing)
    End Sub

    'Private Sub tvLayers_FormatCell(sender As Object, e As FormatCellEventArgs)
    '    If TypeOf e.Item.RowObject Is cItem Then
    '        If e.Column Is colLayersCaveBranchColor Then
    '            Dim oItem As cItem = e.Item.RowObject
    '            e.SubItem.BackColor = oSurvey.Properties.CaveInfos.GetColor(oItem, Color.LightGray)
    '        ElseIf e.Column Is colLayersPreview Then
    '            If bLayersShowItemPreview Then
    '                Dim oItem As cItem = e.Item.RowObject
    '                Dim oItemThumb As Image = oItem.GetThumbnailImage(oDefaultOptions, cItem.PaintOptionsEnum.None, False, 16, 16)
    '                If Not oItemThumb Is Nothing Then
    '                    e.SubItem.ImageSelector = oItemThumb
    '                End If
    '            End If
    '        End If
    '    End If
    'End Sub

    'Private Sub tvLayers_SelectionChanged(sender As Object, e As EventArgs)
    '    Dim oSelectedItem As Object = tvLayers.SelectedObject
    '    If TypeOf oSelectedItem Is cItem Then
    '        Dim oItem As cItem = oSelectedItem
    '        If oItem.Deleted Then
    '            'piclayerItemPreview.Image = imlLayers.Images("cross")
    '            'lbLayerItemTitle.Text = GetLocalizedString("main.textpart5")
    '            'lbLayerItemCaption.Text = ""
    '            btnObjectProperty.Enabled = False
    '            btnObjectSelect.Enabled = False
    '        Else
    '            Dim oItemThumb As Image = oItem.GetThumbnailImage(oDefaultOptions, cItem.PaintOptionsEnum.None, False, 48, 48)
    '            'If oItemThumb Is Nothing Then
    '            '    piclayerItemPreview.Image = imlLayers.Images("generic_error")
    '            'Else
    '            '    piclayerItemPreview.Image = oItemThumb
    '            'End If
    '            'lbLayerItemTitle.Text = tvLayers.SelectedItem.Text
    '            'Dim oBounds As RectangleF = oItem.GetBounds
    '            'lbLayerItemCaption.Text = "x: " & Strings.Format(oBounds.Left, "0.00") & " y: " & Strings.Format(oBounds.Top, "0.00") & "" & vbCrLf & "w: " & Strings.Format(oBounds.Width, "0.00") & " h: " & Strings.Format(oBounds.Height, "0.00")
    '            btnObjectProperty.Enabled = True
    '            btnObjectSelect.Enabled = True
    '        End If
    '    ElseIf TypeOf oSelectedItem Is cLayer Then
    '        'piclayerItemPreview.Image = Nothing
    '        'lbLayerItemTitle.Text = tvLayers.SelectedItem.Text
    '        'lbLayerItemCaption.Text = ""
    '        btnObjectProperty.Enabled = False
    '        btnObjectSelect.Enabled = True
    '    Else
    '        'piclayerItemPreview.Image = Nothing
    '        'lbLayerItemTitle.Text = ""
    '        'lbLayerItemCaption.Text = ""
    '        btnObjectProperty.Enabled = False
    '        btnObjectSelect.Enabled = False
    '    End If
    'End Sub

    Public Class cItemSelectedEventargs
        Inherits EventArgs
        Private oItem As cItem

        Public Sub New(Item As cItem)
            oItem = Item
        End Sub

        Public ReadOnly Property Item As cItem
            Get
                Return oItem
            End Get
        End Property
    End Class

    Public Event OnItemSelected(Sender As Object, e As cItemSelectedEventargs)

    Public Class cLayerSelectedEventargs
        Inherits EventArgs
        Private oLayer As cLayer

        Public Sub New(Layer As cLayer)
            oLayer = Layer
        End Sub

        Public ReadOnly Property Layer As cLayer
            Get
                Return oLayer
            End Get
        End Property
    End Class

    Public Event OnLayerSelected(Sender As Object, e As cLayerSelectedEventargs)

    Public Event OnShowProperties(Sender As Object, e As EventArgs)

    Private Sub pShowProperties()
        RaiseEvent OnShowProperties(Me, EventArgs.Empty)
    End Sub

    Private Sub pSelectObject()
        Dim oSelectedItem As Object = pGetFocusedElement()
        If TypeOf oSelectedItem Is cItem Then
            Dim oItem As cItem = oSelectedItem
            If Not oItem.Deleted Then
                RaiseEvent OnItemSelected(Me, New cItemSelectedEventargs(oItem))
            End If
        ElseIf TypeOf oSelectedItem Is cLayer Then
            Dim oLayer As cLayer = oSelectedItem
            RaiseEvent OnLayerSelected(Me, New cLayerSelectedEventargs(oLayer))
        End If
    End Sub

    Private Sub btnRefresh_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles btnRefresh.ItemClick
        Call pSurveyLoadTreeLayers()
    End Sub

    Private Sub btnObjectSelect_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles btnObjectSelect.ItemClick
        Call pSelectObject()
    End Sub

    Private Sub btnObjectProperty_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles btnObjectProperty.ItemClick
        Call pSelectObject()
        Call pShowProperties()
    End Sub

    Private Sub btnLayerSync_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles btnLayerSync.ItemClick
        If Not IsNothing(oDesign) Then
            If Not IsNothing(oDesignTools.CurrentItem) Then
                Call tvLayers.SetFocusedObject(oDesignTools.CurrentItem)
                'Dim oFoundNode As TreeListNode = tvLayers.FindNode(Function(onode)
                '                                                       Return tvLayers.GetRow(onode.Id) Is oDesignTools.CurrentItem
                '                                                   End Function)
                'If Not oFoundNode Is Nothing Then
                '    tvLayers.MakeNodeVisible(oFoundNode)
                '    tvLayers.FocusedNode = oFoundNode
                'End If
                'Call tvLayers.Reveal(oDesignTools.CurrentItem, True)
                'Call tvLayers.EnsureModelVisible(tvLayers.SelectedObject)
            End If
        End If
    End Sub

    Private Sub tvLayers_CustomUnboundColumnData(sender As Object, e As TreeListCustomColumnDataEventArgs) Handles tvLayers.CustomUnboundColumnData
        If Not e.Row Is Nothing Then
            If e.IsGetData Then
                Select Case e.Column.Name
                    Case "colTreeLayersType"
                        If TypeOf e.Row Is cLayer Then
                            e.Value = DirectCast(e.Row, cLayer).Type.ToString
                        Else
                            Dim oItem As cItem = DirectCast(e.Row, cItem)
                            Dim sText As String = oItem.Type.ToString
                            If oItem.HaveText Then
                                Dim oItemText As cIItemText = oItem
                                sText = sText & " " & Chr(34) & oItemText.Text & Chr(34)
                            End If
                            e.Value = sText
                        End If
                    Case "colTreeLayersName"
                        If TypeOf e.Row Is cLayer Then
                            e.Value = ""
                        Else
                            Dim oItem As cItem = DirectCast(e.Row, cItem)
                            e.Value = oItem.Name
                        End If
                    Case "colTreeLayersCave"
                        If TypeOf e.Row Is cLayer Then
                            e.Value = ""
                        Else
                            Dim oItem As cItem = DirectCast(e.Row, cItem)
                            e.Value = oItem.Cave
                        End If
                    Case "colTreeLayersBranch"
                        If TypeOf e.Row Is cLayer Then
                            e.Value = ""
                        Else
                            Dim oItem As cItem = DirectCast(e.Row, cItem)
                            e.Value = oItem.Branch
                        End If
                    Case "colTreeLayersHiddenInDesign"
                        If TypeOf e.Row Is cLayer Then
                            e.Value = Not DirectCast(e.Row, cLayer).HiddenInDesign
                        Else
                            e.Value = Not DirectCast(e.Row, cItem).HiddenInDesign
                        End If
                    Case "colTreeLayersHiddenInPreview"
                        If TypeOf e.Row Is cLayer Then
                            e.Value = Not DirectCast(e.Row, cLayer).HiddenInPreview
                        Else
                            e.Value = Not DirectCast(e.Row, cItem).HiddenInPreview
                        End If
                End Select
            Else
                Select Case e.Column.Name
                    Case "colTreeLayersHiddenInDesign"
                        If TypeOf e.Row Is cLayer Then
                            DirectCast(e.Row, cLayer).HiddenInDesign = Not e.Value
                            RaiseEvent OnMapInvalidate(Me, EventArgs.Empty)
                        Else
                            DirectCast(e.Row, cItem).HiddenInDesign = Not e.Value
                            RaiseEvent OnMapInvalidate(Me, EventArgs.Empty)
                        End If
                    Case "colTreeLayersHiddenInPreview"
                        If TypeOf e.Row Is cLayer Then
                            DirectCast(e.Row, cLayer).HiddenInPreview = Not e.Value
                            RaiseEvent OnMapInvalidate(Me, EventArgs.Empty)
                        Else
                            DirectCast(e.Row, cItem).HiddenInPreview = Not e.Value
                            RaiseEvent OnMapInvalidate(Me, EventArgs.Empty)
                        End If
                End Select
            End If
        End If
    End Sub

    Private Sub tvLayers_NodeCellStyle(sender As Object, e As GetCustomNodeCellStyleEventArgs) Handles tvLayers.NodeCellStyle
        If e.Column.Name = "colTreeLayersCaveBranchColor" Then
            Dim oElement As Object = tvLayers.GetRow(e.Node.Id)
            If TypeOf oElement Is cItem Then
                Dim oItem As cItem = oElement
                e.Appearance.BackColor = oSurvey.Properties.CaveInfos.GetColor(oItem, Color.LightGray)
            End If
        End If
    End Sub

    Private Sub tvLayers_GetSelectImage(sender As Object, e As GetSelectImageEventArgs) Handles tvLayers.GetSelectImage
        Dim oElement As Object = tvLayers.GetRow(e.Node.Id)
        If TypeOf oElement Is cLayer Then
            e.NodeImageIndex = 0
        Else
            e.NodeImageIndex = 1
        End If
    End Sub

    Private Function pGetFocusedElement() As Object
        If tvLayers.FocusedNode Is Nothing Then
            Return Nothing
        Else
            Return tvLayers.GetRow(tvLayers.FocusedNode.Id)
        End If
    End Function

    Private Sub tvLayers_FocusedNodeChanged(sender As Object, e As FocusedNodeChangedEventArgs) Handles tvLayers.FocusedNodeChanged
        Dim oElement As Object = pGetFocusedElement()

        If TypeOf oElement Is cItem Then
            Dim oItem As cItem = oElement
            If oItem.Deleted Then
                'piclayerItemPreview.Image = imlLayers.Images("cross")
                'lbLayerItemTitle.Text = GetLocalizedString("main.textpart5")
                'lbLayerItemCaption.Text = ""
                btnObjectProperty.Enabled = False
                btnObjectSelect.Enabled = False
            Else
                Dim oItemThumb As Image = oItem.GetThumbnailImage(oDefaultOptions, cItem.PaintOptionsEnum.None, False, 48, 48)
                'If oItemThumb Is Nothing Then
                '    piclayerItemPreview.Image = imlLayers.Images("generic_error")
                'Else
                '    piclayerItemPreview.Image = oItemThumb
                'End If
                'lbLayerItemTitle.Text = tvLayers.SelectedItem.Text
                'Dim oBounds As RectangleF = oItem.GetBounds
                'lbLayerItemCaption.Text = "x: " & Strings.Format(oBounds.Left, "0.00") & " y: " & Strings.Format(oBounds.Top, "0.00") & "" & vbCrLf & "w: " & Strings.Format(oBounds.Width, "0.00") & " h: " & Strings.Format(oBounds.Height, "0.00")
                btnObjectProperty.Enabled = True
                btnObjectSelect.Enabled = True
            End If
        ElseIf TypeOf oElement Is cLayer Then
            'piclayerItemPreview.Image = Nothing
            'lbLayerItemTitle.Text = tvLayers.SelectedItem.Text
            'lbLayerItemCaption.Text = ""
            btnObjectProperty.Enabled = False
            btnObjectSelect.Enabled = True
        Else
            'piclayerItemPreview.Image = Nothing
            'lbLayerItemTitle.Text = ""
            'lbLayerItemCaption.Text = ""
            btnObjectProperty.Enabled = False
            btnObjectSelect.Enabled = False
        End If
    End Sub

    Private Sub tvLayers_PopupMenuShowing(sender As Object, e As XtraTreeList.PopupMenuShowingEventArgs) Handles tvLayers.PopupMenuShowing
        If e.HitInfo.InRowCell Then
            e.Allow = False
            Call mnuContext.ShowPopup(tvLayers.PointToScreen(e.Point))
        End If
    End Sub

    Private Sub tvLayers_DoubleClick(sender As Object, e As EventArgs) Handles tvLayers.DoubleClick
        Call pSelectObject()
    End Sub

    Private Sub tvLayers_CustomRowFilter(sender As Object, e As CustomRowFilterEventArgs) Handles tvLayers.CustomRowFilter
        If TypeOf e.Row Is cItem Then
            Dim oItem As cItem = DirectCast(e.Row, cItem)
            If modDesign.GetIfItemMustBeDrawedByCaveAndBranch(oCurrentOptions, oItem, oDesignTools.CurrentCave, oDesignTools.CurrentBranch) Then
                e.Visible = Not oItem.FilteredInDesign
            Else
                e.Visible = False
            End If
            e.Handled = True
        End If
    End Sub

    Private Delegate Sub RefreshDataDelegate()
    Public Sub RefreshData()
        If InvokeRequired Then
            Call Invoke(New RefreshDataDelegate(AddressOf RefreshData))
        Else
            Call tvLayers.RefreshDataSource()
        End If
    End Sub

    Private bDisableFilterItemEvent As Boolean

    Private Sub pFilterApply()
        If Not bDisableFilterItemEvent Then
            bDisableFilterItemEvent = True
            If oDesignTools.IsFiltered Then
                If Not btnFiltered.Checked Then btnFiltered.Checked = True
                If btnWhiteboard.Checked <> oDesignTools.FilterWhiteBoard Then btnWhiteboard.Checked = oDesignTools.FilterWhiteBoard
                btnWhiteboard.Enabled = btnFiltered.Checked
                If btnInvertFilter.Checked <> oDesignTools.FilterReversed Then btnInvertFilter.Checked = oDesignTools.FilterReversed
                btnInvertFilter.Enabled = btnFiltered.Checked
            Else
                If btnFiltered.Checked Then btnFiltered.Checked = False
                If btnWhiteboard.Checked Then btnWhiteboard.Checked = False
                btnWhiteboard.Enabled = False
                btnInvertFilter.Enabled = False
            End If
            bDisableFilterItemEvent = False
        End If
        Call RefreshData()
    End Sub

    Private Sub oDesignTools_OnFilterApplied(Sender As Object, ToolEventArgs As cEditDesignTools.cFilterEventArgs) Handles oDesignTools.OnFilterApplied
        Call pFilterApply
    End Sub

    Private Sub oDesignTools_OnFilterRemoved(Sender As Object, ToolEventArgs As cEditDesignTools.cFilterEventArgs) Handles oDesignTools.OnFilterRemoved
        Call pFilterApply()
    End Sub

    Public Sub ExpandAll()
        Call tvLayers.ExpandAll()
    End Sub

    Public Sub CollapseAll()
        Call tvLayers.CollapseAll()
    End Sub

    Public Event OnFilterEdit(Sender As Object, e As EventArgs)

    Private Sub btnFilterEdit_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles btnFilterEdit.ItemClick
        RaiseEvent OnFilterEdit(Me, EventArgs.Empty)
    End Sub

    Private Sub btnFiltered_CheckedChanged(sender As Object, e As XtraBars.ItemClickEventArgs) Handles btnFiltered.CheckedChanged
        If Not bDisableFilterItemEvent Then
            Call oDesignTools.FilterToggle()
        End If
    End Sub

    Private Sub btnWhiteboard_CheckedChanged(sender As Object, e As XtraBars.ItemClickEventArgs) Handles btnWhiteboard.CheckedChanged
        If Not bDisableFilterItemEvent Then
            oDesignTools.FilterWhiteBoard = btnWhiteboard.Checked
        End If
    End Sub

    Private Sub btnInvertFilter_CheckedChanged(sender As Object, e As XtraBars.ItemClickEventArgs) Handles btnInvertFilter.CheckedChanged
        If Not bDisableFilterItemEvent Then
            oDesignTools.FilterReversed = btnInvertFilter.Checked
        End If
    End Sub

    Private Sub btnExpandAll_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnExpandAll.ItemClick
        Call tvLayers.ExpandAll()
    End Sub

    Private Sub btnCollapseAll_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnCollapseAll.ItemClick
        Call tvLayers.CollapseAll()
    End Sub

    Private Sub oLayer_ListChanged(sender As Object, e As ListChangedEventArgs) Handles oLayer0.ListChanged, oLayer1.ListChanged, oLayer2.ListChanged, oLayer3.ListChanged, oLayer4.ListChanged, oLayer5.ListChanged, oLayer6.ListChanged
        Task.Delay(1000).ContinueWith(Sub()
                                          Call RefreshData()
                                      End Sub)
    End Sub

    Private Sub cDockLevels_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Visible Then
            'pSurveyLoadTreeLayers() '
            Call tvLayers.RefreshDataSource()
            Call tvLayers.Invalidate()
        End If
    End Sub
End Class