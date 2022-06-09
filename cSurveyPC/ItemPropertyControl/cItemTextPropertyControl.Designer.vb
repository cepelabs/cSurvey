<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cItemTextPropertyControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cItemTextPropertyControl))
        Me.pnlPropTextStyleVAlign = New System.Windows.Forms.Panel()
        Me.optPropTextVAlignBottom = New System.Windows.Forms.CheckBox()
        Me.optPropTextVAlignTop = New System.Windows.Forms.CheckBox()
        Me.optPropTextVAlignCenter = New System.Windows.Forms.CheckBox()
        Me.optPropTextAlignRight = New System.Windows.Forms.CheckBox()
        Me.optPropTextAlignCenter = New System.Windows.Forms.CheckBox()
        Me.optPropTextAlignLeft = New System.Windows.Forms.CheckBox()
        Me.cboPropTextSize = New System.Windows.Forms.ComboBox()
        Me.lblPropTextSize = New System.Windows.Forms.Label()
        Me.lblPropText = New System.Windows.Forms.Label()
        Me.txtPropText = New System.Windows.Forms.TextBox()
        Me.lblPropTextStyle = New System.Windows.Forms.Label()
        Me.cboPropTextStyle = New System.Windows.Forms.ComboBox()
        Me.cboPropTextRotateMode = New System.Windows.Forms.ComboBox()
        Me.lblPropTextRotateMode = New System.Windows.Forms.Label()
        Me.pnlPropTextFont = New System.Windows.Forms.Panel()
        Me.lblPropFontColor = New System.Windows.Forms.Label()
        Me.cmdPropFontColor = New System.Windows.Forms.Button()
        Me.picPropFontColor = New System.Windows.Forms.PictureBox()
        Me.chkPropTextFontUnderline = New System.Windows.Forms.CheckBox()
        Me.chkPropTextFontItalic = New System.Windows.Forms.CheckBox()
        Me.chkPropTextFontBold = New System.Windows.Forms.CheckBox()
        Me.cboPropTextFontChar = New System.Windows.Forms.ComboBox()
        Me.lblPropTextFontChar = New System.Windows.Forms.Label()
        Me.cboPropTextFontSize = New System.Windows.Forms.ComboBox()
        Me.lblPropTextFontSize = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlPropTextStyle = New System.Windows.Forms.Panel()
        Me.pnlPropTextAlignmentAndRotation = New System.Windows.Forms.Panel()
        Me.pnlPropTextStyleVAlign.SuspendLayout()
        Me.pnlPropTextFont.SuspendLayout()
        CType(Me.picPropFontColor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.pnlPropTextStyle.SuspendLayout()
        Me.pnlPropTextAlignmentAndRotation.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlPropTextStyleVAlign
        '
        Me.pnlPropTextStyleVAlign.Controls.Add(Me.optPropTextVAlignBottom)
        Me.pnlPropTextStyleVAlign.Controls.Add(Me.optPropTextVAlignTop)
        Me.pnlPropTextStyleVAlign.Controls.Add(Me.optPropTextVAlignCenter)
        resources.ApplyResources(Me.pnlPropTextStyleVAlign, "pnlPropTextStyleVAlign")
        Me.pnlPropTextStyleVAlign.Name = "pnlPropTextStyleVAlign"
        '
        'optPropTextVAlignBottom
        '
        resources.ApplyResources(Me.optPropTextVAlignBottom, "optPropTextVAlignBottom")
        Me.optPropTextVAlignBottom.Name = "optPropTextVAlignBottom"
        Me.optPropTextVAlignBottom.UseVisualStyleBackColor = True
        '
        'optPropTextVAlignTop
        '
        resources.ApplyResources(Me.optPropTextVAlignTop, "optPropTextVAlignTop")
        Me.optPropTextVAlignTop.Name = "optPropTextVAlignTop"
        Me.optPropTextVAlignTop.UseVisualStyleBackColor = True
        '
        'optPropTextVAlignCenter
        '
        resources.ApplyResources(Me.optPropTextVAlignCenter, "optPropTextVAlignCenter")
        Me.optPropTextVAlignCenter.Checked = True
        Me.optPropTextVAlignCenter.CheckState = System.Windows.Forms.CheckState.Checked
        Me.optPropTextVAlignCenter.Name = "optPropTextVAlignCenter"
        Me.optPropTextVAlignCenter.UseVisualStyleBackColor = True
        '
        'optPropTextAlignRight
        '
        resources.ApplyResources(Me.optPropTextAlignRight, "optPropTextAlignRight")
        Me.optPropTextAlignRight.Name = "optPropTextAlignRight"
        Me.optPropTextAlignRight.UseVisualStyleBackColor = True
        '
        'optPropTextAlignCenter
        '
        resources.ApplyResources(Me.optPropTextAlignCenter, "optPropTextAlignCenter")
        Me.optPropTextAlignCenter.Checked = True
        Me.optPropTextAlignCenter.CheckState = System.Windows.Forms.CheckState.Checked
        Me.optPropTextAlignCenter.Name = "optPropTextAlignCenter"
        Me.optPropTextAlignCenter.UseVisualStyleBackColor = True
        '
        'optPropTextAlignLeft
        '
        resources.ApplyResources(Me.optPropTextAlignLeft, "optPropTextAlignLeft")
        Me.optPropTextAlignLeft.Name = "optPropTextAlignLeft"
        Me.optPropTextAlignLeft.UseVisualStyleBackColor = True
        '
        'cboPropTextSize
        '
        Me.cboPropTextSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropTextSize.FormattingEnabled = True
        Me.cboPropTextSize.Items.AddRange(New Object() {resources.GetString("cboPropTextSize.Items"), resources.GetString("cboPropTextSize.Items1"), resources.GetString("cboPropTextSize.Items2"), resources.GetString("cboPropTextSize.Items3"), resources.GetString("cboPropTextSize.Items4"), resources.GetString("cboPropTextSize.Items5"), resources.GetString("cboPropTextSize.Items6"), resources.GetString("cboPropTextSize.Items7"), resources.GetString("cboPropTextSize.Items8"), resources.GetString("cboPropTextSize.Items9"), resources.GetString("cboPropTextSize.Items10"), resources.GetString("cboPropTextSize.Items11"), resources.GetString("cboPropTextSize.Items12"), resources.GetString("cboPropTextSize.Items13")})
        resources.ApplyResources(Me.cboPropTextSize, "cboPropTextSize")
        Me.cboPropTextSize.Name = "cboPropTextSize"
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
        'cboPropTextStyle
        '
        resources.ApplyResources(Me.cboPropTextStyle, "cboPropTextStyle")
        Me.cboPropTextStyle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboPropTextStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropTextStyle.FormattingEnabled = True
        Me.cboPropTextStyle.Items.AddRange(New Object() {resources.GetString("cboPropTextStyle.Items"), resources.GetString("cboPropTextStyle.Items1"), resources.GetString("cboPropTextStyle.Items2"), resources.GetString("cboPropTextStyle.Items3")})
        Me.cboPropTextStyle.Name = "cboPropTextStyle"
        '
        'cboPropTextRotateMode
        '
        Me.cboPropTextRotateMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropTextRotateMode.FormattingEnabled = True
        Me.cboPropTextRotateMode.Items.AddRange(New Object() {resources.GetString("cboPropTextRotateMode.Items"), resources.GetString("cboPropTextRotateMode.Items1")})
        resources.ApplyResources(Me.cboPropTextRotateMode, "cboPropTextRotateMode")
        Me.cboPropTextRotateMode.Name = "cboPropTextRotateMode"
        '
        'lblPropTextRotateMode
        '
        resources.ApplyResources(Me.lblPropTextRotateMode, "lblPropTextRotateMode")
        Me.lblPropTextRotateMode.Name = "lblPropTextRotateMode"
        '
        'pnlPropTextFont
        '
        resources.ApplyResources(Me.pnlPropTextFont, "pnlPropTextFont")
        Me.pnlPropTextFont.BackColor = System.Drawing.Color.Transparent
        Me.pnlPropTextFont.Controls.Add(Me.lblPropFontColor)
        Me.pnlPropTextFont.Controls.Add(Me.cmdPropFontColor)
        Me.pnlPropTextFont.Controls.Add(Me.picPropFontColor)
        Me.pnlPropTextFont.Controls.Add(Me.chkPropTextFontUnderline)
        Me.pnlPropTextFont.Controls.Add(Me.chkPropTextFontItalic)
        Me.pnlPropTextFont.Controls.Add(Me.chkPropTextFontBold)
        Me.pnlPropTextFont.Controls.Add(Me.cboPropTextFontChar)
        Me.pnlPropTextFont.Controls.Add(Me.lblPropTextFontChar)
        Me.pnlPropTextFont.Controls.Add(Me.cboPropTextFontSize)
        Me.pnlPropTextFont.Controls.Add(Me.lblPropTextFontSize)
        Me.pnlPropTextFont.Name = "pnlPropTextFont"
        '
        'lblPropFontColor
        '
        resources.ApplyResources(Me.lblPropFontColor, "lblPropFontColor")
        Me.lblPropFontColor.Name = "lblPropFontColor"
        '
        'cmdPropFontColor
        '
        resources.ApplyResources(Me.cmdPropFontColor, "cmdPropFontColor")
        Me.cmdPropFontColor.Name = "cmdPropFontColor"
        Me.cmdPropFontColor.UseVisualStyleBackColor = True
        '
        'picPropFontColor
        '
        resources.ApplyResources(Me.picPropFontColor, "picPropFontColor")
        Me.picPropFontColor.Name = "picPropFontColor"
        Me.picPropFontColor.TabStop = False
        '
        'chkPropTextFontUnderline
        '
        resources.ApplyResources(Me.chkPropTextFontUnderline, "chkPropTextFontUnderline")
        Me.chkPropTextFontUnderline.Name = "chkPropTextFontUnderline"
        Me.chkPropTextFontUnderline.UseVisualStyleBackColor = True
        '
        'chkPropTextFontItalic
        '
        resources.ApplyResources(Me.chkPropTextFontItalic, "chkPropTextFontItalic")
        Me.chkPropTextFontItalic.Name = "chkPropTextFontItalic"
        Me.chkPropTextFontItalic.UseVisualStyleBackColor = True
        '
        'chkPropTextFontBold
        '
        resources.ApplyResources(Me.chkPropTextFontBold, "chkPropTextFontBold")
        Me.chkPropTextFontBold.Name = "chkPropTextFontBold"
        Me.chkPropTextFontBold.UseVisualStyleBackColor = True
        '
        'cboPropTextFontChar
        '
        Me.cboPropTextFontChar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropTextFontChar.FormattingEnabled = True
        resources.ApplyResources(Me.cboPropTextFontChar, "cboPropTextFontChar")
        Me.cboPropTextFontChar.Name = "cboPropTextFontChar"
        '
        'lblPropTextFontChar
        '
        resources.ApplyResources(Me.lblPropTextFontChar, "lblPropTextFontChar")
        Me.lblPropTextFontChar.Name = "lblPropTextFontChar"
        '
        'cboPropTextFontSize
        '
        Me.cboPropTextFontSize.FormattingEnabled = True
        Me.cboPropTextFontSize.Items.AddRange(New Object() {resources.GetString("cboPropTextFontSize.Items"), resources.GetString("cboPropTextFontSize.Items1"), resources.GetString("cboPropTextFontSize.Items2"), resources.GetString("cboPropTextFontSize.Items3"), resources.GetString("cboPropTextFontSize.Items4"), resources.GetString("cboPropTextFontSize.Items5"), resources.GetString("cboPropTextFontSize.Items6"), resources.GetString("cboPropTextFontSize.Items7"), resources.GetString("cboPropTextFontSize.Items8"), resources.GetString("cboPropTextFontSize.Items9"), resources.GetString("cboPropTextFontSize.Items10"), resources.GetString("cboPropTextFontSize.Items11"), resources.GetString("cboPropTextFontSize.Items12"), resources.GetString("cboPropTextFontSize.Items13"), resources.GetString("cboPropTextFontSize.Items14"), resources.GetString("cboPropTextFontSize.Items15"), resources.GetString("cboPropTextFontSize.Items16"), resources.GetString("cboPropTextFontSize.Items17")})
        resources.ApplyResources(Me.cboPropTextFontSize, "cboPropTextFontSize")
        Me.cboPropTextFontSize.Name = "cboPropTextFontSize"
        '
        'lblPropTextFontSize
        '
        resources.ApplyResources(Me.lblPropTextFontSize, "lblPropTextFontSize")
        Me.lblPropTextFontSize.Name = "lblPropTextFontSize"
        '
        'TableLayoutPanel1
        '
        resources.ApplyResources(Me.TableLayoutPanel1, "TableLayoutPanel1")
        Me.TableLayoutPanel1.Controls.Add(Me.pnlPropTextStyle, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.pnlPropTextFont, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.pnlPropTextAlignmentAndRotation, 0, 2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        '
        'pnlPropTextStyle
        '
        resources.ApplyResources(Me.pnlPropTextStyle, "pnlPropTextStyle")
        Me.pnlPropTextStyle.Controls.Add(Me.txtPropText)
        Me.pnlPropTextStyle.Controls.Add(Me.cboPropTextStyle)
        Me.pnlPropTextStyle.Controls.Add(Me.lblPropTextStyle)
        Me.pnlPropTextStyle.Controls.Add(Me.lblPropText)
        Me.pnlPropTextStyle.Name = "pnlPropTextStyle"
        '
        'pnlPropTextAlignmentAndRotation
        '
        resources.ApplyResources(Me.pnlPropTextAlignmentAndRotation, "pnlPropTextAlignmentAndRotation")
        Me.pnlPropTextAlignmentAndRotation.Controls.Add(Me.cboPropTextRotateMode)
        Me.pnlPropTextAlignmentAndRotation.Controls.Add(Me.lblPropTextRotateMode)
        Me.pnlPropTextAlignmentAndRotation.Controls.Add(Me.lblPropTextSize)
        Me.pnlPropTextAlignmentAndRotation.Controls.Add(Me.pnlPropTextStyleVAlign)
        Me.pnlPropTextAlignmentAndRotation.Controls.Add(Me.cboPropTextSize)
        Me.pnlPropTextAlignmentAndRotation.Controls.Add(Me.optPropTextAlignLeft)
        Me.pnlPropTextAlignmentAndRotation.Controls.Add(Me.optPropTextAlignRight)
        Me.pnlPropTextAlignmentAndRotation.Controls.Add(Me.optPropTextAlignCenter)
        Me.pnlPropTextAlignmentAndRotation.Name = "pnlPropTextAlignmentAndRotation"
        '
        'cItemTextPropertyControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "cItemTextPropertyControl"
        Me.pnlPropTextStyleVAlign.ResumeLayout(False)
        Me.pnlPropTextFont.ResumeLayout(False)
        Me.pnlPropTextFont.PerformLayout()
        CType(Me.picPropFontColor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.pnlPropTextStyle.ResumeLayout(False)
        Me.pnlPropTextStyle.PerformLayout()
        Me.pnlPropTextAlignmentAndRotation.ResumeLayout(False)
        Me.pnlPropTextAlignmentAndRotation.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlPropTextStyleVAlign As Panel
    Friend WithEvents optPropTextVAlignBottom As CheckBox
    Friend WithEvents optPropTextVAlignTop As CheckBox
    Friend WithEvents optPropTextVAlignCenter As CheckBox
    Friend WithEvents optPropTextAlignRight As CheckBox
    Friend WithEvents optPropTextAlignCenter As CheckBox
    Friend WithEvents optPropTextAlignLeft As CheckBox
    Friend WithEvents cboPropTextSize As ComboBox
    Friend WithEvents lblPropTextSize As Label
    Friend WithEvents lblPropText As Label
    Friend WithEvents txtPropText As TextBox
    Friend WithEvents lblPropTextStyle As Label
    Friend WithEvents cboPropTextStyle As ComboBox
    Friend WithEvents cboPropTextRotateMode As ComboBox
    Friend WithEvents lblPropTextRotateMode As Label
    Friend WithEvents pnlPropTextFont As Panel
    Friend WithEvents lblPropFontColor As Label
    Friend WithEvents cmdPropFontColor As Button
    Friend WithEvents picPropFontColor As PictureBox
    Friend WithEvents chkPropTextFontUnderline As CheckBox
    Friend WithEvents chkPropTextFontItalic As CheckBox
    Friend WithEvents chkPropTextFontBold As CheckBox
    Friend WithEvents cboPropTextFontChar As ComboBox
    Friend WithEvents lblPropTextFontChar As Label
    Friend WithEvents cboPropTextFontSize As ComboBox
    Friend WithEvents lblPropTextFontSize As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents pnlPropTextStyle As Panel
    Friend WithEvents pnlPropTextAlignmentAndRotation As Panel
End Class
