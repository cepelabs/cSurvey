<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cItemProfileSplayPropertyControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cItemProfileSplayPropertyControl))
        Me.lblPropPlanSplay = New DevExpress.XtraEditors.LabelControl()
        Me.txtPropProfileSplayNegInclinationRangeMax = New System.Windows.Forms.NumericUpDown()
        Me.txtPropProfileSplayNegInclinationRangeMin = New System.Windows.Forms.NumericUpDown()
        Me.lblPropProfileSplayNegInclinationRange = New DevExpress.XtraEditors.LabelControl()
        Me.txtPropProfileSplayPosInclinationRangeMax = New System.Windows.Forms.NumericUpDown()
        Me.txtPropProfileSplayPosInclinationRangeMin = New System.Windows.Forms.NumericUpDown()
        Me.cmdPropProfileSplay = New DevExpress.XtraEditors.SimpleButton()
        Me.txtPropProfileSplayMaxVariationAngle = New System.Windows.Forms.NumericUpDown()
        Me.lblPropProfileSplayMaxVariationAngle = New DevExpress.XtraEditors.LabelControl()
        Me.lblPropProfileSplayProjectionAngle = New DevExpress.XtraEditors.LabelControl()
        Me.txtPropProfileSplayProjectionAngle = New System.Windows.Forms.NumericUpDown()
        Me.lblPropProfileSplayPosInclinationRange = New DevExpress.XtraEditors.LabelControl()
        Me.picPropProfileProjectionSchema = New DevExpress.XtraEditors.PictureEdit()
        CType(Me.txtPropProfileSplayNegInclinationRangeMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropProfileSplayNegInclinationRangeMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropProfileSplayPosInclinationRangeMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropProfileSplayPosInclinationRangeMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropProfileSplayMaxVariationAngle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropProfileSplayProjectionAngle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPropProfileProjectionSchema.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblPropPlanSplay
        '
        resources.ApplyResources(Me.lblPropPlanSplay, "lblPropPlanSplay")
        Me.lblPropPlanSplay.Name = "lblPropPlanSplay"
        '
        'txtPropProfileSplayNegInclinationRangeMax
        '
        Me.txtPropProfileSplayNegInclinationRangeMax.DecimalPlaces = 1
        Me.txtPropProfileSplayNegInclinationRangeMax.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        resources.ApplyResources(Me.txtPropProfileSplayNegInclinationRangeMax, "txtPropProfileSplayNegInclinationRangeMax")
        Me.txtPropProfileSplayNegInclinationRangeMax.Maximum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtPropProfileSplayNegInclinationRangeMax.Minimum = New Decimal(New Integer() {90, 0, 0, -2147483648})
        Me.txtPropProfileSplayNegInclinationRangeMax.Name = "txtPropProfileSplayNegInclinationRangeMax"
        '
        'txtPropProfileSplayNegInclinationRangeMin
        '
        Me.txtPropProfileSplayNegInclinationRangeMin.DecimalPlaces = 1
        Me.txtPropProfileSplayNegInclinationRangeMin.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        resources.ApplyResources(Me.txtPropProfileSplayNegInclinationRangeMin, "txtPropProfileSplayNegInclinationRangeMin")
        Me.txtPropProfileSplayNegInclinationRangeMin.Maximum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtPropProfileSplayNegInclinationRangeMin.Minimum = New Decimal(New Integer() {90, 0, 0, -2147483648})
        Me.txtPropProfileSplayNegInclinationRangeMin.Name = "txtPropProfileSplayNegInclinationRangeMin"
        Me.txtPropProfileSplayNegInclinationRangeMin.Value = New Decimal(New Integer() {90, 0, 0, -2147483648})
        '
        'lblPropProfileSplayNegInclinationRange
        '
        Me.lblPropProfileSplayNegInclinationRange.Appearance.Font = CType(resources.GetObject("lblPropProfileSplayNegInclinationRange.Appearance.Font"), System.Drawing.Font)
        Me.lblPropProfileSplayNegInclinationRange.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblPropProfileSplayNegInclinationRange, "lblPropProfileSplayNegInclinationRange")
        Me.lblPropProfileSplayNegInclinationRange.Name = "lblPropProfileSplayNegInclinationRange"
        '
        'txtPropProfileSplayPosInclinationRangeMax
        '
        Me.txtPropProfileSplayPosInclinationRangeMax.DecimalPlaces = 1
        Me.txtPropProfileSplayPosInclinationRangeMax.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        resources.ApplyResources(Me.txtPropProfileSplayPosInclinationRangeMax, "txtPropProfileSplayPosInclinationRangeMax")
        Me.txtPropProfileSplayPosInclinationRangeMax.Maximum = New Decimal(New Integer() {90, 0, 0, 0})
        Me.txtPropProfileSplayPosInclinationRangeMax.Name = "txtPropProfileSplayPosInclinationRangeMax"
        Me.txtPropProfileSplayPosInclinationRangeMax.Value = New Decimal(New Integer() {90, 0, 0, 0})
        '
        'txtPropProfileSplayPosInclinationRangeMin
        '
        Me.txtPropProfileSplayPosInclinationRangeMin.DecimalPlaces = 1
        Me.txtPropProfileSplayPosInclinationRangeMin.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        resources.ApplyResources(Me.txtPropProfileSplayPosInclinationRangeMin, "txtPropProfileSplayPosInclinationRangeMin")
        Me.txtPropProfileSplayPosInclinationRangeMin.Maximum = New Decimal(New Integer() {90, 0, 0, 0})
        Me.txtPropProfileSplayPosInclinationRangeMin.Name = "txtPropProfileSplayPosInclinationRangeMin"
        '
        'cmdPropProfileSplay
        '
        resources.ApplyResources(Me.cmdPropProfileSplay, "cmdPropProfileSplay")
        Me.cmdPropProfileSplay.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdPropProfileSplay.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.replicatesplaydata
        Me.cmdPropProfileSplay.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.cmdPropProfileSplay.Name = "cmdPropProfileSplay"
        '
        'txtPropProfileSplayMaxVariationAngle
        '
        resources.ApplyResources(Me.txtPropProfileSplayMaxVariationAngle, "txtPropProfileSplayMaxVariationAngle")
        Me.txtPropProfileSplayMaxVariationAngle.Maximum = New Decimal(New Integer() {180, 0, 0, 0})
        Me.txtPropProfileSplayMaxVariationAngle.Name = "txtPropProfileSplayMaxVariationAngle"
        '
        'lblPropProfileSplayMaxVariationAngle
        '
        Me.lblPropProfileSplayMaxVariationAngle.Appearance.Font = CType(resources.GetObject("lblPropProfileSplayMaxVariationAngle.Appearance.Font"), System.Drawing.Font)
        Me.lblPropProfileSplayMaxVariationAngle.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblPropProfileSplayMaxVariationAngle, "lblPropProfileSplayMaxVariationAngle")
        Me.lblPropProfileSplayMaxVariationAngle.Name = "lblPropProfileSplayMaxVariationAngle"
        '
        'lblPropProfileSplayProjectionAngle
        '
        Me.lblPropProfileSplayProjectionAngle.Appearance.Font = CType(resources.GetObject("lblPropProfileSplayProjectionAngle.Appearance.Font"), System.Drawing.Font)
        Me.lblPropProfileSplayProjectionAngle.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblPropProfileSplayProjectionAngle, "lblPropProfileSplayProjectionAngle")
        Me.lblPropProfileSplayProjectionAngle.Name = "lblPropProfileSplayProjectionAngle"
        '
        'txtPropProfileSplayProjectionAngle
        '
        resources.ApplyResources(Me.txtPropProfileSplayProjectionAngle, "txtPropProfileSplayProjectionAngle")
        Me.txtPropProfileSplayProjectionAngle.Maximum = New Decimal(New Integer() {90, 0, 0, 0})
        Me.txtPropProfileSplayProjectionAngle.Minimum = New Decimal(New Integer() {90, 0, 0, -2147483648})
        Me.txtPropProfileSplayProjectionAngle.Name = "txtPropProfileSplayProjectionAngle"
        '
        'lblPropProfileSplayPosInclinationRange
        '
        Me.lblPropProfileSplayPosInclinationRange.Appearance.Font = CType(resources.GetObject("lblPropProfileSplayPosInclinationRange.Appearance.Font"), System.Drawing.Font)
        Me.lblPropProfileSplayPosInclinationRange.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblPropProfileSplayPosInclinationRange, "lblPropProfileSplayPosInclinationRange")
        Me.lblPropProfileSplayPosInclinationRange.Name = "lblPropProfileSplayPosInclinationRange"
        '
        'picPropProfileProjectionSchema
        '
        resources.ApplyResources(Me.picPropProfileProjectionSchema, "picPropProfileProjectionSchema")
        Me.picPropProfileProjectionSchema.Name = "picPropProfileProjectionSchema"
        Me.picPropProfileProjectionSchema.Properties.NullText = resources.GetString("picPropProfileProjectionSchema.Properties.NullText")
        Me.picPropProfileProjectionSchema.Properties.PictureInterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
        Me.picPropProfileProjectionSchema.Properties.ReadOnly = True
        Me.picPropProfileProjectionSchema.Properties.ShowEditMenuItem = DevExpress.Utils.DefaultBoolean.[False]
        Me.picPropProfileProjectionSchema.Properties.ShowMenu = False
        Me.picPropProfileProjectionSchema.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        '
        'cItemProfileSplayPropertyControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.txtPropProfileSplayNegInclinationRangeMax)
        Me.Controls.Add(Me.txtPropProfileSplayNegInclinationRangeMin)
        Me.Controls.Add(Me.lblPropProfileSplayNegInclinationRange)
        Me.Controls.Add(Me.txtPropProfileSplayPosInclinationRangeMax)
        Me.Controls.Add(Me.txtPropProfileSplayPosInclinationRangeMin)
        Me.Controls.Add(Me.txtPropProfileSplayMaxVariationAngle)
        Me.Controls.Add(Me.lblPropProfileSplayMaxVariationAngle)
        Me.Controls.Add(Me.lblPropProfileSplayProjectionAngle)
        Me.Controls.Add(Me.txtPropProfileSplayProjectionAngle)
        Me.Controls.Add(Me.lblPropProfileSplayPosInclinationRange)
        Me.Controls.Add(Me.lblPropPlanSplay)
        Me.Controls.Add(Me.picPropProfileProjectionSchema)
        Me.Controls.Add(Me.cmdPropProfileSplay)
        Me.Name = "cItemProfileSplayPropertyControl"
        CType(Me.txtPropProfileSplayNegInclinationRangeMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropProfileSplayNegInclinationRangeMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropProfileSplayPosInclinationRangeMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropProfileSplayPosInclinationRangeMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropProfileSplayMaxVariationAngle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropProfileSplayProjectionAngle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPropProfileProjectionSchema.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblPropPlanSplay As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPropProfileSplayNegInclinationRangeMax As NumericUpDown
    Friend WithEvents txtPropProfileSplayNegInclinationRangeMin As NumericUpDown
    Friend WithEvents lblPropProfileSplayNegInclinationRange As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPropProfileSplayPosInclinationRangeMax As NumericUpDown
    Friend WithEvents txtPropProfileSplayPosInclinationRangeMin As NumericUpDown
    Friend WithEvents cmdPropProfileSplay As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtPropProfileSplayMaxVariationAngle As NumericUpDown
    Friend WithEvents lblPropProfileSplayMaxVariationAngle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPropProfileSplayProjectionAngle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPropProfileSplayProjectionAngle As NumericUpDown
    Friend WithEvents lblPropProfileSplayPosInclinationRange As DevExpress.XtraEditors.LabelControl
    Friend WithEvents picPropProfileProjectionSchema As DevExpress.XtraEditors.PictureEdit
End Class
