<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQuotaProperties
    Inherits cItemPropertyControl

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmQuotaProperties))
        Me.frmScaleQuota = New DevExpress.XtraEditors.GroupControl()
        Me.Label1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtQuotaticksize = New System.Windows.Forms.NumericUpDown()
        Me.txtQuotatickfrequency = New System.Windows.Forms.NumericUpDown()
        Me.lblPlotPenWidth = New DevExpress.XtraEditors.LabelControl()
        Me.lblPlotSelectedPenWidth = New DevExpress.XtraEditors.LabelControl()
        Me.txtQuotaticklabelfrequency = New System.Windows.Forms.NumericUpDown()
        Me.frmHVQuota = New DevExpress.XtraEditors.GroupControl()
        Me.lblQuotaRightRefPercent = New DevExpress.XtraEditors.LabelControl()
        Me.txtQuotaRightRefPercent = New System.Windows.Forms.NumericUpDown()
        Me.lblQuotaCapDecoration = New DevExpress.XtraEditors.LabelControl()
        Me.lblQuotaLeftRefPercent = New DevExpress.XtraEditors.LabelControl()
        Me.txtQuotaLeftRefPercent = New System.Windows.Forms.NumericUpDown()
        Me.cboQuotaCapDecoration = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.frmAltQuota = New DevExpress.XtraEditors.GroupControl()
        Me.lblQuotaAltitudeFill = New DevExpress.XtraEditors.LabelControl()
        Me.lblQuotaAltitudeStyle = New DevExpress.XtraEditors.LabelControl()
        Me.cboQuotaAltitudeFill = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.cboQuotaAltitudeStyle = New DevExpress.XtraEditors.ComboBoxEdit()
        CType(Me.frmScaleQuota, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frmScaleQuota.SuspendLayout()
        CType(Me.txtQuotaticksize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuotatickfrequency, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuotaticklabelfrequency, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.frmHVQuota, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frmHVQuota.SuspendLayout()
        CType(Me.txtQuotaRightRefPercent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuotaLeftRefPercent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboQuotaCapDecoration.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.frmAltQuota, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frmAltQuota.SuspendLayout()
        CType(Me.cboQuotaAltitudeFill.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboQuotaAltitudeStyle.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'frmScaleQuota
        '
        Me.frmScaleQuota.Controls.Add(Me.Label1)
        Me.frmScaleQuota.Controls.Add(Me.txtQuotaticksize)
        Me.frmScaleQuota.Controls.Add(Me.txtQuotatickfrequency)
        Me.frmScaleQuota.Controls.Add(Me.lblPlotPenWidth)
        Me.frmScaleQuota.Controls.Add(Me.lblPlotSelectedPenWidth)
        Me.frmScaleQuota.Controls.Add(Me.txtQuotaticklabelfrequency)
        resources.ApplyResources(Me.frmScaleQuota, "frmScaleQuota")
        Me.frmScaleQuota.Name = "frmScaleQuota"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'txtQuotaticksize
        '
        Me.txtQuotaticksize.DecimalPlaces = 1
        Me.txtQuotaticksize.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        resources.ApplyResources(Me.txtQuotaticksize, "txtQuotaticksize")
        Me.txtQuotaticksize.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtQuotaticksize.Minimum = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.txtQuotaticksize.Name = "txtQuotaticksize"
        Me.txtQuotaticksize.Value = New Decimal(New Integer() {3, 0, 0, 65536})
        '
        'txtQuotatickfrequency
        '
        resources.ApplyResources(Me.txtQuotatickfrequency, "txtQuotatickfrequency")
        Me.txtQuotatickfrequency.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.txtQuotatickfrequency.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtQuotatickfrequency.Name = "txtQuotatickfrequency"
        Me.txtQuotatickfrequency.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblPlotPenWidth
        '
        resources.ApplyResources(Me.lblPlotPenWidth, "lblPlotPenWidth")
        Me.lblPlotPenWidth.Name = "lblPlotPenWidth"
        '
        'lblPlotSelectedPenWidth
        '
        resources.ApplyResources(Me.lblPlotSelectedPenWidth, "lblPlotSelectedPenWidth")
        Me.lblPlotSelectedPenWidth.Name = "lblPlotSelectedPenWidth"
        '
        'txtQuotaticklabelfrequency
        '
        resources.ApplyResources(Me.txtQuotaticklabelfrequency, "txtQuotaticklabelfrequency")
        Me.txtQuotaticklabelfrequency.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.txtQuotaticklabelfrequency.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtQuotaticklabelfrequency.Name = "txtQuotaticklabelfrequency"
        Me.txtQuotaticklabelfrequency.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'frmHVQuota
        '
        Me.frmHVQuota.Controls.Add(Me.lblQuotaRightRefPercent)
        Me.frmHVQuota.Controls.Add(Me.txtQuotaRightRefPercent)
        Me.frmHVQuota.Controls.Add(Me.lblQuotaCapDecoration)
        Me.frmHVQuota.Controls.Add(Me.lblQuotaLeftRefPercent)
        Me.frmHVQuota.Controls.Add(Me.txtQuotaLeftRefPercent)
        Me.frmHVQuota.Controls.Add(Me.cboQuotaCapDecoration)
        resources.ApplyResources(Me.frmHVQuota, "frmHVQuota")
        Me.frmHVQuota.Name = "frmHVQuota"
        '
        'lblQuotaRightRefPercent
        '
        resources.ApplyResources(Me.lblQuotaRightRefPercent, "lblQuotaRightRefPercent")
        Me.lblQuotaRightRefPercent.Name = "lblQuotaRightRefPercent"
        '
        'txtQuotaRightRefPercent
        '
        Me.txtQuotaRightRefPercent.DecimalPlaces = 1
        Me.txtQuotaRightRefPercent.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        resources.ApplyResources(Me.txtQuotaRightRefPercent, "txtQuotaRightRefPercent")
        Me.txtQuotaRightRefPercent.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtQuotaRightRefPercent.Name = "txtQuotaRightRefPercent"
        Me.txtQuotaRightRefPercent.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'lblQuotaCapDecoration
        '
        resources.ApplyResources(Me.lblQuotaCapDecoration, "lblQuotaCapDecoration")
        Me.lblQuotaCapDecoration.Name = "lblQuotaCapDecoration"
        '
        'lblQuotaLeftRefPercent
        '
        resources.ApplyResources(Me.lblQuotaLeftRefPercent, "lblQuotaLeftRefPercent")
        Me.lblQuotaLeftRefPercent.Name = "lblQuotaLeftRefPercent"
        '
        'txtQuotaLeftRefPercent
        '
        Me.txtQuotaLeftRefPercent.DecimalPlaces = 1
        Me.txtQuotaLeftRefPercent.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        resources.ApplyResources(Me.txtQuotaLeftRefPercent, "txtQuotaLeftRefPercent")
        Me.txtQuotaLeftRefPercent.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtQuotaLeftRefPercent.Name = "txtQuotaLeftRefPercent"
        Me.txtQuotaLeftRefPercent.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'cboQuotaCapDecoration
        '
        resources.ApplyResources(Me.cboQuotaCapDecoration, "cboQuotaCapDecoration")
        Me.cboQuotaCapDecoration.Name = "cboQuotaCapDecoration"
        Me.cboQuotaCapDecoration.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboQuotaCapDecoration.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboQuotaCapDecoration.Properties.Items.AddRange(New Object() {resources.GetString("cboQuotaCapDecoration.Properties.Items"), resources.GetString("cboQuotaCapDecoration.Properties.Items1"), resources.GetString("cboQuotaCapDecoration.Properties.Items2")})
        Me.cboQuotaCapDecoration.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'frmAltQuota
        '
        Me.frmAltQuota.Controls.Add(Me.lblQuotaAltitudeFill)
        Me.frmAltQuota.Controls.Add(Me.lblQuotaAltitudeStyle)
        Me.frmAltQuota.Controls.Add(Me.cboQuotaAltitudeFill)
        Me.frmAltQuota.Controls.Add(Me.cboQuotaAltitudeStyle)
        resources.ApplyResources(Me.frmAltQuota, "frmAltQuota")
        Me.frmAltQuota.Name = "frmAltQuota"
        '
        'lblQuotaAltitudeFill
        '
        resources.ApplyResources(Me.lblQuotaAltitudeFill, "lblQuotaAltitudeFill")
        Me.lblQuotaAltitudeFill.Name = "lblQuotaAltitudeFill"
        '
        'lblQuotaAltitudeStyle
        '
        resources.ApplyResources(Me.lblQuotaAltitudeStyle, "lblQuotaAltitudeStyle")
        Me.lblQuotaAltitudeStyle.Name = "lblQuotaAltitudeStyle"
        '
        'cboQuotaAltitudeFill
        '
        resources.ApplyResources(Me.cboQuotaAltitudeFill, "cboQuotaAltitudeFill")
        Me.cboQuotaAltitudeFill.Name = "cboQuotaAltitudeFill"
        Me.cboQuotaAltitudeFill.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboQuotaAltitudeFill.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboQuotaAltitudeFill.Properties.Items.AddRange(New Object() {resources.GetString("cboQuotaAltitudeFill.Properties.Items"), resources.GetString("cboQuotaAltitudeFill.Properties.Items1"), resources.GetString("cboQuotaAltitudeFill.Properties.Items2"), resources.GetString("cboQuotaAltitudeFill.Properties.Items3")})
        Me.cboQuotaAltitudeFill.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'cboQuotaAltitudeStyle
        '
        resources.ApplyResources(Me.cboQuotaAltitudeStyle, "cboQuotaAltitudeStyle")
        Me.cboQuotaAltitudeStyle.Name = "cboQuotaAltitudeStyle"
        Me.cboQuotaAltitudeStyle.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboQuotaAltitudeStyle.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboQuotaAltitudeStyle.Properties.Items.AddRange(New Object() {resources.GetString("cboQuotaAltitudeStyle.Properties.Items"), resources.GetString("cboQuotaAltitudeStyle.Properties.Items1"), resources.GetString("cboQuotaAltitudeStyle.Properties.Items2"), resources.GetString("cboQuotaAltitudeStyle.Properties.Items3"), resources.GetString("cboQuotaAltitudeStyle.Properties.Items4")})
        Me.cboQuotaAltitudeStyle.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'frmQuotaProperties
        '
        Me.Appearance.Options.UseFont = True
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.frmAltQuota)
        Me.Controls.Add(Me.frmHVQuota)
        Me.Controls.Add(Me.frmScaleQuota)
        Me.Name = "frmQuotaProperties"
        CType(Me.frmScaleQuota, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frmScaleQuota.ResumeLayout(False)
        Me.frmScaleQuota.PerformLayout()
        CType(Me.txtQuotaticksize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuotatickfrequency, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuotaticklabelfrequency, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.frmHVQuota, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frmHVQuota.ResumeLayout(False)
        Me.frmHVQuota.PerformLayout()
        CType(Me.txtQuotaRightRefPercent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuotaLeftRefPercent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboQuotaCapDecoration.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.frmAltQuota, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frmAltQuota.ResumeLayout(False)
        Me.frmAltQuota.PerformLayout()
        CType(Me.cboQuotaAltitudeFill.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboQuotaAltitudeStyle.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents frmScaleQuota As DevExpress.XtraEditors.GroupControl
    Friend WithEvents Label1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtQuotaticksize As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtQuotatickfrequency As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblPlotPenWidth As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPlotSelectedPenWidth As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtQuotaticklabelfrequency As System.Windows.Forms.NumericUpDown
    Friend WithEvents frmHVQuota As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblQuotaRightRefPercent As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtQuotaRightRefPercent As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblQuotaCapDecoration As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblQuotaLeftRefPercent As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtQuotaLeftRefPercent As System.Windows.Forms.NumericUpDown
    Friend WithEvents cboQuotaCapDecoration As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents frmAltQuota As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblQuotaAltitudeFill As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblQuotaAltitudeStyle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboQuotaAltitudeFill As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents cboQuotaAltitudeStyle As DevExpress.XtraEditors.ComboBoxEdit
End Class
