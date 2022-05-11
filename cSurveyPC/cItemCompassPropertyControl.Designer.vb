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
        Me.cmdCompassBrowseClipart = New DevExpress.XtraEditors.SimpleButton()
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
        Me.chkUseTextScaleOnClipart = New DevExpress.XtraEditors.CheckEdit()
        Me.chkUseClipartScaleOnText = New DevExpress.XtraEditors.CheckEdit()
        Me.chkHideNorthValue = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.picCompassClipartImage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCompassClipartZoomFactor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCompassYear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkUseTextScaleOnClipart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkUseClipartScaleOnText.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkHideNorthValue.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCompassBrowseClipart
        '
        Me.cmdCompassBrowseClipart.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdCompassBrowseClipart.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.open
        Me.cmdCompassBrowseClipart.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.cmdCompassBrowseClipart, "cmdCompassBrowseClipart")
        Me.cmdCompassBrowseClipart.Name = "cmdCompassBrowseClipart"
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
        Me.chkUseTextScaleOnClipart.Properties.Caption = resources.GetString("chkUseTextScaleOnClipart.Properties.Caption")
        '
        'chkUseClipartScaleOnText
        '
        resources.ApplyResources(Me.chkUseClipartScaleOnText, "chkUseClipartScaleOnText")
        Me.chkUseClipartScaleOnText.Name = "chkUseClipartScaleOnText"
        Me.chkUseClipartScaleOnText.Properties.Caption = resources.GetString("chkUseClipartScaleOnText.Properties.Caption")
        '
        'chkHideNorthValue
        '
        resources.ApplyResources(Me.chkHideNorthValue, "chkHideNorthValue")
        Me.chkHideNorthValue.Name = "chkHideNorthValue"
        Me.chkHideNorthValue.Properties.Caption = resources.GetString("chkHideNorthValue.Properties.Caption")
        '
        'cItemCompassPropertyControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
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
        Me.Controls.Add(Me.picCompassClipartImage)
        Me.Controls.Add(Me.lblCompassClipartZoomFactor)
        Me.Controls.Add(Me.txtCompassClipartZoomFactor)
        Me.Controls.Add(Me.lblCompassClipart)
        Me.Name = "cItemCompassPropertyControl"
        CType(Me.picCompassClipartImage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCompassClipartZoomFactor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCompassYear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkUseTextScaleOnClipart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkUseClipartScaleOnText.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkHideNorthValue.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCompassBrowseClipart As DevExpress.XtraEditors.SimpleButton
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
    Friend WithEvents chkUseTextScaleOnClipart As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkUseClipartScaleOnText As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkHideNorthValue As DevExpress.XtraEditors.CheckEdit
End Class
