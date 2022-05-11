<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cLinkedSurveySelectorControl
    Inherits DevExpress.XtraEditors.XtraUserControl

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cLinkedSurveySelectorControl))
        Me.iml = New DevExpress.Utils.SvgImageCollection(Me.components)
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.btnSelectAll = New DevExpress.XtraBars.BarButtonItem()
        Me.btnDeselectAll = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRefresh = New DevExpress.XtraBars.BarButtonItem()
        Me.mnuContext = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.tvLinkedSurveys = New DevExpress.XtraTreeList.TreeList()
        Me.colLinkSelected = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.chkLinkSelected = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.colLinkIcon = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cboLinkIcon = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.colLinkGPS = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cboLinkGPS = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.colLinkName = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colLinkFilename = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        CType(Me.iml, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mnuContext, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tvLinkedSurveys, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkLinkSelected, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboLinkIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboLinkGPS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'iml
        '
        Me.iml.Add("linkedfile", "linkedfile", GetType(cSurveyPC.My.Resources.Resources))
        Me.iml.Add("unlinkedfile", "unlinkedfile", GetType(cSurveyPC.My.Resources.Resources))
        Me.iml.Add("bo_localization", "bo_localization", GetType(cSurveyPC.My.Resources.Resources))
        Me.iml.Add("error2", "error2", GetType(cSurveyPC.My.Resources.Resources))
        '
        'BarManager
        '
        Me.BarManager.DockControls.Add(Me.barDockControlTop)
        Me.BarManager.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager.DockControls.Add(Me.barDockControlRight)
        Me.BarManager.Form = Me
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnSelectAll, Me.btnDeselectAll, Me.btnRefresh})
        Me.BarManager.MaxItemId = 3
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
        'btnSelectAll
        '
        resources.ApplyResources(Me.btnSelectAll, "btnSelectAll")
        Me.btnSelectAll.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left
        Me.btnSelectAll.Id = 0
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'btnDeselectAll
        '
        resources.ApplyResources(Me.btnDeselectAll, "btnDeselectAll")
        Me.btnDeselectAll.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left
        Me.btnDeselectAll.Id = 1
        Me.btnDeselectAll.Name = "btnDeselectAll"
        Me.btnDeselectAll.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'btnRefresh
        '
        resources.ApplyResources(Me.btnRefresh, "btnRefresh")
        Me.btnRefresh.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left
        Me.btnRefresh.Id = 2
        Me.btnRefresh.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.actions_refresh
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'mnuContext
        '
        Me.mnuContext.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnSelectAll), New DevExpress.XtraBars.LinkPersistInfo(Me.btnDeselectAll), New DevExpress.XtraBars.LinkPersistInfo(Me.btnRefresh, True)})
        Me.mnuContext.Manager = Me.BarManager
        Me.mnuContext.Name = "mnuContext"
        '
        'tvLinkedSurveys
        '
        Me.tvLinkedSurveys.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.colLinkSelected, Me.colLinkIcon, Me.colLinkGPS, Me.colLinkName, Me.colLinkFilename})
        resources.ApplyResources(Me.tvLinkedSurveys, "tvLinkedSurveys")
        Me.tvLinkedSurveys.MenuManager = Me.BarManager
        Me.tvLinkedSurveys.Name = "tvLinkedSurveys"
        Me.tvLinkedSurveys.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFullFocus
        Me.tvLinkedSurveys.OptionsView.ShowIndicator = False
        Me.tvLinkedSurveys.OptionsView.ShowRoot = False
        Me.tvLinkedSurveys.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.chkLinkSelected, Me.cboLinkGPS, Me.cboLinkIcon})
        '
        'colLinkSelected
        '
        resources.ApplyResources(Me.colLinkSelected, "colLinkSelected")
        Me.colLinkSelected.ColumnEdit = Me.chkLinkSelected
        Me.colLinkSelected.FieldName = "Selected"
        Me.colLinkSelected.Name = "colLinkSelected"
        Me.colLinkSelected.OptionsColumn.FixedWidth = True
        Me.colLinkSelected.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.[Boolean]
        '
        'chkLinkSelected
        '
        resources.ApplyResources(Me.chkLinkSelected, "chkLinkSelected")
        Me.chkLinkSelected.Name = "chkLinkSelected"
        '
        'colLinkIcon
        '
        resources.ApplyResources(Me.colLinkIcon, "colLinkIcon")
        Me.colLinkIcon.ColumnEdit = Me.cboLinkIcon
        Me.colLinkIcon.FieldName = "IsValid"
        Me.colLinkIcon.Name = "colLinkIcon"
        Me.colLinkIcon.OptionsColumn.AllowEdit = False
        Me.colLinkIcon.OptionsColumn.AllowFocus = False
        Me.colLinkIcon.OptionsColumn.FixedWidth = True
        Me.colLinkIcon.OptionsColumn.ReadOnly = True
        '
        'cboLinkIcon
        '
        resources.ApplyResources(Me.cboLinkIcon, "cboLinkIcon")
        Me.cboLinkIcon.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboLinkIcon.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboLinkIcon.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem(resources.GetString("cboLinkIcon.Items"), CType(resources.GetObject("cboLinkIcon.Items1"), Object), CType(resources.GetObject("cboLinkIcon.Items2"), Integer)), New DevExpress.XtraEditors.Controls.ImageComboBoxItem(resources.GetString("cboLinkIcon.Items3"), CType(resources.GetObject("cboLinkIcon.Items4"), Object), CType(resources.GetObject("cboLinkIcon.Items5"), Integer))})
        Me.cboLinkIcon.Name = "cboLinkIcon"
        Me.cboLinkIcon.SmallImages = Me.iml
        '
        'colLinkGPS
        '
        Me.colLinkGPS.ColumnEdit = Me.cboLinkGPS
        Me.colLinkGPS.FieldName = "IsGeoreferenced"
        Me.colLinkGPS.ImageOptions.Alignment = CType(resources.GetObject("colLinkGPS.ImageOptions.Alignment"), System.Drawing.StringAlignment)
        Me.colLinkGPS.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.bo_localization
        Me.colLinkGPS.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.colLinkGPS, "colLinkGPS")
        Me.colLinkGPS.Name = "colLinkGPS"
        Me.colLinkGPS.OptionsColumn.AllowEdit = False
        Me.colLinkGPS.OptionsColumn.AllowFocus = False
        Me.colLinkGPS.OptionsColumn.FixedWidth = True
        Me.colLinkGPS.OptionsColumn.ReadOnly = True
        '
        'cboLinkGPS
        '
        resources.ApplyResources(Me.cboLinkGPS, "cboLinkGPS")
        Me.cboLinkGPS.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboLinkGPS.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboLinkGPS.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem(resources.GetString("cboLinkGPS.Items"), CType(resources.GetObject("cboLinkGPS.Items1"), Object), CType(resources.GetObject("cboLinkGPS.Items2"), Integer)), New DevExpress.XtraEditors.Controls.ImageComboBoxItem(resources.GetString("cboLinkGPS.Items3"), CType(resources.GetObject("cboLinkGPS.Items4"), Object), CType(resources.GetObject("cboLinkGPS.Items5"), Integer))})
        Me.cboLinkGPS.Name = "cboLinkGPS"
        Me.cboLinkGPS.SmallImages = Me.iml
        '
        'colLinkName
        '
        resources.ApplyResources(Me.colLinkName, "colLinkName")
        Me.colLinkName.FieldName = "Name"
        Me.colLinkName.Name = "colLinkName"
        Me.colLinkName.OptionsColumn.AllowEdit = False
        Me.colLinkName.OptionsColumn.AllowFocus = False
        Me.colLinkName.OptionsColumn.ReadOnly = True
        Me.colLinkName.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.[String]
        '
        'colLinkFilename
        '
        resources.ApplyResources(Me.colLinkFilename, "colLinkFilename")
        Me.colLinkFilename.FieldName = "Filename"
        Me.colLinkFilename.Name = "colLinkFilename"
        Me.colLinkFilename.OptionsColumn.AllowEdit = False
        Me.colLinkFilename.OptionsColumn.AllowFocus = False
        Me.colLinkFilename.OptionsColumn.ReadOnly = True
        Me.colLinkFilename.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.[String]
        '
        'cLinkedSurveySelectorControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tvLinkedSurveys)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "cLinkedSurveySelectorControl"
        CType(Me.iml, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mnuContext, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tvLinkedSurveys, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkLinkSelected, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboLinkIcon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboLinkGPS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents iml As DevExpress.Utils.SvgImageCollection
    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents btnSelectAll As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnDeselectAll As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnRefresh As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuContext As DevExpress.XtraBars.PopupMenu
    Friend WithEvents tvLinkedSurveys As DevExpress.XtraTreeList.TreeList
    Friend WithEvents colLinkSelected As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents chkLinkSelected As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents colLinkIcon As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cboLinkIcon As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents colLinkGPS As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cboLinkGPS As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents colLinkName As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colLinkFilename As DevExpress.XtraTreeList.Columns.TreeListColumn
End Class
