<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmResurveyMain
    Inherits cForm

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmResurveyMain))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.spMain = New System.Windows.Forms.SplitContainer()
        Me.pnlPlanOrProfile = New System.Windows.Forms.Panel()
        Me.pnlMain = New System.Windows.Forms.SplitContainer()
        Me.picPlan = New System.Windows.Forms.PictureBox()
        Me.mnuPreview = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuPreviewAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPreviewRemove = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPreviewRemoveAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPreviewDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPreviewDeleteAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPreviewDeleteLink = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPreviewSetOrigin = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPreviewProperties = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPreviewShowHide = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPreviewHide = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPreviewShowOnlySelected = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPreviewHideAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPreviewShowHidden = New System.Windows.Forms.ToolStripMenuItem()
        Me.picProfile = New System.Windows.Forms.PictureBox()
        Me.grdStations = New System.Windows.Forms.DataGridView()
        Me.colColor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPlanLocation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colProfileLocation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPlanNext = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colProfileNext = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mnuGridStation = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuGridStationRemove = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuGridStationDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuGridStationSetOrigin = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuGridStationProperties = New System.Windows.Forms.ToolStripMenuItem()
        Me.grdPlot = New System.Windows.Forms.DataGridView()
        Me.tbSegmentsAndTrigpoints = New System.Windows.Forms.ToolStrip()
        Me.btnStations = New System.Windows.Forms.ToolStripButton()
        Me.btnPlot = New System.Windows.Forms.ToolStripButton()
        Me.mnuTabs = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuTabsLoadImage = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlPopup = New System.Windows.Forms.Panel()
        Me.btnPopupClose = New System.Windows.Forms.Button()
        Me.lblPopupWarning = New System.Windows.Forms.Label()
        Me.picPopupWarning = New System.Windows.Forms.PictureBox()
        Me.tbMain = New System.Windows.Forms.ToolStrip()
        Me.btnNew = New System.Windows.Forms.ToolStripButton()
        Me.btnLoad = New System.Windows.Forms.ToolStripButton()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnOptions = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnLoadImage = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnPlan = New System.Windows.Forms.ToolStripButton()
        Me.btnProfile = New System.Windows.Forms.ToolStripButton()
        Me.btnBoth = New System.Windows.Forms.ToolStripButton()
        Me.btnVerticalLayout = New System.Windows.Forms.ToolStripButton()
        Me.btnHorizontalLayout = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnZoomIn = New System.Windows.Forms.ToolStripButton()
        Me.btnZoomOut = New System.Windows.Forms.ToolStripButton()
        Me.btnZoomFit = New System.Windows.Forms.ToolStripSplitButton()
        Me.btnZoomToFit1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnZoomToFit2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCalculate = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnConfirm = New System.Windows.Forms.ToolStripButton()
        Me.btnClose = New System.Windows.Forms.ToolStripButton()
        Me.sbMain = New System.Windows.Forms.StatusStrip()
        Me.pnlStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pnlCurrentProjection = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pnlCoordinates = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pnlDistance = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pnlAngle = New System.Windows.Forms.ToolStripStatusLabel()
        Me.imlPopup = New System.Windows.Forms.ImageList(Me.components)
        Me.colPlotFrom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPlotTo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPlotPlanimetricDistance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPlotDrop = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPlotDistance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPlotBearing = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPlotInclination = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sinistra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Destra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Alto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Basso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.spMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spMain.Panel1.SuspendLayout()
        Me.spMain.Panel2.SuspendLayout()
        Me.spMain.SuspendLayout()
        Me.pnlPlanOrProfile.SuspendLayout()
        CType(Me.pnlMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMain.Panel1.SuspendLayout()
        Me.pnlMain.Panel2.SuspendLayout()
        Me.pnlMain.SuspendLayout()
        CType(Me.picPlan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuPreview.SuspendLayout()
        CType(Me.picProfile, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdStations, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuGridStation.SuspendLayout()
        CType(Me.grdPlot, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbSegmentsAndTrigpoints.SuspendLayout()
        Me.mnuTabs.SuspendLayout()
        Me.pnlPopup.SuspendLayout()
        CType(Me.picPopupWarning, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbMain.SuspendLayout()
        Me.sbMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'spMain
        '
        resources.ApplyResources(Me.spMain, "spMain")
        Me.spMain.Name = "spMain"
        '
        'spMain.Panel1
        '
        Me.spMain.Panel1.Controls.Add(Me.pnlPlanOrProfile)
        '
        'spMain.Panel2
        '
        Me.spMain.Panel2.Controls.Add(Me.grdStations)
        Me.spMain.Panel2.Controls.Add(Me.grdPlot)
        Me.spMain.Panel2.Controls.Add(Me.tbSegmentsAndTrigpoints)
        '
        'pnlPlanOrProfile
        '
        Me.pnlPlanOrProfile.Controls.Add(Me.pnlMain)
        resources.ApplyResources(Me.pnlPlanOrProfile, "pnlPlanOrProfile")
        Me.pnlPlanOrProfile.Name = "pnlPlanOrProfile"
        '
        'pnlMain
        '
        Me.pnlMain.BackColor = System.Drawing.SystemColors.ControlDark
        resources.ApplyResources(Me.pnlMain, "pnlMain")
        Me.pnlMain.Name = "pnlMain"
        '
        'pnlMain.Panel1
        '
        Me.pnlMain.Panel1.Controls.Add(Me.picPlan)
        '
        'pnlMain.Panel2
        '
        Me.pnlMain.Panel2.Controls.Add(Me.picProfile)
        '
        'picPlan
        '
        Me.picPlan.BackColor = System.Drawing.SystemColors.ControlDark
        Me.picPlan.ContextMenuStrip = Me.mnuPreview
        resources.ApplyResources(Me.picPlan, "picPlan")
        Me.picPlan.Name = "picPlan"
        Me.picPlan.TabStop = False
        '
        'mnuPreview
        '
        resources.ApplyResources(Me.mnuPreview, "mnuPreview")
        Me.mnuPreview.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPreviewAdd, Me.ToolStripMenuItem1, Me.mnuPreviewRemove, Me.mnuPreviewRemoveAll, Me.ToolStripMenuItem3, Me.mnuPreviewDelete, Me.mnuPreviewDeleteAll, Me.ToolStripMenuItem5, Me.mnuPreviewDeleteLink, Me.ToolStripMenuItem2, Me.mnuPreviewSetOrigin, Me.mnuPreviewProperties, Me.ToolStripMenuItem4, Me.mnuPreviewShowHide})
        Me.mnuPreview.Name = "mnuPreview"
        '
        'mnuPreviewAdd
        '
        resources.ApplyResources(Me.mnuPreviewAdd, "mnuPreviewAdd")
        Me.mnuPreviewAdd.Name = "mnuPreviewAdd"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        '
        'mnuPreviewRemove
        '
        resources.ApplyResources(Me.mnuPreviewRemove, "mnuPreviewRemove")
        Me.mnuPreviewRemove.Name = "mnuPreviewRemove"
        '
        'mnuPreviewRemoveAll
        '
        resources.ApplyResources(Me.mnuPreviewRemoveAll, "mnuPreviewRemoveAll")
        Me.mnuPreviewRemoveAll.Name = "mnuPreviewRemoveAll"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        resources.ApplyResources(Me.ToolStripMenuItem3, "ToolStripMenuItem3")
        '
        'mnuPreviewDelete
        '
        resources.ApplyResources(Me.mnuPreviewDelete, "mnuPreviewDelete")
        Me.mnuPreviewDelete.Name = "mnuPreviewDelete"
        '
        'mnuPreviewDeleteAll
        '
        resources.ApplyResources(Me.mnuPreviewDeleteAll, "mnuPreviewDeleteAll")
        Me.mnuPreviewDeleteAll.Name = "mnuPreviewDeleteAll"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        resources.ApplyResources(Me.ToolStripMenuItem5, "ToolStripMenuItem5")
        '
        'mnuPreviewDeleteLink
        '
        Me.mnuPreviewDeleteLink.Name = "mnuPreviewDeleteLink"
        resources.ApplyResources(Me.mnuPreviewDeleteLink, "mnuPreviewDeleteLink")
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        resources.ApplyResources(Me.ToolStripMenuItem2, "ToolStripMenuItem2")
        '
        'mnuPreviewSetOrigin
        '
        Me.mnuPreviewSetOrigin.Name = "mnuPreviewSetOrigin"
        resources.ApplyResources(Me.mnuPreviewSetOrigin, "mnuPreviewSetOrigin")
        '
        'mnuPreviewProperties
        '
        resources.ApplyResources(Me.mnuPreviewProperties, "mnuPreviewProperties")
        Me.mnuPreviewProperties.Name = "mnuPreviewProperties"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        resources.ApplyResources(Me.ToolStripMenuItem4, "ToolStripMenuItem4")
        '
        'mnuPreviewShowHide
        '
        Me.mnuPreviewShowHide.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPreviewHide, Me.mnuPreviewShowOnlySelected, Me.mnuPreviewHideAll, Me.ToolStripMenuItem7, Me.mnuPreviewShowHidden})
        Me.mnuPreviewShowHide.Name = "mnuPreviewShowHide"
        resources.ApplyResources(Me.mnuPreviewShowHide, "mnuPreviewShowHide")
        '
        'mnuPreviewHide
        '
        Me.mnuPreviewHide.Name = "mnuPreviewHide"
        resources.ApplyResources(Me.mnuPreviewHide, "mnuPreviewHide")
        '
        'mnuPreviewShowOnlySelected
        '
        Me.mnuPreviewShowOnlySelected.Name = "mnuPreviewShowOnlySelected"
        resources.ApplyResources(Me.mnuPreviewShowOnlySelected, "mnuPreviewShowOnlySelected")
        '
        'mnuPreviewHideAll
        '
        Me.mnuPreviewHideAll.Name = "mnuPreviewHideAll"
        resources.ApplyResources(Me.mnuPreviewHideAll, "mnuPreviewHideAll")
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        resources.ApplyResources(Me.ToolStripMenuItem7, "ToolStripMenuItem7")
        '
        'mnuPreviewShowHidden
        '
        Me.mnuPreviewShowHidden.Name = "mnuPreviewShowHidden"
        resources.ApplyResources(Me.mnuPreviewShowHidden, "mnuPreviewShowHidden")
        '
        'picProfile
        '
        Me.picProfile.BackColor = System.Drawing.SystemColors.ControlDark
        Me.picProfile.ContextMenuStrip = Me.mnuPreview
        resources.ApplyResources(Me.picProfile, "picProfile")
        Me.picProfile.Name = "picProfile"
        Me.picProfile.TabStop = False
        '
        'grdStations
        '
        Me.grdStations.AllowUserToAddRows = False
        Me.grdStations.AllowUserToDeleteRows = False
        Me.grdStations.BackgroundColor = System.Drawing.SystemColors.Control
        Me.grdStations.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.grdStations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdStations.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colColor, Me.colStation, Me.colPlanLocation, Me.colProfileLocation, Me.colPlanNext, Me.colProfileNext, Me.colTipo})
        Me.grdStations.ContextMenuStrip = Me.mnuGridStation
        Me.grdStations.GridColor = System.Drawing.SystemColors.ControlLight
        resources.ApplyResources(Me.grdStations, "grdStations")
        Me.grdStations.MultiSelect = False
        Me.grdStations.Name = "grdStations"
        Me.grdStations.ReadOnly = True
        Me.grdStations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        '
        'colColor
        '
        resources.ApplyResources(Me.colColor, "colColor")
        Me.colColor.Name = "colColor"
        Me.colColor.ReadOnly = True
        '
        'colStation
        '
        resources.ApplyResources(Me.colStation, "colStation")
        Me.colStation.Name = "colStation"
        Me.colStation.ReadOnly = True
        '
        'colPlanLocation
        '
        resources.ApplyResources(Me.colPlanLocation, "colPlanLocation")
        Me.colPlanLocation.Name = "colPlanLocation"
        Me.colPlanLocation.ReadOnly = True
        '
        'colProfileLocation
        '
        resources.ApplyResources(Me.colProfileLocation, "colProfileLocation")
        Me.colProfileLocation.Name = "colProfileLocation"
        Me.colProfileLocation.ReadOnly = True
        '
        'colPlanNext
        '
        resources.ApplyResources(Me.colPlanNext, "colPlanNext")
        Me.colPlanNext.Name = "colPlanNext"
        Me.colPlanNext.ReadOnly = True
        '
        'colProfileNext
        '
        resources.ApplyResources(Me.colProfileNext, "colProfileNext")
        Me.colProfileNext.Name = "colProfileNext"
        Me.colProfileNext.ReadOnly = True
        '
        'colTipo
        '
        resources.ApplyResources(Me.colTipo, "colTipo")
        Me.colTipo.Name = "colTipo"
        Me.colTipo.ReadOnly = True
        '
        'mnuGridStation
        '
        resources.ApplyResources(Me.mnuGridStation, "mnuGridStation")
        Me.mnuGridStation.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuGridStationRemove, Me.ToolStripMenuItem6, Me.mnuGridStationDelete, Me.ToolStripMenuItem8, Me.mnuGridStationSetOrigin, Me.mnuGridStationProperties})
        Me.mnuGridStation.Name = "mnuGridStation"
        '
        'mnuGridStationRemove
        '
        Me.mnuGridStationRemove.Name = "mnuGridStationRemove"
        resources.ApplyResources(Me.mnuGridStationRemove, "mnuGridStationRemove")
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        resources.ApplyResources(Me.ToolStripMenuItem6, "ToolStripMenuItem6")
        '
        'mnuGridStationDelete
        '
        resources.ApplyResources(Me.mnuGridStationDelete, "mnuGridStationDelete")
        Me.mnuGridStationDelete.Name = "mnuGridStationDelete"
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        resources.ApplyResources(Me.ToolStripMenuItem8, "ToolStripMenuItem8")
        '
        'mnuGridStationSetOrigin
        '
        Me.mnuGridStationSetOrigin.Name = "mnuGridStationSetOrigin"
        resources.ApplyResources(Me.mnuGridStationSetOrigin, "mnuGridStationSetOrigin")
        '
        'mnuGridStationProperties
        '
        resources.ApplyResources(Me.mnuGridStationProperties, "mnuGridStationProperties")
        Me.mnuGridStationProperties.Name = "mnuGridStationProperties"
        '
        'grdPlot
        '
        Me.grdPlot.AllowUserToAddRows = False
        Me.grdPlot.AllowUserToDeleteRows = False
        Me.grdPlot.BackgroundColor = System.Drawing.SystemColors.Control
        Me.grdPlot.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.grdPlot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdPlot.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colPlotFrom, Me.colPlotTo, Me.colPlotPlanimetricDistance, Me.colPlotDrop, Me.colPlotDistance, Me.colPlotBearing, Me.colPlotInclination, Me.Sinistra, Me.Destra, Me.Alto, Me.Basso})
        Me.grdPlot.GridColor = System.Drawing.SystemColors.ControlLight
        resources.ApplyResources(Me.grdPlot, "grdPlot")
        Me.grdPlot.Name = "grdPlot"
        Me.grdPlot.ReadOnly = True
        Me.grdPlot.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        '
        'tbSegmentsAndTrigpoints
        '
        Me.tbSegmentsAndTrigpoints.BackColor = System.Drawing.Color.Transparent
        Me.tbSegmentsAndTrigpoints.CanOverflow = False
        resources.ApplyResources(Me.tbSegmentsAndTrigpoints, "tbSegmentsAndTrigpoints")
        Me.tbSegmentsAndTrigpoints.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tbSegmentsAndTrigpoints.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnStations, Me.btnPlot})
        Me.tbSegmentsAndTrigpoints.Name = "tbSegmentsAndTrigpoints"
        '
        'btnStations
        '
        Me.btnStations.Checked = True
        Me.btnStations.CheckState = System.Windows.Forms.CheckState.Checked
        Me.btnStations.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        resources.ApplyResources(Me.btnStations, "btnStations")
        Me.btnStations.Name = "btnStations"
        '
        'btnPlot
        '
        Me.btnPlot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        resources.ApplyResources(Me.btnPlot, "btnPlot")
        Me.btnPlot.Name = "btnPlot"
        '
        'mnuTabs
        '
        resources.ApplyResources(Me.mnuTabs, "mnuTabs")
        Me.mnuTabs.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTabsLoadImage})
        Me.mnuTabs.Name = "mnuTabs"
        '
        'mnuTabsLoadImage
        '
        resources.ApplyResources(Me.mnuTabsLoadImage, "mnuTabsLoadImage")
        Me.mnuTabsLoadImage.Name = "mnuTabsLoadImage"
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
        Me.btnPopupClose.BackColor = System.Drawing.Color.Transparent
        Me.btnPopupClose.FlatAppearance.BorderSize = 0
        Me.btnPopupClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnPopupClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnPopupClose.Image = Global.cSurveyPC.My.Resources.Resources.cross
        Me.btnPopupClose.Name = "btnPopupClose"
        Me.btnPopupClose.UseVisualStyleBackColor = False
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
        'tbMain
        '
        resources.ApplyResources(Me.tbMain, "tbMain")
        Me.tbMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNew, Me.btnLoad, Me.btnSave, Me.ToolStripSeparator5, Me.btnOptions, Me.ToolStripSeparator2, Me.btnLoadImage, Me.ToolStripSeparator7, Me.btnPlan, Me.btnProfile, Me.btnBoth, Me.btnVerticalLayout, Me.btnHorizontalLayout, Me.ToolStripSeparator6, Me.btnZoomIn, Me.btnZoomOut, Me.btnZoomFit, Me.ToolStripSeparator1, Me.btnCalculate, Me.ToolStripSeparator3, Me.btnExport, Me.ToolStripSeparator4, Me.btnConfirm, Me.btnClose})
        Me.tbMain.Name = "tbMain"
        '
        'btnNew
        '
        Me.btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnNew, "btnNew")
        Me.btnNew.Name = "btnNew"
        '
        'btnLoad
        '
        Me.btnLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnLoad, "btnLoad")
        Me.btnLoad.Name = "btnLoad"
        '
        'btnSave
        '
        Me.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnSave, "btnSave")
        Me.btnSave.Name = "btnSave"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        resources.ApplyResources(Me.ToolStripSeparator5, "ToolStripSeparator5")
        '
        'btnOptions
        '
        Me.btnOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnOptions, "btnOptions")
        Me.btnOptions.Name = "btnOptions"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        '
        'btnLoadImage
        '
        resources.ApplyResources(Me.btnLoadImage, "btnLoadImage")
        Me.btnLoadImage.Name = "btnLoadImage"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        resources.ApplyResources(Me.ToolStripSeparator7, "ToolStripSeparator7")
        '
        'btnPlan
        '
        Me.btnPlan.Checked = True
        Me.btnPlan.CheckState = System.Windows.Forms.CheckState.Checked
        Me.btnPlan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        resources.ApplyResources(Me.btnPlan, "btnPlan")
        Me.btnPlan.Name = "btnPlan"
        '
        'btnProfile
        '
        Me.btnProfile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        resources.ApplyResources(Me.btnProfile, "btnProfile")
        Me.btnProfile.Name = "btnProfile"
        '
        'btnBoth
        '
        Me.btnBoth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        resources.ApplyResources(Me.btnBoth, "btnBoth")
        Me.btnBoth.Name = "btnBoth"
        '
        'btnVerticalLayout
        '
        Me.btnVerticalLayout.Checked = True
        Me.btnVerticalLayout.CheckState = System.Windows.Forms.CheckState.Checked
        Me.btnVerticalLayout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnVerticalLayout, "btnVerticalLayout")
        Me.btnVerticalLayout.Image = Global.cSurveyPC.My.Resources.Resources.application_tile_horizontal
        Me.btnVerticalLayout.Name = "btnVerticalLayout"
        '
        'btnHorizontalLayout
        '
        Me.btnHorizontalLayout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnHorizontalLayout, "btnHorizontalLayout")
        Me.btnHorizontalLayout.Image = Global.cSurveyPC.My.Resources.Resources.application_tile_vertical
        Me.btnHorizontalLayout.Name = "btnHorizontalLayout"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        resources.ApplyResources(Me.ToolStripSeparator6, "ToolStripSeparator6")
        '
        'btnZoomIn
        '
        Me.btnZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnZoomIn.Image = Global.cSurveyPC.My.Resources.Resources.magnifier_zoom_in
        resources.ApplyResources(Me.btnZoomIn, "btnZoomIn")
        Me.btnZoomIn.Name = "btnZoomIn"
        '
        'btnZoomOut
        '
        Me.btnZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnZoomOut.Image = Global.cSurveyPC.My.Resources.Resources.magifier_zoom_out
        resources.ApplyResources(Me.btnZoomOut, "btnZoomOut")
        Me.btnZoomOut.Name = "btnZoomOut"
        '
        'btnZoomFit
        '
        Me.btnZoomFit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnZoomFit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnZoomToFit1, Me.btnZoomToFit2})
        Me.btnZoomFit.Image = Global.cSurveyPC.My.Resources.Resources.page_white_magnify
        resources.ApplyResources(Me.btnZoomFit, "btnZoomFit")
        Me.btnZoomFit.Name = "btnZoomFit"
        '
        'btnZoomToFit1
        '
        Me.btnZoomToFit1.Name = "btnZoomToFit1"
        resources.ApplyResources(Me.btnZoomToFit1, "btnZoomToFit1")
        '
        'btnZoomToFit2
        '
        Me.btnZoomToFit2.Name = "btnZoomToFit2"
        resources.ApplyResources(Me.btnZoomToFit2, "btnZoomToFit2")
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        '
        'btnCalculate
        '
        resources.ApplyResources(Me.btnCalculate, "btnCalculate")
        Me.btnCalculate.Name = "btnCalculate"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        resources.ApplyResources(Me.ToolStripSeparator3, "ToolStripSeparator3")
        '
        'btnExport
        '
        resources.ApplyResources(Me.btnExport, "btnExport")
        Me.btnExport.Name = "btnExport"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        resources.ApplyResources(Me.ToolStripSeparator4, "ToolStripSeparator4")
        '
        'btnConfirm
        '
        Me.btnConfirm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        resources.ApplyResources(Me.btnConfirm, "btnConfirm")
        Me.btnConfirm.Name = "btnConfirm"
        '
        'btnClose
        '
        Me.btnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        resources.ApplyResources(Me.btnClose, "btnClose")
        Me.btnClose.Name = "btnClose"
        '
        'sbMain
        '
        Me.sbMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.pnlStatus, Me.pnlCurrentProjection, Me.pnlCoordinates, Me.pnlDistance, Me.pnlAngle})
        resources.ApplyResources(Me.sbMain, "sbMain")
        Me.sbMain.Name = "sbMain"
        '
        'pnlStatus
        '
        Me.pnlStatus.Name = "pnlStatus"
        resources.ApplyResources(Me.pnlStatus, "pnlStatus")
        Me.pnlStatus.Spring = True
        '
        'pnlCurrentProjection
        '
        resources.ApplyResources(Me.pnlCurrentProjection, "pnlCurrentProjection")
        Me.pnlCurrentProjection.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.pnlCurrentProjection.Name = "pnlCurrentProjection"
        '
        'pnlCoordinates
        '
        resources.ApplyResources(Me.pnlCoordinates, "pnlCoordinates")
        Me.pnlCoordinates.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.pnlCoordinates.Name = "pnlCoordinates"
        '
        'pnlDistance
        '
        resources.ApplyResources(Me.pnlDistance, "pnlDistance")
        Me.pnlDistance.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.pnlDistance.Name = "pnlDistance"
        '
        'pnlAngle
        '
        resources.ApplyResources(Me.pnlAngle, "pnlAngle")
        Me.pnlAngle.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.pnlAngle.Name = "pnlAngle"
        '
        'imlPopup
        '
        Me.imlPopup.ImageStream = CType(resources.GetObject("imlPopup.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlPopup.TransparentColor = System.Drawing.Color.Transparent
        Me.imlPopup.Images.SetKeyName(0, "warning")
        Me.imlPopup.Images.SetKeyName(1, "calculate")
        Me.imlPopup.Images.SetKeyName(2, "error")
        '
        'colPlotFrom
        '
        resources.ApplyResources(Me.colPlotFrom, "colPlotFrom")
        Me.colPlotFrom.Name = "colPlotFrom"
        Me.colPlotFrom.ReadOnly = True
        '
        'colPlotTo
        '
        resources.ApplyResources(Me.colPlotTo, "colPlotTo")
        Me.colPlotTo.Name = "colPlotTo"
        Me.colPlotTo.ReadOnly = True
        '
        'colPlotPlanimetricDistance
        '
        resources.ApplyResources(Me.colPlotPlanimetricDistance, "colPlotPlanimetricDistance")
        Me.colPlotPlanimetricDistance.Name = "colPlotPlanimetricDistance"
        Me.colPlotPlanimetricDistance.ReadOnly = True
        '
        'colPlotDrop
        '
        resources.ApplyResources(Me.colPlotDrop, "colPlotDrop")
        Me.colPlotDrop.Name = "colPlotDrop"
        Me.colPlotDrop.ReadOnly = True
        '
        'colPlotDistance
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colPlotDistance.DefaultCellStyle = DataGridViewCellStyle1
        resources.ApplyResources(Me.colPlotDistance, "colPlotDistance")
        Me.colPlotDistance.Name = "colPlotDistance"
        Me.colPlotDistance.ReadOnly = True
        '
        'colPlotBearing
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colPlotBearing.DefaultCellStyle = DataGridViewCellStyle2
        resources.ApplyResources(Me.colPlotBearing, "colPlotBearing")
        Me.colPlotBearing.Name = "colPlotBearing"
        Me.colPlotBearing.ReadOnly = True
        '
        'colPlotInclination
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colPlotInclination.DefaultCellStyle = DataGridViewCellStyle3
        resources.ApplyResources(Me.colPlotInclination, "colPlotInclination")
        Me.colPlotInclination.Name = "colPlotInclination"
        Me.colPlotInclination.ReadOnly = True
        '
        'Sinistra
        '
        resources.ApplyResources(Me.Sinistra, "Sinistra")
        Me.Sinistra.Name = "Sinistra"
        Me.Sinistra.ReadOnly = True
        '
        'Destra
        '
        resources.ApplyResources(Me.Destra, "Destra")
        Me.Destra.Name = "Destra"
        Me.Destra.ReadOnly = True
        '
        'Alto
        '
        resources.ApplyResources(Me.Alto, "Alto")
        Me.Alto.Name = "Alto"
        Me.Alto.ReadOnly = True
        '
        'Basso
        '
        resources.ApplyResources(Me.Basso, "Basso")
        Me.Basso.Name = "Basso"
        Me.Basso.ReadOnly = True
        '
        'frmResurveyMain
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.spMain)
        Me.Controls.Add(Me.pnlPopup)
        Me.Controls.Add(Me.tbMain)
        Me.Controls.Add(Me.sbMain)
        Me.DoubleBuffered = True
        Me.KeyPreview = True
        Me.Name = "frmResurveyMain"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.spMain.Panel1.ResumeLayout(False)
        Me.spMain.Panel2.ResumeLayout(False)
        Me.spMain.Panel2.PerformLayout()
        CType(Me.spMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spMain.ResumeLayout(False)
        Me.pnlPlanOrProfile.ResumeLayout(False)
        Me.pnlMain.Panel1.ResumeLayout(False)
        Me.pnlMain.Panel1.PerformLayout()
        Me.pnlMain.Panel2.ResumeLayout(False)
        Me.pnlMain.Panel2.PerformLayout()
        CType(Me.pnlMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMain.ResumeLayout(False)
        CType(Me.picPlan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuPreview.ResumeLayout(False)
        CType(Me.picProfile, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdStations, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuGridStation.ResumeLayout(False)
        CType(Me.grdPlot, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbSegmentsAndTrigpoints.ResumeLayout(False)
        Me.tbSegmentsAndTrigpoints.PerformLayout()
        Me.mnuTabs.ResumeLayout(False)
        Me.pnlPopup.ResumeLayout(False)
        CType(Me.picPopupWarning, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbMain.ResumeLayout(False)
        Me.tbMain.PerformLayout()
        Me.sbMain.ResumeLayout(False)
        Me.sbMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents spMain As System.Windows.Forms.SplitContainer
    Friend WithEvents tbMain As System.Windows.Forms.ToolStrip
    Friend WithEvents grdStations As System.Windows.Forms.DataGridView
    Friend WithEvents picPlan As System.Windows.Forms.PictureBox
    Friend WithEvents picProfile As System.Windows.Forms.PictureBox
    Friend WithEvents btnLoadImage As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnLoad As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuPreview As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuPreviewAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuPreviewRemove As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPreviewRemoveAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnCalculate As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuPreviewDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPreviewDeleteAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPreviewSetOrigin As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuPreviewProperties As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents pnlPlanOrProfile As System.Windows.Forms.Panel
    Friend WithEvents sbMain As System.Windows.Forms.StatusStrip
    Friend WithEvents tbSegmentsAndTrigpoints As System.Windows.Forms.ToolStrip
    Friend WithEvents btnPlot As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnStations As System.Windows.Forms.ToolStripButton
    Friend WithEvents grdPlot As System.Windows.Forms.DataGridView
    Friend WithEvents mnuGridStation As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuGridStationDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuGridStationRemove As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuGridStationProperties As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuGridStationSetOrigin As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTabs As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuTabsLoadImage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnConfirm As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents pnlStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents pnlCoordinates As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents pnlDistance As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents pnlAngle As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnOptions As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuPreviewDeleteLink As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlPopup As System.Windows.Forms.Panel
    Friend WithEvents btnPopupClose As System.Windows.Forms.Button
    Friend WithEvents lblPopupWarning As System.Windows.Forms.Label
    Friend WithEvents picPopupWarning As System.Windows.Forms.PictureBox
    Friend WithEvents imlPopup As System.Windows.Forms.ImageList
    Friend WithEvents mnuPreviewShowHide As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPreviewHide As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPreviewShowOnlySelected As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPreviewHideAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPreviewShowHidden As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnZoomIn As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnZoomOut As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnZoomFit As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents btnZoomToFit1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnZoomToFit2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlMain As System.Windows.Forms.SplitContainer
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnPlan As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnProfile As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnBoth As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents pnlCurrentProjection As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnHorizontalLayout As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnVerticalLayout As System.Windows.Forms.ToolStripButton
    Friend WithEvents colColor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStation As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPlanLocation As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colProfileLocation As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPlanNext As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colProfileNext As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPlotFrom As DataGridViewTextBoxColumn
    Friend WithEvents colPlotTo As DataGridViewTextBoxColumn
    Friend WithEvents colPlotPlanimetricDistance As DataGridViewTextBoxColumn
    Friend WithEvents colPlotDrop As DataGridViewTextBoxColumn
    Friend WithEvents colPlotDistance As DataGridViewTextBoxColumn
    Friend WithEvents colPlotBearing As DataGridViewTextBoxColumn
    Friend WithEvents colPlotInclination As DataGridViewTextBoxColumn
    Friend WithEvents Sinistra As DataGridViewTextBoxColumn
    Friend WithEvents Destra As DataGridViewTextBoxColumn
    Friend WithEvents Alto As DataGridViewTextBoxColumn
    Friend WithEvents Basso As DataGridViewTextBoxColumn
End Class
