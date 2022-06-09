<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmParametersInfoBox
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmParametersInfoBox))
        Dim ButtonImageOptions1 As DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions = New DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions()
        Dim ButtonImageOptions2 As DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions = New DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions()
        Dim ButtonImageOptions3 As DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions = New DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions()
        Me.chkTextFontUnderline = New DevExpress.XtraEditors.CheckButton()
        Me.chkTextFontItalic = New DevExpress.XtraEditors.CheckButton()
        Me.chkTextFontBold = New DevExpress.XtraEditors.CheckButton()
        Me.lblPropTextFontChar = New DevExpress.XtraEditors.LabelControl()
        Me.lblTextFontSize = New DevExpress.XtraEditors.LabelControl()
        Me.chkVisible = New DevExpress.XtraEditors.CheckEdit()
        Me.lblWidth = New System.Windows.Forms.Label()
        Me.txtWidth = New DevExpress.XtraEditors.SpinEdit()
        Me.lblWidthUnit = New DevExpress.XtraEditors.LabelControl()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.chkUnlock = New DevExpress.XtraEditors.CheckButton()
        Me.cboTextFontSize = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.cboTextFontChar = New DevExpress.XtraEditors.FontEdit()
        Me.txtColor = New cColorSelector()
        Me.lblTextColor = New DevExpress.XtraEditors.LabelControl()
        CType(Me.chkVisible.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWidth.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.cboTextFontSize.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTextFontChar.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtColor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkTextFontUnderline
        '
        Me.chkTextFontUnderline.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.chkTextFontUnderline.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.underline
        Me.chkTextFontUnderline.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.chkTextFontUnderline, "chkTextFontUnderline")
        Me.chkTextFontUnderline.Name = "chkTextFontUnderline"
        '
        'chkTextFontItalic
        '
        Me.chkTextFontItalic.ImageOptions.Image = Global.cSurveyPC.My.Resources.Resources.text_italic
        Me.chkTextFontItalic.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.chkTextFontItalic.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.italic
        Me.chkTextFontItalic.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.chkTextFontItalic, "chkTextFontItalic")
        Me.chkTextFontItalic.Name = "chkTextFontItalic"
        '
        'chkTextFontBold
        '
        Me.chkTextFontBold.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.chkTextFontBold.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.bold
        Me.chkTextFontBold.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.chkTextFontBold, "chkTextFontBold")
        Me.chkTextFontBold.Name = "chkTextFontBold"
        '
        'lblPropTextFontChar
        '
        resources.ApplyResources(Me.lblPropTextFontChar, "lblPropTextFontChar")
        Me.lblPropTextFontChar.Name = "lblPropTextFontChar"
        '
        'lblTextFontSize
        '
        resources.ApplyResources(Me.lblTextFontSize, "lblTextFontSize")
        Me.lblTextFontSize.Name = "lblTextFontSize"
        '
        'chkVisible
        '
        resources.ApplyResources(Me.chkVisible, "chkVisible")
        Me.chkVisible.Name = "chkVisible"
        Me.chkVisible.Properties.Caption = resources.GetString("chkVisible.Properties.Caption")
        '
        'lblWidth
        '
        resources.ApplyResources(Me.lblWidth, "lblWidth")
        Me.lblWidth.Name = "lblWidth"
        '
        'txtWidth
        '
        resources.ApplyResources(Me.txtWidth, "txtWidth")
        Me.txtWidth.Name = "txtWidth"
        Me.txtWidth.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtWidth.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtWidth.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtWidth.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtWidth.Properties.IsFloatValue = False
        Me.txtWidth.Properties.MaskSettings.Set("mask", "N00")
        Me.txtWidth.Properties.MaxValue = New Decimal(New Integer() {5000, 0, 0, 0})
        '
        'lblWidthUnit
        '
        resources.ApplyResources(Me.lblWidthUnit, "lblWidthUnit")
        Me.lblWidthUnit.Name = "lblWidthUnit"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.chkUnlock)
        Me.GroupControl1.Controls.Add(Me.cboTextFontSize)
        Me.GroupControl1.Controls.Add(Me.cboTextFontChar)
        Me.GroupControl1.Controls.Add(Me.txtColor)
        Me.GroupControl1.Controls.Add(Me.lblTextColor)
        Me.GroupControl1.Controls.Add(Me.chkVisible)
        Me.GroupControl1.Controls.Add(Me.lblPropTextFontChar)
        Me.GroupControl1.Controls.Add(Me.chkTextFontItalic)
        Me.GroupControl1.Controls.Add(Me.chkTextFontBold)
        Me.GroupControl1.Controls.Add(Me.lblTextFontSize)
        Me.GroupControl1.Controls.Add(Me.chkTextFontUnderline)
        Me.GroupControl1.CustomHeaderButtons.AddRange(New DevExpress.XtraEditors.ButtonPanel.IBaseButton() {New DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton(resources.GetString("GroupControl1.CustomHeaderButtons"), CType(resources.GetObject("GroupControl1.CustomHeaderButtons1"), Boolean), ButtonImageOptions1, CType(resources.GetObject("GroupControl1.CustomHeaderButtons2"), DevExpress.XtraBars.Docking2010.ButtonStyle), resources.GetString("GroupControl1.CustomHeaderButtons3"), CType(resources.GetObject("GroupControl1.CustomHeaderButtons4"), Integer), CType(resources.GetObject("GroupControl1.CustomHeaderButtons5"), Boolean), CType(resources.GetObject("GroupControl1.CustomHeaderButtons6"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("GroupControl1.CustomHeaderButtons7"), Boolean), CType(resources.GetObject("GroupControl1.CustomHeaderButtons8"), Boolean), CType(resources.GetObject("GroupControl1.CustomHeaderButtons9"), Boolean), CType(resources.GetObject("GroupControl1.CustomHeaderButtons10"), Object), CType(resources.GetObject("GroupControl1.CustomHeaderButtons11"), Integer)), New DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton(resources.GetString("GroupControl1.CustomHeaderButtons12"), CType(resources.GetObject("GroupControl1.CustomHeaderButtons13"), Boolean), ButtonImageOptions2, CType(resources.GetObject("GroupControl1.CustomHeaderButtons14"), DevExpress.XtraBars.Docking2010.ButtonStyle), resources.GetString("GroupControl1.CustomHeaderButtons15"), CType(resources.GetObject("GroupControl1.CustomHeaderButtons16"), Integer), CType(resources.GetObject("GroupControl1.CustomHeaderButtons17"), Boolean), CType(resources.GetObject("GroupControl1.CustomHeaderButtons18"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("GroupControl1.CustomHeaderButtons19"), Boolean), CType(resources.GetObject("GroupControl1.CustomHeaderButtons20"), Boolean), CType(resources.GetObject("GroupControl1.CustomHeaderButtons21"), Boolean), CType(resources.GetObject("GroupControl1.CustomHeaderButtons22"), Object), CType(resources.GetObject("GroupControl1.CustomHeaderButtons23"), Integer)), New DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton(resources.GetString("GroupControl1.CustomHeaderButtons24"), CType(resources.GetObject("GroupControl1.CustomHeaderButtons25"), Boolean), ButtonImageOptions3, CType(resources.GetObject("GroupControl1.CustomHeaderButtons26"), DevExpress.XtraBars.Docking2010.ButtonStyle), resources.GetString("GroupControl1.CustomHeaderButtons27"), CType(resources.GetObject("GroupControl1.CustomHeaderButtons28"), Integer), CType(resources.GetObject("GroupControl1.CustomHeaderButtons29"), Boolean), CType(resources.GetObject("GroupControl1.CustomHeaderButtons30"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("GroupControl1.CustomHeaderButtons31"), Boolean), CType(resources.GetObject("GroupControl1.CustomHeaderButtons32"), Boolean), CType(resources.GetObject("GroupControl1.CustomHeaderButtons33"), Boolean), CType(resources.GetObject("GroupControl1.CustomHeaderButtons34"), Object), CType(resources.GetObject("GroupControl1.CustomHeaderButtons35"), Integer))})
        Me.GroupControl1.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText
        resources.ApplyResources(Me.GroupControl1, "GroupControl1")
        Me.GroupControl1.Name = "GroupControl1"
        '
        'chkUnlock
        '
        Me.chkUnlock.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.chkUnlock.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.Security_Unlock
        Me.chkUnlock.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.chkUnlock, "chkUnlock")
        Me.chkUnlock.Name = "chkUnlock"
        '
        'cboTextFontSize
        '
        resources.ApplyResources(Me.cboTextFontSize, "cboTextFontSize")
        Me.cboTextFontSize.Name = "cboTextFontSize"
        Me.cboTextFontSize.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboTextFontSize.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboTextFontSize.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines)), New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboTextFontSize.Properties.Buttons1"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboTextFontSize.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.cboTextFontSize.Properties.Items.AddRange(New Object() {resources.GetString("cboTextFontSize.Properties.Items"), resources.GetString("cboTextFontSize.Properties.Items1"), resources.GetString("cboTextFontSize.Properties.Items2"), resources.GetString("cboTextFontSize.Properties.Items3"), resources.GetString("cboTextFontSize.Properties.Items4"), resources.GetString("cboTextFontSize.Properties.Items5"), resources.GetString("cboTextFontSize.Properties.Items6"), resources.GetString("cboTextFontSize.Properties.Items7"), resources.GetString("cboTextFontSize.Properties.Items8"), resources.GetString("cboTextFontSize.Properties.Items9"), resources.GetString("cboTextFontSize.Properties.Items10"), resources.GetString("cboTextFontSize.Properties.Items11"), resources.GetString("cboTextFontSize.Properties.Items12"), resources.GetString("cboTextFontSize.Properties.Items13"), resources.GetString("cboTextFontSize.Properties.Items14"), resources.GetString("cboTextFontSize.Properties.Items15"), resources.GetString("cboTextFontSize.Properties.Items16")})
        Me.cboTextFontSize.Properties.NullText = resources.GetString("cboTextFontSize.Properties.NullText")
        '
        'cboTextFontChar
        '
        resources.ApplyResources(Me.cboTextFontChar, "cboTextFontChar")
        Me.cboTextFontChar.Name = "cboTextFontChar"
        Me.cboTextFontChar.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboTextFontChar.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboTextFontChar.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines)), New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboTextFontChar.Properties.Buttons1"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboTextFontChar.Properties.NullText = resources.GetString("cboTextFontChar.Properties.NullText")
        '
        'txtColor
        '
        resources.ApplyResources(Me.txtColor, "txtColor")
        Me.txtColor.Name = "txtColor"
        Me.txtColor.DefaultColor = Color.Transparent
        Me.txtColor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtColor.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtColor.Properties.ColorAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtColor.Properties.ShowSystemColors = False
        Me.txtColor.Properties.ShowWebColors = False
        '
        'lblTextColor
        '
        resources.ApplyResources(Me.lblTextColor, "lblTextColor")
        Me.lblTextColor.Name = "lblTextColor"
        '
        'frmParametersInfoBox
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.lblWidthUnit)
        Me.Controls.Add(Me.txtWidth)
        Me.Controls.Add(Me.lblWidth)
        Me.Name = "frmParametersInfoBox"
        CType(Me.chkVisible.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWidth.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.cboTextFontSize.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTextFontChar.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtColor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkTextFontUnderline As DevExpress.XtraEditors.CheckButton
    Friend WithEvents chkTextFontItalic As DevExpress.XtraEditors.CheckButton
    Friend WithEvents chkTextFontBold As DevExpress.XtraEditors.CheckButton
    Friend WithEvents lblPropTextFontChar As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblTextFontSize As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkVisible As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblWidth As System.Windows.Forms.Label
    Friend WithEvents txtWidth As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents lblWidthUnit As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents txtColor As cColorSelector
    Friend WithEvents lblTextColor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboTextFontSize As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents cboTextFontChar As DevExpress.XtraEditors.FontEdit
    Friend WithEvents chkUnlock As DevExpress.XtraEditors.CheckButton
End Class
