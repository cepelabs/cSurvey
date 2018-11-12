<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmParametersInfoBox
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmParametersInfoBox))
        Me.lblFontColor = New System.Windows.Forms.Label()
        Me.cmdFontColor = New System.Windows.Forms.Button()
        Me.picFontColor = New System.Windows.Forms.PictureBox()
        Me.chkTextFontUnderline = New System.Windows.Forms.CheckBox()
        Me.chkTextFontItalic = New System.Windows.Forms.CheckBox()
        Me.chkTextFontBold = New System.Windows.Forms.CheckBox()
        Me.cboTextFontChar = New System.Windows.Forms.ComboBox()
        Me.lblPropTextFontChar = New System.Windows.Forms.Label()
        Me.cboTextFontSize = New System.Windows.Forms.ComboBox()
        Me.lblTextFontSize = New System.Windows.Forms.Label()
        Me.tabInfoBoxPart = New System.Windows.Forms.TabControl()
        Me.tabID = New System.Windows.Forms.TabPage()
        Me.pnlSub = New System.Windows.Forms.Panel()
        Me.chkVisible = New System.Windows.Forms.CheckBox()
        Me.tabName = New System.Windows.Forms.TabPage()
        Me.tabText = New System.Windows.Forms.TabPage()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdApply = New System.Windows.Forms.Button()
        Me.lblWidth = New System.Windows.Forms.Label()
        Me.txtWidth = New System.Windows.Forms.NumericUpDown()
        Me.lblWidthUnit = New System.Windows.Forms.Label()
        CType(Me.picFontColor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabInfoBoxPart.SuspendLayout()
        Me.tabID.SuspendLayout()
        Me.pnlSub.SuspendLayout()
        CType(Me.txtWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblFontColor
        '
        resources.ApplyResources(Me.lblFontColor, "lblFontColor")
        Me.lblFontColor.Name = "lblFontColor"
        '
        'cmdFontColor
        '
        resources.ApplyResources(Me.cmdFontColor, "cmdFontColor")
        Me.cmdFontColor.Name = "cmdFontColor"
        Me.cmdFontColor.UseVisualStyleBackColor = True
        '
        'picFontColor
        '
        resources.ApplyResources(Me.picFontColor, "picFontColor")
        Me.picFontColor.Name = "picFontColor"
        Me.picFontColor.TabStop = False
        '
        'chkTextFontUnderline
        '
        resources.ApplyResources(Me.chkTextFontUnderline, "chkTextFontUnderline")
        Me.chkTextFontUnderline.Image = Global.cSurveyPC.My.Resources.Resources.text_underline
        Me.chkTextFontUnderline.Name = "chkTextFontUnderline"
        Me.chkTextFontUnderline.UseVisualStyleBackColor = True
        '
        'chkTextFontItalic
        '
        resources.ApplyResources(Me.chkTextFontItalic, "chkTextFontItalic")
        Me.chkTextFontItalic.Image = Global.cSurveyPC.My.Resources.Resources.text_italic
        Me.chkTextFontItalic.Name = "chkTextFontItalic"
        Me.chkTextFontItalic.UseVisualStyleBackColor = True
        '
        'chkTextFontBold
        '
        resources.ApplyResources(Me.chkTextFontBold, "chkTextFontBold")
        Me.chkTextFontBold.Image = Global.cSurveyPC.My.Resources.Resources.text_bold
        Me.chkTextFontBold.Name = "chkTextFontBold"
        Me.chkTextFontBold.UseVisualStyleBackColor = True
        '
        'cboTextFontChar
        '
        Me.cboTextFontChar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTextFontChar.FormattingEnabled = True
        resources.ApplyResources(Me.cboTextFontChar, "cboTextFontChar")
        Me.cboTextFontChar.Name = "cboTextFontChar"
        '
        'lblPropTextFontChar
        '
        resources.ApplyResources(Me.lblPropTextFontChar, "lblPropTextFontChar")
        Me.lblPropTextFontChar.Name = "lblPropTextFontChar"
        '
        'cboTextFontSize
        '
        Me.cboTextFontSize.FormattingEnabled = True
        Me.cboTextFontSize.Items.AddRange(New Object() {resources.GetString("cboTextFontSize.Items"), resources.GetString("cboTextFontSize.Items1"), resources.GetString("cboTextFontSize.Items2"), resources.GetString("cboTextFontSize.Items3"), resources.GetString("cboTextFontSize.Items4"), resources.GetString("cboTextFontSize.Items5"), resources.GetString("cboTextFontSize.Items6"), resources.GetString("cboTextFontSize.Items7"), resources.GetString("cboTextFontSize.Items8"), resources.GetString("cboTextFontSize.Items9"), resources.GetString("cboTextFontSize.Items10"), resources.GetString("cboTextFontSize.Items11"), resources.GetString("cboTextFontSize.Items12"), resources.GetString("cboTextFontSize.Items13"), resources.GetString("cboTextFontSize.Items14"), resources.GetString("cboTextFontSize.Items15"), resources.GetString("cboTextFontSize.Items16"), resources.GetString("cboTextFontSize.Items17")})
        resources.ApplyResources(Me.cboTextFontSize, "cboTextFontSize")
        Me.cboTextFontSize.Name = "cboTextFontSize"
        '
        'lblTextFontSize
        '
        resources.ApplyResources(Me.lblTextFontSize, "lblTextFontSize")
        Me.lblTextFontSize.Name = "lblTextFontSize"
        '
        'tabInfoBoxPart
        '
        Me.tabInfoBoxPart.Controls.Add(Me.tabID)
        Me.tabInfoBoxPart.Controls.Add(Me.tabName)
        Me.tabInfoBoxPart.Controls.Add(Me.tabText)
        resources.ApplyResources(Me.tabInfoBoxPart, "tabInfoBoxPart")
        Me.tabInfoBoxPart.Multiline = True
        Me.tabInfoBoxPart.Name = "tabInfoBoxPart"
        Me.tabInfoBoxPart.SelectedIndex = 0
        '
        'tabID
        '
        Me.tabID.Controls.Add(Me.pnlSub)
        resources.ApplyResources(Me.tabID, "tabID")
        Me.tabID.Name = "tabID"
        Me.tabID.UseVisualStyleBackColor = True
        '
        'pnlSub
        '
        Me.pnlSub.Controls.Add(Me.chkVisible)
        Me.pnlSub.Controls.Add(Me.chkTextFontBold)
        Me.pnlSub.Controls.Add(Me.picFontColor)
        Me.pnlSub.Controls.Add(Me.lblFontColor)
        Me.pnlSub.Controls.Add(Me.chkTextFontUnderline)
        Me.pnlSub.Controls.Add(Me.lblTextFontSize)
        Me.pnlSub.Controls.Add(Me.cboTextFontSize)
        Me.pnlSub.Controls.Add(Me.chkTextFontItalic)
        Me.pnlSub.Controls.Add(Me.cmdFontColor)
        resources.ApplyResources(Me.pnlSub, "pnlSub")
        Me.pnlSub.Name = "pnlSub"
        '
        'chkVisible
        '
        resources.ApplyResources(Me.chkVisible, "chkVisible")
        Me.chkVisible.Name = "chkVisible"
        Me.chkVisible.UseVisualStyleBackColor = True
        '
        'tabName
        '
        resources.ApplyResources(Me.tabName, "tabName")
        Me.tabName.Name = "tabName"
        Me.tabName.UseVisualStyleBackColor = True
        '
        'tabText
        '
        resources.ApplyResources(Me.tabText, "tabText")
        Me.tabText.Name = "tabText"
        Me.tabText.UseVisualStyleBackColor = True
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
        'cmdApply
        '
        resources.ApplyResources(Me.cmdApply, "cmdApply")
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.UseVisualStyleBackColor = True
        '
        'lblWidth
        '
        resources.ApplyResources(Me.lblWidth, "lblWidth")
        Me.lblWidth.Name = "lblWidth"
        '
        'txtWidth
        '
        resources.ApplyResources(Me.txtWidth, "txtWidth")
        Me.txtWidth.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.txtWidth.Name = "txtWidth"
        '
        'lblWidthUnit
        '
        resources.ApplyResources(Me.lblWidthUnit, "lblWidthUnit")
        Me.lblWidthUnit.Name = "lblWidthUnit"
        '
        'frmParametersInfoBox
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.lblWidthUnit)
        Me.Controls.Add(Me.txtWidth)
        Me.Controls.Add(Me.lblWidth)
        Me.Controls.Add(Me.cmdApply)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.tabInfoBoxPart)
        Me.Controls.Add(Me.cboTextFontChar)
        Me.Controls.Add(Me.lblPropTextFontChar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmParametersInfoBox"
        CType(Me.picFontColor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabInfoBoxPart.ResumeLayout(False)
        Me.tabID.ResumeLayout(False)
        Me.pnlSub.ResumeLayout(False)
        Me.pnlSub.PerformLayout()
        CType(Me.txtWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblFontColor As System.Windows.Forms.Label
    Friend WithEvents cmdFontColor As System.Windows.Forms.Button
    Friend WithEvents picFontColor As System.Windows.Forms.PictureBox
    Friend WithEvents chkTextFontUnderline As System.Windows.Forms.CheckBox
    Friend WithEvents chkTextFontItalic As System.Windows.Forms.CheckBox
    Friend WithEvents chkTextFontBold As System.Windows.Forms.CheckBox
    Friend WithEvents cboTextFontChar As System.Windows.Forms.ComboBox
    Friend WithEvents lblPropTextFontChar As System.Windows.Forms.Label
    Friend WithEvents cboTextFontSize As System.Windows.Forms.ComboBox
    Friend WithEvents lblTextFontSize As System.Windows.Forms.Label
    Friend WithEvents tabInfoBoxPart As System.Windows.Forms.TabControl
    Friend WithEvents tabID As System.Windows.Forms.TabPage
    Friend WithEvents pnlSub As System.Windows.Forms.Panel
    Friend WithEvents chkVisible As System.Windows.Forms.CheckBox
    Friend WithEvents tabName As System.Windows.Forms.TabPage
    Friend WithEvents tabText As System.Windows.Forms.TabPage
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents lblWidth As System.Windows.Forms.Label
    Friend WithEvents txtWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblWidthUnit As System.Windows.Forms.Label
End Class
