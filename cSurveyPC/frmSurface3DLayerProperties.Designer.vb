<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSurface3DLayerProperties
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSurface3DLayerProperties))
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.txtTransparency = New System.Windows.Forms.NumericUpDown()
        Me.lblPropTransparency = New System.Windows.Forms.Label()
        CType(Me.txtTransparency, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(192, 49)
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
        Me.cmdOk.Location = New System.Drawing.Point(106, 49)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(80, 25)
        Me.cmdOk.TabIndex = 0
        Me.cmdOk.Text = "Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
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
        'frmSurface3DLayerProperties
        '
        Me.AcceptButton = Me.cmdOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(284, 86)
        Me.Controls.Add(Me.txtTransparency)
        Me.Controls.Add(Me.lblPropTransparency)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSurface3DLayerProperties"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Proprietà superficie:"
        CType(Me.txtTransparency, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents txtTransparency As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblPropTransparency As System.Windows.Forms.Label
End Class
