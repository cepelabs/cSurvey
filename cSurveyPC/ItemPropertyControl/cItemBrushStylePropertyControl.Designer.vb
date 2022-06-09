<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cItemBrushStylePropertyControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cItemBrushStylePropertyControl))
        Me.cboPropBrushPattern = New cSurveyPC.cBrushStyleDropDown()
        Me.cmdPropBrushReseed = New DevExpress.XtraEditors.SimpleButton()
        Me.lblPropBrushClipartPosition = New DevExpress.XtraEditors.LabelControl()
        Me.cboPropBrushClipartPosition = New System.Windows.Forms.ComboBox()
        Me.lblPropBrushClipartImage = New DevExpress.XtraEditors.LabelControl()
        Me.lblPropBrushAlternativeBrushColor = New DevExpress.XtraEditors.LabelControl()
        Me.lblPropBrushColor = New DevExpress.XtraEditors.LabelControl()
        Me.lblPropBrushClipartAngle = New DevExpress.XtraEditors.LabelControl()
        Me.txtPropBrushClipartAngle = New System.Windows.Forms.NumericUpDown()
        Me.lblPropBrushClipartAngleMode = New DevExpress.XtraEditors.LabelControl()
        Me.cboPropBrushClipartAngleMode = New System.Windows.Forms.ComboBox()
        Me.lblPattern = New DevExpress.XtraEditors.LabelControl()
        Me.cboPropBrushHatch = New System.Windows.Forms.ComboBox()
        Me.lblPropBrushClipartZoomFactor = New DevExpress.XtraEditors.LabelControl()
        Me.txtPropBrushClipartZoomFactor = New System.Windows.Forms.NumericUpDown()
        Me.txtPropBrushClipartDensity = New System.Windows.Forms.NumericUpDown()
        Me.lblPropBrushClipartDensity = New DevExpress.XtraEditors.LabelControl()
        Me.lblPropBrushPatternType = New DevExpress.XtraEditors.LabelControl()
        Me.cboPropBrushPatternType = New System.Windows.Forms.ComboBox()
        Me.cboPropBrushClipartCrop = New System.Windows.Forms.ComboBox()
        Me.lblPropBrushClipartCrop = New DevExpress.XtraEditors.LabelControl()
        Me.lblPropBrushPatternPen = New DevExpress.XtraEditors.LabelControl()
        Me.cboPropBrushPatternPen = New System.Windows.Forms.ComboBox()
        Me.txtPropBrushColor = New cSurveyPC.cColorSelector()
        Me.txtPropBrushAlternativeBrushColor = New cSurveyPC.cColorSelector()
        Me.lblBrush = New DevExpress.XtraEditors.LabelControl()
        Me.cmdPropBrushBrowseClipart = New DevExpress.XtraEditors.SimpleButton()
        Me.picPropBrushClipartImage = New DevExpress.XtraEditors.PictureEdit()
        CType(Me.txtPropBrushClipartAngle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropBrushClipartZoomFactor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropBrushClipartDensity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropBrushColor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropBrushAlternativeBrushColor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPropBrushClipartImage.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboPropBrushPattern
        '
        resources.ApplyResources(Me.cboPropBrushPattern, "cboPropBrushPattern")
        Me.cboPropBrushPattern.EditValue = cSurveyPC.cSurvey.Design.cBrush.BrushTypeEnum.BigDebrits
        Me.cboPropBrushPattern.Name = "cboPropBrushPattern"
        '
        'cmdPropBrushReseed
        '
        resources.ApplyResources(Me.cmdPropBrushReseed, "cmdPropBrushReseed")
        Me.cmdPropBrushReseed.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdPropBrushReseed.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.actions_refresh
        Me.cmdPropBrushReseed.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.cmdPropBrushReseed.Name = "cmdPropBrushReseed"
        '
        'lblPropBrushClipartPosition
        '
        resources.ApplyResources(Me.lblPropBrushClipartPosition, "lblPropBrushClipartPosition")
        Me.lblPropBrushClipartPosition.Name = "lblPropBrushClipartPosition"
        '
        'cboPropBrushClipartPosition
        '
        Me.cboPropBrushClipartPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropBrushClipartPosition.DropDownWidth = 120
        Me.cboPropBrushClipartPosition.FormattingEnabled = True
        Me.cboPropBrushClipartPosition.Items.AddRange(New Object() {resources.GetString("cboPropBrushClipartPosition.Items"), resources.GetString("cboPropBrushClipartPosition.Items1")})
        resources.ApplyResources(Me.cboPropBrushClipartPosition, "cboPropBrushClipartPosition")
        Me.cboPropBrushClipartPosition.Name = "cboPropBrushClipartPosition"
        '
        'lblPropBrushClipartImage
        '
        resources.ApplyResources(Me.lblPropBrushClipartImage, "lblPropBrushClipartImage")
        Me.lblPropBrushClipartImage.Name = "lblPropBrushClipartImage"
        '
        'lblPropBrushAlternativeBrushColor
        '
        resources.ApplyResources(Me.lblPropBrushAlternativeBrushColor, "lblPropBrushAlternativeBrushColor")
        Me.lblPropBrushAlternativeBrushColor.Name = "lblPropBrushAlternativeBrushColor"
        '
        'lblPropBrushColor
        '
        resources.ApplyResources(Me.lblPropBrushColor, "lblPropBrushColor")
        Me.lblPropBrushColor.Name = "lblPropBrushColor"
        '
        'lblPropBrushClipartAngle
        '
        resources.ApplyResources(Me.lblPropBrushClipartAngle, "lblPropBrushClipartAngle")
        Me.lblPropBrushClipartAngle.Name = "lblPropBrushClipartAngle"
        '
        'txtPropBrushClipartAngle
        '
        resources.ApplyResources(Me.txtPropBrushClipartAngle, "txtPropBrushClipartAngle")
        Me.txtPropBrushClipartAngle.Maximum = New Decimal(New Integer() {359, 0, 0, 0})
        Me.txtPropBrushClipartAngle.Name = "txtPropBrushClipartAngle"
        '
        'lblPropBrushClipartAngleMode
        '
        resources.ApplyResources(Me.lblPropBrushClipartAngleMode, "lblPropBrushClipartAngleMode")
        Me.lblPropBrushClipartAngleMode.Name = "lblPropBrushClipartAngleMode"
        '
        'cboPropBrushClipartAngleMode
        '
        Me.cboPropBrushClipartAngleMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropBrushClipartAngleMode.FormattingEnabled = True
        Me.cboPropBrushClipartAngleMode.Items.AddRange(New Object() {resources.GetString("cboPropBrushClipartAngleMode.Items"), resources.GetString("cboPropBrushClipartAngleMode.Items1")})
        resources.ApplyResources(Me.cboPropBrushClipartAngleMode, "cboPropBrushClipartAngleMode")
        Me.cboPropBrushClipartAngleMode.Name = "cboPropBrushClipartAngleMode"
        '
        'lblPattern
        '
        resources.ApplyResources(Me.lblPattern, "lblPattern")
        Me.lblPattern.Name = "lblPattern"
        '
        'cboPropBrushHatch
        '
        Me.cboPropBrushHatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropBrushHatch.FormattingEnabled = True
        Me.cboPropBrushHatch.Items.AddRange(New Object() {resources.GetString("cboPropBrushHatch.Items"), resources.GetString("cboPropBrushHatch.Items1"), resources.GetString("cboPropBrushHatch.Items2"), resources.GetString("cboPropBrushHatch.Items3"), resources.GetString("cboPropBrushHatch.Items4")})
        resources.ApplyResources(Me.cboPropBrushHatch, "cboPropBrushHatch")
        Me.cboPropBrushHatch.Name = "cboPropBrushHatch"
        '
        'lblPropBrushClipartZoomFactor
        '
        resources.ApplyResources(Me.lblPropBrushClipartZoomFactor, "lblPropBrushClipartZoomFactor")
        Me.lblPropBrushClipartZoomFactor.Name = "lblPropBrushClipartZoomFactor"
        '
        'txtPropBrushClipartZoomFactor
        '
        resources.ApplyResources(Me.txtPropBrushClipartZoomFactor, "txtPropBrushClipartZoomFactor")
        Me.txtPropBrushClipartZoomFactor.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtPropBrushClipartZoomFactor.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtPropBrushClipartZoomFactor.Name = "txtPropBrushClipartZoomFactor"
        Me.txtPropBrushClipartZoomFactor.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'txtPropBrushClipartDensity
        '
        resources.ApplyResources(Me.txtPropBrushClipartDensity, "txtPropBrushClipartDensity")
        Me.txtPropBrushClipartDensity.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.txtPropBrushClipartDensity.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtPropBrushClipartDensity.Name = "txtPropBrushClipartDensity"
        Me.txtPropBrushClipartDensity.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'lblPropBrushClipartDensity
        '
        resources.ApplyResources(Me.lblPropBrushClipartDensity, "lblPropBrushClipartDensity")
        Me.lblPropBrushClipartDensity.Name = "lblPropBrushClipartDensity"
        '
        'lblPropBrushPatternType
        '
        resources.ApplyResources(Me.lblPropBrushPatternType, "lblPropBrushPatternType")
        Me.lblPropBrushPatternType.Name = "lblPropBrushPatternType"
        '
        'cboPropBrushPatternType
        '
        Me.cboPropBrushPatternType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropBrushPatternType.FormattingEnabled = True
        Me.cboPropBrushPatternType.Items.AddRange(New Object() {resources.GetString("cboPropBrushPatternType.Items"), resources.GetString("cboPropBrushPatternType.Items1")})
        resources.ApplyResources(Me.cboPropBrushPatternType, "cboPropBrushPatternType")
        Me.cboPropBrushPatternType.Name = "cboPropBrushPatternType"
        '
        'cboPropBrushClipartCrop
        '
        Me.cboPropBrushClipartCrop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropBrushClipartCrop.FormattingEnabled = True
        Me.cboPropBrushClipartCrop.Items.AddRange(New Object() {resources.GetString("cboPropBrushClipartCrop.Items"), resources.GetString("cboPropBrushClipartCrop.Items1"), resources.GetString("cboPropBrushClipartCrop.Items2")})
        resources.ApplyResources(Me.cboPropBrushClipartCrop, "cboPropBrushClipartCrop")
        Me.cboPropBrushClipartCrop.Name = "cboPropBrushClipartCrop"
        '
        'lblPropBrushClipartCrop
        '
        resources.ApplyResources(Me.lblPropBrushClipartCrop, "lblPropBrushClipartCrop")
        Me.lblPropBrushClipartCrop.Name = "lblPropBrushClipartCrop"
        '
        'lblPropBrushPatternPen
        '
        resources.ApplyResources(Me.lblPropBrushPatternPen, "lblPropBrushPatternPen")
        Me.lblPropBrushPatternPen.Name = "lblPropBrushPatternPen"
        '
        'cboPropBrushPatternPen
        '
        Me.cboPropBrushPatternPen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropBrushPatternPen.FormattingEnabled = True
        Me.cboPropBrushPatternPen.Items.AddRange(New Object() {resources.GetString("cboPropBrushPatternPen.Items"), resources.GetString("cboPropBrushPatternPen.Items1"), resources.GetString("cboPropBrushPatternPen.Items2"), resources.GetString("cboPropBrushPatternPen.Items3"), resources.GetString("cboPropBrushPatternPen.Items4")})
        resources.ApplyResources(Me.cboPropBrushPatternPen, "cboPropBrushPatternPen")
        Me.cboPropBrushPatternPen.Name = "cboPropBrushPatternPen"
        '
        'txtPropBrushColor
        '
        Me.txtPropBrushColor.DefaultColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.txtPropBrushColor, "txtPropBrushColor")
        Me.txtPropBrushColor.Name = "txtPropBrushColor"
        Me.txtPropBrushColor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtPropBrushColor.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtPropBrushColor.Properties.ColorAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtPropBrushColor.Properties.ShowSystemColors = False
        Me.txtPropBrushColor.Properties.ShowWebColors = False
        '
        'txtPropBrushAlternativeBrushColor
        '
        Me.txtPropBrushAlternativeBrushColor.DefaultColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.txtPropBrushAlternativeBrushColor, "txtPropBrushAlternativeBrushColor")
        Me.txtPropBrushAlternativeBrushColor.Name = "txtPropBrushAlternativeBrushColor"
        Me.txtPropBrushAlternativeBrushColor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtPropBrushAlternativeBrushColor.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtPropBrushAlternativeBrushColor.Properties.ColorAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtPropBrushAlternativeBrushColor.Properties.ShowSystemColors = False
        Me.txtPropBrushAlternativeBrushColor.Properties.ShowWebColors = False
        '
        'lblBrush
        '
        resources.ApplyResources(Me.lblBrush, "lblBrush")
        Me.lblBrush.Name = "lblBrush"
        '
        'cmdPropBrushBrowseClipart
        '
        Me.cmdPropBrushBrowseClipart.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdPropBrushBrowseClipart.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.open
        Me.cmdPropBrushBrowseClipart.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.cmdPropBrushBrowseClipart, "cmdPropBrushBrowseClipart")
        Me.cmdPropBrushBrowseClipart.Name = "cmdPropBrushBrowseClipart"
        '
        'picPropBrushClipartImage
        '
        resources.ApplyResources(Me.picPropBrushClipartImage, "picPropBrushClipartImage")
        Me.picPropBrushClipartImage.Name = "picPropBrushClipartImage"
        Me.picPropBrushClipartImage.Properties.NullText = resources.GetString("picPropBrushClipartImage.Properties.NullText")
        Me.picPropBrushClipartImage.Properties.ReadOnly = True
        Me.picPropBrushClipartImage.Properties.ShowEditMenuItem = DevExpress.Utils.DefaultBoolean.[False]
        Me.picPropBrushClipartImage.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        '
        'cItemBrushStylePropertyControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.cmdPropBrushBrowseClipart)
        Me.Controls.Add(Me.picPropBrushClipartImage)
        Me.Controls.Add(Me.txtPropBrushAlternativeBrushColor)
        Me.Controls.Add(Me.txtPropBrushColor)
        Me.Controls.Add(Me.lblPropBrushClipartPosition)
        Me.Controls.Add(Me.cboPropBrushClipartPosition)
        Me.Controls.Add(Me.lblPropBrushClipartImage)
        Me.Controls.Add(Me.lblPropBrushAlternativeBrushColor)
        Me.Controls.Add(Me.lblPropBrushColor)
        Me.Controls.Add(Me.lblPropBrushClipartAngle)
        Me.Controls.Add(Me.txtPropBrushClipartAngle)
        Me.Controls.Add(Me.lblPropBrushClipartAngleMode)
        Me.Controls.Add(Me.lblPattern)
        Me.Controls.Add(Me.cboPropBrushHatch)
        Me.Controls.Add(Me.lblPropBrushClipartZoomFactor)
        Me.Controls.Add(Me.txtPropBrushClipartZoomFactor)
        Me.Controls.Add(Me.txtPropBrushClipartDensity)
        Me.Controls.Add(Me.lblPropBrushClipartDensity)
        Me.Controls.Add(Me.cboPropBrushClipartCrop)
        Me.Controls.Add(Me.lblPropBrushClipartCrop)
        Me.Controls.Add(Me.lblPropBrushPatternPen)
        Me.Controls.Add(Me.cboPropBrushPatternPen)
        Me.Controls.Add(Me.cmdPropBrushReseed)
        Me.Controls.Add(Me.cboPropBrushPattern)
        Me.Controls.Add(Me.lblBrush)
        Me.Controls.Add(Me.cboPropBrushPatternType)
        Me.Controls.Add(Me.cboPropBrushClipartAngleMode)
        Me.Controls.Add(Me.lblPropBrushPatternType)
        Me.Name = "cItemBrushStylePropertyControl"
        CType(Me.txtPropBrushClipartAngle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropBrushClipartZoomFactor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropBrushClipartDensity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropBrushColor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropBrushAlternativeBrushColor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPropBrushClipartImage.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboPropBrushPattern As cBrushStyleDropDown
    Friend WithEvents cmdPropBrushReseed As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblPropBrushClipartPosition As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboPropBrushClipartPosition As ComboBox
    Friend WithEvents lblPropBrushClipartImage As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPropBrushAlternativeBrushColor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPropBrushColor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPropBrushClipartAngle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPropBrushClipartAngle As NumericUpDown
    Friend WithEvents lblPropBrushClipartAngleMode As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboPropBrushClipartAngleMode As ComboBox
    Friend WithEvents lblPattern As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboPropBrushHatch As ComboBox
    Friend WithEvents lblPropBrushClipartZoomFactor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPropBrushClipartZoomFactor As NumericUpDown
    Friend WithEvents txtPropBrushClipartDensity As NumericUpDown
    Friend WithEvents lblPropBrushClipartDensity As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPropBrushPatternType As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboPropBrushPatternType As ComboBox
    Friend WithEvents cboPropBrushClipartCrop As ComboBox
    Friend WithEvents lblPropBrushClipartCrop As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPropBrushPatternPen As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboPropBrushPatternPen As ComboBox
    Friend WithEvents txtPropBrushColor As cColorSelector
    Friend WithEvents txtPropBrushAlternativeBrushColor As cColorSelector
    Friend WithEvents lblBrush As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdPropBrushBrowseClipart As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents picPropBrushClipartImage As DevExpress.XtraEditors.PictureEdit
End Class
