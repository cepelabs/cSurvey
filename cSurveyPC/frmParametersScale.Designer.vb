<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmParametersScale
    Inherits DevExpress.XtraEditors.XtraUserControl

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmParametersScale))
        Me.lblCompassClipartZoomFactor = New DevExpress.XtraEditors.LabelControl()
        Me.txtScaleMeters = New DevExpress.XtraEditors.SpinEdit()
        Me.lblScaleSteps = New DevExpress.XtraEditors.LabelControl()
        Me.txtScaleSteps = New DevExpress.XtraEditors.SpinEdit()
        Me.chkScaleTextFontUnderline = New DevExpress.XtraEditors.CheckButton()
        Me.chkScaleTextFontItalic = New DevExpress.XtraEditors.CheckButton()
        Me.chkScaleTextFontBold = New DevExpress.XtraEditors.CheckButton()
        Me.lblScaleTextFontChar = New DevExpress.XtraEditors.LabelControl()
        Me.cboScaleTextFontSize = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblScaleTextFontSize = New DevExpress.XtraEditors.LabelControl()
        Me.lblScaleColor = New DevExpress.XtraEditors.LabelControl()
        Me.Label2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtScaleText = New DevExpress.XtraEditors.TextEdit()
        Me.lblScaleStep = New DevExpress.XtraEditors.LabelControl()
        Me.txtScaleStep = New DevExpress.XtraEditors.SpinEdit()
        Me.chkHideScaleValue = New DevExpress.XtraEditors.CheckEdit()
        Me.cboScaleTextFontChar = New DevExpress.XtraEditors.FontEdit()
        Me.txtScaleColor = New cColorSelector
        CType(Me.txtScaleMeters.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtScaleSteps.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboScaleTextFontSize.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtScaleText.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtScaleStep.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkHideScaleValue.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboScaleTextFontChar.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtScaleColor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblCompassClipartZoomFactor
        '
        resources.ApplyResources(Me.lblCompassClipartZoomFactor, "lblCompassClipartZoomFactor")
        Me.lblCompassClipartZoomFactor.Name = "lblCompassClipartZoomFactor"
        '
        'txtScaleMeters
        '
        resources.ApplyResources(Me.txtScaleMeters, "txtScaleMeters")
        Me.txtScaleMeters.Name = "txtScaleMeters"
        Me.txtScaleMeters.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtScaleMeters.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtScaleMeters.Properties.DisplayFormat.FormatString = "N0"
        Me.txtScaleMeters.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtScaleMeters.Properties.EditFormat.FormatString = "N0"
        Me.txtScaleMeters.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtScaleMeters.Properties.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.txtScaleMeters.Properties.IsFloatValue = False
        Me.txtScaleMeters.Properties.MaskSettings.Set("mask", "N00")
        Me.txtScaleMeters.Properties.MaxValue = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtScaleMeters.Properties.MinValue = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'lblScaleSteps
        '
        resources.ApplyResources(Me.lblScaleSteps, "lblScaleSteps")
        Me.lblScaleSteps.Name = "lblScaleSteps"
        '
        'txtScaleSteps
        '
        resources.ApplyResources(Me.txtScaleSteps, "txtScaleSteps")
        Me.txtScaleSteps.Name = "txtScaleSteps"
        Me.txtScaleSteps.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtScaleSteps.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtScaleSteps.Properties.DisplayFormat.FormatString = "N0"
        Me.txtScaleSteps.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtScaleSteps.Properties.EditFormat.FormatString = "N0"
        Me.txtScaleSteps.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtScaleSteps.Properties.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.txtScaleSteps.Properties.IsFloatValue = False
        Me.txtScaleSteps.Properties.MaskSettings.Set("mask", "N00")
        Me.txtScaleSteps.Properties.MaxValue = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtScaleSteps.Properties.MinValue = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'chkScaleTextFontUnderline
        '
        Me.chkScaleTextFontUnderline.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.chkScaleTextFontUnderline.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.underline
        Me.chkScaleTextFontUnderline.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.chkScaleTextFontUnderline, "chkScaleTextFontUnderline")
        Me.chkScaleTextFontUnderline.Name = "chkScaleTextFontUnderline"
        '
        'chkScaleTextFontItalic
        '
        Me.chkScaleTextFontItalic.ImageOptions.Image = Global.cSurveyPC.My.Resources.Resources.text_italic
        Me.chkScaleTextFontItalic.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.chkScaleTextFontItalic.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.italic
        Me.chkScaleTextFontItalic.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.chkScaleTextFontItalic, "chkScaleTextFontItalic")
        Me.chkScaleTextFontItalic.Name = "chkScaleTextFontItalic"
        '
        'chkScaleTextFontBold
        '
        Me.chkScaleTextFontBold.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.chkScaleTextFontBold.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.bold
        Me.chkScaleTextFontBold.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.chkScaleTextFontBold, "chkScaleTextFontBold")
        Me.chkScaleTextFontBold.Name = "chkScaleTextFontBold"
        '
        'lblScaleTextFontChar
        '
        resources.ApplyResources(Me.lblScaleTextFontChar, "lblScaleTextFontChar")
        Me.lblScaleTextFontChar.Name = "lblScaleTextFontChar"
        '
        'cboScaleTextFontSize
        '
        resources.ApplyResources(Me.cboScaleTextFontSize, "cboScaleTextFontSize")
        Me.cboScaleTextFontSize.Name = "cboScaleTextFontSize"
        Me.cboScaleTextFontSize.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboScaleTextFontSize.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboScaleTextFontSize.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines)), New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboScaleTextFontSize.Properties.Buttons1"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboScaleTextFontSize.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.cboScaleTextFontSize.Properties.Items.AddRange(New Object() {resources.GetString("cboScaleTextFontSize.Properties.Items"), resources.GetString("cboScaleTextFontSize.Properties.Items1"), resources.GetString("cboScaleTextFontSize.Properties.Items2"), resources.GetString("cboScaleTextFontSize.Properties.Items3"), resources.GetString("cboScaleTextFontSize.Properties.Items4"), resources.GetString("cboScaleTextFontSize.Properties.Items5"), resources.GetString("cboScaleTextFontSize.Properties.Items6"), resources.GetString("cboScaleTextFontSize.Properties.Items7"), resources.GetString("cboScaleTextFontSize.Properties.Items8"), resources.GetString("cboScaleTextFontSize.Properties.Items9"), resources.GetString("cboScaleTextFontSize.Properties.Items10"), resources.GetString("cboScaleTextFontSize.Properties.Items11"), resources.GetString("cboScaleTextFontSize.Properties.Items12"), resources.GetString("cboScaleTextFontSize.Properties.Items13"), resources.GetString("cboScaleTextFontSize.Properties.Items14"), resources.GetString("cboScaleTextFontSize.Properties.Items15"), resources.GetString("cboScaleTextFontSize.Properties.Items16")})
        Me.cboScaleTextFontSize.Properties.NullText = resources.GetString("cboScaleTextFontSize.Properties.NullText")
        '
        'lblScaleTextFontSize
        '
        resources.ApplyResources(Me.lblScaleTextFontSize, "lblScaleTextFontSize")
        Me.lblScaleTextFontSize.Name = "lblScaleTextFontSize"
        '
        'lblScaleColor
        '
        resources.ApplyResources(Me.lblScaleColor, "lblScaleColor")
        Me.lblScaleColor.Name = "lblScaleColor"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'txtScaleText
        '
        resources.ApplyResources(Me.txtScaleText, "txtScaleText")
        Me.txtScaleText.Name = "txtScaleText"
        '
        'lblScaleStep
        '
        resources.ApplyResources(Me.lblScaleStep, "lblScaleStep")
        Me.lblScaleStep.Name = "lblScaleStep"
        '
        'txtScaleStep
        '
        resources.ApplyResources(Me.txtScaleStep, "txtScaleStep")
        Me.txtScaleStep.Name = "txtScaleStep"
        Me.txtScaleStep.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtScaleStep.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtScaleStep.Properties.DisplayFormat.FormatString = "N0"
        Me.txtScaleStep.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtScaleStep.Properties.EditFormat.FormatString = "N0"
        Me.txtScaleStep.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtScaleStep.Properties.IsFloatValue = False
        Me.txtScaleStep.Properties.MaskSettings.Set("mask", "N00")
        Me.txtScaleStep.Properties.MaxValue = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtScaleStep.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'chkHideScaleValue
        '
        resources.ApplyResources(Me.chkHideScaleValue, "chkHideScaleValue")
        Me.chkHideScaleValue.Name = "chkHideScaleValue"
        Me.chkHideScaleValue.Properties.Caption = resources.GetString("chkHideScaleValue.Properties.Caption")
        '
        'cboScaleTextFontChar
        '
        resources.ApplyResources(Me.cboScaleTextFontChar, "cboScaleTextFontChar")
        Me.cboScaleTextFontChar.Name = "cboScaleTextFontChar"
        Me.cboScaleTextFontChar.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboScaleTextFontChar.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboScaleTextFontChar.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines)), New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboScaleTextFontChar.Properties.Buttons1"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboScaleTextFontChar.Properties.NullText = resources.GetString("cboScaleTextFontChar.Properties.NullText")
        '
        'txtScaleColor
        '
        resources.ApplyResources(Me.txtScaleColor, "txtScaleColor")
        Me.txtScaleColor.Name = "txtScaleColor"
        Me.txtScaleColor.DefaultColor = Color.Transparent
        Me.txtScaleColor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtScaleColor.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtScaleColor.Properties.ColorAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtScaleColor.Properties.ShowSystemColors = False
        Me.txtScaleColor.Properties.ShowWebColors = False
        '
        'frmParametersScale
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.txtScaleColor)
        Me.Controls.Add(Me.chkHideScaleValue)
        Me.Controls.Add(Me.lblScaleStep)
        Me.Controls.Add(Me.txtScaleStep)
        Me.Controls.Add(Me.txtScaleText)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.chkScaleTextFontUnderline)
        Me.Controls.Add(Me.chkScaleTextFontItalic)
        Me.Controls.Add(Me.chkScaleTextFontBold)
        Me.Controls.Add(Me.lblScaleTextFontChar)
        Me.Controls.Add(Me.cboScaleTextFontSize)
        Me.Controls.Add(Me.lblScaleTextFontSize)
        Me.Controls.Add(Me.lblScaleColor)
        Me.Controls.Add(Me.lblScaleSteps)
        Me.Controls.Add(Me.txtScaleSteps)
        Me.Controls.Add(Me.lblCompassClipartZoomFactor)
        Me.Controls.Add(Me.txtScaleMeters)
        Me.Controls.Add(Me.cboScaleTextFontChar)
        Me.Name = "frmParametersScale"
        CType(Me.txtScaleMeters.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtScaleSteps.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboScaleTextFontSize.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtScaleText.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtScaleStep.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkHideScaleValue.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboScaleTextFontChar.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtScaleColor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCompassClipartZoomFactor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtScaleMeters As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents lblScaleSteps As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtScaleSteps As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents chkScaleTextFontUnderline As DevExpress.XtraEditors.CheckButton
    Friend WithEvents chkScaleTextFontItalic As DevExpress.XtraEditors.CheckButton
    Friend WithEvents chkScaleTextFontBold As DevExpress.XtraEditors.CheckButton
    Friend WithEvents lblScaleTextFontChar As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboScaleTextFontSize As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblScaleTextFontSize As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblScaleColor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Label2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtScaleText As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblScaleStep As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtScaleStep As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents chkHideScaleValue As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cboScaleTextFontChar As DevExpress.XtraEditors.FontEdit
    Friend WithEvents txtScaleColor As cColorSelector
End Class
