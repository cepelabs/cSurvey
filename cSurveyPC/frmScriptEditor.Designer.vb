<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmScriptEditor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmScriptEditor))
        Me.tbMain = New System.Windows.Forms.ToolStrip()
        Me.btnNew = New System.Windows.Forms.ToolStripButton()
        Me.btnOpen = New System.Windows.Forms.ToolStripButton()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.btnSaveAs = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.cboFunctionLanguage = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCheckQuerySintax = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCleanQuerySintax = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnRun = New System.Windows.Forms.ToolStripButton()
        Me.bwScript = New System.ComponentModel.BackgroundWorker()
        Me.txtDebug = New System.Windows.Forms.RichTextBox()
        Me.txtScript = New ScintillaNET.Scintilla()
        Me.tbMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbMain
        '
        resources.ApplyResources(Me.tbMain, "tbMain")
        Me.tbMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tbMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNew, Me.btnOpen, Me.btnSave, Me.btnSaveAs, Me.ToolStripSeparator3, Me.ToolStripLabel1, Me.cboFunctionLanguage, Me.ToolStripSeparator4, Me.btnCheckQuerySintax, Me.ToolStripSeparator1, Me.btnCleanQuerySintax, Me.ToolStripSeparator2, Me.btnRun})
        Me.tbMain.Name = "tbMain"
        '
        'btnNew
        '
        Me.btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnNew, "btnNew")
        Me.btnNew.Name = "btnNew"
        '
        'btnOpen
        '
        Me.btnOpen.Image = Global.cSurveyPC.My.Resources.Resources.folder
        resources.ApplyResources(Me.btnOpen, "btnOpen")
        Me.btnOpen.Name = "btnOpen"
        '
        'btnSave
        '
        Me.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSave.Image = Global.cSurveyPC.My.Resources.Resources.disk
        resources.ApplyResources(Me.btnSave, "btnSave")
        Me.btnSave.Name = "btnSave"
        '
        'btnSaveAs
        '
        Me.btnSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSaveAs.Image = Global.cSurveyPC.My.Resources.Resources.save_as1
        resources.ApplyResources(Me.btnSaveAs, "btnSaveAs")
        Me.btnSaveAs.Name = "btnSaveAs"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        resources.ApplyResources(Me.ToolStripSeparator3, "ToolStripSeparator3")
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        resources.ApplyResources(Me.ToolStripLabel1, "ToolStripLabel1")
        '
        'cboFunctionLanguage
        '
        Me.cboFunctionLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFunctionLanguage.Items.AddRange(New Object() {resources.GetString("cboFunctionLanguage.Items"), resources.GetString("cboFunctionLanguage.Items1")})
        Me.cboFunctionLanguage.Name = "cboFunctionLanguage"
        resources.ApplyResources(Me.cboFunctionLanguage, "cboFunctionLanguage")
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        resources.ApplyResources(Me.ToolStripSeparator4, "ToolStripSeparator4")
        '
        'btnCheckQuerySintax
        '
        resources.ApplyResources(Me.btnCheckQuerySintax, "btnCheckQuerySintax")
        Me.btnCheckQuerySintax.Name = "btnCheckQuerySintax"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        '
        'btnCleanQuerySintax
        '
        resources.ApplyResources(Me.btnCleanQuerySintax, "btnCleanQuerySintax")
        Me.btnCleanQuerySintax.Name = "btnCleanQuerySintax"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        '
        'btnRun
        '
        Me.btnRun.Image = Global.cSurveyPC.My.Resources.Resources.run_macros
        resources.ApplyResources(Me.btnRun, "btnRun")
        Me.btnRun.Name = "btnRun"
        '
        'bwScript
        '
        Me.bwScript.WorkerReportsProgress = True
        Me.bwScript.WorkerSupportsCancellation = True
        '
        'txtDebug
        '
        resources.ApplyResources(Me.txtDebug, "txtDebug")
        Me.txtDebug.AutoWordSelection = True
        Me.txtDebug.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDebug.DetectUrls = False
        Me.txtDebug.HideSelection = False
        Me.txtDebug.Name = "txtDebug"
        Me.txtDebug.ReadOnly = True
        '
        'txtScript
        '
        resources.ApplyResources(Me.txtScript, "txtScript")
        Me.txtScript.Lexer = ScintillaNET.Lexer.Vb
        Me.txtScript.Name = "txtScript"
        '
        'frmScriptEditor
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.txtScript)
        Me.Controls.Add(Me.txtDebug)
        Me.Controls.Add(Me.tbMain)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmScriptEditor"
        Me.tbMain.ResumeLayout(False)
        Me.tbMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbMain As System.Windows.Forms.ToolStrip
    Friend WithEvents btnCheckQuerySintax As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCleanQuerySintax As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnRun As System.Windows.Forms.ToolStripButton
    Friend WithEvents bwScript As System.ComponentModel.BackgroundWorker
    Friend WithEvents txtDebug As System.Windows.Forms.RichTextBox
    Friend WithEvents btnOpen As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSaveAs As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cboFunctionLanguage As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtScript As ScintillaNET.Scintilla
End Class
