<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportTherion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportTherion))
        Me.txtPrefix = New System.Windows.Forms.TextBox()
        Me.lblPrefix = New System.Windows.Forms.Label()
        Me.txtFilename = New System.Windows.Forms.TextBox()
        Me.lblFilename = New System.Windows.Forms.Label()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.tipDefault = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtCaveName = New System.Windows.Forms.TextBox()
        Me.txtTherionScaleFactor = New System.Windows.Forms.NumericUpDown()
        Me.lblCaveName = New System.Windows.Forms.Label()
        Me.chkTherionImportprofile = New System.Windows.Forms.CheckBox()
        Me.chkTherionImportplan = New System.Windows.Forms.CheckBox()
        Me.chkTherionMergeAndReorderBorders = New System.Windows.Forms.CheckBox()
        Me.chktherionConvertBezierToSpline = New System.Windows.Forms.CheckBox()
        Me.lblTherionScaleFactor = New System.Windows.Forms.Label()
        CType(Me.txtTherionScaleFactor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtPrefix
        '
        Me.txtPrefix.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        resources.ApplyResources(Me.txtPrefix, "txtPrefix")
        Me.txtPrefix.Name = "txtPrefix"
        Me.tipDefault.SetToolTip(Me.txtPrefix, resources.GetString("txtPrefix.ToolTip"))
        '
        'lblPrefix
        '
        resources.ApplyResources(Me.lblPrefix, "lblPrefix")
        Me.lblPrefix.Name = "lblPrefix"
        '
        'txtFilename
        '
        Me.txtFilename.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        resources.ApplyResources(Me.txtFilename, "txtFilename")
        Me.txtFilename.Name = "txtFilename"
        Me.txtFilename.ReadOnly = True
        Me.tipDefault.SetToolTip(Me.txtFilename, resources.GetString("txtFilename.ToolTip"))
        '
        'lblFilename
        '
        resources.ApplyResources(Me.lblFilename, "lblFilename")
        Me.lblFilename.Name = "lblFilename"
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'txtCaveName
        '
        Me.txtCaveName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        resources.ApplyResources(Me.txtCaveName, "txtCaveName")
        Me.txtCaveName.Name = "txtCaveName"
        Me.tipDefault.SetToolTip(Me.txtCaveName, resources.GetString("txtCaveName.ToolTip"))
        '
        'txtTherionScaleFactor
        '
        Me.txtTherionScaleFactor.DecimalPlaces = 2
        Me.txtTherionScaleFactor.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        resources.ApplyResources(Me.txtTherionScaleFactor, "txtTherionScaleFactor")
        Me.txtTherionScaleFactor.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.txtTherionScaleFactor.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtTherionScaleFactor.Name = "txtTherionScaleFactor"
        Me.tipDefault.SetToolTip(Me.txtTherionScaleFactor, resources.GetString("txtTherionScaleFactor.ToolTip"))
        Me.txtTherionScaleFactor.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblCaveName
        '
        resources.ApplyResources(Me.lblCaveName, "lblCaveName")
        Me.lblCaveName.Name = "lblCaveName"
        '
        'chkTherionImportprofile
        '
        resources.ApplyResources(Me.chkTherionImportprofile, "chkTherionImportprofile")
        Me.chkTherionImportprofile.Name = "chkTherionImportprofile"
        Me.chkTherionImportprofile.UseVisualStyleBackColor = True
        '
        'chkTherionImportplan
        '
        resources.ApplyResources(Me.chkTherionImportplan, "chkTherionImportplan")
        Me.chkTherionImportplan.Name = "chkTherionImportplan"
        Me.chkTherionImportplan.UseVisualStyleBackColor = True
        '
        'chkTherionMergeAndReorderBorders
        '
        resources.ApplyResources(Me.chkTherionMergeAndReorderBorders, "chkTherionMergeAndReorderBorders")
        Me.chkTherionMergeAndReorderBorders.Name = "chkTherionMergeAndReorderBorders"
        Me.chkTherionMergeAndReorderBorders.UseVisualStyleBackColor = True
        '
        'chktherionConvertBezierToSpline
        '
        resources.ApplyResources(Me.chktherionConvertBezierToSpline, "chktherionConvertBezierToSpline")
        Me.chktherionConvertBezierToSpline.Name = "chktherionConvertBezierToSpline"
        Me.chktherionConvertBezierToSpline.UseVisualStyleBackColor = True
        '
        'lblTherionScaleFactor
        '
        resources.ApplyResources(Me.lblTherionScaleFactor, "lblTherionScaleFactor")
        Me.lblTherionScaleFactor.Name = "lblTherionScaleFactor"
        '
        'frmImportTherion
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.lblTherionScaleFactor)
        Me.Controls.Add(Me.txtTherionScaleFactor)
        Me.Controls.Add(Me.chktherionConvertBezierToSpline)
        Me.Controls.Add(Me.chkTherionMergeAndReorderBorders)
        Me.Controls.Add(Me.chkTherionImportprofile)
        Me.Controls.Add(Me.chkTherionImportplan)
        Me.Controls.Add(Me.txtCaveName)
        Me.Controls.Add(Me.lblCaveName)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.txtFilename)
        Me.Controls.Add(Me.lblFilename)
        Me.Controls.Add(Me.txtPrefix)
        Me.Controls.Add(Me.lblPrefix)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmImportTherion"
        CType(Me.txtTherionScaleFactor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPrefix As System.Windows.Forms.TextBox
    Friend WithEvents lblPrefix As System.Windows.Forms.Label
    Friend WithEvents txtFilename As System.Windows.Forms.TextBox
    Friend WithEvents lblFilename As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents tipDefault As System.Windows.Forms.ToolTip
    Friend WithEvents txtCaveName As System.Windows.Forms.TextBox
    Friend WithEvents lblCaveName As System.Windows.Forms.Label
    Friend WithEvents chkTherionImportprofile As System.Windows.Forms.CheckBox
    Friend WithEvents chkTherionImportplan As System.Windows.Forms.CheckBox
    Friend WithEvents chkTherionMergeAndReorderBorders As System.Windows.Forms.CheckBox
    Friend WithEvents chktherionConvertBezierToSpline As System.Windows.Forms.CheckBox
    Friend WithEvents lblTherionScaleFactor As System.Windows.Forms.Label
    Friend WithEvents txtTherionScaleFactor As System.Windows.Forms.NumericUpDown
End Class
