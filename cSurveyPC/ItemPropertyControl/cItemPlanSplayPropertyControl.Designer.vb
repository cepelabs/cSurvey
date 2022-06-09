<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cItemPlanSplayPropertyControl
    Inherits cItemPropertyControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cItemPlanSplayPropertyControl))
        Me.lblPropPlanSplayInclinationRange = New DevExpress.XtraEditors.LabelControl()
        Me.txtPropPlanSplayInclinationRangeMax = New System.Windows.Forms.NumericUpDown()
        Me.txtPropPlanSplayInclinationRangeMin = New System.Windows.Forms.NumericUpDown()
        Me.cmdPropPlanSplay = New DevExpress.XtraEditors.SimpleButton()
        Me.lblPropPlanSplay = New DevExpress.XtraEditors.LabelControl()
        Me.lblPropPlanSplayPlanProjectionPlanType = New DevExpress.XtraEditors.LabelControl()
        Me.cboPropPlanSplayPlanProjectionType = New System.Windows.Forms.ComboBox()
        Me.txtPropPlanSplayPlanDeltaZ = New System.Windows.Forms.NumericUpDown()
        Me.lblPropPlanSplayPlanDeltaZ = New DevExpress.XtraEditors.LabelControl()
        Me.txtPropPlanSplayMaxVariationDelta = New System.Windows.Forms.NumericUpDown()
        Me.lblPropPlanSplayMaxVariationDelta = New DevExpress.XtraEditors.LabelControl()
        CType(Me.txtPropPlanSplayInclinationRangeMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropPlanSplayInclinationRangeMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropPlanSplayPlanDeltaZ, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropPlanSplayMaxVariationDelta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblPropPlanSplayInclinationRange
        '
        Me.lblPropPlanSplayInclinationRange.Appearance.Font = CType(resources.GetObject("lblPropPlanSplayInclinationRange.Appearance.Font"), System.Drawing.Font)
        Me.lblPropPlanSplayInclinationRange.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblPropPlanSplayInclinationRange, "lblPropPlanSplayInclinationRange")
        Me.lblPropPlanSplayInclinationRange.Name = "lblPropPlanSplayInclinationRange"
        '
        'txtPropPlanSplayInclinationRangeMax
        '
        Me.txtPropPlanSplayInclinationRangeMax.DecimalPlaces = 1
        Me.txtPropPlanSplayInclinationRangeMax.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        resources.ApplyResources(Me.txtPropPlanSplayInclinationRangeMax, "txtPropPlanSplayInclinationRangeMax")
        Me.txtPropPlanSplayInclinationRangeMax.Maximum = New Decimal(New Integer() {90, 0, 0, 0})
        Me.txtPropPlanSplayInclinationRangeMax.Minimum = New Decimal(New Integer() {90, 0, 0, -2147483648})
        Me.txtPropPlanSplayInclinationRangeMax.Name = "txtPropPlanSplayInclinationRangeMax"
        Me.txtPropPlanSplayInclinationRangeMax.Value = New Decimal(New Integer() {90, 0, 0, 0})
        '
        'txtPropPlanSplayInclinationRangeMin
        '
        Me.txtPropPlanSplayInclinationRangeMin.DecimalPlaces = 1
        Me.txtPropPlanSplayInclinationRangeMin.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        resources.ApplyResources(Me.txtPropPlanSplayInclinationRangeMin, "txtPropPlanSplayInclinationRangeMin")
        Me.txtPropPlanSplayInclinationRangeMin.Maximum = New Decimal(New Integer() {90, 0, 0, 0})
        Me.txtPropPlanSplayInclinationRangeMin.Minimum = New Decimal(New Integer() {90, 0, 0, -2147483648})
        Me.txtPropPlanSplayInclinationRangeMin.Name = "txtPropPlanSplayInclinationRangeMin"
        Me.txtPropPlanSplayInclinationRangeMin.Value = New Decimal(New Integer() {90, 0, 0, -2147483648})
        '
        'cmdPropPlanSplay
        '
        resources.ApplyResources(Me.cmdPropPlanSplay, "cmdPropPlanSplay")
        Me.cmdPropPlanSplay.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdPropPlanSplay.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.replicatesplaydata
        Me.cmdPropPlanSplay.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.cmdPropPlanSplay.Name = "cmdPropPlanSplay"
        '
        'lblPropPlanSplay
        '
        resources.ApplyResources(Me.lblPropPlanSplay, "lblPropPlanSplay")
        Me.lblPropPlanSplay.Name = "lblPropPlanSplay"
        '
        'lblPropPlanSplayPlanProjectionPlanType
        '
        Me.lblPropPlanSplayPlanProjectionPlanType.Appearance.Font = CType(resources.GetObject("lblPropPlanSplayPlanProjectionPlanType.Appearance.Font"), System.Drawing.Font)
        Me.lblPropPlanSplayPlanProjectionPlanType.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblPropPlanSplayPlanProjectionPlanType, "lblPropPlanSplayPlanProjectionPlanType")
        Me.lblPropPlanSplayPlanProjectionPlanType.Name = "lblPropPlanSplayPlanProjectionPlanType"
        '
        'cboPropPlanSplayPlanProjectionType
        '
        Me.cboPropPlanSplayPlanProjectionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboPropPlanSplayPlanProjectionType, "cboPropPlanSplayPlanProjectionType")
        Me.cboPropPlanSplayPlanProjectionType.Items.AddRange(New Object() {resources.GetString("cboPropPlanSplayPlanProjectionType.Items"), resources.GetString("cboPropPlanSplayPlanProjectionType.Items1"), resources.GetString("cboPropPlanSplayPlanProjectionType.Items2")})
        Me.cboPropPlanSplayPlanProjectionType.Name = "cboPropPlanSplayPlanProjectionType"
        '
        'txtPropPlanSplayPlanDeltaZ
        '
        Me.txtPropPlanSplayPlanDeltaZ.DecimalPlaces = 1
        Me.txtPropPlanSplayPlanDeltaZ.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        resources.ApplyResources(Me.txtPropPlanSplayPlanDeltaZ, "txtPropPlanSplayPlanDeltaZ")
        Me.txtPropPlanSplayPlanDeltaZ.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtPropPlanSplayPlanDeltaZ.Minimum = New Decimal(New Integer() {10000, 0, 0, -2147483648})
        Me.txtPropPlanSplayPlanDeltaZ.Name = "txtPropPlanSplayPlanDeltaZ"
        '
        'lblPropPlanSplayPlanDeltaZ
        '
        Me.lblPropPlanSplayPlanDeltaZ.Appearance.Font = CType(resources.GetObject("lblPropPlanSplayPlanDeltaZ.Appearance.Font"), System.Drawing.Font)
        Me.lblPropPlanSplayPlanDeltaZ.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblPropPlanSplayPlanDeltaZ, "lblPropPlanSplayPlanDeltaZ")
        Me.lblPropPlanSplayPlanDeltaZ.Name = "lblPropPlanSplayPlanDeltaZ"
        '
        'txtPropPlanSplayMaxVariationDelta
        '
        Me.txtPropPlanSplayMaxVariationDelta.DecimalPlaces = 1
        Me.txtPropPlanSplayMaxVariationDelta.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        resources.ApplyResources(Me.txtPropPlanSplayMaxVariationDelta, "txtPropPlanSplayMaxVariationDelta")
        Me.txtPropPlanSplayMaxVariationDelta.Name = "txtPropPlanSplayMaxVariationDelta"
        '
        'lblPropPlanSplayMaxVariationDelta
        '
        Me.lblPropPlanSplayMaxVariationDelta.Appearance.Font = CType(resources.GetObject("lblPropPlanSplayMaxVariationDelta.Appearance.Font"), System.Drawing.Font)
        Me.lblPropPlanSplayMaxVariationDelta.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblPropPlanSplayMaxVariationDelta, "lblPropPlanSplayMaxVariationDelta")
        Me.lblPropPlanSplayMaxVariationDelta.Name = "lblPropPlanSplayMaxVariationDelta"
        '
        'cItemPlanSplayPropertyControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.lblPropPlanSplayInclinationRange)
        Me.Controls.Add(Me.txtPropPlanSplayInclinationRangeMax)
        Me.Controls.Add(Me.txtPropPlanSplayInclinationRangeMin)
        Me.Controls.Add(Me.cmdPropPlanSplay)
        Me.Controls.Add(Me.lblPropPlanSplay)
        Me.Controls.Add(Me.lblPropPlanSplayPlanProjectionPlanType)
        Me.Controls.Add(Me.cboPropPlanSplayPlanProjectionType)
        Me.Controls.Add(Me.txtPropPlanSplayPlanDeltaZ)
        Me.Controls.Add(Me.lblPropPlanSplayPlanDeltaZ)
        Me.Controls.Add(Me.txtPropPlanSplayMaxVariationDelta)
        Me.Controls.Add(Me.lblPropPlanSplayMaxVariationDelta)
        Me.Name = "cItemPlanSplayPropertyControl"
        CType(Me.txtPropPlanSplayInclinationRangeMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropPlanSplayInclinationRangeMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropPlanSplayPlanDeltaZ, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropPlanSplayMaxVariationDelta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblPropPlanSplayInclinationRange As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPropPlanSplayInclinationRangeMax As NumericUpDown
    Friend WithEvents txtPropPlanSplayInclinationRangeMin As NumericUpDown
    Friend WithEvents cmdPropPlanSplay As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblPropPlanSplay As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPropPlanSplayPlanProjectionPlanType As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboPropPlanSplayPlanProjectionType As ComboBox
    Friend WithEvents txtPropPlanSplayPlanDeltaZ As NumericUpDown
    Friend WithEvents lblPropPlanSplayPlanDeltaZ As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPropPlanSplayMaxVariationDelta As NumericUpDown
    Friend WithEvents lblPropPlanSplayMaxVariationDelta As DevExpress.XtraEditors.LabelControl
End Class
