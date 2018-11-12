<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmParametersDesign
    Inherits cForm

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmParametersDesign))
        Me.cmdApply = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.lblAdvancedClippingMode = New System.Windows.Forms.Label()
        Me.cboAdvancedClippingMode = New System.Windows.Forms.ComboBox()
        Me.chkDrawSolidRock = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
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
        'lblAdvancedClippingMode
        '
        resources.ApplyResources(Me.lblAdvancedClippingMode, "lblAdvancedClippingMode")
        Me.lblAdvancedClippingMode.Name = "lblAdvancedClippingMode"
        '
        'cboAdvancedClippingMode
        '
        Me.cboAdvancedClippingMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAdvancedClippingMode.FormattingEnabled = True
        Me.cboAdvancedClippingMode.Items.AddRange(New Object() {resources.GetString("cboAdvancedClippingMode.Items"), resources.GetString("cboAdvancedClippingMode.Items1")})
        resources.ApplyResources(Me.cboAdvancedClippingMode, "cboAdvancedClippingMode")
        Me.cboAdvancedClippingMode.Name = "cboAdvancedClippingMode"
        '
        'chkDrawSolidRock
        '
        resources.ApplyResources(Me.chkDrawSolidRock, "chkDrawSolidRock")
        Me.chkDrawSolidRock.Name = "chkDrawSolidRock"
        Me.chkDrawSolidRock.UseVisualStyleBackColor = True
        '
        'frmParametersDesign
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.chkDrawSolidRock)
        Me.Controls.Add(Me.cmdApply)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cboAdvancedClippingMode)
        Me.Controls.Add(Me.lblAdvancedClippingMode)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmParametersDesign"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents lblAdvancedClippingMode As System.Windows.Forms.Label
    Friend WithEvents cboAdvancedClippingMode As System.Windows.Forms.ComboBox
    Friend WithEvents chkDrawSolidRock As CheckBox
End Class
