<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManageLRUD
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
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmManageLRUD))
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.frmRestore = New System.Windows.Forms.GroupBox()
        Me.chkRestoreDeleteBackupAfterRestore = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboRestoreName = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.frmBackup = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboBackupName = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.chkBackup = New System.Windows.Forms.CheckBox()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.frmMode1 = New System.Windows.Forms.GroupBox()
        Me.RadioButton1b = New System.Windows.Forms.RadioButton()
        Me.RadioButton1a = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkShotWithLRUD = New System.Windows.Forms.CheckBox()
        Me.cboReplicateTo = New System.Windows.Forms.ComboBox()
        Me.chkShotWithCalculatedLRUD = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkShotWithoutLRUD = New System.Windows.Forms.CheckBox()
        Me.frmMode2 = New System.Windows.Forms.GroupBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtMode2V = New System.Windows.Forms.NumericUpDown()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.txtMode2H = New System.Windows.Forms.NumericUpDown()
        Me.chkMode2OnlyCutSplay = New System.Windows.Forms.CheckBox()
        Me.chkMarkAsCalculated = New System.Windows.Forms.CheckBox()
        Me.frmRestore.SuspendLayout()
        Me.frmBackup.SuspendLayout()
        Me.frmMode1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.frmMode2.SuspendLayout()
        CType(Me.txtMode2V, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMode2H, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'frmRestore
        '
        Me.frmRestore.Controls.Add(Me.chkRestoreDeleteBackupAfterRestore)
        Me.frmRestore.Controls.Add(Me.Label4)
        Me.frmRestore.Controls.Add(Me.cboRestoreName)
        Me.frmRestore.Controls.Add(Me.Label5)
        resources.ApplyResources(Me.frmRestore, "frmRestore")
        Me.frmRestore.Name = "frmRestore"
        Me.frmRestore.TabStop = False
        '
        'chkRestoreDeleteBackupAfterRestore
        '
        resources.ApplyResources(Me.chkRestoreDeleteBackupAfterRestore, "chkRestoreDeleteBackupAfterRestore")
        Me.chkRestoreDeleteBackupAfterRestore.Name = "chkRestoreDeleteBackupAfterRestore"
        Me.chkRestoreDeleteBackupAfterRestore.UseVisualStyleBackColor = True
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'cboRestoreName
        '
        Me.cboRestoreName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRestoreName.FormattingEnabled = True
        resources.ApplyResources(Me.cboRestoreName, "cboRestoreName")
        Me.cboRestoreName.Name = "cboRestoreName"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'frmBackup
        '
        Me.frmBackup.Controls.Add(Me.Label3)
        Me.frmBackup.Controls.Add(Me.cboBackupName)
        Me.frmBackup.Controls.Add(Me.Label2)
        resources.ApplyResources(Me.frmBackup, "frmBackup")
        Me.frmBackup.Name = "frmBackup"
        Me.frmBackup.TabStop = False
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'cboBackupName
        '
        Me.cboBackupName.FormattingEnabled = True
        resources.ApplyResources(Me.cboBackupName, "cboBackupName")
        Me.cboBackupName.Name = "cboBackupName"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'RadioButton4
        '
        resources.ApplyResources(Me.RadioButton4, "RadioButton4")
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'chkBackup
        '
        resources.ApplyResources(Me.chkBackup, "chkBackup")
        Me.chkBackup.Name = "chkBackup"
        Me.chkBackup.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        resources.ApplyResources(Me.RadioButton3, "RadioButton3")
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        resources.ApplyResources(Me.RadioButton2, "RadioButton2")
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'frmMode1
        '
        Me.frmMode1.Controls.Add(Me.RadioButton1b)
        Me.frmMode1.Controls.Add(Me.RadioButton1a)
        resources.ApplyResources(Me.frmMode1, "frmMode1")
        Me.frmMode1.Name = "frmMode1"
        Me.frmMode1.TabStop = False
        '
        'RadioButton1b
        '
        resources.ApplyResources(Me.RadioButton1b, "RadioButton1b")
        Me.RadioButton1b.Name = "RadioButton1b"
        Me.RadioButton1b.UseVisualStyleBackColor = True
        '
        'RadioButton1a
        '
        resources.ApplyResources(Me.RadioButton1a, "RadioButton1a")
        Me.RadioButton1a.Checked = True
        Me.RadioButton1a.Name = "RadioButton1a"
        Me.RadioButton1a.TabStop = True
        Me.RadioButton1a.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        resources.ApplyResources(Me.RadioButton1, "RadioButton1")
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.chkShotWithLRUD)
        Me.Panel1.Controls.Add(Me.cboReplicateTo)
        Me.Panel1.Controls.Add(Me.chkShotWithCalculatedLRUD)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.chkShotWithoutLRUD)
        Me.Panel1.Name = "Panel1"
        '
        'chkShotWithLRUD
        '
        resources.ApplyResources(Me.chkShotWithLRUD, "chkShotWithLRUD")
        Me.chkShotWithLRUD.BackColor = System.Drawing.Color.Transparent
        Me.chkShotWithLRUD.Name = "chkShotWithLRUD"
        Me.chkShotWithLRUD.UseVisualStyleBackColor = False
        '
        'cboReplicateTo
        '
        Me.cboReplicateTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboReplicateTo.FormattingEnabled = True
        Me.cboReplicateTo.Items.AddRange(New Object() {resources.GetString("cboReplicateTo.Items"), resources.GetString("cboReplicateTo.Items1"), resources.GetString("cboReplicateTo.Items2"), resources.GetString("cboReplicateTo.Items3")})
        resources.ApplyResources(Me.cboReplicateTo, "cboReplicateTo")
        Me.cboReplicateTo.Name = "cboReplicateTo"
        '
        'chkShotWithCalculatedLRUD
        '
        resources.ApplyResources(Me.chkShotWithCalculatedLRUD, "chkShotWithCalculatedLRUD")
        Me.chkShotWithCalculatedLRUD.BackColor = System.Drawing.Color.Transparent
        Me.chkShotWithCalculatedLRUD.Name = "chkShotWithCalculatedLRUD"
        Me.chkShotWithCalculatedLRUD.UseVisualStyleBackColor = False
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Name = "Label1"
        '
        'chkShotWithoutLRUD
        '
        resources.ApplyResources(Me.chkShotWithoutLRUD, "chkShotWithoutLRUD")
        Me.chkShotWithoutLRUD.BackColor = System.Drawing.Color.Transparent
        Me.chkShotWithoutLRUD.Name = "chkShotWithoutLRUD"
        Me.chkShotWithoutLRUD.UseVisualStyleBackColor = False
        '
        'frmMode2
        '
        Me.frmMode2.Controls.Add(Me.Label26)
        Me.frmMode2.Controls.Add(Me.txtMode2V)
        Me.frmMode2.Controls.Add(Me.Label35)
        Me.frmMode2.Controls.Add(Me.txtMode2H)
        Me.frmMode2.Controls.Add(Me.chkMode2OnlyCutSplay)
        resources.ApplyResources(Me.frmMode2, "frmMode2")
        Me.frmMode2.Name = "frmMode2"
        Me.frmMode2.TabStop = False
        '
        'Label26
        '
        resources.ApplyResources(Me.Label26, "Label26")
        Me.Label26.Name = "Label26"
        '
        'txtMode2V
        '
        resources.ApplyResources(Me.txtMode2V, "txtMode2V")
        Me.txtMode2V.Maximum = New Decimal(New Integer() {180, 0, 0, 0})
        Me.txtMode2V.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtMode2V.Name = "txtMode2V"
        Me.txtMode2V.Value = New Decimal(New Integer() {45, 0, 0, 0})
        '
        'Label35
        '
        resources.ApplyResources(Me.Label35, "Label35")
        Me.Label35.Name = "Label35"
        '
        'txtMode2H
        '
        resources.ApplyResources(Me.txtMode2H, "txtMode2H")
        Me.txtMode2H.Maximum = New Decimal(New Integer() {180, 0, 0, 0})
        Me.txtMode2H.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtMode2H.Name = "txtMode2H"
        Me.txtMode2H.Value = New Decimal(New Integer() {45, 0, 0, 0})
        '
        'chkMode2OnlyCutSplay
        '
        resources.ApplyResources(Me.chkMode2OnlyCutSplay, "chkMode2OnlyCutSplay")
        Me.chkMode2OnlyCutSplay.Name = "chkMode2OnlyCutSplay"
        Me.chkMode2OnlyCutSplay.UseVisualStyleBackColor = True
        '
        'chkMarkAsCalculated
        '
        resources.ApplyResources(Me.chkMarkAsCalculated, "chkMarkAsCalculated")
        Me.chkMarkAsCalculated.Name = "chkMarkAsCalculated"
        Me.chkMarkAsCalculated.UseVisualStyleBackColor = True
        '
        'frmManageLRUD
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.chkMarkAsCalculated)
        Me.Controls.Add(Me.frmMode2)
        Me.Controls.Add(Me.frmRestore)
        Me.Controls.Add(Me.frmBackup)
        Me.Controls.Add(Me.RadioButton4)
        Me.Controls.Add(Me.chkBackup)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.RadioButton3)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.frmMode1)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmManageLRUD"
        Me.frmRestore.ResumeLayout(False)
        Me.frmRestore.PerformLayout()
        Me.frmBackup.ResumeLayout(False)
        Me.frmBackup.PerformLayout()
        Me.frmMode1.ResumeLayout(False)
        Me.frmMode1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.frmMode2.ResumeLayout(False)
        Me.frmMode2.PerformLayout()
        CType(Me.txtMode2V, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMode2H, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents frmMode1 As GroupBox
    Friend WithEvents RadioButton1b As RadioButton
    Friend WithEvents RadioButton1a As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents cmdCancel As Button
    Friend WithEvents cmdOk As Button
    Friend WithEvents chkBackup As CheckBox
    Friend WithEvents RadioButton4 As RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboReplicateTo As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents frmBackup As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboBackupName As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents frmRestore As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboRestoreName As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkRestoreDeleteBackupAfterRestore As System.Windows.Forms.CheckBox
    Friend WithEvents frmMode2 As GroupBox
    Friend WithEvents chkMode2OnlyCutSplay As CheckBox
    Friend WithEvents Label26 As Label
    Friend WithEvents txtMode2V As NumericUpDown
    Friend WithEvents Label35 As Label
    Friend WithEvents txtMode2H As NumericUpDown
    Friend WithEvents chkShotWithoutLRUD As CheckBox
    Friend WithEvents chkMarkAsCalculated As CheckBox
    Friend WithEvents chkShotWithCalculatedLRUD As CheckBox
    Friend WithEvents chkShotWithLRUD As CheckBox
End Class
