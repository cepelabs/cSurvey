<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSignProperties
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSignProperties))
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.frmSignRotationAngleDelta = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSignRotationAngleDelta = New System.Windows.Forms.NumericUpDown()
        Me.frmSignRotationAngleDelta.SuspendLayout()
        CType(Me.txtSignRotationAngleDelta, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'frmSignRotationAngleDelta
        '
        Me.frmSignRotationAngleDelta.Controls.Add(Me.Label1)
        Me.frmSignRotationAngleDelta.Controls.Add(Me.txtSignRotationAngleDelta)
        Me.frmSignRotationAngleDelta.Location = New System.Drawing.Point(12, 12)
        Me.frmSignRotationAngleDelta.Name = "frmSignRotationAngleDelta"
        Me.frmSignRotationAngleDelta.Size = New System.Drawing.Size(260, 122)
        Me.frmSignRotationAngleDelta.TabIndex = 127
        Me.frmSignRotationAngleDelta.TabStop = False
        Me.frmSignRotationAngleDelta.Text = "Rotazione:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Angolo di rotazione base (°):"
        '
        'txtSignRotationAngleDelta
        '
        Me.txtSignRotationAngleDelta.DecimalPlaces = 1
        Me.txtSignRotationAngleDelta.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.txtSignRotationAngleDelta.Location = New System.Drawing.Point(167, 20)
        Me.txtSignRotationAngleDelta.Maximum = New Decimal(New Integer() {3599, 0, 0, 65536})
        Me.txtSignRotationAngleDelta.Name = "txtSignRotationAngleDelta"
        Me.txtSignRotationAngleDelta.Size = New System.Drawing.Size(78, 21)
        Me.txtSignRotationAngleDelta.TabIndex = 2
        '
        'frmSignProperties
        '
        Me.AcceptButton = Me.cmdOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(284, 310)
        Me.Controls.Add(Me.frmSignRotationAngleDelta)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSignProperties"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Proprietà simbolo:"
        Me.frmSignRotationAngleDelta.ResumeLayout(False)
        Me.frmSignRotationAngleDelta.PerformLayout()
        CType(Me.txtSignRotationAngleDelta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents frmSignRotationAngleDelta As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSignRotationAngleDelta As System.Windows.Forms.NumericUpDown
End Class
