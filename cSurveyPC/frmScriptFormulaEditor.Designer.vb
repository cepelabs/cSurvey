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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmScriptFormulaEditor))
        Me.tbMain = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.cboFunctionLanguage = New System.Windows.Forms.ToolStripComboBox()
        Me.btnUnboxed = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCheckQuerySintax = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCleanQuerySintax = New System.Windows.Forms.ToolStripButton()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.txtFormula = New ScintillaNET.Scintilla()
        Me.tbMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbMain
        '
        resources.ApplyResources(Me.tbMain, "tbMain")
        Me.tbMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tbMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.cboFunctionLanguage, Me.btnUnboxed, Me.ToolStripSeparator2, Me.btnCheckQuerySintax, Me.ToolStripSeparator1, Me.btnCleanQuerySintax})
        Me.tbMain.Name = "tbMain"
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
        'btnUnboxed
        '
        Me.btnUnboxed.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnUnboxed.Image = Global.cSurveyPC.My.Resources.Resources.box_closed
        resources.ApplyResources(Me.btnUnboxed, "btnUnboxed")
        Me.btnUnboxed.Name = "btnUnboxed"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
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
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'txtFormula
        '
        resources.ApplyResources(Me.txtFormula, "txtFormula")
        Me.txtFormula.Lexer = ScintillaNET.Lexer.Vb
        Me.txtFormula.Name = "txtFormula"
        '
        'frmScriptFormulaEditor
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.tbMain)
        Me.Controls.Add(Me.txtFormula)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmScriptFormulaEditor"
        Me.tbMain.ResumeLayout(False)
        Me.tbMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbMain As System.Windows.Forms.ToolStrip
    Friend WithEvents btnCheckQuerySintax As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCleanQuerySintax As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cboFunctionLanguage As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtFormula As ScintillaNET.Scintilla
    Friend WithEvents btnUnboxed As ToolStripButton
End Class
