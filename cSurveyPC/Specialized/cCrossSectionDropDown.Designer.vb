<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cCrossSectionDropDown
    Inherits System.Windows.Forms.UserControl

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
        Me.cboBindCrossSections = New DevExpress.XtraEditors.ComboBoxEdit()
        CType(Me.cboBindCrossSections.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboBindCrossSections
        '
        Me.cboBindCrossSections.Dock = System.Windows.Forms.DockStyle.Top
        Me.cboBindCrossSections.Enabled = False
        Me.cboBindCrossSections.Location = New System.Drawing.Point(0, 0)
        Me.cboBindCrossSections.Name = "cboBindCrossSections"
        Me.cboBindCrossSections.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboBindCrossSections.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cboBindCrossSections.Size = New System.Drawing.Size(346, 20)
        Me.cboBindCrossSections.TabIndex = 164
        Me.cboBindCrossSections.ToolTip = "Indicates to which cross-section connect the current object. If black the connect" &
    "ion is done by proximity."
        '
        'cCrossSectionDropDown
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.cboBindCrossSections)
        Me.Name = "cCrossSectionDropDown"
        Me.Size = New System.Drawing.Size(346, 60)
        CType(Me.cboBindCrossSections.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cboBindCrossSections As DevExpress.XtraEditors.ComboBoxEdit
End Class
