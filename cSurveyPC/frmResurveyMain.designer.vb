<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmResurveyMain
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            'If Not oPlanScalePath Is Nothing Then oPlanScalePath.Dispose()
            'If Not oPlanShotsPath Is Nothing Then oPlanShotsPath.Dispose()
            'If Not oPlanStationPath Is Nothing Then oPlanStationPath.Dispose()
            'If Not oProfileScalePath Is Nothing Then oProfileScalePath.Dispose()
            'If Not oProfileShotsPath Is Nothing Then oProfileShotsPath.Dispose()
            'If Not oProfileStationPath Is Nothing Then oProfileStationPath.Dispose()
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmResurveyMain))
        Dim DockingContainer1 As DevExpress.XtraBars.Docking2010.Views.Tabbed.DockingContainer = New DevExpress.XtraBars.Docking2010.Views.Tabbed.DockingContainer()
        Dim PushTransition1 As DevExpress.Utils.Animation.PushTransition = New DevExpress.Utils.Animation.PushTransition()
        Me.DocumentGroup1 = New DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup(Me.components)
        Me.docPlan = New DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(Me.components)
        Me.docProfile = New DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(Me.components)
        Me.grdShots = New DevExpress.XtraGrid.GridControl()
        Me.gridviewShots = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colShotsFrom = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colShotsTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colShotsDistance = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colShotsBearing = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colShotsInclination = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colShotsPlanimetricDistance = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colShotsDrop = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colShotsLeft = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colShotsRight = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colShotsUp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colShotsDown = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colShotsUserLeft = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colShotsUserRight = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colShotsUserUp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colShotsUserDown = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RibbonControl = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.btnConfirm = New DevExpress.XtraBars.BarButtonItem()
        Me.btnClose = New DevExpress.XtraBars.BarButtonItem()
        Me.btnNew = New DevExpress.XtraBars.BarButtonItem()
        Me.btnLoad = New DevExpress.XtraBars.BarButtonItem()
        Me.btnSave = New DevExpress.XtraBars.BarButtonItem()
        Me.btnLoadImage = New DevExpress.XtraBars.BarButtonItem()
        Me.btnOptions = New DevExpress.XtraBars.BarButtonItem()
        Me.btnZoomIn = New DevExpress.XtraBars.BarButtonItem()
        Me.btnZoomOut = New DevExpress.XtraBars.BarButtonItem()
        Me.btnCalculate = New DevExpress.XtraBars.BarButtonItem()
        Me.btnExport = New DevExpress.XtraBars.BarButtonItem()
        Me.btnShowRulers = New DevExpress.XtraBars.BarCheckItem()
        Me.btnAdd2 = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRemove2 = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRemoveAll2 = New DevExpress.XtraBars.BarButtonItem()
        Me.btnDelete2 = New DevExpress.XtraBars.BarButtonItem()
        Me.btnDeleteAll2 = New DevExpress.XtraBars.BarButtonItem()
        Me.btnDeleteLink = New DevExpress.XtraBars.BarButtonItem()
        Me.btnSetOrigin2 = New DevExpress.XtraBars.BarButtonItem()
        Me.btnProperties2 = New DevExpress.XtraBars.BarButtonItem()
        Me.btnShowRuler = New DevExpress.XtraBars.BarCheckItem()
        Me.pnlStatus = New DevExpress.XtraBars.BarStaticItem()
        Me.pnlCurrentProjection = New DevExpress.XtraBars.BarStaticItem()
        Me.pnlCoordinates = New DevExpress.XtraBars.BarStaticItem()
        Me.pnlDistance = New DevExpress.XtraBars.BarStaticItem()
        Me.pnlAngle = New DevExpress.XtraBars.BarStaticItem()
        Me.pnlZoom = New DevExpress.XtraBars.BarStaticItem()
        Me.btnZoom100 = New DevExpress.XtraBars.BarButtonItem()
        Me.btnZoomToFit = New DevExpress.XtraBars.BarButtonItem()
        Me.btnsZoom = New DevExpress.XtraBars.BarButtonGroup()
        Me.btnZoom25 = New DevExpress.XtraBars.BarButtonItem()
        Me.btnZoom200 = New DevExpress.XtraBars.BarButtonItem()
        Me.btnZoom50 = New DevExpress.XtraBars.BarButtonItem()
        Me.btnVisibility = New DevExpress.XtraBars.BarSubItem()
        Me.btnPlanShowAll = New DevExpress.XtraBars.BarButtonItem()
        Me.btnPlanHideAll = New DevExpress.XtraBars.BarButtonItem()
        Me.btnProfileShowAll = New DevExpress.XtraBars.BarButtonItem()
        Me.btnProfileHideAll = New DevExpress.XtraBars.BarButtonItem()
        Me.btnVisible = New DevExpress.XtraBars.BarEditItem()
        Me.chkVisible = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.btnImageInvertColor = New DevExpress.XtraBars.BarButtonItem()
        Me.btnImageToGrayScale = New DevExpress.XtraBars.BarButtonItem()
        Me.btnImageBWThreshold = New DevExpress.XtraBars.BarEditItem()
        Me.trkImageBlackAndWhite = New DevExpress.XtraEditors.Repository.RepositoryItemTrackBar()
        Me.btnRulerCenterHere = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRulerAlignTo = New DevExpress.XtraBars.BarButtonItem()
        Me.btnMagnifier = New DevExpress.XtraBars.BarCheckItem()
        Me.btnLeftEdit = New DevExpress.XtraBars.BarEditItem()
        Me.txtLeftEdit = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.btnRightEdit = New DevExpress.XtraBars.BarEditItem()
        Me.txtRightEdit = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.btnUpEdit = New DevExpress.XtraBars.BarEditItem()
        Me.txtUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.btnDownEdit = New DevExpress.XtraBars.BarEditItem()
        Me.txtDownEdit = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.btnSaveAs = New DevExpress.XtraBars.BarButtonItem()
        Me.btnSaveImage = New DevExpress.XtraBars.BarButtonItem()
        Me.btnClearImage = New DevExpress.XtraBars.BarButtonItem()
        Me.tbPlan = New DevExpress.XtraBars.Ribbon.RibbonMiniToolbar(Me.components)
        Me.tbProfile = New DevExpress.XtraBars.Ribbon.RibbonMiniToolbar(Me.components)
        Me.pageMain = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.grpFile = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.grpCommands = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.grpIntegration = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.pageImage = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.grpImageCommands = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.grpImageColors = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.pageWorkflow = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.grpView = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.grpStations = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.grpPlaceholders = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.grpLinks = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.grpWorkflowCommands = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonStatusBar1 = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.picPlan = New System.Windows.Forms.PictureBox()
        Me.picProfile = New System.Windows.Forms.PictureBox()
        Me.grdStations = New DevExpress.XtraGrid.GridControl()
        Me.gridviewStations = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colPlaceholdersIcon = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPlaceholdersName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPlaceholdersPlanPoint = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPlaceholdersProfilePoint = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPlaceholdersPlanConnectedTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPlaceholdersProfileConnectedTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPlaceholdersType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPlaceholdersPlanVisible = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPlaceholdersProfileVisible = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.pnlPlan = New System.Windows.Forms.Panel()
        Me.mnuPanel = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.pnlProfile = New System.Windows.Forms.Panel()
        Me.pnlPopup = New System.Windows.Forms.Panel()
        Me.btnPopupClose = New DevExpress.XtraEditors.SimpleButton()
        Me.lblPopupWarning = New System.Windows.Forms.Label()
        Me.picPopupWarning = New System.Windows.Forms.PictureBox()
        Me.imlPopup = New System.Windows.Forms.ImageList(Me.components)
        Me.mnuDesign = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.DockManager = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        Me.dockMagnifier = New DevExpress.XtraBars.Docking.DockPanel()
        Me.ControlContainer2 = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.picMagnifier = New System.Windows.Forms.PictureBox()
        Me.panelContainer1 = New DevExpress.XtraBars.Docking.DockPanel()
        Me.dockStations = New DevExpress.XtraBars.Docking.DockPanel()
        Me.DockPanel3_Container = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.dockPlot = New DevExpress.XtraBars.Docking.DockPanel()
        Me.ControlContainer1 = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.dockProfile = New DevExpress.XtraBars.Docking.DockPanel()
        Me.DockPanel2_Container = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.dockPlan = New DevExpress.XtraBars.Docking.DockPanel()
        Me.DockPanel1_Container = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.DocumentManager = New DevExpress.XtraBars.Docking2010.DocumentManager(Me.components)
        Me.docView = New DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(Me.components)
        Me.mnuStations = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.mnuDesignAdd = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.mnuDesignLink = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.WorkspaceManager = New DevExpress.Utils.WorkspaceManager(Me.components)
        Me.tmrMagnifier = New System.Windows.Forms.Timer(Me.components)
        CType(Me.DocumentGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.docPlan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.docProfile, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdShots, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridviewShots, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkVisible, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trkImageBlackAndWhite, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLeftEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRightEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUpEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDownEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPlan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picProfile, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdStations, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridviewStations, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPlan.SuspendLayout()
        CType(Me.mnuPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlProfile.SuspendLayout()
        Me.pnlPopup.SuspendLayout()
        CType(Me.picPopupWarning, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mnuDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DockManager, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.dockMagnifier.SuspendLayout()
        Me.ControlContainer2.SuspendLayout()
        CType(Me.picMagnifier, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelContainer1.SuspendLayout()
        Me.dockStations.SuspendLayout()
        Me.DockPanel3_Container.SuspendLayout()
        Me.dockPlot.SuspendLayout()
        Me.ControlContainer1.SuspendLayout()
        Me.dockProfile.SuspendLayout()
        Me.DockPanel2_Container.SuspendLayout()
        Me.dockPlan.SuspendLayout()
        Me.DockPanel1_Container.SuspendLayout()
        CType(Me.DocumentManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.docView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mnuStations, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mnuDesignAdd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mnuDesignLink, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DocumentGroup1
        '
        Me.DocumentGroup1.Items.AddRange(New DevExpress.XtraBars.Docking2010.Views.Tabbed.Document() {Me.docPlan, Me.docProfile})
        '
        'docPlan
        '
        resources.ApplyResources(Me.docPlan, "docPlan")
        Me.docPlan.ControlName = "dockPlan"
        Me.docPlan.FloatLocation = New System.Drawing.Point(251, 334)
        Me.docPlan.FloatSize = New System.Drawing.Size(956, 200)
        Me.docPlan.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.[False]
        Me.docPlan.Properties.AllowFloat = DevExpress.Utils.DefaultBoolean.[True]
        Me.docPlan.Properties.AllowFloatOnDoubleClick = DevExpress.Utils.DefaultBoolean.[False]
        Me.docPlan.Properties.AllowPin = DevExpress.Utils.DefaultBoolean.[False]
        Me.docPlan.Properties.ShowPinButton = DevExpress.Utils.DefaultBoolean.[False]
        '
        'docProfile
        '
        resources.ApplyResources(Me.docProfile, "docProfile")
        Me.docProfile.ControlName = "dockProfile"
        Me.docProfile.FloatLocation = New System.Drawing.Point(295, 333)
        Me.docProfile.FloatSize = New System.Drawing.Size(950, 359)
        Me.docProfile.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.[False]
        Me.docProfile.Properties.AllowFloat = DevExpress.Utils.DefaultBoolean.[True]
        Me.docProfile.Properties.AllowFloatOnDoubleClick = DevExpress.Utils.DefaultBoolean.[False]
        Me.docProfile.Properties.AllowPin = DevExpress.Utils.DefaultBoolean.[False]
        '
        'grdShots
        '
        resources.ApplyResources(Me.grdShots, "grdShots")
        Me.grdShots.MainView = Me.gridviewShots
        Me.grdShots.MenuManager = Me.RibbonControl
        Me.grdShots.Name = "grdShots"
        Me.grdShots.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridviewShots})
        '
        'gridviewShots
        '
        Me.gridviewShots.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.gridviewShots.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colShotsFrom, Me.colShotsTo, Me.colShotsDistance, Me.colShotsBearing, Me.colShotsInclination, Me.colShotsPlanimetricDistance, Me.colShotsDrop, Me.colShotsLeft, Me.colShotsRight, Me.colShotsUp, Me.colShotsDown, Me.colShotsUserLeft, Me.colShotsUserRight, Me.colShotsUserUp, Me.colShotsUserDown})
        Me.gridviewShots.GridControl = Me.grdShots
        Me.gridviewShots.Name = "gridviewShots"
        Me.gridviewShots.OptionsBehavior.AutoPopulateColumns = False
        Me.gridviewShots.OptionsCustomization.AllowGroup = False
        Me.gridviewShots.OptionsView.ColumnAutoWidth = False
        Me.gridviewShots.OptionsView.ShowGroupPanel = False
        '
        'colShotsFrom
        '
        resources.ApplyResources(Me.colShotsFrom, "colShotsFrom")
        Me.colShotsFrom.FieldName = "From"
        Me.colShotsFrom.Name = "colShotsFrom"
        Me.colShotsFrom.OptionsColumn.AllowEdit = False
        Me.colShotsFrom.OptionsColumn.ReadOnly = True
        '
        'colShotsTo
        '
        resources.ApplyResources(Me.colShotsTo, "colShotsTo")
        Me.colShotsTo.FieldName = "To"
        Me.colShotsTo.Name = "colShotsTo"
        Me.colShotsTo.OptionsColumn.AllowEdit = False
        Me.colShotsTo.OptionsColumn.ReadOnly = True
        '
        'colShotsDistance
        '
        resources.ApplyResources(Me.colShotsDistance, "colShotsDistance")
        Me.colShotsDistance.DisplayFormat.FormatString = "N2"
        Me.colShotsDistance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colShotsDistance.FieldName = "Distance"
        Me.colShotsDistance.Name = "colShotsDistance"
        Me.colShotsDistance.OptionsColumn.AllowEdit = False
        Me.colShotsDistance.OptionsColumn.ReadOnly = True
        '
        'colShotsBearing
        '
        resources.ApplyResources(Me.colShotsBearing, "colShotsBearing")
        Me.colShotsBearing.DisplayFormat.FormatString = "N2"
        Me.colShotsBearing.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colShotsBearing.FieldName = "Bearing"
        Me.colShotsBearing.Name = "colShotsBearing"
        Me.colShotsBearing.OptionsColumn.AllowEdit = False
        Me.colShotsBearing.OptionsColumn.ReadOnly = True
        '
        'colShotsInclination
        '
        resources.ApplyResources(Me.colShotsInclination, "colShotsInclination")
        Me.colShotsInclination.DisplayFormat.FormatString = "N2"
        Me.colShotsInclination.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colShotsInclination.FieldName = "Inclination"
        Me.colShotsInclination.Name = "colShotsInclination"
        Me.colShotsInclination.OptionsColumn.AllowEdit = False
        Me.colShotsInclination.OptionsColumn.ReadOnly = True
        '
        'colShotsPlanimetricDistance
        '
        resources.ApplyResources(Me.colShotsPlanimetricDistance, "colShotsPlanimetricDistance")
        Me.colShotsPlanimetricDistance.DisplayFormat.FormatString = "N2"
        Me.colShotsPlanimetricDistance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colShotsPlanimetricDistance.FieldName = "PlanimetricDistance"
        Me.colShotsPlanimetricDistance.Name = "colShotsPlanimetricDistance"
        Me.colShotsPlanimetricDistance.OptionsColumn.AllowEdit = False
        Me.colShotsPlanimetricDistance.OptionsColumn.ReadOnly = True
        '
        'colShotsDrop
        '
        resources.ApplyResources(Me.colShotsDrop, "colShotsDrop")
        Me.colShotsDrop.DisplayFormat.FormatString = "N2"
        Me.colShotsDrop.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colShotsDrop.FieldName = "Drop"
        Me.colShotsDrop.Name = "colShotsDrop"
        Me.colShotsDrop.OptionsColumn.AllowEdit = False
        Me.colShotsDrop.OptionsColumn.ReadOnly = True
        '
        'colShotsLeft
        '
        resources.ApplyResources(Me.colShotsLeft, "colShotsLeft")
        Me.colShotsLeft.DisplayFormat.FormatString = "N2"
        Me.colShotsLeft.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colShotsLeft.FieldName = "GetLeft"
        Me.colShotsLeft.Name = "colShotsLeft"
        Me.colShotsLeft.OptionsColumn.AllowEdit = False
        Me.colShotsLeft.OptionsColumn.ReadOnly = True
        '
        'colShotsRight
        '
        resources.ApplyResources(Me.colShotsRight, "colShotsRight")
        Me.colShotsRight.DisplayFormat.FormatString = "N2"
        Me.colShotsRight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colShotsRight.FieldName = "GetRight"
        Me.colShotsRight.Name = "colShotsRight"
        Me.colShotsRight.OptionsColumn.AllowEdit = False
        Me.colShotsRight.OptionsColumn.ReadOnly = True
        '
        'colShotsUp
        '
        resources.ApplyResources(Me.colShotsUp, "colShotsUp")
        Me.colShotsUp.DisplayFormat.FormatString = "N2"
        Me.colShotsUp.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colShotsUp.FieldName = "GetUp"
        Me.colShotsUp.Name = "colShotsUp"
        Me.colShotsUp.OptionsColumn.AllowEdit = False
        Me.colShotsUp.OptionsColumn.ReadOnly = True
        '
        'colShotsDown
        '
        resources.ApplyResources(Me.colShotsDown, "colShotsDown")
        Me.colShotsDown.DisplayFormat.FormatString = "N2"
        Me.colShotsDown.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colShotsDown.FieldName = "GetDown"
        Me.colShotsDown.Name = "colShotsDown"
        Me.colShotsDown.OptionsColumn.AllowEdit = False
        Me.colShotsDown.OptionsColumn.ReadOnly = True
        '
        'colShotsUserLeft
        '
        resources.ApplyResources(Me.colShotsUserLeft, "colShotsUserLeft")
        Me.colShotsUserLeft.DisplayFormat.FormatString = "N2"
        Me.colShotsUserLeft.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colShotsUserLeft.FieldName = "UserLeft"
        Me.colShotsUserLeft.Name = "colShotsUserLeft"
        '
        'colShotsUserRight
        '
        resources.ApplyResources(Me.colShotsUserRight, "colShotsUserRight")
        Me.colShotsUserRight.DisplayFormat.FormatString = "N2"
        Me.colShotsUserRight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colShotsUserRight.FieldName = "UserRight"
        Me.colShotsUserRight.Name = "colShotsUserRight"
        '
        'colShotsUserUp
        '
        resources.ApplyResources(Me.colShotsUserUp, "colShotsUserUp")
        Me.colShotsUserUp.DisplayFormat.FormatString = "N2"
        Me.colShotsUserUp.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colShotsUserUp.FieldName = "UserUp"
        Me.colShotsUserUp.Name = "colShotsUserUp"
        '
        'colShotsUserDown
        '
        resources.ApplyResources(Me.colShotsUserDown, "colShotsUserDown")
        Me.colShotsUserDown.DisplayFormat.FormatString = "N2"
        Me.colShotsUserDown.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colShotsUserDown.FieldName = "UserDown"
        Me.colShotsUserDown.Name = "colShotsUserDown"
        '
        'RibbonControl
        '
        Me.RibbonControl.AutoSizeItems = True
        Me.RibbonControl.CaptionBarItemLinks.Add(Me.btnConfirm)
        Me.RibbonControl.CaptionBarItemLinks.Add(Me.btnClose)
        Me.RibbonControl.ExpandCollapseItem.Id = 0
        Me.RibbonControl.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnConfirm, Me.btnClose, Me.RibbonControl.ExpandCollapseItem, Me.RibbonControl.SearchEditItem, Me.btnNew, Me.btnLoad, Me.btnSave, Me.btnLoadImage, Me.btnOptions, Me.btnZoomIn, Me.btnZoomOut, Me.btnCalculate, Me.btnExport, Me.btnShowRulers, Me.btnAdd2, Me.btnRemove2, Me.btnRemoveAll2, Me.btnDelete2, Me.btnDeleteAll2, Me.btnDeleteLink, Me.btnSetOrigin2, Me.btnProperties2, Me.btnShowRuler, Me.pnlStatus, Me.pnlCurrentProjection, Me.pnlCoordinates, Me.pnlDistance, Me.pnlAngle, Me.pnlZoom, Me.btnZoom100, Me.btnZoomToFit, Me.btnsZoom, Me.btnZoom25, Me.btnZoom200, Me.btnZoom50, Me.btnVisibility, Me.btnPlanHideAll, Me.btnPlanShowAll, Me.btnProfileShowAll, Me.btnProfileHideAll, Me.btnVisible, Me.btnImageInvertColor, Me.btnImageToGrayScale, Me.btnImageBWThreshold, Me.btnRulerCenterHere, Me.btnRulerAlignTo, Me.btnMagnifier, Me.btnLeftEdit, Me.btnRightEdit, Me.btnUpEdit, Me.btnDownEdit, Me.btnSaveAs, Me.btnSaveImage, Me.btnClearImage})
        resources.ApplyResources(Me.RibbonControl, "RibbonControl")
        Me.RibbonControl.MaxItemId = 70
        Me.RibbonControl.MiniToolbars.Add(Me.tbPlan)
        Me.RibbonControl.MiniToolbars.Add(Me.tbProfile)
        Me.RibbonControl.Name = "RibbonControl"
        Me.RibbonControl.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.pageMain, Me.pageImage, Me.pageWorkflow})
        Me.RibbonControl.QuickToolbarItemLinks.Add(Me.btnNew)
        Me.RibbonControl.QuickToolbarItemLinks.Add(Me.btnLoad)
        Me.RibbonControl.QuickToolbarItemLinks.Add(Me.btnLoadImage, True)
        Me.RibbonControl.QuickToolbarItemLinks.Add(Me.btnCalculate, True)
        Me.RibbonControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.chkVisible, Me.trkImageBlackAndWhite, Me.txtLeftEdit, Me.txtRightEdit, Me.txtUpEdit, Me.txtDownEdit})
        Me.RibbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl.StatusBar = Me.RibbonStatusBar1
        '
        'btnConfirm
        '
        resources.ApplyResources(Me.btnConfirm, "btnConfirm")
        Me.btnConfirm.Id = 16
        Me.btnConfirm.ImageOptions.SvgImage = CType(resources.GetObject("btnConfirm.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnConfirm.Name = "btnConfirm"
        '
        'btnClose
        '
        resources.ApplyResources(Me.btnClose, "btnClose")
        Me.btnClose.Id = 17
        Me.btnClose.ImageOptions.SvgImage = CType(resources.GetObject("btnClose.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnClose.Name = "btnClose"
        '
        'btnNew
        '
        resources.ApplyResources(Me.btnNew, "btnNew")
        Me.btnNew.Id = 1
        Me.btnNew.ImageOptions.SvgImage = CType(resources.GetObject("btnNew.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'btnLoad
        '
        resources.ApplyResources(Me.btnLoad, "btnLoad")
        Me.btnLoad.Id = 2
        Me.btnLoad.ImageOptions.SvgImage = CType(resources.GetObject("btnLoad.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'btnSave
        '
        resources.ApplyResources(Me.btnSave, "btnSave")
        Me.btnSave.Id = 3
        Me.btnSave.ImageOptions.SvgImage = CType(resources.GetObject("btnSave.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnSave.Name = "btnSave"
        '
        'btnLoadImage
        '
        resources.ApplyResources(Me.btnLoadImage, "btnLoadImage")
        Me.btnLoadImage.Id = 4
        Me.btnLoadImage.ImageOptions.SvgImage = CType(resources.GetObject("btnLoadImage.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnLoadImage.Name = "btnLoadImage"
        '
        'btnOptions
        '
        resources.ApplyResources(Me.btnOptions, "btnOptions")
        Me.btnOptions.Id = 5
        Me.btnOptions.ImageOptions.SvgImage = CType(resources.GetObject("btnOptions.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnOptions.Name = "btnOptions"
        '
        'btnZoomIn
        '
        resources.ApplyResources(Me.btnZoomIn, "btnZoomIn")
        Me.btnZoomIn.Id = 6
        Me.btnZoomIn.ImageOptions.SvgImage = CType(resources.GetObject("btnZoomIn.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnZoomIn.Name = "btnZoomIn"
        '
        'btnZoomOut
        '
        resources.ApplyResources(Me.btnZoomOut, "btnZoomOut")
        Me.btnZoomOut.Id = 7
        Me.btnZoomOut.ImageOptions.SvgImage = CType(resources.GetObject("btnZoomOut.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnZoomOut.Name = "btnZoomOut"
        '
        'btnCalculate
        '
        resources.ApplyResources(Me.btnCalculate, "btnCalculate")
        Me.btnCalculate.Id = 14
        Me.btnCalculate.ImageOptions.SvgImage = CType(resources.GetObject("btnCalculate.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnCalculate.Name = "btnCalculate"
        '
        'btnExport
        '
        resources.ApplyResources(Me.btnExport, "btnExport")
        Me.btnExport.Id = 15
        Me.btnExport.ImageOptions.SvgImage = CType(resources.GetObject("btnExport.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'btnShowRulers
        '
        resources.ApplyResources(Me.btnShowRulers, "btnShowRulers")
        Me.btnShowRulers.Id = 19
        Me.btnShowRulers.ImageOptions.SvgImage = CType(resources.GetObject("btnShowRulers.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnShowRulers.Name = "btnShowRulers"
        Me.btnShowRulers.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'btnAdd2
        '
        resources.ApplyResources(Me.btnAdd2, "btnAdd2")
        Me.btnAdd2.Id = 20
        Me.btnAdd2.ImageOptions.SvgImage = CType(resources.GetObject("btnAdd2.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnAdd2.Name = "btnAdd2"
        '
        'btnRemove2
        '
        resources.ApplyResources(Me.btnRemove2, "btnRemove2")
        Me.btnRemove2.Enabled = False
        Me.btnRemove2.Id = 21
        Me.btnRemove2.ImageOptions.SvgImage = CType(resources.GetObject("btnRemove2.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnRemove2.Name = "btnRemove2"
        '
        'btnRemoveAll2
        '
        resources.ApplyResources(Me.btnRemoveAll2, "btnRemoveAll2")
        Me.btnRemoveAll2.Enabled = False
        Me.btnRemoveAll2.Id = 22
        Me.btnRemoveAll2.ImageOptions.SvgImage = CType(resources.GetObject("btnRemoveAll2.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnRemoveAll2.Name = "btnRemoveAll2"
        '
        'btnDelete2
        '
        resources.ApplyResources(Me.btnDelete2, "btnDelete2")
        Me.btnDelete2.Enabled = False
        Me.btnDelete2.Id = 23
        Me.btnDelete2.ImageOptions.SvgImage = CType(resources.GetObject("btnDelete2.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnDelete2.Name = "btnDelete2"
        '
        'btnDeleteAll2
        '
        resources.ApplyResources(Me.btnDeleteAll2, "btnDeleteAll2")
        Me.btnDeleteAll2.Enabled = False
        Me.btnDeleteAll2.Id = 24
        Me.btnDeleteAll2.ImageOptions.SvgImage = CType(resources.GetObject("btnDeleteAll2.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnDeleteAll2.Name = "btnDeleteAll2"
        '
        'btnDeleteLink
        '
        resources.ApplyResources(Me.btnDeleteLink, "btnDeleteLink")
        Me.btnDeleteLink.Enabled = False
        Me.btnDeleteLink.Id = 25
        Me.btnDeleteLink.ImageOptions.SvgImage = CType(resources.GetObject("btnDeleteLink.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnDeleteLink.Name = "btnDeleteLink"
        '
        'btnSetOrigin2
        '
        resources.ApplyResources(Me.btnSetOrigin2, "btnSetOrigin2")
        Me.btnSetOrigin2.Enabled = False
        Me.btnSetOrigin2.Id = 26
        Me.btnSetOrigin2.ImageOptions.SvgImage = CType(resources.GetObject("btnSetOrigin2.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnSetOrigin2.Name = "btnSetOrigin2"
        '
        'btnProperties2
        '
        resources.ApplyResources(Me.btnProperties2, "btnProperties2")
        Me.btnProperties2.Enabled = False
        Me.btnProperties2.Id = 27
        Me.btnProperties2.ImageOptions.SvgImage = CType(resources.GetObject("btnProperties2.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnProperties2.Name = "btnProperties2"
        '
        'btnShowRuler
        '
        resources.ApplyResources(Me.btnShowRuler, "btnShowRuler")
        Me.btnShowRuler.Enabled = False
        Me.btnShowRuler.Id = 29
        Me.btnShowRuler.ImageOptions.SvgImage = CType(resources.GetObject("btnShowRuler.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnShowRuler.Name = "btnShowRuler"
        Me.btnShowRuler.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'pnlStatus
        '
        Me.pnlStatus.AutoSize = DevExpress.XtraBars.BarStaticItemSize.Spring
        Me.pnlStatus.Id = 32
        Me.pnlStatus.Name = "pnlStatus"
        '
        'pnlCurrentProjection
        '
        Me.pnlCurrentProjection.AutoSize = DevExpress.XtraBars.BarStaticItemSize.None
        Me.pnlCurrentProjection.Id = 33
        Me.pnlCurrentProjection.Name = "pnlCurrentProjection"
        Me.pnlCurrentProjection.Width = 200
        '
        'pnlCoordinates
        '
        Me.pnlCoordinates.AutoSize = DevExpress.XtraBars.BarStaticItemSize.None
        Me.pnlCoordinates.Id = 34
        Me.pnlCoordinates.Name = "pnlCoordinates"
        Me.pnlCoordinates.Width = 120
        '
        'pnlDistance
        '
        Me.pnlDistance.AutoSize = DevExpress.XtraBars.BarStaticItemSize.None
        Me.pnlDistance.Id = 35
        Me.pnlDistance.Name = "pnlDistance"
        Me.pnlDistance.Width = 120
        '
        'pnlAngle
        '
        Me.pnlAngle.Id = 36
        Me.pnlAngle.Name = "pnlAngle"
        Me.pnlAngle.Width = 120
        '
        'pnlZoom
        '
        Me.pnlZoom.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.pnlZoom.AutoSize = DevExpress.XtraBars.BarStaticItemSize.None
        Me.pnlZoom.Id = 37
        Me.pnlZoom.Name = "pnlZoom"
        Me.pnlZoom.TextAlignment = System.Drawing.StringAlignment.Far
        Me.pnlZoom.Width = 120
        '
        'btnZoom100
        '
        Me.btnZoom100.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        resources.ApplyResources(Me.btnZoom100, "btnZoom100")
        Me.btnZoom100.Id = 39
        Me.btnZoom100.Name = "btnZoom100"
        '
        'btnZoomToFit
        '
        resources.ApplyResources(Me.btnZoomToFit, "btnZoomToFit")
        Me.btnZoomToFit.Id = 40
        Me.btnZoomToFit.ImageOptions.SvgImage = CType(resources.GetObject("btnZoomToFit.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnZoomToFit.Name = "btnZoomToFit"
        '
        'btnsZoom
        '
        Me.btnsZoom.Id = 42
        Me.btnsZoom.Name = "btnsZoom"
        '
        'btnZoom25
        '
        Me.btnZoom25.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        resources.ApplyResources(Me.btnZoom25, "btnZoom25")
        Me.btnZoom25.Id = 43
        Me.btnZoom25.Name = "btnZoom25"
        '
        'btnZoom200
        '
        Me.btnZoom200.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        resources.ApplyResources(Me.btnZoom200, "btnZoom200")
        Me.btnZoom200.Id = 45
        Me.btnZoom200.Name = "btnZoom200"
        '
        'btnZoom50
        '
        Me.btnZoom50.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        resources.ApplyResources(Me.btnZoom50, "btnZoom50")
        Me.btnZoom50.Id = 46
        Me.btnZoom50.Name = "btnZoom50"
        '
        'btnVisibility
        '
        resources.ApplyResources(Me.btnVisibility, "btnVisibility")
        Me.btnVisibility.Id = 49
        Me.btnVisibility.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnPlanShowAll), New DevExpress.XtraBars.LinkPersistInfo(Me.btnPlanHideAll), New DevExpress.XtraBars.LinkPersistInfo(Me.btnProfileShowAll, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnProfileHideAll)})
        Me.btnVisibility.Name = "btnVisibility"
        '
        'btnPlanShowAll
        '
        resources.ApplyResources(Me.btnPlanShowAll, "btnPlanShowAll")
        Me.btnPlanShowAll.Id = 51
        Me.btnPlanShowAll.Name = "btnPlanShowAll"
        '
        'btnPlanHideAll
        '
        resources.ApplyResources(Me.btnPlanHideAll, "btnPlanHideAll")
        Me.btnPlanHideAll.Id = 50
        Me.btnPlanHideAll.Name = "btnPlanHideAll"
        '
        'btnProfileShowAll
        '
        resources.ApplyResources(Me.btnProfileShowAll, "btnProfileShowAll")
        Me.btnProfileShowAll.Id = 52
        Me.btnProfileShowAll.Name = "btnProfileShowAll"
        '
        'btnProfileHideAll
        '
        resources.ApplyResources(Me.btnProfileHideAll, "btnProfileHideAll")
        Me.btnProfileHideAll.Id = 53
        Me.btnProfileHideAll.Name = "btnProfileHideAll"
        '
        'btnVisible
        '
        resources.ApplyResources(Me.btnVisible, "btnVisible")
        Me.btnVisible.Edit = Me.chkVisible
        Me.btnVisible.Id = 54
        Me.btnVisible.Name = "btnVisible"
        '
        'chkVisible
        '
        resources.ApplyResources(Me.chkVisible, "chkVisible")
        Me.chkVisible.Name = "chkVisible"
        '
        'btnImageInvertColor
        '
        resources.ApplyResources(Me.btnImageInvertColor, "btnImageInvertColor")
        Me.btnImageInvertColor.Id = 55
        Me.btnImageInvertColor.ImageOptions.SvgImage = CType(resources.GetObject("btnImageInvertColor.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnImageInvertColor.Name = "btnImageInvertColor"
        '
        'btnImageToGrayScale
        '
        resources.ApplyResources(Me.btnImageToGrayScale, "btnImageToGrayScale")
        Me.btnImageToGrayScale.Id = 56
        Me.btnImageToGrayScale.ImageOptions.SvgImage = CType(resources.GetObject("btnImageToGrayScale.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnImageToGrayScale.Name = "btnImageToGrayScale"
        Me.btnImageToGrayScale.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'btnImageBWThreshold
        '
        resources.ApplyResources(Me.btnImageBWThreshold, "btnImageBWThreshold")
        Me.btnImageBWThreshold.Edit = Me.trkImageBlackAndWhite
        Me.btnImageBWThreshold.Id = 57
        Me.btnImageBWThreshold.ImageOptions.SvgImage = CType(resources.GetObject("btnImageBWThreshold.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnImageBWThreshold.Name = "btnImageBWThreshold"
        Me.btnImageBWThreshold.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'trkImageBlackAndWhite
        '
        Me.trkImageBlackAndWhite.LabelAppearance.Options.UseTextOptions = True
        Me.trkImageBlackAndWhite.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.trkImageBlackAndWhite.Name = "trkImageBlackAndWhite"
        '
        'btnRulerCenterHere
        '
        resources.ApplyResources(Me.btnRulerCenterHere, "btnRulerCenterHere")
        Me.btnRulerCenterHere.Enabled = False
        Me.btnRulerCenterHere.Id = 58
        Me.btnRulerCenterHere.ImageOptions.SvgImage = CType(resources.GetObject("btnRulerCenterHere.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnRulerCenterHere.Name = "btnRulerCenterHere"
        '
        'btnRulerAlignTo
        '
        resources.ApplyResources(Me.btnRulerAlignTo, "btnRulerAlignTo")
        Me.btnRulerAlignTo.Enabled = False
        Me.btnRulerAlignTo.Id = 59
        Me.btnRulerAlignTo.ImageOptions.SvgImage = CType(resources.GetObject("btnRulerAlignTo.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnRulerAlignTo.Name = "btnRulerAlignTo"
        '
        'btnMagnifier
        '
        resources.ApplyResources(Me.btnMagnifier, "btnMagnifier")
        Me.btnMagnifier.Id = 60
        Me.btnMagnifier.ImageOptions.SvgImage = CType(resources.GetObject("btnMagnifier.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnMagnifier.Name = "btnMagnifier"
        '
        'btnLeftEdit
        '
        resources.ApplyResources(Me.btnLeftEdit, "btnLeftEdit")
        Me.btnLeftEdit.Edit = Me.txtLeftEdit
        Me.btnLeftEdit.Id = 63
        Me.btnLeftEdit.ImageOptions.SvgImage = CType(resources.GetObject("btnLeftEdit.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnLeftEdit.Name = "btnLeftEdit"
        Me.btnLeftEdit.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText
        '
        'txtLeftEdit
        '
        Me.txtLeftEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        resources.ApplyResources(Me.txtLeftEdit, "txtLeftEdit")
        Me.txtLeftEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtLeftEdit.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtLeftEdit.DisplayFormat.FormatString = "N2"
        Me.txtLeftEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtLeftEdit.EditFormat.FormatString = "N2"
        Me.txtLeftEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtLeftEdit.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.[Default]
        Me.txtLeftEdit.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.txtLeftEdit.Mask.EditMask = resources.GetString("txtLeftEdit.Mask.EditMask")
        Me.txtLeftEdit.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.txtLeftEdit.Name = "txtLeftEdit"
        Me.txtLeftEdit.ValidateOnEnterKey = True
        '
        'btnRightEdit
        '
        resources.ApplyResources(Me.btnRightEdit, "btnRightEdit")
        Me.btnRightEdit.Edit = Me.txtRightEdit
        Me.btnRightEdit.Id = 64
        Me.btnRightEdit.ImageOptions.SvgImage = CType(resources.GetObject("btnRightEdit.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnRightEdit.Name = "btnRightEdit"
        Me.btnRightEdit.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText
        '
        'txtRightEdit
        '
        Me.txtRightEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        resources.ApplyResources(Me.txtRightEdit, "txtRightEdit")
        Me.txtRightEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtRightEdit.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtRightEdit.DisplayFormat.FormatString = "N2"
        Me.txtRightEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtRightEdit.EditFormat.FormatString = "N2"
        Me.txtRightEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtRightEdit.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.[Default]
        Me.txtRightEdit.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.txtRightEdit.Mask.EditMask = resources.GetString("txtRightEdit.Mask.EditMask")
        Me.txtRightEdit.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.txtRightEdit.Name = "txtRightEdit"
        Me.txtRightEdit.ValidateOnEnterKey = True
        '
        'btnUpEdit
        '
        resources.ApplyResources(Me.btnUpEdit, "btnUpEdit")
        Me.btnUpEdit.Edit = Me.txtUpEdit
        Me.btnUpEdit.Id = 65
        Me.btnUpEdit.ImageOptions.SvgImage = CType(resources.GetObject("btnUpEdit.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnUpEdit.Name = "btnUpEdit"
        Me.btnUpEdit.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText
        '
        'txtUpEdit
        '
        Me.txtUpEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        resources.ApplyResources(Me.txtUpEdit, "txtUpEdit")
        Me.txtUpEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtUpEdit.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtUpEdit.DisplayFormat.FormatString = "N2"
        Me.txtUpEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtUpEdit.EditFormat.FormatString = "N2"
        Me.txtUpEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtUpEdit.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.[Default]
        Me.txtUpEdit.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.txtUpEdit.Mask.EditMask = resources.GetString("txtUpEdit.Mask.EditMask")
        Me.txtUpEdit.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.txtUpEdit.Name = "txtUpEdit"
        Me.txtUpEdit.ValidateOnEnterKey = True
        '
        'btnDownEdit
        '
        resources.ApplyResources(Me.btnDownEdit, "btnDownEdit")
        Me.btnDownEdit.Edit = Me.txtDownEdit
        Me.btnDownEdit.Id = 66
        Me.btnDownEdit.ImageOptions.SvgImage = CType(resources.GetObject("btnDownEdit.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnDownEdit.Name = "btnDownEdit"
        Me.btnDownEdit.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText
        '
        'txtDownEdit
        '
        Me.txtDownEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        resources.ApplyResources(Me.txtDownEdit, "txtDownEdit")
        Me.txtDownEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtDownEdit.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtDownEdit.DisplayFormat.FormatString = "N2"
        Me.txtDownEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtDownEdit.EditFormat.FormatString = "N2"
        Me.txtDownEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtDownEdit.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.[Default]
        Me.txtDownEdit.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.txtDownEdit.Mask.EditMask = resources.GetString("txtDownEdit.Mask.EditMask")
        Me.txtDownEdit.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.txtDownEdit.Name = "txtDownEdit"
        Me.txtDownEdit.ValidateOnEnterKey = True
        '
        'btnSaveAs
        '
        resources.ApplyResources(Me.btnSaveAs, "btnSaveAs")
        Me.btnSaveAs.Id = 67
        Me.btnSaveAs.ImageOptions.SvgImage = CType(resources.GetObject("btnSaveAs.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnSaveAs.Name = "btnSaveAs"
        Me.btnSaveAs.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText
        '
        'btnSaveImage
        '
        resources.ApplyResources(Me.btnSaveImage, "btnSaveImage")
        Me.btnSaveImage.Enabled = False
        Me.btnSaveImage.Id = 68
        Me.btnSaveImage.ImageOptions.SvgImage = CType(resources.GetObject("btnSaveImage.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnSaveImage.Name = "btnSaveImage"
        '
        'btnClearImage
        '
        resources.ApplyResources(Me.btnClearImage, "btnClearImage")
        Me.btnClearImage.Enabled = False
        Me.btnClearImage.Id = 69
        Me.btnClearImage.ImageOptions.SvgImage = CType(resources.GetObject("btnClearImage.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnClearImage.Name = "btnClearImage"
        '
        'tbPlan
        '
        Me.tbPlan.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.tbPlan.AllowShowingWhenPopupIsOpen = True
        Me.tbPlan.ItemLinks.Add(Me.btnLeftEdit)
        Me.tbPlan.ItemLinks.Add(Me.btnRightEdit)
        Me.tbPlan.ItemLinks.Add(Me.btnProperties2, True)
        Me.tbPlan.OpacityOptions.AllowTransparency = False
        Me.tbPlan.OpacityOptions.OpacityDistance = 43
        Me.tbPlan.OpacityOptions.TransparencyDistance = 500
        Me.tbPlan.OpacityOptions.TransparencyDistanceWhenBarHovered = 501
        Me.tbPlan.ParentControl = Me
        Me.tbPlan.RowCount = DevExpress.XtraBars.Ribbon.RibbonPageGroupItemsLayout.TwoRows
        '
        'tbProfile
        '
        Me.tbProfile.ItemLinks.Add(Me.btnUpEdit)
        Me.tbProfile.ItemLinks.Add(Me.btnDownEdit)
        Me.tbProfile.ItemLinks.Add(Me.btnProperties2, True)
        Me.tbProfile.OpacityOptions.AllowTransparency = False
        Me.tbProfile.ParentControl = Me
        '
        'pageMain
        '
        Me.pageMain.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.grpFile, Me.grpCommands, Me.grpIntegration})
        Me.pageMain.Name = "pageMain"
        resources.ApplyResources(Me.pageMain, "pageMain")
        '
        'grpFile
        '
        Me.grpFile.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.[False]
        Me.grpFile.ItemLinks.Add(Me.btnNew)
        Me.grpFile.ItemLinks.Add(Me.btnLoad)
        Me.grpFile.ItemLinks.Add(Me.btnSave)
        Me.grpFile.ItemLinks.Add(Me.btnSaveAs)
        Me.grpFile.ItemLinks.Add(Me.btnOptions, True)
        Me.grpFile.Name = "grpFile"
        resources.ApplyResources(Me.grpFile, "grpFile")
        '
        'grpCommands
        '
        Me.grpCommands.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.[False]
        Me.grpCommands.ItemLinks.Add(Me.btnLoadImage)
        Me.grpCommands.ItemLinks.Add(Me.btnCalculate, True)
        Me.grpCommands.ItemLinks.Add(Me.btnExport, True)
        Me.grpCommands.Name = "grpCommands"
        resources.ApplyResources(Me.grpCommands, "grpCommands")
        '
        'grpIntegration
        '
        Me.grpIntegration.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.[False]
        Me.grpIntegration.ItemLinks.Add(Me.btnConfirm)
        Me.grpIntegration.ItemLinks.Add(Me.btnClose)
        Me.grpIntegration.Name = "grpIntegration"
        resources.ApplyResources(Me.grpIntegration, "grpIntegration")
        '
        'pageImage
        '
        Me.pageImage.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.grpImageCommands, Me.grpImageColors})
        Me.pageImage.Name = "pageImage"
        resources.ApplyResources(Me.pageImage, "pageImage")
        '
        'grpImageCommands
        '
        Me.grpImageCommands.ItemLinks.Add(Me.btnLoadImage)
        Me.grpImageCommands.ItemLinks.Add(Me.btnSaveImage)
        Me.grpImageCommands.ItemLinks.Add(Me.btnClearImage)
        Me.grpImageCommands.Name = "grpImageCommands"
        resources.ApplyResources(Me.grpImageCommands, "grpImageCommands")
        '
        'grpImageColors
        '
        Me.grpImageColors.Enabled = False
        Me.grpImageColors.ItemLinks.Add(Me.btnImageInvertColor)
        Me.grpImageColors.ItemLinks.Add(Me.btnImageToGrayScale)
        Me.grpImageColors.ItemLinks.Add(Me.btnImageBWThreshold)
        Me.grpImageColors.Name = "grpImageColors"
        resources.ApplyResources(Me.grpImageColors, "grpImageColors")
        '
        'pageWorkflow
        '
        Me.pageWorkflow.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.grpView, Me.grpStations, Me.grpPlaceholders, Me.grpLinks, Me.grpWorkflowCommands})
        Me.pageWorkflow.Name = "pageWorkflow"
        resources.ApplyResources(Me.pageWorkflow, "pageWorkflow")
        '
        'grpView
        '
        Me.grpView.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.[False]
        Me.grpView.ItemLinks.Add(Me.btnZoomIn, True)
        Me.grpView.ItemLinks.Add(Me.btnZoomOut)
        Me.grpView.ItemLinks.Add(Me.btnZoomToFit)
        Me.grpView.ItemLinks.Add(Me.btnShowRulers, True)
        Me.grpView.ItemLinks.Add(Me.btnShowRuler)
        Me.grpView.ItemLinks.Add(Me.btnMagnifier, True)
        Me.grpView.Name = "grpView"
        resources.ApplyResources(Me.grpView, "grpView")
        '
        'grpStations
        '
        Me.grpStations.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.[False]
        Me.grpStations.ItemLinks.Add(Me.btnSetOrigin2)
        Me.grpStations.ItemLinks.Add(Me.btnProperties2)
        Me.grpStations.ItemLinks.Add(Me.btnDelete2, True)
        Me.grpStations.ItemLinks.Add(Me.btnDeleteAll2, True)
        Me.grpStations.Name = "grpStations"
        resources.ApplyResources(Me.grpStations, "grpStations")
        '
        'grpPlaceholders
        '
        Me.grpPlaceholders.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.[False]
        Me.grpPlaceholders.ItemLinks.Add(Me.btnVisible)
        Me.grpPlaceholders.ItemLinks.Add(Me.btnRulerCenterHere, True)
        Me.grpPlaceholders.ItemLinks.Add(Me.btnRemove2, True)
        Me.grpPlaceholders.ItemLinks.Add(Me.btnRemoveAll2, True)
        Me.grpPlaceholders.Name = "grpPlaceholders"
        resources.ApplyResources(Me.grpPlaceholders, "grpPlaceholders")
        '
        'grpLinks
        '
        Me.grpLinks.ItemLinks.Add(Me.btnRulerAlignTo)
        Me.grpLinks.ItemLinks.Add(Me.btnDeleteLink, True)
        Me.grpLinks.Name = "grpLinks"
        resources.ApplyResources(Me.grpLinks, "grpLinks")
        '
        'grpWorkflowCommands
        '
        Me.grpWorkflowCommands.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.[False]
        Me.grpWorkflowCommands.ItemLinks.Add(Me.btnCalculate)
        Me.grpWorkflowCommands.Name = "grpWorkflowCommands"
        resources.ApplyResources(Me.grpWorkflowCommands, "grpWorkflowCommands")
        '
        'RibbonStatusBar1
        '
        Me.RibbonStatusBar1.ItemLinks.Add(Me.pnlStatus)
        Me.RibbonStatusBar1.ItemLinks.Add(Me.pnlCurrentProjection, True)
        Me.RibbonStatusBar1.ItemLinks.Add(Me.pnlCoordinates, True)
        Me.RibbonStatusBar1.ItemLinks.Add(Me.pnlDistance, True)
        Me.RibbonStatusBar1.ItemLinks.Add(Me.pnlAngle, True)
        Me.RibbonStatusBar1.ItemLinks.Add(Me.pnlZoom)
        Me.RibbonStatusBar1.ItemLinks.Add(Me.btnZoom25)
        Me.RibbonStatusBar1.ItemLinks.Add(Me.btnZoom50)
        Me.RibbonStatusBar1.ItemLinks.Add(Me.btnZoom100)
        Me.RibbonStatusBar1.ItemLinks.Add(Me.btnZoom200)
        resources.ApplyResources(Me.RibbonStatusBar1, "RibbonStatusBar1")
        Me.RibbonStatusBar1.Name = "RibbonStatusBar1"
        Me.RibbonStatusBar1.Ribbon = Me.RibbonControl
        '
        'picPlan
        '
        resources.ApplyResources(Me.picPlan, "picPlan")
        Me.picPlan.Name = "picPlan"
        Me.picPlan.TabStop = False
        '
        'picProfile
        '
        resources.ApplyResources(Me.picProfile, "picProfile")
        Me.picProfile.Name = "picProfile"
        Me.picProfile.TabStop = False
        '
        'grdStations
        '
        resources.ApplyResources(Me.grdStations, "grdStations")
        Me.grdStations.MainView = Me.gridviewStations
        Me.grdStations.MenuManager = Me.RibbonControl
        Me.grdStations.Name = "grdStations"
        Me.grdStations.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridviewStations})
        '
        'gridviewStations
        '
        Me.gridviewStations.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.gridviewStations.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colPlaceholdersIcon, Me.colPlaceholdersName, Me.colPlaceholdersPlanPoint, Me.colPlaceholdersProfilePoint, Me.colPlaceholdersPlanConnectedTo, Me.colPlaceholdersProfileConnectedTo, Me.colPlaceholdersType, Me.colPlaceholdersPlanVisible, Me.colPlaceholdersProfileVisible})
        Me.gridviewStations.GridControl = Me.grdStations
        Me.gridviewStations.Name = "gridviewStations"
        Me.gridviewStations.OptionsCustomization.AllowGroup = False
        Me.gridviewStations.OptionsSelection.MultiSelect = True
        Me.gridviewStations.OptionsView.ColumnAutoWidth = False
        Me.gridviewStations.OptionsView.ShowGroupPanel = False
        '
        'colPlaceholdersIcon
        '
        resources.ApplyResources(Me.colPlaceholdersIcon, "colPlaceholdersIcon")
        Me.colPlaceholdersIcon.FieldName = "FakeIconField"
        Me.colPlaceholdersIcon.MaxWidth = 12
        Me.colPlaceholdersIcon.MinWidth = 12
        Me.colPlaceholdersIcon.Name = "colPlaceholdersIcon"
        Me.colPlaceholdersIcon.OptionsColumn.AllowEdit = False
        Me.colPlaceholdersIcon.OptionsColumn.ReadOnly = True
        Me.colPlaceholdersIcon.OptionsFilter.AllowAutoFilter = False
        Me.colPlaceholdersIcon.OptionsFilter.AllowFilter = False
        Me.colPlaceholdersIcon.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        '
        'colPlaceholdersName
        '
        resources.ApplyResources(Me.colPlaceholdersName, "colPlaceholdersName")
        Me.colPlaceholdersName.FieldName = "Name"
        Me.colPlaceholdersName.Name = "colPlaceholdersName"
        Me.colPlaceholdersName.OptionsColumn.AllowEdit = False
        Me.colPlaceholdersName.OptionsColumn.ReadOnly = True
        '
        'colPlaceholdersPlanPoint
        '
        resources.ApplyResources(Me.colPlaceholdersPlanPoint, "colPlaceholdersPlanPoint")
        Me.colPlaceholdersPlanPoint.FieldName = "FakePlanPointField"
        Me.colPlaceholdersPlanPoint.Name = "colPlaceholdersPlanPoint"
        Me.colPlaceholdersPlanPoint.OptionsColumn.AllowEdit = False
        Me.colPlaceholdersPlanPoint.OptionsColumn.ReadOnly = True
        Me.colPlaceholdersPlanPoint.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        '
        'colPlaceholdersProfilePoint
        '
        resources.ApplyResources(Me.colPlaceholdersProfilePoint, "colPlaceholdersProfilePoint")
        Me.colPlaceholdersProfilePoint.FieldName = "FakeProfilePointField"
        Me.colPlaceholdersProfilePoint.Name = "colPlaceholdersProfilePoint"
        Me.colPlaceholdersProfilePoint.OptionsColumn.AllowEdit = False
        Me.colPlaceholdersProfilePoint.OptionsColumn.ReadOnly = True
        Me.colPlaceholdersProfilePoint.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        '
        'colPlaceholdersPlanConnectedTo
        '
        resources.ApplyResources(Me.colPlaceholdersPlanConnectedTo, "colPlaceholdersPlanConnectedTo")
        Me.colPlaceholdersPlanConnectedTo.FieldName = "PlanConnectedToString"
        Me.colPlaceholdersPlanConnectedTo.MinWidth = 120
        Me.colPlaceholdersPlanConnectedTo.Name = "colPlaceholdersPlanConnectedTo"
        Me.colPlaceholdersPlanConnectedTo.OptionsColumn.AllowEdit = False
        Me.colPlaceholdersPlanConnectedTo.OptionsColumn.ReadOnly = True
        '
        'colPlaceholdersProfileConnectedTo
        '
        resources.ApplyResources(Me.colPlaceholdersProfileConnectedTo, "colPlaceholdersProfileConnectedTo")
        Me.colPlaceholdersProfileConnectedTo.FieldName = "ProfileConnectedToString"
        Me.colPlaceholdersProfileConnectedTo.MinWidth = 120
        Me.colPlaceholdersProfileConnectedTo.Name = "colPlaceholdersProfileConnectedTo"
        Me.colPlaceholdersProfileConnectedTo.OptionsColumn.AllowEdit = False
        Me.colPlaceholdersProfileConnectedTo.OptionsColumn.ReadOnly = True
        '
        'colPlaceholdersType
        '
        resources.ApplyResources(Me.colPlaceholdersType, "colPlaceholdersType")
        Me.colPlaceholdersType.FieldName = "Type"
        Me.colPlaceholdersType.Name = "colPlaceholdersType"
        Me.colPlaceholdersType.OptionsColumn.AllowEdit = False
        Me.colPlaceholdersType.OptionsColumn.ReadOnly = True
        '
        'colPlaceholdersPlanVisible
        '
        resources.ApplyResources(Me.colPlaceholdersPlanVisible, "colPlaceholdersPlanVisible")
        Me.colPlaceholdersPlanVisible.FieldName = "PlanVisible"
        Me.colPlaceholdersPlanVisible.MaxWidth = 24
        Me.colPlaceholdersPlanVisible.MinWidth = 24
        Me.colPlaceholdersPlanVisible.Name = "colPlaceholdersPlanVisible"
        '
        'colPlaceholdersProfileVisible
        '
        resources.ApplyResources(Me.colPlaceholdersProfileVisible, "colPlaceholdersProfileVisible")
        Me.colPlaceholdersProfileVisible.FieldName = "ProfileVisible"
        Me.colPlaceholdersProfileVisible.MaxWidth = 24
        Me.colPlaceholdersProfileVisible.MinWidth = 24
        Me.colPlaceholdersProfileVisible.Name = "colPlaceholdersProfileVisible"
        '
        'pnlPlan
        '
        resources.ApplyResources(Me.pnlPlan, "pnlPlan")
        Me.pnlPlan.Controls.Add(Me.picPlan)
        Me.pnlPlan.Name = "pnlPlan"
        '
        'mnuPanel
        '
        Me.mnuPanel.ItemLinks.Add(Me.btnLoadImage)
        Me.mnuPanel.Name = "mnuPanel"
        Me.mnuPanel.Ribbon = Me.RibbonControl
        '
        'pnlProfile
        '
        resources.ApplyResources(Me.pnlProfile, "pnlProfile")
        Me.pnlProfile.Controls.Add(Me.picProfile)
        Me.pnlProfile.Name = "pnlProfile"
        '
        'pnlPopup
        '
        Me.pnlPopup.Controls.Add(Me.btnPopupClose)
        Me.pnlPopup.Controls.Add(Me.lblPopupWarning)
        Me.pnlPopup.Controls.Add(Me.picPopupWarning)
        resources.ApplyResources(Me.pnlPopup, "pnlPopup")
        Me.pnlPopup.Name = "pnlPopup"
        '
        'btnPopupClose
        '
        resources.ApplyResources(Me.btnPopupClose, "btnPopupClose")
        Me.btnPopupClose.ImageOptions.SvgImage = CType(resources.GetObject("btnPopupClose.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnPopupClose.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.btnPopupClose.Name = "btnPopupClose"
        Me.btnPopupClose.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        '
        'lblPopupWarning
        '
        resources.ApplyResources(Me.lblPopupWarning, "lblPopupWarning")
        Me.lblPopupWarning.Name = "lblPopupWarning"
        '
        'picPopupWarning
        '
        resources.ApplyResources(Me.picPopupWarning, "picPopupWarning")
        Me.picPopupWarning.Name = "picPopupWarning"
        Me.picPopupWarning.TabStop = False
        '
        'imlPopup
        '
        Me.imlPopup.ImageStream = CType(resources.GetObject("imlPopup.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlPopup.TransparentColor = System.Drawing.Color.Transparent
        Me.imlPopup.Images.SetKeyName(0, "warning")
        Me.imlPopup.Images.SetKeyName(1, "calculate")
        Me.imlPopup.Images.SetKeyName(2, "error")
        '
        'mnuDesign
        '
        Me.mnuDesign.ItemLinks.Add(Me.btnAdd2)
        Me.mnuDesign.ItemLinks.Add(Me.btnDelete2, True)
        Me.mnuDesign.ItemLinks.Add(Me.btnRemove2, True)
        Me.mnuDesign.ItemLinks.Add(Me.btnDeleteLink, True)
        Me.mnuDesign.ItemLinks.Add(Me.btnSetOrigin2, True)
        Me.mnuDesign.ItemLinks.Add(Me.btnProperties2)
        Me.mnuDesign.Name = "mnuDesign"
        Me.mnuDesign.Ribbon = Me.RibbonControl
        '
        'DockManager
        '
        Me.DockManager.DockingOptions.AllowDockToCenter = DevExpress.Utils.DefaultBoolean.[True]
        Me.DockManager.DockingOptions.DockPanelInCaptionRegion = DevExpress.Utils.DefaultBoolean.[True]
        Me.DockManager.DockingOptions.ShowAutoHideButton = False
        Me.DockManager.DockingOptions.ShowCloseButton = False
        Me.DockManager.DockingOptions.ShowMaximizeButton = False
        Me.DockManager.Form = Me
        Me.DockManager.HiddenPanels.AddRange(New DevExpress.XtraBars.Docking.DockPanel() {Me.dockMagnifier})
        Me.DockManager.MenuManager = Me.RibbonControl
        Me.DockManager.RootPanels.AddRange(New DevExpress.XtraBars.Docking.DockPanel() {Me.panelContainer1, Me.dockProfile, Me.dockPlan})
        Me.DockManager.SerializationOptions.RestoreDockPanelsText = False
        Me.DockManager.TopZIndexControls.AddRange(New String() {"DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.StatusBar", "System.Windows.Forms.MenuStrip", "System.Windows.Forms.StatusStrip", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl", "DevExpress.XtraBars.Navigation.OfficeNavigationBar", "DevExpress.XtraBars.Navigation.TileNavPane", "DevExpress.XtraBars.TabFormControl", "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl", "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl"})
        '
        'dockMagnifier
        '
        Me.dockMagnifier.Controls.Add(Me.ControlContainer2)
        Me.dockMagnifier.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom
        Me.dockMagnifier.ID = New System.Guid("c67c901b-0400-435d-9d92-58ff5729a6a2")
        resources.ApplyResources(Me.dockMagnifier, "dockMagnifier")
        Me.dockMagnifier.Name = "dockMagnifier"
        Me.dockMagnifier.Options.AllowDockAsTabbedDocument = False
        Me.dockMagnifier.Options.AllowDockBottom = False
        Me.dockMagnifier.Options.AllowDockFill = False
        Me.dockMagnifier.Options.AllowDockLeft = False
        Me.dockMagnifier.Options.AllowDockRight = False
        Me.dockMagnifier.Options.AllowDockTop = False
        Me.dockMagnifier.Options.ShowAutoHideButton = False
        Me.dockMagnifier.Options.ShowCloseButton = False
        Me.dockMagnifier.Options.ShowMaximizeButton = False
        Me.dockMagnifier.OriginalSize = New System.Drawing.Size(200, 200)
        Me.dockMagnifier.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Bottom
        Me.dockMagnifier.SavedIndex = 1
        Me.dockMagnifier.SavedParent = Me.panelContainer1
        Me.dockMagnifier.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden
        '
        'ControlContainer2
        '
        Me.ControlContainer2.Controls.Add(Me.picMagnifier)
        resources.ApplyResources(Me.ControlContainer2, "ControlContainer2")
        Me.ControlContainer2.Name = "ControlContainer2"
        '
        'picMagnifier
        '
        resources.ApplyResources(Me.picMagnifier, "picMagnifier")
        Me.picMagnifier.Name = "picMagnifier"
        Me.picMagnifier.TabStop = False
        '
        'panelContainer1
        '
        Me.panelContainer1.ActiveChild = Me.dockStations
        Me.panelContainer1.Controls.Add(Me.dockStations)
        Me.panelContainer1.Controls.Add(Me.dockPlot)
        Me.panelContainer1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right
        Me.panelContainer1.ID = New System.Guid("9d927ae8-a1f1-4c46-9e6f-3e9fdc414f65")
        resources.ApplyResources(Me.panelContainer1, "panelContainer1")
        Me.panelContainer1.Name = "panelContainer1"
        Me.panelContainer1.OriginalSize = New System.Drawing.Size(690, 200)
        Me.panelContainer1.Tabbed = True
        '
        'dockStations
        '
        Me.dockStations.Controls.Add(Me.DockPanel3_Container)
        Me.dockStations.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill
        Me.dockStations.ID = New System.Guid("2c4a71cf-7d1d-485a-96c8-3fa81686cc58")
        resources.ApplyResources(Me.dockStations, "dockStations")
        Me.dockStations.Name = "dockStations"
        Me.dockStations.Options.AllowDockAsTabbedDocument = False
        Me.dockStations.Options.ShowAutoHideButton = False
        Me.dockStations.Options.ShowCloseButton = False
        Me.dockStations.Options.ShowMaximizeButton = False
        Me.dockStations.OriginalSize = New System.Drawing.Size(415, 360)
        '
        'DockPanel3_Container
        '
        Me.DockPanel3_Container.Controls.Add(Me.grdStations)
        resources.ApplyResources(Me.DockPanel3_Container, "DockPanel3_Container")
        Me.DockPanel3_Container.Name = "DockPanel3_Container"
        '
        'dockPlot
        '
        Me.dockPlot.Controls.Add(Me.ControlContainer1)
        Me.dockPlot.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill
        Me.dockPlot.ID = New System.Guid("61910ffd-b70c-4ed0-93fa-24d8e0df3744")
        resources.ApplyResources(Me.dockPlot, "dockPlot")
        Me.dockPlot.Name = "dockPlot"
        Me.dockPlot.Options.AllowDockAsTabbedDocument = False
        Me.dockPlot.Options.ShowAutoHideButton = False
        Me.dockPlot.Options.ShowCloseButton = False
        Me.dockPlot.Options.ShowMaximizeButton = False
        Me.dockPlot.OriginalSize = New System.Drawing.Size(415, 360)
        '
        'ControlContainer1
        '
        Me.ControlContainer1.Controls.Add(Me.grdShots)
        resources.ApplyResources(Me.ControlContainer1, "ControlContainer1")
        Me.ControlContainer1.Name = "ControlContainer1"
        '
        'dockProfile
        '
        Me.dockProfile.Controls.Add(Me.DockPanel2_Container)
        Me.dockProfile.DockedAsTabbedDocument = True
        Me.dockProfile.FloatLocation = New System.Drawing.Point(295, 333)
        Me.dockProfile.FloatSize = New System.Drawing.Size(950, 359)
        Me.dockProfile.FloatVertical = True
        Me.dockProfile.ID = New System.Guid("49bff736-c58f-49d7-9cab-07efb0de2c64")
        Me.dockProfile.Name = "dockProfile"
        Me.dockProfile.Options.AllowDockBottom = False
        Me.dockProfile.Options.AllowDockFill = False
        Me.dockProfile.Options.AllowDockLeft = False
        Me.dockProfile.Options.AllowDockRight = False
        Me.dockProfile.Options.AllowDockTop = False
        Me.dockProfile.Options.FloatOnDblClick = False
        Me.dockProfile.Options.ShowAutoHideButton = False
        Me.dockProfile.Options.ShowCloseButton = False
        Me.dockProfile.OriginalSize = New System.Drawing.Size(950, 359)
        Me.dockProfile.SavedIndex = 1
        Me.dockProfile.SavedMdiDocument = True
        resources.ApplyResources(Me.dockProfile, "dockProfile")
        '
        'DockPanel2_Container
        '
        Me.DockPanel2_Container.Controls.Add(Me.pnlProfile)
        resources.ApplyResources(Me.DockPanel2_Container, "DockPanel2_Container")
        Me.DockPanel2_Container.Name = "DockPanel2_Container"
        '
        'dockPlan
        '
        Me.dockPlan.Controls.Add(Me.DockPanel1_Container)
        Me.dockPlan.DockedAsTabbedDocument = True
        Me.dockPlan.FloatLocation = New System.Drawing.Point(251, 334)
        Me.dockPlan.FloatSize = New System.Drawing.Size(956, 200)
        Me.dockPlan.ID = New System.Guid("6f61ce63-4703-43d5-8dc5-cb89adbf616f")
        Me.dockPlan.Name = "dockPlan"
        Me.dockPlan.Options.AllowDockBottom = False
        Me.dockPlan.Options.AllowDockFill = False
        Me.dockPlan.Options.AllowDockLeft = False
        Me.dockPlan.Options.AllowDockRight = False
        Me.dockPlan.Options.AllowDockTop = False
        Me.dockPlan.Options.FloatOnDblClick = False
        Me.dockPlan.Options.ShowAutoHideButton = False
        Me.dockPlan.Options.ShowCloseButton = False
        Me.dockPlan.OriginalSize = New System.Drawing.Size(956, 200)
        Me.dockPlan.SavedIndex = 2
        Me.dockPlan.SavedMdiDocument = True
        resources.ApplyResources(Me.dockPlan, "dockPlan")
        '
        'DockPanel1_Container
        '
        Me.DockPanel1_Container.Controls.Add(Me.pnlPlan)
        resources.ApplyResources(Me.DockPanel1_Container, "DockPanel1_Container")
        Me.DockPanel1_Container.Name = "DockPanel1_Container"
        '
        'DocumentManager
        '
        Me.DocumentManager.ContainerControl = Me
        Me.DocumentManager.MenuManager = Me.RibbonControl
        Me.DocumentManager.View = Me.docView
        Me.DocumentManager.ViewCollection.AddRange(New DevExpress.XtraBars.Docking2010.Views.BaseView() {Me.docView})
        '
        'docView
        '
        Me.docView.DocumentGroupProperties.ShowDocumentSelectorButton = False
        Me.docView.DocumentGroups.AddRange(New DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup() {Me.DocumentGroup1})
        Me.docView.DocumentProperties.AllowAnimation = False
        Me.docView.DocumentProperties.AllowClose = False
        Me.docView.Documents.AddRange(New DevExpress.XtraBars.Docking2010.Views.BaseDocument() {Me.docProfile, Me.docPlan})
        DockingContainer1.Element = Me.DocumentGroup1
        Me.docView.RootContainer.Nodes.AddRange(New DevExpress.XtraBars.Docking2010.Views.Tabbed.DockingContainer() {DockingContainer1})
        Me.docView.UseDocumentSelector = DevExpress.Utils.DefaultBoolean.[False]
        '
        'mnuStations
        '
        Me.mnuStations.ItemLinks.Add(Me.btnSetOrigin2, True)
        Me.mnuStations.ItemLinks.Add(Me.btnProperties2)
        Me.mnuStations.ItemLinks.Add(Me.btnRemove2, True)
        Me.mnuStations.ItemLinks.Add(Me.btnRemoveAll2)
        Me.mnuStations.ItemLinks.Add(Me.btnDelete2, True)
        Me.mnuStations.ItemLinks.Add(Me.btnDeleteAll2, True)
        Me.mnuStations.ItemLinks.Add(Me.btnVisibility, True)
        Me.mnuStations.Name = "mnuStations"
        Me.mnuStations.Ribbon = Me.RibbonControl
        '
        'mnuDesignAdd
        '
        Me.mnuDesignAdd.ItemLinks.Add(Me.btnAdd2)
        Me.mnuDesignAdd.Name = "mnuDesignAdd"
        Me.mnuDesignAdd.Ribbon = Me.RibbonControl
        '
        'mnuDesignLink
        '
        Me.mnuDesignLink.ItemLinks.Add(Me.btnDeleteLink)
        Me.mnuDesignLink.Name = "mnuDesignLink"
        Me.mnuDesignLink.Ribbon = Me.RibbonControl
        '
        'WorkspaceManager
        '
        Me.WorkspaceManager.AllowTransitionAnimation = DevExpress.Utils.DefaultBoolean.[False]
        Me.WorkspaceManager.TargetControl = Me
        Me.WorkspaceManager.TransitionType = PushTransition1
        '
        'tmrMagnifier
        '
        Me.tmrMagnifier.Interval = 500
        '
        'frmResurveyMain
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.pnlPopup)
        Me.Controls.Add(Me.panelContainer1)
        Me.Controls.Add(Me.RibbonStatusBar1)
        Me.Controls.Add(Me.RibbonControl)
        Me.IconOptions.Icon = CType(resources.GetObject("frmResurveyMain.IconOptions.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmResurveyMain"
        Me.Ribbon = Me.RibbonControl
        Me.StatusBar = Me.RibbonStatusBar1
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DocumentGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.docPlan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.docProfile, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdShots, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridviewShots, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkVisible, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trkImageBlackAndWhite, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLeftEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRightEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUpEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDownEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPlan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picProfile, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdStations, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridviewStations, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPlan.ResumeLayout(False)
        Me.pnlPlan.PerformLayout()
        CType(Me.mnuPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlProfile.ResumeLayout(False)
        Me.pnlProfile.PerformLayout()
        Me.pnlPopup.ResumeLayout(False)
        CType(Me.picPopupWarning, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mnuDesign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DockManager, System.ComponentModel.ISupportInitialize).EndInit()
        Me.dockMagnifier.ResumeLayout(False)
        Me.ControlContainer2.ResumeLayout(False)
        CType(Me.picMagnifier, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelContainer1.ResumeLayout(False)
        Me.dockStations.ResumeLayout(False)
        Me.DockPanel3_Container.ResumeLayout(False)
        Me.dockPlot.ResumeLayout(False)
        Me.ControlContainer1.ResumeLayout(False)
        Me.dockProfile.ResumeLayout(False)
        Me.DockPanel2_Container.ResumeLayout(False)
        Me.dockPlan.ResumeLayout(False)
        Me.DockPanel1_Container.ResumeLayout(False)
        CType(Me.DocumentManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.docView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mnuStations, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mnuDesignAdd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mnuDesignLink, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents picPlan As System.Windows.Forms.PictureBox
    Friend WithEvents picProfile As System.Windows.Forms.PictureBox
    Friend WithEvents pnlPopup As System.Windows.Forms.Panel
    Friend WithEvents btnPopupClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblPopupWarning As System.Windows.Forms.Label
    Friend WithEvents picPopupWarning As System.Windows.Forms.PictureBox
    Friend WithEvents imlPopup As System.Windows.Forms.ImageList
    Friend WithEvents RibbonControl As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents pageMain As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents grpFile As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents btnNew As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnLoad As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnSave As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnLoadImage As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnOptions As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnZoomIn As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnZoomOut As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnCalculate As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents grpCommands As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents grpView As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents btnExport As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnConfirm As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnClose As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents grpIntegration As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents btnShowRulers As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents btnAdd2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnRemove2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnRemoveAll2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnDelete2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnDeleteAll2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnDeleteLink As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnSetOrigin2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnProperties2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents pageWorkflow As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents grpPlaceholders As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents grpStations As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents grpWorkflowCommands As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents btnShowRuler As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents RibbonStatusBar1 As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents pnlStatus As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents pnlCurrentProjection As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents pnlCoordinates As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents pnlDistance As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents pnlAngle As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents pnlZoom As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents btnZoom100 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents grdShots As DevExpress.XtraGrid.GridControl
    Friend WithEvents gridviewShots As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colShotsFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colShotsTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colShotsDistance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colShotsBearing As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colShotsInclination As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colShotsPlanimetricDistance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colShotsDrop As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnZoomToFit As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnsZoom As DevExpress.XtraBars.BarButtonGroup
    Friend WithEvents btnZoom25 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnZoom200 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnZoom50 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents grdStations As DevExpress.XtraGrid.GridControl
    Friend WithEvents gridviewStations As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents mnuPanel As DevExpress.XtraBars.PopupMenu
    Friend WithEvents colPlaceholdersName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPlaceholdersPlanPoint As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPlaceholdersProfilePoint As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPlaceholdersType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPlaceholdersPlanConnectedTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPlaceholdersProfileConnectedTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPlaceholdersIcon As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPlaceholdersPlanVisible As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPlaceholdersProfileVisible As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents mnuDesign As DevExpress.XtraBars.PopupMenu
    Friend WithEvents DockManager As DevExpress.XtraBars.Docking.DockManager
    Friend WithEvents dockPlan As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents DockPanel1_Container As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents dockProfile As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents DockPanel2_Container As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents dockStations As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents DockPanel3_Container As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents DocumentManager As DevExpress.XtraBars.Docking2010.DocumentManager
    Friend WithEvents docView As DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView
    Friend WithEvents DocumentGroup1 As DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup
    Friend WithEvents docProfile As DevExpress.XtraBars.Docking2010.Views.Tabbed.Document
    Friend WithEvents docPlan As DevExpress.XtraBars.Docking2010.Views.Tabbed.Document
    Friend WithEvents panelContainer1 As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents dockPlot As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents ControlContainer1 As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents grpLinks As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents mnuStations As DevExpress.XtraBars.PopupMenu
    Friend WithEvents btnVisibility As DevExpress.XtraBars.BarSubItem
    Friend WithEvents btnPlanShowAll As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnPlanHideAll As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnProfileShowAll As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnProfileHideAll As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents pnlPlan As System.Windows.Forms.Panel
    Friend WithEvents pnlProfile As System.Windows.Forms.Panel
    Friend WithEvents btnVisible As DevExpress.XtraBars.BarEditItem
    Friend WithEvents chkVisible As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents btnImageInvertColor As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents grpImageColors As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents btnImageToGrayScale As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnImageBWThreshold As DevExpress.XtraBars.BarEditItem
    Friend WithEvents trkImageBlackAndWhite As DevExpress.XtraEditors.Repository.RepositoryItemTrackBar
    Friend WithEvents pageImage As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents btnRulerCenterHere As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnRulerAlignTo As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuDesignAdd As DevExpress.XtraBars.PopupMenu
    Friend WithEvents mnuDesignLink As DevExpress.XtraBars.PopupMenu
    Friend WithEvents grpImageCommands As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents WorkspaceManager As DevExpress.Utils.WorkspaceManager
    Friend WithEvents dockMagnifier As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents ControlContainer2 As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents tmrMagnifier As Timer
    Friend WithEvents picMagnifier As PictureBox
    Friend WithEvents btnMagnifier As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents colShotsLeft As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colShotsRight As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colShotsUp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colShotsDown As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colShotsUserLeft As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colShotsUserRight As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colShotsUserUp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colShotsUserDown As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnLeftEdit As DevExpress.XtraBars.BarEditItem
    Friend WithEvents txtLeftEdit As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents btnRightEdit As DevExpress.XtraBars.BarEditItem
    Friend WithEvents txtRightEdit As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents tbPlan As DevExpress.XtraBars.Ribbon.RibbonMiniToolbar
    Friend WithEvents btnUpEdit As DevExpress.XtraBars.BarEditItem
    Friend WithEvents txtUpEdit As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents btnDownEdit As DevExpress.XtraBars.BarEditItem
    Friend WithEvents txtDownEdit As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents tbProfile As DevExpress.XtraBars.Ribbon.RibbonMiniToolbar
    Friend WithEvents btnSaveAs As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnSaveImage As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnClearImage As DevExpress.XtraBars.BarButtonItem
End Class
