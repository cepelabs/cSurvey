<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmInfoEntrance
    Inherits cForm

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInfoEntrance))
        Me.cmdClose = New DevExpress.XtraEditors.SimpleButton()
        Me.pnlSurveyInfo = New DevExpress.XtraEditors.PanelControl()
        Me.lblSurveyInfoCave = New DevExpress.XtraEditors.LabelControl()
        Me.cboSurveyInfoCave = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCaveListName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtCaveListName = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
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
        Me.mnuContext = New DevExpress.XtraBars.PopupMenu(Me.components)
        CType(Me.pnlSurveyInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSurveyInfo.SuspendLayout()
        CType(Me.cboSurveyInfoCave.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCaveListName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdSurveyInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlSurveyInfo.Controls.Add(Me.lblSurveyInfoCave)
        Me.pnlSurveyInfo.Controls.Add(Me.cboSurveyInfoCave)
        Me.pnlSurveyInfo.Controls.Add(Me.grdSurveyInfo)
        Me.pnlSurveyInfo.Name = "pnlSurveyInfo"
        '
        'lblSurveyInfoCave
        '
        resources.ApplyResources(Me.lblSurveyInfoCave, "lblSurveyInfoCave")
        Me.lblSurveyInfoCave.Name = "lblSurveyInfoCave"
        '
        'cboSurveyInfoCave
        '
        resources.ApplyResources(Me.cboSurveyInfoCave, "cboSurveyInfoCave")
        Me.cboSurveyInfoCave.Name = "cboSurveyInfoCave"
        Me.cboSurveyInfoCave.Properties.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboSurveyInfoCave.Properties.Appearance.Font = CType(resources.GetObject("cboSurveyInfoCave.Properties.Appearance.Font"), System.Drawing.Font)
        Me.cboSurveyInfoCave.Properties.Appearance.Options.UseFont = True
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
        Me.GridLookUpEdit1View.OptionsView.ShowGroupPanel = False
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
        'grdSurveyInfo
        '
        resources.ApplyResources(Me.grdSurveyInfo, "grdSurveyInfo")
        Me.grdSurveyInfo.Cursor = System.Windows.Forms.Cursors.Default
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
        'mnuContext
        '
        Me.mnuContext.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnCopyValue, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnCopyValues), New DevExpress.XtraBars.LinkPersistInfo(Me.btnCopy, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnCopyAll), New DevExpress.XtraBars.LinkPersistInfo(Me.btnExport, True)})
        Me.mnuContext.Manager = Me.BarManager
        Me.mnuContext.Name = "mnuContext"
        '
        'frmInfoEntrance
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
        Me.MinimizeBox = False
        Me.Name = "frmInfoEntrance"
        CType(Me.pnlSurveyInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSurveyInfo.ResumeLayout(False)
        Me.pnlSurveyInfo.PerformLayout()
        CType(Me.cboSurveyInfoCave.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCaveListName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdSurveyInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mnuContext, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents pnlSurveyInfo As DevExpress.XtraEditors.PanelControl
    Friend WithEvents lblSurveyInfoCave As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboSurveyInfoCave As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colCaveListName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtCaveListName As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents grdSurveyInfo As cVerticalGrid
    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents btnCopyValue As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnCopyValues As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnCopyAll As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnCopy As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnExport As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuContext As DevExpress.XtraBars.PopupMenu
End Class
