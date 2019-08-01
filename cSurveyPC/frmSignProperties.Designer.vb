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
        'frmSignRotationAngleDelta
        '
        Me.frmSignRotationAngleDelta.Controls.Add(Me.Label1)
        Me.frmSignRotationAngleDelta.Controls.Add(Me.txtSignRotationAngleDelta)
        resources.ApplyResources(Me.frmSignRotationAngleDelta, "frmSignRotationAngleDelta")
        Me.frmSignRotationAngleDelta.Name = "frmSignRotationAngleDelta"
        Me.frmSignRotationAngleDelta.TabStop = False
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'txtSignRotationAngleDelta
        '
        Me.txtSignRotationAngleDelta.DecimalPlaces = 1
        Me.txtSignRotationAngleDelta.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        resources.ApplyResources(Me.txtSignRotationAngleDelta, "txtSignRotationAngleDelta")
        Me.txtSignRotationAngleDelta.Maximum = New Decimal(New Integer() {3599, 0, 0, 65536})
        Me.txtSignRotationAngleDelta.Name = "txtSignRotationAngleDelta"
        '
        'frmSignProperties
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.frmSignRotationAngleDelta)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSignProperties"
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
