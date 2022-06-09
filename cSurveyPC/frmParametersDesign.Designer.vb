<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmParametersDesign
    Inherits DevExpress.XtraEditors.XtraUserControl

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
        Me.lblAdvancedClippingMode = New DevExpress.XtraEditors.LabelControl()
        Me.cboAdvancedClippingMode = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
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
        'frmParametersDesign
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.cboAdvancedClippingMode)
        Me.Controls.Add(Me.lblAdvancedClippingMode)
        Me.Name = "frmParametersDesign"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblAdvancedClippingMode As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboAdvancedClippingMode As System.Windows.Forms.ComboBox
End Class
