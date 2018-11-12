<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQuotaProperties
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmQuotaProperties))
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.frmScaleQuota = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtQuotaticksize = New System.Windows.Forms.NumericUpDown()
        Me.txtQuotatickfrequency = New System.Windows.Forms.NumericUpDown()
        Me.lblPlotPenWidth = New System.Windows.Forms.Label()
        Me.lblPlotSelectedPenWidth = New System.Windows.Forms.Label()
        Me.txtQuotaticklabelfrequency = New System.Windows.Forms.NumericUpDown()
        Me.frmHVQuota = New System.Windows.Forms.GroupBox()
        Me.cboQuotaCapDecoration = New System.Windows.Forms.ComboBox()
        Me.lblQuotaRightRefPercent = New System.Windows.Forms.Label()
        Me.txtQuotaRightRefPercent = New System.Windows.Forms.NumericUpDown()
        Me.lblQuotaCapDecoration = New System.Windows.Forms.Label()
        Me.lblQuotaLeftRefPercent = New System.Windows.Forms.Label()
        Me.txtQuotaLeftRefPercent = New System.Windows.Forms.NumericUpDown()
        Me.frmScaleQuota.SuspendLayout()
        CType(Me.txtQuotaticksize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuotatickfrequency, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuotaticklabelfrequency, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frmHVQuota.SuspendLayout()
        CType(Me.txtQuotaRightRefPercent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuotaLeftRefPercent, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(192, 273)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(80, 25)
        Me.cmdCancel.TabIndex = 1
        Me.cmdCancel.Text = "Annulla"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Location = New System.Drawing.Point(106, 273)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(80, 25)
        Me.cmdOk.TabIndex = 0
        Me.cmdOk.Text = "Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'frmScaleQuota
        '
        Me.frmScaleQuota.Controls.Add(Me.Label1)
        Me.frmScaleQuota.Controls.Add(Me.txtQuotaticksize)
        Me.frmScaleQuota.Controls.Add(Me.txtQuotatickfrequency)
        Me.frmScaleQuota.Controls.Add(Me.lblPlotPenWidth)
        Me.frmScaleQuota.Controls.Add(Me.lblPlotSelectedPenWidth)
        Me.frmScaleQuota.Controls.Add(Me.txtQuotaticklabelfrequency)
        Me.frmScaleQuota.Location = New System.Drawing.Point(12, 12)
        Me.frmScaleQuota.Name = "frmScaleQuota"
        Me.frmScaleQuota.Size = New System.Drawing.Size(260, 122)
        Me.frmScaleQuota.TabIndex = 127
        Me.frmScaleQuota.TabStop = False
        Me.frmScaleQuota.Text = "Scala verticale/orizzontale:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Lunghezza tacca (m):"
        '
        'txtQuotaticksize
        '
        Me.txtQuotaticksize.DecimalPlaces = 1
        Me.txtQuotaticksize.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.txtQuotaticksize.Location = New System.Drawing.Point(167, 78)
        Me.txtQuotaticksize.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtQuotaticksize.Name = "txtQuotaticksize"
        Me.txtQuotaticksize.Size = New System.Drawing.Size(78, 21)
        Me.txtQuotaticksize.TabIndex = 2
        Me.txtQuotaticksize.Value = New Decimal(New Integer() {3, 0, 0, 65536})
        '
        'txtQuotatickfrequency
        '
        Me.txtQuotatickfrequency.Location = New System.Drawing.Point(189, 22)
        Me.txtQuotatickfrequency.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.txtQuotatickfrequency.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtQuotatickfrequency.Name = "txtQuotatickfrequency"
        Me.txtQuotatickfrequency.Size = New System.Drawing.Size(56, 21)
        Me.txtQuotatickfrequency.TabIndex = 0
        Me.txtQuotatickfrequency.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblPlotPenWidth
        '
        Me.lblPlotPenWidth.AutoSize = True
        Me.lblPlotPenWidth.Location = New System.Drawing.Point(6, 24)
        Me.lblPlotPenWidth.Name = "lblPlotPenWidth"
        Me.lblPlotPenWidth.Size = New System.Drawing.Size(116, 13)
        Me.lblPlotPenWidth.TabIndex = 4
        Me.lblPlotPenWidth.Text = "Frequenza tacche (m):"
        '
        'lblPlotSelectedPenWidth
        '
        Me.lblPlotSelectedPenWidth.AutoSize = True
        Me.lblPlotSelectedPenWidth.Location = New System.Drawing.Point(6, 51)
        Me.lblPlotSelectedPenWidth.Name = "lblPlotSelectedPenWidth"
        Me.lblPlotSelectedPenWidth.Size = New System.Drawing.Size(127, 13)
        Me.lblPlotSelectedPenWidth.TabIndex = 6
        Me.lblPlotSelectedPenWidth.Text = "Frequenza etichetta (m):"
        '
        'txtQuotaticklabelfrequency
        '
        Me.txtQuotaticklabelfrequency.Location = New System.Drawing.Point(189, 51)
        Me.txtQuotaticklabelfrequency.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.txtQuotaticklabelfrequency.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtQuotaticklabelfrequency.Name = "txtQuotaticklabelfrequency"
        Me.txtQuotaticklabelfrequency.Size = New System.Drawing.Size(56, 21)
        Me.txtQuotaticklabelfrequency.TabIndex = 1
        Me.txtQuotaticklabelfrequency.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'frmHVQuota
        '
        Me.frmHVQuota.Controls.Add(Me.cboQuotaCapDecoration)
        Me.frmHVQuota.Controls.Add(Me.lblQuotaRightRefPercent)
        Me.frmHVQuota.Controls.Add(Me.txtQuotaRightRefPercent)
        Me.frmHVQuota.Controls.Add(Me.lblQuotaCapDecoration)
        Me.frmHVQuota.Controls.Add(Me.lblQuotaLeftRefPercent)
        Me.frmHVQuota.Controls.Add(Me.txtQuotaLeftRefPercent)
        Me.frmHVQuota.Location = New System.Drawing.Point(12, 140)
        Me.frmHVQuota.Name = "frmHVQuota"
        Me.frmHVQuota.Size = New System.Drawing.Size(260, 122)
        Me.frmHVQuota.TabIndex = 128
        Me.frmHVQuota.TabStop = False
        Me.frmHVQuota.Text = "Quota orizzontale/verticale:"
        '
        'cboQuotaCapDecoration
        '
        Me.cboQuotaCapDecoration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboQuotaCapDecoration.FormattingEnabled = True
        Me.cboQuotaCapDecoration.Items.AddRange(New Object() {"Nessuna", "Frecce", "Segmento inclinato"})
        Me.cboQuotaCapDecoration.Location = New System.Drawing.Point(148, 21)
        Me.cboQuotaCapDecoration.Name = "cboQuotaCapDecoration"
        Me.cboQuotaCapDecoration.Size = New System.Drawing.Size(97, 21)
        Me.cboQuotaCapDecoration.TabIndex = 0
        '
        'lblQuotaRightRefPercent
        '
        Me.lblQuotaRightRefPercent.AutoSize = True
        Me.lblQuotaRightRefPercent.Location = New System.Drawing.Point(6, 78)
        Me.lblQuotaRightRefPercent.Name = "lblQuotaRightRefPercent"
        Me.lblQuotaRightRefPercent.Size = New System.Drawing.Size(111, 13)
        Me.lblQuotaRightRefPercent.TabIndex = 8
        Me.lblQuotaRightRefPercent.Text = "% riferimento destro:"
        '
        'txtQuotaRightRefPercent
        '
        Me.txtQuotaRightRefPercent.DecimalPlaces = 1
        Me.txtQuotaRightRefPercent.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.txtQuotaRightRefPercent.Location = New System.Drawing.Point(189, 78)
        Me.txtQuotaRightRefPercent.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtQuotaRightRefPercent.Name = "txtQuotaRightRefPercent"
        Me.txtQuotaRightRefPercent.Size = New System.Drawing.Size(56, 21)
        Me.txtQuotaRightRefPercent.TabIndex = 2
        Me.txtQuotaRightRefPercent.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'lblQuotaCapDecoration
        '
        Me.lblQuotaCapDecoration.AutoSize = True
        Me.lblQuotaCapDecoration.Location = New System.Drawing.Point(6, 24)
        Me.lblQuotaCapDecoration.Name = "lblQuotaCapDecoration"
        Me.lblQuotaCapDecoration.Size = New System.Drawing.Size(70, 13)
        Me.lblQuotaCapDecoration.TabIndex = 4
        Me.lblQuotaCapDecoration.Text = "Decorazione:"
        '
        'lblQuotaLeftRefPercent
        '
        Me.lblQuotaLeftRefPercent.AutoSize = True
        Me.lblQuotaLeftRefPercent.Location = New System.Drawing.Point(6, 51)
        Me.lblQuotaLeftRefPercent.Name = "lblQuotaLeftRefPercent"
        Me.lblQuotaLeftRefPercent.Size = New System.Drawing.Size(114, 13)
        Me.lblQuotaLeftRefPercent.TabIndex = 6
        Me.lblQuotaLeftRefPercent.Text = "% riferimento sinistro:"
        '
        'txtQuotaLeftRefPercent
        '
        Me.txtQuotaLeftRefPercent.DecimalPlaces = 1
        Me.txtQuotaLeftRefPercent.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.txtQuotaLeftRefPercent.Location = New System.Drawing.Point(189, 51)
        Me.txtQuotaLeftRefPercent.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtQuotaLeftRefPercent.Name = "txtQuotaLeftRefPercent"
        Me.txtQuotaLeftRefPercent.Size = New System.Drawing.Size(56, 21)
        Me.txtQuotaLeftRefPercent.TabIndex = 1
        Me.txtQuotaLeftRefPercent.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'frmQuotaProperties
        '
        Me.AcceptButton = Me.cmdOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(284, 310)
        Me.Controls.Add(Me.frmHVQuota)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.frmScaleQuota)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmQuotaProperties"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Proprietà quota:"
        Me.frmScaleQuota.ResumeLayout(False)
        Me.frmScaleQuota.PerformLayout()
        CType(Me.txtQuotaticksize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuotatickfrequency, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuotaticklabelfrequency, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frmHVQuota.ResumeLayout(False)
        Me.frmHVQuota.PerformLayout()
        CType(Me.txtQuotaRightRefPercent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuotaLeftRefPercent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents frmScaleQuota As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtQuotaticksize As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtQuotatickfrequency As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblPlotPenWidth As System.Windows.Forms.Label
    Friend WithEvents lblPlotSelectedPenWidth As System.Windows.Forms.Label
    Friend WithEvents txtQuotaticklabelfrequency As System.Windows.Forms.NumericUpDown
    Friend WithEvents frmHVQuota As System.Windows.Forms.GroupBox
    Friend WithEvents lblQuotaRightRefPercent As System.Windows.Forms.Label
    Friend WithEvents txtQuotaRightRefPercent As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblQuotaCapDecoration As System.Windows.Forms.Label
    Friend WithEvents lblQuotaLeftRefPercent As System.Windows.Forms.Label
    Friend WithEvents txtQuotaLeftRefPercent As System.Windows.Forms.NumericUpDown
    Friend WithEvents cboQuotaCapDecoration As System.Windows.Forms.ComboBox
End Class
