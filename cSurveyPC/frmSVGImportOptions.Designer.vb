<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSVGImportOptions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSVGImportOptions))
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.lblSVGLineType = New System.Windows.Forms.Label()
        Me.cboSVGLineType = New System.Windows.Forms.ComboBox()
        Me.lblSVGScale = New System.Windows.Forms.Label()
        Me.txtSVGScale = New System.Windows.Forms.NumericUpDown()
        Me.chkSVGAutodivide = New System.Windows.Forms.CheckBox()
        Me.txtSVGPathMaxLen = New System.Windows.Forms.NumericUpDown()
        Me.lblPlotSelectedPointSize = New System.Windows.Forms.Label()
        Me.txtSize = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.picPreview = New System.Windows.Forms.PictureBox()
        CType(Me.txtSVGScale, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSVGPathMaxLen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'lblSVGLineType
        '
        resources.ApplyResources(Me.lblSVGLineType, "lblSVGLineType")
        Me.lblSVGLineType.Name = "lblSVGLineType"
        '
        'cboSVGLineType
        '
        Me.cboSVGLineType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSVGLineType.FormattingEnabled = True
        Me.cboSVGLineType.Items.AddRange(New Object() {resources.GetString("cboSVGLineType.Items"), resources.GetString("cboSVGLineType.Items1"), resources.GetString("cboSVGLineType.Items2")})
        resources.ApplyResources(Me.cboSVGLineType, "cboSVGLineType")
        Me.cboSVGLineType.Name = "cboSVGLineType"
        '
        'lblSVGScale
        '
        resources.ApplyResources(Me.lblSVGScale, "lblSVGScale")
        Me.lblSVGScale.Name = "lblSVGScale"
        '
        'txtSVGScale
        '
        Me.txtSVGScale.DecimalPlaces = 3
        Me.txtSVGScale.Increment = New Decimal(New Integer() {1, 0, 0, 196608})
        resources.ApplyResources(Me.txtSVGScale, "txtSVGScale")
        Me.txtSVGScale.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.txtSVGScale.Name = "txtSVGScale"
        Me.txtSVGScale.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'chkSVGAutodivide
        '
        resources.ApplyResources(Me.chkSVGAutodivide, "chkSVGAutodivide")
        Me.chkSVGAutodivide.Name = "chkSVGAutodivide"
        Me.chkSVGAutodivide.UseVisualStyleBackColor = True
        '
        'txtSVGPathMaxLen
        '
        Me.txtSVGPathMaxLen.Increment = New Decimal(New Integer() {500, 0, 0, 0})
        resources.ApplyResources(Me.txtSVGPathMaxLen, "txtSVGPathMaxLen")
        Me.txtSVGPathMaxLen.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.txtSVGPathMaxLen.Name = "txtSVGPathMaxLen"
        '
        'lblPlotSelectedPointSize
        '
        resources.ApplyResources(Me.lblPlotSelectedPointSize, "lblPlotSelectedPointSize")
        Me.lblPlotSelectedPointSize.Name = "lblPlotSelectedPointSize"
        '
        'txtSize
        '
        resources.ApplyResources(Me.txtSize, "txtSize")
        Me.txtSize.Name = "txtSize"
        Me.txtSize.ReadOnly = True
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'picPreview
        '
        Me.picPreview.BackColor = System.Drawing.Color.White
        Me.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        resources.ApplyResources(Me.picPreview, "picPreview")
        Me.picPreview.Name = "picPreview"
        Me.picPreview.TabStop = False
        '
        'frmSVGImportOptions
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.picPreview)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSize)
        Me.Controls.Add(Me.chkSVGAutodivide)
        Me.Controls.Add(Me.txtSVGPathMaxLen)
        Me.Controls.Add(Me.lblSVGScale)
        Me.Controls.Add(Me.lblPlotSelectedPointSize)
        Me.Controls.Add(Me.txtSVGScale)
        Me.Controls.Add(Me.lblSVGLineType)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cboSVGLineType)
        Me.Controls.Add(Me.cmdOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.IconOptions.Icon = CType(resources.GetObject("frmSVGImportOptions.IconOptions.Icon"), System.Drawing.Icon)
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.import
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSVGImportOptions"
        CType(Me.txtSVGScale, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSVGPathMaxLen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents lblSVGLineType As System.Windows.Forms.Label
    Friend WithEvents cboSVGLineType As System.Windows.Forms.ComboBox
    Friend WithEvents lblSVGScale As System.Windows.Forms.Label
    Friend WithEvents txtSVGScale As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkSVGAutodivide As System.Windows.Forms.CheckBox
    Friend WithEvents txtSVGPathMaxLen As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblPlotSelectedPointSize As System.Windows.Forms.Label
    Friend WithEvents txtSize As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents picPreview As System.Windows.Forms.PictureBox
End Class
