<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmParametersCompass
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmParametersCompass))
        Me.lblCompassColor = New System.Windows.Forms.Label()
        Me.cmdCompassColorBrowse = New System.Windows.Forms.Button()
        Me.picCompassColor = New System.Windows.Forms.PictureBox()
        Me.picCompassClipartImage = New System.Windows.Forms.PictureBox()
        Me.lblCompassClipartZoomFactor = New System.Windows.Forms.Label()
        Me.txtCompassClipartZoomFactor = New System.Windows.Forms.NumericUpDown()
        Me.lblCompassClipart = New System.Windows.Forms.Label()
        Me.cmdCompassBrowseClipart = New System.Windows.Forms.Button()
        Me.cmdApply = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.lblCompassText = New System.Windows.Forms.Label()
        Me.txtCompassText = New System.Windows.Forms.TextBox()
        Me.lblCompassTextFontSize = New System.Windows.Forms.Label()
        Me.cboCompassTextFontSize = New System.Windows.Forms.ComboBox()
        Me.lblCompassTextFontChar = New System.Windows.Forms.Label()
        Me.cboCompassTextFontChar = New System.Windows.Forms.ComboBox()
        Me.chkCompassTextFontBold = New System.Windows.Forms.CheckBox()
        Me.chkCompassTextFontItalic = New System.Windows.Forms.CheckBox()
        Me.chkCompassTextFontUnderline = New System.Windows.Forms.CheckBox()
        CType(Me.picCompassColor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCompassClipartImage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCompassClipartZoomFactor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblCompassColor
        '
        resources.ApplyResources(Me.lblCompassColor, "lblCompassColor")
        Me.lblCompassColor.Name = "lblCompassColor"
        '
        'cmdCompassColorBrowse
        '
        resources.ApplyResources(Me.cmdCompassColorBrowse, "cmdCompassColorBrowse")
        Me.cmdCompassColorBrowse.Name = "cmdCompassColorBrowse"
        Me.cmdCompassColorBrowse.UseVisualStyleBackColor = True
        '
        'picCompassColor
        '
        resources.ApplyResources(Me.picCompassColor, "picCompassColor")
        Me.picCompassColor.Name = "picCompassColor"
        Me.picCompassColor.TabStop = False
        '
        'picCompassClipartImage
        '
        resources.ApplyResources(Me.picCompassClipartImage, "picCompassClipartImage")
        Me.picCompassClipartImage.Name = "picCompassClipartImage"
        Me.picCompassClipartImage.TabStop = False
        '
        'lblCompassClipartZoomFactor
        '
        resources.ApplyResources(Me.lblCompassClipartZoomFactor, "lblCompassClipartZoomFactor")
        Me.lblCompassClipartZoomFactor.Name = "lblCompassClipartZoomFactor"
        '
        'txtCompassClipartZoomFactor
        '
        Me.txtCompassClipartZoomFactor.DecimalPlaces = 2
        Me.txtCompassClipartZoomFactor.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        resources.ApplyResources(Me.txtCompassClipartZoomFactor, "txtCompassClipartZoomFactor")
        Me.txtCompassClipartZoomFactor.Minimum = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.txtCompassClipartZoomFactor.Name = "txtCompassClipartZoomFactor"
        Me.txtCompassClipartZoomFactor.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblCompassClipart
        '
        resources.ApplyResources(Me.lblCompassClipart, "lblCompassClipart")
        Me.lblCompassClipart.Name = "lblCompassClipart"
        '
        'cmdCompassBrowseClipart
        '
        resources.ApplyResources(Me.cmdCompassBrowseClipart, "cmdCompassBrowseClipart")
        Me.cmdCompassBrowseClipart.Name = "cmdCompassBrowseClipart"
        Me.cmdCompassBrowseClipart.UseVisualStyleBackColor = True
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
        'cboCompassTextFontSize
        '
        Me.cboCompassTextFontSize.FormattingEnabled = True
        Me.cboCompassTextFontSize.Items.AddRange(New Object() {resources.GetString("cboCompassTextFontSize.Items"), resources.GetString("cboCompassTextFontSize.Items1"), resources.GetString("cboCompassTextFontSize.Items2"), resources.GetString("cboCompassTextFontSize.Items3"), resources.GetString("cboCompassTextFontSize.Items4"), resources.GetString("cboCompassTextFontSize.Items5"), resources.GetString("cboCompassTextFontSize.Items6"), resources.GetString("cboCompassTextFontSize.Items7"), resources.GetString("cboCompassTextFontSize.Items8"), resources.GetString("cboCompassTextFontSize.Items9"), resources.GetString("cboCompassTextFontSize.Items10"), resources.GetString("cboCompassTextFontSize.Items11"), resources.GetString("cboCompassTextFontSize.Items12"), resources.GetString("cboCompassTextFontSize.Items13"), resources.GetString("cboCompassTextFontSize.Items14"), resources.GetString("cboCompassTextFontSize.Items15"), resources.GetString("cboCompassTextFontSize.Items16")})
        resources.ApplyResources(Me.cboCompassTextFontSize, "cboCompassTextFontSize")
        Me.cboCompassTextFontSize.Name = "cboCompassTextFontSize"
        '
        'lblCompassTextFontChar
        '
        resources.ApplyResources(Me.lblCompassTextFontChar, "lblCompassTextFontChar")
        Me.lblCompassTextFontChar.Name = "lblCompassTextFontChar"
        '
        'cboCompassTextFontChar
        '
        Me.cboCompassTextFontChar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCompassTextFontChar.FormattingEnabled = True
        resources.ApplyResources(Me.cboCompassTextFontChar, "cboCompassTextFontChar")
        Me.cboCompassTextFontChar.Name = "cboCompassTextFontChar"
        '
        'chkCompassTextFontBold
        '
        resources.ApplyResources(Me.chkCompassTextFontBold, "chkCompassTextFontBold")
        Me.chkCompassTextFontBold.Image = Global.cSurveyPC.My.Resources.Resources.text_bold
        Me.chkCompassTextFontBold.Name = "chkCompassTextFontBold"
        Me.chkCompassTextFontBold.UseVisualStyleBackColor = True
        '
        'chkCompassTextFontItalic
        '
        resources.ApplyResources(Me.chkCompassTextFontItalic, "chkCompassTextFontItalic")
        Me.chkCompassTextFontItalic.Image = Global.cSurveyPC.My.Resources.Resources.text_italic
        Me.chkCompassTextFontItalic.Name = "chkCompassTextFontItalic"
        Me.chkCompassTextFontItalic.UseVisualStyleBackColor = True
        '
        'chkCompassTextFontUnderline
        '
        resources.ApplyResources(Me.chkCompassTextFontUnderline, "chkCompassTextFontUnderline")
        Me.chkCompassTextFontUnderline.Image = Global.cSurveyPC.My.Resources.Resources.text_underline
        Me.chkCompassTextFontUnderline.Name = "chkCompassTextFontUnderline"
        Me.chkCompassTextFontUnderline.UseVisualStyleBackColor = True
        '
        'frmParametersCompass
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.cmdApply)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.chkCompassTextFontUnderline)
        Me.Controls.Add(Me.chkCompassTextFontItalic)
        Me.Controls.Add(Me.chkCompassTextFontBold)
        Me.Controls.Add(Me.cboCompassTextFontChar)
        Me.Controls.Add(Me.lblCompassTextFontChar)
        Me.Controls.Add(Me.cboCompassTextFontSize)
        Me.Controls.Add(Me.lblCompassTextFontSize)
        Me.Controls.Add(Me.txtCompassText)
        Me.Controls.Add(Me.lblCompassText)
        Me.Controls.Add(Me.cmdCompassBrowseClipart)
        Me.Controls.Add(Me.lblCompassColor)
        Me.Controls.Add(Me.cmdCompassColorBrowse)
        Me.Controls.Add(Me.picCompassColor)
        Me.Controls.Add(Me.picCompassClipartImage)
        Me.Controls.Add(Me.lblCompassClipartZoomFactor)
        Me.Controls.Add(Me.txtCompassClipartZoomFactor)
        Me.Controls.Add(Me.lblCompassClipart)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmParametersCompass"
        CType(Me.picCompassColor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCompassClipartImage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCompassClipartZoomFactor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCompassColor As System.Windows.Forms.Label
    Friend WithEvents cmdCompassColorBrowse As System.Windows.Forms.Button
    Friend WithEvents picCompassColor As System.Windows.Forms.PictureBox
    Friend WithEvents picCompassClipartImage As System.Windows.Forms.PictureBox
    Friend WithEvents lblCompassClipartZoomFactor As System.Windows.Forms.Label
    Friend WithEvents txtCompassClipartZoomFactor As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblCompassClipart As System.Windows.Forms.Label
    Friend WithEvents cmdCompassBrowseClipart As System.Windows.Forms.Button
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents lblCompassText As System.Windows.Forms.Label
    Friend WithEvents txtCompassText As System.Windows.Forms.TextBox
    Friend WithEvents lblCompassTextFontSize As System.Windows.Forms.Label
    Friend WithEvents cboCompassTextFontSize As System.Windows.Forms.ComboBox
    Friend WithEvents lblCompassTextFontChar As System.Windows.Forms.Label
    Friend WithEvents cboCompassTextFontChar As System.Windows.Forms.ComboBox
    Friend WithEvents chkCompassTextFontBold As System.Windows.Forms.CheckBox
    Friend WithEvents chkCompassTextFontItalic As System.Windows.Forms.CheckBox
    Friend WithEvents chkCompassTextFontUnderline As System.Windows.Forms.CheckBox
End Class
