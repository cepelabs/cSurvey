<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmScriptFormulaEditor
    Inherits cForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmScriptFormulaEditor))
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.txtFormula = New ScintillaNET.Scintilla()
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barCode = New DevExpress.XtraBars.Bar()
        Me.btnFunctionLanguage = New DevExpress.XtraBars.BarEditItem()
        Me.cboFunctionLanguage = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.btnUnboxed = New DevExpress.XtraBars.BarCheckItem()
        Me.btnCheckQuerySintax = New DevExpress.XtraBars.BarButtonItem()
        Me.btnCleanQuerySintax = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.pnlBottom = New DevExpress.XtraEditors.PanelControl()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboFunctionLanguage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlBottom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBottom.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.Name = "cmdOk"
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Name = "cmdCancel"
        '
        'txtFormula
        '
        Me.txtFormula.BorderStyle = System.Windows.Forms.BorderStyle.None
        resources.ApplyResources(Me.txtFormula, "txtFormula")
        Me.txtFormula.Lexer = ScintillaNET.Lexer.Vb
        Me.txtFormula.Name = "txtFormula"
        '
        'BarManager
        '
        Me.BarManager.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.barCode})
        Me.BarManager.Categories.AddRange(New DevExpress.XtraBars.BarManagerCategory() {CType(resources.GetObject("BarManager.Categories"), DevExpress.XtraBars.BarManagerCategory)})
        Me.BarManager.DockControls.Add(Me.barDockControlTop)
        Me.BarManager.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager.DockControls.Add(Me.barDockControlRight)
        Me.BarManager.Form = Me
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnFunctionLanguage, Me.btnUnboxed, Me.btnCheckQuerySintax, Me.btnCleanQuerySintax})
        Me.BarManager.MaxItemId = 4
        Me.BarManager.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cboFunctionLanguage})
        '
        'barCode
        '
        Me.barCode.BarName = "Tools"
        Me.barCode.DockCol = 0
        Me.barCode.DockRow = 0
        Me.barCode.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.barCode.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnFunctionLanguage), New DevExpress.XtraBars.LinkPersistInfo(Me.btnUnboxed), New DevExpress.XtraBars.LinkPersistInfo(Me.btnCheckQuerySintax, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnCleanQuerySintax, True)})
        Me.barCode.OptionsBar.AllowQuickCustomization = False
        Me.barCode.OptionsBar.DisableClose = True
        Me.barCode.OptionsBar.DisableCustomization = True
        Me.barCode.OptionsBar.DrawBorder = False
        Me.barCode.OptionsBar.UseWholeRow = True
        resources.ApplyResources(Me.barCode, "barCode")
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
        'btnUnboxed
        '
        resources.ApplyResources(Me.btnUnboxed, "btnUnboxed")
        Me.btnUnboxed.CategoryGuid = New System.Guid("ba52e61e-15f0-44d7-b556-616beec6662c")
        Me.btnUnboxed.Id = 1
        Me.btnUnboxed.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.togglefieldcodes
        Me.btnUnboxed.Name = "btnUnboxed"
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
        'pnlBottom
        '
        Me.pnlBottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlBottom.Controls.Add(Me.cmdOk)
        Me.pnlBottom.Controls.Add(Me.cmdCancel)
        resources.ApplyResources(Me.pnlBottom, "pnlBottom")
        Me.pnlBottom.Name = "pnlBottom"
        '
        'frmScriptFormulaEditor
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.txtFormula)
        Me.Controls.Add(Me.pnlBottom)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.IconOptions.Icon = CType(resources.GetObject("frmScriptFormulaEditor.IconOptions.Icon"), System.Drawing.Icon)
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.script2
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmScriptFormulaEditor"
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboFunctionLanguage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlBottom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBottom.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtFormula As ScintillaNET.Scintilla
    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents barCode As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents pnlBottom As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnFunctionLanguage As DevExpress.XtraBars.BarEditItem
    Friend WithEvents cboFunctionLanguage As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents btnUnboxed As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents btnCheckQuerySintax As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnCleanQuerySintax As DevExpress.XtraBars.BarButtonItem
End Class
