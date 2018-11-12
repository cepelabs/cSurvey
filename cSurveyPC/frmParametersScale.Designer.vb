<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmParametersScale
    Inherits cForm

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmParametersScale))
        Me.lblCompassClipartZoomFactor = New System.Windows.Forms.Label()
        Me.txtScaleMeters = New System.Windows.Forms.NumericUpDown()
        Me.lblScaleSteps = New System.Windows.Forms.Label()
        Me.txtScaleSteps = New System.Windows.Forms.NumericUpDown()
        Me.chkScaleTextFontUnderline = New System.Windows.Forms.CheckBox()
        Me.chkScaleTextFontItalic = New System.Windows.Forms.CheckBox()
        Me.chkScaleTextFontBold = New System.Windows.Forms.CheckBox()
        Me.cboScaleTextFontChar = New System.Windows.Forms.ComboBox()
        Me.lblScaleTextFontChar = New System.Windows.Forms.Label()
        Me.cboScaleTextFontSize = New System.Windows.Forms.ComboBox()
        Me.lblScaleTextFontSize = New System.Windows.Forms.Label()
        Me.lblScaleColor = New System.Windows.Forms.Label()
        Me.cmdScaleColorBrowse = New System.Windows.Forms.Button()
        Me.picScaleColor = New System.Windows.Forms.PictureBox()
        Me.cmdApply = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtScaleText = New System.Windows.Forms.TextBox()
        Me.lblScaleStep = New System.Windows.Forms.Label()
        Me.txtScaleStep = New System.Windows.Forms.NumericUpDown()
        Me.chkHideScaleValue = New System.Windows.Forms.CheckBox()
        CType(Me.txtScaleMeters, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtScaleSteps, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picScaleColor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtScaleStep, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblCompassClipartZoomFactor
        '
        resources.ApplyResources(Me.lblCompassClipartZoomFactor, "lblCompassClipartZoomFactor")
        Me.lblCompassClipartZoomFactor.Name = "lblCompassClipartZoomFactor"
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
        'chkScaleTextFontUnderline
        '
        resources.ApplyResources(Me.chkScaleTextFontUnderline, "chkScaleTextFontUnderline")
        Me.chkScaleTextFontUnderline.Image = Global.cSurveyPC.My.Resources.Resources.text_underline
        Me.chkScaleTextFontUnderline.Name = "chkScaleTextFontUnderline"
        Me.chkScaleTextFontUnderline.UseVisualStyleBackColor = True
        '
        'chkScaleTextFontItalic
        '
        resources.ApplyResources(Me.chkScaleTextFontItalic, "chkScaleTextFontItalic")
        Me.chkScaleTextFontItalic.Image = Global.cSurveyPC.My.Resources.Resources.text_italic
        Me.chkScaleTextFontItalic.Name = "chkScaleTextFontItalic"
        Me.chkScaleTextFontItalic.UseVisualStyleBackColor = True
        '
        'chkScaleTextFontBold
        '
        resources.ApplyResources(Me.chkScaleTextFontBold, "chkScaleTextFontBold")
        Me.chkScaleTextFontBold.Image = Global.cSurveyPC.My.Resources.Resources.text_bold
        Me.chkScaleTextFontBold.Name = "chkScaleTextFontBold"
        Me.chkScaleTextFontBold.UseVisualStyleBackColor = True
        '
        'cboScaleTextFontChar
        '
        Me.cboScaleTextFontChar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboScaleTextFontChar.FormattingEnabled = True
        resources.ApplyResources(Me.cboScaleTextFontChar, "cboScaleTextFontChar")
        Me.cboScaleTextFontChar.Name = "cboScaleTextFontChar"
        '
        'lblScaleTextFontChar
        '
        resources.ApplyResources(Me.lblScaleTextFontChar, "lblScaleTextFontChar")
        Me.lblScaleTextFontChar.Name = "lblScaleTextFontChar"
        '
        'cboScaleTextFontSize
        '
        Me.cboScaleTextFontSize.FormattingEnabled = True
        Me.cboScaleTextFontSize.Items.AddRange(New Object() {resources.GetString("cboScaleTextFontSize.Items"), resources.GetString("cboScaleTextFontSize.Items1"), resources.GetString("cboScaleTextFontSize.Items2"), resources.GetString("cboScaleTextFontSize.Items3"), resources.GetString("cboScaleTextFontSize.Items4"), resources.GetString("cboScaleTextFontSize.Items5"), resources.GetString("cboScaleTextFontSize.Items6"), resources.GetString("cboScaleTextFontSize.Items7"), resources.GetString("cboScaleTextFontSize.Items8"), resources.GetString("cboScaleTextFontSize.Items9"), resources.GetString("cboScaleTextFontSize.Items10"), resources.GetString("cboScaleTextFontSize.Items11"), resources.GetString("cboScaleTextFontSize.Items12"), resources.GetString("cboScaleTextFontSize.Items13"), resources.GetString("cboScaleTextFontSize.Items14"), resources.GetString("cboScaleTextFontSize.Items15"), resources.GetString("cboScaleTextFontSize.Items16"), resources.GetString("cboScaleTextFontSize.Items17")})
        resources.ApplyResources(Me.cboScaleTextFontSize, "cboScaleTextFontSize")
        Me.cboScaleTextFontSize.Name = "cboScaleTextFontSize"
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
        'cmdScaleColorBrowse
        '
        resources.ApplyResources(Me.cmdScaleColorBrowse, "cmdScaleColorBrowse")
        Me.cmdScaleColorBrowse.Name = "cmdScaleColorBrowse"
        Me.cmdScaleColorBrowse.UseVisualStyleBackColor = True
        '
        'picScaleColor
        '
        resources.ApplyResources(Me.picScaleColor, "picScaleColor")
        Me.picScaleColor.Name = "picScaleColor"
        Me.picScaleColor.TabStop = False
        '
        'cmdApply
        '
        resources.ApplyResources(Me.cmdApply, "cmdApply")
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.UseVisualStyleBackColor = True
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
        Me.txtScaleStep.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtScaleStep.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtScaleStep.Name = "txtScaleStep"
        Me.txtScaleStep.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'chkHideScaleValue
        '
        resources.ApplyResources(Me.chkHideScaleValue, "chkHideScaleValue")
        Me.chkHideScaleValue.Name = "chkHideScaleValue"
        Me.chkHideScaleValue.UseVisualStyleBackColor = True
        '
        'frmParametersScale
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.chkHideScaleValue)
        Me.Controls.Add(Me.lblScaleStep)
        Me.Controls.Add(Me.txtScaleStep)
        Me.Controls.Add(Me.txtScaleText)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdApply)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.chkScaleTextFontUnderline)
        Me.Controls.Add(Me.chkScaleTextFontItalic)
        Me.Controls.Add(Me.chkScaleTextFontBold)
        Me.Controls.Add(Me.cboScaleTextFontChar)
        Me.Controls.Add(Me.lblScaleTextFontChar)
        Me.Controls.Add(Me.cboScaleTextFontSize)
        Me.Controls.Add(Me.lblScaleTextFontSize)
        Me.Controls.Add(Me.lblScaleColor)
        Me.Controls.Add(Me.cmdScaleColorBrowse)
        Me.Controls.Add(Me.picScaleColor)
        Me.Controls.Add(Me.lblScaleSteps)
        Me.Controls.Add(Me.txtScaleSteps)
        Me.Controls.Add(Me.lblCompassClipartZoomFactor)
        Me.Controls.Add(Me.txtScaleMeters)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmParametersScale"
        CType(Me.txtScaleMeters, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtScaleSteps, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picScaleColor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtScaleStep, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCompassClipartZoomFactor As System.Windows.Forms.Label
    Friend WithEvents txtScaleMeters As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblScaleSteps As System.Windows.Forms.Label
    Friend WithEvents txtScaleSteps As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkScaleTextFontUnderline As System.Windows.Forms.CheckBox
    Friend WithEvents chkScaleTextFontItalic As System.Windows.Forms.CheckBox
    Friend WithEvents chkScaleTextFontBold As System.Windows.Forms.CheckBox
    Friend WithEvents cboScaleTextFontChar As System.Windows.Forms.ComboBox
    Friend WithEvents lblScaleTextFontChar As System.Windows.Forms.Label
    Friend WithEvents cboScaleTextFontSize As System.Windows.Forms.ComboBox
    Friend WithEvents lblScaleTextFontSize As System.Windows.Forms.Label
    Friend WithEvents lblScaleColor As System.Windows.Forms.Label
    Friend WithEvents cmdScaleColorBrowse As System.Windows.Forms.Button
    Friend WithEvents picScaleColor As System.Windows.Forms.PictureBox
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtScaleText As System.Windows.Forms.TextBox
    Friend WithEvents lblScaleStep As System.Windows.Forms.Label
    Friend WithEvents txtScaleStep As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkHideScaleValue As System.Windows.Forms.CheckBox
End Class
