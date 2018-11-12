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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.chkMorphingDisable = New System.Windows.Forms.CheckBox()
        Me.chkCalculateMode = New System.Windows.Forms.CheckBox()
        Me.lblDesignWarpingMode = New System.Windows.Forms.Label()
        Me.cboDesignWarpingMode = New System.Windows.Forms.ComboBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.chkCalculateModeEnabled = New System.Windows.Forms.CheckBox()
        Me.chkDesignWarpingModeEnabled = New System.Windows.Forms.CheckBox()
        Me.chkMorphingDisableEnabled = New System.Windows.Forms.CheckBox()
        Me.lblDesignWarpingModeEnabledIn = New System.Windows.Forms.Label()
        Me.chkProfileWarpingEnabled = New System.Windows.Forms.CheckBox()
        Me.chkPlanWarpingEnabled = New System.Windows.Forms.CheckBox()
        Me.chkUpgradeCalculateVersionEnabled = New System.Windows.Forms.CheckBox()
        Me.chkUpgradeCalculateVersion = New System.Windows.Forms.CheckBox()
        Me.chkUpgradeInversionModeEnabled = New System.Windows.Forms.CheckBox()
        Me.chkUpgradeInversionMode = New System.Windows.Forms.CheckBox()
        Me.chkRegenerateSegmentsIDEnabled = New System.Windows.Forms.CheckBox()
        Me.chkRegenerateSegmentsID = New System.Windows.Forms.CheckBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        '
        'lblDescription
        '
        resources.ApplyResources(Me.lblDescription, "lblDescription")
        Me.lblDescription.Name = "lblDescription"
        '
        'chkMorphingDisable
        '
        resources.ApplyResources(Me.chkMorphingDisable, "chkMorphingDisable")
        Me.chkMorphingDisable.Name = "chkMorphingDisable"
        Me.chkMorphingDisable.UseVisualStyleBackColor = True
        '
        'chkCalculateMode
        '
        resources.ApplyResources(Me.chkCalculateMode, "chkCalculateMode")
        Me.chkCalculateMode.Name = "chkCalculateMode"
        Me.chkCalculateMode.UseVisualStyleBackColor = True
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
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'chkCalculateModeEnabled
        '
        resources.ApplyResources(Me.chkCalculateModeEnabled, "chkCalculateModeEnabled")
        Me.chkCalculateModeEnabled.Name = "chkCalculateModeEnabled"
        Me.chkCalculateModeEnabled.UseVisualStyleBackColor = True
        '
        'chkDesignWarpingModeEnabled
        '
        resources.ApplyResources(Me.chkDesignWarpingModeEnabled, "chkDesignWarpingModeEnabled")
        Me.chkDesignWarpingModeEnabled.Name = "chkDesignWarpingModeEnabled"
        Me.chkDesignWarpingModeEnabled.UseVisualStyleBackColor = True
        '
        'chkMorphingDisableEnabled
        '
        resources.ApplyResources(Me.chkMorphingDisableEnabled, "chkMorphingDisableEnabled")
        Me.chkMorphingDisableEnabled.Name = "chkMorphingDisableEnabled"
        Me.chkMorphingDisableEnabled.UseVisualStyleBackColor = True
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
        Me.chkProfileWarpingEnabled.UseVisualStyleBackColor = True
        '
        'chkPlanWarpingEnabled
        '
        resources.ApplyResources(Me.chkPlanWarpingEnabled, "chkPlanWarpingEnabled")
        Me.chkPlanWarpingEnabled.Name = "chkPlanWarpingEnabled"
        Me.chkPlanWarpingEnabled.UseVisualStyleBackColor = True
        '
        'chkUpgradeCalculateVersionEnabled
        '
        resources.ApplyResources(Me.chkUpgradeCalculateVersionEnabled, "chkUpgradeCalculateVersionEnabled")
        Me.chkUpgradeCalculateVersionEnabled.Name = "chkUpgradeCalculateVersionEnabled"
        Me.chkUpgradeCalculateVersionEnabled.UseVisualStyleBackColor = True
        '
        'chkUpgradeCalculateVersion
        '
        resources.ApplyResources(Me.chkUpgradeCalculateVersion, "chkUpgradeCalculateVersion")
        Me.chkUpgradeCalculateVersion.Name = "chkUpgradeCalculateVersion"
        Me.chkUpgradeCalculateVersion.UseVisualStyleBackColor = True
        '
        'chkUpgradeInversionModeEnabled
        '
        resources.ApplyResources(Me.chkUpgradeInversionModeEnabled, "chkUpgradeInversionModeEnabled")
        Me.chkUpgradeInversionModeEnabled.Name = "chkUpgradeInversionModeEnabled"
        Me.chkUpgradeInversionModeEnabled.UseVisualStyleBackColor = True
        '
        'chkUpgradeInversionMode
        '
        resources.ApplyResources(Me.chkUpgradeInversionMode, "chkUpgradeInversionMode")
        Me.chkUpgradeInversionMode.Name = "chkUpgradeInversionMode"
        Me.chkUpgradeInversionMode.UseVisualStyleBackColor = True
        '
        'chkRegenerateSegmentsIDEnabled
        '
        resources.ApplyResources(Me.chkRegenerateSegmentsIDEnabled, "chkRegenerateSegmentsIDEnabled")
        Me.chkRegenerateSegmentsIDEnabled.Name = "chkRegenerateSegmentsIDEnabled"
        Me.chkRegenerateSegmentsIDEnabled.UseVisualStyleBackColor = True
        '
        'chkRegenerateSegmentsID
        '
        resources.ApplyResources(Me.chkRegenerateSegmentsID, "chkRegenerateSegmentsID")
        Me.chkRegenerateSegmentsID.Name = "chkRegenerateSegmentsID"
        Me.chkRegenerateSegmentsID.UseVisualStyleBackColor = True
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
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblDescription)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOpeningFlags"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents chkMorphingDisable As System.Windows.Forms.CheckBox
    Friend WithEvents chkCalculateMode As System.Windows.Forms.CheckBox
    Friend WithEvents lblDesignWarpingMode As System.Windows.Forms.Label
    Friend WithEvents cboDesignWarpingMode As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents chkCalculateModeEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents chkDesignWarpingModeEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents chkMorphingDisableEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents lblDesignWarpingModeEnabledIn As Label
    Friend WithEvents chkProfileWarpingEnabled As CheckBox
    Friend WithEvents chkPlanWarpingEnabled As CheckBox
    Friend WithEvents chkUpgradeCalculateVersionEnabled As CheckBox
    Friend WithEvents chkUpgradeCalculateVersion As CheckBox
    Friend WithEvents chkUpgradeInversionModeEnabled As CheckBox
    Friend WithEvents chkUpgradeInversionMode As CheckBox
    Friend WithEvents chkRegenerateSegmentsIDEnabled As CheckBox
    Friend WithEvents chkRegenerateSegmentsID As CheckBox
End Class
