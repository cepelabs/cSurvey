<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSurfaceLayerProperties
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSurfaceLayerProperties))
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.frmScale = New System.Windows.Forms.GroupBox()
        Me.lblMaxScale = New System.Windows.Forms.Label()
        Me.lblMinScale = New System.Windows.Forms.Label()
        Me.chkMaxScale = New System.Windows.Forms.CheckBox()
        Me.txtMaxScale = New System.Windows.Forms.NumericUpDown()
        Me.chkMinScale = New System.Windows.Forms.CheckBox()
        Me.txtMinScale = New System.Windows.Forms.NumericUpDown()
        Me.txtTransparency = New System.Windows.Forms.NumericUpDown()
        Me.lblPropTransparency = New System.Windows.Forms.Label()
        Me.frmScale.SuspendLayout()
        CType(Me.txtMaxScale, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMinScale, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTransparency, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'frmScale
        '
        Me.frmScale.Controls.Add(Me.lblMaxScale)
        Me.frmScale.Controls.Add(Me.lblMinScale)
        Me.frmScale.Controls.Add(Me.chkMaxScale)
        Me.frmScale.Controls.Add(Me.txtMaxScale)
        Me.frmScale.Controls.Add(Me.chkMinScale)
        Me.frmScale.Controls.Add(Me.txtMinScale)
        resources.ApplyResources(Me.frmScale, "frmScale")
        Me.frmScale.Name = "frmScale"
        Me.frmScale.TabStop = False
        '
        'lblMaxScale
        '
        resources.ApplyResources(Me.lblMaxScale, "lblMaxScale")
        Me.lblMaxScale.Name = "lblMaxScale"
        '
        'lblMinScale
        '
        resources.ApplyResources(Me.lblMinScale, "lblMinScale")
        Me.lblMinScale.Name = "lblMinScale"
        '
        'chkMaxScale
        '
        resources.ApplyResources(Me.chkMaxScale, "chkMaxScale")
        Me.chkMaxScale.Name = "chkMaxScale"
        Me.chkMaxScale.UseVisualStyleBackColor = True
        '
        'txtMaxScale
        '
        resources.ApplyResources(Me.txtMaxScale, "txtMaxScale")
        Me.txtMaxScale.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.txtMaxScale.Maximum = New Decimal(New Integer() {50000, 0, 0, 0})
        Me.txtMaxScale.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtMaxScale.Name = "txtMaxScale"
        Me.txtMaxScale.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'chkMinScale
        '
        resources.ApplyResources(Me.chkMinScale, "chkMinScale")
        Me.chkMinScale.Name = "chkMinScale"
        Me.chkMinScale.UseVisualStyleBackColor = True
        '
        'txtMinScale
        '
        resources.ApplyResources(Me.txtMinScale, "txtMinScale")
        Me.txtMinScale.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.txtMinScale.Maximum = New Decimal(New Integer() {50000, 0, 0, 0})
        Me.txtMinScale.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtMinScale.Name = "txtMinScale"
        Me.txtMinScale.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'txtTransparency
        '
        resources.ApplyResources(Me.txtTransparency, "txtTransparency")
        Me.txtTransparency.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.txtTransparency.Name = "txtTransparency"
        '
        'lblPropTransparency
        '
        resources.ApplyResources(Me.lblPropTransparency, "lblPropTransparency")
        Me.lblPropTransparency.Name = "lblPropTransparency"
        '
        'frmSurfaceLayerProperties
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.txtTransparency)
        Me.Controls.Add(Me.lblPropTransparency)
        Me.Controls.Add(Me.frmScale)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSurfaceLayerProperties"
        Me.frmScale.ResumeLayout(False)
        Me.frmScale.PerformLayout()
        CType(Me.txtMaxScale, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMinScale, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTransparency, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents frmScale As System.Windows.Forms.GroupBox
    Friend WithEvents txtMinScale As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkMaxScale As System.Windows.Forms.CheckBox
    Friend WithEvents txtMaxScale As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkMinScale As System.Windows.Forms.CheckBox
    Friend WithEvents txtTransparency As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblPropTransparency As System.Windows.Forms.Label
    Friend WithEvents lblMaxScale As System.Windows.Forms.Label
    Friend WithEvents lblMinScale As System.Windows.Forms.Label
End Class
