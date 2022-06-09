<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmItemsFilter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmItemsFilter))
        Dim EditorButtonImageOptions3 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject9 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject10 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject11 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject12 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim EditorButtonImageOptions4 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject13 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject14 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject15 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject16 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.cmdApply = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.txtName = New DevExpress.XtraEditors.TextEdit()
        Me.Label6 = New DevExpress.XtraEditors.LabelControl()
        Me.cboCategories = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblPropCategory = New DevExpress.XtraEditors.LabelControl()
        Me.cboCaveList = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCaveListName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtCaveListName = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.cboCaveBranchList = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colBranchListName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtBranchListName = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.Label1 = New DevExpress.XtraEditors.LabelControl()
        Me.lblPropCave = New DevExpress.XtraEditors.LabelControl()
        Me.chkReversed = New DevExpress.XtraEditors.CheckEdit()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.tabMain = New DevExpress.XtraTab.XtraTabPage()
        Me.tabUserProperties = New DevExpress.XtraTab.XtraTabPage()
        Me.prpDataProperties = New DevExpress.XtraVerticalGrid.PropertyGridControl()
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.btnDeleteValue = New DevExpress.XtraBars.BarButtonItem()
        Me.txtReplacePath = New DevExpress.XtraEditors.Repository.RepositoryItemBreadCrumbEdit()
        Me.mnuDataProperties = New DevExpress.XtraBars.PopupMenu(Me.components)
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCategories.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCaveList.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCaveListName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCaveBranchList.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBranchListName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkReversed.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.tabMain.SuspendLayout()
        Me.tabUserProperties.SuspendLayout()
        CType(Me.prpDataProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtReplacePath, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mnuDataProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdApply
        '
        resources.ApplyResources(Me.cmdApply, "cmdApply")
        Me.cmdApply.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdApply.Name = "cmdApply"
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Name = "cmdOk"
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Name = "cmdCancel"
        '
        'txtName
        '
        resources.ApplyResources(Me.txtName, "txtName")
        Me.txtName.Name = "txtName"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'cboCategories
        '
        resources.ApplyResources(Me.cboCategories, "cboCategories")
        Me.cboCategories.Name = "cboCategories"
        Me.cboCategories.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboCategories.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboCategories.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'lblPropCategory
        '
        Me.lblPropCategory.Appearance.Font = CType(resources.GetObject("lblPropCategory.Appearance.Font"), System.Drawing.Font)
        Me.lblPropCategory.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblPropCategory, "lblPropCategory")
        Me.lblPropCategory.Name = "lblPropCategory"
        '
        'cboCaveList
        '
        resources.ApplyResources(Me.cboCaveList, "cboCaveList")
        Me.cboCaveList.Name = "cboCaveList"
        Me.cboCaveList.Properties.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboCaveList.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboCaveList.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboCaveList.Properties.DisplayMember = "ToHTMLString"
        Me.cboCaveList.Properties.NullText = resources.GetString("cboCaveList.Properties.NullText")
        Me.cboCaveList.Properties.PopupSizeable = False
        Me.cboCaveList.Properties.PopupView = Me.GridLookUpEdit1View
        Me.cboCaveList.Properties.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.txtCaveListName})
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
        'cboCaveBranchList
        '
        resources.ApplyResources(Me.cboCaveBranchList, "cboCaveBranchList")
        Me.cboCaveBranchList.Name = "cboCaveBranchList"
        Me.cboCaveBranchList.Properties.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboCaveBranchList.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboCaveBranchList.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboCaveBranchList.Properties.DisplayMember = "ToHTMLString"
        Me.cboCaveBranchList.Properties.NullText = resources.GetString("cboCaveBranchList.Properties.NullText")
        Me.cboCaveBranchList.Properties.PopupSizeable = False
        Me.cboCaveBranchList.Properties.PopupView = Me.GridView1
        Me.cboCaveBranchList.Properties.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.txtBranchListName})
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
        'Label1
        '
        Me.Label1.Appearance.Font = CType(resources.GetObject("Label1.Appearance.Font"), System.Drawing.Font)
        Me.Label1.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'lblPropCave
        '
        Me.lblPropCave.Appearance.Font = CType(resources.GetObject("lblPropCave.Appearance.Font"), System.Drawing.Font)
        Me.lblPropCave.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblPropCave, "lblPropCave")
        Me.lblPropCave.Name = "lblPropCave"
        '
        'chkReversed
        '
        resources.ApplyResources(Me.chkReversed, "chkReversed")
        Me.chkReversed.Name = "chkReversed"
        Me.chkReversed.Properties.Caption = resources.GetString("chkReversed.Properties.Caption")
        '
        'XtraTabControl1
        '
        resources.ApplyResources(Me.XtraTabControl1, "XtraTabControl1")
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.tabMain
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.tabMain, Me.tabUserProperties})
        '
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.cboCaveList)
        Me.tabMain.Controls.Add(Me.txtName)
        Me.tabMain.Controls.Add(Me.cboCaveBranchList)
        Me.tabMain.Controls.Add(Me.Label6)
        Me.tabMain.Controls.Add(Me.Label1)
        Me.tabMain.Controls.Add(Me.lblPropCategory)
        Me.tabMain.Controls.Add(Me.lblPropCave)
        Me.tabMain.Controls.Add(Me.cboCategories)
        Me.tabMain.Name = "tabMain"
        resources.ApplyResources(Me.tabMain, "tabMain")
        '
        'tabUserProperties
        '
        Me.tabUserProperties.Controls.Add(Me.prpDataProperties)
        Me.tabUserProperties.Name = "tabUserProperties"
        resources.ApplyResources(Me.tabUserProperties, "tabUserProperties")
        '
        'prpDataProperties
        '
        Me.prpDataProperties.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.prpDataProperties, "prpDataProperties")
        Me.prpDataProperties.Name = "prpDataProperties"
        Me.prpDataProperties.OptionsMenu.EnableContextMenu = False
        Me.prpDataProperties.OptionsView.ShowRootLevelIndent = False
        '
        'BarManager
        '
        Me.BarManager.DockControls.Add(Me.barDockControlTop)
        Me.BarManager.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager.DockControls.Add(Me.barDockControlRight)
        Me.BarManager.Form = Me
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnDeleteValue})
        Me.BarManager.MaxItemId = 9
        Me.BarManager.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.txtReplacePath})
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
        'btnDeleteValue
        '
        resources.ApplyResources(Me.btnDeleteValue, "btnDeleteValue")
        Me.btnDeleteValue.Id = 8
        Me.btnDeleteValue.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.delete1
        Me.btnDeleteValue.Name = "btnDeleteValue"
        '
        'txtReplacePath
        '
        Me.txtReplacePath.AllowEdit = False
        resources.ApplyResources(Me.txtReplacePath, "txtReplacePath")
        resources.ApplyResources(EditorButtonImageOptions3, "EditorButtonImageOptions3")
        resources.ApplyResources(EditorButtonImageOptions4, "EditorButtonImageOptions4")
        Me.txtReplacePath.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtReplacePath.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("txtReplacePath.Buttons1"), CType(resources.GetObject("txtReplacePath.Buttons2"), Integer), CType(resources.GetObject("txtReplacePath.Buttons3"), Boolean), CType(resources.GetObject("txtReplacePath.Buttons4"), Boolean), CType(resources.GetObject("txtReplacePath.Buttons5"), Boolean), EditorButtonImageOptions3, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject9, SerializableAppearanceObject10, SerializableAppearanceObject11, SerializableAppearanceObject12, resources.GetString("txtReplacePath.Buttons6"), CType(resources.GetObject("txtReplacePath.Buttons7"), Object), CType(resources.GetObject("txtReplacePath.Buttons8"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("txtReplacePath.Buttons9"), DevExpress.Utils.ToolTipAnchor)), New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtReplacePath.Buttons10"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("txtReplacePath.Buttons11"), CType(resources.GetObject("txtReplacePath.Buttons12"), Integer), CType(resources.GetObject("txtReplacePath.Buttons13"), Boolean), CType(resources.GetObject("txtReplacePath.Buttons14"), Boolean), CType(resources.GetObject("txtReplacePath.Buttons15"), Boolean), EditorButtonImageOptions4, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject13, SerializableAppearanceObject14, SerializableAppearanceObject15, SerializableAppearanceObject16, resources.GetString("txtReplacePath.Buttons16"), CType(resources.GetObject("txtReplacePath.Buttons17"), Object), CType(resources.GetObject("txtReplacePath.Buttons18"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("txtReplacePath.Buttons19"), DevExpress.Utils.ToolTipAnchor))})
        Me.txtReplacePath.Name = "txtReplacePath"
        Me.txtReplacePath.ShowRootGlyph = False
        '
        'mnuDataProperties
        '
        Me.mnuDataProperties.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnDeleteValue)})
        Me.mnuDataProperties.Manager = Me.BarManager
        Me.mnuDataProperties.Name = "mnuDataProperties"
        '
        'frmItemsFilter
        '
        Me.AcceptButton = Me.cmdApply
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.chkReversed)
        Me.Controls.Add(Me.cmdApply)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.IconOptions.Icon = CType(resources.GetObject("frmItemsFilter.IconOptions.Icon"), System.Drawing.Icon)
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.editfilter
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmItemsFilter"
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCategories.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCaveList.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCaveListName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCaveBranchList.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBranchListName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkReversed.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.tabMain.ResumeLayout(False)
        Me.tabMain.PerformLayout()
        Me.tabUserProperties.ResumeLayout(False)
        CType(Me.prpDataProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtReplacePath, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mnuDataProperties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdApply As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboCategories As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblPropCategory As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkReversed As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents Label1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPropCave As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboCaveList As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colCaveListName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtCaveListName As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents cboCaveBranchList As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colBranchListName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtBranchListName As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents tabMain As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tabUserProperties As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents prpDataProperties As DevExpress.XtraVerticalGrid.PropertyGridControl
    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents btnDeleteValue As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents txtReplacePath As DevExpress.XtraEditors.Repository.RepositoryItemBreadCrumbEdit
    Friend WithEvents mnuDataProperties As DevExpress.XtraBars.PopupMenu
End Class
