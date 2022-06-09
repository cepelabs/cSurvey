<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmParametersCompass
    Inherits DevExpress.XtraEditors.XtraUserControl

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmParametersCompass))
        Me.lblCompassColor = New DevExpress.XtraEditors.LabelControl()
        Me.lblCompassClipartZoomFactor = New DevExpress.XtraEditors.LabelControl()
        Me.txtCompassClipartZoomFactor = New DevExpress.XtraEditors.SpinEdit()
        Me.lblCompassClipart = New DevExpress.XtraEditors.LabelControl()
        Me.lblCompassText = New DevExpress.XtraEditors.LabelControl()
        Me.txtCompassText = New DevExpress.XtraEditors.TextEdit()
        Me.lblCompassTextFontSize = New DevExpress.XtraEditors.LabelControl()
        Me.lblCompassTextFontChar = New DevExpress.XtraEditors.LabelControl()
        Me.cboCompassFontSize = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.cboCompassFontChar = New DevExpress.XtraEditors.FontEdit()
        Me.txtColor = New cColorSelector()
        Me.chkCompassFontItalic = New DevExpress.XtraEditors.CheckButton()
        Me.chkCompassFontBold = New DevExpress.XtraEditors.CheckButton()
        Me.chkCompassFontUnderline = New DevExpress.XtraEditors.CheckButton()
        Me.picCompassClipartImage = New DevExpress.XtraEditors.PictureEdit()
        CType(Me.txtCompassClipartZoomFactor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCompassText.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCompassFontSize.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCompassFontChar.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtColor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCompassClipartImage.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblCompassColor
        '
        resources.ApplyResources(Me.lblCompassColor, "lblCompassColor")
        Me.lblCompassColor.Name = "lblCompassColor"
        '
        'lblCompassClipartZoomFactor
        '
        resources.ApplyResources(Me.lblCompassClipartZoomFactor, "lblCompassClipartZoomFactor")
        Me.lblCompassClipartZoomFactor.Name = "lblCompassClipartZoomFactor"
        '
        'txtCompassClipartZoomFactor
        '
        resources.ApplyResources(Me.txtCompassClipartZoomFactor, "txtCompassClipartZoomFactor")
        Me.txtCompassClipartZoomFactor.Name = "txtCompassClipartZoomFactor"
        Me.txtCompassClipartZoomFactor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtCompassClipartZoomFactor.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtCompassClipartZoomFactor.Properties.DisplayFormat.FormatString = "N2"
        Me.txtCompassClipartZoomFactor.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtCompassClipartZoomFactor.Properties.EditFormat.FormatString = "N2"
        Me.txtCompassClipartZoomFactor.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtCompassClipartZoomFactor.Properties.MaxValue = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.txtCompassClipartZoomFactor.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 131072})
        '
        'lblCompassClipart
        '
        resources.ApplyResources(Me.lblCompassClipart, "lblCompassClipart")
        Me.lblCompassClipart.Name = "lblCompassClipart"
        '
        'lblCompassText
        '
        resources.ApplyResources(Me.lblCompassText, "lblCompassText")
        Me.lblCompassText.Name = "lblCompassText"
        '
        'txtCompassText
        '
        resources.ApplyResources(Me.txtCompassText, "txtCompassText")
        Me.txtCompassText.Name = "txtCompassText"
        '
        'lblCompassTextFontSize
        '
        resources.ApplyResources(Me.lblCompassTextFontSize, "lblCompassTextFontSize")
        Me.lblCompassTextFontSize.Name = "lblCompassTextFontSize"
        '
        'lblCompassTextFontChar
        '
        resources.ApplyResources(Me.lblCompassTextFontChar, "lblCompassTextFontChar")
        Me.lblCompassTextFontChar.Name = "lblCompassTextFontChar"
        '
        'cboCompassFontSize
        '
        resources.ApplyResources(Me.cboCompassFontSize, "cboCompassFontSize")
        Me.cboCompassFontSize.Name = "cboCompassFontSize"
        Me.cboCompassFontSize.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboCompassFontSize.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboCompassFontSize.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines)), New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboCompassFontSize.Properties.Buttons1"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboCompassFontSize.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.cboCompassFontSize.Properties.Items.AddRange(New Object() {resources.GetString("cboCompassFontSize.Properties.Items"), resources.GetString("cboCompassFontSize.Properties.Items1"), resources.GetString("cboCompassFontSize.Properties.Items2"), resources.GetString("cboCompassFontSize.Properties.Items3"), resources.GetString("cboCompassFontSize.Properties.Items4"), resources.GetString("cboCompassFontSize.Properties.Items5"), resources.GetString("cboCompassFontSize.Properties.Items6"), resources.GetString("cboCompassFontSize.Properties.Items7"), resources.GetString("cboCompassFontSize.Properties.Items8"), resources.GetString("cboCompassFontSize.Properties.Items9"), resources.GetString("cboCompassFontSize.Properties.Items10"), resources.GetString("cboCompassFontSize.Properties.Items11"), resources.GetString("cboCompassFontSize.Properties.Items12"), resources.GetString("cboCompassFontSize.Properties.Items13"), resources.GetString("cboCompassFontSize.Properties.Items14"), resources.GetString("cboCompassFontSize.Properties.Items15"), resources.GetString("cboCompassFontSize.Properties.Items16")})
        Me.cboCompassFontSize.Properties.NullText = resources.GetString("cboCompassFontSize.Properties.NullText")
        '
        'cboCompassFontChar
        '
        resources.ApplyResources(Me.cboCompassFontChar, "cboCompassFontChar")
        Me.cboCompassFontChar.Name = "cboCompassFontChar"
        Me.cboCompassFontChar.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboCompassFontChar.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboCompassFontChar.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines)), New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboCompassFontChar.Properties.Buttons1"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboCompassFontChar.Properties.NullText = resources.GetString("cboCompassFontChar.Properties.NullText")
        '
        'txtColor
        '
        resources.ApplyResources(Me.txtColor, "txtColor")
        Me.txtColor.Name = "txtColor"
        Me.txtColor.DefaultColor = System.Drawing.Color.Transparent
        Me.txtColor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtColor.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtColor.Properties.ColorAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtColor.Properties.ShowSystemColors = False
        Me.txtColor.Properties.ShowWebColors = False
        '
        'chkCompassFontItalic
        '
        Me.chkCompassFontItalic.ImageOptions.Image = Global.cSurveyPC.My.Resources.Resources.text_italic
        Me.chkCompassFontItalic.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.chkCompassFontItalic.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.italic
        Me.chkCompassFontItalic.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.chkCompassFontItalic, "chkCompassFontItalic")
        Me.chkCompassFontItalic.Name = "chkCompassFontItalic"
        '
        'chkCompassFontBold
        '
        Me.chkCompassFontBold.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.chkCompassFontBold.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.bold
        Me.chkCompassFontBold.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.chkCompassFontBold, "chkCompassFontBold")
        Me.chkCompassFontBold.Name = "chkCompassFontBold"
        '
        'chkCompassFontUnderline
        '
        Me.chkCompassFontUnderline.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.chkCompassFontUnderline.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.underline
        Me.chkCompassFontUnderline.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.chkCompassFontUnderline, "chkCompassFontUnderline")
        Me.chkCompassFontUnderline.Name = "chkCompassFontUnderline"
        '
        'picCompassClipartImage
        '
        resources.ApplyResources(Me.picCompassClipartImage, "picCompassClipartImage")
        Me.picCompassClipartImage.Name = "picCompassClipartImage"
        Me.picCompassClipartImage.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.picCompassClipartImage.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        '
        'frmParametersCompass
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.cboCompassFontSize)
        Me.Controls.Add(Me.cboCompassFontChar)
        Me.Controls.Add(Me.txtColor)
        Me.Controls.Add(Me.chkCompassFontItalic)
        Me.Controls.Add(Me.chkCompassFontBold)
        Me.Controls.Add(Me.chkCompassFontUnderline)
        Me.Controls.Add(Me.lblCompassTextFontChar)
        Me.Controls.Add(Me.lblCompassTextFontSize)
        Me.Controls.Add(Me.txtCompassText)
        Me.Controls.Add(Me.lblCompassText)
        Me.Controls.Add(Me.lblCompassColor)
        Me.Controls.Add(Me.lblCompassClipartZoomFactor)
        Me.Controls.Add(Me.txtCompassClipartZoomFactor)
        Me.Controls.Add(Me.lblCompassClipart)
        Me.Controls.Add(Me.picCompassClipartImage)
        Me.Name = "frmParametersCompass"
        CType(Me.txtCompassClipartZoomFactor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCompassText.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCompassFontSize.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCompassFontChar.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtColor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCompassClipartImage.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCompassColor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblCompassClipartZoomFactor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtCompassClipartZoomFactor As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents lblCompassClipart As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblCompassText As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtCompassText As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblCompassTextFontSize As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblCompassTextFontChar As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboCompassFontSize As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents cboCompassFontChar As DevExpress.XtraEditors.FontEdit
    Friend WithEvents txtColor As cColorSelector
    Friend WithEvents chkCompassFontItalic As DevExpress.XtraEditors.CheckButton
    Friend WithEvents chkCompassFontBold As DevExpress.XtraEditors.CheckButton
    Friend WithEvents chkCompassFontUnderline As DevExpress.XtraEditors.CheckButton
    Friend WithEvents picCompassClipartImage As DevExpress.XtraEditors.PictureEdit
End Class
