<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLinkedSurveys
    Inherits cDockContentWindow

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLinkedSurveys))
        Me.tvLinkedSurveys = New BrightIdeasSoftware.TreeListView()
        Me.colLinkedSurveysName = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.colLinkedSurveysGPSState = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.colLinkedSurveysFilename = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.colLinkedSurveysFolder = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.colLinkedSurveysNote = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.colLinkedSurveysLastException = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.colLinkedSurveysParent = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
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
        CType(Me.tvLinkedSurveys, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mnuCalculate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mnuContext, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tvLinkedSurveys
        '
        Me.tvLinkedSurveys.AllColumns.Add(Me.colLinkedSurveysName)
        Me.tvLinkedSurveys.AllColumns.Add(Me.colLinkedSurveysGPSState)
        Me.tvLinkedSurveys.AllColumns.Add(Me.colLinkedSurveysFilename)
        Me.tvLinkedSurveys.AllColumns.Add(Me.colLinkedSurveysFolder)
        Me.tvLinkedSurveys.AllColumns.Add(Me.colLinkedSurveysNote)
        Me.tvLinkedSurveys.AllColumns.Add(Me.colLinkedSurveysLastException)
        Me.tvLinkedSurveys.AllColumns.Add(Me.colLinkedSurveysParent)
        Me.tvLinkedSurveys.AllowDrop = True
        Me.tvLinkedSurveys.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tvLinkedSurveys.CellEditUseWholeCell = False
        Me.tvLinkedSurveys.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colLinkedSurveysName, Me.colLinkedSurveysGPSState, Me.colLinkedSurveysFilename, Me.colLinkedSurveysFolder, Me.colLinkedSurveysNote, Me.colLinkedSurveysLastException, Me.colLinkedSurveysParent})
        Me.tvLinkedSurveys.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.tvLinkedSurveys, "tvLinkedSurveys")
        Me.tvLinkedSurveys.FullRowSelect = True
        Me.tvLinkedSurveys.HideSelection = False
        Me.tvLinkedSurveys.IsSimpleDragSource = True
        Me.tvLinkedSurveys.IsSimpleDropSink = True
        Me.tvLinkedSurveys.MultiSelect = False
        Me.tvLinkedSurveys.Name = "tvLinkedSurveys"
        Me.tvLinkedSurveys.ShowGroups = False
        Me.tvLinkedSurveys.UseCompatibleStateImageBehavior = False
        Me.tvLinkedSurveys.View = System.Windows.Forms.View.Details
        Me.tvLinkedSurveys.VirtualMode = True
        '
        'colLinkedSurveysName
        '
        Me.colLinkedSurveysName.IsEditable = False
        resources.ApplyResources(Me.colLinkedSurveysName, "colLinkedSurveysName")
        '
        'colLinkedSurveysGPSState
        '
        Me.colLinkedSurveysGPSState.IsEditable = False
        resources.ApplyResources(Me.colLinkedSurveysGPSState, "colLinkedSurveysGPSState")
        '
        'colLinkedSurveysFilename
        '
        Me.colLinkedSurveysFilename.IsEditable = False
        resources.ApplyResources(Me.colLinkedSurveysFilename, "colLinkedSurveysFilename")
        '
        'colLinkedSurveysFolder
        '
        Me.colLinkedSurveysFolder.IsEditable = False
        resources.ApplyResources(Me.colLinkedSurveysFolder, "colLinkedSurveysFolder")
        '
        'colLinkedSurveysNote
        '
        resources.ApplyResources(Me.colLinkedSurveysNote, "colLinkedSurveysNote")
        '
        'colLinkedSurveysLastException
        '
        resources.ApplyResources(Me.colLinkedSurveysLastException, "colLinkedSurveysLastException")
        '
        'colLinkedSurveysParent
        '
        resources.ApplyResources(Me.colLinkedSurveysParent, "colLinkedSurveysParent")
        '
        'BarManager
        '
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
        'frmLinkedSurveys
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.tvLinkedSurveys)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "frmLinkedSurveys"
        Me.ShowIcon = False
        Me.TopMost = True
        CType(Me.tvLinkedSurveys, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mnuCalculate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mnuContext, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents colLinkedSurveysName As BrightIdeasSoftware.OLVColumn
    Friend WithEvents colLinkedSurveysFilename As BrightIdeasSoftware.OLVColumn
    Friend WithEvents colLinkedSurveysFolder As BrightIdeasSoftware.OLVColumn
    Friend WithEvents colLinkedSurveysNote As BrightIdeasSoftware.OLVColumn
    Friend WithEvents tvLinkedSurveys As BrightIdeasSoftware.TreeListView
    Friend WithEvents colLinkedSurveysGPSState As BrightIdeasSoftware.OLVColumn
    Friend WithEvents colLinkedSurveysLastException As BrightIdeasSoftware.OLVColumn
    Friend WithEvents colLinkedSurveysParent As BrightIdeasSoftware.OLVColumn
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
End Class
