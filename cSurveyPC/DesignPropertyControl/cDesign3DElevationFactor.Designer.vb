<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cDesign3DElevationFactor
    Inherits cDesignPropertyControl

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

    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cDesign3DElevationFactor))
        Me.trk3DSurfaceElevationAmp = New DevExpress.XtraEditors.TrackBarControl()
        Me.lbl3DSurfaceElevationAmp = New DevExpress.XtraEditors.LabelControl()
        CType(Me.trk3DSurfaceElevationAmp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trk3DSurfaceElevationAmp.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'trk3DSurfaceElevationAmp
        '
        resources.ApplyResources(Me.trk3DSurfaceElevationAmp, "trk3DSurfaceElevationAmp")
        Me.trk3DSurfaceElevationAmp.Name = "trk3DSurfaceElevationAmp"
        Me.trk3DSurfaceElevationAmp.Properties.AutoSize = False
        Me.trk3DSurfaceElevationAmp.Properties.LabelAppearance.Options.UseTextOptions = True
        Me.trk3DSurfaceElevationAmp.Properties.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.trk3DSurfaceElevationAmp.Properties.LargeChange = 10
        Me.trk3DSurfaceElevationAmp.Properties.Maximum = 100
        Me.trk3DSurfaceElevationAmp.Properties.Minimum = 10
        Me.trk3DSurfaceElevationAmp.Properties.TickFrequency = 10
        Me.trk3DSurfaceElevationAmp.Value = 10
        '
        'lbl3DSurfaceElevationAmp
        '
        resources.ApplyResources(Me.lbl3DSurfaceElevationAmp, "lbl3DSurfaceElevationAmp")
        Me.lbl3DSurfaceElevationAmp.Name = "lbl3DSurfaceElevationAmp"
        '
        'cDesign3DElevationFactor
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.trk3DSurfaceElevationAmp)
        Me.Controls.Add(Me.lbl3DSurfaceElevationAmp)
        Me.Name = "cDesign3DElevationFactor"
        CType(Me.trk3DSurfaceElevationAmp.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trk3DSurfaceElevationAmp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents trk3DSurfaceElevationAmp As DevExpress.XtraEditors.TrackBarControl
    Friend WithEvents lbl3DSurfaceElevationAmp As DevExpress.XtraEditors.LabelControl
End Class
