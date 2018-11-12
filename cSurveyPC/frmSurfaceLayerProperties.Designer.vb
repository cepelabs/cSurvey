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
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(192, 153)
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
        Me.cmdOk.Location = New System.Drawing.Point(106, 153)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(80, 25)
        Me.cmdOk.TabIndex = 0
        Me.cmdOk.Text = "Ok"
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
        Me.frmScale.Location = New System.Drawing.Point(12, 48)
        Me.frmScale.Name = "frmScale"
        Me.frmScale.Size = New System.Drawing.Size(260, 83)
        Me.frmScale.TabIndex = 127
        Me.frmScale.TabStop = False
        Me.frmScale.Text = "Visualizza per scala:"
        '
        'lblMaxScale
        '
        Me.lblMaxScale.AutoSize = True
        Me.lblMaxScale.Enabled = False
        Me.lblMaxScale.Location = New System.Drawing.Point(120, 50)
        Me.lblMaxScale.Name = "lblMaxScale"
        Me.lblMaxScale.Size = New System.Drawing.Size(17, 13)
        Me.lblMaxScale.TabIndex = 13
        Me.lblMaxScale.Text = "1:"
        '
        'lblMinScale
        '
        Me.lblMinScale.AutoSize = True
        Me.lblMinScale.Enabled = False
        Me.lblMinScale.Location = New System.Drawing.Point(120, 23)
        Me.lblMinScale.Name = "lblMinScale"
        Me.lblMinScale.Size = New System.Drawing.Size(17, 13)
        Me.lblMinScale.TabIndex = 12
        Me.lblMinScale.Text = "1:"
        '
        'chkMaxScale
        '
        Me.chkMaxScale.AutoSize = True
        Me.chkMaxScale.Location = New System.Drawing.Point(18, 48)
        Me.chkMaxScale.Name = "chkMaxScale"
        Me.chkMaxScale.Size = New System.Drawing.Size(98, 17)
        Me.chkMaxScale.TabIndex = 11
        Me.chkMaxScale.Text = "Scala massima:"
        Me.chkMaxScale.UseVisualStyleBackColor = True
        '
        'txtMaxScale
        '
        Me.txtMaxScale.Enabled = False
        Me.txtMaxScale.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.txtMaxScale.Location = New System.Drawing.Point(144, 48)
        Me.txtMaxScale.Maximum = New Decimal(New Integer() {50000, 0, 0, 0})
        Me.txtMaxScale.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtMaxScale.Name = "txtMaxScale"
        Me.txtMaxScale.Size = New System.Drawing.Size(78, 21)
        Me.txtMaxScale.TabIndex = 10
        Me.txtMaxScale.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'chkMinScale
        '
        Me.chkMinScale.AutoSize = True
        Me.chkMinScale.Location = New System.Drawing.Point(18, 21)
        Me.chkMinScale.Name = "chkMinScale"
        Me.chkMinScale.Size = New System.Drawing.Size(90, 17)
        Me.chkMinScale.TabIndex = 9
        Me.chkMinScale.Text = "Scala minima:"
        Me.chkMinScale.UseVisualStyleBackColor = True
        '
        'txtMinScale
        '
        Me.txtMinScale.Enabled = False
        Me.txtMinScale.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.txtMinScale.Location = New System.Drawing.Point(144, 21)
        Me.txtMinScale.Maximum = New Decimal(New Integer() {50000, 0, 0, 0})
        Me.txtMinScale.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtMinScale.Name = "txtMinScale"
        Me.txtMinScale.Size = New System.Drawing.Size(78, 21)
        Me.txtMinScale.TabIndex = 2
        Me.txtMinScale.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'txtTransparency
        '
        Me.txtTransparency.Location = New System.Drawing.Point(135, 12)
        Me.txtTransparency.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.txtTransparency.Name = "txtTransparency"
        Me.txtTransparency.Size = New System.Drawing.Size(58, 21)
        Me.txtTransparency.TabIndex = 129
        Me.txtTransparency.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPropTransparency
        '
        Me.lblPropTransparency.AutoSize = True
        Me.lblPropTransparency.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPropTransparency.Location = New System.Drawing.Point(28, 14)
        Me.lblPropTransparency.Name = "lblPropTransparency"
        Me.lblPropTransparency.Size = New System.Drawing.Size(71, 13)
        Me.lblPropTransparency.TabIndex = 128
        Me.lblPropTransparency.Text = "Trasparenza:"
        Me.lblPropTransparency.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmSurfaceLayerProperties
        '
        Me.AcceptButton = Me.cmdOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(284, 190)
        Me.Controls.Add(Me.txtTransparency)
        Me.Controls.Add(Me.lblPropTransparency)
        Me.Controls.Add(Me.frmScale)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSurfaceLayerProperties"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Proprietà superficie:"
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
