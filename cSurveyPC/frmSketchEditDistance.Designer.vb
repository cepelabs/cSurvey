<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSketchEditDistance
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSketchEditDistance))
        Me.lblDistance = New DevExpress.XtraEditors.LabelControl()
        Me.txtDistance = New DevExpress.XtraEditors.SpinEdit()
        Me.lblDistanceUM = New DevExpress.XtraEditors.LabelControl()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.txtDistance.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblDistance
        '
        resources.ApplyResources(Me.lblDistance, "lblDistance")
        Me.lblDistance.Name = "lblDistance"
        '
        'txtDistance
        '
        resources.ApplyResources(Me.txtDistance, "txtDistance")
        Me.txtDistance.Name = "txtDistance"
        Me.txtDistance.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtDistance.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtDistance.Properties.DisplayFormat.FormatString = "N2"
        Me.txtDistance.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtDistance.Properties.EditFormat.FormatString = "N2"
        Me.txtDistance.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtDistance.Properties.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.txtDistance.Properties.MaxValue = New Decimal(New Integer() {999, 0, 0, 0})
        Me.txtDistance.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 131072})
        '
        'lblDistanceUM
        '
        resources.ApplyResources(Me.lblDistanceUM, "lblDistanceUM")
        Me.lblDistanceUM.Name = "lblDistanceUM"
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Name = "cmdCancel"
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Name = "cmdOk"
        '
        'frmSketchEditDistance
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.lblDistanceUM)
        Me.Controls.Add(Me.txtDistance)
        Me.Controls.Add(Me.lblDistance)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSketchEditDistance"
        CType(Me.txtDistance.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblDistance As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtDistance As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents lblDistanceUM As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
End Class
