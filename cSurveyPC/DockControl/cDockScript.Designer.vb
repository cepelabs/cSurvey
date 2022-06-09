<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cDockScript
    Inherits DevExpress.XtraEditors.XtraUserControl

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cDockScript))
        Me.bwScript = New System.ComponentModel.BackgroundWorker()
        Me.txtScript = New ScintillaNET.Scintilla()
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barCode = New DevExpress.XtraBars.Bar()
        Me.btnNew = New DevExpress.XtraBars.BarButtonItem()
        Me.btnOpen = New DevExpress.XtraBars.BarButtonItem()
        Me.btnSave = New DevExpress.XtraBars.BarButtonItem()
        Me.btnSaveAs = New DevExpress.XtraBars.BarButtonItem()
        Me.btnFunctionLanguage = New DevExpress.XtraBars.BarEditItem()
        Me.cboFunctionLanguage = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.btnCheckQuerySintax = New DevExpress.XtraBars.BarButtonItem()
        Me.btnCleanQuerySintax = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRun = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.txtDebug = New DevExpress.XtraRichEdit.RichEditControl()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboFunctionLanguage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bwScript
        '
        Me.bwScript.WorkerReportsProgress = True
        Me.bwScript.WorkerSupportsCancellation = True
        '
        'txtScript
        '
        Me.txtScript.BorderStyle = System.Windows.Forms.BorderStyle.None
        resources.ApplyResources(Me.txtScript, "txtScript")
        Me.txtScript.Lexer = ScintillaNET.Lexer.Vb
        Me.txtScript.Name = "txtScript"
        '
        'BarManager
        '
        Me.BarManager.AllowCustomization = False
        Me.BarManager.AllowQuickCustomization = False
        Me.BarManager.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.barCode})
        Me.BarManager.Categories.AddRange(New DevExpress.XtraBars.BarManagerCategory() {CType(resources.GetObject("BarManager.Categories"), DevExpress.XtraBars.BarManagerCategory)})
        Me.BarManager.DockControls.Add(Me.barDockControlTop)
        Me.BarManager.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager.DockControls.Add(Me.barDockControlRight)
        Me.BarManager.Form = Me
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnFunctionLanguage, Me.btnCheckQuerySintax, Me.btnCleanQuerySintax, Me.btnRun, Me.btnNew, Me.btnOpen, Me.btnSave, Me.btnSaveAs})
        Me.BarManager.MaxItemId = 9
        Me.BarManager.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cboFunctionLanguage})
        '
        'barCode
        '
        Me.barCode.BarName = "Tools"
        Me.barCode.DockCol = 0
        Me.barCode.DockRow = 0
        Me.barCode.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.barCode.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnNew), New DevExpress.XtraBars.LinkPersistInfo(Me.btnOpen), New DevExpress.XtraBars.LinkPersistInfo(Me.btnSave), New DevExpress.XtraBars.LinkPersistInfo(Me.btnSaveAs), New DevExpress.XtraBars.LinkPersistInfo(Me.btnFunctionLanguage, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnCheckQuerySintax, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnCleanQuerySintax, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnRun, True)})
        Me.barCode.OptionsBar.AllowQuickCustomization = False
        Me.barCode.OptionsBar.DisableClose = True
        Me.barCode.OptionsBar.DisableCustomization = True
        Me.barCode.OptionsBar.DrawBorder = False
        Me.barCode.OptionsBar.UseWholeRow = True
        resources.ApplyResources(Me.barCode, "barCode")
        '
        'btnNew
        '
        resources.ApplyResources(Me.btnNew, "btnNew")
        Me.btnNew.Id = 5
        Me.btnNew.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources._new
        Me.btnNew.Name = "btnNew"
        '
        'btnOpen
        '
        resources.ApplyResources(Me.btnOpen, "btnOpen")
        Me.btnOpen.Id = 6
        Me.btnOpen.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.open
        Me.btnOpen.Name = "btnOpen"
        '
        'btnSave
        '
        resources.ApplyResources(Me.btnSave, "btnSave")
        Me.btnSave.Id = 7
        Me.btnSave.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.save
        Me.btnSave.Name = "btnSave"
        '
        'btnSaveAs
        '
        resources.ApplyResources(Me.btnSaveAs, "btnSaveAs")
        Me.btnSaveAs.Id = 8
        Me.btnSaveAs.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.saveas
        Me.btnSaveAs.Name = "btnSaveAs"
        '
        'btnFunctionLanguage
        '
        resources.ApplyResources(Me.btnFunctionLanguage, "btnFunctionLanguage")
        Me.btnFunctionLanguage.CategoryGuid = New System.Guid("ba52e61e-15f0-44d7-b556-616beec6662c")
        Me.btnFunctionLanguage.Edit = Me.cboFunctionLanguage
        Me.btnFunctionLanguage.Id = 0
        Me.btnFunctionLanguage.Name = "btnFunctionLanguage"
        Me.btnFunctionLanguage.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'cboFunctionLanguage
        '
        resources.ApplyResources(Me.cboFunctionLanguage, "cboFunctionLanguage")
        Me.cboFunctionLanguage.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboFunctionLanguage.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboFunctionLanguage.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem(resources.GetString("cboFunctionLanguage.Items"), CType(resources.GetObject("cboFunctionLanguage.Items1"), Object), CType(resources.GetObject("cboFunctionLanguage.Items2"), Integer)), New DevExpress.XtraEditors.Controls.ImageComboBoxItem(resources.GetString("cboFunctionLanguage.Items3"), CType(resources.GetObject("cboFunctionLanguage.Items4"), Object), CType(resources.GetObject("cboFunctionLanguage.Items5"), Integer))})
        Me.cboFunctionLanguage.Name = "cboFunctionLanguage"
        '
        'btnCheckQuerySintax
        '
        resources.ApplyResources(Me.btnCheckQuerySintax, "btnCheckQuerySintax")
        Me.btnCheckQuerySintax.CategoryGuid = New System.Guid("ba52e61e-15f0-44d7-b556-616beec6662c")
        Me.btnCheckQuerySintax.Id = 2
        Me.btnCheckQuerySintax.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.spellcheckasyoutype
        Me.btnCheckQuerySintax.Name = "btnCheckQuerySintax"
        '
        'btnCleanQuerySintax
        '
        resources.ApplyResources(Me.btnCleanQuerySintax, "btnCleanQuerySintax")
        Me.btnCleanQuerySintax.CategoryGuid = New System.Guid("ba52e61e-15f0-44d7-b556-616beec6662c")
        Me.btnCleanQuerySintax.Id = 3
        Me.btnCleanQuerySintax.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.clearall
        Me.btnCleanQuerySintax.Name = "btnCleanQuerySintax"
        '
        'btnRun
        '
        resources.ApplyResources(Me.btnRun, "btnRun")
        Me.btnRun.Id = 4
        Me.btnRun.ImageOptions.SvgImage = CType(resources.GetObject("btnRun.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnRun.Name = "btnRun"
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
        'txtDebug
        '
        Me.txtDebug.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple
        Me.txtDebug.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        resources.ApplyResources(Me.txtDebug, "txtDebug")
        Me.txtDebug.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Pixel
        Me.txtDebug.MenuManager = Me.BarManager
        Me.txtDebug.Name = "txtDebug"
        Me.txtDebug.ReadOnly = True
        Me.txtDebug.Views.SimpleView.AdjustColorsToSkins = True
        Me.txtDebug.Views.SimpleView.WordWrap = False
        '
        'cDockScript
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.txtScript)
        Me.Controls.Add(Me.txtDebug)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "cDockScript"
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboFunctionLanguage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bwScript As System.ComponentModel.BackgroundWorker
    Friend WithEvents txtScript As ScintillaNET.Scintilla
    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents barCode As DevExpress.XtraBars.Bar
    Friend WithEvents btnFunctionLanguage As DevExpress.XtraBars.BarEditItem
    Friend WithEvents cboFunctionLanguage As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents btnCheckQuerySintax As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnCleanQuerySintax As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnRun As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents btnNew As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnOpen As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnSave As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnSaveAs As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents txtDebug As DevExpress.XtraRichEdit.RichEditControl
End Class
