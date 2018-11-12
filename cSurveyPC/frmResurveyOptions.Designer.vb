<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmResurveyOptions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmResurveyOptions))
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkUseDropForInclination = New System.Windows.Forms.CheckBox()
        Me.chkSkipInvalidStation = New System.Windows.Forms.CheckBox()
        Me.lblNordCorrectionDegrees = New System.Windows.Forms.Label()
        Me.txtNordCorrection = New System.Windows.Forms.NumericUpDown()
        Me.lblNordCorrection = New System.Windows.Forms.Label()
        Me.cboCalculateMode = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtUDMaxValue = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtLRMaxValue = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkLRUDCalculate = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtLRUDBorderWidth = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtNordCorrection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.txtUDMaxValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLRMaxValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLRUDBorderWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Controls.Add(Me.chkUseDropForInclination)
        Me.GroupBox1.Controls.Add(Me.chkSkipInvalidStation)
        Me.GroupBox1.Controls.Add(Me.lblNordCorrectionDegrees)
        Me.GroupBox1.Controls.Add(Me.txtNordCorrection)
        Me.GroupBox1.Controls.Add(Me.lblNordCorrection)
        Me.GroupBox1.Controls.Add(Me.cboCalculateMode)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'chkUseDropForInclination
        '
        resources.ApplyResources(Me.chkUseDropForInclination, "chkUseDropForInclination")
        Me.chkUseDropForInclination.Name = "chkUseDropForInclination"
        Me.chkUseDropForInclination.UseVisualStyleBackColor = True
        '
        'chkSkipInvalidStation
        '
        resources.ApplyResources(Me.chkSkipInvalidStation, "chkSkipInvalidStation")
        Me.chkSkipInvalidStation.Name = "chkSkipInvalidStation"
        Me.chkSkipInvalidStation.UseVisualStyleBackColor = True
        '
        'lblNordCorrectionDegrees
        '
        resources.ApplyResources(Me.lblNordCorrectionDegrees, "lblNordCorrectionDegrees")
        Me.lblNordCorrectionDegrees.Name = "lblNordCorrectionDegrees"
        '
        'txtNordCorrection
        '
        Me.txtNordCorrection.DecimalPlaces = 1
        Me.txtNordCorrection.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        resources.ApplyResources(Me.txtNordCorrection, "txtNordCorrection")
        Me.txtNordCorrection.Maximum = New Decimal(New Integer() {359, 0, 0, 0})
        Me.txtNordCorrection.Minimum = New Decimal(New Integer() {359, 0, 0, -2147483648})
        Me.txtNordCorrection.Name = "txtNordCorrection"
        '
        'lblNordCorrection
        '
        resources.ApplyResources(Me.lblNordCorrection, "lblNordCorrection")
        Me.lblNordCorrection.Name = "lblNordCorrection"
        '
        'cboCalculateMode
        '
        Me.cboCalculateMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCalculateMode.FormattingEnabled = True
        Me.cboCalculateMode.Items.AddRange(New Object() {resources.GetString("cboCalculateMode.Items"), resources.GetString("cboCalculateMode.Items1")})
        resources.ApplyResources(Me.cboCalculateMode, "cboCalculateMode")
        Me.cboCalculateMode.Name = "cboCalculateMode"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'GroupBox2
        '
        resources.ApplyResources(Me.GroupBox2, "GroupBox2")
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtUDMaxValue)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtLRMaxValue)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.chkLRUDCalculate)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtLRUDBorderWidth)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.TabStop = False
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'txtUDMaxValue
        '
        Me.txtUDMaxValue.DecimalPlaces = 1
        Me.txtUDMaxValue.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        resources.ApplyResources(Me.txtUDMaxValue, "txtUDMaxValue")
        Me.txtUDMaxValue.Minimum = New Decimal(New Integer() {2, 0, 0, 65536})
        Me.txtUDMaxValue.Name = "txtUDMaxValue"
        Me.txtUDMaxValue.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'txtLRMaxValue
        '
        Me.txtLRMaxValue.DecimalPlaces = 1
        Me.txtLRMaxValue.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        resources.ApplyResources(Me.txtLRMaxValue, "txtLRMaxValue")
        Me.txtLRMaxValue.Minimum = New Decimal(New Integer() {2, 0, 0, 65536})
        Me.txtLRMaxValue.Name = "txtLRMaxValue"
        Me.txtLRMaxValue.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'chkLRUDCalculate
        '
        resources.ApplyResources(Me.chkLRUDCalculate, "chkLRUDCalculate")
        Me.chkLRUDCalculate.Name = "chkLRUDCalculate"
        Me.chkLRUDCalculate.UseVisualStyleBackColor = True
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'txtLRUDBorderWidth
        '
        resources.ApplyResources(Me.txtLRUDBorderWidth, "txtLRUDBorderWidth")
        Me.txtLRUDBorderWidth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtLRUDBorderWidth.Name = "txtLRUDBorderWidth"
        Me.txtLRUDBorderWidth.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'frmResurveyOptions
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmResurveyOptions"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtNordCorrection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.txtUDMaxValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLRMaxValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLRUDBorderWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboCalculateMode As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblNordCorrection As System.Windows.Forms.Label
    Friend WithEvents lblNordCorrectionDegrees As System.Windows.Forms.Label
    Friend WithEvents txtNordCorrection As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkSkipInvalidStation As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtUDMaxValue As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtLRMaxValue As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkLRUDCalculate As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtLRUDBorderWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkUseDropForInclination As CheckBox
End Class
