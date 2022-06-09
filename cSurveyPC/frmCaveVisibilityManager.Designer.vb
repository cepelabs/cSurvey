<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCaveVisibilityManager
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCaveVisibilityManager))
        Me.cmdApply = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.lblProfile = New DevExpress.XtraEditors.LabelControl()
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.BarMain = New DevExpress.XtraBars.Bar()
        Me.btnAdd = New DevExpress.XtraBars.BarButtonItem()
        Me.btnAddAsCopy = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRemove = New DevExpress.XtraBars.BarButtonItem()
        Me.btnCheckQuerySintax = New DevExpress.XtraBars.BarButtonItem()
        Me.btnCleanQuerySintax = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.btnSelectAll = New DevExpress.XtraBars.BarButtonItem()
        Me.btnDeselectAll = New DevExpress.XtraBars.BarButtonItem()
        Me.btnInvertSelection = New DevExpress.XtraBars.BarButtonItem()
        Me.btnSelectCurrentCave = New DevExpress.XtraBars.BarButtonItem()
        Me.btnDeselectCurrentCave = New DevExpress.XtraBars.BarButtonItem()
        Me.tabProfile = New DevExpress.XtraTab.XtraTabControl()
        Me.tabCaveAndBranches = New DevExpress.XtraTab.XtraTabPage()
        Me.grdProfile = New cSurveyPC.cCaveBranchSelectorGrid()
        Me.tabSegment = New DevExpress.XtraTab.XtraTabPage()
        Me.txtSegments = New ScintillaNET.Scintilla()
        Me.tabItems = New DevExpress.XtraTab.XtraTabPage()
        Me.txtItems = New ScintillaNET.Scintilla()
        Me.mnuProfile = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.cboProfiles = New DevExpress.XtraEditors.ComboBoxEdit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tabProfile, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabProfile.SuspendLayout()
        Me.tabCaveAndBranches.SuspendLayout()
        Me.tabSegment.SuspendLayout()
        Me.tabItems.SuspendLayout()
        CType(Me.mnuProfile, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboProfiles.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdApply
        '
        resources.ApplyResources(Me.cmdApply, "cmdApply")
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
        'lblProfile
        '
        resources.ApplyResources(Me.lblProfile, "lblProfile")
        Me.lblProfile.Name = "lblProfile"
        '
        'BarManager
        '
        Me.BarManager.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.BarMain})
        Me.BarManager.DockControls.Add(Me.barDockControlTop)
        Me.BarManager.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager.DockControls.Add(Me.barDockControlRight)
        Me.BarManager.Form = Me
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnAdd, Me.btnRemove, Me.btnAddAsCopy, Me.btnCheckQuerySintax, Me.btnCleanQuerySintax, Me.btnSelectAll, Me.btnDeselectAll, Me.btnInvertSelection, Me.btnSelectCurrentCave, Me.btnDeselectCurrentCave})
        Me.BarManager.MaxItemId = 22
        '
        'BarMain
        '
        Me.BarMain.BarName = "Tools"
        Me.BarMain.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top
        Me.BarMain.DockCol = 0
        Me.BarMain.DockRow = 0
        Me.BarMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.BarMain.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnAdd, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnAddAsCopy), New DevExpress.XtraBars.LinkPersistInfo(Me.btnRemove, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnCheckQuerySintax, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnCleanQuerySintax, True)})
        Me.BarMain.OptionsBar.AllowQuickCustomization = False
        Me.BarMain.OptionsBar.DisableCustomization = True
        Me.BarMain.OptionsBar.DrawDragBorder = False
        Me.BarMain.OptionsBar.UseWholeRow = True
        resources.ApplyResources(Me.BarMain, "BarMain")
        '
        'btnAdd
        '
        resources.ApplyResources(Me.btnAdd, "btnAdd")
        Me.btnAdd.Id = 11
        Me.btnAdd.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.actions_add
        Me.btnAdd.Name = "btnAdd"
        '
        'btnAddAsCopy
        '
        resources.ApplyResources(Me.btnAddAsCopy, "btnAddAsCopy")
        Me.btnAddAsCopy.Enabled = False
        Me.btnAddAsCopy.Id = 13
        Me.btnAddAsCopy.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.copy
        Me.btnAddAsCopy.Name = "btnAddAsCopy"
        '
        'btnRemove
        '
        resources.ApplyResources(Me.btnRemove, "btnRemove")
        Me.btnRemove.Enabled = False
        Me.btnRemove.Id = 12
        Me.btnRemove.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.delete1
        Me.btnRemove.Name = "btnRemove"
        '
        'btnCheckQuerySintax
        '
        resources.ApplyResources(Me.btnCheckQuerySintax, "btnCheckQuerySintax")
        Me.btnCheckQuerySintax.Id = 15
        Me.btnCheckQuerySintax.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.spellcheckasyoutype
        Me.btnCheckQuerySintax.Name = "btnCheckQuerySintax"
        Me.btnCheckQuerySintax.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'btnCleanQuerySintax
        '
        resources.ApplyResources(Me.btnCleanQuerySintax, "btnCleanQuerySintax")
        Me.btnCleanQuerySintax.Id = 16
        Me.btnCleanQuerySintax.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.clearall
        Me.btnCleanQuerySintax.Name = "btnCleanQuerySintax"
        Me.btnCleanQuerySintax.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
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
        Me.btnSelectAll.Id = 17
        Me.btnSelectAll.Name = "btnSelectAll"
        '
        'btnDeselectAll
        '
        resources.ApplyResources(Me.btnDeselectAll, "btnDeselectAll")
        Me.btnDeselectAll.Id = 18
        Me.btnDeselectAll.Name = "btnDeselectAll"
        '
        'btnInvertSelection
        '
        resources.ApplyResources(Me.btnInvertSelection, "btnInvertSelection")
        Me.btnInvertSelection.Id = 19
        Me.btnInvertSelection.Name = "btnInvertSelection"
        '
        'btnSelectCurrentCave
        '
        resources.ApplyResources(Me.btnSelectCurrentCave, "btnSelectCurrentCave")
        Me.btnSelectCurrentCave.Id = 20
        Me.btnSelectCurrentCave.Name = "btnSelectCurrentCave"
        '
        'btnDeselectCurrentCave
        '
        resources.ApplyResources(Me.btnDeselectCurrentCave, "btnDeselectCurrentCave")
        Me.btnDeselectCurrentCave.Id = 21
        Me.btnDeselectCurrentCave.Name = "btnDeselectCurrentCave"
        '
        'tabProfile
        '
        resources.ApplyResources(Me.tabProfile, "tabProfile")
        Me.tabProfile.Name = "tabProfile"
        Me.tabProfile.SelectedTabPage = Me.tabCaveAndBranches
        Me.tabProfile.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.tabCaveAndBranches, Me.tabSegment, Me.tabItems})
        '
        'tabCaveAndBranches
        '
        Me.tabCaveAndBranches.Controls.Add(Me.grdProfile)
        Me.tabCaveAndBranches.Name = "tabCaveAndBranches"
        resources.ApplyResources(Me.tabCaveAndBranches, "tabCaveAndBranches")
        '
        'grdProfile
        '
        resources.ApplyResources(Me.grdProfile, "grdProfile")
        Me.grdProfile.Name = "grdProfile"
        '
        'tabSegment
        '
        Me.tabSegment.Controls.Add(Me.txtSegments)
        Me.tabSegment.Name = "tabSegment"
        Me.tabSegment.PageVisible = False
        resources.ApplyResources(Me.tabSegment, "tabSegment")
        '
        'txtSegments
        '
        Me.txtSegments.BorderStyle = System.Windows.Forms.BorderStyle.None
        resources.ApplyResources(Me.txtSegments, "txtSegments")
        Me.txtSegments.Lexer = ScintillaNET.Lexer.Vb
        Me.txtSegments.Name = "txtSegments"
        '
        'tabItems
        '
        Me.tabItems.Controls.Add(Me.txtItems)
        Me.tabItems.Name = "tabItems"
        Me.tabItems.PageVisible = False
        resources.ApplyResources(Me.tabItems, "tabItems")
        '
        'txtItems
        '
        Me.txtItems.BorderStyle = System.Windows.Forms.BorderStyle.None
        resources.ApplyResources(Me.txtItems, "txtItems")
        Me.txtItems.Lexer = ScintillaNET.Lexer.Vb
        Me.txtItems.Name = "txtItems"
        '
        'mnuProfile
        '
        Me.mnuProfile.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnSelectAll), New DevExpress.XtraBars.LinkPersistInfo(Me.btnDeselectAll), New DevExpress.XtraBars.LinkPersistInfo(Me.btnInvertSelection, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnSelectCurrentCave, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnDeselectCurrentCave)})
        Me.mnuProfile.Manager = Me.BarManager
        Me.mnuProfile.Name = "mnuProfile"
        '
        'cboProfiles
        '
        resources.ApplyResources(Me.cboProfiles, "cboProfiles")
        Me.cboProfiles.MenuManager = Me.BarManager
        Me.cboProfiles.Name = "cboProfiles"
        Me.cboProfiles.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboProfiles.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboProfiles.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'frmCaveVisibilityManager
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblProfile)
        Me.Controls.Add(Me.cmdApply)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.tabProfile)
        Me.Controls.Add(Me.cboProfiles)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.profileview
        Me.MinimizeBox = False
        Me.Name = "frmCaveVisibilityManager"
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tabProfile, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabProfile.ResumeLayout(False)
        Me.tabCaveAndBranches.ResumeLayout(False)
        Me.tabSegment.ResumeLayout(False)
        Me.tabItems.ResumeLayout(False)
        CType(Me.mnuProfile, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboProfiles.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdApply As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblProfile As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents BarMain As DevExpress.XtraBars.Bar
    Friend WithEvents btnAdd As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnRemove As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents btnAddAsCopy As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents tabProfile As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents tabCaveAndBranches As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tabSegment As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tabItems As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents btnCheckQuerySintax As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnCleanQuerySintax As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents txtSegments As ScintillaNET.Scintilla
    Friend WithEvents txtItems As ScintillaNET.Scintilla
    Friend WithEvents grdProfile As cCaveBranchSelectorGrid
    Friend WithEvents btnSelectAll As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnDeselectAll As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnInvertSelection As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnSelectCurrentCave As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnDeselectCurrentCave As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuProfile As DevExpress.XtraBars.PopupMenu
    Friend WithEvents cboProfiles As DevExpress.XtraEditors.ComboBoxEdit
End Class
