﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHistory
    Inherits cForm

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHistory))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.grdItems = New DevExpress.XtraGrid.GridControl()
        Me.grdItemsView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.coilItemsIcon = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cboItemsIcon = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.svgiml = New DevExpress.Utils.SvgImageCollection(Me.components)
        Me.colItemsName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colItemsSource = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colItemsSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colItemsDateTime = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colItemsUser = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colItemsGroup = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.btnShowLocal = New DevExpress.XtraBars.BarCheckItem()
        Me.btnShowWeb = New DevExpress.XtraBars.BarCheckItem()
        Me.btnSaveTo = New DevExpress.XtraBars.BarSubItem()
        Me.btnAddLocal = New DevExpress.XtraBars.BarButtonItem()
        Me.btnAddWeb = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRestore = New DevExpress.XtraBars.BarButtonItem()
        Me.btnDelete = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRefresh = New DevExpress.XtraBars.BarButtonItem()
        Me.Bar3 = New DevExpress.XtraBars.Bar()
        Me.pnlStatus = New DevExpress.XtraBars.BarStaticItem()
        Me.BarAndDockingController = New DevExpress.XtraBars.BarAndDockingController(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.btnLogClear = New DevExpress.XtraBars.BarButtonItem()
        Me.grdLog = New DevExpress.XtraGrid.GridControl()
        Me.grdLogView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colLogType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cboLogType = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.colLogMessage = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLogDateStamp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.mnuItems = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.mnuLog = New DevExpress.XtraBars.PopupMenu(Me.components)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.grdItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdItemsView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboItemsIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.svgiml, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarAndDockingController, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdLog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdLogView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboLogType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mnuItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mnuLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        resources.ApplyResources(Me.SplitContainer1, "SplitContainer1")
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.grdItems)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.grdLog)
        '
        'grdItems
        '
        resources.ApplyResources(Me.grdItems, "grdItems")
        Me.grdItems.MainView = Me.grdItemsView
        Me.grdItems.MenuManager = Me.BarManager
        Me.grdItems.Name = "grdItems"
        Me.grdItems.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cboItemsIcon})
        Me.grdItems.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdItemsView})
        '
        'grdItemsView
        '
        Me.grdItemsView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.coilItemsIcon, Me.colItemsName, Me.colItemsSource, Me.colItemsSize, Me.colItemsDateTime, Me.colItemsUser, Me.colItemsGroup})
        Me.grdItemsView.GridControl = Me.grdItems
        Me.grdItemsView.GroupCount = 1
        Me.grdItemsView.Name = "grdItemsView"
        Me.grdItemsView.OptionsBehavior.Editable = False
        Me.grdItemsView.OptionsBehavior.ReadOnly = True
        Me.grdItemsView.OptionsFind.FindPanelLocation = DevExpress.XtraGrid.Views.Grid.GridFindPanelLocation.Panel
        Me.grdItemsView.OptionsFind.ShowFindButton = False
        Me.grdItemsView.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colItemsGroup, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'coilItemsIcon
        '
        resources.ApplyResources(Me.coilItemsIcon, "coilItemsIcon")
        Me.coilItemsIcon.ColumnEdit = Me.cboItemsIcon
        Me.coilItemsIcon.FieldName = "ImageIndex"
        Me.coilItemsIcon.MaxWidth = 24
        Me.coilItemsIcon.MinWidth = 24
        Me.coilItemsIcon.Name = "coilItemsIcon"
        Me.coilItemsIcon.OptionsColumn.FixedWidth = True
        '
        'cboItemsIcon
        '
        resources.ApplyResources(Me.cboItemsIcon, "cboItemsIcon")
        Me.cboItemsIcon.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboItemsIcon.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboItemsIcon.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem(resources.GetString("cboItemsIcon.Items"), CType(resources.GetObject("cboItemsIcon.Items1"), Object), CType(resources.GetObject("cboItemsIcon.Items2"), Integer)), New DevExpress.XtraEditors.Controls.ImageComboBoxItem(resources.GetString("cboItemsIcon.Items3"), CType(resources.GetObject("cboItemsIcon.Items4"), Object), CType(resources.GetObject("cboItemsIcon.Items5"), Integer))})
        Me.cboItemsIcon.Name = "cboItemsIcon"
        Me.cboItemsIcon.SmallImages = Me.svgiml
        '
        'svgiml
        '
        Me.svgiml.Add("local", CType(resources.GetObject("svgiml.local"), DevExpress.Utils.Svg.SvgImage))
        Me.svgiml.Add("web", CType(resources.GetObject("svgiml.web"), DevExpress.Utils.Svg.SvgImage))
        Me.svgiml.Add("info", "about", GetType(cSurveyPC.My.Resources.Resources))
        Me.svgiml.Add("warning", "warning", GetType(cSurveyPC.My.Resources.Resources))
        Me.svgiml.Add("error", "error2", GetType(cSurveyPC.My.Resources.Resources))
        '
        'colItemsName
        '
        resources.ApplyResources(Me.colItemsName, "colItemsName")
        Me.colItemsName.FieldName = "Name"
        Me.colItemsName.Name = "colItemsName"
        '
        'colItemsSource
        '
        resources.ApplyResources(Me.colItemsSource, "colItemsSource")
        Me.colItemsSource.FieldName = "Origin"
        Me.colItemsSource.Name = "colItemsSource"
        '
        'colItemsSize
        '
        resources.ApplyResources(Me.colItemsSize, "colItemsSize")
        Me.colItemsSize.DisplayFormat.FormatString = "N"
        Me.colItemsSize.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colItemsSize.FieldName = "Size"
        Me.colItemsSize.Name = "colItemsSize"
        '
        'colItemsDateTime
        '
        resources.ApplyResources(Me.colItemsDateTime, "colItemsDateTime")
        Me.colItemsDateTime.DisplayFormat.FormatString = "G"
        Me.colItemsDateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colItemsDateTime.FieldName = "DateStamp"
        Me.colItemsDateTime.Name = "colItemsDateTime"
        '
        'colItemsUser
        '
        resources.ApplyResources(Me.colItemsUser, "colItemsUser")
        Me.colItemsUser.FieldName = "Username"
        Me.colItemsUser.Name = "colItemsUser"
        '
        'colItemsGroup
        '
        resources.ApplyResources(Me.colItemsGroup, "colItemsGroup")
        Me.colItemsGroup.FieldName = "Group"
        Me.colItemsGroup.Name = "colItemsGroup"
        '
        'BarManager
        '
        Me.BarManager.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar1, Me.Bar3})
        Me.BarManager.Controller = Me.BarAndDockingController
        Me.BarManager.DockControls.Add(Me.barDockControlTop)
        Me.BarManager.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager.DockControls.Add(Me.barDockControlRight)
        Me.BarManager.Form = Me
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.pnlStatus, Me.btnShowLocal, Me.btnShowWeb, Me.btnSaveTo, Me.btnAddLocal, Me.btnAddWeb, Me.btnRestore, Me.btnDelete, Me.btnRefresh, Me.btnLogClear})
        Me.BarManager.MaxItemId = 10
        Me.BarManager.StatusBar = Me.Bar3
        '
        'Bar1
        '
        Me.Bar1.BarName = "Tools"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnShowLocal), New DevExpress.XtraBars.LinkPersistInfo(Me.btnShowWeb), New DevExpress.XtraBars.LinkPersistInfo(Me.btnSaveTo, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnRestore, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnDelete, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnRefresh, True)})
        Me.Bar1.OptionsBar.AllowQuickCustomization = False
        Me.Bar1.OptionsBar.DisableClose = True
        Me.Bar1.OptionsBar.DisableCustomization = True
        Me.Bar1.OptionsBar.DrawDragBorder = False
        Me.Bar1.OptionsBar.UseWholeRow = True
        resources.ApplyResources(Me.Bar1, "Bar1")
        '
        'btnShowLocal
        '
        Me.btnShowLocal.BindableChecked = True
        resources.ApplyResources(Me.btnShowLocal, "btnShowLocal")
        Me.btnShowLocal.Checked = True
        Me.btnShowLocal.Id = 1
        Me.btnShowLocal.Name = "btnShowLocal"
        '
        'btnShowWeb
        '
        Me.btnShowWeb.BindableChecked = True
        resources.ApplyResources(Me.btnShowWeb, "btnShowWeb")
        Me.btnShowWeb.Checked = True
        Me.btnShowWeb.Id = 2
        Me.btnShowWeb.Name = "btnShowWeb"
        '
        'btnSaveTo
        '
        resources.ApplyResources(Me.btnSaveTo, "btnSaveTo")
        Me.btnSaveTo.Id = 3
        Me.btnSaveTo.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.saveas
        Me.btnSaveTo.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnAddLocal), New DevExpress.XtraBars.LinkPersistInfo(Me.btnAddWeb)})
        Me.btnSaveTo.Name = "btnSaveTo"
        Me.btnSaveTo.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'btnAddLocal
        '
        resources.ApplyResources(Me.btnAddLocal, "btnAddLocal")
        Me.btnAddLocal.Id = 4
        Me.btnAddLocal.Name = "btnAddLocal"
        '
        'btnAddWeb
        '
        resources.ApplyResources(Me.btnAddWeb, "btnAddWeb")
        Me.btnAddWeb.Id = 5
        Me.btnAddWeb.Name = "btnAddWeb"
        '
        'btnRestore
        '
        resources.ApplyResources(Me.btnRestore, "btnRestore")
        Me.btnRestore.Id = 6
        Me.btnRestore.Name = "btnRestore"
        '
        'btnDelete
        '
        resources.ApplyResources(Me.btnDelete, "btnDelete")
        Me.btnDelete.Id = 7
        Me.btnDelete.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.delete1
        Me.btnDelete.Name = "btnDelete"
        '
        'btnRefresh
        '
        resources.ApplyResources(Me.btnRefresh, "btnRefresh")
        Me.btnRefresh.Id = 8
        Me.btnRefresh.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.actions_refresh
        Me.btnRefresh.Name = "btnRefresh"
        '
        'Bar3
        '
        Me.Bar3.BarName = "Status bar"
        Me.Bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom
        Me.Bar3.DockCol = 0
        Me.Bar3.DockRow = 0
        Me.Bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
        Me.Bar3.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.pnlStatus)})
        Me.Bar3.OptionsBar.AllowQuickCustomization = False
        Me.Bar3.OptionsBar.DrawDragBorder = False
        Me.Bar3.OptionsBar.UseWholeRow = True
        resources.ApplyResources(Me.Bar3, "Bar3")
        '
        'pnlStatus
        '
        Me.pnlStatus.AutoSize = DevExpress.XtraBars.BarStaticItemSize.Spring
        Me.pnlStatus.Id = 0
        Me.pnlStatus.Name = "pnlStatus"
        '
        'BarAndDockingController
        '
        Me.BarAndDockingController.AppearancesBar.ItemsFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        'btnLogClear
        '
        resources.ApplyResources(Me.btnLogClear, "btnLogClear")
        Me.btnLogClear.Id = 9
        Me.btnLogClear.Name = "btnLogClear"
        '
        'grdLog
        '
        resources.ApplyResources(Me.grdLog, "grdLog")
        Me.grdLog.MainView = Me.grdLogView
        Me.grdLog.MenuManager = Me.BarManager
        Me.grdLog.Name = "grdLog"
        Me.grdLog.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cboLogType})
        Me.grdLog.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdLogView})
        '
        'grdLogView
        '
        Me.grdLogView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colLogType, Me.colLogMessage, Me.colLogDateStamp})
        Me.grdLogView.GridControl = Me.grdLog
        Me.grdLogView.Name = "grdLogView"
        Me.grdLogView.OptionsBehavior.Editable = False
        Me.grdLogView.OptionsBehavior.ReadOnly = True
        Me.grdLogView.OptionsView.ShowGroupPanel = False
        Me.grdLogView.OptionsView.ShowIndicator = False
        '
        'colLogType
        '
        resources.ApplyResources(Me.colLogType, "colLogType")
        Me.colLogType.ColumnEdit = Me.cboLogType
        Me.colLogType.FieldName = "Type"
        Me.colLogType.MaxWidth = 24
        Me.colLogType.MinWidth = 24
        Me.colLogType.Name = "colLogType"
        Me.colLogType.OptionsColumn.FixedWidth = True
        '
        'cboLogType
        '
        resources.ApplyResources(Me.cboLogType, "cboLogType")
        Me.cboLogType.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboLogType.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboLogType.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem(resources.GetString("cboLogType.Items"), resources.GetString("cboLogType.Items1"), CType(resources.GetObject("cboLogType.Items2"), Integer)), New DevExpress.XtraEditors.Controls.ImageComboBoxItem(resources.GetString("cboLogType.Items3"), resources.GetString("cboLogType.Items4"), CType(resources.GetObject("cboLogType.Items5"), Integer)), New DevExpress.XtraEditors.Controls.ImageComboBoxItem(resources.GetString("cboLogType.Items6"), resources.GetString("cboLogType.Items7"), CType(resources.GetObject("cboLogType.Items8"), Integer))})
        Me.cboLogType.Name = "cboLogType"
        Me.cboLogType.SmallImages = Me.svgiml
        '
        'colLogMessage
        '
        resources.ApplyResources(Me.colLogMessage, "colLogMessage")
        Me.colLogMessage.FieldName = "Message"
        Me.colLogMessage.Name = "colLogMessage"
        '
        'colLogDateStamp
        '
        resources.ApplyResources(Me.colLogDateStamp, "colLogDateStamp")
        Me.colLogDateStamp.DisplayFormat.FormatString = "G"
        Me.colLogDateStamp.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colLogDateStamp.FieldName = "DateStamp"
        Me.colLogDateStamp.Name = "colLogDateStamp"
        '
        'mnuItems
        '
        Me.mnuItems.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnRestore), New DevExpress.XtraBars.LinkPersistInfo(Me.btnDelete, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnRefresh, True)})
        Me.mnuItems.Manager = Me.BarManager
        Me.mnuItems.Name = "mnuItems"
        '
        'mnuLog
        '
        Me.mnuLog.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnLogClear)})
        Me.mnuLog.Manager = Me.BarManager
        Me.mnuLog.Name = "mnuLog"
        '
        'frmHistory
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.IconOptions.Icon = CType(resources.GetObject("frmHistory.IconOptions.Icon"), System.Drawing.Icon)
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.time
        Me.Name = "frmHistory"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.grdItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdItemsView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboItemsIcon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.svgiml, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarAndDockingController, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdLog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdLogView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboLogType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mnuItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mnuLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents Bar3 As DevExpress.XtraBars.Bar
    Friend WithEvents pnlStatus As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents btnShowLocal As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents btnShowWeb As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents btnSaveTo As DevExpress.XtraBars.BarSubItem
    Friend WithEvents btnAddLocal As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnAddWeb As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnRestore As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnDelete As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnRefresh As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents svgiml As DevExpress.Utils.SvgImageCollection
    Friend WithEvents mnuItems As DevExpress.XtraBars.PopupMenu
    Friend WithEvents grdItems As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdItemsView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents coilItemsIcon As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colItemsName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colItemsSource As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colItemsSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colItemsDateTime As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colItemsUser As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colItemsGroup As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cboItemsIcon As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents grdLog As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdLogView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colLogMessage As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLogDateStamp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLogType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cboLogType As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents BarAndDockingController As DevExpress.XtraBars.BarAndDockingController
    Friend WithEvents btnLogClear As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuLog As DevExpress.XtraBars.PopupMenu
End Class
