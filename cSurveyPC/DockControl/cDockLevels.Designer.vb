<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cDockLevels
    Inherits DevExpress.XtraEditors.XtraUserControl

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cDockLevels))
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.BarMain = New DevExpress.XtraBars.Bar()
        Me.btnFilterEdit = New DevExpress.XtraBars.BarButtonItem()
        Me.btnFiltered = New DevExpress.XtraBars.BarCheckItem()
        Me.btnWhiteboard = New DevExpress.XtraBars.BarCheckItem()
        Me.btnInvertFilter = New DevExpress.XtraBars.BarCheckItem()
        Me.btnLayerSync = New DevExpress.XtraBars.BarButtonItem()
        Me.btnObjectProperty = New DevExpress.XtraBars.BarButtonItem()
        Me.btnObjectSelect = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRefresh = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.btnExpandAll = New DevExpress.XtraBars.BarButtonItem()
        Me.btnCollapseAll = New DevExpress.XtraBars.BarButtonItem()
        Me.mnuContext = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.iml = New DevExpress.Utils.SvgImageCollection(Me.components)
        Me.tvLayers = New DevExpress.XtraTreeList.TreeList()
        Me.colTreeLayersType = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colTreeLayersCaveBranchColor = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colTreeLayersHiddenInPreview = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colTreeLayersHiddenInDesign = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colTreeLayersName = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colTreeLayersCave = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colTreeLayersBranch = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mnuContext, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.iml, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tvLayers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarManager
        '
        Me.BarManager.AllowCustomization = False
        Me.BarManager.AllowQuickCustomization = False
        Me.BarManager.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.BarMain})
        Me.BarManager.DockControls.Add(Me.barDockControlTop)
        Me.BarManager.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager.DockControls.Add(Me.barDockControlRight)
        Me.BarManager.Form = Me
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnFilterEdit, Me.btnRefresh, Me.btnFiltered, Me.btnWhiteboard, Me.btnInvertFilter, Me.btnLayerSync, Me.btnObjectProperty, Me.btnObjectSelect, Me.btnExpandAll, Me.btnCollapseAll})
        Me.BarManager.MaxItemId = 11
        '
        'BarMain
        '
        Me.BarMain.BarName = "Tools"
        Me.BarMain.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top
        Me.BarMain.DockCol = 0
        Me.BarMain.DockRow = 0
        Me.BarMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.BarMain.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnFilterEdit), New DevExpress.XtraBars.LinkPersistInfo(Me.btnFiltered), New DevExpress.XtraBars.LinkPersistInfo(Me.btnWhiteboard), New DevExpress.XtraBars.LinkPersistInfo(Me.btnInvertFilter), New DevExpress.XtraBars.LinkPersistInfo(Me.btnLayerSync, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnObjectProperty, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnObjectSelect), New DevExpress.XtraBars.LinkPersistInfo(Me.btnRefresh, True)})
        Me.BarMain.OptionsBar.AllowQuickCustomization = False
        Me.BarMain.OptionsBar.DisableClose = True
        Me.BarMain.OptionsBar.DisableCustomization = True
        Me.BarMain.OptionsBar.DrawDragBorder = False
        Me.BarMain.OptionsBar.UseWholeRow = True
        resources.ApplyResources(Me.BarMain, "BarMain")
        '
        'btnFilterEdit
        '
        resources.ApplyResources(Me.btnFilterEdit, "btnFilterEdit")
        Me.btnFilterEdit.Id = 0
        Me.btnFilterEdit.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.editfilter
        Me.btnFilterEdit.Name = "btnFilterEdit"
        '
        'btnFiltered
        '
        resources.ApplyResources(Me.btnFiltered, "btnFiltered")
        Me.btnFiltered.Id = 3
        Me.btnFiltered.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.filter1
        Me.btnFiltered.Name = "btnFiltered"
        '
        'btnWhiteboard
        '
        resources.ApplyResources(Me.btnWhiteboard, "btnWhiteboard")
        Me.btnWhiteboard.Enabled = False
        Me.btnWhiteboard.Id = 4
        Me.btnWhiteboard.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.whiteboard
        Me.btnWhiteboard.Name = "btnWhiteboard"
        '
        'btnInvertFilter
        '
        resources.ApplyResources(Me.btnInvertFilter, "btnInvertFilter")
        Me.btnInvertFilter.Enabled = False
        Me.btnInvertFilter.Id = 5
        Me.btnInvertFilter.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.invertfilter
        Me.btnInvertFilter.Name = "btnInvertFilter"
        '
        'btnLayerSync
        '
        resources.ApplyResources(Me.btnLayerSync, "btnLayerSync")
        Me.btnLayerSync.Id = 6
        Me.btnLayerSync.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.productquickcomparisons
        Me.btnLayerSync.Name = "btnLayerSync"
        '
        'btnObjectProperty
        '
        resources.ApplyResources(Me.btnObjectProperty, "btnObjectProperty")
        Me.btnObjectProperty.Enabled = False
        Me.btnObjectProperty.Id = 7
        Me.btnObjectProperty.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.propertiespanel
        Me.btnObjectProperty.Name = "btnObjectProperty"
        '
        'btnObjectSelect
        '
        resources.ApplyResources(Me.btnObjectSelect, "btnObjectSelect")
        Me.btnObjectSelect.Enabled = False
        Me.btnObjectSelect.Id = 8
        Me.btnObjectSelect.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources._select
        Me.btnObjectSelect.Name = "btnObjectSelect"
        '
        'btnRefresh
        '
        resources.ApplyResources(Me.btnRefresh, "btnRefresh")
        Me.btnRefresh.Id = 2
        Me.btnRefresh.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.actions_refresh
        Me.btnRefresh.Name = "btnRefresh"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        resources.ApplyResources(Me.barDockControlTop, "barDockControlTop")
        Me.barDockControlTop.Manager = Me.BarManager
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        resources.ApplyResources(Me.barDockControlBottom, "barDockControlBottom")
        Me.barDockControlBottom.Manager = Me.BarManager
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        resources.ApplyResources(Me.barDockControlLeft, "barDockControlLeft")
        Me.barDockControlLeft.Manager = Me.BarManager
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        resources.ApplyResources(Me.barDockControlRight, "barDockControlRight")
        Me.barDockControlRight.Manager = Me.BarManager
        '
        'btnExpandAll
        '
        resources.ApplyResources(Me.btnExpandAll, "btnExpandAll")
        Me.btnExpandAll.Id = 9
        Me.btnExpandAll.Name = "btnExpandAll"
        '
        'btnCollapseAll
        '
        resources.ApplyResources(Me.btnCollapseAll, "btnCollapseAll")
        Me.btnCollapseAll.Id = 10
        Me.btnCollapseAll.Name = "btnCollapseAll"
        '
        'mnuContext
        '
        Me.mnuContext.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnExpandAll), New DevExpress.XtraBars.LinkPersistInfo(Me.btnCollapseAll), New DevExpress.XtraBars.LinkPersistInfo(Me.btnFilterEdit, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnFiltered), New DevExpress.XtraBars.LinkPersistInfo(Me.btnObjectProperty, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnObjectSelect), New DevExpress.XtraBars.LinkPersistInfo(Me.btnRefresh, True)})
        Me.mnuContext.Manager = Me.BarManager
        Me.mnuContext.Name = "mnuContext"
        '
        'iml
        '
        Me.iml.Add("layer", CType(resources.GetObject("iml.layer"), DevExpress.Utils.Svg.SvgImage))
        Me.iml.Add("item", CType(resources.GetObject("iml.item"), DevExpress.Utils.Svg.SvgImage))
        '
        'tvLayers
        '
        Me.tvLayers.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.tvLayers.ChildListFieldName = "ItemsList"
        Me.tvLayers.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.colTreeLayersType, Me.colTreeLayersCaveBranchColor, Me.colTreeLayersHiddenInPreview, Me.colTreeLayersHiddenInDesign, Me.colTreeLayersName, Me.colTreeLayersCave, Me.colTreeLayersBranch})
        resources.ApplyResources(Me.tvLayers, "tvLayers")
        Me.tvLayers.MenuManager = Me.BarManager
        Me.tvLayers.MinWidth = 16
        Me.tvLayers.Name = "tvLayers"
        Me.tvLayers.OptionsBehavior.PopulateServiceColumns = True
        Me.tvLayers.OptionsCustomization.AllowColumnMoving = False
        Me.tvLayers.OptionsView.AutoWidth = False
        Me.tvLayers.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFullFocus
        Me.tvLayers.OptionsView.ShowHorzLines = False
        Me.tvLayers.OptionsView.ShowIndicator = False
        Me.tvLayers.OptionsView.ShowVertLines = False
        Me.tvLayers.SelectImageList = Me.iml
        '
        'colTreeLayersType
        '
        resources.ApplyResources(Me.colTreeLayersType, "colTreeLayersType")
        Me.colTreeLayersType.FieldName = "2"
        Me.colTreeLayersType.Name = "colTreeLayersType"
        Me.colTreeLayersType.OptionsColumn.AllowEdit = False
        Me.colTreeLayersType.OptionsColumn.ReadOnly = True
        Me.colTreeLayersType.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.[String]
        '
        'colTreeLayersCaveBranchColor
        '
        resources.ApplyResources(Me.colTreeLayersCaveBranchColor, "colTreeLayersCaveBranchColor")
        Me.colTreeLayersCaveBranchColor.FieldName = "1"
        Me.colTreeLayersCaveBranchColor.Name = "colTreeLayersCaveBranchColor"
        Me.colTreeLayersCaveBranchColor.OptionsColumn.AllowEdit = False
        Me.colTreeLayersCaveBranchColor.OptionsColumn.FixedWidth = True
        Me.colTreeLayersCaveBranchColor.OptionsColumn.ReadOnly = True
        Me.colTreeLayersCaveBranchColor.OptionsFilter.AllowAutoFilter = False
        Me.colTreeLayersCaveBranchColor.OptionsFilter.AllowFilter = False
        '
        'colTreeLayersHiddenInPreview
        '
        resources.ApplyResources(Me.colTreeLayersHiddenInPreview, "colTreeLayersHiddenInPreview")
        Me.colTreeLayersHiddenInPreview.FieldName = "3"
        Me.colTreeLayersHiddenInPreview.ImageOptions.Alignment = CType(resources.GetObject("colTreeLayersHiddenInPreview.ImageOptions.Alignment"), System.Drawing.StringAlignment)
        Me.colTreeLayersHiddenInPreview.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.printvisibility
        Me.colTreeLayersHiddenInPreview.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.CommonPalette
        Me.colTreeLayersHiddenInPreview.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.colTreeLayersHiddenInPreview.Name = "colTreeLayersHiddenInPreview"
        Me.colTreeLayersHiddenInPreview.OptionsColumn.FixedWidth = True
        Me.colTreeLayersHiddenInPreview.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.[Boolean]
        '
        'colTreeLayersHiddenInDesign
        '
        resources.ApplyResources(Me.colTreeLayersHiddenInDesign, "colTreeLayersHiddenInDesign")
        Me.colTreeLayersHiddenInDesign.FieldName = "4"
        Me.colTreeLayersHiddenInDesign.ImageOptions.Alignment = CType(resources.GetObject("colTreeLayersHiddenInDesign.ImageOptions.Alignment"), System.Drawing.StringAlignment)
        Me.colTreeLayersHiddenInDesign.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.designervisibility
        Me.colTreeLayersHiddenInDesign.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.colTreeLayersHiddenInDesign.Name = "colTreeLayersHiddenInDesign"
        Me.colTreeLayersHiddenInDesign.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.[Boolean]
        '
        'colTreeLayersName
        '
        resources.ApplyResources(Me.colTreeLayersName, "colTreeLayersName")
        Me.colTreeLayersName.FieldName = "5"
        Me.colTreeLayersName.Name = "colTreeLayersName"
        Me.colTreeLayersName.OptionsColumn.AllowEdit = False
        Me.colTreeLayersName.OptionsColumn.ReadOnly = True
        Me.colTreeLayersName.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.[String]
        '
        'colTreeLayersCave
        '
        resources.ApplyResources(Me.colTreeLayersCave, "colTreeLayersCave")
        Me.colTreeLayersCave.FieldName = "6"
        Me.colTreeLayersCave.Name = "colTreeLayersCave"
        Me.colTreeLayersCave.OptionsColumn.AllowEdit = False
        Me.colTreeLayersCave.OptionsColumn.ReadOnly = True
        Me.colTreeLayersCave.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.[String]
        '
        'colTreeLayersBranch
        '
        resources.ApplyResources(Me.colTreeLayersBranch, "colTreeLayersBranch")
        Me.colTreeLayersBranch.FieldName = "7"
        Me.colTreeLayersBranch.Name = "colTreeLayersBranch"
        Me.colTreeLayersBranch.OptionsColumn.AllowEdit = False
        Me.colTreeLayersBranch.OptionsColumn.ReadOnly = True
        Me.colTreeLayersBranch.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.[String]
        '
        'cDockLevels
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.tvLayers)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "cDockLevels"
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mnuContext, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.iml, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tvLayers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents BarMain As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents btnFilterEdit As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuContext As DevExpress.XtraBars.PopupMenu
    Friend WithEvents btnRefresh As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnFiltered As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents btnWhiteboard As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents btnInvertFilter As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents btnLayerSync As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnObjectProperty As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnObjectSelect As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents iml As DevExpress.Utils.SvgImageCollection
    Friend WithEvents tvLayers As DevExpress.XtraTreeList.TreeList
    Friend WithEvents colTreeLayersName As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colTreeLayersCave As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colTreeLayersBranch As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colTreeLayersType As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colTreeLayersHiddenInPreview As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colTreeLayersHiddenInDesign As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colTreeLayersCaveBranchColor As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents btnExpandAll As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnCollapseAll As DevExpress.XtraBars.BarButtonItem
End Class
