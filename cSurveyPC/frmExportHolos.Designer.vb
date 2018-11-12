<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExportHolos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExportHolos))
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.tipDefault = New System.Windows.Forms.ToolTip(Me.components)
        Me.chkExportSurface = New System.Windows.Forms.CheckBox()
        Me.chkExportColors = New System.Windows.Forms.CheckBox()
        Me.cboExportProfile = New System.Windows.Forms.ComboBox()
        Me.lblExportProfile = New System.Windows.Forms.Label()
        Me.chkExportLRUD = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
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
        'chkExportSurface
        '
        resources.ApplyResources(Me.chkExportSurface, "chkExportSurface")
        Me.chkExportSurface.Name = "chkExportSurface"
        Me.chkExportSurface.UseVisualStyleBackColor = True
        '
        'chkExportColors
        '
        resources.ApplyResources(Me.chkExportColors, "chkExportColors")
        Me.chkExportColors.Name = "chkExportColors"
        Me.chkExportColors.UseVisualStyleBackColor = True
        '
        'cboExportProfile
        '
        Me.cboExportProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboExportProfile.FormattingEnabled = True
        Me.cboExportProfile.Items.AddRange(New Object() {resources.GetString("cboExportProfile.Items"), resources.GetString("cboExportProfile.Items1")})
        resources.ApplyResources(Me.cboExportProfile, "cboExportProfile")
        Me.cboExportProfile.Name = "cboExportProfile"
        '
        'lblExportProfile
        '
        resources.ApplyResources(Me.lblExportProfile, "lblExportProfile")
        Me.lblExportProfile.Name = "lblExportProfile"
        '
        'chkExportLRUD
        '
        resources.ApplyResources(Me.chkExportLRUD, "chkExportLRUD")
        Me.chkExportLRUD.Name = "chkExportLRUD"
        Me.chkExportLRUD.UseVisualStyleBackColor = True
        '
        'frmExportHolos
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.chkExportLRUD)
        Me.Controls.Add(Me.lblExportProfile)
        Me.Controls.Add(Me.cboExportProfile)
        Me.Controls.Add(Me.chkExportColors)
        Me.Controls.Add(Me.chkExportSurface)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmExportHolos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents tipDefault As System.Windows.Forms.ToolTip
    Friend WithEvents chkExportSurface As System.Windows.Forms.CheckBox
    Friend WithEvents chkExportColors As System.Windows.Forms.CheckBox
    Friend WithEvents cboExportProfile As System.Windows.Forms.ComboBox
    Friend WithEvents lblExportProfile As System.Windows.Forms.Label
    Friend WithEvents chkExportLRUD As System.Windows.Forms.CheckBox
End Class
