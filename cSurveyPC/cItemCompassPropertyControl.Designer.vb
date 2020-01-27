<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cItemCompassPropertyControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cItemCompassPropertyControl))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmdCompassBrowseClipart = New System.Windows.Forms.Button()
        Me.lblCompassColor = New System.Windows.Forms.Label()
        Me.cmdCompassColorBrowse = New System.Windows.Forms.Button()
        Me.picCompassColor = New System.Windows.Forms.PictureBox()
        Me.picCompassClipartImage = New System.Windows.Forms.PictureBox()
        Me.lblCompassClipartZoomFactor = New System.Windows.Forms.Label()
        Me.txtCompassClipartZoomFactor = New System.Windows.Forms.NumericUpDown()
        Me.lblCompassClipart = New System.Windows.Forms.Label()
        Me.lblCompassMode = New System.Windows.Forms.Label()
        Me.cboCompassMode = New System.Windows.Forms.ComboBox()
        Me.cboCompassNorth = New System.Windows.Forms.ComboBox()
        Me.lblCompassNorth = New System.Windows.Forms.Label()
        Me.lblCompassYear = New System.Windows.Forms.Label()
        Me.txtCompassYear = New System.Windows.Forms.NumericUpDown()
        Me.chkUseTextScaleOnClipart = New System.Windows.Forms.CheckBox()
        Me.chkUseClipartScaleOnText = New System.Windows.Forms.CheckBox()
        Me.chkHideNorthValue = New System.Windows.Forms.CheckBox()
        CType(Me.picCompassColor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCompassClipartImage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCompassClipartZoomFactor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCompassYear, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'cmdCompassBrowseClipart
        '
        resources.ApplyResources(Me.cmdCompassBrowseClipart, "cmdCompassBrowseClipart")
        Me.cmdCompassBrowseClipart.Name = "cmdCompassBrowseClipart"
        Me.cmdCompassBrowseClipart.UseVisualStyleBackColor = True
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
        Me.txtCompassClipartZoomFactor.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.txtCompassClipartZoomFactor.Minimum = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.txtCompassClipartZoomFactor.Name = "txtCompassClipartZoomFactor"
        Me.txtCompassClipartZoomFactor.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblCompassClipart
        '
        resources.ApplyResources(Me.lblCompassClipart, "lblCompassClipart")
        Me.lblCompassClipart.Name = "lblCompassClipart"
        '
        'lblCompassMode
        '
        resources.ApplyResources(Me.lblCompassMode, "lblCompassMode")
        Me.lblCompassMode.Name = "lblCompassMode"
        '
        'cboCompassMode
        '
        Me.cboCompassMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCompassMode.FormattingEnabled = True
        Me.cboCompassMode.Items.AddRange(New Object() {resources.GetString("cboCompassMode.Items"), resources.GetString("cboCompassMode.Items1")})
        resources.ApplyResources(Me.cboCompassMode, "cboCompassMode")
        Me.cboCompassMode.Name = "cboCompassMode"
        '
        'cboCompassNorth
        '
        Me.cboCompassNorth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCompassNorth.FormattingEnabled = True
        Me.cboCompassNorth.Items.AddRange(New Object() {resources.GetString("cboCompassNorth.Items"), resources.GetString("cboCompassNorth.Items1")})
        resources.ApplyResources(Me.cboCompassNorth, "cboCompassNorth")
        Me.cboCompassNorth.Name = "cboCompassNorth"
        '
        'lblCompassNorth
        '
        resources.ApplyResources(Me.lblCompassNorth, "lblCompassNorth")
        Me.lblCompassNorth.Name = "lblCompassNorth"
        '
        'lblCompassYear
        '
        resources.ApplyResources(Me.lblCompassYear, "lblCompassYear")
        Me.lblCompassYear.Name = "lblCompassYear"
        '
        'txtCompassYear
        '
        resources.ApplyResources(Me.txtCompassYear, "txtCompassYear")
        Me.txtCompassYear.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.txtCompassYear.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.txtCompassYear.Minimum = New Decimal(New Integer() {1700, 0, 0, 0})
        Me.txtCompassYear.Name = "txtCompassYear"
        Me.txtCompassYear.Value = New Decimal(New Integer() {1700, 0, 0, 0})
        '
        'chkUseTextScaleOnClipart
        '
        resources.ApplyResources(Me.chkUseTextScaleOnClipart, "chkUseTextScaleOnClipart")
        Me.chkUseTextScaleOnClipart.Name = "chkUseTextScaleOnClipart"
        Me.chkUseTextScaleOnClipart.UseVisualStyleBackColor = True
        '
        'chkUseClipartScaleOnText
        '
        resources.ApplyResources(Me.chkUseClipartScaleOnText, "chkUseClipartScaleOnText")
        Me.chkUseClipartScaleOnText.Name = "chkUseClipartScaleOnText"
        Me.chkUseClipartScaleOnText.UseVisualStyleBackColor = True
        '
        'chkHideNorthValue
        '
        resources.ApplyResources(Me.chkHideNorthValue, "chkHideNorthValue")
        Me.chkHideNorthValue.Name = "chkHideNorthValue"
        Me.chkHideNorthValue.UseVisualStyleBackColor = True
        '
        'cItemCompassPropertyControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.Controls.Add(Me.chkHideNorthValue)
        Me.Controls.Add(Me.chkUseClipartScaleOnText)
        Me.Controls.Add(Me.chkUseTextScaleOnClipart)
        Me.Controls.Add(Me.txtCompassYear)
        Me.Controls.Add(Me.lblCompassYear)
        Me.Controls.Add(Me.cboCompassNorth)
        Me.Controls.Add(Me.lblCompassNorth)
        Me.Controls.Add(Me.cboCompassMode)
        Me.Controls.Add(Me.lblCompassMode)
        Me.Controls.Add(Me.cmdCompassBrowseClipart)
        Me.Controls.Add(Me.lblCompassColor)
        Me.Controls.Add(Me.cmdCompassColorBrowse)
        Me.Controls.Add(Me.picCompassColor)
        Me.Controls.Add(Me.picCompassClipartImage)
        Me.Controls.Add(Me.lblCompassClipartZoomFactor)
        Me.Controls.Add(Me.txtCompassClipartZoomFactor)
        Me.Controls.Add(Me.lblCompassClipart)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Name = "cItemCompassPropertyControl"
        CType(Me.picCompassColor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCompassClipartImage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCompassClipartZoomFactor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCompassYear, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cmdCompassBrowseClipart As Button
    Friend WithEvents lblCompassColor As Label
    Friend WithEvents cmdCompassColorBrowse As Button
    Friend WithEvents picCompassColor As PictureBox
    Friend WithEvents picCompassClipartImage As PictureBox
    Friend WithEvents lblCompassClipartZoomFactor As Label
    Friend WithEvents txtCompassClipartZoomFactor As NumericUpDown
    Friend WithEvents lblCompassClipart As Label
    Friend WithEvents lblCompassMode As Label
    Friend WithEvents cboCompassMode As ComboBox
    Friend WithEvents cboCompassNorth As ComboBox
    Friend WithEvents lblCompassNorth As Label
    Friend WithEvents lblCompassYear As Label
    Friend WithEvents txtCompassYear As NumericUpDown
    Friend WithEvents chkUseTextScaleOnClipart As CheckBox
    Friend WithEvents chkUseClipartScaleOnText As CheckBox
    Friend WithEvents chkHideNorthValue As CheckBox
End Class
