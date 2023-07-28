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
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.frmRestore = New DevExpress.XtraEditors.GroupControl()
        Me.chkRestoreDeleteBackupAfterRestore = New DevExpress.XtraEditors.CheckEdit()
        Me.Label4 = New DevExpress.XtraEditors.LabelControl()
        Me.cboRestoreName = New System.Windows.Forms.ComboBox()
        Me.Label5 = New DevExpress.XtraEditors.LabelControl()
        Me.frmBackup = New DevExpress.XtraEditors.GroupControl()
        Me.Label3 = New DevExpress.XtraEditors.LabelControl()
        Me.cboBackupName = New System.Windows.Forms.ComboBox()
        Me.Label2 = New DevExpress.XtraEditors.LabelControl()
        Me.chkBackup = New DevExpress.XtraEditors.CheckEdit()
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.frmMode1 = New DevExpress.XtraEditors.GroupControl()
        Me.RadioButton1b = New System.Windows.Forms.RadioButton()
        Me.RadioButton1a = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New DevExpress.XtraEditors.PanelControl()
        Me.chkShotWithLRUD = New DevExpress.XtraEditors.CheckEdit()
        Me.cboReplicateTo = New System.Windows.Forms.ComboBox()
        Me.chkShotWithCalculatedLRUD = New DevExpress.XtraEditors.CheckEdit()
        Me.Label1 = New DevExpress.XtraEditors.LabelControl()
        Me.chkShotWithoutLRUD = New DevExpress.XtraEditors.CheckEdit()
        Me.frmMode2 = New DevExpress.XtraEditors.GroupControl()
        Me.lblSplayMode = New DevExpress.XtraEditors.LabelControl()
        Me.cboMode2Mode = New System.Windows.Forms.ComboBox()
        Me.Label26 = New DevExpress.XtraEditors.LabelControl()
        Me.txtMode2V = New System.Windows.Forms.NumericUpDown()
        Me.Label35 = New DevExpress.XtraEditors.LabelControl()
        Me.txtMode2H = New System.Windows.Forms.NumericUpDown()
        Me.chkMode2OnlyCutSplay = New DevExpress.XtraEditors.CheckEdit()
        Me.chkMarkAsCalculated = New DevExpress.XtraEditors.CheckEdit()
        Me.cboAction = New System.Windows.Forms.ComboBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.lblAction = New DevExpress.XtraEditors.LabelControl()
        Me.pnlOption0 = New DevExpress.XtraEditors.PanelControl()
        Me.pnlOption1 = New DevExpress.XtraEditors.PanelControl()
        Me.pnlOption3 = New DevExpress.XtraEditors.PanelControl()
        Me.pnlOptionOther = New DevExpress.XtraEditors.PanelControl()
        Me.pnlBottom = New DevExpress.XtraEditors.PanelControl()
        CType(Me.frmRestore, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frmRestore.SuspendLayout()
        CType(Me.chkRestoreDeleteBackupAfterRestore.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.frmBackup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frmBackup.SuspendLayout()
        CType(Me.chkBackup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.frmMode1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frmMode1.SuspendLayout()
        CType(Me.Panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.chkShotWithLRUD.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkShotWithCalculatedLRUD.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkShotWithoutLRUD.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.frmMode2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frmMode2.SuspendLayout()
        CType(Me.txtMode2V, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMode2H, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkMode2OnlyCutSplay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkMarkAsCalculated.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        '
        'frmRestore
        '
        Me.frmRestore.Controls.Add(Me.chkRestoreDeleteBackupAfterRestore)
        Me.frmRestore.Controls.Add(Me.Label4)
        Me.frmRestore.Controls.Add(Me.cboRestoreName)
        Me.frmRestore.Controls.Add(Me.Label5)
        resources.ApplyResources(Me.frmRestore, "frmRestore")
        Me.frmRestore.Name = "frmRestore"
        '
        'chkRestoreDeleteBackupAfterRestore
        '
        resources.ApplyResources(Me.chkRestoreDeleteBackupAfterRestore, "chkRestoreDeleteBackupAfterRestore")
        Me.chkRestoreDeleteBackupAfterRestore.Name = "chkRestoreDeleteBackupAfterRestore"
        Me.chkRestoreDeleteBackupAfterRestore.Properties.AutoWidth = True
        Me.chkRestoreDeleteBackupAfterRestore.Properties.Caption = resources.GetString("chkRestoreDeleteBackupAfterRestore.Properties.Caption")
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
        Me.chkBackup.Properties.AutoWidth = True
        Me.chkBackup.Properties.Caption = resources.GetString("chkBackup.Properties.Caption")
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.Name = "cmdOk"
        '
        'frmMode1
        '
        Me.frmMode1.Controls.Add(Me.RadioButton1b)
        Me.frmMode1.Controls.Add(Me.RadioButton1a)
        resources.ApplyResources(Me.frmMode1, "frmMode1")
        Me.frmMode1.Name = "frmMode1"
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
        Me.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
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
        Me.chkShotWithLRUD.Name = "chkShotWithLRUD"
        Me.chkShotWithLRUD.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.chkShotWithLRUD.Properties.Appearance.Options.UseBackColor = True
        Me.chkShotWithLRUD.Properties.AutoWidth = True
        Me.chkShotWithLRUD.Properties.Caption = resources.GetString("chkShotWithLRUD.Properties.Caption")
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
        Me.chkShotWithCalculatedLRUD.Name = "chkShotWithCalculatedLRUD"
        Me.chkShotWithCalculatedLRUD.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.chkShotWithCalculatedLRUD.Properties.Appearance.Options.UseBackColor = True
        Me.chkShotWithCalculatedLRUD.Properties.AutoWidth = True
        Me.chkShotWithCalculatedLRUD.Properties.Caption = resources.GetString("chkShotWithCalculatedLRUD.Properties.Caption")
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Appearance.Options.UseBackColor = True
        Me.Label1.Name = "Label1"
        '
        'chkShotWithoutLRUD
        '
        resources.ApplyResources(Me.chkShotWithoutLRUD, "chkShotWithoutLRUD")
        Me.chkShotWithoutLRUD.Name = "chkShotWithoutLRUD"
        Me.chkShotWithoutLRUD.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.chkShotWithoutLRUD.Properties.Appearance.Options.UseBackColor = True
        Me.chkShotWithoutLRUD.Properties.AutoWidth = True
        Me.chkShotWithoutLRUD.Properties.Caption = resources.GetString("chkShotWithoutLRUD.Properties.Caption")
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
        Me.chkMode2OnlyCutSplay.Properties.AutoWidth = True
        Me.chkMode2OnlyCutSplay.Properties.Caption = resources.GetString("chkMode2OnlyCutSplay.Properties.Caption")
        '
        'chkMarkAsCalculated
        '
        resources.ApplyResources(Me.chkMarkAsCalculated, "chkMarkAsCalculated")
        Me.chkMarkAsCalculated.Name = "chkMarkAsCalculated"
        Me.chkMarkAsCalculated.Properties.AutoWidth = True
        Me.chkMarkAsCalculated.Properties.Caption = resources.GetString("chkMarkAsCalculated.Properties.Caption")
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
        Me.lblAction.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.lblAction.Appearance.Options.UseBackColor = True
        resources.ApplyResources(Me.lblAction, "lblAction")
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
        CType(Me.frmRestore, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frmRestore.ResumeLayout(False)
        Me.frmRestore.PerformLayout()
        CType(Me.chkRestoreDeleteBackupAfterRestore.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.frmBackup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frmBackup.ResumeLayout(False)
        Me.frmBackup.PerformLayout()
        CType(Me.chkBackup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.frmMode1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frmMode1.ResumeLayout(False)
        Me.frmMode1.PerformLayout()
        CType(Me.Panel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.chkShotWithLRUD.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkShotWithCalculatedLRUD.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkShotWithoutLRUD.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.frmMode2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frmMode2.ResumeLayout(False)
        Me.frmMode2.PerformLayout()
        CType(Me.txtMode2V, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMode2H, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkMode2OnlyCutSplay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkMarkAsCalculated.Properties, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents frmMode1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents RadioButton1b As RadioButton
    Friend WithEvents RadioButton1a As RadioButton
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkBackup As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents Label1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboReplicateTo As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents frmBackup As DevExpress.XtraEditors.GroupControl
    Friend WithEvents Label3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboBackupName As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents frmRestore As DevExpress.XtraEditors.GroupControl
    Friend WithEvents Label4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboRestoreName As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkRestoreDeleteBackupAfterRestore As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents frmMode2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents chkMode2OnlyCutSplay As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents Label26 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtMode2V As NumericUpDown
    Friend WithEvents Label35 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtMode2H As NumericUpDown
    Friend WithEvents chkShotWithoutLRUD As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkMarkAsCalculated As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkShotWithCalculatedLRUD As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkShotWithLRUD As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblSplayMode As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboMode2Mode As ComboBox
    Friend WithEvents cboAction As ComboBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents lblAction As DevExpress.XtraEditors.LabelControl
    Friend WithEvents pnlOption0 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnlOption1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnlOption3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnlOptionOther As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnlBottom As DevExpress.XtraEditors.PanelControl
End Class
