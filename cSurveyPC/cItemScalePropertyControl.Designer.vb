<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cItemScalePropertyControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cItemScalePropertyControl))
        Me.lblScaleStep = New System.Windows.Forms.Label()
        Me.txtScaleStep = New System.Windows.Forms.NumericUpDown()
        Me.lblScaleColor = New System.Windows.Forms.Label()
        Me.cmdScaleColorBrowse = New System.Windows.Forms.Button()
        Me.picScaleColor = New System.Windows.Forms.PictureBox()
        Me.lblScaleSteps = New System.Windows.Forms.Label()
        Me.txtScaleSteps = New System.Windows.Forms.NumericUpDown()
        Me.lblScaleMeters = New System.Windows.Forms.Label()
        Me.txtScaleMeters = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkHideScaleValue = New System.Windows.Forms.CheckBox()
        Me.lblScaleMetersUM = New System.Windows.Forms.Label()
        Me.lblScaleStepUM = New System.Windows.Forms.Label()
        CType(Me.txtScaleStep, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picScaleColor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtScaleSteps, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtScaleMeters, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblScaleStep
        '
        resources.ApplyResources(Me.lblScaleStep, "lblScaleStep")
        Me.lblScaleStep.Name = "lblScaleStep"
        '
        'txtScaleStep
        '
        resources.ApplyResources(Me.txtScaleStep, "txtScaleStep")
        Me.txtScaleStep.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtScaleStep.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtScaleStep.Name = "txtScaleStep"
        Me.txtScaleStep.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblScaleColor
        '
        resources.ApplyResources(Me.lblScaleColor, "lblScaleColor")
        Me.lblScaleColor.Name = "lblScaleColor"
        '
        'cmdScaleColorBrowse
        '
        resources.ApplyResources(Me.cmdScaleColorBrowse, "cmdScaleColorBrowse")
        Me.cmdScaleColorBrowse.Name = "cmdScaleColorBrowse"
        Me.cmdScaleColorBrowse.UseVisualStyleBackColor = True
        '
        'picScaleColor
        '
        resources.ApplyResources(Me.picScaleColor, "picScaleColor")
        Me.picScaleColor.Name = "picScaleColor"
        Me.picScaleColor.TabStop = False
        '
        'lblScaleSteps
        '
        resources.ApplyResources(Me.lblScaleSteps, "lblScaleSteps")
        Me.lblScaleSteps.Name = "lblScaleSteps"
        '
        'txtScaleSteps
        '
        Me.txtScaleSteps.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        resources.ApplyResources(Me.txtScaleSteps, "txtScaleSteps")
        Me.txtScaleSteps.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtScaleSteps.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.txtScaleSteps.Name = "txtScaleSteps"
        Me.txtScaleSteps.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'lblScaleMeters
        '
        resources.ApplyResources(Me.lblScaleMeters, "lblScaleMeters")
        Me.lblScaleMeters.Name = "lblScaleMeters"
        '
        'txtScaleMeters
        '
        Me.txtScaleMeters.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        resources.ApplyResources(Me.txtScaleMeters, "txtScaleMeters")
        Me.txtScaleMeters.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtScaleMeters.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.txtScaleMeters.Name = "txtScaleMeters"
        Me.txtScaleMeters.Value = New Decimal(New Integer() {10, 0, 0, 0})
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
        'chkHideScaleValue
        '
        resources.ApplyResources(Me.chkHideScaleValue, "chkHideScaleValue")
        Me.chkHideScaleValue.Name = "chkHideScaleValue"
        Me.chkHideScaleValue.UseVisualStyleBackColor = True
        '
        'lblScaleMetersUM
        '
        resources.ApplyResources(Me.lblScaleMetersUM, "lblScaleMetersUM")
        Me.lblScaleMetersUM.Name = "lblScaleMetersUM"
        '
        'lblScaleStepUM
        '
        resources.ApplyResources(Me.lblScaleStepUM, "lblScaleStepUM")
        Me.lblScaleStepUM.Name = "lblScaleStepUM"
        '
        'cItemScalePropertyControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.Controls.Add(Me.lblScaleStepUM)
        Me.Controls.Add(Me.lblScaleMetersUM)
        Me.Controls.Add(Me.chkHideScaleValue)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblScaleStep)
        Me.Controls.Add(Me.txtScaleStep)
        Me.Controls.Add(Me.lblScaleColor)
        Me.Controls.Add(Me.cmdScaleColorBrowse)
        Me.Controls.Add(Me.picScaleColor)
        Me.Controls.Add(Me.lblScaleSteps)
        Me.Controls.Add(Me.txtScaleSteps)
        Me.Controls.Add(Me.lblScaleMeters)
        Me.Controls.Add(Me.txtScaleMeters)
        Me.Name = "cItemScalePropertyControl"
        CType(Me.txtScaleStep, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picScaleColor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtScaleSteps, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtScaleMeters, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblScaleStep As Label
    Friend WithEvents txtScaleStep As NumericUpDown
    Friend WithEvents lblScaleColor As Label
    Friend WithEvents cmdScaleColorBrowse As Button
    Friend WithEvents picScaleColor As PictureBox
    Friend WithEvents lblScaleSteps As Label
    Friend WithEvents txtScaleSteps As NumericUpDown
    Friend WithEvents lblScaleMeters As Label
    Friend WithEvents txtScaleMeters As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents chkHideScaleValue As CheckBox
    Friend WithEvents lblScaleMetersUM As Label
    Friend WithEvents lblScaleStepUM As Label
End Class
