<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cItemSignPropertyControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cItemSignPropertyControl))
        Me.cboPropSignFlip = New System.Windows.Forms.ComboBox()
        Me.lblPropSignFlip = New DevExpress.XtraEditors.LabelControl()
        Me.cboPropSign = New System.Windows.Forms.ComboBox()
        Me.lblPropSign = New DevExpress.XtraEditors.LabelControl()
        Me.cboPropSignSize = New System.Windows.Forms.ComboBox()
        Me.lblPropSignSize = New DevExpress.XtraEditors.LabelControl()
        Me.cboPropSignRotateMode = New System.Windows.Forms.ComboBox()
        Me.lblPropSignRotateMode = New DevExpress.XtraEditors.LabelControl()
        Me.lblPropSignRotationAngleDelta = New System.Windows.Forms.Label()
        Me.txtPropSignRotationAngleDelta = New System.Windows.Forms.NumericUpDown()
        CType(Me.txtPropSignRotationAngleDelta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboPropSignFlip
        '
        Me.cboPropSignFlip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropSignFlip.FormattingEnabled = True
        Me.cboPropSignFlip.Items.AddRange(New Object() {resources.GetString("cboPropSignFlip.Items"), resources.GetString("cboPropSignFlip.Items1"), resources.GetString("cboPropSignFlip.Items2"), resources.GetString("cboPropSignFlip.Items3")})
        resources.ApplyResources(Me.cboPropSignFlip, "cboPropSignFlip")
        Me.cboPropSignFlip.Name = "cboPropSignFlip"
        '
        'lblPropSignFlip
        '
        resources.ApplyResources(Me.lblPropSignFlip, "lblPropSignFlip")
        Me.lblPropSignFlip.Name = "lblPropSignFlip"
        '
        'cboPropSign
        '
        Me.cboPropSign.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboPropSign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboPropSign, "cboPropSign")
        Me.cboPropSign.Name = "cboPropSign"
        '
        'lblPropSign
        '
        Me.lblPropSign.Appearance.Font = CType(resources.GetObject("lblPropSign.Appearance.Font"), System.Drawing.Font)
        Me.lblPropSign.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblPropSign, "lblPropSign")
        Me.lblPropSign.Name = "lblPropSign"
        '
        'cboPropSignSize
        '
        Me.cboPropSignSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropSignSize.FormattingEnabled = True
        Me.cboPropSignSize.Items.AddRange(New Object() {resources.GetString("cboPropSignSize.Items"), resources.GetString("cboPropSignSize.Items1"), resources.GetString("cboPropSignSize.Items2"), resources.GetString("cboPropSignSize.Items3"), resources.GetString("cboPropSignSize.Items4"), resources.GetString("cboPropSignSize.Items5"), resources.GetString("cboPropSignSize.Items6"), resources.GetString("cboPropSignSize.Items7"), resources.GetString("cboPropSignSize.Items8"), resources.GetString("cboPropSignSize.Items9"), resources.GetString("cboPropSignSize.Items10"), resources.GetString("cboPropSignSize.Items11"), resources.GetString("cboPropSignSize.Items12"), resources.GetString("cboPropSignSize.Items13")})
        resources.ApplyResources(Me.cboPropSignSize, "cboPropSignSize")
        Me.cboPropSignSize.Name = "cboPropSignSize"
        '
        'lblPropSignSize
        '
        resources.ApplyResources(Me.lblPropSignSize, "lblPropSignSize")
        Me.lblPropSignSize.Name = "lblPropSignSize"
        '
        'cboPropSignRotateMode
        '
        Me.cboPropSignRotateMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropSignRotateMode.FormattingEnabled = True
        Me.cboPropSignRotateMode.Items.AddRange(New Object() {resources.GetString("cboPropSignRotateMode.Items"), resources.GetString("cboPropSignRotateMode.Items1")})
        resources.ApplyResources(Me.cboPropSignRotateMode, "cboPropSignRotateMode")
        Me.cboPropSignRotateMode.Name = "cboPropSignRotateMode"
        '
        'lblPropSignRotateMode
        '
        resources.ApplyResources(Me.lblPropSignRotateMode, "lblPropSignRotateMode")
        Me.lblPropSignRotateMode.Name = "lblPropSignRotateMode"
        '
        'lblPropSignRotationAngleDelta
        '
        resources.ApplyResources(Me.lblPropSignRotationAngleDelta, "lblPropSignRotationAngleDelta")
        Me.lblPropSignRotationAngleDelta.Name = "lblPropSignRotationAngleDelta"
        '
        'txtPropSignRotationAngleDelta
        '
        Me.txtPropSignRotationAngleDelta.DecimalPlaces = 1
        Me.txtPropSignRotationAngleDelta.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        resources.ApplyResources(Me.txtPropSignRotationAngleDelta, "txtPropSignRotationAngleDelta")
        Me.txtPropSignRotationAngleDelta.Maximum = New Decimal(New Integer() {3599, 0, 0, 65536})
        Me.txtPropSignRotationAngleDelta.Name = "txtPropSignRotationAngleDelta"
        '
        'cItemSignPropertyControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.lblPropSignRotationAngleDelta)
        Me.Controls.Add(Me.txtPropSignRotationAngleDelta)
        Me.Controls.Add(Me.cboPropSignFlip)
        Me.Controls.Add(Me.lblPropSignFlip)
        Me.Controls.Add(Me.cboPropSign)
        Me.Controls.Add(Me.lblPropSign)
        Me.Controls.Add(Me.cboPropSignSize)
        Me.Controls.Add(Me.lblPropSignSize)
        Me.Controls.Add(Me.cboPropSignRotateMode)
        Me.Controls.Add(Me.lblPropSignRotateMode)
        Me.Name = "cItemSignPropertyControl"
        CType(Me.txtPropSignRotationAngleDelta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboPropSignFlip As ComboBox
    Friend WithEvents lblPropSignFlip As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboPropSign As ComboBox
    Friend WithEvents lblPropSign As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboPropSignSize As ComboBox
    Friend WithEvents lblPropSignSize As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboPropSignRotateMode As ComboBox
    Friend WithEvents lblPropSignRotateMode As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPropSignRotationAngleDelta As Label
    Friend WithEvents txtPropSignRotationAngleDelta As NumericUpDown
End Class
