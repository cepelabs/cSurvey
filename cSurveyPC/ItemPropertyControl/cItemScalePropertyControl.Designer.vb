<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cItemScalePropertyControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cItemScalePropertyControl))
        Me.lblScaleStep = New DevExpress.XtraEditors.LabelControl()
        Me.txtScaleStep = New System.Windows.Forms.NumericUpDown()
        Me.lblScaleColor = New DevExpress.XtraEditors.LabelControl()
        Me.lblScaleSteps = New DevExpress.XtraEditors.LabelControl()
        Me.txtScaleSteps = New System.Windows.Forms.NumericUpDown()
        Me.lblScaleMeters = New DevExpress.XtraEditors.LabelControl()
        Me.txtScaleMeters = New System.Windows.Forms.NumericUpDown()
        Me.label3 = New DevExpress.XtraEditors.LabelControl()
        Me.label4 = New DevExpress.XtraEditors.LabelControl()
        Me.label5 = New DevExpress.XtraEditors.LabelControl()
        Me.chkHideScaleValue = New DevExpress.XtraEditors.CheckEdit()
        Me.lblScaleMetersUM = New DevExpress.XtraEditors.LabelControl()
        Me.lblScaleStepUM = New DevExpress.XtraEditors.LabelControl()
        Me.txtScaleScaleHeightFactor = New System.Windows.Forms.NumericUpDown()
        Me.lblScaleScaleHeightFactor = New DevExpress.XtraEditors.LabelControl()
        Me.cboPropScaleFillStyle = New System.Windows.Forms.ComboBox()
        Me.lblPropScaleFillStyle = New DevExpress.XtraEditors.LabelControl()
        Me.txtScaleColor = New cSurveyPC.cColorSelector()
        CType(Me.txtScaleStep, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtScaleSteps, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtScaleMeters, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkHideScaleValue.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtScaleScaleHeightFactor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtScaleColor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblScaleStep
        '
        resources.ApplyResources(Me.lblScaleStep, "lblScaleStep")
        Me.lblScaleStep.Name = "lblScaleStep"
        '
        'txtScaleStep
        '
        resources.ApplyResources(Me.txtScaleStep, "txtScaleStep")
        Me.txtScaleStep.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtScaleStep.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtScaleStep.Name = "txtScaleStep"
        Me.txtScaleStep.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblScaleColor
        '
        resources.ApplyResources(Me.lblScaleColor, "lblScaleColor")
        Me.lblScaleColor.Name = "lblScaleColor"
        '
        'lblScaleSteps
        '
        resources.ApplyResources(Me.lblScaleSteps, "lblScaleSteps")
        Me.lblScaleSteps.Name = "lblScaleSteps"
        '
        'txtScaleSteps
        '
        Me.txtScaleSteps.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        resources.ApplyResources(Me.txtScaleSteps, "txtScaleSteps")
        Me.txtScaleSteps.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtScaleSteps.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.txtScaleSteps.Name = "txtScaleSteps"
        Me.txtScaleSteps.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'lblScaleMeters
        '
        resources.ApplyResources(Me.lblScaleMeters, "lblScaleMeters")
        Me.lblScaleMeters.Name = "lblScaleMeters"
        '
        'txtScaleMeters
        '
        Me.txtScaleMeters.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        resources.ApplyResources(Me.txtScaleMeters, "txtScaleMeters")
        Me.txtScaleMeters.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtScaleMeters.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.txtScaleMeters.Name = "txtScaleMeters"
        Me.txtScaleMeters.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'label3
        '
        resources.ApplyResources(Me.label3, "label3")
        Me.label3.Name = "label3"
        '
        'label4
        '
        resources.ApplyResources(Me.label4, "label4")
        Me.label4.Name = "label4"
        '
        'label5
        '
        resources.ApplyResources(Me.label5, "label5")
        Me.label5.Name = "label5"
        '
        'chkHideScaleValue
        '
        resources.ApplyResources(Me.chkHideScaleValue, "chkHideScaleValue")
        Me.chkHideScaleValue.Name = "chkHideScaleValue"
        Me.chkHideScaleValue.Properties.Caption = resources.GetString("chkHideScaleValue.Properties.Caption")
        '
        'lblScaleMetersUM
        '
        resources.ApplyResources(Me.lblScaleMetersUM, "lblScaleMetersUM")
        Me.lblScaleMetersUM.Name = "lblScaleMetersUM"
        '
        'lblScaleStepUM
        '
        resources.ApplyResources(Me.lblScaleStepUM, "lblScaleStepUM")
        Me.lblScaleStepUM.Name = "lblScaleStepUM"
        '
        'txtScaleScaleHeightFactor
        '
        Me.txtScaleScaleHeightFactor.DecimalPlaces = 2
        Me.txtScaleScaleHeightFactor.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        resources.ApplyResources(Me.txtScaleScaleHeightFactor, "txtScaleScaleHeightFactor")
        Me.txtScaleScaleHeightFactor.Minimum = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.txtScaleScaleHeightFactor.Name = "txtScaleScaleHeightFactor"
        Me.txtScaleScaleHeightFactor.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblScaleScaleHeightFactor
        '
        resources.ApplyResources(Me.lblScaleScaleHeightFactor, "lblScaleScaleHeightFactor")
        Me.lblScaleScaleHeightFactor.Name = "lblScaleScaleHeightFactor"
        '
        'cboPropScaleFillStyle
        '
        Me.cboPropScaleFillStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropScaleFillStyle.FormattingEnabled = True
        Me.cboPropScaleFillStyle.Items.AddRange(New Object() {resources.GetString("cboPropScaleFillStyle.Items"), resources.GetString("cboPropScaleFillStyle.Items1")})
        resources.ApplyResources(Me.cboPropScaleFillStyle, "cboPropScaleFillStyle")
        Me.cboPropScaleFillStyle.Name = "cboPropScaleFillStyle"
        '
        'lblPropScaleFillStyle
        '
        resources.ApplyResources(Me.lblPropScaleFillStyle, "lblPropScaleFillStyle")
        Me.lblPropScaleFillStyle.Name = "lblPropScaleFillStyle"
        '
        'txtScaleColor
        '
        Me.txtScaleColor.DefaultColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.txtScaleColor, "txtScaleColor")
        Me.txtScaleColor.Name = "txtScaleColor"
        Me.txtScaleColor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtScaleColor.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtScaleColor.Properties.ColorAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtScaleColor.Properties.ShowSystemColors = False
        Me.txtScaleColor.Properties.ShowWebColors = False
        '
        'cItemScalePropertyControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.txtScaleColor)
        Me.Controls.Add(Me.cboPropScaleFillStyle)
        Me.Controls.Add(Me.lblPropScaleFillStyle)
        Me.Controls.Add(Me.txtScaleScaleHeightFactor)
        Me.Controls.Add(Me.lblScaleScaleHeightFactor)
        Me.Controls.Add(Me.lblScaleStepUM)
        Me.Controls.Add(Me.lblScaleMetersUM)
        Me.Controls.Add(Me.chkHideScaleValue)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.lblScaleStep)
        Me.Controls.Add(Me.txtScaleStep)
        Me.Controls.Add(Me.lblScaleColor)
        Me.Controls.Add(Me.lblScaleSteps)
        Me.Controls.Add(Me.txtScaleSteps)
        Me.Controls.Add(Me.lblScaleMeters)
        Me.Controls.Add(Me.txtScaleMeters)
        Me.Name = "cItemScalePropertyControl"
        CType(Me.txtScaleStep, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtScaleSteps, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtScaleMeters, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkHideScaleValue.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtScaleScaleHeightFactor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtScaleColor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblScaleStep As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtScaleStep As NumericUpDown
    Friend WithEvents lblScaleColor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblScaleSteps As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtScaleSteps As NumericUpDown
    Friend WithEvents lblScaleMeters As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtScaleMeters As NumericUpDown
    Friend WithEvents label3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents label4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents label5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkHideScaleValue As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblScaleMetersUM As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblScaleStepUM As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtScaleScaleHeightFactor As NumericUpDown
    Friend WithEvents lblScaleScaleHeightFactor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboPropScaleFillStyle As ComboBox
    Friend WithEvents lblPropScaleFillStyle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtScaleColor As cColorSelector
End Class
