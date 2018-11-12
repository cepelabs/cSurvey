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
        Me.lblDistance = New System.Windows.Forms.Label()
        Me.txtDistance = New System.Windows.Forms.NumericUpDown()
        Me.lblDistanceUM = New System.Windows.Forms.Label()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        CType(Me.txtDistance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblDistance
        '
        resources.ApplyResources(Me.lblDistance, "lblDistance")
        Me.lblDistance.Name = "lblDistance"
        '
        'txtDistance
        '
        Me.txtDistance.DecimalPlaces = 2
        Me.txtDistance.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        resources.ApplyResources(Me.txtDistance, "txtDistance")
        Me.txtDistance.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.txtDistance.Minimum = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.txtDistance.Name = "txtDistance"
        Me.txtDistance.Value = New Decimal(New Integer() {1, 0, 0, 65536})
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
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'frmSketchEditDistance
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
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
        CType(Me.txtDistance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblDistance As Label
    Friend WithEvents txtDistance As NumericUpDown
    Friend WithEvents lblDistanceUM As Label
    Friend WithEvents cmdCancel As Button
    Friend WithEvents cmdOk As Button
End Class
