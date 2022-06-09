<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInfoCave
    Inherits cForm

    'Form overrides dispose to clean up the component list.
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInfoCave))
        Me.cmdClose = New DevExpress.XtraEditors.SimpleButton()
        Me.pnlSurveyInfo = New DevExpress.XtraEditors.PanelControl()
        Me.pnlSurvey = New DevExpress.XtraEditors.PanelControl()
        Me.lblSurveyInfoCaveBranch = New DevExpress.XtraEditors.LabelControl()
        Me.lblSurveyInfoCave = New DevExpress.XtraEditors.LabelControl()
        Me.grdSurveyInfo = New cSurveyPC.cVerticalGrid()
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.btnCopyValue = New DevExpress.XtraBars.BarButtonItem()
        Me.btnCopyValues = New DevExpress.XtraBars.BarButtonItem()
        Me.btnCopyAll = New DevExpress.XtraBars.BarButtonItem()
        Me.btnCopy = New DevExpress.XtraBars.BarButtonItem()
        Me.btnExport = New DevExpress.XtraBars.BarButtonItem()
        Me.cboSurveyInfoCave = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCaveListName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtCaveListName = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.cboSurveyInfoCaveBranch = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colBranchListName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtBranchListName = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.pnlLinkedSurveys = New DevExpress.XtraEditors.PanelControl()
        Me.lblSurveyInfoFilename = New DevExpress.XtraEditors.LabelControl()
        Me.cboSurveyInfoFilename = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.mnuSurveyInfo = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuSurveyInfoCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSurveyInfoCopyAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuSurveyInfoExport = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContext = New DevExpress.XtraBars.PopupMenu(Me.components)
        CType(Me.pnlSurveyInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSurveyInfo.SuspendLayout()
        CType(Me.pnlSurvey, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSurvey.SuspendLayout()
        CType(Me.grdSurveyInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboSurveyInfoCave.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCaveListName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboSurveyInfoCaveBranch.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBranchListName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlLinkedSurveys, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLinkedSurveys.SuspendLayout()
        CType(Me.cboSurveyInfoFilename.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuSurveyInfo.SuspendLayout()
        CType(Me.mnuContext, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdClose
        '
        resources.ApplyResources(Me.cmdClose, "cmdClose")
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Name = "cmdClose"
        '
        'pnlSurveyInfo
        '
        resources.ApplyResources(Me.pnlSurveyInfo, "pnlSurveyInfo")
        Me.pnlSurveyInfo.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlSurveyInfo.Controls.Add(Me.pnlSurvey)
        Me.pnlSurveyInfo.Controls.Add(Me.pnlLinkedSurveys)
        Me.pnlSurveyInfo.Name = "pnlSurveyInfo"
        '
        'pnlSurvey
        '
        Me.pnlSurvey.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlSurvey.Controls.Add(Me.lblSurveyInfoCaveBranch)
        Me.pnlSurvey.Controls.Add(Me.lblSurveyInfoCave)
        Me.pnlSurvey.Controls.Add(Me.grdSurveyInfo)
        Me.pnlSurvey.Controls.Add(Me.cboSurveyInfoCave)
        Me.pnlSurvey.Controls.Add(Me.cboSurveyInfoCaveBranch)
        resources.ApplyResources(Me.pnlSurvey, "pnlSurvey")
        Me.pnlSurvey.Name = "pnlSurvey"
        '
        'lblSurveyInfoCaveBranch
        '
        resources.ApplyResources(Me.lblSurveyInfoCaveBranch, "lblSurveyInfoCaveBranch")
        Me.lblSurveyInfoCaveBranch.Name = "lblSurveyInfoCaveBranch"
        '
        'lblSurveyInfoCave
        '
        resources.ApplyResources(Me.lblSurveyInfoCave, "lblSurveyInfoCave")
        Me.lblSurveyInfoCave.Name = "lblSurveyInfoCave"
        '
        'grdSurveyInfo
        '
        resources.ApplyResources(Me.grdSurveyInfo, "grdSurveyInfo")
        Me.grdSurveyInfo.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdSurveyInfo.MenuManager = Me.BarManager
        Me.grdSurveyInfo.Name = "grdSurveyInfo"
        Me.grdSurveyInfo.OptionsFilter.AllowFilter = False
        Me.grdSurveyInfo.OptionsView.AllowHtmlText = True
        Me.grdSurveyInfo.OptionsView.MinRowAutoHeight = 20
        '
        'BarManager
        '
        Me.BarManager.DockControls.Add(Me.barDockControlTop)
        Me.BarManager.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager.DockControls.Add(Me.barDockControlRight)
        Me.BarManager.Form = Me
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnCopyValue, Me.btnCopyValues, Me.btnCopyAll, Me.btnCopy, Me.btnExport})
        Me.BarManager.MaxItemId = 8
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
        'btnCopyValue
        '
        resources.ApplyResources(Me.btnCopyValue, "btnCopyValue")
        Me.btnCopyValue.Id = 3
        Me.btnCopyValue.Name = "btnCopyValue"
        '
        'btnCopyValues
        '
        resources.ApplyResources(Me.btnCopyValues, "btnCopyValues")
        Me.btnCopyValues.Id = 4
        Me.btnCopyValues.Name = "btnCopyValues"
        '
        'btnCopyAll
        '
        resources.ApplyResources(Me.btnCopyAll, "btnCopyAll")
        Me.btnCopyAll.Id = 5
        Me.btnCopyAll.Name = "btnCopyAll"
        '
        'btnCopy
        '
        resources.ApplyResources(Me.btnCopy, "btnCopy")
        Me.btnCopy.Id = 6
        Me.btnCopy.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.copy
        Me.btnCopy.Name = "btnCopy"
        '
        'btnExport
        '
        resources.ApplyResources(Me.btnExport, "btnExport")
        Me.btnExport.Id = 7
        Me.btnExport.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.exportfile
        Me.btnExport.Name = "btnExport"
        '
        'cboSurveyInfoCave
        '
        resources.ApplyResources(Me.cboSurveyInfoCave, "cboSurveyInfoCave")
        Me.cboSurveyInfoCave.Name = "cboSurveyInfoCave"
        Me.cboSurveyInfoCave.Properties.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboSurveyInfoCave.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboSurveyInfoCave.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboSurveyInfoCave.Properties.DisplayMember = "ToHTMLString"
        Me.cboSurveyInfoCave.Properties.NullText = resources.GetString("cboSurveyInfoCave.Properties.NullText")
        Me.cboSurveyInfoCave.Properties.PopupSizeable = False
        Me.cboSurveyInfoCave.Properties.PopupView = Me.GridLookUpEdit1View
        Me.cboSurveyInfoCave.Properties.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.txtCaveListName})
        '
        'GridLookUpEdit1View
        '
        Me.GridLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCaveListName})
        Me.GridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridLookUpEdit1View.Name = "GridLookUpEdit1View"
        Me.GridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridLookUpEdit1View.OptionsView.ShowColumnHeaders = False
        Me.GridLookUpEdit1View.OptionsView.ShowGroupPanel = False
        Me.GridLookUpEdit1View.OptionsView.ShowIndicator = False
        '
        'colCaveListName
        '
        resources.ApplyResources(Me.colCaveListName, "colCaveListName")
        Me.colCaveListName.ColumnEdit = Me.txtCaveListName
        Me.colCaveListName.FieldName = "ToHTMLString"
        Me.colCaveListName.Name = "colCaveListName"
        Me.colCaveListName.OptionsColumn.AllowEdit = False
        '
        'txtCaveListName
        '
        Me.txtCaveListName.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        resources.ApplyResources(Me.txtCaveListName, "txtCaveListName")
        Me.txtCaveListName.Name = "txtCaveListName"
        Me.txtCaveListName.ReadOnly = True
        '
        'cboSurveyInfoCaveBranch
        '
        resources.ApplyResources(Me.cboSurveyInfoCaveBranch, "cboSurveyInfoCaveBranch")
        Me.cboSurveyInfoCaveBranch.Name = "cboSurveyInfoCaveBranch"
        Me.cboSurveyInfoCaveBranch.Properties.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboSurveyInfoCaveBranch.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboSurveyInfoCaveBranch.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboSurveyInfoCaveBranch.Properties.DisplayMember = "ToHTMLString"
        Me.cboSurveyInfoCaveBranch.Properties.NullText = resources.GetString("cboSurveyInfoCaveBranch.Properties.NullText")
        Me.cboSurveyInfoCaveBranch.Properties.PopupSizeable = False
        Me.cboSurveyInfoCaveBranch.Properties.PopupView = Me.GridView1
        Me.cboSurveyInfoCaveBranch.Properties.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.txtBranchListName})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colBranchListName})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowColumnHeaders = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OptionsView.ShowIndicator = False
        '
        'colBranchListName
        '
        resources.ApplyResources(Me.colBranchListName, "colBranchListName")
        Me.colBranchListName.ColumnEdit = Me.txtBranchListName
        Me.colBranchListName.FieldName = "ToHTMLString"
        Me.colBranchListName.Name = "colBranchListName"
        Me.colBranchListName.OptionsColumn.AllowEdit = False
        '
        'txtBranchListName
        '
        Me.txtBranchListName.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        resources.ApplyResources(Me.txtBranchListName, "txtBranchListName")
        Me.txtBranchListName.Name = "txtBranchListName"
        Me.txtBranchListName.ReadOnly = True
        '
        'pnlLinkedSurveys
        '
        Me.pnlLinkedSurveys.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlLinkedSurveys.Controls.Add(Me.lblSurveyInfoFilename)
        Me.pnlLinkedSurveys.Controls.Add(Me.cboSurveyInfoFilename)
        resources.ApplyResources(Me.pnlLinkedSurveys, "pnlLinkedSurveys")
        Me.pnlLinkedSurveys.Name = "pnlLinkedSurveys"
        '
        'lblSurveyInfoFilename
        '
        resources.ApplyResources(Me.lblSurveyInfoFilename, "lblSurveyInfoFilename")
        Me.lblSurveyInfoFilename.Name = "lblSurveyInfoFilename"
        '
        'cboSurveyInfoFilename
        '
        resources.ApplyResources(Me.cboSurveyInfoFilename, "cboSurveyInfoFilename")
        Me.cboSurveyInfoFilename.Name = "cboSurveyInfoFilename"
        Me.cboSurveyInfoFilename.Properties.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboSurveyInfoFilename.Properties.Appearance.Font = CType(resources.GetObject("cboSurveyInfoFilename.Properties.Appearance.Font"), System.Drawing.Font)
        Me.cboSurveyInfoFilename.Properties.Appearance.Options.UseFont = True
        Me.cboSurveyInfoFilename.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboSurveyInfoFilename.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboSurveyInfoFilename.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'mnuSurveyInfo
        '
        resources.ApplyResources(Me.mnuSurveyInfo, "mnuSurveyInfo")
        Me.mnuSurveyInfo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSurveyInfoCopy, Me.mnuSurveyInfoCopyAll, Me.ToolStripMenuItem1, Me.mnuSurveyInfoExport})
        Me.mnuSurveyInfo.Name = "mnuSurveyInfo"
        '
        'mnuSurveyInfoCopy
        '
        Me.mnuSurveyInfoCopy.Image = Global.cSurveyPC.My.Resources.Resources.page_copy
        Me.mnuSurveyInfoCopy.Name = "mnuSurveyInfoCopy"
        resources.ApplyResources(Me.mnuSurveyInfoCopy, "mnuSurveyInfoCopy")
        '
        'mnuSurveyInfoCopyAll
        '
        Me.mnuSurveyInfoCopyAll.Name = "mnuSurveyInfoCopyAll"
        resources.ApplyResources(Me.mnuSurveyInfoCopyAll, "mnuSurveyInfoCopyAll")
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        '
        'mnuSurveyInfoExport
        '
        Me.mnuSurveyInfoExport.Name = "mnuSurveyInfoExport"
        resources.ApplyResources(Me.mnuSurveyInfoExport, "mnuSurveyInfoExport")
        '
        'mnuContext
        '
        Me.mnuContext.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnCopyValue, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnCopyValues), New DevExpress.XtraBars.LinkPersistInfo(Me.btnCopy, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnCopyAll), New DevExpress.XtraBars.LinkPersistInfo(Me.btnExport, True)})
        Me.mnuContext.Manager = Me.BarManager
        Me.mnuContext.Name = "mnuContext"
        '
        'frmInfoCave
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdClose
        Me.Controls.Add(Me.pnlSurveyInfo)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.about
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInfoCave"
        Me.SaveAndRestoreSettings = True
        CType(Me.pnlSurveyInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSurveyInfo.ResumeLayout(False)
        CType(Me.pnlSurvey, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSurvey.ResumeLayout(False)
        Me.pnlSurvey.PerformLayout()
        CType(Me.grdSurveyInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboSurveyInfoCave.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCaveListName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboSurveyInfoCaveBranch.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBranchListName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlLinkedSurveys, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLinkedSurveys.ResumeLayout(False)
        Me.pnlLinkedSurveys.PerformLayout()
        CType(Me.cboSurveyInfoFilename.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuSurveyInfo.ResumeLayout(False)
        CType(Me.mnuContext, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents pnlSurveyInfo As DevExpress.XtraEditors.PanelControl
    Friend WithEvents lblSurveyInfoCave As DevExpress.XtraEditors.LabelControl
    Friend WithEvents mnuSurveyInfo As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuSurveyInfoCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSurveyInfoCopyAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblSurveyInfoCaveBranch As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuSurveyInfoExport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblSurveyInfoFilename As DevExpress.XtraEditors.LabelControl
    Friend WithEvents pnlLinkedSurveys As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnlSurvey As DevExpress.XtraEditors.PanelControl
    Friend WithEvents grdSurveyInfo As cVerticalGrid
    Friend WithEvents cboSurveyInfoCave As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cboSurveyInfoCaveBranch As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cboSurveyInfoFilename As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents colCaveListName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtCaveListName As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents colBranchListName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtBranchListName As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents btnCopyValue As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnCopyValues As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnCopyAll As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnCopy As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuContext As DevExpress.XtraBars.PopupMenu
    Friend WithEvents btnExport As DevExpress.XtraBars.BarButtonItem
End Class
