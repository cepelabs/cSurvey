<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cDockLinkedSurveys
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cDockLinkedSurveys))
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barMain = New DevExpress.XtraBars.Bar()
        Me.btnAdd = New DevExpress.XtraBars.BarButtonItem()
        Me.btnUnlink = New DevExpress.XtraBars.BarButtonItem()
        Me.btnOpen = New DevExpress.XtraBars.BarButtonItem()
        Me.btnCalculate = New DevExpress.XtraBars.BarButtonItem()
        Me.mnuCalculate = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.btnCalculateSelected = New DevExpress.XtraBars.BarButtonItem()
        Me.btnCalculateAll = New DevExpress.XtraBars.BarButtonItem()
        Me.btnManageLinks = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRefresh = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.btnUnlinkAll = New DevExpress.XtraBars.BarButtonItem()
        Me.mnuContext = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.TreeList1 = New DevExpress.XtraTreeList.TreeList()
        Me.colLinkIcon = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cboLinkIcon = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.iml = New DevExpress.Utils.SvgImageCollection(Me.components)
        Me.colLinkGPS = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cboLinkGPS = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.colLinkName = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colLinkFilename = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colLinkFolder = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colLinkNote = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colLinkException = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mnuCalculate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mnuContext, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TreeList1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboLinkIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.iml, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboLinkGPS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarManager
        '
        Me.BarManager.AllowCustomization = False
        Me.BarManager.AllowQuickCustomization = False
        Me.BarManager.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.barMain})
        Me.BarManager.DockControls.Add(Me.barDockControlTop)
        Me.BarManager.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager.DockControls.Add(Me.barDockControlRight)
        Me.BarManager.Form = Me
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnAdd, Me.btnUnlink, Me.btnRefresh, Me.btnCalculate, Me.btnCalculateSelected, Me.btnCalculateAll, Me.btnOpen, Me.btnUnlinkAll, Me.btnManageLinks})
        Me.BarManager.MaxItemId = 15
        '
        'barMain
        '
        Me.barMain.BarName = "Tools"
        Me.barMain.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top
        Me.barMain.DockCol = 0
        Me.barMain.DockRow = 0
        Me.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.barMain.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnAdd), New DevExpress.XtraBars.LinkPersistInfo(Me.btnUnlink), New DevExpress.XtraBars.LinkPersistInfo(Me.btnOpen, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnCalculate), New DevExpress.XtraBars.LinkPersistInfo(Me.btnManageLinks), New DevExpress.XtraBars.LinkPersistInfo(Me.btnRefresh, True)})
        Me.barMain.OptionsBar.AllowQuickCustomization = False
        Me.barMain.OptionsBar.DisableClose = True
        Me.barMain.OptionsBar.DisableCustomization = True
        Me.barMain.OptionsBar.DrawDragBorder = False
        Me.barMain.OptionsBar.UseWholeRow = True
        resources.ApplyResources(Me.barMain, "barMain")
        '
        'btnAdd
        '
        resources.ApplyResources(Me.btnAdd, "btnAdd")
        Me.btnAdd.Id = 0
        Me.btnAdd.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.actions_add
        Me.btnAdd.Name = "btnAdd"
        '
        'btnUnlink
        '
        resources.ApplyResources(Me.btnUnlink, "btnUnlink")
        Me.btnUnlink.Enabled = False
        Me.btnUnlink.Id = 1
        Me.btnUnlink.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.delete1
        Me.btnUnlink.Name = "btnUnlink"
        '
        'btnOpen
        '
        resources.ApplyResources(Me.btnOpen, "btnOpen")
        Me.btnOpen.Enabled = False
        Me.btnOpen.Id = 12
        Me.btnOpen.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.open
        Me.btnOpen.Name = "btnOpen"
        '
        'btnCalculate
        '
        Me.btnCalculate.ActAsDropDown = True
        Me.btnCalculate.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown
        resources.ApplyResources(Me.btnCalculate, "btnCalculate")
        Me.btnCalculate.DropDownControl = Me.mnuCalculate
        Me.btnCalculate.Enabled = False
        Me.btnCalculate.Id = 9
        Me.btnCalculate.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.calculatenow
        Me.btnCalculate.Name = "btnCalculate"
        '
        'mnuCalculate
        '
        Me.mnuCalculate.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnCalculateSelected), New DevExpress.XtraBars.LinkPersistInfo(Me.btnCalculateAll)})
        Me.mnuCalculate.Manager = Me.BarManager
        Me.mnuCalculate.Name = "mnuCalculate"
        '
        'btnCalculateSelected
        '
        resources.ApplyResources(Me.btnCalculateSelected, "btnCalculateSelected")
        Me.btnCalculateSelected.Id = 10
        Me.btnCalculateSelected.Name = "btnCalculateSelected"
        '
        'btnCalculateAll
        '
        resources.ApplyResources(Me.btnCalculateAll, "btnCalculateAll")
        Me.btnCalculateAll.Id = 11
        Me.btnCalculateAll.Name = "btnCalculateAll"
        '
        'btnManageLinks
        '
        resources.ApplyResources(Me.btnManageLinks, "btnManageLinks")
        Me.btnManageLinks.Enabled = False
        Me.btnManageLinks.Id = 14
        Me.btnManageLinks.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.linktoprevious
        Me.btnManageLinks.Name = "btnManageLinks"
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
        'btnUnlinkAll
        '
        resources.ApplyResources(Me.btnUnlinkAll, "btnUnlinkAll")
        Me.btnUnlinkAll.Enabled = False
        Me.btnUnlinkAll.Id = 13
        Me.btnUnlinkAll.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.removedataitems
        Me.btnUnlinkAll.Name = "btnUnlinkAll"
        '
        'mnuContext
        '
        Me.mnuContext.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnAdd), New DevExpress.XtraBars.LinkPersistInfo(Me.btnUnlink), New DevExpress.XtraBars.LinkPersistInfo(Me.btnUnlinkAll, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnOpen, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnCalculate), New DevExpress.XtraBars.LinkPersistInfo(Me.btnManageLinks), New DevExpress.XtraBars.LinkPersistInfo(Me.btnRefresh, True)})
        Me.mnuContext.Manager = Me.BarManager
        Me.mnuContext.Name = "mnuContext"
        '
        'TreeList1
        '
        Me.TreeList1.AllowDrop = True
        Me.TreeList1.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.colLinkIcon, Me.colLinkGPS, Me.colLinkName, Me.colLinkFilename, Me.colLinkFolder, Me.colLinkNote, Me.colLinkException})
        resources.ApplyResources(Me.TreeList1, "TreeList1")
        Me.TreeList1.KeyFieldName = "Self"
        Me.TreeList1.MenuManager = Me.BarManager
        Me.TreeList1.Name = "TreeList1"
        Me.TreeList1.OptionsView.AutoWidth = False
        Me.TreeList1.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFullFocus
        Me.TreeList1.OptionsView.ShowIndicator = False
        Me.TreeList1.ParentFieldName = "Parent"
        Me.TreeList1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cboLinkGPS, Me.cboLinkIcon})
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
        'iml
        '
        Me.iml.Add("linkedfile", "linkedfile", GetType(cSurveyPC.My.Resources.Resources))
        Me.iml.Add("unlinkedfile", "unlinkedfile", GetType(cSurveyPC.My.Resources.Resources))
        Me.iml.Add("bo_localization", "bo_localization", GetType(cSurveyPC.My.Resources.Resources))
        Me.iml.Add("error2", "error2", GetType(cSurveyPC.My.Resources.Resources))
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
        Me.colLinkName.FieldName = "_name"
        Me.colLinkName.Name = "colLinkName"
        Me.colLinkName.OptionsColumn.AllowEdit = False
        Me.colLinkName.OptionsColumn.AllowFocus = False
        Me.colLinkName.OptionsColumn.ReadOnly = True
        Me.colLinkName.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.[String]
        '
        'colLinkFilename
        '
        resources.ApplyResources(Me.colLinkFilename, "colLinkFilename")
        Me.colLinkFilename.FieldName = "_filename"
        Me.colLinkFilename.Name = "colLinkFilename"
        Me.colLinkFilename.OptionsColumn.AllowEdit = False
        Me.colLinkFilename.OptionsColumn.AllowFocus = False
        Me.colLinkFilename.OptionsColumn.ReadOnly = True
        Me.colLinkFilename.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.[String]
        '
        'colLinkFolder
        '
        resources.ApplyResources(Me.colLinkFolder, "colLinkFolder")
        Me.colLinkFolder.FieldName = "_folder"
        Me.colLinkFolder.Name = "colLinkFolder"
        Me.colLinkFolder.OptionsColumn.AllowEdit = False
        Me.colLinkFolder.OptionsColumn.ReadOnly = True
        Me.colLinkFolder.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.[String]
        '
        'colLinkNote
        '
        resources.ApplyResources(Me.colLinkNote, "colLinkNote")
        Me.colLinkNote.FieldName = "Note"
        Me.colLinkNote.Name = "colLinkNote"
        Me.colLinkNote.OptionsColumn.AllowEdit = False
        Me.colLinkNote.OptionsColumn.ReadOnly = True
        '
        'colLinkException
        '
        resources.ApplyResources(Me.colLinkException, "colLinkException")
        Me.colLinkException.FieldName = "LastException"
        Me.colLinkException.Name = "colLinkException"
        Me.colLinkException.OptionsColumn.AllowEdit = False
        Me.colLinkException.OptionsColumn.ReadOnly = True
        '
        'cDockLinkedSurveys
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.TreeList1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "cDockLinkedSurveys"
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mnuCalculate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mnuContext, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TreeList1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboLinkIcon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.iml, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboLinkGPS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents barMain As DevExpress.XtraBars.Bar
    Friend WithEvents btnAdd As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnUnlink As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnRefresh As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnCalculate As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents mnuCalculate As DevExpress.XtraBars.PopupMenu
    Friend WithEvents btnCalculateSelected As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnCalculateAll As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnOpen As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnUnlinkAll As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuContext As DevExpress.XtraBars.PopupMenu
    Friend WithEvents btnManageLinks As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents TreeList1 As DevExpress.XtraTreeList.TreeList
    Friend WithEvents colLinkIcon As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cboLinkIcon As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents colLinkGPS As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cboLinkGPS As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents colLinkName As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colLinkFilename As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colLinkFolder As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colLinkNote As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colLinkException As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents iml As DevExpress.Utils.SvgImageCollection
End Class
