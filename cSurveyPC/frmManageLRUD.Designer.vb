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
        Me.chkBackup = New System.Windows.Forms.CheckBox()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.frmMode1 = New System.Windows.Forms.GroupBox()
        Me.RadioButton1b = New System.Windows.Forms.RadioButton()
        Me.RadioButton1a = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkShotWithLRUD = New System.Windows.Forms.CheckBox()
        Me.cboReplicateTo = New System.Windows.Forms.ComboBox()
        Me.chkShotWithCalculatedLRUD = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkShotWithoutLRUD = New System.Windows.Forms.CheckBox()
        Me.frmMode2 = New System.Windows.Forms.GroupBox()
        Me.lblSplayMode = New System.Windows.Forms.Label()
        Me.cboMode2Mode = New System.Windows.Forms.ComboBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtMode2V = New System.Windows.Forms.NumericUpDown()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.txtMode2H = New System.Windows.Forms.NumericUpDown()
        Me.chkMode2OnlyCutSplay = New System.Windows.Forms.CheckBox()
        Me.chkMarkAsCalculated = New System.Windows.Forms.CheckBox()
        Me.cboAction = New System.Windows.Forms.ComboBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.lblAction = New System.Windows.Forms.Label()
        Me.pnlOption0 = New DevExpress.XtraEditors.PanelControl()
        Me.pnlOption1 = New DevExpress.XtraEditors.PanelControl()
        Me.pnlOption3 = New DevExpress.XtraEditors.PanelControl()
        Me.pnlOptionOther = New DevExpress.XtraEditors.PanelControl()
        Me.pnlBottom = New DevExpress.XtraEditors.PanelControl()
        Me.frmRestore.SuspendLayout()
        Me.frmBackup.SuspendLayout()
        Me.frmMode1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.frmMode2.SuspendLayout()
        CType(Me.txtMode2V, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMode2H, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.pnlOption0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOption0.SuspendLayout()
        CType(Me.pnlOption1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOption1.SuspendLayout()
        CType(Me.pnlOption3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOption3.SuspendLayout()
        CType(Me.pnlOptionOther, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOptionOther.SuspendLayout()
        CType(Me.pnlBottom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBottom.SuspendLayout()
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.chkShotWithLRUD)
        Me.Panel1.Controls.Add(Me.cboReplicateTo)
        Me.Panel1.Controls.Add(Me.chkShotWithCalculatedLRUD)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.chkShotWithoutLRUD)
        resources.ApplyResources(Me.Panel1, "Panel1")
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
        Me.frmMode2.Controls.Add(Me.lblSplayMode)
        Me.frmMode2.Controls.Add(Me.cboMode2Mode)
        Me.frmMode2.Controls.Add(Me.Label26)
        Me.frmMode2.Controls.Add(Me.txtMode2V)
        Me.frmMode2.Controls.Add(Me.Label35)
        Me.frmMode2.Controls.Add(Me.txtMode2H)
        Me.frmMode2.Controls.Add(Me.chkMode2OnlyCutSplay)
        resources.ApplyResources(Me.frmMode2, "frmMode2")
        Me.frmMode2.Name = "frmMode2"
        Me.frmMode2.TabStop = False
        '
        'lblSplayMode
        '
        resources.ApplyResources(Me.lblSplayMode, "lblSplayMode")
        Me.lblSplayMode.Name = "lblSplayMode"
        '
        'cboMode2Mode
        '
        Me.cboMode2Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMode2Mode.FormattingEnabled = True
        Me.cboMode2Mode.Items.AddRange(New Object() {resources.GetString("cboMode2Mode.Items")})
        resources.ApplyResources(Me.cboMode2Mode, "cboMode2Mode")
        Me.cboMode2Mode.Name = "cboMode2Mode"
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
        'cboAction
        '
        Me.cboAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAction.FormattingEnabled = True
        Me.cboAction.Items.AddRange(New Object() {resources.GetString("cboAction.Items"), resources.GetString("cboAction.Items1"), resources.GetString("cboAction.Items2"), resources.GetString("cboAction.Items3")})
        resources.ApplyResources(Me.cboAction, "cboAction")
        Me.cboAction.Name = "cboAction"
        '
        'TableLayoutPanel1
        '
        resources.ApplyResources(Me.TableLayoutPanel1, "TableLayoutPanel1")
        Me.TableLayoutPanel1.Controls.Add(Me.PanelControl1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.pnlOption0, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.pnlOption1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.pnlOption3, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.pnlOptionOther, 0, 4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.lblAction)
        Me.PanelControl1.Controls.Add(Me.cboAction)
        resources.ApplyResources(Me.PanelControl1, "PanelControl1")
        Me.PanelControl1.Name = "PanelControl1"
        '
        'lblAction
        '
        resources.ApplyResources(Me.lblAction, "lblAction")
        Me.lblAction.BackColor = System.Drawing.Color.Transparent
        Me.lblAction.Name = "lblAction"
        '
        'pnlOption0
        '
        Me.pnlOption0.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlOption0.Controls.Add(Me.frmMode1)
        resources.ApplyResources(Me.pnlOption0, "pnlOption0")
        Me.pnlOption0.Name = "pnlOption0"
        '
        'pnlOption1
        '
        Me.pnlOption1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlOption1.Controls.Add(Me.frmMode2)
        resources.ApplyResources(Me.pnlOption1, "pnlOption1")
        Me.pnlOption1.Name = "pnlOption1"
        '
        'pnlOption3
        '
        Me.pnlOption3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlOption3.Controls.Add(Me.frmRestore)
        resources.ApplyResources(Me.pnlOption3, "pnlOption3")
        Me.pnlOption3.Name = "pnlOption3"
        '
        'pnlOptionOther
        '
        Me.pnlOptionOther.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlOptionOther.Controls.Add(Me.chkMarkAsCalculated)
        Me.pnlOptionOther.Controls.Add(Me.chkBackup)
        Me.pnlOptionOther.Controls.Add(Me.frmBackup)
        resources.ApplyResources(Me.pnlOptionOther, "pnlOptionOther")
        Me.pnlOptionOther.Name = "pnlOptionOther"
        '
        'pnlBottom
        '
        Me.pnlBottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlBottom.Controls.Add(Me.cmdCancel)
        Me.pnlBottom.Controls.Add(Me.cmdOk)
        resources.ApplyResources(Me.pnlBottom, "pnlBottom")
        Me.pnlBottom.Name = "pnlBottom"
        '
        'frmManageLRUD
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlBottom)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.lrud
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
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.pnlOption0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlOption0.ResumeLayout(False)
        CType(Me.pnlOption1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlOption1.ResumeLayout(False)
        CType(Me.pnlOption3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlOption3.ResumeLayout(False)
        CType(Me.pnlOptionOther, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlOptionOther.ResumeLayout(False)
        Me.pnlOptionOther.PerformLayout()
        CType(Me.pnlBottom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBottom.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents frmMode1 As GroupBox
    Friend WithEvents RadioButton1b As RadioButton
    Friend WithEvents RadioButton1a As RadioButton
    Friend WithEvents cmdCancel As Button
    Friend WithEvents cmdOk As Button
    Friend WithEvents chkBackup As CheckBox
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
    Friend WithEvents lblSplayMode As Label
    Friend WithEvents cboMode2Mode As ComboBox
    Friend WithEvents cboAction As ComboBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents lblAction As Label
    Friend WithEvents pnlOption0 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnlOption1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnlOption3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnlOptionOther As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnlBottom As DevExpress.XtraEditors.PanelControl
End Class
