<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cBorderFromSplay
    Inherits System.Windows.Forms.UserControl

    'UserControl esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cBorderFromSplay))
        Me.cboUseHull = New System.Windows.Forms.ComboBox()
        Me.lblUseHull = New System.Windows.Forms.Label()
        Me.cmdCreate = New System.Windows.Forms.Button()
        Me.optCaveBranch = New System.Windows.Forms.RadioButton()
        Me.optSegment = New System.Windows.Forms.RadioButton()
        Me.txtAngPrec = New System.Windows.Forms.NumericUpDown()
        Me.lblPointReductionUM = New System.Windows.Forms.Label()
        Me.lblAngPrec = New System.Windows.Forms.Label()
        Me.cboLineType = New System.Windows.Forms.ComboBox()
        Me.lblLineType = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.optAllSplays = New System.Windows.Forms.RadioButton()
        Me.optCutAndLRUD = New System.Windows.Forms.RadioButton()
        Me.pnlAllSplays = New System.Windows.Forms.Panel()
        CType(Me.txtAngPrec, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.pnlAllSplays.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboUseHull
        '
        resources.ApplyResources(Me.cboUseHull, "cboUseHull")
        Me.cboUseHull.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUseHull.FormattingEnabled = True
        Me.cboUseHull.Items.AddRange(New Object() {resources.GetString("cboUseHull.Items"), resources.GetString("cboUseHull.Items1")})
        Me.cboUseHull.Name = "cboUseHull"
        '
        'lblUseHull
        '
        resources.ApplyResources(Me.lblUseHull, "lblUseHull")
        Me.lblUseHull.Name = "lblUseHull"
        '
        'cmdCreate
        '
        resources.ApplyResources(Me.cmdCreate, "cmdCreate")
        Me.cmdCreate.Name = "cmdCreate"
        Me.cmdCreate.UseVisualStyleBackColor = True
        '
        'optCaveBranch
        '
        resources.ApplyResources(Me.optCaveBranch, "optCaveBranch")
        Me.optCaveBranch.Name = "optCaveBranch"
        Me.optCaveBranch.TabStop = True
        Me.optCaveBranch.UseVisualStyleBackColor = True
        '
        'optSegment
        '
        resources.ApplyResources(Me.optSegment, "optSegment")
        Me.optSegment.Name = "optSegment"
        Me.optSegment.TabStop = True
        Me.optSegment.UseVisualStyleBackColor = True
        '
        'txtAngPrec
        '
        resources.ApplyResources(Me.txtAngPrec, "txtAngPrec")
        Me.txtAngPrec.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.txtAngPrec.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtAngPrec.Name = "txtAngPrec"
        Me.txtAngPrec.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblPointReductionUM
        '
        resources.ApplyResources(Me.lblPointReductionUM, "lblPointReductionUM")
        Me.lblPointReductionUM.Name = "lblPointReductionUM"
        '
        'lblAngPrec
        '
        resources.ApplyResources(Me.lblAngPrec, "lblAngPrec")
        Me.lblAngPrec.Name = "lblAngPrec"
        '
        'cboLineType
        '
        resources.ApplyResources(Me.cboLineType, "cboLineType")
        Me.cboLineType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLineType.FormattingEnabled = True
        Me.cboLineType.Items.AddRange(New Object() {resources.GetString("cboLineType.Items"), resources.GetString("cboLineType.Items1")})
        Me.cboLineType.Name = "cboLineType"
        '
        'lblLineType
        '
        resources.ApplyResources(Me.lblLineType, "lblLineType")
        Me.lblLineType.Name = "lblLineType"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.optAllSplays)
        Me.Panel1.Controls.Add(Me.optCutAndLRUD)
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
        '
        'optAllSplays
        '
        resources.ApplyResources(Me.optAllSplays, "optAllSplays")
        Me.optAllSplays.Name = "optAllSplays"
        Me.optAllSplays.TabStop = True
        Me.optAllSplays.UseVisualStyleBackColor = True
        '
        'optCutAndLRUD
        '
        resources.ApplyResources(Me.optCutAndLRUD, "optCutAndLRUD")
        Me.optCutAndLRUD.Name = "optCutAndLRUD"
        Me.optCutAndLRUD.TabStop = True
        Me.optCutAndLRUD.UseVisualStyleBackColor = True
        '
        'pnlAllSplays
        '
        Me.pnlAllSplays.Controls.Add(Me.cboUseHull)
        Me.pnlAllSplays.Controls.Add(Me.cboLineType)
        Me.pnlAllSplays.Controls.Add(Me.lblUseHull)
        Me.pnlAllSplays.Controls.Add(Me.lblLineType)
        Me.pnlAllSplays.Controls.Add(Me.lblAngPrec)
        Me.pnlAllSplays.Controls.Add(Me.txtAngPrec)
        Me.pnlAllSplays.Controls.Add(Me.lblPointReductionUM)
        resources.ApplyResources(Me.pnlAllSplays, "pnlAllSplays")
        Me.pnlAllSplays.Name = "pnlAllSplays"
        '
        'cBorderFromSplay
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.optSegment)
        Me.Controls.Add(Me.optCaveBranch)
        Me.Controls.Add(Me.cmdCreate)
        Me.Controls.Add(Me.pnlAllSplays)
        Me.Name = "cBorderFromSplay"
        CType(Me.txtAngPrec, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlAllSplays.ResumeLayout(False)
        Me.pnlAllSplays.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cboUseHull As ComboBox
    Friend WithEvents lblUseHull As Label
    Friend WithEvents cmdCreate As Button
    Friend WithEvents optCaveBranch As RadioButton
    Friend WithEvents optSegment As RadioButton
    Friend WithEvents txtAngPrec As NumericUpDown
    Friend WithEvents lblPointReductionUM As Label
    Friend WithEvents lblAngPrec As Label
    Friend WithEvents cboLineType As ComboBox
    Friend WithEvents lblLineType As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents optAllSplays As RadioButton
    Friend WithEvents optCutAndLRUD As RadioButton
    Friend WithEvents pnlAllSplays As Panel
End Class
