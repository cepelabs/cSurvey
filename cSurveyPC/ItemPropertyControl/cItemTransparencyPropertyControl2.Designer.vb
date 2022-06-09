<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cItemTransparencyPropertyControl2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cItemTransparencyPropertyControl2))
        Me.lblPropTransparency = New DevExpress.XtraEditors.LabelControl()
        Me.trkTransparency = New DevExpress.XtraEditors.TrackBarControl()
        CType(Me.trkTransparency, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trkTransparency.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblPropTransparency
        '
        resources.ApplyResources(Me.lblPropTransparency, "lblPropTransparency")
        Me.lblPropTransparency.Name = "lblPropTransparency"
        '
        'trkTransparency
        '
        resources.ApplyResources(Me.trkTransparency, "trkTransparency")
        Me.trkTransparency.Name = "trkTransparency"
        Me.trkTransparency.Properties.AutoSize = False
        Me.trkTransparency.Properties.LabelAppearance.Options.UseTextOptions = True
        Me.trkTransparency.Properties.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.trkTransparency.Properties.Maximum = 255
        Me.trkTransparency.Properties.TickFrequency = 15
        '
        'cItemTransparencyPropertyControl2
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.trkTransparency)
        Me.Controls.Add(Me.lblPropTransparency)
        Me.Name = "cItemTransparencyPropertyControl2"
        CType(Me.trkTransparency.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trkTransparency, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblPropTransparency As DevExpress.XtraEditors.LabelControl
    Friend WithEvents trkTransparency As DevExpress.XtraEditors.TrackBarControl
End Class
