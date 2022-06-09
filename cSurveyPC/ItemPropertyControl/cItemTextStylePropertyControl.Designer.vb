<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cItemTextStylePropertyControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cItemTextStylePropertyControl))
        Me.optPropTextVAlignBottom = New DevExpress.XtraEditors.CheckButton()
        Me.optPropTextVAlignTop = New DevExpress.XtraEditors.CheckButton()
        Me.optPropTextVAlignCenter = New DevExpress.XtraEditors.CheckButton()
        Me.optPropTextAlignRight = New DevExpress.XtraEditors.CheckButton()
        Me.optPropTextAlignCenter = New DevExpress.XtraEditors.CheckButton()
        Me.optPropTextAlignLeft = New DevExpress.XtraEditors.CheckButton()
        Me.cboPropTextSize = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblPropTextSize = New DevExpress.XtraEditors.LabelControl()
        Me.lblPropText = New DevExpress.XtraEditors.LabelControl()
        Me.txtPropText = New DevExpress.XtraEditors.MemoEdit()
        Me.lblPropTextStyle = New DevExpress.XtraEditors.LabelControl()
        Me.cboPropTextRotateMode = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblPropTextRotateMode = New DevExpress.XtraEditors.LabelControl()
        Me.lblPropFontColor = New DevExpress.XtraEditors.LabelControl()
        Me.chkPropTextFontUnderline = New DevExpress.XtraEditors.CheckButton()
        Me.chkPropTextFontItalic = New DevExpress.XtraEditors.CheckButton()
        Me.chkPropTextFontBold = New DevExpress.XtraEditors.CheckButton()
        Me.lblPropTextFontChar = New DevExpress.XtraEditors.LabelControl()
        Me.lblPropTextFontSize = New DevExpress.XtraEditors.LabelControl()
        Me.txtPropFontColor = New cSurveyPC.cColorSelector()
        Me.cboPropTextFontChar = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.cboPropTextStyle = New cSurveyPC.cFontStyleDropDown()
        Me.cboPropTextFontSize = New DevExpress.XtraEditors.ComboBoxEdit()
        CType(Me.cboPropTextSize.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropText.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPropTextRotateMode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropFontColor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPropTextFontChar.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPropTextFontSize.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'optPropTextVAlignBottom
        '
        Me.optPropTextVAlignBottom.GroupIndex = 10
        Me.optPropTextVAlignBottom.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.optPropTextVAlignBottom.ImageOptions.SvgImage = CType(resources.GetObject("optPropTextVAlignBottom.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.optPropTextVAlignBottom.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.optPropTextVAlignBottom, "optPropTextVAlignBottom")
        Me.optPropTextVAlignBottom.Name = "optPropTextVAlignBottom"
        Me.optPropTextVAlignBottom.TabStop = False
        '
        'optPropTextVAlignTop
        '
        Me.optPropTextVAlignTop.GroupIndex = 10
        Me.optPropTextVAlignTop.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.optPropTextVAlignTop.ImageOptions.SvgImage = CType(resources.GetObject("optPropTextVAlignTop.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.optPropTextVAlignTop.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.optPropTextVAlignTop, "optPropTextVAlignTop")
        Me.optPropTextVAlignTop.Name = "optPropTextVAlignTop"
        Me.optPropTextVAlignTop.TabStop = False
        '
        'optPropTextVAlignCenter
        '
        Me.optPropTextVAlignCenter.GroupIndex = 10
        Me.optPropTextVAlignCenter.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.optPropTextVAlignCenter.ImageOptions.SvgImage = CType(resources.GetObject("optPropTextVAlignCenter.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.optPropTextVAlignCenter.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.optPropTextVAlignCenter, "optPropTextVAlignCenter")
        Me.optPropTextVAlignCenter.Name = "optPropTextVAlignCenter"
        Me.optPropTextVAlignCenter.TabStop = False
        '
        'optPropTextAlignRight
        '
        Me.optPropTextAlignRight.GroupIndex = 11
        Me.optPropTextAlignRight.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.optPropTextAlignRight.ImageOptions.SvgImage = CType(resources.GetObject("optPropTextAlignRight.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.optPropTextAlignRight.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.optPropTextAlignRight, "optPropTextAlignRight")
        Me.optPropTextAlignRight.Name = "optPropTextAlignRight"
        Me.optPropTextAlignRight.TabStop = False
        '
        'optPropTextAlignCenter
        '
        Me.optPropTextAlignCenter.GroupIndex = 11
        Me.optPropTextAlignCenter.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.optPropTextAlignCenter.ImageOptions.SvgImage = CType(resources.GetObject("optPropTextAlignCenter.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.optPropTextAlignCenter.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.optPropTextAlignCenter, "optPropTextAlignCenter")
        Me.optPropTextAlignCenter.Name = "optPropTextAlignCenter"
        Me.optPropTextAlignCenter.TabStop = False
        '
        'optPropTextAlignLeft
        '
        Me.optPropTextAlignLeft.GroupIndex = 11
        Me.optPropTextAlignLeft.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.optPropTextAlignLeft.ImageOptions.SvgImage = CType(resources.GetObject("optPropTextAlignLeft.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.optPropTextAlignLeft.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.optPropTextAlignLeft, "optPropTextAlignLeft")
        Me.optPropTextAlignLeft.Name = "optPropTextAlignLeft"
        Me.optPropTextAlignLeft.TabStop = False
        '
        'cboPropTextSize
        '
        resources.ApplyResources(Me.cboPropTextSize, "cboPropTextSize")
        Me.cboPropTextSize.Name = "cboPropTextSize"
        Me.cboPropTextSize.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboPropTextSize.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboPropTextSize.Properties.Items.AddRange(New Object() {resources.GetString("cboPropTextSize.Properties.Items"), resources.GetString("cboPropTextSize.Properties.Items1"), resources.GetString("cboPropTextSize.Properties.Items2"), resources.GetString("cboPropTextSize.Properties.Items3"), resources.GetString("cboPropTextSize.Properties.Items4"), resources.GetString("cboPropTextSize.Properties.Items5"), resources.GetString("cboPropTextSize.Properties.Items6"), resources.GetString("cboPropTextSize.Properties.Items7"), resources.GetString("cboPropTextSize.Properties.Items8"), resources.GetString("cboPropTextSize.Properties.Items9"), resources.GetString("cboPropTextSize.Properties.Items10"), resources.GetString("cboPropTextSize.Properties.Items11"), resources.GetString("cboPropTextSize.Properties.Items12"), resources.GetString("cboPropTextSize.Properties.Items13")})
        Me.cboPropTextSize.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'lblPropTextSize
        '
        resources.ApplyResources(Me.lblPropTextSize, "lblPropTextSize")
        Me.lblPropTextSize.Name = "lblPropTextSize"
        '
        'lblPropText
        '
        resources.ApplyResources(Me.lblPropText, "lblPropText")
        Me.lblPropText.Name = "lblPropText"
        '
        'txtPropText
        '
        resources.ApplyResources(Me.txtPropText, "txtPropText")
        Me.txtPropText.Name = "txtPropText"
        '
        'lblPropTextStyle
        '
        resources.ApplyResources(Me.lblPropTextStyle, "lblPropTextStyle")
        Me.lblPropTextStyle.Name = "lblPropTextStyle"
        '
        'cboPropTextRotateMode
        '
        resources.ApplyResources(Me.cboPropTextRotateMode, "cboPropTextRotateMode")
        Me.cboPropTextRotateMode.Name = "cboPropTextRotateMode"
        Me.cboPropTextRotateMode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboPropTextRotateMode.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboPropTextRotateMode.Properties.Items.AddRange(New Object() {resources.GetString("cboPropTextRotateMode.Properties.Items"), resources.GetString("cboPropTextRotateMode.Properties.Items1")})
        Me.cboPropTextRotateMode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'lblPropTextRotateMode
        '
        resources.ApplyResources(Me.lblPropTextRotateMode, "lblPropTextRotateMode")
        Me.lblPropTextRotateMode.Name = "lblPropTextRotateMode"
        '
        'lblPropFontColor
        '
        resources.ApplyResources(Me.lblPropFontColor, "lblPropFontColor")
        Me.lblPropFontColor.Name = "lblPropFontColor"
        '
        'chkPropTextFontUnderline
        '
        Me.chkPropTextFontUnderline.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.chkPropTextFontUnderline.ImageOptions.SvgImage = CType(resources.GetObject("chkPropTextFontUnderline.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.chkPropTextFontUnderline.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.chkPropTextFontUnderline, "chkPropTextFontUnderline")
        Me.chkPropTextFontUnderline.Name = "chkPropTextFontUnderline"
        '
        'chkPropTextFontItalic
        '
        Me.chkPropTextFontItalic.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.chkPropTextFontItalic.ImageOptions.SvgImage = CType(resources.GetObject("chkPropTextFontItalic.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.chkPropTextFontItalic.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.chkPropTextFontItalic, "chkPropTextFontItalic")
        Me.chkPropTextFontItalic.Name = "chkPropTextFontItalic"
        '
        'chkPropTextFontBold
        '
        Me.chkPropTextFontBold.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.chkPropTextFontBold.ImageOptions.SvgImage = CType(resources.GetObject("chkPropTextFontBold.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.chkPropTextFontBold.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.chkPropTextFontBold, "chkPropTextFontBold")
        Me.chkPropTextFontBold.Name = "chkPropTextFontBold"
        '
        'lblPropTextFontChar
        '
        resources.ApplyResources(Me.lblPropTextFontChar, "lblPropTextFontChar")
        Me.lblPropTextFontChar.Name = "lblPropTextFontChar"
        '
        'lblPropTextFontSize
        '
        resources.ApplyResources(Me.lblPropTextFontSize, "lblPropTextFontSize")
        Me.lblPropTextFontSize.Name = "lblPropTextFontSize"
        '
        'txtPropFontColor
        '
        Me.txtPropFontColor.DefaultColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.txtPropFontColor, "txtPropFontColor")
        Me.txtPropFontColor.Name = "txtPropFontColor"
        Me.txtPropFontColor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtPropFontColor.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtPropFontColor.Properties.ColorAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtPropFontColor.Properties.ShowSystemColors = False
        Me.txtPropFontColor.Properties.ShowWebColors = False
        '
        'cboPropTextFontChar
        '
        resources.ApplyResources(Me.cboPropTextFontChar, "cboPropTextFontChar")
        Me.cboPropTextFontChar.Name = "cboPropTextFontChar"
        Me.cboPropTextFontChar.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboPropTextFontChar.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboPropTextFontChar.Properties.DropDownRows = 10
        Me.cboPropTextFontChar.Properties.ShowToolTipForTrimmedText = DevExpress.Utils.DefaultBoolean.[False]
        Me.cboPropTextFontChar.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'cboPropTextStyle
        '
        resources.ApplyResources(Me.cboPropTextStyle, "cboPropTextStyle")
        Me.cboPropTextStyle.EditValue = cSurveyPC.cSurvey.Design.cItemFont.FontTypeEnum.Generic
        Me.cboPropTextStyle.Name = "cboPropTextStyle"
        '
        'cboPropTextFontSize
        '
        resources.ApplyResources(Me.cboPropTextFontSize, "cboPropTextFontSize")
        Me.cboPropTextFontSize.Name = "cboPropTextFontSize"
        Me.cboPropTextFontSize.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboPropTextFontSize.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboPropTextFontSize.Properties.Items.AddRange(New Object() {resources.GetString("cboPropTextFontSize.Properties.Items"), resources.GetString("cboPropTextFontSize.Properties.Items1"), resources.GetString("cboPropTextFontSize.Properties.Items2"), resources.GetString("cboPropTextFontSize.Properties.Items3"), resources.GetString("cboPropTextFontSize.Properties.Items4"), resources.GetString("cboPropTextFontSize.Properties.Items5"), resources.GetString("cboPropTextFontSize.Properties.Items6"), resources.GetString("cboPropTextFontSize.Properties.Items7"), resources.GetString("cboPropTextFontSize.Properties.Items8"), resources.GetString("cboPropTextFontSize.Properties.Items9"), resources.GetString("cboPropTextFontSize.Properties.Items10"), resources.GetString("cboPropTextFontSize.Properties.Items11"), resources.GetString("cboPropTextFontSize.Properties.Items12"), resources.GetString("cboPropTextFontSize.Properties.Items13"), resources.GetString("cboPropTextFontSize.Properties.Items14"), resources.GetString("cboPropTextFontSize.Properties.Items15"), resources.GetString("cboPropTextFontSize.Properties.Items16"), resources.GetString("cboPropTextFontSize.Properties.Items17")})
        Me.cboPropTextFontSize.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'cItemTextStylePropertyControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.lblPropFontColor)
        Me.Controls.Add(Me.chkPropTextFontUnderline)
        Me.Controls.Add(Me.chkPropTextFontItalic)
        Me.Controls.Add(Me.chkPropTextFontBold)
        Me.Controls.Add(Me.lblPropTextFontChar)
        Me.Controls.Add(Me.lblPropTextFontSize)
        Me.Controls.Add(Me.optPropTextVAlignBottom)
        Me.Controls.Add(Me.optPropTextVAlignTop)
        Me.Controls.Add(Me.optPropTextAlignRight)
        Me.Controls.Add(Me.optPropTextVAlignCenter)
        Me.Controls.Add(Me.optPropTextAlignCenter)
        Me.Controls.Add(Me.optPropTextAlignLeft)
        Me.Controls.Add(Me.cboPropTextSize)
        Me.Controls.Add(Me.lblPropTextSize)
        Me.Controls.Add(Me.lblPropText)
        Me.Controls.Add(Me.txtPropText)
        Me.Controls.Add(Me.lblPropTextStyle)
        Me.Controls.Add(Me.cboPropTextRotateMode)
        Me.Controls.Add(Me.lblPropTextRotateMode)
        Me.Controls.Add(Me.txtPropFontColor)
        Me.Controls.Add(Me.cboPropTextFontChar)
        Me.Controls.Add(Me.cboPropTextStyle)
        Me.Controls.Add(Me.cboPropTextFontSize)
        Me.Name = "cItemTextStylePropertyControl"
        CType(Me.cboPropTextSize.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropText.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPropTextRotateMode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropFontColor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPropTextFontChar.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPropTextFontSize.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents optPropTextVAlignBottom As DevExpress.XtraEditors.CheckButton
    Friend WithEvents optPropTextVAlignTop As DevExpress.XtraEditors.CheckButton
    Friend WithEvents optPropTextVAlignCenter As DevExpress.XtraEditors.CheckButton
    Friend WithEvents optPropTextAlignRight As DevExpress.XtraEditors.CheckButton
    Friend WithEvents optPropTextAlignCenter As DevExpress.XtraEditors.CheckButton
    Friend WithEvents optPropTextAlignLeft As DevExpress.XtraEditors.CheckButton
    Friend WithEvents cboPropTextSize As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblPropTextSize As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPropText As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPropText As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents lblPropTextStyle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboPropTextRotateMode As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblPropTextRotateMode As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPropFontColor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkPropTextFontUnderline As DevExpress.XtraEditors.CheckButton
    Friend WithEvents chkPropTextFontItalic As DevExpress.XtraEditors.CheckButton
    Friend WithEvents chkPropTextFontBold As DevExpress.XtraEditors.CheckButton
    Friend WithEvents lblPropTextFontChar As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPropTextFontSize As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPropFontColor As cColorSelector
    Friend WithEvents cboPropTextFontChar As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents cboPropTextStyle As cFontStyleDropDown
    Friend WithEvents cboPropTextFontSize As DevExpress.XtraEditors.ComboBoxEdit
End Class
