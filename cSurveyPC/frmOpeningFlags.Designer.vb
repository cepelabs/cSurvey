<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOpeningFlags
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOpeningFlags))
        Me.lblDescription = New DevExpress.XtraEditors.LabelControl()
        Me.chkMorphingDisable = New DevExpress.XtraEditors.CheckEdit()
        Me.chkCalculateMode = New DevExpress.XtraEditors.CheckEdit()
        Me.lblDesignWarpingMode = New DevExpress.XtraEditors.LabelControl()
        Me.cboDesignWarpingMode = New System.Windows.Forms.ComboBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.chkCalculateModeEnabled = New DevExpress.XtraEditors.CheckEdit()
        Me.chkDesignWarpingModeEnabled = New DevExpress.XtraEditors.CheckEdit()
        Me.chkMorphingDisableEnabled = New DevExpress.XtraEditors.CheckEdit()
        Me.lblDesignWarpingModeEnabledIn = New DevExpress.XtraEditors.LabelControl()
        Me.chkProfileWarpingEnabled = New DevExpress.XtraEditors.CheckEdit()
        Me.chkPlanWarpingEnabled = New DevExpress.XtraEditors.CheckEdit()
        Me.chkUpgradeCalculateVersionEnabled = New DevExpress.XtraEditors.CheckEdit()
        Me.chkUpgradeCalculateVersion = New DevExpress.XtraEditors.CheckEdit()
        Me.chkUpgradeInversionModeEnabled = New DevExpress.XtraEditors.CheckEdit()
        Me.chkUpgradeInversionMode = New DevExpress.XtraEditors.CheckEdit()
        Me.chkRegenerateSegmentsIDEnabled = New DevExpress.XtraEditors.CheckEdit()
        Me.chkRegenerateSegmentsID = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.chkMorphingDisable.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkCalculateMode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkCalculateModeEnabled.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkDesignWarpingModeEnabled.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkMorphingDisableEnabled.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkProfileWarpingEnabled.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPlanWarpingEnabled.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkUpgradeCalculateVersionEnabled.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkUpgradeCalculateVersion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkUpgradeInversionModeEnabled.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkUpgradeInversionMode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkRegenerateSegmentsIDEnabled.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkRegenerateSegmentsID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblDescription
        '
        Me.lblDescription.Appearance.Options.UseTextOptions = True
        Me.lblDescription.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        resources.ApplyResources(Me.lblDescription, "lblDescription")
        Me.lblDescription.Name = "lblDescription"
        '
        'chkMorphingDisable
        '
        resources.ApplyResources(Me.chkMorphingDisable, "chkMorphingDisable")
        Me.chkMorphingDisable.Name = "chkMorphingDisable"
        Me.chkMorphingDisable.Properties.Caption = resources.GetString("chkMorphingDisable.Properties.Caption")
        '
        'chkCalculateMode
        '
        resources.ApplyResources(Me.chkCalculateMode, "chkCalculateMode")
        Me.chkCalculateMode.Name = "chkCalculateMode"
        Me.chkCalculateMode.Properties.Caption = resources.GetString("chkCalculateMode.Properties.Caption")
        '
        'lblDesignWarpingMode
        '
        resources.ApplyResources(Me.lblDesignWarpingMode, "lblDesignWarpingMode")
        Me.lblDesignWarpingMode.Name = "lblDesignWarpingMode"
        '
        'cboDesignWarpingMode
        '
        Me.cboDesignWarpingMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboDesignWarpingMode, "cboDesignWarpingMode")
        Me.cboDesignWarpingMode.FormattingEnabled = True
        Me.cboDesignWarpingMode.Items.AddRange(New Object() {resources.GetString("cboDesignWarpingMode.Items"), resources.GetString("cboDesignWarpingMode.Items1")})
        Me.cboDesignWarpingMode.Name = "cboDesignWarpingMode"
        '
        'PictureBox2
        '
        resources.ApplyResources(Me.PictureBox2, "PictureBox2")
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.TabStop = False
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Name = "cmdCancel"
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Name = "cmdOk"
        '
        'chkCalculateModeEnabled
        '
        resources.ApplyResources(Me.chkCalculateModeEnabled, "chkCalculateModeEnabled")
        Me.chkCalculateModeEnabled.Name = "chkCalculateModeEnabled"
        Me.chkCalculateModeEnabled.Properties.AutoWidth = True
        Me.chkCalculateModeEnabled.Properties.Caption = resources.GetString("chkCalculateModeEnabled.Properties.Caption")
        '
        'chkDesignWarpingModeEnabled
        '
        resources.ApplyResources(Me.chkDesignWarpingModeEnabled, "chkDesignWarpingModeEnabled")
        Me.chkDesignWarpingModeEnabled.Name = "chkDesignWarpingModeEnabled"
        Me.chkDesignWarpingModeEnabled.Properties.AutoWidth = True
        Me.chkDesignWarpingModeEnabled.Properties.Caption = resources.GetString("chkDesignWarpingModeEnabled.Properties.Caption")
        '
        'chkMorphingDisableEnabled
        '
        resources.ApplyResources(Me.chkMorphingDisableEnabled, "chkMorphingDisableEnabled")
        Me.chkMorphingDisableEnabled.Name = "chkMorphingDisableEnabled"
        Me.chkMorphingDisableEnabled.Properties.AutoWidth = True
        Me.chkMorphingDisableEnabled.Properties.Caption = resources.GetString("chkMorphingDisableEnabled.Properties.Caption")
        '
        'lblDesignWarpingModeEnabledIn
        '
        resources.ApplyResources(Me.lblDesignWarpingModeEnabledIn, "lblDesignWarpingModeEnabledIn")
        Me.lblDesignWarpingModeEnabledIn.Name = "lblDesignWarpingModeEnabledIn"
        '
        'chkProfileWarpingEnabled
        '
        resources.ApplyResources(Me.chkProfileWarpingEnabled, "chkProfileWarpingEnabled")
        Me.chkProfileWarpingEnabled.Name = "chkProfileWarpingEnabled"
        Me.chkProfileWarpingEnabled.Properties.Caption = resources.GetString("chkProfileWarpingEnabled.Properties.Caption")
        '
        'chkPlanWarpingEnabled
        '
        resources.ApplyResources(Me.chkPlanWarpingEnabled, "chkPlanWarpingEnabled")
        Me.chkPlanWarpingEnabled.Name = "chkPlanWarpingEnabled"
        Me.chkPlanWarpingEnabled.Properties.Caption = resources.GetString("chkPlanWarpingEnabled.Properties.Caption")
        '
        'chkUpgradeCalculateVersionEnabled
        '
        resources.ApplyResources(Me.chkUpgradeCalculateVersionEnabled, "chkUpgradeCalculateVersionEnabled")
        Me.chkUpgradeCalculateVersionEnabled.Name = "chkUpgradeCalculateVersionEnabled"
        Me.chkUpgradeCalculateVersionEnabled.Properties.AutoWidth = True
        Me.chkUpgradeCalculateVersionEnabled.Properties.Caption = resources.GetString("chkUpgradeCalculateVersionEnabled.Properties.Caption")
        '
        'chkUpgradeCalculateVersion
        '
        resources.ApplyResources(Me.chkUpgradeCalculateVersion, "chkUpgradeCalculateVersion")
        Me.chkUpgradeCalculateVersion.Name = "chkUpgradeCalculateVersion"
        Me.chkUpgradeCalculateVersion.Properties.Caption = resources.GetString("chkUpgradeCalculateVersion.Properties.Caption")
        '
        'chkUpgradeInversionModeEnabled
        '
        resources.ApplyResources(Me.chkUpgradeInversionModeEnabled, "chkUpgradeInversionModeEnabled")
        Me.chkUpgradeInversionModeEnabled.Name = "chkUpgradeInversionModeEnabled"
        Me.chkUpgradeInversionModeEnabled.Properties.AutoWidth = True
        Me.chkUpgradeInversionModeEnabled.Properties.Caption = resources.GetString("chkUpgradeInversionModeEnabled.Properties.Caption")
        '
        'chkUpgradeInversionMode
        '
        resources.ApplyResources(Me.chkUpgradeInversionMode, "chkUpgradeInversionMode")
        Me.chkUpgradeInversionMode.Name = "chkUpgradeInversionMode"
        Me.chkUpgradeInversionMode.Properties.Caption = resources.GetString("chkUpgradeInversionMode.Properties.Caption")
        '
        'chkRegenerateSegmentsIDEnabled
        '
        resources.ApplyResources(Me.chkRegenerateSegmentsIDEnabled, "chkRegenerateSegmentsIDEnabled")
        Me.chkRegenerateSegmentsIDEnabled.Name = "chkRegenerateSegmentsIDEnabled"
        Me.chkRegenerateSegmentsIDEnabled.Properties.AutoWidth = True
        Me.chkRegenerateSegmentsIDEnabled.Properties.Caption = resources.GetString("chkRegenerateSegmentsIDEnabled.Properties.Caption")
        '
        'chkRegenerateSegmentsID
        '
        resources.ApplyResources(Me.chkRegenerateSegmentsID, "chkRegenerateSegmentsID")
        Me.chkRegenerateSegmentsID.Name = "chkRegenerateSegmentsID"
        Me.chkRegenerateSegmentsID.Properties.Caption = resources.GetString("chkRegenerateSegmentsID.Properties.Caption")
        '
        'frmOpeningFlags
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.chkRegenerateSegmentsIDEnabled)
        Me.Controls.Add(Me.chkRegenerateSegmentsID)
        Me.Controls.Add(Me.chkUpgradeInversionModeEnabled)
        Me.Controls.Add(Me.chkUpgradeInversionMode)
        Me.Controls.Add(Me.chkUpgradeCalculateVersionEnabled)
        Me.Controls.Add(Me.chkUpgradeCalculateVersion)
        Me.Controls.Add(Me.lblDesignWarpingModeEnabledIn)
        Me.Controls.Add(Me.chkProfileWarpingEnabled)
        Me.Controls.Add(Me.chkPlanWarpingEnabled)
        Me.Controls.Add(Me.chkMorphingDisableEnabled)
        Me.Controls.Add(Me.chkDesignWarpingModeEnabled)
        Me.Controls.Add(Me.chkCalculateModeEnabled)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.chkCalculateMode)
        Me.Controls.Add(Me.lblDesignWarpingMode)
        Me.Controls.Add(Me.cboDesignWarpingMode)
        Me.Controls.Add(Me.chkMorphingDisable)
        Me.Controls.Add(Me.lblDescription)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.swissknife
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOpeningFlags"
        CType(Me.chkMorphingDisable.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkCalculateMode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkCalculateModeEnabled.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkDesignWarpingModeEnabled.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkMorphingDisableEnabled.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkProfileWarpingEnabled.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPlanWarpingEnabled.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkUpgradeCalculateVersionEnabled.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkUpgradeCalculateVersion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkUpgradeInversionModeEnabled.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkUpgradeInversionMode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkRegenerateSegmentsIDEnabled.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkRegenerateSegmentsID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblDescription As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkMorphingDisable As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkCalculateMode As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblDesignWarpingMode As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboDesignWarpingMode As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkCalculateModeEnabled As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkDesignWarpingModeEnabled As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkMorphingDisableEnabled As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblDesignWarpingModeEnabledIn As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkProfileWarpingEnabled As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkPlanWarpingEnabled As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkUpgradeCalculateVersionEnabled As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkUpgradeCalculateVersion As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkUpgradeInversionModeEnabled As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkUpgradeInversionMode As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkRegenerateSegmentsIDEnabled As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkRegenerateSegmentsID As DevExpress.XtraEditors.CheckEdit
End Class
